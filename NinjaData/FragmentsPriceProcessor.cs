using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NinjaData
{
    
    public static class FragmentsPriceProcessor
    {
        private static Fragment[] Stones { get; } = new Fragment[10];
        private static FragmentsListingModel AllFrags { get; set; }

        private static Fragment[] PaleCourtKeys { get; } = new Fragment[4];

        public static bool InitialLoadCompleted { get; set; } = false;

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
            string url = $"currencyoverview?league={ApiHelper.currentLeague}&type=Fragment";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    AllFrags = await response.Content.ReadAsAsync<FragmentsListingModel>();
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
            LoadFrags();

        }
        public static void LoadFrags()
        {
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
                    case "Volkuur's Key":
                        PaleCourtKeys[0] = listing;
                        break;
                    case "Inya's Key":
                        PaleCourtKeys[1] = listing;
                        break;
                    case "Eber's Key":
                        PaleCourtKeys[2] = listing;
                        break;
                    case "Yriel's Key":
                        PaleCourtKeys[3] = listing;
                        break;
                    default:
                        break;
                }
            }
        }
        public static List<BreachStonePriceDiff> BreachstoneProfitCalc()
        {
            List<BreachStonePriceDiff> profits = new List<BreachStonePriceDiff>();
            for (int i = 0; i < 10; i += 2)
                profits.Add(new BreachStonePriceDiff(Stones[i].CurrencyTypeName, (float)Math.Round(Stones[i + 1].chaosEquivalent - Stones[i].chaosEquivalent, 2)));

            profits.Sort(
                (x, y) => y.BreachStonePrice.CompareTo(x.BreachStonePrice)
                );

            return profits;
        }

        public static List<PaleCourtPriceDiff> PaleCourtProfitCalc()
        {
            List<PaleCourtPriceDiff> profits = new List<PaleCourtPriceDiff>();
            for (int i = 0; i < 4; i++)
            {
                PaleCourtPriceDiff temp = new PaleCourtPriceDiff(PaleCourtKeys[i].CurrencyTypeName, PaleCourtKeys[i].chaosEquivalent,
                    ProphecyProcessor.PaleCourtProphecies[i].Name, ProphecyProcessor.PaleCourtProphecies[i].chaosValue,
                    PaleCourtKeys[i].chaosEquivalent - ProphecyProcessor.PaleCourtProphecies[i].chaosValue);

                switch(temp.KeyName)
                {
                    case "Volkuur's Key":
                        temp.Note = "Completed in a Cemetery Map";
                        break;
                    case "Inya's Key":
                        temp.Note = "Completed in the Labyrinth";
                        break;
                    case "Eber's Key":
                        temp.Note = "Completed in the Crystal Veins or Crystal Ore Map";
                        break;
                    case "Yriel's Key":
                        temp.Note = "Completed in the a Mud Geyser Map";
                        break;
                    default:
                        temp.Note = "Ya blew it";
                        break;
                }

                profits.Add(temp);
            }
            return profits;
        }
    }

    public class BreachStonePriceDiff
    {
        public string BreachStoneName { get; set; }
        public float BreachStonePrice { get; set; }

        public BreachStonePriceDiff(string name, float price)
        {
            BreachStoneName = name;
            BreachStonePrice = price;
        }
    }

    public class PaleCourtPriceDiff
    {
        public string ProphecyName { get; set; }
        public float ProphecyPrice{ get; set; }
        public string KeyName { get; set; }
        public float KeyPrice { get; set; }
        public string Note { get; set; }
        public float Profit { get; set; }
        public PaleCourtPriceDiff(string kName, float kPrice, string pName, float pPrice, float profit)
        {
            ProphecyName = pName;
            ProphecyPrice = pPrice;
            KeyName = kName;
            KeyPrice = kPrice;
            Note = "";
            Profit = profit;
        }
    }
}
