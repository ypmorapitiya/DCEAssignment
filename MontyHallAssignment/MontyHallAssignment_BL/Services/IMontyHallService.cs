using MontyHallAssignment_BL.Models.DTOs;

namespace MontyHallAssignment_BL.Services
{
    public interface IMontyHallService
    {
        SimulationResponse SimulateGames(SimulationRQ simulationRQ);
    }
}