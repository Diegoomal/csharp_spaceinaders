using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

using System.Drawing;

namespace FormGames
{
    public class Tiro : Objeto2D, IObjeto2D
    {
        //
        // Variáveis
        //

        public bool flgSaiuArea = false;

        public bool flgExplodiu = false;
        public int segundoMomentoColisao = 0;

        //
        // Construtores
        //

        public Tiro()
        {
            base.angulo = 0;
            base.progressao = 2;
            base.posicao = new Point(0, 0);
            base.tamanho = new Size(50, 50);
            base.tag = "tiro";
        }

        public Tiro(int progressao, Point posicao, Size tamanho, string caminho)
        {
            base.angulo = 0;
            base.progressao = progressao;
            base.tag = "tiro";
            base.posicao = posicao;
            base.tamanho = tamanho;
            base.inputImage(caminho, tamanho);
        }
        
        //
        // Métodos implementados da interface
        //

        public void destruir()
        {
            this.flgExplodiu = true;
            this.segundoMomentoColisao = DateTime.Now.Second;
            this.imagem = EstaticosProjeto.imgExplosao;
        }

        public object mover(object obj)
        {
            //lock ((System.Windows.Forms.Form)obj)
            //{
                if (!(this.posicao.Y < (-this.tamanho.Height * 2)))
                    this.posicao.Y -= this.progressao;
                else
                    this.flgSaiuArea = true;            
            //}

            return null;
        }

    }// class
}// namespace
