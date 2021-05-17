using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeSolverQLearning.Models
{
    public class Area
    {
        public int pastArea { get; set; }
        public int nextArea { get; set; }
        public int pastAreaRotate { get; set; }
        public double pastAreaQScore { get; set; }
    }
}
