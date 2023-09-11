using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DirectoryApp.RegisterViewModel;

public class StudentViewModel : INotifyPropertyChanged
{
    private int _userStudentID;
    private string _studentFirstName;
    private string _studentLastName;
    private string _studentEmail;
    private string _studentPassword;
    private string _studentGender;
    private string _studentBirthdate;
    private string _studentMobileNumber;
    private string _studentCity;
    private string _studentSchoolProgram;
    private string _studentSchoolCourse;
    private string _studentYearLevel;
    public event PropertyChangedEventHandler PropertyChanged;
    public int UserStudentID
    {
        get
        {
            return _userStudentID;
        }
        set
        {
            this._userStudentID = value;
            OnPropertyChanged(nameof(UserStudentID));  
        }
    }

    public string StudentFirstName
    {
        get
        {
            return _studentFirstName;
        }
        set
        {
            this._studentFirstName = value;
            OnPropertyChanged(nameof(StudentFirstName));
        }
    }

    public string StudentLastName
    {
        get 
        { 
            return _studentLastName;
        }
        set
        {
            this._studentLastName = value;
            OnPropertyChanged(nameof(StudentLastName));
        }
    }

    public string StudentEmail
    {
        get
        {
            return _studentEmail;
        }
        set
        {
            this._studentEmail = value;
            OnPropertyChanged(nameof(StudentEmail));
        }
    }

    public string StudentPassword
    {
        get
        {
            return _studentPassword;
        }
        set
        {
            this._studentPassword = value;
            OnPropertyChanged(nameof(StudentPassword));
        }
    }

    public string StudentGender
    {
        get
        {
            return _studentGender;
        }
        set
        {
            this._studentGender = value;
            OnPropertyChanged(nameof(StudentGender));
        }
    }

    public string StudentBirthdate
    {
        get
        {
            return _studentBirthdate;
        }
        set
        {
            this._studentBirthdate = value;
            OnPropertyChanged(nameof(_studentLastName));
        }
    }

    public string StudentMobileNumber
    {
        get
        {
            return _studentMobileNumber;
        }
        set
        {
            this._studentMobileNumber = value;
            OnPropertyChanged(nameof(StudentMobileNumber));
        }
    }

    public string StudentCity
    {
        get
        {
            return _studentCity;
        }
        set
        {
            this._studentCity = value;
            OnPropertyChanged(nameof(StudentCity));
        }
    }

    public string StudentSchoolProgram
    {
        get
        {
            return _studentSchoolProgram;
        }
        set
        {
            this._studentSchoolProgram = value;
            OnPropertyChanged(nameof(StudentSchoolProgram));
        }
    }

    public string StudentSchoolCourse
    {
        get
        {
            return _studentSchoolCourse;
        }
        set
        {
            this._studentSchoolCourse = value;
            OnPropertyChanged(nameof(StudentSchoolCourse));
        }
    }

    public string StudentYearLevel
    {
        get
        {
            return _studentYearLevel;
        }
        set
        {
            this._studentYearLevel = value;
            OnPropertyChanged(nameof(StudentYearLevel));
        }
    }
    void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

}