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
    /// Interaction logic for InputDataPage.xaml
    /// </summary>
    public partial class CreateNetworkPage : Page
    {



        public static AddRouterPage addRouterPage = new AddRouterPage();
        public CreateNetworkPage()
        {
            InitializeComponent();
        }

        private void AddRouterClick(object sender, RoutedEventArgs e)
        {
            AddRouterFrame.Navigate(addRouterPage);
        }

        private void AddLinksClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
