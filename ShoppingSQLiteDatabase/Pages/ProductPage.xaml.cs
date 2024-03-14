using ShoppingSQLiteDatabase.Models;
using ShoppingSQLiteDatabase.Service;

namespace ShoppingSQLiteDatabase.Pages;

public partial class ProductPage : ContentPage
{
    private ShoppingDatabase _database;


    private ProductPage _currentItem;

    public ShoppingItems CurrentItem
    {
        get { return _currentItem; }
        set
        {
            _currentItem = value;

            OnPropertyChanged();

        }
    }

    public ProductPage()
	{
		InitializeComponent();
        _currentItem = new ProductPage();

        BindingContext = this;
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();

        LoadData();
    }
    private void LoadData()
    {
        ShoppingItems shoppingItems = _currentItem.GetItemById(0);
        {

            CurrentItem = shoppingItems;

        }
    }

}