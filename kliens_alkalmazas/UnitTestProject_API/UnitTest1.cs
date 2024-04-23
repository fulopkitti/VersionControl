using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.NetworkInformation;
using System;
using kliens_alkalmazas;


namespace UnitTestProject_API
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
                string ipAddress = "20.234.113.211";

                // Act
                bool isReachable = IsReachable(ipAddress);

                // Assert
                Assert.IsTrue(isReachable, $"The IP address {ipAddress} is not reachable.");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Hiba történt az IP cím elérhetőségének ellenőrzése közben: {ex.Message}");
            }
        }

        public bool IsReachable(string ipAddress)
        {
            using (Ping ping = new Ping())
            {
                try
                {
                    PingReply reply = ping.Send(ipAddress);
                    return reply.Status == IPStatus.Success;
                }
                catch
                {
                    return false;
                }
            }
        }
    }

}
