using System;
using System.IO;
using LabSystemsTestTask.Logger;

namespace LabSystemsTestTask.Utils
{
    public static class UtilsCreateReport
    {
        public static void Init(string data, ILogger logger)
        {
            var filePath = Path.GetFullPath("../.." + "\\Output\\generatedReport.txt");

            try
            {
                using (var sw = new StreamWriter(filePath))
                {
                    sw.WriteLine(data);
                    sw.Close();
                    logger.ReportSuccessfullyGenerated();
                }
            }
            catch (Exception ex)
            {
                logger.FailedToCreateReport(ex);
                UtilsStopExecution.WithError();
            }
        }
    }
}