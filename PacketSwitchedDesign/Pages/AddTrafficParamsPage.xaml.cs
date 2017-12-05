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
                || string.IsNullOrEmpty(LambdaVBR2.Text) || string.IsNullOrWhiteSpace(LambdaVBR2.Text)))
            {
                
            }
        }
    }
}
