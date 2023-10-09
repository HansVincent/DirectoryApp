using DirectoryApp.RegisterViewModel;
using System.IO.Enumeration;
using System.Text.Json;

namespace DirectoryApp
{
    public partial class MainPage : ContentPage
    {
        string setusername = "admin";
        string setpassword = "admin123";
        string dirPath = "D:\\DirectoryAppFiles";
        string fileName = "Users.json";
        string filePath = String.Empty;
        public MainPage()
        {
            filePath = Path.Combine(dirPath, fileName);
            if(!File.Exists(filePath)) 
            {
                File.Create(filePath);
            }
            InitializeComponent();
            Shell.Current.Title = "Window Title";
        }

        private async void onLoginClick(object sender, EventArgs e)
        {
            string enteredStudentID = studentID.Text;
            string enteredPassword = password.Text;
            List<StudentViewModel> students = new List<StudentViewModel>();
            List<ContactsViewModel> contacts = new List<ContactsViewModel>();
            ContactsViewModel contact = new ContactsViewModel();
            string fileIDPath = Path.Combine(dirPath, "Users.json");
        
            if (File.Exists(fileIDPath))
            {
                var jsonReadString = File.ReadAllText(fileIDPath);
                if (!string.IsNullOrEmpty(jsonReadString))
                {
                    students = JsonSerializer.Deserialize<List<StudentViewModel>>(jsonReadString);
                    foreach (var data in students)
                    {
                        if (data.UserStudentID == Int32.Parse(enteredStudentID))
                        {
                            if (data.StudentPassword == enteredPassword)
                            {
                                string path = Path.Combine(dirPath, "S" + Convert.ToString(data.UserStudentID) + ".json");
                                jsonReadString = File.ReadAllText(path);
                                contacts = JsonSerializer.Deserialize<List<ContactsViewModel>>(jsonReadString);
                                await Navigation.PushAsync(new Home(enteredStudentID, contacts));
                            }
                        }
                    }
                    if(studentID.Text == String.Empty)
                    {
                        Status.Text = "User ID/Password is empty try again.";
                    }
                    else if(password.Text == String.Empty)
                    {
                        Status.Text = "User ID/Password is empty try again.";
                    }
                    else
                    {
                        Status.Text = "User ID/Password is incorrect try again.";
                    }

                }
            }
        }

        void onEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            string oldText = e.OldTextValue;
            string newText = e.NewTextValue;
            string myText = studentID.Text;
        }

        private async void onNavigateToRegisterTapped(object sender, EventArgs e)
        {
  
            await Navigation.PushAsync(new Register());
        }


    }
}