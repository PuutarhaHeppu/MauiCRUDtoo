using MauiCRUDtoo.Views;

namespace MauiCRUDtoo
{
    public partial class MainPage : ContentPage
    {
        private readonly LocalDbService _dbService;
        private int _editCustomerId;

        public MainPage(LocalDbService dbService)
        {
            InitializeComponent();
            _dbService = dbService;
            Task.Run(async () => listView.ItemsSource = await _dbService.GetCustomers());
        }

        private void saveButton_Clicked(object sender, EventArgs e)
        {
            if 
        }

        private void listView_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }
    }


}
