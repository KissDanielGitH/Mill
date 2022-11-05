using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace View
{
    public class ButtonRounded : Button
    {
        public Int32 Position { get; set; }

        public ButtonRounded(int position)
        {
            Position = position;
            Text = null;
            BackColor = Color.Yellow;
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            Size = new Size(50, 50);
        }

        

        protected override void OnPaint(PaintEventArgs pevent)
        {
            GraphicsPath graphics = new GraphicsPath();
            graphics.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);
            this.Region = new System.Drawing.Region(graphics);

            base.OnPaint(pevent);
        }
    }
}
