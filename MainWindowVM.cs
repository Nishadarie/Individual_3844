using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Individual_3844.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Individual_3844
{
    public  partial class MainWindowVM : ObservableObject
    {
        [ObservableProperty]
        public  ObservableCollection<User> users;
        [ObservableProperty]
        public User selectedUser=null;



        public void CloseMainWindow()
        {
            Application.Current.MainWindow.Close();
        }




        [RelayCommand]
        public void messeag()
        {

            MessageBox.Show($"{selectedUser.FirstName} The GPA should be between 0 and 4 .", "Error");
        }

        [RelayCommand]
        public void AddStudent()
        {
            var vm = new AddUserVM();
            vm.title = "ADD USER";
            AddUserWindow window = new AddUserWindow(vm);
            window.ShowDialog();

            if (vm.Student.FirstName != null)
            {
                users.Add(vm.Student);
            }
        }

        [RelayCommand]
        public void Delete()
        {
            if (selectedUser != null)
            {
                string name = selectedUser.FirstName;
                users.Remove(selectedUser);
                MessageBox.Show($"{name} is  successfuly Deleted.", "DELETED \a ");
                
            }
            else
            {
                MessageBox.Show("Select the student you want to delete.", "Error!");


            }
        }
        [RelayCommand]
        public void ExecuteEditStudentCommand()
        {
            if (selectedUser != null)
            {
                var vm = new AddUserVM(selectedUser);
                vm.title = "EDIT USER";
                var window = new AddUserWindow(vm);

                window.ShowDialog();


                int index = users.IndexOf(selectedUser);
                users.RemoveAt(index);
                users.Insert(index, vm.Student);

            }
            else
            {
                MessageBox.Show("First a student should be selected", "Warning!");
            }
        }

        public  MainWindowVM()
        {
            users = new ObservableCollection<User>();
            BitmapImage image1 = new BitmapImage(new Uri("/Pictures/Images/image 1.png", UriKind.Relative));
            users.Add(new User(40, "Prabhashi", "Nirasha", "15/10/1983" ,image1));
            BitmapImage image2 = new BitmapImage(new Uri("/Pictures/Images/image 2.png", UriKind.Relative));
            users.Add(new User(35, "Nisha", "Wageeshi", "11/10/1988",image2));
            BitmapImage image3 = new BitmapImage(new Uri("/Pictures/Images/image 3.png", UriKind.Relative));
            users.Add(new User(33, "Sumudu", "Dilshan", "05/11/1990",image3));
            BitmapImage image4= new BitmapImage(new Uri("/Pictures/Images/image 4.jpeg", UriKind.Relative));
            users.Add(new User(28, "Sanaj", "Samarakoon", "05/03/1995", image4));

        }
    }
}
