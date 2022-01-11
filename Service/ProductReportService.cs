using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using solidCsharp.Repository;

namespace solidCsharp.Service
{
    public class ProductReportService
    {
		private ProductRepository repository;
		public ProductReportService(ProductRepository repository)
		{
			this.repository = repository;
		}

		public string GenerateReport(ReportType type)
		{
			var products = this.repository.ListAll();
			if (type == ReportType.CSV)
			{
				string report = "ID;Name;Price\r\n";
				foreach (var product in products)
				{
					report += product.Id + ";" + product.Name + ";" + product.Price + "\r\n";
				}
				return report;
			}
			else if (type == ReportType.HTML)
			{
				string report = "<html><body><table>\r\n<th><td>ID</td><td>Name</td><td>Price</td></th>\r\n";
				foreach (var product in products)
				{
					report += "<tr><td>" + product.Id + "</td><td>" + product.Name + "</td><td>" + product.Price + "</td></tr>\r\n";
				}
				report += "</table></body><html>";
				return report;
			}
			throw new Exception("Tipo de relatório inválido!");
		}
	}
}
