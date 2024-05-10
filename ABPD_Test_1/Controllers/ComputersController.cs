using ABPD_Test_1.DTOs;
using ABPD_Test_1.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ABPD_Test_1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ComputersController : ControllerBase
{
    private readonly IComputerRepository _computerRepository;

    public ComputersController(IComputerRepository computerRepository)
    {
        _computerRepository = computerRepository;
    }

    [HttpPost]
    public IActionResult CreateComputer([FromBody] ComputerCreteDto computerDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            int newComputerId = _computerRepository.CreateComputer(computerDto);
            return CreatedAtAction(nameof(CreateComputer), new { id = newComputerId }, computerDto);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "An error occurred while creating the Computer. Please try again.");
        }
    }
}