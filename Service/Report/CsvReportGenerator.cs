using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace solidCsharp.Service.Report
{
    public class CsvReportGenerator : IReportGenerator
	{
		private string report;

		public void StartReport()
		{
			report = "";
		}

		public void StartHeaders()
		{

		}
		public void AddHeader(string value)
		{
			report += value + ";";
		}

		public void FinishHeaders()
		{
			report = report.Substring(0, report.Length - 1);
			report += "\r\n";
		}
		public void StartLine()
		{

		}

		public void AddColumn(string value)
		{
			report += value + ";";
		}

		public void FinishLine()
		{
			report = report.Substring(0, report.Length - 1);
			report += "\r\n";
		}
		public string FinishReport()
		{
			return report;
		}
	}
}
