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
    /// Interaction logic for AddETEConnection.xaml
    /// </summary>
    public partial class AddETEConnectionPage : Page
    {
        public AddETEConnectionPage()
        {
            InitializeComponent();          
        }

        ETEConnection eteConnection = new ETEConnection();
        private void AddLinkToDPClick(object sender, RoutedEventArgs e)
        {
            if (eteConnection.Route.Count == 0)
            {
                if(MainPage.network.Links.ElementAt(LinkList.SelectedIndex).SourceRouter.Type.Equals("Brzegowy")
                   || MainPage.network.Links.ElementAt(LinkList.SelectedIndex).DestRouter.Type.Equals("Brzegowy"))
                {
                    eteConnection.Route.Add(MainPage.network.Links.ElementAt(LinkList.SelectedIndex));
                    eteConnection.SourceNode = MainPage.network.Links.ElementAt(LinkList.SelectedIndex).SourceRouter;
                    MessageBox.Show("Dodano łącze do drogi połączeniowej");
                }
                else
                {
                    MessageBox.Show("Droga połączeniowa musi zaczynać się węzłem brzegowym");
                }
            }
            else if (eteConnection.Route.Count < 2)
            {
                eteConnection.Route.Add(MainPage.network.Links.ElementAt(LinkList.SelectedIndex));
                MessageBox.Show("Dodano łącze do drogi połączeniowej");
            }
            else
            {
                if (!(eteConnection.Route.Last().DestRouter.Type.Equals("Brzegowy") || eteConnection.Route.Last().SourceRouter.Type.Equals("Brzegowy")))
                {
                    eteConnection.Route.Add(MainPage.network.Links.ElementAt(LinkList.SelectedIndex));
                    MessageBox.Show("Dodano łącze do drogi połączeniowej");  
                }
                else
                {
                    MessageBox.Show("Nie można dodać więcej połączeń do drogi");
                }
            }
          
        }
        private void AddDPToConnectionsClick(object sender, RoutedEventArgs e)
        {
            if (eteConnection.Route.Last().DestRouter.Type.Equals("Rdzeniowy") && eteConnection.Route.Last().SourceRouter.Type.Equals("Rdzeniowy"))
            {
                MessageBox.Show("Droga połączeniowa musi konczyć się ruterem brzegowym");
            }
            else if(eteConnection.Route.Count >= 2)
            {
                MainPage.network.DPConnections.Add(eteConnection);
                eteConnection.DestNode = MainPage.network.Links.ElementAt(LinkList.SelectedIndex).DestRouter;
                MessageBox.Show("Dodano drogę połączeniową do zbioru dróg");
            }
            else
            {
                MessageBox.Show("Droga połączeniowa musi zawierać conajmniej dwa łącza");
            }
        }


    }
}
