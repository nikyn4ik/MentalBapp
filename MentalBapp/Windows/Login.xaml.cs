using MentalBapp.AddEdit;
using DataBase.Models;
using DataBase;

namespace MentalBapp.Windows
{
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }

        private async void LoginB(object sender, EventArgs e)
        {
            string name = Name.Text;
            string password = PasswordEntry.Text;

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(password))
            {
                await DisplayAlert("Error", "Please enter login and password", "OK");
                return;
            }

            bool isAuthenticated = await AuthenticateUserAsync(name, password);

            if (isAuthenticated)
            {
                await Navigation.PushAsync(new Menu());
            }
            else
            {
                await DisplayAlert("Error", "Invalid login or password", "OK");
            }
        }

        private async void RegisterB(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
            await Navigation.PushAsync(new Registration());
        }

        private async Task<bool> AuthenticateUserAsync(string name, string password)
        {
            using (var db = new ApplicationContext())
            {
                var user = db.Users.FirstOrDefault(u => u.Name == name);
                if (user == null)
                {
                    return false;
                }

                return User.VerifyPass(password, user.Salt, user.PasswordHash);
            }
        }
    }
}
