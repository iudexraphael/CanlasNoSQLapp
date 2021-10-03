using System;
using System.Collections.Generic;
using System.Text;

using System.Threading.Tasks;
using Xamarin.Forms;
using MvvmHelpers;

using CanlasNoSQLapp.Services;
using CanlasNoSQLapp.Models;
using System.Collections.ObjectModel;

namespace CanlasNoSQLapp.ViewModels
{
    class StudentViewModel : BaseViewModel
    {
        public int StudentID { get; set; }

        public string StudentName { get; set; }

        public string Course { get; set; }

        public string YearLevel { get; set; }

        public string Section { get; set; }

        private DBFirebase services;

        public Command AddStudentCommand { get; }
        public ObservableCollection<Student> _students = new ObservableCollection<Student>();
        public ObservableCollection<Student> Students
        {
            get { return _students; }
            set
            {
                _students = value;
                OnPropertyChanged();
            }
        }

        public StudentViewModel ()
        {
            services = new DBFirebase();
            Students = services.getStudent();
            AddStudentCommand = new Command(async () => await addStudentAsync(StudentID, StudentName, Course, YearLevel, Section));
       
        }
        public async Task addStudentAsync(int StudentID, string StudentName, string Course, string YearLevel, string Section)
        {
            await services.AddStudent(StudentID, StudentName, Course, YearLevel, Section);
        }
            
            }
}
