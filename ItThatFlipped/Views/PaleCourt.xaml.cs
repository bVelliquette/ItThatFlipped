using NinjaData;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ItThatFlipped.Views
{
    /// <summary>
    /// Interaction logic for PaleCourt.xaml
    /// </summary>
    public partial class PaleCourt : UserControl
    {
        public PaleCourt()
        {
            InitializeComponent();
        }
        private async void UpdateFragments(object sender, RoutedEventArgs e)
        {
            try
            {
                await FragmentsPriceProcessor.LoadData();
                UserControl_Loaded(sender, e);
            }
            catch (System.Net.Http.HttpRequestException)
            {
                Status.Text = "Could not resolve hostname.\nCheck your internet connection, or poe.ninja servers may be down.";
            }
        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                await FragmentsPriceProcessor.InitLoadAsync();
                await ProphecyProcessor.InitLoadAsync();

                List<Tuple<string, float, string, float, float>> PaleCourtKeys = FragmentsPriceProcessor.PaleCourtProfitCalc();
                string temp = "";
                foreach (var item in PaleCourtKeys)
                {
                    temp += $"{item.Item1}: {item.Item2:F2}\n";
                    temp += $"{item.Item3}: {item.Item4:F2}\n";
                    temp += $"Profit: {item.Item5:F2} Chaos\n\n";
                }
                TestBox.Text = temp;
                Status.Text = $"PaleCourt prices successfully loaded for {ApiHelper.currentLeague} league";
            }
            catch (System.Net.Http.HttpRequestException)
            {
                Status.Text = "Could not resolve hostname.\nCheck your internet connection, or poe.ninja servers may be down.";
            }

        }
    }
}
