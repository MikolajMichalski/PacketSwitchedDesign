﻿using System;
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
            CreateNetworkFrame.Navigate(addLinkPage);
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
    }
}
