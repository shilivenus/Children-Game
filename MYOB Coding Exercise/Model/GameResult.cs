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
    public class GameResult
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("last_child")]
        public int LastChild { get; set; }

        [JsonProperty("order_of_elimination")]
        public int[] OrderOfElimination { get; set; }

        public GameResult(int id, int lastChild, int[] orderOfElimination)
        {
            this.Id = id;
            this.LastChild = lastChild;
            this.OrderOfElimination = orderOfElimination;
        }
    }
}
