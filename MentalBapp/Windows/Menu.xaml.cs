namespace MentalBapp.Windows;

public partial class Menu : ContentPage
{
	public Menu()
	{
		InitializeComponent();
	}
    private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem is string item)
        {
            ((FlyoutPage)Application.Current.MainPage).Detail = item switch
            {
                //"Home" => new NavigationPage(new HomePage()),
                //"Profile" => new NavigationPage(new ProfilePage()),
                //"Settings" => new NavigationPage(new SettingsPage()),
                //"Help" => new NavigationPage(new HelpPage()),
                //_ => ((FlyoutPage)Application.Current.MainPage).Detail
            };
            ((FlyoutPage)Application.Current.MainPage).IsPresented = false;
        }
    }
}