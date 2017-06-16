using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Moq;
using MYOB_Coding_Exercise;
using MYOB_Coding_Exercise.Interface;
using MYOB_Coding_Exercise.Model;

namespace MYOBCodingExerciseTest
{
    [TestClass]
    public class ApiCallTest
    {
        private readonly ApiCall _api = new ApiCall(new MYOBHttpClient());
        [TestMethod]
        public void GetGameManifest_Successful()
        {           
            //Act
            var actual = _api.GetGameManifest().Result;

            //Assert
            Assert.IsInstanceOfType(actual.Id, typeof(int));
            Assert.IsInstanceOfType(actual.ChildrenCount, typeof(int));
            Assert.IsInstanceOfType(actual.EliminateEach, typeof(int));
        }

        [TestMethod]        
        public void GetGameManifest_Failure()
        {
            //Arrange
            var mockHttpClient = new Mock<IHttpClient>();

            mockHttpClient.Setup(x=>x.GetAsync(It.IsAny<string>())).Returns(Task.FromResult(new HttpResponseMessage(HttpStatusCode.BadRequest)));
            //var responseMessage = new HttpResponseMessage(HttpStatusCode.BadRequest);
            //var messageHandler = new FakeHttpMessageHandler(responseMessage);            
            //var httpClient = new HttpClient(messageHandler);
            var api = new ApiCall(mockHttpClient.Object);

            //Act
            var actual = api.GetGameManifest();

            //Assert.IsNotNull(actual.Exception);
        }

        [TestMethod]
        public void PostGameResult_Successful()
        {
            //Arrange
            GameResult gr = new GameResult(81381, 3, new int[]{1,2});            

            //Act
            var actual = _api.PostGameResult(gr).Result;

            //Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void PostGameResult_Failure()
        {
            //Arrange
            GameResult gr = new GameResult(1, 2, null);

            //Act
            var actual = _api.PostGameResult(gr).Result;

            //Assert
            Assert.IsFalse(actual);
        }
    }
}
