namespace ProjectBrightBuy;

public partial class ViewProductPage : ContentPage
{
    public ObservableCollection<Product> Products { get; set; }

    public ViewProductPage()
    {
        InitializeComponent();
        LoadProducts();
    }

    private async void LoadProducts()
    {
        var products = await App.Database.GetProductsAsync();
        ProductsCollection.ItemsSource = products;
    }

    private void OnSearchTextChanged(object sender, TextChangedEventArgs e)
    {
        var searchText = e.NewTextValue?.ToLower() ?? "";
        var filtered = App.Database.SearchProducts(searchText);
        ProductsCollection.ItemsSource = filtered;
    }

    private async void OnAddToCartClicked(object sender, EventArgs e)
    {
        var button = (Button)sender;
        var product = (Product)button.BindingContext;

        await App.Database.AddToCartAsync(product);
        await DisplayAlert("Success", $"{product.Name} added to cart.", "OK");
    }

    private async void OnRemoveProductClicked(object sender, EventArgs e)
    {
        var button = (Button)sender;
        var product = (Product)button.BindingContext;

        bool confirm = await DisplayAlert("Confirm", $"Remove {product.Name}?", "Yes", "No");
        if (confirm)
        {
            await App.Database.DeleteProductAsync(product);
            await DisplayAlert("Removed", $"{product.Name} has been deleted.", "OK");
            LoadProducts(); // Refresh list
        }
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}