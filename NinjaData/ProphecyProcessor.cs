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
        public static Prophecy[] FatedUniqueProphecies { get; set; } = new Prophecy[57];
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
                    case "Power Magnified":
                        FatedUniqueProphecies[0] = item;
                        break;
                    case "Song of the Sekhema":
                        FatedUniqueProphecies[1] = item;
                        break;
                    case "The Queen's Sacrifice":
                        FatedUniqueProphecies[2] = item;
                        break;
                    case "Cold Greed":
                        FatedUniqueProphecies[3] = item;
                        break;
                    case "Faith Exhumed":
                        FatedUniqueProphecies[4] = item;
                        break;
                    case "Blinding Light":
                        FatedUniqueProphecies[5] = item;
                        break;
                    case "Heavy Blows":
                        FatedUniqueProphecies[6] = item;
                        break;
                    case "End of the Light":
                        FatedUniqueProphecies[7] = item;
                        break;
                    case "The Bowstring's Music":
                        FatedUniqueProphecies[8] = item;
                        break;
                    case "Dying Cry":
                        FatedUniqueProphecies[9] = item;
                        break;
                    case "The Malevolent Witch":
                        FatedUniqueProphecies[10] = item;
                        break;
                    case "Ancient Doom":
                        FatedUniqueProphecies[11] = item;
                        break;
                    case "The Dreaded Rhoa":
                        FatedUniqueProphecies[12] = item;
                        break;
                    case "Burning Dread":
                        FatedUniqueProphecies[13] = item;
                        break;
                    case "Agony at Dusk":
                        FatedUniqueProphecies[14] = item;
                        break;
                    case "The Bloody Flowers Redux":
                        FatedUniqueProphecies[15] = item;
                        break;
                    case "Dark Instincts":
                        FatedUniqueProphecies[16] = item;
                        break;
                    case "A Vision of Ice and Fire":
                        FatedUniqueProphecies[17] = item;
                        break;
                    case "Black Devotion":
                        FatedUniqueProphecies[18] = item;
                        break;
                    case "The Bishop's Legacy":
                        FatedUniqueProphecies[19] = item;
                        break;
                    case "Greed's Folly":
                        FatedUniqueProphecies[20] = item;
                        break;
                    case "Fire and Ice":
                        FatedUniqueProphecies[21] = item;
                        break;
                    case "Winter's Mournful Melodies":
                        FatedUniqueProphecies[22] = item;
                        break;
                    case "A Dishonourable Death":
                        FatedUniqueProphecies[23] = item;
                        break;
                    case "The Snuffed Flame":
                        FatedUniqueProphecies[24] = item;
                        break;
                    case "The King's Path":
                        FatedUniqueProphecies[25] = item;
                        break;
                    case "The Karui Rebellion":
                        FatedUniqueProphecies[26] = item;
                        break;
                    case "The Nightmare Awakens":
                        FatedUniqueProphecies[27] = item;
                        break;
                    case "Pleasure and Pain":
                        FatedUniqueProphecies[28] = item;
                        break;
                    case "Trapped in the Tower":
                        FatedUniqueProphecies[29] = item;
                        break;
                    case "A Forest of False Idols":
                        FatedUniqueProphecies[30] = item;
                        break;
                    case "The Fall of an Empire":
                        FatedUniqueProphecies[31] = item;
                        break;
                    case "The Misunderstood Queen":
                        FatedUniqueProphecies[32] = item;
                        break;
                    case "The Beginning and the End":
                        FatedUniqueProphecies[33] = item;
                        break;
                    case "Crimson Hues":
                        FatedUniqueProphecies[34] = item;
                        break;
                    case "The Flow of Energy":
                        FatedUniqueProphecies[35] = item;
                        break;
                    case "The Silverwood":
                        FatedUniqueProphecies[36] = item;
                        break;
                    case "Sun's Punishment":
                        FatedUniqueProphecies[37] = item;
                        break;
                    case "Severed Limbs":
                        FatedUniqueProphecies[38] = item;
                        break;
                    case "Dance of Steel":
                        FatedUniqueProphecies[39] = item;
                        break;
                    case "Blind Faith":
                        FatedUniqueProphecies[40] = item;
                        break;
                    case "The Apex Predator":
                        FatedUniqueProphecies[41] = item;
                        break;
                    case "Battle Hardened":
                        FatedUniqueProphecies[42] = item;
                        break;
                    case "The Great Leader of the North":
                        FatedUniqueProphecies[43] = item;
                        break;
                    case "Nature's Resilience":
                        FatedUniqueProphecies[44] = item;
                        break;
                    case "Fire and Brimstone":
                        FatedUniqueProphecies[45] = item;
                        break;
                    case "The Storm Spire":
                        FatedUniqueProphecies[46] = item;
                        break;
                    case "The Great Mind of the North":
                        FatedUniqueProphecies[47] = item;
                        break;
                    case "The Servant's Heart":
                        FatedUniqueProphecies[48] = item;
                        break;
                    case "Mouth of Horrors":
                        FatedUniqueProphecies[49] = item;
                        break;
                    case "A Rift in Time":
                        FatedUniqueProphecies[50] = item;
                        break;
                    case "From The Void":
                        FatedUniqueProphecies[51] = item;
                        break;
                    case "The King and the Brambles":
                        FatedUniqueProphecies[52] = item;
                        break;
                    case "The Mentor":
                        FatedUniqueProphecies[53] = item;
                        break;
                    case "Last of the Wildmen":
                        FatedUniqueProphecies[54] = item;
                        break;
                    case "Darktongue's Shriek":
                        FatedUniqueProphecies[55] = item;
                        break;
                    case "Cold Blooded Fury":
                        FatedUniqueProphecies[56] = item;
                        break;
                    default:
                        break;
                }
            }
        }

    }
}
