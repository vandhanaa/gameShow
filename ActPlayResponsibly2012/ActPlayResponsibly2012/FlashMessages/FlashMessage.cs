using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace ActPlayResponsibly2012.FlashMessages
{
    public class FlashMessage : INotifyPropertyChanged
    {
        private FlashMessageType type;
        public FlashMessageType Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
                OnPropertyChanged("Type");
            }
        }

        private int id;
        public int Id
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

        private string content;
        public string Content
        {
            get
            {
                return content;
            }
            set
            {
                content = value;
                OnPropertyChanged("Content");
            }
        }

        private bool isTeamListDisplayed;
        public bool IsTeamListDisplayed
        {
            get
            {
                return isTeamListDisplayed;
            }
            set
            {
                isTeamListDisplayed = value;
                OnPropertyChanged("IsTeamListDisplayed");
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
