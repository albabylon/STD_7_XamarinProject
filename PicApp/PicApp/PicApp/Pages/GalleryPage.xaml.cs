using PicApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
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

            ItemTapCommand = new Command<GalleryImage>(OnItemTappedAction);
        }

        protected override void OnAppearing()
        {
            var images = GetImagesFromPhone();
            Images = new ObservableCollection<GalleryImage>(images);

            BindingContext = this;
            base.OnAppearing();
        }

        private IEnumerable<GalleryImage> GetImagesFromPhone()
        {
            if (Device.RuntimePlatform == Device.Android)
            {
                return new List<GalleryImage>()
                {
                    new GalleryImage("name1", "maxresdefault.jpg", "21.12.2001"),
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
            }
            else
                return new List<GalleryImage>();
        }

        private void OnItemTappedAction(GalleryImage selectedImage)
            => SelectedImage = selectedImage;

        private void OnTapped(object sender, EventArgs e)
        {
            //снятие выделения предыдущих
            galleryFlexLayout.Children.Where(x => x is Frame).ForEach(x => VisualStateManager.GoToState(x, "NotTap"));

            //назначение тапнутой
            if (sender is Frame frame)
                VisualStateManager.GoToState(frame, "Tap");
        }

        private async void OnClickedOpenImage(object sender, EventArgs e)
            => await Navigation.PushAsync(new PicturePage(SelectedImage));

        private void OnClickedDeleteImage(object sender, EventArgs e)
            => Images.Remove(SelectedImage);
    }
}