using Persistence;

namespace Model
{    
    public class MalomGame : IMalomGame
    {
        #region Private fields
        
        private const int NUMBER_OF_EDGES = 24;
        private IMillDataAccess DataAccess;       
        #endregion

        #region Properties
        public Int32 phaseCounter { get; private set; }
        public Edge<Players>[] GameGraph { get; private set; }
        public Players CurrentPlayer { get; private set; }
        public Int32 NumberOfWhitePieces { get; private set; }
        public Int32 NumberOfBlackPieces { get; private set; }
        public Phases Phase { get; private set; }
        #endregion

        #region Constructor

        public MalomGame(IMillDataAccess dataAccess)
        {
            phaseCounter = 0;
            Phase = Phases.PHASE1;
            NumberOfWhitePieces = 0;
            NumberOfBlackPieces = 0;
            CurrentPlayer = Players.White;
            GameGraph = new Edge<Players>[NUMBER_OF_EDGES];
            DataAccess = dataAccess;
            firstGame();
        }
        #endregion

        #region Private methods
        private void LoadPlayers(Edge<Players>[] players)
        {
            for (int i = 0; i < GameGraph.Length; ++i)
            {
                GameGraph[i].Data = players[i].Data;
            }
        }

        private void CountPieces(Edge<Players>[] players)
        {
            for (int i = 0; i < GameGraph.Length; ++i)
            {
                if (players[i].Data == Players.White) NumberOfWhitePieces++;
                else if (players[i].Data == Players.Black) NumberOfBlackPieces++;
            }
        }

        private List<Int32> possibleSteps(Int32 actual)
        {
            List<Int32>? possibleSteps = new List<Int32>();
            foreach (Int32 i in GameGraph[actual].Neighbours!)
            {
                if (GameGraph[i].Data == Players.NoPlayer)
                {
                    possibleSteps.Add(i);
                }
            }
            return possibleSteps;
        }

        private void firstGame()
        {
           for(int i = 0; i < NUMBER_OF_EDGES; ++i)
            {
                GameGraph[i] = new Edge<Players>(Players.NoPlayer);
                if ( i % 8 == 0) 
                { 
                    GameGraph[i].Neighbours?.Add(i + 7);
                    GameGraph[i].Neighbours?.Add(i + 1);
                }
                else if (i % 8 == 7)
                {
                    GameGraph[i].Neighbours?.Add(i - 1);
                    GameGraph[i].Neighbours?.Add(i - 7);
                } else
                {
                    GameGraph[i].Neighbours?.Add(i - 1);
                    GameGraph[i].Neighbours?.Add(i + 1);
                }
            }
           for (int i = NUMBER_OF_EDGES - 1; i > NUMBER_OF_EDGES / 3 - 1; i -= 2)
            {
                GameGraph[i].Neighbours?.Add(i - 8);
            }
           for (int i = 1; i < NUMBER_OF_EDGES * 2 / 3; i += 2)
            {
                GameGraph[i].Neighbours?.Add(i + 8);
            }
        }

        
        private void move(Int32 position, Int32 destination)
        {
            GameGraph[position].Data = Players.NoPlayer;
            GameGraph[destination].Data = CurrentPlayer;
        }

        private Boolean CheckMill(Int32 position)
        {
            if (position % 2 == 0)
            {
                if (position % 8 == 0)
                    return CheckOwnCircleMill(position + 7) || CheckOwnCircleMill(position + 1);
                else
                    return CheckOwnCircleMill(position - 1) || CheckOwnCircleMill(position + 1);
            }
            else
            {
                return CheckOwnCircleMill(position) || CheckCrossCircleMill((position % 8) + 8);
            }
        }

        private Boolean CheckOwnCircleMill(Int32 position)
        {
            return GameGraph[position].Data == GameGraph[GameGraph[position].Neighbours![0]].Data &&
                   GameGraph[position].Data == GameGraph[GameGraph[position].Neighbours![1]].Data;
        }

