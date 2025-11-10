namespace ProjectBrightBuy;

public partial class ViewCartPage : ContentPage
{
    public ObservableCollection<CartItem> CartItems { get; set; }
    public double TotalPrice => CartItems.Sum(item => item.ProductPrice * item.Quantity);

    public Command<string> RemoveFromCartCommand { get; }
    public Command ClearCartCommand { get; }
    public Command CheckoutCommand { get; }

    public ViewCartPage()
    {
        InitializeComponent();

        CartItems = new ObservableCollection<CartItem>
            {
                new CartItem { ProductID = "P001", ProductName = "Samsung Galaxy S24", ProductType = "Electronics", ProductPrice = 18999.99, Quantity = 1 },
                new CartItem { ProductID = "P002", ProductName = "Nike Air Max", ProductType = "Clothing", ProductPrice = 1499.00, Quantity = 2 },
            };

        RemoveFromCartCommand = new Command<string>(RemoveItem);
        ClearCartCommand = new Command(ClearCart);
        CheckoutCommand = new Command(ProceedToCheckout);

        BindingContext = this;
    }

    void RemoveItem(string productId)
    {
        var item = CartItems.FirstOrDefault(p => p.ProductID == productId);
        if (item != null)
            CartItems.Remove(item);
    }

    void ClearCart()
    {
        CartItems.Clear();
    }

    async void ProceedToCheckout()
    {
        await DisplayAlert("Checkout", "Proceeding to checkout...", "OK");
        // Navigate to Checkout page logic here
    }
}

public class CartItem
{
    public string ProductID { get; set; }
    public string ProductName { get; set; }
    public string ProductType { get; set; }
    public double ProductPrice { get; set; }
    public int Quantity { get; set; }
}
}