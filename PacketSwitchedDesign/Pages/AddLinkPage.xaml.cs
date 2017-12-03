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
            
            if (MainPage.network.Routers.Count >= 2 && !string.IsNullOrEmpty(StartNodeNumber.Text)
                && !string.IsNullOrEmpty(EndNodeNumber.Text) && !string.IsNullOrWhiteSpace(StartNodeNumber.Text)
                && !string.IsNullOrWhiteSpace(EndNodeNumber.Text)
                && MainPage.network.Routers.Contains(MainPage.network.Routers.Single(x => x.Number == int.Parse(StartNodeNumber.Text)))
                && MainPage.network.Routers.Contains(MainPage.network.Routers.Single(x => x.Number == int.Parse(EndNodeNumber.Text))))
            {
                    var startNode = MainPage.network.Routers.Single(x => x.Number == int.Parse(StartNodeNumber.Text));
                    var endNode = MainPage.network.Routers.Single(x => x.Number == int.Parse(EndNodeNumber.Text));
                    var link = new Link(startNode.Number, endNode.Number); 
            }else
            //else if (MainPage.network.Routers.Count < 2 
            //        || string.IsNullOrEmpty(StartNodeNumber.Text)
            //        || string.IsNullOrEmpty(EndNodeNumber.Text)
            //        || string.IsNullOrWhiteSpace(StartNodeNumber.Text)
            //        || string.IsNullOrWhiteSpace(EndNodeNumber.Text)
            //        || !MainPage.network.Routers.Contains(MainPage.network.Routers.Single(x => x.Number == int.Parse(StartNodeNumber.Text)))
            //        || !MainPage.network.Routers.Contains(MainPage.network.Routers.Single(x => x.Number == int.Parse(EndNodeNumber.Text))))
            {
                MessageBox.Show("Za mało węzłów w sieci");
            }
            //else if (string.IsNullOrEmpty(StartNodeNumber.Text)
            //        || string.IsNullOrEmpty(EndNodeNumber.Text)
            //        || string.IsNullOrWhiteSpace(StartNodeNumber.Text)
            //        || string.IsNullOrWhiteSpace(EndNodeNumber.Text)
            //        || !MainPage.network.Routers.Contains(MainPage.network.Routers.Single(x => x.Number == int.Parse(StartNodeNumber.Text)))
            //        || !MainPage.network.Routers.Contains(MainPage.network.Routers.Single(x => x.Number == int.Parse(EndNodeNumber.Text))))
            //{
            //    MessageBox.Show("Błąd danych");
            //}

        }
    }
}
