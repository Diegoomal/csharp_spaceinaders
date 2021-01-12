using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

using System.Drawing;

namespace FormGames
{
    interface IStrategyKeyDown : IGame
    {
        void processar(ref object obj);
    }
}
