using ABPD_Test_1.DTOs;
using ABPD_Test_1.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ABPD_Test_1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VideoCardsController : ControllerBase
{
    private readonly IVideoCardRepository _videoCardRepository;

    public VideoCardsController(IVideoCardRepository videoCardRepository)
    {
        _videoCardRepository = videoCardRepository;
    }

    [HttpPost]
    public IActionResult CreateVideoCard([FromBody] VideoCardCreateDto videoCardDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            int newVideoCardId = _videoCardRepository.CreateVideoCard(videoCardDto);
            return CreatedAtAction(nameof(CreateVideoCard), new { id = newVideoCardId }, videoCardDto);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "An error occurred while creating the Video Card. Please try again.");
        }
    }
}