using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using Persistence;

namespace ViewWPF.ViewModel
{
    public class MillViewModel : ViewModelBase
    {
        #region Fields
        private MalomGame model;
        private int firstPosition;
        private int secondPosition;
        private bool positionSelected;
        private string whitePieces;
        private string blackPieces;
        private string playersTurn;
        private string phaseOfGame;
        #endregion

        #region Commands
        public DelegateCommand PassGame { get; private set; }
        public DelegateCommand NewGameCommand { get; private set; }
        public DelegateCommand SaveGameCommand { get; private set; }
        public DelegateCommand LoadGameCommand { get; private set; }
        public DelegateCommand ExitGameCommand { get; private set; }
        #endregion

        #region Properties
        public int CircleRadius { get; private set; }

        public string WhitePieces { 
            get => whitePieces; 
            private set 
            { 
                if (value != whitePieces) 
                { 
                    whitePieces = value;
                    OnPropertyChanged(nameof(WhitePieces));
                } 
            } 
        }

        public string BlackPieces { 
            get => blackPieces; 
            private set
            {
                if (value != blackPieces)
                {
                    blackPieces = value;
                    OnPropertyChanged(nameof(BlackPieces));
                }
            }
        }

        public string PlayersTurn { 
            get => playersTurn; 
            private set 
            {
                if (value != playersTurn)
                {
                    playersTurn = value;
                    OnPropertyChanged(nameof(PlayersTurn));
                }
            } 
        }
        
        public string PhaseOfGame { 
            get => phaseOfGame; 
            private set 
            {
                if (value != phaseOfGame)
                {
                    phaseOfGame = value;
                    OnPropertyChanged(nameof(PhaseOfGame));
                }
            } 
        }

        public ObservableCollection<MillPiece> Pieces { get; set; }
        #endregion

        #region Events
        public event EventHandler? NewGame;
        public event EventHandler? SaveGame;
        public event EventHandler? LoadGame;
        public event EventHandler? ExitGame;
        #endregion

        public MillViewModel(MalomGame model)
        {
            this.model = model;
            CircleRadius = 20;
            whitePieces = $"Pieces of White:\n{model.NumberOfWhitePieces}";
            blackPieces = $"Pieces of Black:\n{model.NumberOfBlackPieces}";
            playersTurn = $"Player's turn:\n{model.CurrentPlayer}";
            phaseOfGame = $"Phase of game:\n{model.Phase}";
            positionSelected = false;
            PassGame = new DelegateCommand(param => { model.PassTurn(); LabelsChanged(); });
            NewGameCommand = new DelegateCommand(param => OnNewGame());
            SaveGameCommand = new DelegateCommand(param => OnSaveGame());
            LoadGameCommand = new DelegateCommand(param => OnLoadGame());
            ExitGameCommand = new DelegateCommand(param => OnExitGame());

            Pieces = new ObservableCollection<MillPiece>();
            List<Position> positions = new List<Position>();
            positions.AddRange(PositionCalculator.GetCenterPositions(600, 600, CircleRadius, 0));
            positions.AddRange(PositionCalculator.GetCenterPositions(400, 400, CircleRadius, 100));
            positions.AddRange(PositionCalculator.GetCenterPositions(200, 200, CircleRadius, 200));
            for (int i = 0; i < positions.Count; ++i)
            {
                Pieces.Add(new MillPiece(positions[i], i, Players.NoPlayer, new DelegateCommand(param => StepGameHandler(Convert.ToInt32(param)))));
            }
        }

        private void StepGameHandler(int position)
        {
            if (model.Phase == Phases.PHASE1)
            {
                model.stepGamePhase1(position);
            }
            else if (model.Phase == Phases.PHASE2)
            {
                if (positionSelected)
                {
                    secondPosition = position;
                    model.stepGamePhase2(firstPosition, secondPosition);
                    positionSelected = false;
                }
                else
                {
                    positionSelected = true;
                    firstPosition = position;
                }
            }
            else if (model.Phase == Phases.REMOVE)
            {
                model.RemovePiece(position);
            }
            LabelsChanged();
            PiecesChanged();
        }

        private void PiecesChanged()
        {
            for (int i = 0; i < Pieces.Count; ++i)
            {
                Pieces[i].Player = model.GameGraph[i].Data;
            }
        }

        private void LabelsChanged()
        {
            WhitePieces = $"Pieces of White:\n{model.NumberOfWhitePieces}";
            BlackPieces = $"Pieces of Black:\n{model.NumberOfBlackPieces}";
            PlayersTurn = $"Player's turn:\n{model.CurrentPlayer}";
            PhaseOfGame = $"Phase of game:\n{model.Phase}";
        }

        #region Event methods
        private void OnNewGame()
        {
            NewGame?.Invoke(this, EventArgs.Empty);
            PiecesChanged();
            LabelsChanged();
        }

        private void OnSaveGame()
        {
            SaveGame?.Invoke(this, EventArgs.Empty);
        }

        private void OnLoadGame()
        {
            LoadGame?.Invoke(this, EventArgs.Empty);
            PiecesChanged();
            LabelsChanged();
        }

        private void OnExitGame()
        {
            ExitGame?.Invoke(this, EventArgs.Empty);
        }
        #endregion
    }
}
