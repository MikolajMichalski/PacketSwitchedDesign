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
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
       
       public static Network network;
       public static CreateNetworkPage createNetworkPage = new CreateNetworkPage();
        public MainPage()
        {
            InitializeComponent();
        }
        private void InputDataButton(object sender, RoutedEventArgs e)
        {
            WorkSpaceFrame.Navigate(createNetworkPage);
            network = new Network();
        }

        private void Calculate(object sender, RoutedEventArgs e)
        {
            foreach (var dp in network.DPConnections)
            {
                dp.C_EF = dp.WZ_CBR * network.PacketLengthCBR * dp.SourceNode.Lambda_EF;
                dp.C_AF = dp.WZ_VBR1 * network.PacketLengthVBR1 * dp.SourceNode.Lambda_AF;
                dp.C_BE = dp.WZ_VBR2 * network.PacketLengthVBR2 * dp.SourceNode.Lambda_BE;
            }
            foreach (var link in network.Links)
            {
                var list = network.DPConnections.Where(x => x.Route.Contains(link)).ToList();
                for (int i = 0; i < list.Count; i++)
                {
                    link.ThroughputEF = link.ThroughputEF + list.ElementAt(i).C_EF;
                    link.ThroughputAF = link.ThroughputAF + list.ElementAt(i).C_AF;
                    link.ThroughputBE = link.ThroughputBE + list.ElementAt(i).C_BE;
                }
            }
        }

    }
}
