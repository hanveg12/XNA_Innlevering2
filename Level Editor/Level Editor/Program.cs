using System;
using System.Windows.Forms;

namespace Level_Editor
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        
        [STAThread]
        static void Main(string[] args)
        {
            DialogResult res = MessageBox.Show("Vil du åpne spillet i redigeringsmodus?", "Velg modus", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                MainForm form = new MainForm();
                form.Show();
                form.game = new EditorGame(form.pctSurface.Handle, form, form.pctSurface);
                form.game.Run();
            }

            else
            {
                using (Game1 game = new Game1())
                {
                    game.Run();
                }

            }
        }
    }
#endif
}

