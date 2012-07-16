using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Input;

using ActPlayResponsibly2012.Repository;
using ActPlayResponsibly2012.Questions;
using ActPlayResponsibly2012.Teams;
using ActPlayResponsibly2012.Facility;
using System.Timers;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using ActPlayResponsibly2012.FlashMessages;
using System.Collections.ObjectModel;
using System.Threading;

using Timer = System.Timers.Timer;
using System.Windows.Threading;
using System.Diagnostics;

namespace ActPlayResponsibly2012
{
    public class APRViewModel : INotifyPropertyChanged
    {
        private int currentTeamIndex;
        public int CurrentTeamIndex
        {
            get
            {
                return currentTeamIndex;
            }
            set
            {
                currentTeamIndex = value;
                OnPropertyChanged("CurrentTeamIndex");
                CurrentTeam = teams[currentTeamIndex % 4];
            }
        }

        private Team currentTeam;
        public Team CurrentTeam
        {
            get
            {
                return currentTeam;
            }
            set
            {
                currentTeam = value;
                OnPropertyChanged("CurrentTeam");
            }
        }

        private Team redTeam;
        public Team RedTeam
        {
            get
            {
                return redTeam;
            }
            set
            {
                redTeam = value;
                OnPropertyChanged("RedTeam");
            }
        }

        private Team yellowTeam;
        public Team YellowTeam
        {
            get
            {
                return yellowTeam;
            }
            set
            {
                yellowTeam = value;
                OnPropertyChanged("YellowTeam");
            }
        }

        private Team greenTeam;
        public Team GreenTeam
        {
            get
            {
                return greenTeam;
            }
            set
            {
                greenTeam = value;
                OnPropertyChanged("GreenTeam");
            }
        }

