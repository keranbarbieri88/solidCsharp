
namespace solidCsharp.Service.Report
{
    public interface IReportGenerator
    {
		public void StartReport();
		public void StartHeaders();
		public void AddHeader(string valor);
		public void FinishHeaders();
		public void StartLine();
		public void AddColumn(string valor);
		public void FinishLine();
		public string FinishReport();
	}
}
