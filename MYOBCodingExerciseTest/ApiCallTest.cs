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
using MYOB_Coding_Exercise.Model;

namespace MYOBCodingExerciseTest
{
    [TestClass]
    public class ApiCallTest
    {
        [TestMethod]
        public void GetGameManifest_Successful()
        {
            //Arrange
            var api = new ApiCall(new HttpClient());

            //Act
            var actual = api.GetGameManifest().Result;

            //Assert
            Assert.IsInstanceOfType(actual.Id, typeof(int));
            Assert.IsInstanceOfType(actual.ChildrenCount, typeof(int));
            Assert.IsInstanceOfType(actual.EliminateEach, typeof(int));
        }

        [TestMethod]        
        public void GetGameManifest_Failure()
        {
            //Arrange
            var responseMessage = new HttpResponseMessage(HttpStatusCode.BadRequest);
            var messageHandler = new FakeHttpMessageHandler(responseMessage);            
            var httpClient = new HttpClient(messageHandler);
            var api = new ApiCall(httpClient);

            //Act
            var actual = api.GetGameManifest();

            Assert.IsNotNull(actual.Exception);
        }

        [TestMethod]
        public void PostGameResult_Successful()
        {
            //Arrange
            GameResult gr = new GameResult(81381, 3, new int[]{1,2});
            var api = new ApiCall(new HttpClient());

            //Act
            var actual = api.PostGameResult(gr).Result;

            //Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void PostGameResult_Failure()
        {
            //Arrange
            GameResult gr = new GameResult(1, 2, null);
            var api = new ApiCall(new HttpClient());

            //Act
            var actual = api.PostGameResult(gr).Result;

            //Assert
            Assert.IsFalse(actual);
        }
    }
}
