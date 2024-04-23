using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using kliens_alkalmazas;

namespace UnitTestProject_authentication
{
    [TestMethod]
    public void TestCheckUser_ValidUsername_ReturnsTrue()
    {
        string validUsername = "admin";

        bool result = authentication.CheckUser(validUsername);


        Assert.IsTrue(result);
    }

    public void TestCheckUser_InvalidUsername_ReturnsFalse()
    {
        string invalidUsername = "user";


        bool result = authentication.CheckUser(invalidUsername);


        Assert.IsFalse(result);
    }

    public void TestCheckPassword_ValidPassword_ReturnsTrue()
    {
        string validPassword = "asd123";

        bool result = authentication.CheckPassword(validPassword);

        Assert.IsTrue(result);
    }

    public void TestCheckPassword_InvalidPassword_ReturnsFalse()
    {
        string invalidPassword = "password";

        bool result = authentication.CheckPassword(invalidPassword);

        Assert.IsFalse(result);
    }

    public void TestCheckId_ValidId_ReturnsTrue()
    {
        int validId = 5;

        bool result = authentication.CheckId(validId);

        Assert.IsTrue(result);
    }

    public void TestCheckId_InvalidId_ReturnsFalse()
    {
        int invalidId = 10;

        bool result = authentication.CheckId(invalidId);

        Assert.IsFalse(result);
    }
}

