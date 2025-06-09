using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    [Serializable]
    public class Puzzle
    {
        public string Description { get; set; }
        private string Solution { get; set; }
        public Item Reward { get; set; }

        public Puzzle() { }

        public Puzzle(string description, string solution, Item reward = null)
        {
            Description = description;
            Solution = solution;
            Reward = reward;
        }

        public bool CheckSolution(string solution)
        {
            return solution.Equals(Solution, StringComparison.OrdinalIgnoreCase);
        }
    }
}
