using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface IMalomGame
    {
        void resetGame();

        void stepGamePhase1(Int32 destination);

        void stepGamePhase2(Int32 position, Int32 destination);

        void RemovePiece(Int32 position);

        void SaveGame(string path);

        public void LoadGame(string path);
    }
}
