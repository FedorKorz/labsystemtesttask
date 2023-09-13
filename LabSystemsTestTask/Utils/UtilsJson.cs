using System;
using System.IO;
using LabSystemsTestTask.Logger;
using Newtonsoft.Json;

namespace LabSystemsTestTask.Utils
{
    public static class UtilsJson
    {
        private static readonly string PathJson = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory)) +
                                                  "Resources/applicantData.json";

        public static string ReadJsonFile(string key, ILogger logger)
        {
            try
            {
                dynamic file = JsonConvert.DeserializeObject(File.ReadAllText(PathJson));
                return Convert.ToString(file[$"{key}"]);
            }
            catch (Exception e)
            {
                logger.FailedToReadJson(e);
                UtilsStopExecution.WithError();
                return string.Empty;
            }
        }
    }
}