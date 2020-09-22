using ItThatFlipped.ViewModels;
using ItThatFlipped.Views;
using NinjaData;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace ItThatFlipped
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ApiHelper.InitializeClient();
        }

        private void PaleCourt_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new PaleCourtModel();
        }

        private void Breachstone_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new BreachstonesModel();
        }

        private void Fated_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new FatedModel();
        }

        private void MainLoaded(object sender, RoutedEventArgs e)
        {
            LeagueSelect.ItemsSource = ApiHelper.LeagueNames;
            LeagueSelect.SelectedIndex = 2; //Defaults to Current trade challenge league.
        }

        private void NewLeagueSelected(object sender, SelectionChangedEventArgs e)
        {
            ApiHelper.currentLeague = (string)LeagueSelect.SelectedItem;
            FragmentsPriceProcessor.InitialLoadCompleted = false;
            ProphecyProcessor.InitialLoadCompleted = false;
        }
    }
}
