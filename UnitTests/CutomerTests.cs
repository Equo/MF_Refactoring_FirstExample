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
    }
}
