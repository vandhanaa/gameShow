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
using System.Collections.ObjectModel;
using ActPlayResponsibly2012.Teams;

namespace ActPlayResponsibly2012.FlashMessages
{
    /// <summary>
    /// Interaction logic for FlashMessageView.xaml
    /// </summary>
    public partial class FlashMessageView : UserControl
    {
        private ObservableCollection<Team> teams;
        public ObservableCollection<Team> Teams
        {
            get
            {
                return teams;
            }
            set
            {
                teams = value;
                TeamSelector.ItemsSource = value;
            }
        }

        private FlashMessage viewModel;
        public FlashMessage ViewModel
        {
            get
            {
                return viewModel;
            }
            set
            {
                viewModel = value;
                DataContext = value;
            }
        }

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

        private void DisplayWatermark(object sender, SelectionChangedEventArgs e)
        {
            if (TeamSelector.SelectedItem != null)
                ComboBoxWatermark.Visibility = Visibility.Hidden;
            else
                ComboBoxWatermark.Visibility = Visibility.Visible;
        }
    }
}
