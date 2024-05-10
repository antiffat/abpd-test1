using ABPD_Test_1.DTOs;

namespace ABPD_Test_1.Interfaces;

public interface ICpuRepository
{
    int CreateCpu(CpuCreateDto cpuDto);
}