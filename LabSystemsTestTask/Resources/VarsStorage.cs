using System.IO;

namespace LabSystemsTestTask.Resources
{
    public static class VarsStorage
    {
        public static readonly string GeneratedReportPath = Path.GetFullPath("../.." + "\\Output\\generatedReport.txt");
        public static readonly string GeneratedLogs = Path.GetFullPath("../.." + "\\Output\\errorLogs.txt");
    }
}