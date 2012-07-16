using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.ComponentModel;
using System.Windows.Media.Imaging;
using System.Windows;

namespace ActPlayResponsibly2012.Teams
{
    public class Team : INotifyPropertyChanged
    {
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        private TeamId id;
        public TeamId Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        private BitmapImage avatar;
        public BitmapImage Avatar
        {
            get
            {
                return avatar;
            }
            set
            {
                avatar = value;
                OnPropertyChanged("Avatar");
            }
        }

        private BitmapImage background;
        public BitmapImage Background
        {
            get
            {
                return background;
            }
            set
            {
                background = value;
                OnPropertyChanged("Background");
            }
        }

        private bool isHardQuestion;
        public bool IsHardQuestion
        {
            get
            {
                return isHardQuestion;
            }
            set
            {
                isHardQuestion = value;
                OnPropertyChanged("IsHardQuestion");
            }
        }

        private List<Point> path;
        public List<Point> Path
        {
            get
            {
                return path;
            }
            set
            {
                path = value;
                OnPropertyChanged("Path");
            }
        }

        private int currentPositionIndex;
        public int CurrentPositionIndex
        {
            get
            {
                return currentPositionIndex;
            }
            set
            {
                if (value < 0 || value > path.Count - 1)
                    return;
                currentPositionIndex = value;
                OnPropertyChanged("CurrentPositionIndex");
                CurrentPosition = Path[value];
            }
        }

        private Point currentPosition;
        public Point CurrentPosition
        {
            get
            {
                return currentPosition;
            }
            set
            {
                currentPosition = value;
                OnPropertyChanged("CurrentPosition");
            }
        }

        private bool lifeLine1;
        public bool LifeLine1
        {
            get { return lifeLine1; }
            set { lifeLine1 = value; OnPropertyChanged("LifeLine1"); }
        }

        private bool lifeLine2;
        public bool LifeLine2
        {
            get { return lifeLine2; }
            set { lifeLine2 = value; OnPropertyChanged("LifeLine2"); }
        }

        private bool lifeLine3;
        public bool LifeLine3
        {
            get { return lifeLine3; }
            set { lifeLine3 = value; OnPropertyChanged("LifeLine3"); }
        }

        private bool lifeLine4;
        public bool LifeLine4
        {
            get { return lifeLine4; }
            set { lifeLine4 = value; OnPropertyChanged("LifeLine4"); }
        }

        public Team(string name, TeamId id, BitmapImage avatar, BitmapImage background, List<Point> path)
        {
            Name = name;
            Id = id;
            Avatar = avatar;
            Background = background;
            Path = path;
            CurrentPositionIndex = 0;
            IsHardQuestion = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
