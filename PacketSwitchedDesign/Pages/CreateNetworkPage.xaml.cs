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

namespace PacketSwitchedDesign.Pages
{
    /// <summary>
    /// Interaction logic for InputDataPage.xaml
    /// </summary>
    public partial class CreateNetworkPage : Page
    {


        public static AddLinkPage addLinkPage = new AddLinkPage();
        public static AddRouterPage addRouterPage = new AddRouterPage();
        public static AddETEConnectionPage addETEConnectionPage = new AddETEConnectionPage();
        public static AddTrafficParamsPage addTrafficParamsPage = new AddTrafficParamsPage();
        public static AddQualityParamsPage addQualityParamsPage = new AddQualityParamsPage();
        public static AddWZPage addWZPage = new AddWZPage();
        public CreateNetworkPage()
        {
            InitializeComponent();
        }

        private void AddRouterClick(object sender, RoutedEventArgs e)
        {
            CreateNetworkFrame.Navigate(addRouterPage);
        }

        private void AddLinksClick(object sender, RoutedEventArgs e)
        {
            if (MainPage.network.Routers.Count != 0)
            {
                CreateNetworkFrame.Navigate(addLinkPage);
            }
            else
            {
                MessageBox.Show("Dodaj węzły do sieci");
            }
        }

        private void AddETEConnectionClick(object sender, RoutedEventArgs e)
        {
            if (MainPage.network.Links.Count > 0)
            {
            CreateNetworkFrame.Navigate(addETEConnectionPage);

                addETEConnectionPage.LinkList.ItemsSource = MainPage.network.Links;
                addETEConnectionPage.LinkList.Items.Refresh();
                
            }
            else
            {
               MessageBox.Show("Dodaj połączenia");
            }
        }

        private void AddTrafficParamsClick(object sender, RoutedEventArgs e)
        {
            if (MainPage.network.Routers.Count != 0)
            {
                CreateNetworkFrame.Navigate(addTrafficParamsPage);
                List<int> routerNumbers = new List<int>();
                foreach(Router ruter in MainPage.network.Routers)
                {
                    if (ruter.Type.Equals("Brzegowy"))
                    {
                        routerNumbers.Add(ruter.Number);
                    }    
                }
                addTrafficParamsPage.SourceSelection.ItemsSource = routerNumbers;

            }
            else
            {
                MessageBox.Show("Dodaj węzły do sieci");
            }
        }

        private void AddQualityParamsClick(object sender, RoutedEventArgs e)
        {
            if (MainPage.network.Routers.Count != 0)
            {
                CreateNetworkFrame.Navigate(addQualityParamsPage);
            }
            else
            {
                MessageBox.Show("Dodaj węzły do sieci");
            }
        }

        private void AddWZClick(object sender, RoutedEventArgs e)
        {
            if (MainPage.network.DPConnections.Count != 0)
            {
                CreateNetworkFrame.Navigate(addWZPage);
                addWZPage.DPList.ItemsSource = MainPage.network.DPConnections;
            }
            else
            {
                MessageBox.Show("Dodaj drogi połączeniowe");
            }

        }
    }
}
