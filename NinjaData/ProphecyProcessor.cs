using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NinjaData
{
    public static class ProphecyProcessor
    {
        private static ProphecyListingModel AllProphecies { get; set; }
        public static Prophecy[] PaleCourtProphecies { get; set; } = new Prophecy[4];
        public static bool InitialLoadCompleted { get; set; } = false;
        public static async Task InitLoadAsync()
        {
            if (!InitialLoadCompleted)
            {
                await LoadData();
                InitialLoadCompleted = true;
            }
        }
        public static async Task LoadData() {

            string url = $"itemoverview?league={ApiHelper.currentLeague}&type=Prophecy";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    AllProphecies = await response.Content.ReadAsAsync<ProphecyListingModel>();
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
            LoadProphecies();
        }
        public static void LoadProphecies()
        {
            foreach(var item in AllProphecies.Lines)
            {
                switch (item.Name)
                {
                    case "The Unbreathing Queen V":
                        PaleCourtProphecies[0] = item;
                        break;
                    case "Unbearable Whispers V":
                        PaleCourtProphecies[1] = item;
                        break;
                    case "The Plaguemaw V":
                        PaleCourtProphecies[2] = item;
                        break;
                    case "The Feral Lord V":
                        PaleCourtProphecies[3] = item;
                        break;
                    default:
                        break;
                }
            }
        }

    }
}
