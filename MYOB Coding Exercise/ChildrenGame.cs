using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MYOB_Coding_Exercise.Model;

namespace MYOB_Coding_Exercise
{
    public class ChildrenGame: IEliminator
    {        
        /// <summary>
        /// Gets the order of removals array.        
        /// </summary>
        /// <remarks>
        /// This method's complexity is O(N), which is fully depond on 
        /// the two for loop, other statments spend constant time
        /// </remarks>
        /// <returns>The int array contains order of removals</returns>
        /// <param name="childrenCount">Used to specify the total number of children</param>
        /// <param name="eliminateEach">Used to specify the step of each eliminate</param>
        public int[] GetOrderOfRemovals(int childrenCount, int eliminateEach)
        {
            int i, k = 0;

            int start = 0;

            if (childrenCount <= 0 || eliminateEach <= 0)
                return null;

            //result Array is holding the Order of Removals
            int[] result = new int[childrenCount];

            //temp ArrayList holds the inital data
            ArrayList temp = new ArrayList();

            //assign id to each child start from 0  
            for (i = 0; i < childrenCount; i++)
            {
                temp.Add(i);
            }

            //assign removal order to result Array   
            for (i = childrenCount; i > 0; i--)
            {
                start = (start + eliminateEach - 1) % i;
                
                result[k] = (int)temp[start];
                k++;

                temp.RemoveAt(start);                
            }
               
            return result; 
        }

        /// <summary>
        /// Start Game
        /// </summary>
        /// <param name="gameManifest">Used to inital game</param>
        /// <returns>The game result object</returns>
        /// <exception cref="System.Exception">
        /// Thrown when gameManifest is null or remove order which
        /// return from GetOrderOfRemovals method is null
        /// </exception>
        public GameResult Play(GameManifest gameManifest)
        {
            if (gameManifest == null)
                throw new Exception("gameManifest is null");

            var removalOrder = GetOrderOfRemovals(gameManifest.ChildrenCount, gameManifest.EliminateEach);

            if(removalOrder == null)
                throw new Exception(String.Format("children_count {0} or eliminate_each {1} is not valid number", gameManifest.ChildrenCount, gameManifest.EliminateEach));

            return new GameResult(gameManifest.Id, removalOrder.Last(), removalOrder);
        }
    }
}
