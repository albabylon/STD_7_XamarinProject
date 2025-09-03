using PicApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PicApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PincodePage : ContentPage
    {
        private StringBuilder _pincodeEntered;
        private int _pincodeCounter;
        private bool _isUserExist;
        
        public User User { get; set; }

        public PincodePage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            _isUserExist = CheckUser();

            _pincodeEntered = new StringBuilder();
            _pincodeCounter = 0;
            
            base.OnAppearing();
        }

        //methods
        private bool CheckUser()
        {
            if (App.Current.Properties.TryGetValue("CurrentUser", out object user))
            {
                if (user is User realUser)
                    User = realUser;

                return true;
            }
            else
            {
                pinStatus.Text = "Задайте PIN из 4 цифр для входа";

                return false;
            }

        }

        private async void CheckUserPincode()
        {
            if (_isUserExist)
            {
                if (User.Pincode == _pincodeEntered.ToString())
                    await Navigation.PushAsync(new GalleryPage());
                else
                {
                    pinStatus.Text = "Введен неверный PIN";
                    await Task.Delay(2000);
                    OnAppearing();
                    pinStatus.Text = "Введите PIN из 4 цифр";
                }
            }
            else
            {
                User = new User(Guid.NewGuid(), _pincodeEntered.ToString());
                App.Current.Properties.Add("CurrentUser", User);
                pinStatus.Text = "Введите PIN из 4 цифр";
                _isUserExist = true;
                CheckUserPincode();
            }
        }

        //handlers
        private void ButtonPinClicked(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                _pincodeEntered.Append(button.Text);
                _pincodeCounter++;
            }

            if (_pincodeCounter == 4)
                CheckUserPincode();
        }
    }
}