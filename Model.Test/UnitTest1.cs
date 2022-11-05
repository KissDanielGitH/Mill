using Moq;
using Model;
using Persistence;

namespace Model.Test
{
    [TestFixture]
    public class Tests
    {
        Mock<IMillDataAccess> mock = null!;
        MalomGame Game = null!;

        [SetUp]
        public void Setup()
        {
            mock = new Mock<IMillDataAccess>();
            Game = new MalomGame(mock.Object);
        }

        [Test]
        public void TestConstructor()
        {
            Assert.That(Game.phaseCounter, Is.EqualTo(0));
            Assert.That(Game.Phase, Is.EqualTo(Phases.PHASE1));
            Assert.That(Game.NumberOfWhitePieces, Is.EqualTo(0));
            Assert.That(Game.NumberOfBlackPieces, Is.EqualTo(0));
            Assert.That(Game.CurrentPlayer, Is.EqualTo(Players.White));
            Assert.That(Game.GameGraph.Length, Is.EqualTo(24));
            for (int i = 0; i < Game.GameGraph.Length; i++)
            {
                Assert.That(Game.GameGraph[i].Data, Is.EqualTo(Players.NoPlayer));
            }
        }

        [Test]
        public void TestResetGame()
        {
            for (int i = 0; i < 17; ++i)
            {
                Game.stepGamePhase1(i);
            }
            Game.resetGame();
            Assert.That(Game.phaseCounter, Is.EqualTo(0));
            Assert.That(Game.Phase, Is.EqualTo(Phases.PHASE1));
            Assert.That(Game.NumberOfWhitePieces, Is.EqualTo(0));
            Assert.That(Game.NumberOfBlackPieces, Is.EqualTo(0));
            Assert.That(Game.CurrentPlayer, Is.EqualTo(Players.White));
            for (int i = 0; i < Game.GameGraph.Length; i++)
            {
                Assert.That(Game.GameGraph[i].Data, Is.EqualTo(Players.NoPlayer));
            }
        }

        [Test]
        public void TestStepGamePhase1()
        {
            for (int i = 0; i < 8; ++i)
            {
                Game.stepGamePhase1(i);
            }
            for (int i = 0; i < 8; ++i)
            {
                if (i % 2 == 0)
                {
                    Assert.That(Game.GameGraph[i].Data, Is.EqualTo(Players.White));
                }
                else
                {
                    Assert.That(Game.GameGraph[i].Data, Is.EqualTo(Players.Black));
                }
            }
            for (int i = 8; i < 18; ++i)
            {
                Game.stepGamePhase1(i);
            }
            Assert.That(Game.phaseCounter, Is.EqualTo(18));
        }

        [Test]
        public void TestStepGamePhase2()
        {
            for (int i = 0; i < 17; ++i)
            {
                Game.stepGamePhase1(i);
            }
            Game.stepGamePhase1(18);
            Game.stepGamePhase2(16, 23);
            Assert.That(Game.GameGraph[16].Data, Is.EqualTo(Players.NoPlayer));
            Assert.That(Game.GameGraph[23].Data, Is.EqualTo(Players.White));
        }

        [Test]
        public void TestPassTurn()
        {
            for (int i = 0; i < 17; ++i)
            {
                Game.stepGamePhase1(i);
            }
            Game.stepGamePhase1(18);
            Assert.That(Game.CurrentPlayer, Is.EqualTo(Players.White));
            Game.PassTurn();
            Assert.That(Game.CurrentPlayer, Is.EqualTo(Players.Black));
        }

        [Test]
        public void TestRemovePiece()
        {
            Game.GameGraph[0].Data = Players.Black;
            Game.RemovePiece(0);
            Assert.That(Game.GameGraph[0].Data, Is.EqualTo(Players.NoPlayer));

            Game.GameGraph[0].Data = Players.Black;
            Game.GameGraph[1].Data = Players.Black;
            Game.GameGraph[2].Data = Players.Black;
            Game.RemovePiece(0);
            Assert.That(Game.GameGraph[0].Data, Is.EqualTo(Players.Black));
        }
    }
}