using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MF_Refactoring_FirstExample;

namespace FirstExampleTests
{
    [TestClass]
    public class RentalTests
    {
        [TestMethod]
        public void RentalCtor_DaysRentedGetter()
        {
            // arrange
            var movie = new Movie(string.Empty, 0);
            int expectedDaysRented = 1;

            // act
            var rental = new Rental(movie, expectedDaysRented);
            int actualDaysRented = rental.DaysRented;

            // assert
            Assert.AreEqual<int>(expectedDaysRented, actualDaysRented);
        }

        [TestMethod]
        public void RentalCtor_MovieGetter()
        {
            // arrange
            var expectedMovie = new Movie(string.Empty, 0);

            // act
            var rental = new Rental(expectedMovie, 0);
            var actualMovie = rental.Movie;

            // assert
            Assert.AreEqual<Movie>(expectedMovie, actualMovie);
        }
    }
}
