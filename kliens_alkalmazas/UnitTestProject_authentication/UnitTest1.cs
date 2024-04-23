using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using kliens_alkalmazas;
using System.Text.RegularExpressions;

namespace UnitTestProject_authentication
{
    [TestClass]
    public class UnitTest2
    {

        [TestMethod]
        public void TestCheckUser()
        {
            // Arrange
            string adminUsername = "admin";
            string regularUsername = "user";

            // Act
            bool isAdminUser = CheckUser(adminUsername);
            bool isRegularUser = CheckUser(regularUsername);

            // Assert
            Assert.IsTrue(isAdminUser);
            Assert.IsFalse(isRegularUser);
        }

        [TestMethod]
        public void TestCheckPassword()
        {
            // Arrange
            string validPassword = "asd123";
            string invalidPassword = "password";

            // Act
            bool isValidPassword = CheckPassword(validPassword);
            bool isInvalidPassword = CheckPassword(invalidPassword);

            // Assert
            Assert.IsTrue(isValidPassword);
            Assert.IsFalse(isInvalidPassword);
        }

        [TestMethod]
        public void TestCheckId()
        {
            // Arrange
            int validId = 5;
            int invalidId = 0; // Az id értékének nullánál nagyobbnak kell lennie.

            // Act
            bool isValidId = CheckId(validId);
            bool isInvalidId = CheckId(invalidId);

            // Assert
            Assert.IsTrue(isValidId);
            Assert.IsFalse(isInvalidId);
        }

        // Segédfüggvények

        private bool CheckUser(string username)
        {
            // Admin felhasználónév ellenőrzése
            Regex adminRegex = new Regex("admin");
            return adminRegex.IsMatch(username);
        }

        private bool CheckPassword(string password)
        {
            // Jelszó ellenőrzése
            Regex passwordRegex = new Regex("asd123");
            return passwordRegex.IsMatch(password);
        }

        private bool CheckId(int id)
        {
            // Id ellenőrzése
            return id > 0;
        }
    }
}

