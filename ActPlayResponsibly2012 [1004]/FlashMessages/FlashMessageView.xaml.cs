using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ActPlayResponsibly2012.FlashMessages
{
    /// <summary>
    /// Interaction logic for FlashMessageView.xaml
    /// </summary>
    public partial class FlashMessageView : UserControl
    {
        public FlashMessageView()
        {
            InitializeComponent();
        }

        public void ShowFlashMessage()
        {
            Visibility = System.Windows.Visibility.Visible;
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            Visibility = System.Windows.Visibility.Collapsed;
        }
    }
}
