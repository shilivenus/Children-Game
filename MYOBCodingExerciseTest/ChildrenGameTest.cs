using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MYOB_Coding_Exercise;
using MYOB_Coding_Exercise.Model;

namespace MYOBCodingExerciseTest
{
    [TestClass]
    public class ChildrenGameTest
    {
        IEliminator eliminator = new ChildrenGame();

        [TestMethod]
        public void GetOrderOfRemovals_With_4_Emlements()
        {
            //Arrange
            var childrenCount = 4;
            var eliminateEach = 2;

            var expected = new int[4] {1, 3, 2, 0};

            //Act
            var actual = eliminator.GetOrderOfRemovals(childrenCount, eliminateEach);

            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetOrderOfRemovals_With_10_Emlements()
        {
            //Arrange
            var childrenCount = 10;
            var eliminateEach = 3;

            var expected = new int[10] { 2, 5, 8, 1, 6, 0, 7, 4, 9, 3 };

            //Act
            var actual = eliminator.GetOrderOfRemovals(childrenCount, eliminateEach);

            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetOrderOfRemovals_With_10_Emlements_And_12_EliminateEach()
        {
            //Arrange
            var childrenCount = 10;
            var eliminateEach = 12;

            var expected = new int[10] { 1, 4, 8, 5, 3, 7, 6, 2, 0, 9 };

            //Act
            var actual = eliminator.GetOrderOfRemovals(childrenCount, eliminateEach);

            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetOrderOfRemovals_With_One_Element()
        {
            //Arrange
            var childrenCount = 1;
            var eliminateEach = 2;

            var expected = new int[1] {0};

            //Act
            var actual = eliminator.GetOrderOfRemovals(childrenCount, eliminateEach);

            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetOrderOfRemovals_With_Zero_Element()
        {
            //Arrange
            var childrenCount = 0;
            var eliminateEach = 2;            

            //Act
            var actual = eliminator.GetOrderOfRemovals(childrenCount, eliminateEach);

            //Assert
            Assert.IsNull(actual);
        }

        [TestMethod]
        public void GetOrderOfRemovals_With_Negative_Element()
        {
            //Arrange
            var childrenCount = -1;
            var eliminateEach = 2;

            //Act
            var actual = eliminator.GetOrderOfRemovals(childrenCount, eliminateEach);

            //Assert
            Assert.IsNull(actual);
        }

        [TestMethod]
        public void GetOrderOfRemovals_With_Negative_EliminateEach()
        {
            //Arrange
            var childrenCount = 2;
            var eliminateEach = -1;

            //Act
            var actual = eliminator.GetOrderOfRemovals(childrenCount, eliminateEach);

            //Assert
            Assert.IsNull(actual);
        }

        [TestMethod]
        public void GetOrderOfRemovals_With_Zero_EliminateEach()
        {
            //Arrange
            var childrenCount = 2;
            var eliminateEach = 0;

            //Act
            var actual = eliminator.GetOrderOfRemovals(childrenCount, eliminateEach);

            //Assert
            Assert.IsNull(actual);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Play_With_Null_GameManifest()
        {
            //Act
            var actual = eliminator.Play(null);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Play_With_Negative_Element()
        {
            //Arrange
            GameManifest gameManifest = new GameManifest(1, -1, 2);

            //Act
            var actual = eliminator.Play(gameManifest);
        }

        [TestMethod]
        public void Play_With_4_Emlements_Successful()
        {
            //Arrange
            GameManifest gameManifest = new GameManifest(1, 4, 2);

            var expected = new GameResult(1, 0, new int[4] { 1, 3, 2, 0 });

            //Act
            var actual = eliminator.Play(gameManifest);

            //Assert
            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.LastChild, actual.LastChild);
            CollectionAssert.AreEqual(expected.OrderOfElimination, actual.OrderOfElimination);
        }
    }
}
