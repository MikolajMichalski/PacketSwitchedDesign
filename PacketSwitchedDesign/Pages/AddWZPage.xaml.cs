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
    /// Interaction logic for AddWZPage.xaml
    /// </summary>
    public partial class AddWZPage : Page
    {
        public AddWZPage()
        {
            InitializeComponent();
        }

        private void AddWZClick(object sender, RoutedEventArgs e)
        {
            //var y = int.Parse(DPList.SelectedItem.ToString());
           MainPage.network.DPConnections.ElementAt(DPList.SelectedIndex).WZ_CBR = int.Parse(WZ_CBR.Text);
            MessageBox.Show("Dodano wartości WZ");
        }
    }
}
