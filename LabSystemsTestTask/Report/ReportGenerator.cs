using System;
using System.IO;
using System.Text;
using LabSystemsTestTask.Logger;
using LabSystemsTestTask.Utils;

namespace LabSystemsTestTask.Report
{
    public class ReportGenerator
    {
        private readonly string _username;
        private readonly string _position;
        private readonly string _currentDate;
        private readonly string _email;
        private readonly string _phoneNumber;
        private readonly ILogger _logger;

        public ReportGenerator(string username, string position, string currentDate, string email, string phoneNumber,
            ILogger logger)
        {
            _username = username;
            _position = position;
            _currentDate = currentDate;
            _email = email;
            _phoneNumber = phoneNumber;
            _logger = logger;
        }

        private string GetReportTemplate()
        {
            var pathReportTxt = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory)) +
                                "Resources/report.txt";

            try
            {
                return File.ReadAllText(pathReportTxt);
            }
            catch (Exception e)
            {
                _logger.FailedToOpenReportTemplate(e);
                UtilsStopExecution.WithError();
                return null;
            }
        }

        public string GenerateParameterizedReportAsString()
        {
            var reportTemplate = GetReportTemplate();
            var reportBuilder = new StringBuilder(reportTemplate);

            if (!reportTemplate.Contains("*userName") || !reportTemplate.Contains("*position") ||
                !reportTemplate.Contains("*email") || !reportTemplate.Contains("*phoneNumber"))
            {
                _logger.NecessaryParametersMissing(
                    "Necessary parameters like username, position, email, phone number are missing");
                UtilsStopExecution.WithError();
            }
            
            reportBuilder.Replace("*userName", _username)
                .Replace("*position", _position)
                .Replace("currentDate", _currentDate)
                .Replace("*email", _email)
                .Replace("*phoneNumber", _phoneNumber)
                .Replace("{", "")
                .Replace("}", "");

            return reportBuilder.ToString();
        }

        public void GenerateParameterizedReportAsFile(string data)
        {
            try
            {
                UtilsCreateReport.Init(data, _logger);
            }
            catch (Exception e)
            {
                _logger.FailedToCallFunction(e);
                UtilsStopExecution.WithError();
            }
        }
    }
}