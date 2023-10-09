using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;


namespace DirectoryApp.RegisterViewModel
{

    public class ContactsViewModel : INotifyPropertyChanged
    {
        private string _type;
        private string _studentID;
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _schoolProgram;
        private string _schoolCourse;
        private string _mobileNumber;
        public event PropertyChangedEventHandler PropertyChanged;

        public string Type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
                OnPropertyChanged(nameof(Type));
            }
        }

        public string StudentID
        {
            get
            {
                return _studentID;
            }
            set
            {
                _studentID = value;
                OnPropertyChanged(nameof(StudentID));
            }
        }

        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }

        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        public string SchoolProgram
        {
            get
            {
                return _schoolProgram;
            }
            set
            {
                _schoolProgram = value;
                OnPropertyChanged(nameof(SchoolProgram));
            }
        }

        public string SchoolCourse
        {
            get
            {
                return _schoolCourse;
            }
            set
            {
                _schoolCourse = value;
                OnPropertyChanged(nameof(SchoolCourse));
            }
        }

        public string MobileNumber
        {
            get
            {
                return _mobileNumber;
            }
            set
            {
                _mobileNumber = value;
                OnPropertyChanged(nameof(MobileNumber));
            }
        }

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
