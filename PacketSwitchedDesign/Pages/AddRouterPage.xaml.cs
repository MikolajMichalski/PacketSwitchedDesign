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
    /// Interaction logic for AddRouterPage.xaml
    /// </summary>
    public partial class AddRouterPage : Page
    {

        public AddRouterPage()
        {
            InitializeComponent();

        }

        private void CreateRouter(object sender, RoutedEventArgs e)
        {

            if (RouterTypeSelection.SelectedItem != null && !String.IsNullOrEmpty(NodeNumber.Text))
            {
                if (RouterTypeSelection.Text.Equals("Brzegowy"))
                {
                    if (MainPage.network.Routers.Count(x => x.Number == int.Parse(NodeNumber.Text) && x.Type == "Brzegowy") == 0)
                    {
                        if (MainPage.network.Routers.Count(x => x.Number == int.Parse(NodeNumber.Text)) == 0)
                        {
                            var router = new Router(int.Parse(NodeNumber.Text), RouterTypeSelection.Text);
                            MainPage.network.Routers.Add(router);
                           // MessageBox.Show("Dodano rute brzegowy");
                        }
                        else
                        {
                            MessageBox.Show("Ruter o tym numerze już istnieje");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Taki ruter już istnieje");
                    }
                }
                else if (RouterTypeSelection.Text.Equals("Rdzeniowy"))
                {
                    if (MainPage.network.Routers.Count(x => x.Number == int.Parse(NodeNumber.Text) && x.Type == "Rdzeniowy") == 0)
                   { 
                        if (MainPage.network.Routers.Count(x => x.Number == int.Parse(NodeNumber.Text)) == 0)
                        {
                            var router = new Router(int.Parse(NodeNumber.Text), RouterTypeSelection.Text);
                            MainPage.network.Routers.Add(router);
                          //  MessageBox.Show("Dodano ruter rdzeniowy");
                        }
                        else
                        {
                            MessageBox.Show("Ruter o tym numerze już istnieje");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Taki ruter już istnieje");
                    }
                }
            }
            else
            {
                MessageBox.Show("Podaj wszystkie wymagane dane");
            }
        
            MainPage.createNetworkPage.NumberOfNodes.DataContext = MainPage.network.Routers.Count.ToString();
            MainPage.createNetworkPage.NumberOfEdgeNodes.DataContext = MainPage.network.Routers.Count(x => x.Type == "Brzegowy");
            MainPage.createNetworkPage.NumberOfCoreNodes.DataContext = MainPage.network.Routers.Count(x => x.Type == "Rdzeniowy");
        }
    }
}
