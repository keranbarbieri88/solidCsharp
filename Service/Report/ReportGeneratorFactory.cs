
namespace solidCsharp.Service.Report
{
	public class ReportGeneratorFactory
    {
		public static IReportGenerator GetGenerator(ReportType reportType)
		{
			switch (reportType)
			{
				case ReportType.CSV:
					return new CsvReportGenerator();
				case ReportType.HTML:
				default:
					return new HtmlReportGenerator();
			}
		}
	}
}
