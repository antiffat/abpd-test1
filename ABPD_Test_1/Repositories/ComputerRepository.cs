using System.Data.SqlClient;
using ABPD_Test_1.DTOs;
using ABPD_Test_1.Interfaces;

namespace ABPD_Test_1.Repositories;

public class ComputerRepository : IComputerRepository
{
    public readonly string _connectionString;

    public ComputerRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
        if (string.IsNullOrEmpty(_connectionString))
        {
            throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        }
    }

    public int CreateComputer(ComputerCreteDto computerDto)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();

            var addComputerQuery = @"
                INSERT INTO Computer (VideocardName, CpuName, ComputerName)
                OUTPUT INSERTED.Id
                VALUES (@VideocardName, @CpuName, @ComputerName)";

            using (var command = new SqlCommand(addComputerQuery, connection))
            {
                command.Parameters.AddWithValue("@VideocardName", computerDto.VideoCardName);
                command.Parameters.AddWithValue("@CpuName", computerDto.CpuName);
                command.Parameters.AddWithValue("@ComputerName", computerDto.ComputerName);
                
                int newId = (int)command.ExecuteScalar();
                return newId;
            }
        }
    }
    
}