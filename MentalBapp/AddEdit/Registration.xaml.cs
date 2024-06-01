using DataBase.Models;
using DataBase;
using MentalBapp.Windows;
using System.Text.RegularExpressions;

namespace MentalBapp.AddEdit
{
    public partial class Registration : ContentPage
    {
        public Registration()
        {
            InitializeComponent();
        }

        protected override async void OnDisappearing()
        {
            base.OnDisappearing();
            await Navigation.PushAsync(new Login());
        }

        private void RegisterB(object sender, EventArgs e)
        {
            string name = NameEntry.Text;
            string email = EmailEntry.Text;
            string password = PasswordEntry.Text;
            string ageStr = AgeEntry.Text;
            string gender = GenderPicker.SelectedItem?.ToString();
            string location = LocationEntry.Text;

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(ageStr) || string.IsNullOrEmpty(gender) || string.IsNullOrEmpty(location))
            {
                DisplayAlert("Error", "Please fill in all fields", "OK");
                return;
            }

            if (!IsValidEmail(email))
            {
                DisplayAlert("Error", "Please enter a valid email address", "OK");
                return;
            }

            if (!int.TryParse(ageStr, out int age) || age < 14)
            {
                DisplayAlert("Error", "Please enter a valid age (at least 14)", "OK");
                return;
            }

            if (gender == "Custom")
            {
                gender = CustomG.Text;
            }

            using (var db = new ApplicationContext())
            {
                var existingUser = db.Users.FirstOrDefault(u => u.Email == email);
                if (existingUser != null)
                {
                    DisplayAlert("Error", "User with this email already exists", "OK");
                    return;
                }

                (string passwordHash, string salt) = User.HashPassword(password);

                var newUser = new User
                {
                    Name = name,
                    Email = email,
                    PasswordHash = passwordHash,
                    Salt = salt,
                    Age = age,
                    Gender = gender,
                    Location = location
                };

                db.Users.Add(newUser);

                db.SaveChanges();

                DisplayAlert("Success", "Registration successful!", "OK");
            }
        }

        private bool IsValidEmail(string email)
        {
            string emailPattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
            return Regex.IsMatch(email, emailPattern);
        }
        private void GenderPickers(object sender, EventArgs e)
        {
            if (GenderPicker.SelectedItem?.ToString() == "Custom")
            {
                CustomG.IsVisible = true;
            }
            else
            {
                CustomG.IsVisible = false;
            }
        }

    }
}