        private Boolean CheckCrossCircleMill(Int32 position)
        {
            return GameGraph[position].Data == GameGraph[GameGraph[position].Neighbours![2]].Data &&
                   GameGraph[position].Data == GameGraph[GameGraph[position].Neighbours![3]].Data;
        }

        private Boolean CheckGameOver()
        {
            return NumberOfBlackPieces < 3 || NumberOfWhitePieces < 3;
        }
        #endregion

        #region Public methods
        public void resetGame()
        {
            for (int i = 0; i < NUMBER_OF_EDGES; ++i)
            {
                GameGraph[i].Data = Players.NoPlayer;
            }
            CurrentPlayer = Players.White;
            phaseCounter = 0;
            Phase = Phases.PHASE1;
            NumberOfWhitePieces = 0;
            NumberOfBlackPieces = 0;
            OnTableChanged();
        }

        public void stepGamePhase1(Int32 destination)
        {
            if (GameGraph[destination].Data == Players.NoPlayer)
            {
                GameGraph[destination].Data = CurrentPlayer;
                if (CurrentPlayer == Players.White) NumberOfWhitePieces++;
                else NumberOfBlackPieces++;
                ++phaseCounter;
                if (CheckMill(destination))
                {
                    OnMill();
                    Phase = Phases.REMOVE;
                }
                else
                {
                    Phase = phaseCounter > 17 ? Phases.PHASE2 : Phases.PHASE1;
                    CurrentPlayer = CurrentPlayer == Players.White ? Players.Black : Players.White;
                }
                OnTableChanged();
            }
        }

        public void stepGamePhase2(Int32 position, Int32 destination)
        {
            if (GameGraph[position].Data == CurrentPlayer && possibleSteps(position).Contains(destination))
            {
                move(position, destination);
                if (CheckMill(destination))
                {
                    Phase = Phases.REMOVE;
                    OnMill();
                }
                else
                {
                    CurrentPlayer = CurrentPlayer == Players.White ? Players.Black : Players.White;
                }
            }
            OnTableChanged();
        }

        public void PassTurn()
        {
            if (Phase == Phases.PHASE2)
            {
                CurrentPlayer = CurrentPlayer == Players.White ? Players.Black : Players.White;
                OnTableChanged();
            }
        }

        public void RemovePiece(Int32 position)
        {
            if (!CheckMill(position) && CurrentPlayer != GameGraph[position].Data)
            {
                GameGraph[position].Data = Players.NoPlayer;
                if (CurrentPlayer == Players.Black) NumberOfWhitePieces--;
                else NumberOfBlackPieces--;
                Phase = phaseCounter < 18 ? Phases.PHASE1 : Phases.PHASE2;
                CurrentPlayer = CurrentPlayer == Players.White ? Players.Black : Players.White;
                OnTableChanged();
                if (Phase == Phases.PHASE2 && CheckGameOver())
                {
                    OnGameOver();
                    resetGame();
                    OnTableChanged();
                }
            }
        }

        public void SaveGame(string path)
        {
            DataAccess.SaveGame(path, new LoadingDataStructure(GameGraph, Phase, CurrentPlayer, phaseCounter));
        }

        public void LoadGame(string path)
        {
            resetGame();
            LoadingDataStructure standing = DataAccess.LoadGame(path);
            LoadPlayers(standing.GameGraph!);
            CountPieces(standing.GameGraph!);
            Phase = standing.Phase;
            CurrentPlayer = standing.CurrentPlayer;
            phaseCounter = standing.PhaseCounter;
            OnTableChanged();
        }

        #endregion

        #region Events

        public event EventHandler? Mill;

        public event EventHandler? TableChanged;

        public event EventHandler? GameOver;

        #endregion

        #region Event triggers

        private void OnMill()
        {
            if (Mill != null)
            {
                Mill(this, EventArgs.Empty);
            }
        }

        private void OnTableChanged() 
        { 
            if (TableChanged != null)
            {
                TableChanged(this, EventArgs.Empty);
            }
        }

        private void OnGameOver()
        {
            if (GameOver != null)
            {
                GameOver(this, EventArgs.Empty);
            }
        }

        #endregion
    }
}