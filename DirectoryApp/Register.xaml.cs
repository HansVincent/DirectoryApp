using System.ComponentModel;
using CommunityToolkit.Maui.Views;
using DirectoryApp.RegisterViewModel;
using System.Collections.ObjectModel;
using Microsoft.Maui;
using System.Text.Json;

namespace DirectoryApp;

public partial class Register : ContentPage,INotifyPropertyChanged
{
    StudentViewModel thisStudent = new StudentViewModel();
    string dirPath = "D:\\DirectoryAppFiles";
    string fileName = String.Empty;
    string fileIDPath = String.Empty;
    string fileUsers = "Users.json";
    string fileUserPath = String.Empty;
    public DateTime MaxDate { get; set; } = DateTime.Today;
    public DateTime MinimumDate { get; set; } = DateTime.Today.AddYears(-100);
    private ObservableCollection<string> _studentSchoolProgram;
    private ObservableCollection<string> _studentSchoolCourse;
    private ObservableCollection<string> _studentYearLevel;
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

    public ObservableCollection<string> StudentYearLevel
    {
        get
        {
            return this._studentYearLevel;
        }
        set
        {
            this._studentYearLevel = value;
            OnPropertyChanged(nameof(StudentYearLevel));
        }

    }

    public Register()
    {
        InitializeComponent();
        Shell.Current.Title = "Register User";

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

        StudentYearLevel = new ObservableCollection<string>
        {
            "-Select-",
            "1st Year",
            "2nd Year",
            "3rd Year",
            "4th Year",
            "5th Year"
        };

        StudentSchoolCourse = new ObservableCollection<string>
        {
            "-Select-"
        };
        studentBirthDate.DateSelected += OnDateSelected;
        BindingContext = this;
    }

    private void OnDateSelected(object sender, DateChangedEventArgs e)
    {
        DateTime selectedDate = e.NewDate;
    }

