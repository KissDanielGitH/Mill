using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View
{
    public struct Position {
        public int X { get; set; }
        public int Y { get; set; }



        public Position(int x, int y) { X = x; Y = y; }
    }
    internal class PositionCalculator
    {
        public Form1 Form1
        {
            get => default;
            set
            {
            }
        }

        public static Position[] GetCenterPositions(int width, int height, int radius)
        {
            Position[] positions = new Position[8];

            positions[0] = new Position(0, 0);
            positions[1] = new Position(width / 2 - radius, 0);
            positions[2] = new Position(width - 2 * radius, 0);
            positions[3] = new Position(width - 2 * radius, height / 2 - radius);
            positions[4] = new Position(width - 2 * radius, height - 2 * radius);
            positions[5] = new Position(width / 2 - radius, height - 2 * radius);
            positions[6] = new Position(0, height - 2 * radius);
            positions[7] = new Position(0, height / 2 - radius);
            return positions;
        }
    }
}
