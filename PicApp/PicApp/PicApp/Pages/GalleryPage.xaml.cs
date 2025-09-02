using PicApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PicApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GalleryPage : ContentPage
    {
        public ObservableCollection<GalleryImage> Images { get; set; } = new ObservableCollection<GalleryImage>();

        public GalleryPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            Images = new ObservableCollection<GalleryImage>() 
            { 
                new GalleryImage("name1", "maxresdefault.jpg"),
                new GalleryImage("name2", "maxresdefault.jpg"),
                new GalleryImage("name3", "maxresdefault.jpg"),
            };

            BindingContext = this;
            base.OnAppearing();
        }

        private void OnClickedOpenImage(object sender, EventArgs e)
        {

        }

        private void OnClickedDeleteImage(object sender, EventArgs e)
        {

        }
    }
}