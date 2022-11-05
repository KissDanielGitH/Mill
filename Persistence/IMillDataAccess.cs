using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public interface IMillDataAccess
    {
        LoadingDataStructure LoadGame(String path);

        public void SaveGame(string path, LoadingDataStructure loadingDataStructure);
    }
}
