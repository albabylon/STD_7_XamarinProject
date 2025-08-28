using System;

namespace PicApp.Models
{
    public class User
    {
        public Guid Id { get; set; }

        public string Pincode { get; set; }

        public User(Guid id, string pincode)
        {
            Id = id;
            Pincode = pincode;
        }
    }
}
