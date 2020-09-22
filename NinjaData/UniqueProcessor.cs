using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NinjaData
{
    public static class UniqueProcessor
    {
        private static UniqueListingModel UniqueJewels { get; set; }
        private static UniqueListingModel UniqueFlasks { get; set; }
        private static UniqueListingModel UniqueWeapons { get; set; }
        private static UniqueListingModel UniqueArmours { get; set; }
        private static UniqueListingModel UniqueAccessories { get; set; }
        private static UniqueListingModel UniqueMaps { get; set; }

        public static Unique[] FatedUniques { get; set; } = new Unique[57];
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

            string url = $"itemoverview?league={ApiHelper.currentLeague}&type=UniqueJewel";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    UniqueJewels = await response.Content.ReadAsAsync<UniqueListingModel>();
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }

            url = $"itemoverview?league={ApiHelper.currentLeague}&type=UniqueFlask";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    UniqueFlasks = await response.Content.ReadAsAsync<UniqueListingModel>();
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }

            url = $"itemoverview?league={ApiHelper.currentLeague}&type=UniqueWeapon";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    UniqueWeapons = await response.Content.ReadAsAsync<UniqueListingModel>();
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }

            url = $"itemoverview?league={ApiHelper.currentLeague}&type=UniqueArmour";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    UniqueArmours = await response.Content.ReadAsAsync<UniqueListingModel>();
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }

            url = $"itemoverview?league={ApiHelper.currentLeague}&type=UniqueAccessory";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    UniqueAccessories = await response.Content.ReadAsAsync<UniqueListingModel>();
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }

            url = $"itemoverview?league={ApiHelper.currentLeague}&type=UniqueMap";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    UniqueMaps = await response.Content.ReadAsAsync<UniqueListingModel>();
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }


            LoadUniques();
        }
        public static void LoadUniques()
        {
            Sort(UniqueAccessories);
            Sort(UniqueMaps);
            Sort(UniqueArmours);
            Sort(UniqueFlasks);
            Sort(UniqueJewels);
            Sort(UniqueWeapons);
        }
        private static void Sort(UniqueListingModel arr)
        {
            foreach (var item in arr.Lines)
            {
                if (item.links == 0)
                {
                    switch (item.Name)
                    {
                        case "Amplification Rod":
                            FatedUniques[0] = item;
                            break;
                        case "Asenath's Chant":
                            FatedUniques[1] = item;
                            break;
                        case "Atziri's Reflection":
                            FatedUniques[2] = item;
                            break;
                        case "Cameria's Avarice":
                            FatedUniques[3] = item;
                            break;
                        case "Chaber Cairn":
                            FatedUniques[4] = item;
                            break;
                        case "Corona Solaris":
                            FatedUniques[5] = item;
                            break;
                        case "Cragfall":
                            FatedUniques[6] = item;
                            break;
                        case "Crystal Vault":
                            FatedUniques[7] = item;
                            break;
                        case "Death's Opus":
                            FatedUniques[8] = item;
                            break;
                        case "Deidbellow":
                            FatedUniques[9] = item;
                            break;
                        case "Doedre's Malevolence":
                            FatedUniques[10] = item;
                            break;
                        case "Doomfletch's Prism":
                            FatedUniques[11] = item;
                            break;
                        case "Dreadbeak":
                            FatedUniques[12] = item;
                            break;
                        case "Dreadsurge":
                            FatedUniques[13] = item;
                            break;
                        case "Duskblight":
                            FatedUniques[14] = item;
                            break;
                        case "Ezomyte Hold":
                            FatedUniques[15] = item;
                            break;
                        case "Fox's Fortune":
                            FatedUniques[16] = item;
                            break;
                        case "Frostferno":
                            FatedUniques[17] = item;
                            break;
                        case "Geofri's Devotion":
                            FatedUniques[18] = item;
                            break;
                        case "Geofri's Legacy":
                            FatedUniques[19] = item;
                            break;
                        case "Greedtrap":
                            FatedUniques[20] = item;
                            break;
                        case "Hrimburn":
                            FatedUniques[21] = item;
                            break;
                        case "Hrimnor's Dirge":
                            FatedUniques[22] = item;
                            break;
                        case "Hyrri's Demise":
                            FatedUniques[23] = item;
                            break;
                        case "Kaltensoul":
                            FatedUniques[24] = item;
                            break;
                        case "Kaom's Way":
                            FatedUniques[25] = item;
                            break;
                        case "Karui Charge":
                            FatedUniques[26] = item;
                            break;
                        case "Malachai's Awakening":
                            FatedUniques[27] = item;
                            break;
                        case "Martyr's Crown":
                            FatedUniques[28] = item;
                            break;
                        case "Mirebough":
                            FatedUniques[29] = item;
                            break;
                        case "Ngamahu Tiki":
                            FatedUniques[30] = item;
                            break;
                        case "Panquetzaliztli":
                            FatedUniques[31] = item;
                            break;
                        case "Queen's Escape":
                            FatedUniques[32] = item;
                            break;
                        case "Realm Ender":
                            FatedUniques[33] = item;
                            break;
                        case "Sanguine Gambol":
                            FatedUniques[34] = item;
                            break;
                        case "Shavronne's Gambit":
                            FatedUniques[35] = item;
                            break;
                        case "Silverbough":
                            FatedUniques[36] = item;
                            break;
                        case "Sunspite":
                            FatedUniques[37] = item;
                            break;
                        case "The Cauteriser":
                            FatedUniques[38] = item;
                            break;
                        case "The Dancing Duo":
                            FatedUniques[39] = item;
                            break;
                        case "The Effigon":
                            FatedUniques[40] = item;
                            break;
                        case "The Gryphon":
                            FatedUniques[41] = item;
                            break;
                        case "The Iron Fortress":
                            FatedUniques[42] = item;
                            break;
                        case "The Nomad":
                            FatedUniques[43] = item;
                            break;
                        case "The Oak":
                            FatedUniques[44] = item;
                            break;
                        case "The Signal Fire":
                            FatedUniques[45] = item;
                            break;
                        case "The Stormwall":
                            FatedUniques[46] = item;
                            break;
                        case "The Tactician":
                            FatedUniques[47] = item;
                            break;
                        case "The Tempest":
                            FatedUniques[48] = item;
                            break;
                        case "Thirst for Horrors":
                            FatedUniques[49] = item;
                            break;
                        case "Timetwist":
                            FatedUniques[50] = item;
                            break;
                        case "Voidheart":
                            FatedUniques[51] = item;
                            break;
                        case "Wall of Brambles":
                            FatedUniques[52] = item;
                            break;
                        case "Whakatutuki o Matua":
                            FatedUniques[53] = item;
                            break;
                        case "Wildwrap":
                            FatedUniques[54] = item;
                            break;
                        case "Windshriek":
                            FatedUniques[55] = item;
                            break;
                        case "Winterweave":
                            FatedUniques[56] = item;
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        public static List<FatedUniquePriceDiff> FatedUniqueProfitCalc()
        {
            List<FatedUniquePriceDiff> profits = new List<FatedUniquePriceDiff>();
            for (int i = 0; i < 57; i++)
            {
                if (FatedUniques[i] != null && ProphecyProcessor.FatedUniqueProphecies[i] != null)
                {
                        FatedUniquePriceDiff temp = new FatedUniquePriceDiff(FatedUniques[i].Name, FatedUniques[i].chaosValue,
                            ProphecyProcessor.FatedUniqueProphecies[i].Name, ProphecyProcessor.FatedUniqueProphecies[i].chaosValue,
                            FatedUniques[i].chaosValue - ProphecyProcessor.FatedUniqueProphecies[i].chaosValue);

                        /*
                        switch (temp.KeyName)
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
                        */
                        profits.Add(temp);

                }
            }
            profits.Sort(
                (x, y) => y.Profit.CompareTo(x.Profit)
            );
            return profits;
        }

    }
}
public class FatedUniquePriceDiff
{
    public string ProphecyName { get; set; }
    public float ProphecyPrice { get; set; }
    public string UniqueName { get; set; }
    public float UniquePrice { get; set; }
    public string Note { get; set; }
    public float Profit { get; set; }
    public FatedUniquePriceDiff(string uName, float uPrice, string pName, float pPrice, float profit)
    {
        ProphecyName = pName;
        ProphecyPrice = pPrice;
        UniqueName = uName;
        UniquePrice = uPrice;
        Note = "";
        Profit = profit;
    }
}
