namespace MauiCRUDtoo.Views;

public partial class StartPage : ContentPage
{
	public StartPage()
	{
		InitializeComponent();

	}

    private async void OnCounterClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }
}