using Moq;
using System.Text.Json;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Net;
using Castle.Core.Resource;

namespace MonarchsChallenge.Tests
{
    public class MonarchsCollectorTest
    {

        [Test, Category("TEST 1: Test_getAsynch_success , verify rest call request/response")]
        public void Test_getAsynch_success()
        {
            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            var httpClient = new Mock<CustomClient>();
            var json = JsonSerializer.Serialize<Monarch[]>(GetMonarchList());
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(json, System.Text.Encoding.UTF8, "application/json") }; 
            
            httpClient.Setup(s=>s.GetAsync(It.IsAny<string>())).ReturnsAsync(response);
            var MonarchColl = new MonarchsCollector(httpClient.Object);
            var result = MonarchColl.GetMonarchs();
            Monarch[] data = result.Result;
            Assert.That(result, Is.Not.Null);
            Assert.That(data.Length, Is.EqualTo(5));

        }

        [Test, Category("TEST 2: Test_getAsync_null_response")]
        public void Test_getAsynch_failure()
        {
            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            var httpClient = new Mock<CustomClient>();
            var json = JsonSerializer.Serialize<Monarch[]>(null);
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(json, System.Text.Encoding.UTF8, "application/json") };

            httpClient.Setup(s => s.GetAsync(It.IsAny<string>())).ReturnsAsync(response);
            var MonarchColl = new MonarchsCollector(httpClient.Object);
            var result = MonarchColl.GetMonarchs();
            Assert.That(result.Exception, Is.Not.Null);

        }

        [Test, Category("TEST 3: Test_getAsync_failure")]
        public void Test_getAsynch_failure1()
        {
            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            var httpClient = new Mock<CustomClient>();
            var json = JsonSerializer.Serialize<Monarch[]>(null);
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.ExpectationFailed) { Content = new StringContent(json, System.Text.Encoding.UTF8, "application/json") };

            httpClient.Setup(s => s.GetAsync(It.IsAny<string>())).ReturnsAsync(response);
            var MonarchColl = new MonarchsCollector(httpClient.Object);
            var result = MonarchColl.GetMonarchs();
            Assert.That(result.Exception, Is.Not.Null);
            Assert.That(result.Exception.InnerException.Message, Is.EqualTo("failed to collect data"));
        }

        //Test Data
        private Monarch[] GetMonarchList()
        {
            Monarch[] listOfMonarch = new Monarch[5];
            Monarch monarch1 = new Monarch();
            monarch1.Name = "Edward the Martyr   ";
            monarch1.Country = "United Kingdom";
            monarch1.House = "House of Normandy";
            monarch1.Years = "1485-1509";



            listOfMonarch[0] = monarch1;

            Monarch monarch2 = new Monarch();
            monarch2.Name = "Edmund";
            monarch2.Country = "United Kingdom";
            monarch2.House = "House of Normandy";
            monarch2.Years = "1987-";

            listOfMonarch[1] = monarch2;

            Monarch monarch3 = new Monarch();
            monarch3.Name = "Henry VI";
            monarch3.Country = "Norway";
            monarch3.House = "House of Lancaster";
            monarch3.Years = "899";

            listOfMonarch[2] = monarch3;

            Monarch monarch4 = new Monarch();
            monarch4.Name = "William III";
            monarch4.Country = "United Kingdom";
            monarch4.House = "House of Normandy";
            monarch4.Years = "900-1918";

            listOfMonarch[3] = monarch4;

            Monarch monarch5 = new Monarch();
            monarch5.Name = "William III";
            monarch5.Country = "United Kingdom";
            monarch5.House = "House of Normandy";
            monarch5.Years = "1700-1918";

            listOfMonarch[4] = monarch5;

            return listOfMonarch;

        }
    }
}
