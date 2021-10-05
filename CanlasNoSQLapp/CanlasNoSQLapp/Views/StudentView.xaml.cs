using CanlasNoSQLapp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CanlasNoSQLapp.Models;

namespace CanlasNoSQLapp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StudentView : ContentPage
    {
        public StudentView()
        {
            InitializeComponent();
            BindingContext = new StudentViewModel();
        }
        public async void OnItemSelected(object sender, ItemTappedEventArgs args)
        {
            var student = args.Item as Student;
            if (student == null) return;

            await Navigation.PushAsync(new StudentDetailPage(student));
            lstStudent.SelectedItem = null;

        }
    }
}