using DirectoryApp.RegisterViewModel;
using System.Collections.ObjectModel;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.ComponentModel;
using Microsoft.Maui.Storage;

namespace DirectoryApp;

public partial class Contacts : ContentPage, INotifyPropertyChanged
{
    ContactsViewModel studentViewModel = new ContactsViewModel();
    ContactsViewModel contactViewModel = new ContactsViewModel();
    private ObservableCollection<string> _studentSchoolCourse;
    private ObservableCollection<string> _studentSchoolProgram;
    private ObservableCollection<string> _contactDetails;
    string userID = String.Empty;
    string dirPath = "D:\\DirectoryAppFiles";
    string fileName = String.Empty;
    string fileIDPath = String.Empty;
    string fileContacts = String.Empty;
    string fileContactsPath = String.Empty;
    int identifier = 0;
    bool IsFaculty = false;
    public ObservableCollection<string> ContactDetails
    {
        get
        {
            return _contactDetails;
        }
        set
        {
            _contactDetails = value;
            OnPropertyChanged(nameof(ContactDetails));
        }
    }
    public ObservableCollection<string> StudentSchoolProgram
    {
        get
        {
            return this._studentSchoolProgram;
        }
        set
        {
            this._studentSchoolProgram = value;
            OnPropertyChanged(nameof(StudentSchoolProgram));
        }

    }
    public ObservableCollection<string> StudentSchoolCourse
    {
        get
        {
            return this._studentSchoolCourse;
        }
        set
        {
            this._studentSchoolCourse = value;
            OnPropertyChanged(nameof(StudentSchoolCourse));
        }

    }
    public Contacts(string ID)
    {
        InitializeComponent();
        userID = ID;

        StudentSchoolProgram = new ObservableCollection<string>
        {
            "-Select-",
            "School of Engineering",
            "School of Allied Medical Sciences",
            "School of Education",
            "School of Arts and Sciences",
            "School of Computer Studies",
            "School of Business Management",
            "School of Law"
        };
        StudentSchoolCourse = new ObservableCollection<string>
        {
            "-Select-"
        };

        BindingContext = this;

    }

    private void PickerSchoolProgram_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;
        StudentSchoolCourse.Clear();
        StudentSchoolCourse.Add("-Select-");

