using PicApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PicApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GalleryPage : ContentPage
    {
        public ObservableCollection<GalleryImage> Images { get; set; } = new ObservableCollection<GalleryImage>();

        public GalleryImage SelectedImage { get; set; }

        public ICommand ItemTapCommand { get; set; }

        public GalleryPage()
        {
            InitializeComponent();

            ItemTapCommand = new Command<GalleryImage>(OnItemTapped);
        }

        protected override void OnAppearing()
        {
            Images = new ObservableCollection<GalleryImage>() 
            { 
                new GalleryImage("name1", "maxresdefault.jpg"),
                new GalleryImage("name2", "maxresdefault.jpg"),
                new GalleryImage("name3", "maxresdefault.jpg"),
                new GalleryImage("name4", "maxresdefault.jpg"),
                new GalleryImage("name5", "maxresdefault.jpg"),
                new GalleryImage("name6", "maxresdefault.jpg"),
                new GalleryImage("name7", "maxresdefault.jpg"),
                new GalleryImage("name8", "maxresdefault.jpg"),
                new GalleryImage("name9", "maxresdefault.jpg"),
                new GalleryImage("name10", "maxresdefault.jpg"),
                new GalleryImage("name11", "maxresdefault.jpg"),
                new GalleryImage("name12", "maxresdefault.jpg"),
                new GalleryImage("name13", "maxresdefault.jpg"),
                new GalleryImage("name14", "maxresdefault.jpg"),
            };

            BindingContext = this;
            base.OnAppearing();
        }

        private void OnItemTapped(GalleryImage selectedImage) 
            => SelectedImage = selectedImage;

        private async void OnClickedOpenImage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PicturePage(SelectedImage));
        }

        private void OnClickedDeleteImage(object sender, EventArgs e)
        {
            Images.Remove(SelectedImage);
        }
    }
}