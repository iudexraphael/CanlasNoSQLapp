using CanlasNoSQLapp.Models;
using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanlasNoSQLapp.Services
{
  public class DBFirebase
    {
        FirebaseClient client;

        public DBFirebase ()
        {
            client = new FirebaseClient("https://xamarinactivity-default-rtdb.firebaseio.com/");
        }

        public ObservableCollection<Student> getStudent()
        {
            var studentData = client
                .Child("Student")
                .AsObservable<Student>()
                .AsObservableCollection();

            return studentData;
        }

        public async Task AddStudent(int studentID, string studentName, string course, string yearlvl, string section)
        {
            Student stud = new Student() { StudentID = studentID, StudentName = studentName, 
                Course = course, YearLevel = yearlvl, Section = section};

            await client.Child("Student").PostAsync(stud);
        }
        public async Task DeleteStudent(int studentID, string studentName, string course, string yearlvl, string section)
        {
            var toDeleteStudent = (await client
                 .Child("Student")
                 .OnceAsync<Student>()).FirstOrDefault
                 (a => a.Object.StudentID == studentID
                 || a.Object.YearLevel == yearlvl
                 || a.Object.Course == course
                 || a.Object.Section == section
                 || a.Object.Course == course
                 || a.Object.StudentName == studentName);

            await client.Child("Student").Child(toDeleteStudent.Key).DeleteAsync();

        }
        public async Task UpdateStudent(int studentID, string studentName, string course, string yearlvl, string section)
        {
            var toUpdateStudent = (await client
                .Child("Student")
                .OnceAsync<Student>()).FirstOrDefault
               (a => a.Object.StudentID == studentID
                 || a.Object.YearLevel == yearlvl
                 || a.Object.Course == course
                 || a.Object.Section == section
                 || a.Object.Course == course
                 || a.Object.StudentName == studentName);

            Student e = new Student()
            {
                StudentID = studentID,
                StudentName = studentName,
                Course = course,
                YearLevel = yearlvl,
                Section = section
            };
            await client
                .Child("Student")
                .Child(toUpdateStudent.Key)
                .PutAsync(e);
        }
    }
}
