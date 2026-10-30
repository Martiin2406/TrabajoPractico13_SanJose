using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace TrabajoPractico13
{
    // Luz piloto redonda (como las del tablero).
    // Encendido = true  -> se pinta con ColorEncendido
    // Encendido = false -> se pinta gris
    public class Piloto : Control
    {
        private bool encendido = false;
        private Color colorEncendido = Color.LimeGreen;

        public Piloto()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor | ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw, true);
            BackColor = Color.Transparent;
            Size = new Size(30, 30);
        }

        [Category("Piloto"), DefaultValue(false)]
        public bool Encendido
        {
            get { return encendido; }
            set
            {
                if (encendido == value) return;   // sin cambios: no hace falta redibujar
                encendido = value;
                Invalidate();
            }
        }

        [Category("Piloto"), DefaultValue(typeof(Color), "LimeGreen")]
        public Color ColorEncendido
        {
            get { return colorEncendido; }
            set { colorEncendido = value; Invalidate(); }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle circulo = new Rectangle(2, 2, Width - 5, Height - 5);
            Color relleno = encendido ? colorEncendido : Color.FromArgb(90, 90, 90);

            using (SolidBrush pincel = new SolidBrush(relleno))
                g.FillEllipse(pincel, circulo);

            // Brillo para que parezca una lámpara
            Rectangle brillo = new Rectangle(circulo.X + circulo.Width / 5, circulo.Y + circulo.Height / 6,
                                             circulo.Width / 3, circulo.Height / 4);
            using (SolidBrush pincelBrillo = new SolidBrush(Color.FromArgb(encendido ? 150 : 60, Color.White)))
                g.FillEllipse(pincelBrillo, brillo);

            using (Pen borde = new Pen(Color.FromArgb(40, 40, 40), 2))
                g.DrawEllipse(borde, circulo);
        }
    }
}
