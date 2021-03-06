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
                var orderedList = list.OrderByDescending(m => m.Route.Count);
                for (int i = 0; i < list.Count; i++)
                {
                    link.ThroughputEF = link.ThroughputEF + list.ElementAt(i).C_EF;
                    link.ThroughputAF = link.ThroughputAF + list.ElementAt(i).C_AF;
                    link.ThroughputBE = link.ThroughputBE + list.ElementAt(i).C_BE;

                    link.B_EF = network.IPLR_EF / orderedList.First().Route.Count;
                    link.B_AF = network.IPLR_AF / orderedList.First().Route.Count;
                    link.B_BE = network.IPLR_BE / orderedList.First().Route.Count;

                }
                link.ThroughputEF = 2 * link.ThroughputEF;
                link.ThroughputAF = 2 * link.ThroughputAF;
                link.ThroughputBE = 2 * link.ThroughputBE;

                var C1 = link.ThroughputEF / network.A1;
                var C2 = (link.ThroughputAF + link.ThroughputEF) / network.A12;
                var C3 = (link.ThroughputEF + link.ThroughputAF + link.ThroughputBE) / network.A123;

                var y = Math.Max(C1, C2);
                var c_otn = Math.Max(y, C3);
                if (c_otn <= 1000000)
                {
                    link.ThroughputOTN = 1000000;

                }
                else if (c_otn > 1000000 && c_otn <= 10000000)
                {
                    link.ThroughputOTN = 10000000;
                }
                else if (c_otn > 10000000 && c_otn <= 100000000)
                {
                    link.ThroughputOTN = 100000000;
                }
                else
                {
                    MessageBox.Show(c_otn.ToString());
                }

                link.A_EF = link.ThroughputEF / link.ThroughputOTN;
                link.A_AF = link.ThroughputAF / (link.ThroughputOTN - link.ThroughputEF);
                link.A_BE = link.ThroughputBE / (link.ThroughputOTN - link.ThroughputEF - link.ThroughputAF);


                link.B_EF1 = ((1 - (double)link.A_EF) / (1 - Math.Pow((double)link.A_EF, (double)link.SourceRouter.EfQueueLength + 2))) *
                      ((float)Math.Pow(link.A_EF, link.SourceRouter.EfQueueLength + 1.0));

                while (link.B_EF1 > link.B_EF)
                {
                    link.B_EF1 = ((1 - (double)link.A_EF) / (1 - Math.Pow((double)link.A_EF, (double)link.SourceRouter.EfQueueLength + 2))) *
                          (Math.Pow((double)link.A_EF, (double)link.SourceRouter.EfQueueLength + 1));
                    if (link.B_EF1 > link.B_EF)
                    {
                        link.SourceRouter.EfQueueLength++;
                    }
                }

                link.B_AF1 = ((1 - (double)link.A_AF) / (1 - Math.Pow((double)link.A_AF, (double)link.SourceRouter.AfQueueLength + 2))) *
                          (Math.Pow((double)link.A_AF, (double)link.SourceRouter.AfQueueLength + 1));
                while (link.B_AF1 > link.B_AF)
                {
                    link.B_AF1 = ((1 - (double)link.A_AF) / (1 - Math.Pow((double)link.A_AF, (double)link.SourceRouter.AfQueueLength + 2))) *
                              (Math.Pow((double)link.A_AF, (double)link.SourceRouter.AfQueueLength + 1));
                    if (link.B_AF1 > link.B_AF)
                    {
                        link.SourceRouter.AfQueueLength++;
                    }

                }

                link.B_BE1 = ((1 - (double)link.A_BE) / (1 - Math.Pow((double)link.A_BE, (double)link.SourceRouter.BeQueueLength + 2))) *
                          (Math.Pow((double)link.A_BE, (double)link.SourceRouter.BeQueueLength + 1));
                while (link.B_BE1 > link.B_BE)
                {
                    link.B_BE1 = ((1 - (double)link.A_BE) / (1 - Math.Pow((double)link.A_BE, (double)link.SourceRouter.BeQueueLength + 2))) *
                          (Math.Pow((double)link.A_BE, (double)link.SourceRouter.BeQueueLength + 1));
                    if (link.B_BE1 > link.B_BE)
                    {
                        link.SourceRouter.BeQueueLength++;
                    }
                }
            }

            createNetworkPage.CreateNetworkFrame.Navigate(CreateNetworkPage.resultsPage);
            CreateNetworkPage.resultsPage.QueueLengthResults.ItemsSource = network.Routers;
            var listOfLinks = new List<Link>();
            for (int i = 0; i < network.Links.Count; i += 2)
            {
                listOfLinks.Add(network.Links.ElementAt(i));
            }
            CreateNetworkPage.resultsPage.ThroughputResults.ItemsSource = listOfLinks;
        }

    }
}
