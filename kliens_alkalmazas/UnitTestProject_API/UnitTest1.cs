using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using kliens_alkalmazas;


namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            try
            {

                // Arrange
                string expectedUrl = kliens_alkalmazas.Form1.kliens_kulcs.Url;
                string expectedKulcs = kliens_alkalmazas.Form1.kliens_kulcs.Kulcs;



                // Assert
                Assert.IsNotNull(expectedUrl, expectedKulcs);
                Assert.AreEqual(expectedUrl, "http://20.234.113.211:8081");
                Assert.AreEqual(expectedKulcs, "1-96b39a7e-b4d5-4e33-ab50-b2176bfb9844");

                //Assert.IsNotNull(response);
                //Assert.IsTrue(response.Success);
            }

            catch (Exception ex)
            {
                Assert.Fail($"Hiba történt az external API hívás közben: {ex.Message}");
            }
        }

        
    }
}