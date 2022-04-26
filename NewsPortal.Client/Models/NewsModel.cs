using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using NewsPortal.Server.Lib.Models;

namespace NewsPortal.Client.Models
{
    public class NewsModel : INotifyPropertyChanged
    {
        private int _id;
        public int Id
        {
            get => _id;
            set
            {
                if (value == _id) return;
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        private string _title;
        public string Title
        {
            get => _title;
            set
            {
                if (value == _title) return;
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        private string _content;
        public string Content
        {
            get => _content;
            set
            {
                if (value == _content) return;
                _content = value;
                OnPropertyChanged(nameof(Content));
            }
        }

        private DateTime _date;
        public DateTime DateOfCreation
        {
            get => _date;
            set
            {
                if (value == _date) return;
                _date = value;
                OnPropertyChanged(nameof(DateOfCreation));
            }
        }

        private string _author;
        public string Author
        {
            get => _author;
            set
            {
                if (value == _author) return;
                _author = value;
                OnPropertyChanged(nameof(Author));
            }
        }

        public NewsModel() {}
        public NewsModel(News news, User user)
        {
            Id = news.Id;
            Title = news.Title;
            Content = news.Content;
            DateOfCreation = news.DateOfCreation;
            Author = $"{user.LastName} {user.FirstName} {user.MiddleName}";
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}