using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MYOB_Coding_Exercise;
using MYOB_Coding_Exercise.Interface;
using System.Threading.Tasks;
using MYOB_Coding_Exercise.Model;

namespace MYOBCodingExerciseTest
{
    /// <summary>
    /// Summary description for GameControllerTest
    /// </summary>
    [TestClass]
    public class GameControllerTest
    {
       
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Fail_To_Get_Order_Of_Removals()
        {
            //Arrange
            var mockChildrenGame = new Mock<IEliminator>();
            var mockApiCall = new Mock<IApiCall>();

            mockChildrenGame.Setup(x => x.GetOrderOfRemovals(It.IsAny<int>(), It.IsAny<int>())).Returns(()=>null);
            mockApiCall.Setup(x => x.GetGameManifest()).Returns(Task.FromResult<GameManifest>(new GameManifest(1, 2, 3)));

            GameController GameController = new GameController(mockApiCall.Object, mockChildrenGame.Object);

            //Act
            GameController.Execute();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Fail_To_Post_Game_Result()
        {
            //Arrange
            var mockChildrenGame = new Mock<IEliminator>();
            var mockApiCall = new Mock<IApiCall>();
            var mockArray = new int[] { 1, 2 };

            mockChildrenGame.Setup(x => x.GetOrderOfRemovals(It.IsAny<int>(), It.IsAny<int>())).Returns(mockArray);
            mockApiCall.Setup(x => x.GetGameManifest()).Returns(Task.FromResult(new GameManifest(1, 2, 3)));
            mockApiCall.Setup(x => x.PostGameResult(new GameResult(1, 2, mockArray))).Returns(Task.FromResult(false));

            GameController GameController = new GameController(mockApiCall.Object, mockChildrenGame.Object);

            //Act
            GameController.Execute();
        }
    }
}
