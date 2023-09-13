using System;

namespace LabSystemsTestTask.Utils
{
    public static class UtilsStopExecution
    {
        public static void WithError()
        {
            const int errorCode = 1;
            Environment.Exit(errorCode);
        }
    }
}