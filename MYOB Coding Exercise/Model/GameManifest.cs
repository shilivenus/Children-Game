using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYOB_Coding_Exercise.Model
{
    [Serializable]
    [JsonObject]
    public class GameManifest
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("children_count")]
        public int ChildrenCount { get; set; }

        [JsonProperty("eliminate_each")]
        public int EliminateEach { get; set; }

        public GameManifest(int id, int childrenCount, int eliminateEach)
        {
            this.Id = id;
            this.ChildrenCount = childrenCount;
            this.EliminateEach = eliminateEach;
        }
    }
}