    private void pickerSchoolCourse_SelectedindexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;
    }

    private void pickerSchoolYearLevel_SelectedindexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        pickerStudentSchoolProgram.SelectedIndex = 0;
        pickerStudentYearLevel.SelectedIndex = 0;
        pickerStudentCourse.SelectedIndex = 0;
        txtUserStudentIdentification.Text = String.Empty;
        txtStudentCity.Text = String.Empty;
        txtStudentFirstName.Text = String.Empty;
        txtStudentLastName.Text = String.Empty;
        txtStudentMobileNumber.Text = String.Empty;
        txtStudentPassword.Text = String.Empty;
        txtStudentConfirmPassword.Text = String.Empty;
        txtStudentEmail.Text = String.Empty;
    }

    private int ValidateForm()
    {
        if(validateBehaviorUserStudentID.IsValid)
        {

            if(validateBehaviorStudentFirstName.IsValid)
            {
                if(validateBehaviorStudentLastName.IsValid)
                {
                    if (validateBehaviorStudentPassword.IsValid)
                    {
                        if (validateBehaviorStudentConfirmPassword.IsValid)
                        {
                            if(txtStudentPassword.Text == txtStudentConfirmPassword.Text)
                            {
                                if (validateBehaviorStudentMobileNumber.IsValid)
                                {
                                    if (validateBehaviorStudentEmail.IsValid)
                                    {
                                        if (pickerStudentSchoolProgram.SelectedIndex != 0)
                                        {
                                            if (pickerStudentCourse.SelectedIndex != 0)
                                            {
                                                if (pickerStudentYearLevel.SelectedIndex != 0)
                                                {
                                                    if (rdoStudentGenderFemale.IsChecked || rdoStudentGenderMale.IsChecked)
                                                    {
                                                        if(studentBirthDate.Date != DateTime.Today) 
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
                        }
                    }
                }
            }
        }
        return 1;
    }

    private void ResetForm()
    {
        txtUserStudentIdentification.Text = "";
        txtStudentFirstName.Text = "";
        txtStudentLastName.Text = "";
        txtStudentPassword.Text = "";
        txtStudentConfirmPassword.Text = "";
        txtStudentEmail.Text = "";
        txtStudentCity.Text = "";
        txtStudentMobileNumber.Text = "";
        rdoStudentGenderMale.IsChecked = false;
        rdoStudentGenderFemale.IsChecked = false;
        pickerStudentSchoolProgram.SelectedIndex = 0;
        pickerStudentCourse.SelectedIndex = 0;
        pickerStudentYearLevel.SelectedIndex = 0;
        studentBirthDate.Date = DateTime.Today;
        fileIDPath = String.Empty;
    }

    private void ResetButtonClicked(object sender, EventArgs e)
    {
        ResetForm();
    }

    private async void SubmitButtonClicked(object sender, EventArgs e)
    {
        fileUserPath = Path.Combine(dirPath, fileUsers);
        fileName = txtUserStudentIdentification.Text;
        fileIDPath = Path.Combine(dirPath, "S" + fileName);
        int valid = ValidateForm();
        if(valid == 1)
        {
            await DisplayAlert("Invalid Input", "Please complete all required fields.", "OK");
            return;
        }
        else if(valid == 0)
        {
            RegisterStudent();
            string data = $"Student ID: {thisStudent.UserStudentID.ToString()}\n" + $"Full Name: {thisStudent.StudentLastName} {thisStudent.StudentFirstName}\n" + $"Email: {thisStudent.StudentEmail}\n" + $"Mobile No: {thisStudent.StudentMobileNumber}\n" + $"City: {thisStudent.StudentCity}\n" + $"Gender: {thisStudent.StudentGender}\n" + $"School Program: {thisStudent.StudentSchoolProgram}\n" + $"Course: {thisStudent.StudentSchoolCourse}\n" + $"Year Level: {thisStudent.StudentYearLevel}\n";     
            List<StudentViewModel> students = new List<StudentViewModel>();
            if (!File.Exists(fileIDPath))
            {
                await DisplayAlert("Student Information", data + $"Succesful Registration!\n", "OK");
                var jsonReadString = File.ReadAllText(fileUserPath);
                if (!string.IsNullOrEmpty(jsonReadString))
                {
                    students = JsonSerializer.Deserialize<List<StudentViewModel>>(jsonReadString);
                    students.Add(thisStudent);
                }
                else
                {
                    students.Add(thisStudent);
                }
                var jsonWriteString = JsonSerializer.Serialize<List<StudentViewModel>>(students);
                File.WriteAllText(fileUserPath, jsonWriteString);
                File.Create(fileIDPath);
            }
            else
            {
                await DisplayAlert("Student Information", data, "Student ID already exists.");
            }
        }
    }


    private void RegisterStudent()
    {
        thisStudent.UserStudentID = int.Parse(txtUserStudentIdentification.Text);
        thisStudent.StudentFirstName = txtStudentFirstName.Text;
        thisStudent.StudentLastName = txtStudentLastName.Text;
        thisStudent.StudentEmail = txtStudentEmail.Text;
        thisStudent.StudentPassword = txtStudentPassword.Text;
        thisStudent.StudentSchoolProgram = pickerStudentSchoolProgram.SelectedItem.ToString();
        thisStudent.StudentSchoolCourse = pickerStudentCourse.SelectedItem.ToString();
        thisStudent.StudentYearLevel = pickerStudentYearLevel.SelectedItem.ToString();
        if(rdoStudentGenderMale.IsChecked)
        {
            thisStudent.StudentGender = "Male";
        }
        else if(rdoStudentGenderFemale.IsChecked)
        {
            thisStudent.StudentGender = "Female";
        }
        thisStudent.StudentBirthdate = studentBirthDate.Date.ToString();
        thisStudent.StudentMobileNumber = txtStudentMobileNumber.ToString();
        thisStudent.StudentCity = txtStudentCity.Text;
    }

    private void pickerSchoolProgram_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;
        StudentSchoolCourse.Clear();
        StudentSchoolCourse.Add("-Select-");

        if (selectedIndex == 1)
        {
            StudentSchoolCourse.Add("Bachelor of Science in Civil Engineering");
            StudentSchoolCourse.Add("Bachelor of Science in Computer Engineering");
            StudentSchoolCourse.Add("Bachelor of Science in Mechanical Engineering");
            StudentSchoolCourse.Add("Bachelor of Science in Electronics Engineering");
            StudentSchoolCourse.Add("Bachelor of Science in Electrical Engineering");
            StudentSchoolCourse.Add("Bachelor of Science in Industrial Engineering");
        }
        else if (selectedIndex == 2)
        {
            StudentSchoolCourse.Add("Bachelor of Science in Nursing");
            StudentSchoolCourse.Add("Bachelor of Science in Medical Technology");

        }
        else if (selectedIndex == 3)
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
        else if (selectedIndex == 4)
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
        else if (selectedIndex == 5)
        {
            StudentSchoolCourse.Add("Bachelor of Science in Computer Science");
            StudentSchoolCourse.Add("Bachelor of Science in Information Technology");
            StudentSchoolCourse.Add("Bachelor of Science in Information Systems");
        }
        else if (selectedIndex == 6)
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
        else if (selectedIndex == 7)
        {
            StudentSchoolCourse.Add("Bachelor of Laws");
        }
        else
        {
            return;
        }

    }





}










