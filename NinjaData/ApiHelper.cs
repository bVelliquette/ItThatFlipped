using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace NinjaData
{
    public static class ApiHelper
    {
        public static HttpClient ApiClient { get; set; }
        public static List<string> LeagueNames { get; set; }

        public static string currentLeague { get; set; }

        public static void InitializeClient()
        {
            ApiClient = new HttpClient();
            LoadLeagues();
            ApiClient.BaseAddress = new Uri("https://poe.ninja/api/data/");
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static void LoadLeagues()
        {
            string url = "http://api.pathofexile.com/leagues?type=main";
            using (HttpClient temp = new HttpClient())
            {
                temp.DefaultRequestHeaders.Accept.Clear();
                temp.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                using (HttpResponseMessage response = temp.GetAsync(url).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        List<LeagueModel> tempNames = response.Content.ReadAsAsync<List<LeagueModel>>().Result;
                        List<string> tempList = new List<string>();
                        foreach (var item in tempNames)
                        {
                            if(!item.id.Contains("SSF"))
                                tempList.Add(item.id);
                        }
                        LeagueNames = tempList;
                    }
                    else
                    {
                        throw new Exception(response.ReasonPhrase);
                    }
                }
            }
 
        }
    }

    public class LeagueModel
    {
        public string id { get; set; }
    }
}
