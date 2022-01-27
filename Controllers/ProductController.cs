using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using solidCsharp.Service;
using solidCsharp.Service.Report;


namespace solidCsharp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductReportService productReportService;
        public ProductController(ILogger<ProductController> logger, IProductReportService productReportService)
        {
            _logger = logger;
            this.productReportService = productReportService;
        }

        [HttpGet]
        [Authorize]
        public ActionResult<string> ReportProducts([FromQuery] ReportType reportType)
        {
            // Retorna os dados
            return productReportService.GenerateReport(ReportGeneratorFactory.GetGenerator(reportType));
        }

    }
}
