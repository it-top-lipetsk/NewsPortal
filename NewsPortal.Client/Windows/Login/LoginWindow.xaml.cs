using System.Net.Sockets;
using System.Text.Json;
using System.Windows;
using NewsPortal.Client.Windows.AddNews;
using NewsPortal.Lib;
using NewsPortal.Server.Lib.Models;

namespace NewsPortal.Client.Windows.Login
{
    public partial class LoginWindow : Window
    {
        private readonly NetworkStream _stream;
        public LoginWindow(NetworkStream stream)
        {
            _stream = stream;
            
            InitializeComponent();
        }

        private async void ButtonLogin_OnClick(object sender, RoutedEventArgs e)
        {
            var request = new Request
            {
                Type = "auth",
                Login = InputLogin.Text,
                Password = InputPassword.Password
            };
            await Message.SendData(request, _stream);
            
            var responseRaw = await Message.GetRequest(_stream);
            var user = JsonSerializer.Deserialize<User>(responseRaw);

            if (user?.Id == -1)
            {
                MessageBox.Show("Вы ввели неверные данные");
            }
            else
            {
                MessageBox.Show("Вы успешно авторизовались");
                new AddNewsWindow(_stream, user).Show();
            }
        }

        private void ButtonCancel_OnClick(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}