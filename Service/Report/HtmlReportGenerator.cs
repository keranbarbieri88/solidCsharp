
namespace solidCsharp.Service.Report
{
    public class HtmlReportGenerator : IReportGenerator
	{
		private string report;

		public void StartReport()
		{
			report = "<html><body><table>\r\n";
		}

		public void StartHeaders()
		{
			report += "\t<th>\r\n";
		}
		public void AddHeader(string value)
		{
			report += "\t\t<td>" + value + "</td>\r\n";
		}

		public void FinishHeaders()
		{
			report += "\t</th>\r\n";
		}
		public void StartLine()
		{
			report += "\t<tr>\r\n";
		}

		public void AddColumn(string value)
		{
			report += "\t\t<td>" + value + "</td>\r\n";
		}

		public void FinishLine()
		{
			report += "\t</tr>\r\n";
		}
		public string FinishReport()
		{
			report += "</table></body></html>";
			return report;
		}
	}
}
