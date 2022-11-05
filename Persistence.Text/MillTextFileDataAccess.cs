using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Text
{
    public class MillTextFileDataAccess : IMillDataAccess
    {
        public LoadingDataStructure LoadGame(string path)
        {
            LoadingDataStructure loadingDataStructure = new LoadingDataStructure();
            if (path == null)
                throw new ArgumentNullException("path");

            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    String[] numbers = (reader.ReadToEnd()).Split();

                    loadingDataStructure.GameGraph = new Edge<Players>[numbers.Length - 3];

                    for (int i = 0; i < loadingDataStructure.GameGraph.Length; ++i)
                    {
                        loadingDataStructure.GameGraph[i] = new Edge<Players>((Players)Int32.Parse(numbers[i]));
                    }
                    loadingDataStructure.Phase = (Phases)Int32.Parse(numbers[numbers.Length - 3]);
                    loadingDataStructure.CurrentPlayer = (Players)Int32.Parse(numbers[numbers.Length - 2]);
                    loadingDataStructure.PhaseCounter = Int32.Parse(numbers[numbers.Length - 1]);

                    return loadingDataStructure;
                }
            }
            catch
            {
                throw new MillDataException("Error occured during loading.");
            }
        }

        public void SaveGame(string path, LoadingDataStructure loadingDataStructure)
        {
            if (path == null) throw new ArgumentNullException("path");
            if (loadingDataStructure.GameGraph == null) throw new ArgumentNullException("Edges");

            try
            {
                using (StreamWriter writer = new StreamWriter(path))
                {
                    for (int i = 0; i < loadingDataStructure.GameGraph.Length; ++i)
                    {
                        writer.Write((Int32)loadingDataStructure.GameGraph[i].Data + " ");
                    }
                    writer.Write($"{(Int32)loadingDataStructure.Phase} {(Int32)loadingDataStructure.CurrentPlayer} {loadingDataStructure.PhaseCounter}");
                }
            }
            catch
            {
                throw new MillDataException("Error occured during saving.");
            }
        }
    }
}
