using PicApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PicApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PicturePage : ContentPage
    {
        public PicturePage(GalleryImage imageToShow)
        {
            InitializeComponent();

            image.Source = imageToShow.Url;
            imageName.Text = imageToShow.Name;
        }
    }
}