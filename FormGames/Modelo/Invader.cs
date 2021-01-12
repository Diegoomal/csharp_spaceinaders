using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

using System.Drawing;

namespace FormGames
{
    public class Invader : Objeto2D, IObjeto2D
    {
        //
        // Variáveis
        //

        private bool flgVai = true;
        public bool flgExplodiu = false;

        private int limiteMinX = 50, 
            limiteMaxX = 50;

        public int segundoMomentoColisao = 0;

        public int nPontuacao = 10;

        //
        // Construtores
        //

        public Invader()
        {
            this.angulo = 0;
            this.progressao = 0;
            this.tag = string.Empty;
            this.caminho_imagem = string.Empty;
            this.posicao = new Point(0, 0);
            this.tamanho = new Size(50, 50);
            //inputImage(caminho_imagem);
        }

        public Invader(string caminho_imagem)
        {
            this.angulo = 0;
            this.progressao = 0;
            this.tag = string.Empty;
            this.caminho_imagem = string.Empty;
            this.posicao = new Point(0, 0);
            this.tamanho = new Size(50, 50);
            inputImage(caminho_imagem);
        }

        public Invader(string caminho_imagem, Size tamanho, Point posicao)
        {
            this.angulo = 0;
            this.progressao = 0;
            this.tag = string.Empty;
            this.caminho_imagem = caminho_imagem;
            this.posicao = posicao;
            this.tamanho = tamanho;
            inputImage(caminho_imagem, tamanho);
        }

        public Invader(int progressao, string caminho_imagem, Size tamanho, Point posicao)
        {
            this.angulo = 0;
            this.progressao = progressao;
            this.tag = string.Empty;
            this.caminho_imagem = caminho_imagem;
            this.posicao = posicao;
            this.tamanho = tamanho;
            inputImage(caminho_imagem, tamanho);
        }

        public Invader(int progressao, string caminho_imagem, Size tamanho, Point posicao,
            int limiteMinX, int limiteMaxX)
        {
            this.angulo = 0;
            this.progressao = progressao;
            this.tag = string.Empty;
            this.caminho_imagem = caminho_imagem;
            this.posicao = posicao;
            this.tamanho = tamanho;
            inputImage(caminho_imagem, tamanho);

            this.limiteMinX = limiteMinX;
            this.limiteMaxX = limiteMaxX;
        }

        //
        // Métodos implementados da interface - IObjeto2D
        //

        public void destruir()
        {
            this.flgExplodiu = true;
            this.segundoMomentoColisao = DateTime.Now.Second;
            this.imagem = EstaticosProjeto.imgExplosao;
        }

        public object mover(object obj)
        {
            System.Windows.Forms.Form form = (System.Windows.Forms.Form)obj;

            lock (form)
            {
                if (flgVai)
                    this.posicao.X += 5;
                else
                    this.posicao.X -= 5;

                if (this.posicao.X > (form.Width - limiteMaxX))
                    flgVai = false;

                if (this.posicao.X < limiteMinX)
                    flgVai = true;
            }

            return null;
        }
        
    }// class
}// namespace
