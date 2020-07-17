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

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private async void LoadBreachstones(object sender, RoutedEventArgs e)
        {
            await BreachstonePriceProcessor.InitLoadAsync();
            List<Tuple<string, float>> stones = BreachstonePriceProcessor.ProfitCalc();
            string temp = "";
            foreach (var item in stones)
            {
                temp += $"{item.Item1, -40}{item.Item2}\n";
            }
            TestBox.Text = temp;
        }

        private void TestClear(object sender, RoutedEventArgs e)
        {
            TestBox.Text = "";
        }

        private async void UpdateBreachstones(object sender, RoutedEventArgs e)
        {
            await BreachstonePriceProcessor.LoadData();
            LoadBreachstones(sender, e);
        }
    }
}
