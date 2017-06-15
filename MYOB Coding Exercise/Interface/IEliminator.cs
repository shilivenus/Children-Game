using MYOB_Coding_Exercise.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYOB_Coding_Exercise
{
    public interface IEliminator
    {
        GameResult Play(GameManifest gameManifest);
        int[] GetOrderOfRemovals(int childrenCount, int eliminateEach);
    }
}
