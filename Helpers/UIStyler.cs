using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace PasswordVault.Helpers
{
    public partial class UIStyler
    {
        public static void ApplyButtonStyle(params Button[] buttons)
        {
            foreach (var btn in buttons)
            {
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 1;
                btn.FlatAppearance.BorderColor = Color.DarkGray;

                btn.BackColor = Color.WhiteSmoke;   // спокойный фон
                btn.ForeColor = Color.Black;        // строгий текст

                btn.Font = new Font("Segoe UI", 9F, FontStyle.Regular);

                // Скруглённые углы (небольшой радиус)
                btn.Region = System.Drawing.Region.FromHrgn(
                    CreateRoundRectRgn(0, 0, btn.Width, btn.Height, 6, 6));

                // Hover эффект — лёгкий оттенок серого
                btn.MouseEnter += (s, e) => btn.BackColor = Color.Gainsboro;
                btn.MouseLeave += (s, e) => btn.BackColor = Color.WhiteSmoke;

                // Pressed эффект — чуть темнее
                btn.MouseDown += (s, e) => btn.BackColor = Color.LightGray;
                btn.MouseUp += (s, e) => btn.BackColor = Color.Gainsboro;
            }
        }

        [LibraryImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static partial IntPtr CreateRoundRectRgn(
        int nLeftRect,
        int nTopRect,
        int nRightRect,
        int nBottomRect,
        int nWidthEllipse,
        int nHeightEllipse);

    }
}