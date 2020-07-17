using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NinjaData
{
    
    public static class BreachstonePriceProcessor
    {
        public static Fragment[] Stones { get; set; }
        public static BreachstoneListingModel AllFrags { get; set; }

        private static bool InitialLoadCompleted { get; set; } = false;

        public static async Task InitLoadAsync()
        {
            if (!InitialLoadCompleted)
            {
                await LoadData();
                InitialLoadCompleted = true;
            }
        }
        public static async Task LoadData()
        {
            string url = "currencyoverview?league=Harvest&type=Fragment";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    AllFrags = await response.Content.ReadAsAsync<BreachstoneListingModel>();
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
            LoadStones();

        }
        public static void LoadStones()
        {
            Stones = new Fragment[10];

            foreach (var listing in AllFrags.Lines)
            {
                switch(listing.CurrencyTypeName)
                {
                    case "Xoph's Breachstone":
                        Stones[0] = listing;
                        break;
                    case "Esh's Breachstone":
                        Stones[2] = listing;
                        break;
                    case "Tul's Breachstone":
                        Stones[4] = listing;
                        break;
                    case "Uul-Netol's Breachstone":
                        Stones[6] = listing;
                        break;
                    case "Chayula's Breachstone":
                        Stones[8] = listing;
                        break;
                    case "Xoph's Pure Breachstone":
                        Stones[1] = listing;
                        break;
                    case "Esh's Pure Breachstone":
                        Stones[3] = listing;
                        break;
                    case "Tul's Pure Breachstone":
                        Stones[5] = listing;
                        break;
                    case "Uul-Netol's Pure Breachstone":
                        Stones[7] = listing;
                        break;
                    case "Chayula's Pure Breachstone":
                        Stones[9] = listing;
                        break;
                    default:
                        break;
                }
            }
        }
        public static List<Tuple<string, float>> ProfitCalc()
        {
            List<Tuple<string, float>> profits = new List<Tuple<string, float>>();
            for (int i = 0; i < 10; i += 2)
                profits.Add(new Tuple<string, float>(Stones[i].CurrencyTypeName, Stones[i + 1].chaosEquivalent - Stones[i].chaosEquivalent));

            profits.Sort(
                (x, y) => y.Item2.CompareTo(x.Item2)
                );

            return profits;
        }
    }
}
