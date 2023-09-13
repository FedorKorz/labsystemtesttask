using System;
using System.IO;
using LabSystemsTestTask.Resources;

namespace LabSystemsTestTask.Utils
{
    public static class UtilsCreateLogs
    {
        public static void Init(string data)
        {
            var filePath = VarsStorage.GeneratedLogs;

            try
            {
                using (var sw = new StreamWriter(filePath))
                {
                    sw.WriteLine(data);
                    sw.Close();
                }
            }
            catch (Exception e)
            {
                UtilsStopExecution.WithError();
            }
        }
    }
}