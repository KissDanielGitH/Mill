using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewWPF.ViewModel
{
    public class Position : ViewModelBase
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Position(int x, int y) { X = x; Y = y; }
    }
    public class PositionCalculator
    {

        public static List<Position> GetCenterPositions(int width, int height, int circleRadius, int shift)
        {
            List<Position> positions = new List<Position>(8);

            positions.Add(new Position(shift + 0, shift + 0));
            positions.Add(new Position(shift + width / 2 - circleRadius, shift + 0));
            positions.Add(new Position(shift + width - 2 * circleRadius, shift + 0));
            positions.Add(new Position(shift + width - 2 * circleRadius, shift + height / 2 - circleRadius));
            positions.Add(new Position(shift + width - 2 * circleRadius, shift + height - 2 * circleRadius));
            positions.Add(new Position(shift + width / 2 - circleRadius, shift + height - 2 * circleRadius));
            positions.Add(new Position(shift + 0, shift + height - 2 * circleRadius));
            positions.Add(new Position(shift + 0, shift + height / 2 - circleRadius));
            return positions;
        }
    }
}
