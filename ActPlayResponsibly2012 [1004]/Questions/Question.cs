using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace ActPlayResponsibly2012.Questions
{
    public class Question : INotifyPropertyChanged
    {
        private string questionContent;
        public string QuestionContent
        {
            get
            {
                return questionContent;
            }
            set
            {
                questionContent = value;
                OnPropertyChanged("QuestionContent");
            }
        }

        private QuestionDifficulty difficulty;
        public QuestionDifficulty Difficulty
        {
            get
            {
                return difficulty;
            }
            set
            {
                difficulty = value;
                OnPropertyChanged("Difficulty");
            }
        }

        private QuestionCategory category;
        public QuestionCategory Category
        {
            get
            {
                return category;
            }
            set
            {
                category = value;
                OnPropertyChanged("Category");
            }
        }

        private string a;
        public string A
        {
            get
            {
                return a;
            }
            set
            {
                a = value;
                OnPropertyChanged("A");
            }
        }

        private string b;
        public string B
        {
            get
            {
                return b;
            }
            set
            {
                b = value;
                OnPropertyChanged("B");
            }
        }

        private string c;
        public string C
        {
            get
            {
                return c;
            }
            set
            {
                c = value;
                OnPropertyChanged("C");
            }
        }

        private string d;
        public string D
        {
            get
            {
                return d;
            }
            set
            {
                d = value;
                OnPropertyChanged("D");
            }
        }

        private string correctAnswer;
        public string CorrectAnswer
        {
            get
            {
                return correctAnswer;
            }
            set
            {
                correctAnswer = value;
                OnPropertyChanged("CorrectAnswer");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
