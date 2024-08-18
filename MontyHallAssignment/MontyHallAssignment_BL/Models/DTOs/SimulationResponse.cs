using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MontyHallAssignment_BL.Models.DTOs
{
    public class SimulationResponse
    {
        public double averageWinProbability {  get; set; }
        public Dictionary<int, double> probabilities { get; set; }

        public bool isSucess { get; set; }
        public string errorMessage { get; set; }
    }
}
