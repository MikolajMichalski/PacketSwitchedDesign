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
    /// Interaction logic for AddQualityParamsPage.xaml
    /// </summary>
    public partial class AddQualityParamsPage : Page
    {
        public AddQualityParamsPage()
        {
            InitializeComponent();
        }

        private void AddQualityParamsClick(object sender, RoutedEventArgs e)
        {
            try
            {
                MainPage.network.IPLR_EF = float.Parse(IPLR_EF.Text.Trim(), CultureInfo.InvariantCulture.NumberFormat);
                MainPage.network.IPLR_AF = float.Parse(IPLR_AF.Text.Trim(), CultureInfo.InvariantCulture.NumberFormat);
                MainPage.network.IPLR_BE = float.Parse(IPLR_BE.Text.Trim(), CultureInfo.InvariantCulture.NumberFormat);
                MainPage.network.A1 = float.Parse(A1.Text.Trim(), CultureInfo.InvariantCulture.NumberFormat);
                MainPage.network.A12 = float.Parse(A12.Text.Trim(), CultureInfo.InvariantCulture.NumberFormat);
                MainPage.network.A123 = float.Parse(A123.Text.Trim(), CultureInfo.InvariantCulture.NumberFormat);
                MessageBox.Show("Dodano prametry");
            }
            catch (Exception exception)
            {
                MessageBox.Show("Błąd danych");
            }
        }
    }
}
