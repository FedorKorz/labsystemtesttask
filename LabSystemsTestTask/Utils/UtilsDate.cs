using System;

namespace LabSystemsTestTask.Utils
{
    public static class UtilsDate
    {
        public static string GetCurrentDate()
        {
            return DateTime.Now.ToString("dd-MM-yyyy");
        }
    }
}