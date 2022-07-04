namespace BlazorWeb.Helper
{
    public static class ValidationError
    {
        public static string DicToString(Dictionary<string, string[]> errorsDic)
        {
            string error = String.Empty;
            foreach (var key in errorsDic.Keys)
            {
                foreach (var value in errorsDic[key])
                {
                    error += value + "</br>";
                }
                error += "</br>";
            }
            return error;
        }
    }
}
