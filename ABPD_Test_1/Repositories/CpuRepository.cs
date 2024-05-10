using System.Data.SqlClient;
using ABPD_Test_1.DTOs;
using ABPD_Test_1.Interfaces;

namespace ABPD_Test_1.Repositories;

public class CpuRepository : ICpuRepository
{
    public readonly string _connectionString;

    public CpuRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
        if (string.IsNullOrEmpty(_connectionString))
        {
            throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        }
    }

    public int CreateCpu(CpuCreateDto cpuDto)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();

            var addCpuQuery = @"
                INSERT INTO CPU (Name, Frequency, Cores)
                OUTPUT INSERTED.Id
                VALUES (@Name, @Frequency, @Cores)";

            using (var command = new SqlCommand(addCpuQuery, connection))
            {
                command.Parameters.AddWithValue("@Name", cpuDto.Name);
                command.Parameters.AddWithValue("@Frequency", cpuDto.Frequency);
                command.Parameters.AddWithValue("@Cores", cpuDto.Cores);
                
                int newId = (int)command.ExecuteScalar();
                return newId;
            }
        }
    }
}