using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

using System.Windows.Forms;

namespace FormGames.Strategys
{
    interface IGame
    {
        void desenha(object sender, EventArgs e);
        void update_async(object sender, EventArgs e);
        void update_keydown(object sender, KeyEventArgs e);
    }
}
