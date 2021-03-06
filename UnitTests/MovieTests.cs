﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MF_Refactoring_FirstExample;

namespace FirstExampleTests
{
    [TestClass]
    public class MovieTests
    {
        [TestMethod]
        public void MovieCtor_TitleGetter()
        {
            // arrange
            string expectedTitle = "title";

            // act
            var movie = new Movie(expectedTitle, Movie.Regular);
            string actualTitle = movie.Title;

            // assert
            Assert.AreEqual<string>(expectedTitle, actualTitle);
        }

        [TestMethod]
        public void MovieCtor_PriceCodeGetter()
        {
            // arrange
            int expectedPriceCode = Movie.Regular;

            // act
            var movie = new Movie(string.Empty, expectedPriceCode);
            int actualPriceCode = movie.PriceCode;

            // assert
            Assert.AreEqual<int>(expectedPriceCode, actualPriceCode);
        }

        [TestMethod]
        public void PriceCodeSetter_Getter()
        {
            // arrange
            var movie = new Movie(string.Empty, Movie.Regular);
            int expectedPriceCode = Movie.NewRelease;

            // act
            movie.PriceCode = expectedPriceCode;
            int actualPriceCode = movie.PriceCode;

            // assert
            Assert.AreEqual<int>(expectedPriceCode, actualPriceCode);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PriceCodeSetter_OutOfRangeException_Under()
        {
            // arrange
            var movie = new Movie(string.Empty, Movie.Regular);
            
            // act
            movie.PriceCode = -1;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PriceCodeSetter_OutOfRangeException_Over()
        {
            // arrange
            var movie = new Movie(string.Empty, Movie.Regular);

            // act
            movie.PriceCode = 3;
        }
    }
}
