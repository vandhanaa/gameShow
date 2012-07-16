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

using ActPlayResponsibly2012.Repository;
using ActPlayResponsibly2012.Questions;
using ActPlayResponsibly2012.Teams;
using System.Windows.Media.Animation;
using ActPlayResponsibly2012.FlashMessages;

namespace ActPlayResponsibly2012
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private APRViewModel viewModel;
        public APRViewModel ViewModel
        {
            get
            {
                return viewModel;
            }
            set
            {
                viewModel = value;
                DataContext = viewModel;
            }
        }

        public FrameworkElement CurrentTeamAvatar { get; set; }

        Point mousePositionRelativeToElement;
        Point mouseCurrentPosition;

        public MainWindow()
        {
            InitializeComponent();
            ViewModel = new APRViewModel();
        }

        #region Window Methods
        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            // Repository.Repository.Current.InitializeTeamDataXml();
        }

        private void MaximizeWindow(object sender, RoutedEventArgs e)
        {
            if (WindowState != System.Windows.WindowState.Maximized)
                WindowState = System.Windows.WindowState.Maximized;
            else
                WindowState = System.Windows.WindowState.Normal;
        }

        private void WindowDragMove(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        #endregion

        #region Commands
        private void CanCloseExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CloseExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Close();
        }
        #endregion

        #region Team Avatar
        private void TeamAvatarMouseDown(object sender, MouseButtonEventArgs e)
        {
            CurrentTeamAvatar = sender as FrameworkElement;
            mousePositionRelativeToElement = e.GetPosition(CurrentTeamAvatar);
        }

        private void TeamAvatarMouseMove(object sender, MouseEventArgs e)
        {
            mouseCurrentPosition = e.GetPosition(DragableContent);

            if (e.LeftButton == MouseButtonState.Pressed && CurrentTeamAvatar != null && mousePositionRelativeToElement != null)
            {
                CurrentTeamAvatar.Margin = new Thickness(mouseCurrentPosition.X - mousePositionRelativeToElement.X, mouseCurrentPosition.Y - mousePositionRelativeToElement.Y, 0, 0);
            }
        }

        private void TeamAvatarMouseUp(object sender, MouseButtonEventArgs e)
        {
            CurrentTeamAvatar = null;
        }
        #endregion

        #region Dice
        private void DiceThrowing(object sender, RoutedEventArgs e)
        {
            if (!ViewModel.IsDiceThrowing)
                (Resources["DiceStoryboard"] as Storyboard).Begin();
            else
                (Resources["DiceStoryboard"] as Storyboard).Stop();
        }
        #endregion

        #region Questions
        private void ShowQuestion(object sender, RoutedEventArgs e)
        {
            if ((sender as Button).Tag.ToString() == "Red")
                ViewModel.LoadQuestion(QuestionCategory.Red);
            else if ((sender as Button).Tag.ToString() == "Blue")
                ViewModel.LoadQuestion(QuestionCategory.Blue);
            else if ((sender as Button).Tag.ToString() == "Green")
                ViewModel.LoadQuestion(QuestionCategory.Green);
            else if ((sender as Button).Tag.ToString() == "Yellow")
                ViewModel.LoadQuestion(QuestionCategory.Yellow);
            else if ((sender as Button).Tag.ToString() == "Gray")
                ViewModel.LoadQuestion(QuestionCategory.Gray);
            QuestionView.ShowQuestion();
        }
        #endregion

        #region Flash Messages
        private void ShowFlashMesages(object sender, RoutedEventArgs e)
        {
            // TODO: hardcode
            string tag = (sender as Button).Tag.ToString();
            if (tag.StartsWith("Chance"))
                ViewModel.LoadFlashMessage(FlashMessageType.ChanceCard);
            else if (tag.StartsWith("FlashMessage"))
                ViewModel.LoadFlashMessage(FlashMessageType.SpecialFlashMessage, int.Parse(tag.Split(' ')[1]));
            else if (tag.StartsWith("Lifeline"))
                ViewModel.LoadFlashMessage(FlashMessageType.Lifeline, int.Parse(tag.Split(' ')[1]));
            FlashMessageView.ShowFlashMessage();
        }
        #endregion
    }

    public class BooleanNOTToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return Visibility.Collapsed;

            if ((bool)value)
                return Visibility.Collapsed;
            else
                return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class BooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return Visibility.Collapsed;

            if (!(bool)value)
                return Visibility.Collapsed;
            else
                return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class TeamAvatarBorderBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return null;

            switch((TeamId)value)
            {
                case TeamId.Red:
                    return new SolidColorBrush(Colors.DarkRed);
                case TeamId.Green:
                    return new SolidColorBrush(Colors.DarkGreen);
                case TeamId.Blue:
                    return new SolidColorBrush(Colors.DarkBlue);
                case TeamId.Yellow:
                    return new SolidColorBrush(Colors.Gold);
                default:
                    return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
