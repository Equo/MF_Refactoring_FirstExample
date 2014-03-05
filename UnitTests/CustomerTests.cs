using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MF_Refactoring_FirstExample;

namespace FirstExampleTests
{
    [TestClass]
    public class CustomerTests
    {
        [TestMethod]
        public void CustomerCtor_NameGetter()
        {
            // arrange
            string expectedName = "equo";

            // act
            var customer = new Customer(expectedName);
            string actualName = customer.Name;

            // assert
            Assert.AreEqual<string>(expectedName, actualName);
        }

        [TestMethod]
        public void AddRental()
        {
            // arrange
            var movie = new Movie(string.Empty, 0);
            var rental = new Rental(movie, 1);
            var customer = new Customer("equo");
            
            // act
            customer.AddRental(rental);

            // assert
            ;
        }

        [TestMethod]
        public void Statement_NoRental()
        {
            // arrange
            var customer = new Customer("equo");
            string expectedStatement =
                "Rental Record for equo" + "\n" +
                "Amount owed is 0" + "\n" +
                "You earned 0 frequent renter points";

            // act
            string actualStatement = customer.Statement();

            // assert
            Assert.AreEqual<string>(expectedStatement, actualStatement);
        }

        [TestMethod]
        public void Statement_RegularLessOrEqual2Days()
        {
            // arrange
            var customer = new Customer("equo");
            var movie = new Movie("hoge", Movie.Regular);
            var rental = new Rental(movie, 2);
            customer.AddRental(rental);
            string expectedStatement =
                "Rental Record for equo" + "\n" +
                "\t" + "hoge" + "\t" + "2" + "\n" +
                "Amount owed is 2" + "\n" +
                "You earned 1 frequent renter points";

            // act
            string actualStatement = customer.Statement();

            // assert
            Assert.AreEqual<string>(expectedStatement, actualStatement);
        }

        [TestMethod]
        public void Statement_RegularMoreThan2Days()
        {
            // arrange
            var customer = new Customer("equo");
            var movie = new Movie("hoge", Movie.Regular);
            var rental = new Rental(movie, 3);
            customer.AddRental(rental);
            string expectedStatement =
                "Rental Record for equo" + "\n" +
                "\t" + "hoge" + "\t" + "3.5" + "\n" +
                "Amount owed is 3.5" + "\n" +
                "You earned 1 frequent renter points";

            // act
            string actualStatement = customer.Statement();

            // assert
            Assert.AreEqual<string>(expectedStatement, actualStatement);
        }

        [TestMethod]
        public void Statement_NewReleaseLessOrEqual1Days()
        {
            // arrange
            var customer = new Customer("equo");
            var movie = new Movie("piyo", Movie.NewRelease);
            var rental = new Rental(movie, 1);
            customer.AddRental(rental);
            string expectedStatement =
                "Rental Record for equo" + "\n" +
                "\t" + "piyo" + "\t" + "3" + "\n" +
                "Amount owed is 3" + "\n" +
                "You earned 1 frequent renter points";

            // act
            string actualStatement = customer.Statement();

            // assert
            Assert.AreEqual<string>(expectedStatement, actualStatement);
        }

        [TestMethod]
        public void Statement_NewReleasMoreThan1Days()
        {
            // arrange
            var customer = new Customer("equo");
            var movie = new Movie("piyo", Movie.NewRelease);
            var rental = new Rental(movie, 2);
            customer.AddRental(rental);
            string expectedStatement =
                "Rental Record for equo" + "\n" +
                "\t" + "piyo" + "\t" + "6" + "\n" +
                "Amount owed is 6" + "\n" +
                "You earned 2 frequent renter points";

            // act
            string actualStatement = customer.Statement();

            // assert
            Assert.AreEqual<string>(expectedStatement, actualStatement);
        }

        [TestMethod]
        public void Statement_ChildrensLessOrEqual3Days()
        {
            // arrange
            var customer = new Customer("equo");
            var movie = new Movie("fuga", Movie.Childrens);
            var rental = new Rental(movie, 3);
            customer.AddRental(rental);
            string expectedStatement =
                "Rental Record for equo" + "\n" +
                "\t" + "fuga" + "\t" + "1.5" + "\n" +
                "Amount owed is 1.5" + "\n" +
                "You earned 1 frequent renter points";

            // act
            string actualStatement = customer.Statement();

            // assert
            Assert.AreEqual<string>(expectedStatement, actualStatement);
        }

        [TestMethod]
        public void Statement_ChildrensMoreThan3Days()
        {
            // arrange
            var customer = new Customer("equo");
            var movie = new Movie("fuga", Movie.Childrens);
            var rental = new Rental(movie, 4);
            customer.AddRental(rental);
            string expectedStatement =
                "Rental Record for equo" + "\n" +
                "\t" + "fuga" + "\t" + "3" + "\n" +
                "Amount owed is 3" + "\n" +
                "You earned 1 frequent renter points";

            // act
            string actualStatement = customer.Statement();

            // assert
            Assert.AreEqual<string>(expectedStatement, actualStatement);
        }

        [TestMethod]
        public void Statement_Sum()
        {
            // arrange
            var customer = new Customer("equo");
            var hoge    = new Movie("Hoge",     Movie.Regular);
            var piyo    = new Movie("Piyo",     Movie.Regular);
            var fuga    = new Movie("Fuga",     Movie.NewRelease);
            var hogera  = new Movie("Hogera",   Movie.Childrens);
            customer.AddRental(new Rental(hoge,     1));
            customer.AddRental(new Rental(piyo,     3));
            customer.AddRental(new Rental(fuga,     2));
            customer.AddRental(new Rental(hogera,   4));
            string expectedStatement =
                "Rental Record for equo" + "\n" +
                "\t" + "Hoge" + "\t" + "2" + "\n" +
                "\t" + "Piyo" + "\t" + "3.5" + "\n" +
                "\t" + "Fuga" + "\t" + "6" + "\n" +
                "\t" + "Hogera" + "\t" + "3" + "\n" +
                "Amount owed is 14.5" + "\n" +
                "You earned 5 frequent renter points";

            // act
            string actualStatement = customer.Statement();

            // assert
            Assert.AreEqual<string>(expectedStatement, actualStatement);
        }
    }
}
