using Microsoft.AspNetCore.Mvc;
using MontyHallAssignment_BL.Models.DTOs;
using MontyHallAssignment_BL.Services;
using Newtonsoft.Json;

namespace MontyHallAssignment_WEB.Controllers
{
    public class MontyHallController : Controller
    {
        private readonly IMontyHallService _montyHallService;

        public MontyHallController(IMontyHallService montyHallService)
        {
            _montyHallService = montyHallService;
        }

        [HttpPost("simulate")]
        public async  Task<IActionResult> Simulate([FromBody] SimulationRQ simulationRq)
        {
            //var body = await new StreamReader(Request.Body).ReadToEndAsync();
            //Console.WriteLine($"Raw Body: {body}");

            //var dto = JsonConvert.DeserializeObject<SimulationRQ>(body);

            //// Log the deserialized DTO
            //Console.WriteLine($"NumberOfSimulations: {simulationRq.numberOfSimulations}, IsSwitch: {simulationRq.isSwitchDoors}");
            var result = _montyHallService.SimulateGames(simulationRq);

            if (result.isSucess)
            {
                return Ok(result);
            }
            return BadRequest(new { message="server error" });
            
        }
    }
}
