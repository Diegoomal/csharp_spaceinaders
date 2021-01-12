using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

using System.Drawing;           // class Rectangle  -> verificar colisão
using System.Windows.Forms;     // classe Form      -> contexto
using System.Threading;

namespace FormGames
{
    public class VerificarColisao
    {
        /*public static void colisao_objtos(Form frm, ref Nave nave, ref List<Asteroide> asteroides, ref */
        public static void colisao_objtos(Thread contexto_Thread, ref Nave nave, ref List<Invader> invaders, ref List<Tiro> tiros)
        {
            lock (contexto_Thread)
            {
                List<Tiro> lstTirosASeremRemovidosDaLista = new List<Tiro>();
                List<Invader> lstAsteroidesASeremRemovidosDaList = new List<Invader>();

                // percorre tds objetos que serão verificados
                foreach (Invader invader in invaders)
                {
                    // verifica tempo q passou do asteroid
                    if (arranca_asteroide_depois_que_explodiu(invader))
                        lstAsteroidesASeremRemovidosDaList.Add(invader);

                    // salva o retangle do asteroid q vai ser verificado
                    Rectangle rectangleAsteroide = invader.getRectangle();

                    // verifica colisao entre o Asteroid e a Nave (player)
                    if (nave.getRectangle().IntersectsWith(rectangleAsteroide))
                    {
                        nave.destruir();
                        invader.destruir();

                        lstAsteroidesASeremRemovidosDaList.Add(invader);
                    }

                    foreach (Tiro tiro in tiros)
                    {
                        // saiu da área de jogo (nao visivel)
                        if (tiro.flgSaiuArea)
                            lstTirosASeremRemovidosDaLista.Add(tiro);

                        // verifica colisao entre o Asteroid e a o missel
                        if (rectangleAsteroide.IntersectsWith(tiro.getRectangle()))
                        {
                            // caso ja missel ja tenha atingido, 
                            // nao deixa inserir um novamente prolongando a vida do asteroid
                            if (!invader.flgExplodiu)
                            {
                                tiro.destruir();
                                invader.destruir();

                                nave.add_pontuacao(invader.nPontuacao);

                                lstTirosASeremRemovidosDaLista.Add(tiro);
                                lstAsteroidesASeremRemovidosDaList.Add(invader);
                            }
                        }
                    }
                }

                //
                // removendo objetos que explodiram por colisão
                //

                if (lstTirosASeremRemovidosDaLista.Count > 0)
                {
                    foreach (Tiro tiro in lstTirosASeremRemovidosDaLista)
                        tiros.Remove(tiro);

                    lstTirosASeremRemovidosDaLista.Clear();
                }

                if (lstAsteroidesASeremRemovidosDaList.Count > 0)
                {
                    foreach (Invader asteroide in lstAsteroidesASeremRemovidosDaList)
                    {
                        int variacaoTempo = asteroide.segundoMomentoColisao - DateTime.Now.Second;

                        if (variacaoTempo < 0)
                            variacaoTempo *= -1;

                        if (variacaoTempo > 1 && asteroide.flgExplodiu)
                            invaders.Remove(asteroide);
                    }

                    lstAsteroidesASeremRemovidosDaList.Clear();
                }

            }// lock(form)
        }// fim método colisao_objtos

        private static bool arranca_asteroide_depois_que_explodiu(Invader asteroide)
        {
            int variacaoTempo = asteroide.segundoMomentoColisao - DateTime.Now.Second;

            if (variacaoTempo < 0)
                variacaoTempo *= -1;

            if (variacaoTempo > 0 && asteroide.flgExplodiu)
                return true;
            else
                return false;
        }

    }// public class VerificarColisao
}// namespace
