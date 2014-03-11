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
            var movie = new Movie(string.Empty, Movie.Regular);
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
            var expectedMovie = new Movie(string.Empty, Movie.Regular);

            // act
            var rental = new Rental(expectedMovie, 0);
            var actualMovie = rental.Movie;

            // assert
            Assert.AreEqual<Movie>(expectedMovie, actualMovie);
        }

        [TestMethod]
        public void GetFrequentRenterPoint_NewReleaseMoreThan1Days()
        {
            // arrange
            var movie = new Movie(string.Empty, Movie.NewRelease);
            var rental = new Rental(movie, 2);
            int expectedFrequentRenterPoints = 2;

            // act
            int actualFrequentRenterPoints = rental.GetFrequentRenterPoints();

            // assert
            Assert.AreEqual<int>(expectedFrequentRenterPoints, actualFrequentRenterPoints);
        }

        [TestMethod]
        public void GetFrequentRenterPoint_NewReleaseLessOrEqual1Days()
        {
            // arrange
            var movie = new Movie(string.Empty, Movie.NewRelease);
            var rental = new Rental(movie, 1);
            int expectedFrequentRenterPoints = 1;

            // act
            int actualFrequentRenterPoints = rental.GetFrequentRenterPoints();

            // assert
            Assert.AreEqual<int>(expectedFrequentRenterPoints, actualFrequentRenterPoints);
        }

        [TestMethod]
        public void GetFrequentRenterPoint_RegularMoreThan1Days()
        {
            // arrange
            var movie = new Movie(string.Empty, Movie.Regular);
            var rental = new Rental(movie, 2);
            int expectedFrequentRenterPoints = 1;

            // act
            int actualFrequentRenterPoints = rental.GetFrequentRenterPoints();

            // assert
            Assert.AreEqual<int>(expectedFrequentRenterPoints, actualFrequentRenterPoints);
        }
    }
}
