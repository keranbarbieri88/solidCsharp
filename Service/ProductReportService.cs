using solidCsharp.Repository;
using solidCsharp.Service.Report;

namespace solidCsharp.Service
{
    public class ProductReportService : IProductReportService
	{
		private IProductRepository repository;
		public ProductReportService(IProductRepository repository)
		{
			this.repository = repository;
		}

		public string GenerateReport(IReportGenerator generator)
		{
			var products = this.repository.ListAll();

			generator.StartReport();
			generator.StartHeaders();
			generator.AddHeader("ID");
			generator.AddHeader("Name");
			generator.AddHeader("Price");
			generator.FinishHeaders();
			foreach (var product in products)
			{
				generator.StartLine();
				generator.AddHeader(product.Id);
				generator.AddHeader(product.Name);
				generator.AddHeader(product.Price + "");
				generator.FinishLine();
			}
			return generator.FinishReport();
		}
	}
}
