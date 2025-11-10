namespace ProjectBrightBuy;

public partial class AddProduct : ContentPage
{
    private async void OnAddProductClicked(object sender, EventArgs e)
    {
        // Get user input
        string id = ProductIdEntry.Text;
        string name = ProductNameEntry.Text;
        string type = ProductTypePicker.SelectedItem?.ToString();
        string priceText = ProductPriceEntry.Text;
        string description = ProductDescriptionEditor.Text;

        // Validation
        if (string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(name) ||
            string.IsNullOrWhiteSpace(type) || string.IsNullOrWhiteSpace(priceText))
        {
            await DisplayAlert("Error", "Please fill in all fields.", "OK");
            return;
        }

        if (!decimal.TryParse(priceText, out decimal price))
        {
            await DisplayAlert("Error", "Price must be a valid number.", "OK");
            return;
        }

        // Insert into SQLite database
        var newProduct = new Product
        {
            ProductId = id,
            Name = name,
            Type = type,
            Price = price,
            Description = description
        };

        await App.Database.SaveProductAsync(newProduct);

        await DisplayAlert("Success", $"{name} has been added!", "OK");

        // Clear inputs
        ProductIdEntry.Text = string.Empty;
        ProductNameEntry.Text = string.Empty;
        ProductTypePicker.SelectedIndex = -1;
        ProductPriceEntry.Text = string.Empty;
        ProductDescriptionEditor.Text = string.Empty;
    }

}