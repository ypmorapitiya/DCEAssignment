using MontyHallAssignment_BL.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MontyHallAssignment_BL.Services
{
    public class MontyHallService : IMontyHallService
    {
        public SimulationResponse SimulateGames(SimulationRQ simulationRQ)
        {
            SimulationResponse simulationResponse = new SimulationResponse();

            try
            {
                int numSimulations = simulationRQ.numberOfSimulations;
                bool switchDoors = simulationRQ.isSwitch;
                int wins = 0, losses = 0;
                Dictionary<int, double> winProbability = new Dictionary<int, double>() { { 0, 0 } };
                Random random = new Random();
                bool isNumberofSimulationMoreThan20 = numSimulations >= 20;
                for (int i = 1; i <= numSimulations; i++)
                {
                    double prob = 0;
                    int carDoor = random.Next(3);
                    int playerChoice = random.Next(3);

                    int revealedDoor;
                    do
                    {
                        revealedDoor = random.Next(3);
                    } while (revealedDoor == carDoor || revealedDoor == playerChoice);

                    int finalChoice = switchDoors ? 3 - playerChoice - revealedDoor : playerChoice;

                    if (finalChoice == carDoor)
                        wins++;


                    if (isNumberofSimulationMoreThan20)
                    {
                        if (i % 5 == 0)
                        {
                            prob = (double)wins / i;
                            winProbability.Add(i, prob);
                        }
                        if (i == numSimulations && i % 5 != 0)
                        {

                            prob = (double)wins / i;
                            winProbability.Add(i, prob);
                        }
                    }
                    else
                    {
                        prob = (double)wins / i;
                        winProbability.Add(i, prob);
                    }


                }
                simulationResponse.probabilities = winProbability;
                simulationResponse.averageWinProbability = winProbability.Values.Average();
                simulationResponse.isSucess = true;
            }
            catch (Exception ex)
            {
                simulationResponse.errorMessage = ex.Message;
                simulationResponse.isSucess = false;
            }

            return simulationResponse;
        }
    }
}
