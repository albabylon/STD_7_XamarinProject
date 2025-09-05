using System;
using System.ComponentModel;

namespace PicApp.Models
{
    public class GalleryImage
    {
        public Guid Guid { get; set; }

        private string name;
        public string Name
        {
            get => name;
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        private string url;
        public string Url
        {
            get => url;
            set
            {
                if (url != value)
                {
                    url = value;
                    OnPropertyChanged("Url");
                }
            }
        }

        private string date;
        public string Date
        {
            get => date;
            set
            {
                if (date != value)
                {
                    date = value;
                    OnPropertyChanged("Date");
                }
            }
        }

        public GalleryImage(string name = null, string url = null, string date = null)
        {
            Guid = Guid.NewGuid();
            this.name = name;
            this.url = url;
            this.date = date;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            GalleryImage gallery = (GalleryImage)obj;

            return Guid == gallery.Guid && Name == gallery.Name;
        }

        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 23 + Guid.GetHashCode();
            hash = hash * 23 + Name?.GetHashCode() ?? 0;
            hash = hash * 23 + Url?.GetHashCode() ?? 0;
            return hash;
        }
    }
}
