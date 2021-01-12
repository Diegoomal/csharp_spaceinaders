using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Drawing;

namespace FormGames
{
    public class KeyDown_SPACE : IStrategyKeyDown
    {
        public void processar(ref object obj)
        {
            Nave nave = (Nave)obj;
            nave.space();
        }
    }
}
