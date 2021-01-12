using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace FormGames
{
    interface IObjeto2D : IGame
    {
        //object mover(System.Windows.Forms.Form form);

        void destruir();
        object mover(object obj);
        
    }
}
