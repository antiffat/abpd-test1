using System.Data.SqlClient;
using ABPD_Test_1.DTOs;
using ABPD_Test_1.Interfaces;

namespace ABPD_Test_1.Repositories;

public class VideoCardRepository : IVideoCardRepository
{
    private readonly string _connectionString;

    public VideoCardRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
        if (string.IsNullOrEmpty(_connectionString))
        {
            throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        }
    }
    
    public int CreateVideoCard(VideoCardCreateDto videoCardDto)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();

            var addVideoCardQuery = @"
                INSERT INTO Videocard (Name, Frequency, Memory)
                OUTPUT INSERTED.Id
                VALUES (@Name, @Frequency, @Memory)";

            using (var command = new SqlCommand(addVideoCardQuery, connection))
            {
                command.Parameters.AddWithValue("@Name", videoCardDto.Name);
                command.Parameters.AddWithValue("@Frequency", videoCardDto.Frequency);
                command.Parameters.AddWithValue("@Memory", videoCardDto.Memory);
                
                int newId = (int)command.ExecuteScalar();
                return newId;
            }
        }
    }
}