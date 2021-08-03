using System.Collections.Generic;
using System.Linq;

namespace HappyBirthday.App.Application
{
    public class BirthdaySongGenerator : ISongGenerator
    {
        private const string BirthdayRepeatLine = "Happy birthday to you";
        private const string NameLine = "Happy birthday dear {0}";
        private const string HipHipRepeat = "Hip-hip..Hurray";
        private const int LinesInMainVerse = 4;
        private const int LineWithName = 3;

        public IEnumerable<string> GetBirthdaySong(string name, int hipHipTimes = 3)
        {
            return GetMainVerse(name).Concat(GetHipHipCorus(hipHipTimes));
        }


        private IEnumerable<string> GetMainVerse(string name)
        {
            for(int i = 1; i <= LinesInMainVerse; i++)
            {
                if (i % LineWithName == 0)
                { 
                   yield return string.Format(NameLine, name);
                }
                yield return BirthdayRepeatLine;
            }
        }

        private IEnumerable<string> GetHipHipCorus(int hipHipTimes)
        {
            while (hipHipTimes > 0)
            {
                yield return HipHipRepeat;
                hipHipTimes--;
            }
        }

    }
}
