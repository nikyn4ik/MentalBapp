using Microsoft.Maui.Controls;
using MentalBapp.AddEdit;

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
            string email = EmailEntry.Text;
            string password = PasswordEntry.Text;

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                await DisplayAlert("Error", "Please enter email and password", "OK");
                return;
            }

            bool isAuthenticated = await AuthenticateUserAsync(email, password);

            if (isAuthenticated)
            {
                await Navigation.PushAsync(new Menu());
            }
            else
            {
                await DisplayAlert("Error", "Invalid email or password", "OK");
            }
        }
        private async void RegisterB(object sender, EventArgs e)
        {
            await Navigation.PopAsync();

            await Navigation.PushAsync(new Registration());
        }

        private async Task<bool> AuthenticateUserAsync(string email, string password)
        {
            return !string.IsNullOrWhiteSpace(email) && !string.IsNullOrWhiteSpace(password);
        }
    }
}
