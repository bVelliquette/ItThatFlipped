using NinjaData;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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
    /// Interaction logic for Breachstones.xaml
    /// </summary>
    public partial class Breachstones : UserControl
    {
        public Breachstones()
        {
            InitializeComponent();
        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                await FragmentsPriceProcessor.InitLoadAsync();

                List<BreachStonePriceDiff> stones = FragmentsPriceProcessor.BreachstoneProfitCalc();
                PriceList.ItemsSource = stones;
                Status.Text = $"Breachstone prices successfully loaded for {ApiHelper.currentLeague} league";

            }
            catch (System.Net.Http.HttpRequestException)
            {
                Status.Text = "Could not resolve hostname.\nCheck your internet connection, or poe.ninja servers may be down.";
            }

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
    }
}
