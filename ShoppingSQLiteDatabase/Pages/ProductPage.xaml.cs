using ShoppingSQLiteDatabase.Models;
using ShoppingSQLiteDatabase.Service;
using System.Collections.ObjectModel;
using System.Transactions;
using System.Windows.Input;

namespace ShoppingSQLiteDatabase.Pages;

public partial class ProductPage : ContentPage
{
    private ShoppingDatabase _database;
    private ObservableCollection<ShoppingItems> _items; 

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
        LoadData();

        
    }

    

    private void LoadData()
    {
       
        Items = new ObservableCollection<ShoppingItems>(_database.GetAllShoppingItems());
      
    }
  
   

   
}
