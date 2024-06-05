namespace MauiCRUDtoo.Views;

public partial class StartPage : ContentPage
{
    private readonly LocalDbService _dbService;
    public StartPage(LocalDbService dbService)
    {
        InitializeComponent();
        _dbService = dbService;
    }
    private async void OnButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage(_dbService));
    }


}