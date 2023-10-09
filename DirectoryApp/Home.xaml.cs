using DirectoryApp.RegisterViewModel;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace DirectoryApp;

public partial class Home : ContentPage
{
    string userID = String.Empty;
    public Home(string ID, List<ContactsViewModel> students)
    {
        InitializeComponent();
        userID = ID;
        BindingContext = students;
    }



    private async void OnNavigateToAddContactTapped(object sender, EventArgs e)
    {

        await Navigation.PushAsync(new Contacts(userID));
    }
}