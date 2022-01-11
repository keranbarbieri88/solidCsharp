using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using solidCsharp.Service;


namespace solidCsharp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly ProductReportService productReportService;
        public ProductController(ILogger<ProductController> logger, ProductReportService productReportService)
        {
            _logger = logger;
            this.productReportService = productReportService;
        }
        [HttpGet]
        [Authorize]
        public ActionResult<string> RelatorioProdutos([FromQuery] ReportType reportType)
        {
            // Retorna os dados
            return productReportService.GenerateReport(reportType);
        }

    }
}
