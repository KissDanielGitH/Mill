using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class LoadingDataStructure
    {
        public Edge<Players>[]? GameGraph;
        public Phases Phase;
        public Players CurrentPlayer;
        public int PhaseCounter;

        public LoadingDataStructure() { }

        public LoadingDataStructure(Edge<Players>[]? gameGraph, Phases phase, Players currentPlayer, int phaseCounter)
        {
            GameGraph = gameGraph;
            Phase = phase;
            CurrentPlayer = currentPlayer;
            PhaseCounter = phaseCounter;
        }
    }
}
