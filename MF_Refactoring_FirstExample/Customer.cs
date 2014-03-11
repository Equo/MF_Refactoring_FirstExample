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
            string result = "Rental Record for " + Name + "\n";
            foreach (var each in rentals)
            {
                // Display numbers about this rental
                result += "\t" + each.Movie.Title + "\t" +
                    each.GetCharge().ToString() + "\n";
            }
            // Add footer
            result += "Amount owed is " + GetTotalCharge().ToString() + "\n";
            result += "You earned " + GetTotalFrequentRenterPoints().ToString() +
                " frequent renter points";
            return result;
        }

        public string HtmlStatement()
        {
            string result = "<h1>Rentals for <em>" + Name + "</em></h1><p>\n";
            foreach (var each in rentals)
            {
                // Display numbers about this rental
                result += each.Movie.Title + ": " +
                    each.GetCharge().ToString() + "<br>\n";
            }
            // Add footer
            result += "<p>You owe <em>" + GetTotalCharge().ToString() + "</em><p>\n";
            result += "On this rental you earned <em>" + GetTotalFrequentRenterPoints().ToString() +
                "</em> frequent renter points<p>";
            return result;
        }

        private double AmountFor(Rental rental)
        {
            return rental.GetCharge();
        }

        private double GetTotalCharge()
        {
            double result = 0;
            foreach (var each in rentals)
            {
                result += each.GetCharge();
            }
            return result;
        }

        private int GetTotalFrequentRenterPoints()
        {
            int result = 0;
            foreach (var each in rentals)
            {
                result += each.GetFrequentRenterPoints();
            }
            return result;
        }
    }
}
