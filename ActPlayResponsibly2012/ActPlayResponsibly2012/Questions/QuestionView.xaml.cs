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
using System.Timers;
using System.Windows.Threading;
using System.Windows.Media.Animation;

namespace ActPlayResponsibly2012.Questions
{
    /// <summary>
    /// Interaction logic for QuestionView.xaml
    /// </summary>
    public partial class QuestionView : UserControl
    {
        Brush defaultAnswerButtonBrush;
        DispatcherTimer countDown;
        TimeSpan maxCountDown;
        TimeSpan remainingCountDown;
        Storyboard questionEnterAnimation;
        Storyboard questionLeaveAnimation;
        bool correctAnswerQ = false;
        private Question viewModel;
        public EventHandler<AnswerClickedEventArgs> AnswerClickedEvent;
        public Question ViewModel
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
        
        public QuestionView()
        {
            InitializeComponent();
            defaultAnswerButtonBrush = new Button().Background;
            maxCountDown = TimeSpan.FromSeconds(60);
            countDown = new DispatcherTimer();
            countDown.Interval = TimeSpan.FromSeconds(1);
            countDown.Tick += ((o, args) =>
                {
                    remainingCountDown = remainingCountDown.Subtract(TimeSpan.FromSeconds(1));
                    Timer.Content = remainingCountDown.TotalSeconds;
                    if (remainingCountDown == TimeSpan.Zero)
                    {
                        countDown.Stop();
                        Timer.Content = "Time's Up";
                    }
                });
            
            DataContextChanged += (
                (o, e) => 
                    {
                        viewModel = e.NewValue as Question;
                        A.Background = defaultAnswerButtonBrush;
                        B.Background = defaultAnswerButtonBrush;
                        C.Background = defaultAnswerButtonBrush;
                        D.Background = defaultAnswerButtonBrush;
                    });
            questionEnterAnimation = (Storyboard)Resources["QuestionEnterAnimation"];
            questionLeaveAnimation = (Storyboard)Resources["QuestionLeaveAnimation"];
        }
        public bool getCorrectAnswer(object sender, RoutedEventArgs e)
        {
            return correctAnswerQ;
        }
        private void AnswerClicked(object sender, RoutedEventArgs e)
        {
            countDown.Stop();
            if ((sender as Button).Name == ViewModel.CorrectAnswer)
            {
                (sender as Button).Background = new SolidColorBrush(Colors.Green);
                correctAnswerQ = true;
            }
            else
            {
                (sender as Button).Background = new SolidColorBrush(Colors.Red);
                correctAnswerQ = false;
            }
            var temp = AnswerClickedEvent;
            var temp2 = new AnswerClickedEventArgs { correctAnswer = correctAnswerQ  };
            temp(this, temp2);
        }

        private void CountDownStart(object sender, RoutedEventArgs e)
        {
            CountDownStart();
        }

        public void ShowQuestion()
        {
            Timer.Content = maxCountDown.TotalSeconds;
            Visibility = System.Windows.Visibility.Visible;
            questionEnterAnimation.Begin();
            countDown.Stop();
            CountDownStart();
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            countDown.Stop();
            questionLeaveAnimation.Completed -= Close;
            questionLeaveAnimation.Completed += Close;
            questionLeaveAnimation.Begin();
        }

        private void Close(object sender, EventArgs e)
        {
            Visibility = Visibility.Collapsed;
        }

        private void ShowAnswer(object sender, RoutedEventArgs e)
        {
            string answer = ViewModel.CorrectAnswer;
            switch(answer)
            {
                case "A": AnswerClicked(A, e); break;
                case "B": AnswerClicked(B, e); break;
                case "C": AnswerClicked(C, e); break;
                case "D": AnswerClicked(D, e); break;
            }
        }

        public void CountDownStart()
        {
            remainingCountDown = maxCountDown;
            Timer.Content = remainingCountDown.TotalSeconds;
            countDown.Start();
        }
    }

    public class QuestionDifficultyToBackgroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null || !(value is QuestionDifficulty))
                return null;
            QuestionDifficulty difficuty = (QuestionDifficulty)Enum.Parse(typeof(QuestionDifficulty), value.ToString());
            if (difficuty == QuestionDifficulty.Normal)
                return new SolidColorBrush(Colors.Black);
            else
                return new SolidColorBrush(Colors.Brown);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class AnswerClickedEventArgs : EventArgs
    {
        public bool correctAnswer { get; set; }
    }
}
