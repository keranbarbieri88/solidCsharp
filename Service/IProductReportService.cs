using solidCsharp.Service.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace solidCsharp.Service
{
    public interface IProductReportService
    {
        public string GenerateReport(IReportGenerator generator);

    }
}
