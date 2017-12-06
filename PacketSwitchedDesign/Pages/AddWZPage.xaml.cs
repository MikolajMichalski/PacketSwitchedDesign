using System;
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
            MainPage.network.DPConnections.ElementAt(DPList.SelectedIndex).WZ_CBR = float.Parse(WZ_CBR.Text.Trim(), CultureInfo.InvariantCulture.NumberFormat);
            MainPage.network.DPConnections.ElementAt(DPList.SelectedIndex).WZ_VBR1 = float.Parse(WZ_CBR.Text.Trim(), CultureInfo.InvariantCulture.NumberFormat);
            MainPage.network.DPConnections.ElementAt(DPList.SelectedIndex).WZ_VBR2 = float.Parse(WZ_CBR.Text.Trim(), CultureInfo.InvariantCulture.NumberFormat);
           MessageBox.Show("Dodano wartości WZ");
        }
    }
}
