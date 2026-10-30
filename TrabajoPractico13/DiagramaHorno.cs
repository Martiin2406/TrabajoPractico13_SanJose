using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace TrabajoPractico13
{
    // Dibujo del P&ID del horno. Es solo el "plano" de fondo:
    // los TextBox y las luces piloto se colocan encima desde el diseñador.
    //
    // Simbología usada (norma ISA 5.1, simplificada):
    //   línea gruesa continua  -> cañería de proceso (gas)
    //   línea fina de trazos   -> señal eléctrica
    //   círculo                -> instrumento de campo (TT-101)
    //   círculo con línea      -> instrumento en tablero / PLC (TIC-101)
    public class DiagramaHorno : Control
    {
        private bool llamaEncendida = false;

        public DiagramaHorno()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.UserPaint | ControlStyles.ResizeRedraw, true);
            BackColor = Color.FromArgb(247, 249, 251);
        }

        // Dibuja las llamas del quemador (se usará con el estado de la caldera)
        [Category("Diagrama"), DefaultValue(false)]
        public bool LlamaEncendida
        {
            get { return llamaEncendida; }
            set
            {
                if (llamaEncendida == value) return;   // sin cambios: no hace falta redibujar
                llamaEncendida = value;
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            DibujarTitulo(g);
            DibujarHorno(g);
            DibujarQuemador(g);
            DibujarLineaGas(g);
            DibujarInstrumentos(g);
            DibujarReferencias(g);
        }

        private void DibujarTitulo(Graphics g)
        {
            using (Font titulo = new Font("Segoe UI", 15F, FontStyle.Bold))
            using (Font subtitulo = new Font("Segoe UI", 9F))
            {
                g.DrawString("Horno H-101 — Control de temperatura", titulo, Brushes.Black, 20, 12);
                g.DrawString("P&ID simplificado · PLC Siemens S7-1200", subtitulo, Brushes.DimGray, 22, 42);
            }
        }

        private void DibujarHorno(Graphics g)
        {
            Rectangle horno = new Rectangle(380, 150, 300, 240);
            Rectangle chimenea = new Rectangle(505, 95, 50, 55);
            Rectangle interior = Rectangle.Inflate(horno, -18, -18);

            // Paredes de ladrillo refractario
            using (HatchBrush ladrillo = new HatchBrush(HatchStyle.HorizontalBrick,
                                                        Color.FromArgb(150, 70, 40), Color.FromArgb(222, 184, 135)))
            {
                g.FillRectangle(ladrillo, chimenea);
                g.FillRectangle(ladrillo, horno);
            }
            using (SolidBrush camara = new SolidBrush(Color.FromArgb(45, 45, 48)))
                g.FillRectangle(camara, interior);

            using (Pen chapa = new Pen(Color.Black, 3))
            {
                g.DrawRectangle(chapa, chimenea);
                g.DrawRectangle(chapa, horno);
            }
            g.DrawRectangle(Pens.Black, interior);

            using (Font fuente = new Font("Segoe UI", 12F, FontStyle.Bold))
            using (StringFormat centrado = new StringFormat { Alignment = StringAlignment.Center })
            {
                g.DrawString("HORNO\nH-101", fuente, Brushes.WhiteSmoke,
                             new RectangleF(interior.X, interior.Y + 20, interior.Width, 60), centrado);
            }

            DibujarLlamas(g, interior);
        }

        private void DibujarLlamas(Graphics g, Rectangle interior)
        {
            int baseY = interior.Bottom - 4;
            int[] centros = { 450, 490, 530, 570, 610 };
            int[] alturas = { 40, 55, 65, 55, 40 };

            for (int i = 0; i < centros.Length; i++)
            {
                int x = centros[i];
                int alto = llamaEncendida ? alturas[i] : 12;   // apagada: solo la llama piloto
                Point[] llama =
                {
                    new Point(x - 14, baseY),
                    new Point(x - 8, baseY - alto / 2),
                    new Point(x, baseY - alto),
                    new Point(x + 8, baseY - alto / 2),
                    new Point(x + 14, baseY),
                };

                if (llamaEncendida)
                {
                    using (SolidBrush naranja = new SolidBrush(Color.FromArgb(240, 120, 20)))
                        g.FillClosedCurve(naranja, llama, FillMode.Alternate, 0.3f);
                    Point[] nucleo =
                    {
                        new Point(x - 6, baseY),
                        new Point(x, baseY - alto / 2),
                        new Point(x + 6, baseY),
                    };
                    g.FillClosedCurve(Brushes.Gold, nucleo, FillMode.Alternate, 0.3f);
                }
                else
                {
                    using (SolidBrush azul = new SolidBrush(Color.FromArgb(80, 120, 200)))
                        g.FillClosedCurve(azul, llama, FillMode.Alternate, 0.3f);
                }
            }
        }

        private void DibujarQuemador(Graphics g)
        {
            Rectangle quemador = new Rectangle(455, 405, 150, 45);

            using (Pen cano = new Pen(Color.Black, 3))
                g.DrawLine(cano, 530, 390, 530, 405);       // conexión quemador -> horno

            using (SolidBrush relleno = new SolidBrush(Color.FromArgb(200, 205, 212)))
                g.FillRectangle(relleno, quemador);
            using (Pen borde = new Pen(Color.Black, 2))
                g.DrawRectangle(borde, quemador);

            using (Font fuente = new Font("Segoe UI", 9F, FontStyle.Bold))
            using (StringFormat centrado = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
            {
                g.DrawString("CALDERA\nB-101", fuente, Brushes.Black, quemador, centrado);
            }
        }

        private void DibujarLineaGas(Graphics g)
        {
            const int y = 428;
            const int xValvula = 250;

            using (Pen cano = new Pen(Color.Black, 3))
            {
                g.DrawLine(cano, 60, y, xValvula - 18, y);
                g.DrawLine(cano, xValvula + 18, y, 455, y);
            }

            // Flecha de sentido de flujo entrando a la caldera
            Point[] flecha = { new Point(440, y - 7), new Point(455, y), new Point(440, y + 7) };
            g.FillPolygon(Brushes.Black, flecha);

            using (Font fuente = new Font("Segoe UI", 8.5F, FontStyle.Bold))
                g.DrawString("GAS NATURAL", fuente, Brushes.Black, 60, y - 22);

            // Válvula de control FCV-101: dos triángulos ("moño") + actuador neumático
            Point[] izquierda = { new Point(xValvula - 18, y - 12), new Point(xValvula - 18, y + 12), new Point(xValvula, y) };
            Point[] derecha = { new Point(xValvula + 18, y - 12), new Point(xValvula + 18, y + 12), new Point(xValvula, y) };
            g.FillPolygon(Brushes.White, izquierda);
            g.FillPolygon(Brushes.White, derecha);
            using (Pen borde = new Pen(Color.Black, 2))
            {
                g.DrawPolygon(borde, izquierda);
                g.DrawPolygon(borde, derecha);
                g.DrawLine(borde, xValvula, y, xValvula, 400);                // vástago
                g.DrawArc(borde, xValvula - 14, 386, 28, 28, 180, 180);         // actuador
                g.DrawLine(borde, xValvula - 14, 400, xValvula + 14, 400);
            }

            using (Font fuente = new Font("Segoe UI", 8.5F))
                g.DrawString("FCV-101", fuente, Brushes.Black, xValvula - 24, y + 16);
        }

        private void DibujarInstrumentos(Graphics g)
        {
            Point tt = new Point(790, 210);    // transmisor de temperatura (campo)
            Point tic = new Point(250, 300);   // controlador de temperatura (PLC)
            const int radio = 26;

            // Conexión a proceso: termocupla en la pared del horno
            using (Pen proceso = new Pen(Color.Black, 1.5f))
                g.DrawLine(proceso, 680, tt.Y, tt.X - radio, tt.Y);

            // Señales eléctricas (trazos): TT -> TIC -> válvula
            using (Pen senal = new Pen(Color.Black, 1.5f) { DashStyle = DashStyle.Dash })
            {
                g.DrawLines(senal, new[]
                {
                    new Point(tt.X, tt.Y - radio),
                    new Point(tt.X, 70),
                    new Point(tic.X, 70),
                    new Point(tic.X, tic.Y - radio),
                });
                g.DrawLine(senal, tic.X, tic.Y + radio, tic.X, 386);
            }

            DibujarBurbuja(g, tt, radio, "TT", "101", false);
            DibujarBurbuja(g, tic, radio, "TIC", "101", true);
        }

        private void DibujarBurbuja(Graphics g, Point centro, int radio, string funcion, string lazo, bool enTablero)
        {
            Rectangle circulo = new Rectangle(centro.X - radio, centro.Y - radio, radio * 2, radio * 2);
            g.FillEllipse(Brushes.White, circulo);
            using (Pen borde = new Pen(Color.Black, 2))
            {
                g.DrawEllipse(borde, circulo);
                if (enTablero)
                    g.DrawLine(borde, circulo.Left, centro.Y, circulo.Right, centro.Y);
            }

            using (Font fuente = new Font("Segoe UI", 8.5F, FontStyle.Bold))
            using (StringFormat centrado = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
            {
                g.DrawString(funcion, fuente, Brushes.Black, new RectangleF(circulo.X, circulo.Y + 4, circulo.Width, radio - 4), centrado);
                g.DrawString(lazo, fuente, Brushes.Black, new RectangleF(circulo.X, centro.Y, circulo.Width, radio - 4), centrado);
            }
        }

        private void DibujarReferencias(Graphics g)
        {
            using (Font fuente = new Font("Segoe UI", 8.5F))
            using (Pen proceso = new Pen(Color.Black, 3))
            using (Pen senal = new Pen(Color.Black, 1.5f) { DashStyle = DashStyle.Dash })
            {
                // Leyenda de líneas
                g.DrawLine(proceso, 20, 555, 70, 555);
                g.DrawString("Cañería de proceso", fuente, Brushes.Black, 78, 547);
                g.DrawLine(senal, 20, 580, 70, 580);
                g.DrawString("Señal eléctrica", fuente, Brushes.Black, 78, 572);

                // Rótulo del plano
                Rectangle rotulo = new Rectangle(700, 535, 280, 60);
                g.FillRectangle(Brushes.White, rotulo);
                g.DrawRectangle(Pens.Black, rotulo);
                g.DrawLine(Pens.Black, rotulo.Left, rotulo.Top + 30, rotulo.Right, rotulo.Top + 30);
                using (Font negrita = new Font("Segoe UI", 9F, FontStyle.Bold))
                    g.DrawString("TP Nº13 — Automatización Industrial", negrita, Brushes.Black, rotulo.X + 8, rotulo.Y + 6);
                g.DrawString("Comunicación PLC S7-1200 ↔ PC (S7.Net)", fuente, Brushes.Black, rotulo.X + 8, rotulo.Y + 36);
            }
        }
    }
}
