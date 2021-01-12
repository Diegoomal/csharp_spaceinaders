using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

using System.Windows.Forms;

namespace FormGames
{
    public class Mover
    {
        public static void mover_asteroides(Form form, ref List<Invader> asteroides)
        {
            lock (form)
            {
                foreach (var asteroide in asteroides)
                    asteroide.mover(form);
            }
        }

        public static void mover_apenas_misseis(Form form, ref List<Tiro> tiros)
        {
            Tiro tPosicao = null;

            lock (form)
            {
                foreach (Tiro t in tiros)
                {
                    if (t.posicao.Y < 0)
                    {
                        tPosicao = t;
                        break;
                    }

                    t.posicao.Y -= 5;
                }

                tiros.Remove(tPosicao);
            }
            
        }

    }// public class Mover
}// namespace
