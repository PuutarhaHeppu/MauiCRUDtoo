namespace MauiCRUDtoo
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(MainPage);
        }
    }

}
