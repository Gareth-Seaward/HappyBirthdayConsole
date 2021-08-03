using System;

namespace HappyBirthday.App.Facades
{
    public class ConsoleFacade : IConsoleFacade
    {
        public void Write(string value)
        {
            Console.Write(value);
        }

        public void WriteLine(string value)
        {
            Console.WriteLine(value);
        }
    }
}
