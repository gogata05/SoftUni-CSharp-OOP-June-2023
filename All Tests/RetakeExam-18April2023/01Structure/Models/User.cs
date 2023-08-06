namespace EDriveRent.Models
{
    using EDriveRent.Models.Contracts;
    using EDriveRent.Utilities.Messages;
    using System;
    public class User : IUser
    {
        private string firstName;
        private string lastName;
        private string drivingLicenseNumber;
        private double rating;
        private bool isBlocked;

        public User(string firstName, string lastName, string drivingLicenseNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            DrivingLicenseNumber = drivingLicenseNumber;
            this.rating = 0;
            this.isBlocked = false;
        }

        public string FirstName
        {
            get => firstName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.FirstNameNull));
                }
                firstName = value;
            }
        }

        public string LastName
        {
            get => lastName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.LastNameNull));
                }
                lastName = value;
            }
        }

        public string DrivingLicenseNumber
        {
            get => drivingLicenseNumber;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.DrivingLicenseRequired));
                }
                drivingLicenseNumber = value;
            }
        }

        public double Rating => this.rating;

        public bool IsBlocked => this.isBlocked;

        public void DecreaseRating()
        {
            if (this.rating < 2)
            {
                this.rating = 0;
                this.isBlocked = true;
            }
            else
            {
                this.rating -= 2;
            }
        }

        public void IncreaseRating()
        {
            if (this.rating < 10)
            {
                this.rating += 0.5;
            }
        }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} Driving license: {this.drivingLicenseNumber} Rating: {this.rating}";
        }
    }
}
