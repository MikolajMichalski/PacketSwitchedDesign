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
    /// Interaction logic for AddTrafficParamsPage.xaml
    /// </summary>
    public partial class AddTrafficParamsPage : Page
    {
        public AddTrafficParamsPage()
        {
            InitializeComponent();
        }

        private void AddTrafficParamsClick(object sender, RoutedEventArgs e)
        {
            if (!(string.IsNullOrEmpty(LambdaCBR.Text) || string.IsNullOrWhiteSpace(LambdaCBR.Text)
                  || string.IsNullOrEmpty(LambdaVBR1.Text) || string.IsNullOrWhiteSpace(LambdaVBR1.Text)
                  || string.IsNullOrEmpty(LambdaVBR2.Text) || string.IsNullOrWhiteSpace(LambdaVBR2.Text)
                  || SourceSelection.SelectedItem == null))
            {
                if (float.Parse(LambdaCBR.Text.Trim(), CultureInfo.InvariantCulture.NumberFormat) >= 0 && float.Parse(LambdaVBR1.Text.Trim(), CultureInfo.InvariantCulture.NumberFormat) >= 0 &&
                    float.Parse(LambdaVBR2.Text.Trim(), CultureInfo.InvariantCulture.NumberFormat) >= 0)
                {
                    MainPage.network.Routers.Single(x => x.Number.Equals(int.Parse(SourceSelection.Text))).Lambda_EF =
                        float.Parse(LambdaCBR.Text.Trim(), CultureInfo.InvariantCulture.NumberFormat);
                    MainPage.network.Routers.Single(x => x.Number.Equals(int.Parse(SourceSelection.Text))).Lambda_AF =
                        float.Parse(LambdaVBR1.Text.Trim(), CultureInfo.InvariantCulture.NumberFormat);
                    MainPage.network.Routers.Single(x => x.Number.Equals(int.Parse(SourceSelection.Text))).Lambda_BE =
                        float.Parse(LambdaVBR2.Text.Trim(), CultureInfo.InvariantCulture.NumberFormat);
                    MessageBox.Show("Dodano parametry");
                }
            }            
            else
            {
                MessageBox.Show("Błąd danych");
            }
        }

        private void AddPacketLengthClick(object sender, RoutedEventArgs e)
        {
            if (!(string.IsNullOrEmpty(B_CBR.Text) || string.IsNullOrEmpty(B_VBR1.Text)
                  || string.IsNullOrEmpty(B_VBR2.Text) || string.IsNullOrWhiteSpace(B_CBR.Text)
                  || string.IsNullOrWhiteSpace(B_VBR1.Text) || string.IsNullOrWhiteSpace(B_VBR2.Text)))
            {
                MainPage.network.PacketLengthCBR = int.Parse(B_CBR.Text);
                MainPage.network.PacketLengthVBR1 = int.Parse(B_VBR1.Text);
                MainPage.network.PacketLengthVBR2 = int.Parse(B_VBR2.Text);
                MessageBox.Show("Dodano parametry");
            }
            else
            {
                MessageBox.Show("Błąd danych");
            }
        }
    }
}
