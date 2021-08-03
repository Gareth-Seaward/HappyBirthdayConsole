using FluentAssertions;
using HappyBirthday.App.Application;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace HappyBirthday.Tests
{
    public class BirthdaySongGeneratorTests
    {
        private readonly BirthdaySongGenerator _sut;

        public BirthdaySongGeneratorTests()
        {
            _sut = new BirthdaySongGenerator();
        }

        [Theory]
        [ClassData(typeof(BirthdayData))]
        public void CreatesBirthdaySongForNameAndGivenHipHipTimes(string name, int hipHipTimes, string[] expected)
        {
            var result = _sut.GetBirthdaySong(name, hipHipTimes);

            result.Should().ContainInOrder(expected);
        }

        [Theory]
        [MemberData(nameof(BirthdayData.DefaultData), MemberType = typeof(BirthdayData))]
        public void CreatesBirthdaySongForNameAndDefauttHipHipTimesIfNoneWasGiven(string name, string[] expected)
        {
            var result = _sut.GetBirthdaySong(name);

            result.Should().ContainInOrder(expected);
        }
    }

    public class BirthdayData : IEnumerable<object[]>
    {
        public static IEnumerable<object[]> DefaultData =>
            new List<object[]>
            {
                new object[] { "Rory", new[] { "Happy birthday to you", "Happy birthday to you", "Happy birthday dear Rory", "Happy birthday to you", "Hip-hip..Hurray", "Hip-hip..Hurray", "Hip-hip..Hurray" } },
                new object[] { "Susan", new[] { "Happy birthday to you", "Happy birthday to you", "Happy birthday dear Susan", "Happy birthday to you", "Hip-hip..Hurray", "Hip-hip..Hurray", "Hip-hip..Hurray" } },
                new object[] { "Jack", new[] { "Happy birthday to you", "Happy birthday to you", "Happy birthday dear Jack", "Happy birthday to you", "Hip-hip..Hurray", "Hip-hip..Hurray", "Hip-hip..Hurray" } }
            };
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "Rory", 0, new[] { "Happy birthday to you", "Happy birthday to you", "Happy birthday dear Rory", "Happy birthday to you" } };
            yield return new object[] { "Susan", 1, new[] { "Happy birthday to you", "Happy birthday to you", "Happy birthday dear Susan", "Happy birthday to you", "Hip-hip..Hurray" } };
            yield return new object[] { "Jack", 4, new[] { "Happy birthday to you", "Happy birthday to you", "Happy birthday dear Jack", "Happy birthday to you", "Hip-hip..Hurray", "Hip-hip..Hurray", "Hip-hip..Hurray", "Hip-hip..Hurray" } };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