        private Team blueTeam;
        public Team BlueTeam
        {
            get
            {
                return blueTeam;
            }
            set
            {
                blueTeam = value;
                OnPropertyChanged("BlueTeam");
            }
        }

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
                OnPropertyChanged("Teams");
            }
        }

        private Question currentQuestion;
        public Question CurrentQuestion
        {
            get
            {
                return currentQuestion;
            }
            set
            {
                currentQuestion = value;
                OnPropertyChanged("CurrentQuestion");
            }
        }

        private FlashMessage currentFlashMessage;
        public FlashMessage CurrentFlashMessage
        {
            get
            {
                return currentFlashMessage;
            }
            set
            {
                currentFlashMessage = value;
                OnPropertyChanged("CurrentFlashMessage");
            }
        }

        private int diceNumber = 1;
        public int DiceNumber
        {
            get
            {
                return diceNumber;
            }
            set
            {
                diceNumber = value;
                OnPropertyChanged("DiceNumber");
                OnPropertyChanged("DiceImage");
            }
        }
        public bool IsDiceThrowing { get; private set; }

        public Image DiceImage
        {
            get
            {
                return diceImages[DiceNumber - 1];
            }
        }

        public ICommand NextTurnCommand
        {
            get
            {
                return new RelayCommand(NextTurn);
            }
        }

        public ICommand PromoteCommand
        {
            get
            {
                return new RelayCommand(Promote);
            }
        }

        public ICommand DemoteCommand
        {
            get
            {
                return new RelayCommand(Demote);
            }
        }

        public ICommand ThrowDiceCommand
        {
            get
            {
                return new RelayCommand(ThrowDice);
            }
        }

        public ICommand CurrentTeamMoveForwardCommand
        {
            get
            {
                return new RelayCommand(CurrentTeamMoveForward);
            }
        }

        public ICommand CurrentTeamMoveBackwardCommand
        {
            get
            {
                return new RelayCommand(CurrentTeamMoveBackward);
            }
        }

        public ICommand AllTeamsMoveForwardCommand
        {
            get
            {
                return new RelayCommand(AllTeamsMoveForward);
            }
        }

        public ICommand AllTeamsMoveBackwardCommand
        {
            get
            {
                return new RelayCommand(AllTeamsMoveBackward);
            }
        }

        public ICommand TeamMoveForwardCommand
        {
            get
            {
                return new RelayCommand<Team>(TeamMoveForward);
            }
        }

        public ICommand TeamMoveBackwardCommand
        {
            get
            {
                return new RelayCommand<Team>(TeamMoveBackward);
            }
        }

        Repository.Repository repository;
        QuestionBank questionBank;
        FlashMessageBank flashMessageBank;
        Random random;
        Timer diceTimer;
        Image[] diceImages;

        public event PropertyChangedEventHandler PropertyChanged;

        public APRViewModel()
        {
            try
            {
                repository = Repository.Repository.Current;
                questionBank = repository.LoadQuestionBank();
                flashMessageBank = repository.LoadFlashMessageBank();

                Teams = new ObservableCollection<Team>(repository.LoadTeams());
                RedTeam = teams.Where(o => o.Id == TeamId.Red).ElementAt(0);
                GreenTeam = teams.Where(o => o.Id == TeamId.Green).ElementAt(0);
                YellowTeam = teams.Where(o => o.Id == TeamId.Yellow).ElementAt(0);
                BlueTeam = teams.Where(o => o.Id == TeamId.Blue).ElementAt(0);
                CurrentTeamIndex = 0;

                diceImages = new Image[6];
                for (int i = 0; i < diceImages.Length; i++)
                {
                    diceImages[i] = new Image();
                    diceImages[i].BeginInit();
                    diceImages[i].Source = new BitmapImage(new Uri("Images/DiceNumbers/" + (i + 1) + ".jpg", UriKind.Relative));
                    diceImages[i].EndInit();
                }
            }
            catch { }

            random = new Random();
        }

        void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        public void LoadQuestion(QuestionCategory category)
        {
            if (CurrentTeam.IsHardQuestion)
                LoadQuestion(category, QuestionDifficulty.Hard);
            else
                LoadQuestion(category, QuestionDifficulty.Normal);
            //CurrentQuestion = questionBank.GetQuestion(category, QuestionDifficulty.Normal);
        }
        
        public void LoadQuestion(QuestionCategory category, QuestionDifficulty difficulty)
        {
            CurrentQuestion = questionBank.GetQuestion(category, difficulty);
        }

        public void LoadFlashMessage(FlashMessageType type)
        {
            CurrentFlashMessage = flashMessageBank.GetFlashMessage(type);
        }

        public void LoadFlashMessage(FlashMessageType type, int id)
        {
            CurrentFlashMessage = flashMessageBank.GetFlashMessage(type, id);
            if (type == FlashMessageType.Lifeline)
            {
                switch (id)
                {
                    case 1:
                        CurrentTeam.LifeLine1 = true;
                        break;
                    case 2:
                        CurrentTeam.LifeLine2 = true;
                        break;
                    case 3:
                        CurrentTeam.LifeLine3 = true;
                        break;
                    case 4:
                        CurrentTeam.LifeLine4 = true;
                        break;
                }
            }
        }

        public void NextTurn()
        {
            if (CurrentTeamIndex + 1 >= 4)
                CurrentTeamIndex = 0;
            else
                CurrentTeamIndex++;
        }

        public void Promote()
        {
            CurrentTeam.IsHardQuestion = true;
        }

        public void Demote()
        {
            CurrentTeam.IsHardQuestion = false;
        }

        public void ThrowDice()
        {
            if (IsDiceThrowing)
            {
                diceTimer.Stop();
                IsDiceThrowing = false;
                BackgroundWorker worker = new BackgroundWorker();
                worker.DoWork += ((o, e) =>
                    {
                        for (int i = 0; i < diceNumber; i++)
                        {
                            Thread.Sleep(300);
                            CurrentTeamMoveForward();
                        }
                    });
                worker.RunWorkerAsync();
            }
            else
            {
                diceTimer = new Timer(50);
                diceTimer.AutoReset = true;
                diceTimer.Elapsed += ((o, e) => DiceNumber = random.Next(1, 7));
                diceTimer.Start();
                IsDiceThrowing = true;
            }
        }

        public void MoveTeamForwardAfterAnswer()
        {
            if (CurrentTeam.IsHardQuestion)
            {
                CurrentTeam.CurrentPositionIndex += 2;
            }
            else
            {
                CurrentTeam.CurrentPositionIndex++;
            }
                
        }
        public void MoveTeamBackwardAfterAnswer()
        {
            if (CurrentTeam.IsHardQuestion)
            {
                CurrentTeam.CurrentPositionIndex -= DiceNumber;
            }
            else
            {
                CurrentTeam.CurrentPositionIndex--;
            }
                
        }
        public void CurrentTeamMoveForward()
        {
            CurrentTeam.CurrentPositionIndex++;
        }

        public void CurrentTeamMoveBackward()
        {
            CurrentTeam.CurrentPositionIndex--;
        }

        public void AllTeamsMoveForward()
        {
            foreach (var i in Teams)
                i.CurrentPositionIndex++;
        }

        public void AllTeamsMoveBackward()
        {
            foreach (var i in Teams)
                i.CurrentPositionIndex--;
        }

        public void TeamMoveForward(Team team)
        {
            if (team == null)
                return;

            team.CurrentPositionIndex++;
        }

        public void TeamMoveBackward(Team team)
        {
            if (team == null)
                return;

            team.CurrentPositionIndex--;
        }
    }
}
