
using System.IO.Enumeration;

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

        private void onLoginClick(object sender, EventArgs e)
        {
            string enteredStudentID = studentID.Text;
            string enteredPassword = password.Text;

            if (enteredStudentID == setusername)
            {
                if(enteredPassword == setpassword && !string.IsNullOrWhiteSpace(enteredPassword))
                {
                    Status.Text = "Login Successful";
                }
                else if(enteredPassword != setpassword && !string.IsNullOrWhiteSpace(enteredPassword))
                {
                    Status.Text = "Username and/or Password is incorrect. Please try again";
                }
                else if(string.IsNullOrWhiteSpace(enteredPassword))
                {
                    Status.Text = "Username and/or Password should not be empty. Please try again.";
                }
            }
            else if(enteredStudentID != setusername)
            {
                if (enteredPassword != setpassword && !string.IsNullOrWhiteSpace(enteredPassword))
                {
                    Status.Text = "User does not exist. Please Register.";
                }
                else if (enteredPassword == setpassword && !string.IsNullOrWhiteSpace(enteredPassword))
                {
                    Status.Text = "User does not exist. Please Register.";
                }
                else if(string.IsNullOrWhiteSpace(enteredPassword))
                {
                    Status.Text = "Username and/or Password should not be empty. Please try again.";
                }
            }
            else if(enteredStudentID == String.Empty)
            {
                if(enteredPassword == String.Empty)
                {
                    Status.Text = "Username and/or Password should not be empty. Please try again.";
                }
                if(enteredPassword != String.Empty)
                {
                    Status.Text = "Username and/or Password should not be empty. Please try again.";
                }
            }
            SemanticScreenReader.Announce(CounterBtn.Text);
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