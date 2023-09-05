namespace DirectoryApp
{
    public partial class MainPage : ContentPage
    {
        string setusername = "admin";
        string setpassword = "admin123";

        public MainPage()
        {
            InitializeComponent();
            Shell.Current.Title = "Window Title";
        }

        private void OnLoginClick(object sender, EventArgs e)
        {
            string enteredUsername = username.Text;
            string enteredPassword = password.Text;

            if (enteredUsername == setusername)
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
            else if(enteredUsername != setusername)
            {
                if (enteredPassword != setpassword && !string.IsNullOrWhiteSpace(enteredPassword))
                {
                    Status.Text = "Username and/or Password is incorrect. Please try again";
                }
                else if (enteredPassword == setpassword && !string.IsNullOrWhiteSpace(enteredPassword))
                {
                    Status.Text = "Username and/or Password is incorrect. Please try again";
                }
                else if(string.IsNullOrWhiteSpace(enteredPassword))
                {
                    Status.Text = "Username and/or Password should not be empty. Please try again.";
                }
            }
            else if(enteredUsername == String.Empty)
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

        void OnEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            string oldText = e.OldTextValue;
            string newText = e.NewTextValue;
            string myText = username.Text;
        }


    }
}