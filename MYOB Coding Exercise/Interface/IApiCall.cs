using MYOB_Coding_Exercise.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYOB_Coding_Exercise
{
    public interface IApiCall
    {
        Task<GameManifest> GetGameManifest();

        Task<bool> PostGameResult(GameResult result);
    }
}
