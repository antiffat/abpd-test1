using ABPD_Test_1.DTOs;

namespace ABPD_Test_1.Interfaces;

public interface IVideoCardRepository
{
    int CreateVideoCard(VideoCardCreateDto videoCardDto);
}