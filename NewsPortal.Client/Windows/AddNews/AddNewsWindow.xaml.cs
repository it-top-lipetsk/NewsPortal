using System;
using System.Net.Sockets;
using System.Windows;
using NewsPortal.Lib;
using NewsPortal.Server.Lib.Models;

namespace NewsPortal.Client.Windows.AddNews
{
    public partial class AddNewsWindow : Window
    {
        private User _user;
        private readonly NetworkStream _stream;
        
        public AddNewsWindow(NetworkStream stream, User user)
        {
            _user = user;
            _stream = stream;
            
            InitializeComponent();
        }

        private async void ButtonAdd_OnClick(object sender, RoutedEventArgs e)
        {
            var request = new Request
            {
                Type = "auth",
                News = new News
                {
                    Title = InputTitle.Text,
                    Content = InputContent.Text,
                    DateOfCreation = DateTime.Now,
                    Author = _user.Id
                }
            };
            
            await Message.SendData(request, _stream);
        }

        private void ButtonCancel_OnClick(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}