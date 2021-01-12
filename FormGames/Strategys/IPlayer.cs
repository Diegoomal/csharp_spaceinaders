using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace FormGames
{
    interface IPlayer : IGame
    {
        void up();
        void down();
        void left();
        void right();
        void space();
    }
}
