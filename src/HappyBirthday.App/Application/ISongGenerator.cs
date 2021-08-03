using System.Collections.Generic;

namespace HappyBirthday.App.Application
{
    public interface ISongGenerator
    {
        IEnumerable<string> GetBirthdaySong(string name, int hipHipTimes = 3);
    }
}
