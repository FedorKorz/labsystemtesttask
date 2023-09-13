using System.IO;
using AventStack.ExtentReports;
using LabSystemsTestTask.Logger;
using LabSystemsTestTask.Report;
using LabSystemsTestTask.Resources;
using LabSystemsTestTask.TestResults;
using LabSystemsTestTask.Utils;
using NUnit.Framework;

namespace LabSystemsTestTask
{
    [TestFixture]
    public class Tests
    {
        private string _userName;
        private string _position;
        private string _email;
        private string _phoneNumber;
        private string _date;
        private ILogger _logger;
        private ExtentTest _test;

        [SetUp]
        public void Initialization()
        {
            _userName = UtilsJson.ReadJsonFile("userName", _logger);
            _position = UtilsJson.ReadJsonFile("position", _logger);
            _email = UtilsJson.ReadJsonFile("email", _logger);
            _phoneNumber = UtilsJson.ReadJsonFile("phoneNumber", _logger);
            _date = UtilsDate.GetCurrentDate();
            _logger = new LoggerManager();
            
        }

        [Test]
        public void TestPreconditions()
        {
            _test = ExtentReportManager.CreateTest(TestContext.CurrentContext.Test.Name);
            _test.Info("Starting TestPreconditions");
            Assert.That(_userName, Is.Not.Null, "Applicant's userName hasn't specified");
            Assert.That(_position, Is.Not.Null, "Applicant's position hasn't specified");
            Assert.That(_email, Is.Not.Null, "Applicant's email hasn't specified");
            Assert.That(_phoneNumber, Is.Not.Null, "Applicant's phoneNumber hasn't specified");
            _test.Pass("TestPreconditions successfully finished");
        }

        [Test]
        public void GenerateReport()
        {
            _test = ExtentReportManager.CreateTest(TestContext.CurrentContext.Test.Name);
            _test.Info("Starting GenerateReport");
            var reportGenerator = new ReportGenerator(_userName, _position, _date, _email, _phoneNumber, _logger);
            var generatedReport = reportGenerator.GenerateParameterizedReportAsString();
            reportGenerator.GenerateParameterizedReportAsFile(generatedReport);
            _test.Pass("GenerateReport successfully finished");
        }

        [Test]
        public void CheckGeneratedReport()
        {
            _test = ExtentReportManager.CreateTest(TestContext.CurrentContext.Test.Name);
            Assert.That(File.Exists(VarsStorage.GeneratedReportPath), Is.True, "Report has not created");
            Assert.AreNotEqual(0, VarsStorage.GeneratedReportPath.Length, "Report is empty");
            Assert.AreNotEqual(0, VarsStorage.GeneratedLogs, "Logs are created");
            _test.Pass("CheckGeneratedReport successfully finished");
        }

        [TearDown]
        public void CreatingReport()
        {
            ExtentReportManager.GetExtent().Flush();
        }
    }
}