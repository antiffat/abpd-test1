using ABPD_Test_1.DTOs;
using ABPD_Test_1.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ABPD_Test_1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CpusController : ControllerBase
{
    private readonly ICpuRepository _cpuRepository;

    public CpusController(ICpuRepository cpuRepository)
    {
        _cpuRepository = cpuRepository;
    }

    [HttpPost]
    public IActionResult CreateCpu([FromBody] CpuCreateDto cpuDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            int newCpuId = _cpuRepository.CreateCpu(cpuDto);
            return CreatedAtAction(nameof(CreateCpu), new { id = newCpuId }, cpuDto);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "An error occurred while creating the Cpu. Please try again.");
        }
    }
}