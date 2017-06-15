using MYOB_Coding_Exercise.Interface;
using MYOB_Coding_Exercise.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYOB_Coding_Exercise
{
    public class GameController : IExecute
    {
        private readonly IApiCall _apiCall;
        private readonly IEliminator _eliminator;

        public GameController(IApiCall apiCall, IEliminator eliminator)
        {
            _apiCall = apiCall;
            _eliminator = eliminator;
        }

        /// <summary>
        /// Executing application by calling api, processing it, 
        /// and posting result back.
        /// </summary>
        public void Execute()
        {
            try
            {
                var gs = _apiCall.GetGameManifest().Result;

                var gr = _eliminator.Play(gs);
                
                bool isSuccessed = _apiCall.PostGameResult(gr).Result;
                if (!isSuccessed)
                    throw new Exception("fail to post result back");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}
