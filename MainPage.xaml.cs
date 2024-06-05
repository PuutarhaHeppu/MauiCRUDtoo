using MauiCRUDtoo.Views;

namespace MauiCRUDtoo
{
    public partial class MainPage : ContentPage
    {
        private readonly LocalDbService _dbService;
        private int _editPersonId;

        public MainPage(LocalDbService dbService)
        {
            InitializeComponent();
            _dbService = dbService;
            Task.Run(async () => listView.ItemsSource = await _dbService.GetPersons());
        }

        private async void saveButton_Clicked(object sender, EventArgs e)
        {
            if (_editPersonId == 0)
            {
                await _dbService.Create(new Person
                {
                    Name = nameEntryField.Text,
                    Email = emailEntryField.Text,
                    PhoneNumber = PhoneNumberEntryField.Text
                });
            }
            else
            {
                await _dbService.Update(new Person
                {
                    Id = _editPersonId,
                    Name = nameEntryField.Text,
                    Email = emailEntryField.Text,
                    PhoneNumber = PhoneNumberEntryField.Text
                });

                _editPersonId = 0;
            }

            nameEntryField.Text = string.Empty;
            emailEntryField.Text = string.Empty;
            PhoneNumberEntryField.Text = string.Empty;

            listView.ItemsSource = await _dbService.GetPersons();
        }

        private async void listView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var Person = (Person)e.Item;
            var action = await DisplayActionSheet("Action", "Cancel", null, "Edit", "Delete");

            switch (action)
            {
                case "Edit":

                    _editPersonId = Person.Id;
                    nameEntryField.Text = Person.Name;
                    emailEntryField.Text = Person.Email;
                    PhoneNumberEntryField.Text = Person.PhoneNumber;

                    break;
                case "Delete":

                    await _dbService.Delete(Person);
                    listView.ItemsSource = await _dbService.GetPersons();
                    break;
            }
        }
    }


}
