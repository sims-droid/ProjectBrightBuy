namespace ProjectBrightBuy;

public partial class SignInPage : ContentPage
{
    private async void OnSignInClicked(object sender, EventArgs e)
    {
        string email = EmailEntry.Text;
        string password = PasswordEntry.Text;

        if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
        {
            await DisplayAlert("Error", "Please enter both email and password.", "OK");
            return;
        }

        // SQL Query Example
        var user = await App.Database.GetUserAsync(email, password);

        if (user != null)
        {
            await DisplayAlert("Welcome", $"Hello {user.FirstName}!", "OK");
            await Navigation.PushAsync(new MainPage());
        }
        else
        {
            await DisplayAlert("Error", "Invalid email or password.", "Try Again");
        }
    }

}