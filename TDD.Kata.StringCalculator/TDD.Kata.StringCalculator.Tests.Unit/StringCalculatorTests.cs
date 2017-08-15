using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TDD.Kata.StringCalculator.Tests.Unit
{
    [TestClass]
    public class StringCalculatorTests
    {
        private StringCalculator Target;

        [TestInitialize]
        public void Initialize()
        {
            this.Target = new StringCalculator();
        }

        [TestMethod]
        public void add_emptystring_zero()
        {
            //Arrange

            //Act
            var result = Target.Add("");

            //Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void add_singlenumber_returnsThatNumber_1()
        {
            //Arrange

            //Act
            var result = Target.Add("1");

            //Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void add_single_number_returns_that_number_2()
        {
            //Arrange

            //Act
            var result = Target.Add("2");

            //Assert
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void add_two_numbers_sums_them_1()
        {
            //Arrange

            //Act
            var result = Target.Add("1,2");

            //Assert
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void add_two_numbers_sums_them_2()
        {
            //Arrange

            //Act
            var result = Target.Add("1,3");

            //Assert
            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void add_two_larger_numbers_sums_them()
        {
            //Arrange

            //Act
            var result = Target.Add("10,30");

            //Assert
            Assert.AreEqual(40, result);
        }

        [TestMethod]
        public void add_new_line_zero()
        {
            //Arrange

            //Act
            var result = Target.Add("\n");

            //Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void add_new_line_be_tween_numbers_treats_as_seperator()
        {
            //Arrange

            //Act
            var result = Target.Add("1\n2");

            //Assert
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void add_different_delimiter_used_to_parse_the_sum()
        {
            //Arrange

            //Act
            var result = Target.Add("//A\n1A2");

            //Assert
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void add_different_delimiter_used_to_parse_the_sum_2()
        {
            //Arrange

            //Act
            var result = Target.Add("//B\n1B2");

            //Assert
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void add_negative_throws()
        {
            //Arrange

            //Act
            var result = Target.Add("-1");

            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void add_multiple_negative_throws()
        {
            //Arrange

            //Act
            var result = Target.Add("-1,-2");

            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void add_negativeandpositive_throwsonlythenegative()
        {
            //Arrange

            //Act
            var result = Target.Add("-1,2");

            //Assert
        }

        [TestMethod]
        public void add_numbers_bigger_than_1000_ignored()
        {
            //Arrange

            //Act
            var result = Target.Add("2,1001");

            //Assert
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void add_delimiters_longer_than_one_char_still_accepted()
        {
            //Arrange

            //Act
            var result = Target.Add("//AAA\n1AAA2AAA3");

            //Assert
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void add_multiple_delimiters_all_used()
        {
            //Arrange

            //Act
            var result = Target.Add("//[A][b]\n1A2b3");

            //Assert
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void add_multiple_delimiters_all_used_2()
        {
            //Arrange

            //Act
            var result = Target.Add("//[AB][bc]\n1AB2bc3");

            //Assert
            Assert.AreEqual(6, result);
        }
    }
}
