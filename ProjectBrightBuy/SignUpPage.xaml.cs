namespace ProjectBrightBuy;

public partial class SignUpPage : ContentPage
{
    private async void OnRegisterClicked(object sender, EventArgs e)
    {
        string firstName = FirstNameEntry.Text;
        string lastName = LastNameEntry.Text;
        string email = EmailEntry.Text;
        string password = PasswordEntry.Text;
        string mobile = MobileEntry.Text;
        string address = AddressEntry.Text;

        // Simple validation
        if (string.IsNullOrWhiteSpace(firstName) ||
            string.IsNullOrWhiteSpace(lastName) ||
            string.IsNullOrWhiteSpace(email) ||
            string.IsNullOrWhiteSpace(password) ||
            string.IsNullOrWhiteSpace(mobile) ||
            string.IsNullOrWhiteSpace(address))
        {
            await DisplayAlert("Error", "Please fill in all fields.", "OK");
            return;
        }

        if (!email.Contains("@"))
        {
            await DisplayAlert("Error", "Please enter a valid email address.", "OK");
            return;
        }

        if (password.Length < 6)
        {
            await DisplayAlert("Error", "Password must be at least 6 characters long.", "OK");
            return;
        }

        await DisplayAlert("Success", "Account created successfully!", "OK");

        await Navigation.PushAsync(new SignInPage());
    }

    private async void OnLoginRedirectClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SignInPage());
    }