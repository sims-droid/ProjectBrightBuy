using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBrightBuy.Services
{
    readonly SQLiteAsyncConnection _database;

    public Database(string dbPath)
    {
        _database = new SQLiteAsyncConnection(dbPath);
        _database.CreateTableAsync<User>().Wait();
        _database.CreateTableAsync<Product>().Wait();
        _database.CreateTableAsync<CartItem>().Wait();
    }

    // USER METHODS
    public Task<int> RegisterUserAsync(User user)
    {
        return _database.InsertAsync(user);
    }

    public Task<User> GetUserAsync(string email, string password)
    {
        return _database.Table<User>()
                        .Where(u => u.Email == email && u.Password == password)
                        .FirstOrDefaultAsync();
    }

    public Task<User> CheckEmailExistsAsync(string email)
    {
        return _database.Table<User>()
                        .Where(u => u.Email == email)
                        .FirstOrDefaultAsync();
    }

    // PRODUCT METHODS
    public Task<int> AddProductAsync(Product product)
    {
        return _database.InsertAsync(product);
    }

    public Task<List<Product>> GetProductsAsync()
    {
        return _database.Table<Product>().ToListAsync();
    }

    public Task<int> DeleteProductAsync(Product product)
    {
        return _database.DeleteAsync(product);
    }

    // CART METHODS
    public Task<int> AddToCartAsync(CartItem cartItem)
    {
        return _database.InsertAsync(cartItem);
    }

    public Task<List<CartItem>> GetCartItemsAsync()
    {
        return _database.Table<CartItem>().ToListAsync();
    }

    public Task<int> RemoveFromCartAsync(CartItem cartItem)
    {
        return _database.DeleteAsync(cartItem);
    }
}
}   