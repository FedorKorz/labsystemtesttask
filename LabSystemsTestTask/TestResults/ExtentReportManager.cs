namespace LabSystemsTestTask.TestResults
{
    using AventStack.ExtentReports;
    using AventStack.ExtentReports.Reporter;

    public static class ExtentReportManager
    {
        private static ExtentReports _extent;
        private static ExtentTest _test;

        public static ExtentReports GetExtent()
        {
            if (_extent != null) return _extent;
            _extent = new ExtentReports();
            var htmlReporter = new ExtentSparkReporter("ExtentReport.html");
            _extent.AttachReporter(htmlReporter);
            return _extent;
        }

        public static ExtentTest CreateTest(string testName)
        {
            _test = _extent.CreateTest(testName);
            return _test;
        }
    }
}