        if (selectedIndex == 1 && IsFaculty == false)
        {
            StudentSchoolCourse.Add("Bachelor of Science in Civil Engineering");
            StudentSchoolCourse.Add("Bachelor of Science in Computer Engineering");
            StudentSchoolCourse.Add("Bachelor of Science in Mechanical Engineering");
            StudentSchoolCourse.Add("Bachelor of Science in Electronics Engineering");
            StudentSchoolCourse.Add("Bachelor of Science in Electrical Engineering");
            StudentSchoolCourse.Add("Bachelor of Science in Industrial Engineering");
        }
        else if (selectedIndex == 2 && IsFaculty == false)
        {
            StudentSchoolCourse.Add("Bachelor of Science in Nursing");
            StudentSchoolCourse.Add("Bachelor of Science in Medical Technology");

        }
        else if (selectedIndex == 3 && IsFaculty == false)
        {
            StudentSchoolCourse.Add("Bachelor of Elementary Education");
            StudentSchoolCourse.Add("Bachelor of Early Childhood Education");
            StudentSchoolCourse.Add("Bachelor of Physical Education");
            StudentSchoolCourse.Add("Bachelor of Secondary Education Major in Filipino");
            StudentSchoolCourse.Add("Bachelor of Secondary Education Major in English");
            StudentSchoolCourse.Add("Bachelor of Secondary Education Major in Science");
            StudentSchoolCourse.Add("Bachelor of Secondary Education Major in Mathematics");
            StudentSchoolCourse.Add("Bachelor of Special Needs Education major in Early Childhood Education");
            StudentSchoolCourse.Add("Bachelor of Special Needs Education major in Elementary School Teaching");
            StudentSchoolCourse.Add("Bachelor of Special Needs Education-Generalist");
        }
        else if (selectedIndex == 4 && IsFaculty == false)
        {
            StudentSchoolCourse.Add("Bachelor of Arts in Communication");
            StudentSchoolCourse.Add("Bachelor of Arts in Marketing Communication");
            StudentSchoolCourse.Add("Bachelor of Arts in English Language Studies");
            StudentSchoolCourse.Add("Bachelor of Arts in Journalism");
            StudentSchoolCourse.Add("Bachelor of Science in Biology major in Microbiology");
            StudentSchoolCourse.Add("Bachelor of Science in Biology major in Medical Biology");
            StudentSchoolCourse.Add("Bachelor of Science in Psychology");
            StudentSchoolCourse.Add("Bachelor of Library and Information Science");
            StudentSchoolCourse.Add("Bachelor of Arts in International Studies");
            StudentSchoolCourse.Add("Bachelor of Arts in Political Science");
        }
        else if (selectedIndex == 5 && IsFaculty == false)
        {
            StudentSchoolCourse.Add("Bachelor of Science in Computer Science");
            StudentSchoolCourse.Add("Bachelor of Science in Information Technology");
            StudentSchoolCourse.Add("Bachelor of Science in Information Systems");
        }
        else if (selectedIndex == 6 && IsFaculty == false)
        {
            StudentSchoolCourse.Add("Bachelor of Science in Accountancy");
            StudentSchoolCourse.Add("Bachelor of Science in Management Accounting");
            StudentSchoolCourse.Add("Bachelor of Science in Business Administration ? Financial Management");
            StudentSchoolCourse.Add("Bachelor of Science in Entrepreneurship");
            StudentSchoolCourse.Add("Bachelor of Science in Business Administration ? Operation Management");
            StudentSchoolCourse.Add("Bachelor of Science in Business Administration ? Marketing Management");
            StudentSchoolCourse.Add("Bachelor of Science in Business Administration ? Human Resource Development Management");
            StudentSchoolCourse.Add("Bachelor of Science in Hospitality Management major in Food and Beverage");
            StudentSchoolCourse.Add("Bachelor of Science in Tourism Management");
        }
        else if (selectedIndex == 7 && IsFaculty == false)
        {
            StudentSchoolCourse.Add("Bachelor of Laws");
        }
        else
        {
            return;
        }
    }

    private int ValidateForm()
    {
        List<StudentViewModel> students = new List<StudentViewModel>();
        string fileIDPath = Path.Combine(dirPath, "S" + txtUserStudentIdentification.Text + ".json");

        if (File.Exists(fileIDPath))
        {
            var jsonReadString = File.ReadAllText(fileIDPath);
            if (!string.IsNullOrEmpty(jsonReadString))
            {
                students = JsonSerializer.Deserialize<List<StudentViewModel>>(jsonReadString);
                foreach (var data in students)
                {
                    if (data.UserStudentID == Int32.Parse(txtUserStudentIdentification.Text))
                    {
                        identifier = 1;
                        break;
                    }
                }

            }
        }
        if (txtUserStudentIdentification.Text != null && identifier == 0)
        {

            if (txtStudentFirstName.Text != null)
            {
                if (txtStudentLastName.Text != null)
                {
                    if (txtStudentEmail.Text != null)
                    {
                        if (txtStudentMobileNumber.Text != null)
                        {
                            if (pickerStudentSchoolProgram.SelectedIndex != 0)
                            {
                                if (pickerStudentCourse.SelectedIndex != 0)
                                {           
                                   if (rdoContactTypeFaculty.IsChecked || rdoContactTypeStudent.IsChecked)
                                   {
                                     return 0;
                                   }

                                }
                            }
                        }
                    }
                }
            }
        }
        return 1;
    }

    private void PickerSchoolCourse_SelectedindexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;
    }

    public void AddContact()
    {
        studentViewModel.StudentID = txtUserStudentIdentification.Text;
        studentViewModel.FirstName = txtStudentFirstName.Text;
        studentViewModel.LastName = txtStudentLastName.Text;
        studentViewModel.Email = txtStudentEmail.Text;
        studentViewModel.SchoolProgram = pickerStudentSchoolProgram.SelectedItem.ToString();
        studentViewModel.SchoolCourse = pickerStudentCourse.SelectedItem.ToString();
        if (rdoContactTypeFaculty.IsChecked)
        {
            studentViewModel.Type = "Faculty";
            IsFaculty = true;
            txtUserStudentIdentification.MaxLength = 4;
        }
        else if (rdoContactTypeStudent.IsChecked)
        {
            studentViewModel.Type = "Student";
        }
        studentViewModel.MobileNumber = txtStudentMobileNumber.Text;

    }



    protected override void OnAppearing()
    {
        base.OnAppearing();

        pickerStudentSchoolProgram.SelectedIndex = 0;
        pickerStudentCourse.SelectedIndex = 0;
        txtUserStudentIdentification.Text = String.Empty;
        txtStudentFirstName.Text = String.Empty;
        txtStudentLastName.Text = String.Empty;
        txtStudentMobileNumber.Text = String.Empty;
        txtStudentEmail.Text = String.Empty;
    }

    private async void SubmitButtonClicked(object sender, EventArgs e)
    {
        fileName = userID;
        fileIDPath = Path.Combine(dirPath, "S" + fileName + ".json");
        int valid = ValidateForm();
        if(identifier == 1)
        {
            await DisplayAlert("Invalid Input", "ID already exists", "OK");
            return;
        }
        else if (valid == 1)
        {
            await DisplayAlert("Invalid Input", "Please complete all required fields.", "OK");
            return;
        }
        else if (valid == 0)
        {
            AddContact();
            string data = $"Student ID: {studentViewModel.StudentID.ToString()}\n" + $"Full Name: {studentViewModel.LastName} {studentViewModel.FirstName}\n" + $"Email: {studentViewModel.Email}\n" + $"Mobile No: {studentViewModel.MobileNumber}\n"  + $"School Program: {studentViewModel.SchoolProgram}\n" + $"Course: {studentViewModel.SchoolCourse}\n";
            List<ContactsViewModel> students = new List<ContactsViewModel>();
            if (File.Exists(fileIDPath))
            {
                var jsonReadString = File.ReadAllText(fileIDPath);
                if (!string.IsNullOrEmpty(jsonReadString))
                {
                    students = JsonSerializer.Deserialize<List<ContactsViewModel>>(jsonReadString);
                    students.Add(studentViewModel);
                }
                else
                {
                    students.Add(studentViewModel);
                }
                var jsonWriteString = JsonSerializer.Serialize<List<ContactsViewModel>>(students);
                File.WriteAllText(fileIDPath, jsonWriteString);
                await DisplayAlert("Student Information", data + $"Succesful Registration!\n", "OK");
                await Navigation.PushAsync(new Home((txtUserStudentIdentification.Text), students));
            }
            else
            {
                await DisplayAlert("Student Information", data, "Student ID does not exists.");
            }
        }  
    }
    private void ResetForm()
    {
        txtUserStudentIdentification.Text = "";
        txtStudentFirstName.Text = "";
        txtStudentLastName.Text = "";
        txtStudentEmail.Text = "";
        txtStudentMobileNumber.Text = "";
        rdoContactTypeFaculty.IsChecked = false;
        rdoContactTypeStudent.IsChecked = false;
        pickerStudentSchoolProgram.SelectedIndex = 0;
        pickerStudentCourse.SelectedIndex = 0;
        fileIDPath = String.Empty;
    }

    private void ResetButtonClicked(object sender, EventArgs e)
    {
        ResetForm();
    }
}