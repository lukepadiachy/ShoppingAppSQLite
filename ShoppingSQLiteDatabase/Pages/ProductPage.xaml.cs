using ShoppingSQLiteDatabase.Models;
using ShoppingSQLiteDatabase.Service;
using System.Collections.ObjectModel;
using System.Transactions;

namespace ShoppingSQLiteDatabase.Pages;

public partial class ProductPage : ContentPage
{
    private ShoppingDatabase _database;
    private CustomerProfile _currentCustomer;
    private ObservableCollection<ShoppingItems> _items { get; set; }

    public ObservableCollection<ShoppingItems> Items
    {
        get { return _items; }
        set
        {
            _items = value;

            OnPropertyChanged();

        }
    }

    public ProductPage()
    {
        InitializeComponent();
        _database = new ShoppingDatabase();
        BindingContext = this;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        LoadData();
    }

    private void LoadData()
    {
       // _currentCustomer = _database.GetCustomerById(1);
        Items = new ObservableCollection<ShoppingItems>(_database.GetAllShoppingItems());
        ShoppingItemsListView.BindingContext = Items;
    }

    private void AddShoppingItem_Clicked(object sender, EventArgs e)
    {
        var button = (Button)sender;
        var shoppingItem = (ShoppingItems)button.CommandParameter;

        _database.AddShoppingItemToCustomer(_currentCustomer.CustomerProfileId, shoppingItem.ItemId);
    }
}
