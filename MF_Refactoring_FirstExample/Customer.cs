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
                double thisAmount = 0;

                // Calculate amount one by one
                switch(each.Movie.PriceCode)
                {
                    case Movie.Regular:
                        thisAmount += 2;
                        if (each.DaysRented > 2)
                        {
                            thisAmount += (each.DaysRented - 2) * 1.5;
                        }
                        break;
                    case Movie.NewRelease:
                        thisAmount += each.DaysRented * 3;
                        break;
                    case Movie.Childrens:
                        thisAmount += 1.5;
                        if (each.DaysRented > 3)
                        {
                            thisAmount += (each.DaysRented - 3) * 1.5;
                        }
                        break;
                }

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
                    thisAmount.ToString() + "\n";
                totalAmount += thisAmount;

            }
            // Add footer
            result += "Amount owed is " + totalAmount.ToString() + "\n";
            result += "You earned " + frequentRenterPoints.ToString() +
                " frequent renter points";
            return result;

        }
    }
}
