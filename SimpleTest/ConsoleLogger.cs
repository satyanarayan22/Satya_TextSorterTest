namespace SimpleTest
{
    /// <summary>
    /// Console Logger 
    /// </summary>
    internal class ConsoleLogger : ILogger
    {
        public void Log(string stuff)
        {
            Console.WriteLine(stuff);
        }
    }
}