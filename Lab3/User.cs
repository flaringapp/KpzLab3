using System;

namespace Lab3
{
    public class User
    {
        public readonly int Id;
        public string FirstName;
        public string LastName;
        public string Email;
        public DateTime DateOfBirth;
        public string Description;
        public int? RentPlaceId;

        public User(int id, string firstName, string lastName, string email, DateTime dateOfBirth, string description, int? rentPlaceId)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            DateOfBirth = dateOfBirth;
            Description = description;
            RentPlaceId = rentPlaceId;
        }

        public int Age => (DateTime.MinValue + (DateTime.Now - DateOfBirth)).Year - 1;
    }
}