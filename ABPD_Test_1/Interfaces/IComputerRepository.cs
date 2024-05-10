using ABPD_Test_1.DTOs;

namespace ABPD_Test_1.Interfaces;

public interface IComputerRepository
{
    int CreateComputer(ComputerCreteDto computerDto);
    bool DeleteComputer(int computerId);
}