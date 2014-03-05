using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MF_Refactoring_FirstExample
{
    public class Customer
    {
        private string name;
        private List<Rental> rentals = new List<Rental>();

        public Customer(string name)
        {
            this.name = name;
        }

        public void AddRental(Rental arg)
        {
            rentals.Add(arg);
        }

        public string Name
        {
            get { return name; }
        }

        public string Statement()
        {
            double totalAmount = 0;
            int frequentRenterPoints = 0;
            string result = "Rental Record for " + Name + "\n";
            foreach (var each in rentals)
            {
                // Add rental points
                frequentRenterPoints++;
                // Give bonus points if rented "new release" over two days
                if ((each.Movie.PriceCode == Movie.NewRelease) &&
                    each.DaysRented > 1)
                {
                    frequentRenterPoints++;
                }

                // Display numbers about this rental
                result += "\t" + each.Movie.Title + "\t" +
                    each.GetCharge().ToString() + "\n";
                totalAmount += each.GetCharge();

            }
            // Add footer
            result += "Amount owed is " + totalAmount.ToString() + "\n";
            result += "You earned " + frequentRenterPoints.ToString() +
                " frequent renter points";
            return result;
        }

        private double AmountFor(Rental rental)
        {
            return rental.GetCharge();
        }
    }
}
