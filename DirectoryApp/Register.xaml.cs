using System.ComponentModel;
using CommunityToolkit.Maui.Views;
using DirectoryApp.RegisterViewModel;
using System.Collections.ObjectModel;
using Microsoft.Maui;

namespace DirectoryApp;

public partial class Register : ContentPage,INotifyPropertyChanged
{
    public DateTime MaxDate { get; set; } = DateTime.Today;
    public DateTime MinimumDate { get; set; } = DateTime.Today.AddYears(-100);
    private ObservableCollection<string> _studentSchoolProgram;
    private ObservableCollection<string> _studentSchoolCourse;
    private ObservableCollection<string> _studentYearLevel;
    private bool pickerSchoolProgram = false;
    private bool pickerSchoolCourse = false;
    private bool pickerYearLevel = false;
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

        if (selectedDate == DateTime.Today)
        {
            borderBirthDatePicker.Stroke = Colors.Red;
        }
    }


    private void pickerSchoolProgram_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;

        if (selectedIndex == 0)
        {
            borderStudentSchoolProgram.Stroke = Colors.Red;
        }
        else
        {
            borderStudentSchoolProgram.Stroke = Colors.Black;
        }
        StudentSchoolCourse.Clear();
        StudentSchoolCourse.Add("-SELECT-");

        if (selectedIndex == 1)
        {
            StudentSchoolCourse.Add("Bachelor of Science in Civil Engineering");
            StudentSchoolCourse.Add("Bachelor of Science in Computer Engineering");
            StudentSchoolCourse.Add("Bachelor of Science in Electrical Engineering");
            StudentSchoolCourse.Add("Bachelor of Science in Electronics Engineering");
            StudentSchoolCourse.Add("Bachelor of Science in Industrial Engineering");
            StudentSchoolCourse.Add("Bachelor of Science in Mechanical Engineering");
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
            StudentSchoolCourse.Add("Bachelor of Secondary Education Major in English");
            StudentSchoolCourse.Add("Bachelor of Secondary Education Major in Filipino");
            StudentSchoolCourse.Add("Bachelor of Secondary Education Major in Mathematics");
            StudentSchoolCourse.Add("Bachelor of Secondary Education Major in Science");
            StudentSchoolCourse.Add("Bachelor of Special Needs Education-Generalist");
            StudentSchoolCourse.Add("Bachelor of Special Needs Education major in Early Childhood Education");
            StudentSchoolCourse.Add("Bachelor of Special Needs Education major in Elementary School Teaching");
        }
        else if (selectedIndex == 4)
        {
            StudentSchoolCourse.Add("Bachelor of Arts in Communication");
            StudentSchoolCourse.Add("Bachelor of Arts in Marketing Communication");
            StudentSchoolCourse.Add("Bachelor of Arts in Journalism");
            StudentSchoolCourse.Add("Bachelor of Arts in English Language Studies");
            StudentSchoolCourse.Add("Bachelor of Science in Biology major in Medical Biology");
            StudentSchoolCourse.Add("Bachelor of Science in Biology major in Microbiology");
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










