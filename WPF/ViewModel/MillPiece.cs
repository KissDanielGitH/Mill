using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistence;

namespace ViewWPF.ViewModel
{
    public class MillPiece : ViewModelBase
    {
        private Players player;

        public Position Position { get; private set; }
        public int Index { get; private set; }
        public Players Player 
        {
            get => player;
            set
            {
                if (value != player)
                {
                    player = value;
                    OnPropertyChanged(nameof(Player));
                }
            }
        }
        public DelegateCommand StepCommand { get; private set; }

        public MillPiece(Position position, int index, Players player, DelegateCommand stepCommand)
        {
            Position = position;
            Index = index;
            Player = player;
            StepCommand = stepCommand;
        }
    }
}
