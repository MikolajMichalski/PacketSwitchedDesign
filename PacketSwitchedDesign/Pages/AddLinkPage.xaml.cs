﻿using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Interaction logic for AddLinkPage.xaml
    /// </summary>
    public partial class AddLinkPage : Page
    {
        public AddLinkPage()
        {
            InitializeComponent();
        }

        private void AddLinkClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MainPage.network.Routers.Count >= 2 && !string.IsNullOrEmpty(StartNodeNumber.Text)
                    && !string.IsNullOrEmpty(EndNodeNumber.Text) && !string.IsNullOrWhiteSpace(StartNodeNumber.Text)
                    && !string.IsNullOrWhiteSpace(EndNodeNumber.Text)
                    && MainPage.network.Routers.Contains(MainPage.network.Routers.Single(x => x.Number == int.Parse(StartNodeNumber.Text)))
                    && MainPage.network.Routers.Contains(MainPage.network.Routers.Single(x => x.Number == int.Parse(EndNodeNumber.Text)))
                    && !StartNodeNumber.Text.Equals(EndNodeNumber.Text))
                {
                    //if (MainPage.network.Links.Count(x => x.SourceRouterNumber == int.Parse(EndNodeNumber.Text)) == 0 && MainPage.network.Links.Count(x => x.DestRouterNumber == int.Parse(StartNodeNumber.Text)) == 0)
                    // {

                    var startNode = MainPage.network.Routers.Single(x => x.Number == int.Parse(StartNodeNumber.Text));
                    var endNode = MainPage.network.Routers.Single(x => x.Number == int.Parse(EndNodeNumber.Text));
                    if (!(startNode.Type.Equals("Brzegowy") && endNode.Type.Equals("Brzegowy")))
                    {
                        if (float.Parse(LinkLength.Text.Trim(), CultureInfo.InvariantCulture.NumberFormat) > 0)
                        {
                            var link1 = new Link(startNode, endNode, float.Parse(LinkLength.Text.Trim(), CultureInfo.InvariantCulture.NumberFormat));
                            var link2 = new Link(endNode,startNode, float.Parse(LinkLength.Text.Trim() , CultureInfo.InvariantCulture.NumberFormat));
                            MainPage.network.Links.Add(link1);
                            MainPage.network.Links.Add(link2);
                            MessageBox.Show("dodano łącze");
                        }
                        else
                        {
                            MessageBox.Show("Długosć łącza musi być większa od zera");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Nie można stworzyć bezpośredniego łącza między dwoma węzłami brzegowymi");
                    }
                    // }
                    // else
                    // {
                    //   MessageBox.Show("Takie łącze już istnieje");
                    //  }
                }
                else
                {
                    MessageBox.Show("Błąd danych");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd danych");
            }


        }
    }
}
