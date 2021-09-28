using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rover.Models;

namespace Rover.Tests
{
    [TestClass]
    public class RoverTests
    {
        // Start   Instructions     End      Scuffs
        // 0/2/E   FLFRFFFRFFRR     4/1/N    0
        // 4/4/S   LFLLFFLFFFRFF    0/1/W    1
        // 2/2/W   FLFLFLFRFRFRFRF  2/2/N    0
        // 1/3/N   FFLFFLFFFFF      0/0/S    3

        private readonly string scenario1 = "FLFRFFFRFFRR";
        private readonly string scenario2 = "LFLLFFLFFFRFF";
        private readonly string scenario3 = "FLFLFLFRFRFRFRF";
        private readonly string scenario4 = "FFLFFLFFFFF";

        [TestMethod]
        public void TestScenario1()
        {
            var start = new Placement(0, 2, Enums.Cardinal.E);
            var scenario = new Scenario { Start = start, Instructions = scenario1 };
            var expectedEnd = new Placement(4, 1, Enums.Cardinal.N);
            var expectedEndScuffCount = 0;

            var sut = Walkabout.Go(scenario);

            AssertResult(expectedEnd, expectedEndScuffCount, sut);
        }

        [TestMethod]
        public void TestScenario2()
        {
            var start = new Placement (4, 4, Enums.Cardinal.S);
            var scenario = new Scenario { Start = start, Instructions = scenario2 };
            var expectedEnd = new Placement (0, 1, Enums.Cardinal.W);
            var expectedEndScuffCount = 1;

            var sut = Walkabout.Go(scenario);

            AssertResult(expectedEnd, expectedEndScuffCount, sut);
        }

        [TestMethod]
        public void TestScenario3()
        {
            var start = new Placement (2, 2, Enums.Cardinal.W);
            var scenario = new Scenario { Start = start, Instructions = scenario3 };
            var expectedEnd = new Placement (2, 2, Enums.Cardinal.N);
            var expectedEndScuffCount = 0;

            var sut = Walkabout.Go(scenario);

            AssertResult(expectedEnd, expectedEndScuffCount, sut);
        }

        [TestMethod]
        public void TestScenario4()
        {
            var start = new Placement (1, 3, Enums.Cardinal.N);
            var scenario = new Scenario { Start = start, Instructions = scenario4 };
            var expectedEnd = new Placement (0, 0, Enums.Cardinal.S);
            var expectedEndScuffCount = 3;

            var sut = Walkabout.Go(scenario);

            AssertResult(expectedEnd, expectedEndScuffCount, sut);
        }

        private static void AssertResult(Placement expectedEnd, int expectedScuffCount, Crater sut)
        {
            Assert.AreEqual(expectedEnd.PositionX, sut.Current.PositionX);
            Assert.AreEqual(expectedEnd.PositionY, sut.Current.PositionY);
            Assert.AreEqual(expectedEnd.Direction, sut.Current.Direction);
            Assert.AreEqual(expectedScuffCount, sut.Scuffs);
        }
    }
}
