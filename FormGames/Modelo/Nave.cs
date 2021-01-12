using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

using System.Drawing;

namespace FormGames
{
    public class Nave : Objeto2D, IObjeto2D, IPlayer, IArsenal
    {
        //
        // Variáveis
        //

        //bool flgTiroSimples = true;
        public bool flgExplodiu = false;
        public int nEscolhaArma = 0;
        public int segundoMomentoColisao;
        public int nPontuacao = 0;

        //
        // Construtores
        //

        public Nave()
        {
            this.angulo = 0;
            this.progressao = 0;
            this.tag = string.Empty;
            this.caminho_imagem = string.Empty;
            this.posicao = new Point(0, 0);
            this.tamanho = new Size(50, 50);
            //inputImage(caminho_imagem);
        }

        public Nave(string caminho_imagem)
        {
            this.angulo = 0;
            this.progressao = 0;
            this.tag = string.Empty;
            this.caminho_imagem = string.Empty;
            this.posicao = new Point(0, 0);
            this.tamanho = new Size(50, 50);
            inputImage(caminho_imagem);
        }

        public Nave(string caminho_imagem, Size tamanho, Point posicao)
        {
            this.angulo = 0;
            this.progressao = 0;
            this.tag = string.Empty;
            this.caminho_imagem = caminho_imagem;
            this.posicao = posicao;
            this.tamanho = tamanho;
            inputImage(caminho_imagem, tamanho);
        }

        public Nave(int progressao, string caminho_imagem, Size tamanho, Point posicao)
        {
            this.angulo = 0;
            this.progressao = progressao;
            this.tag = string.Empty;
            this.caminho_imagem = caminho_imagem;
            this.posicao = posicao;
            this.tamanho = tamanho;
            inputImage(caminho_imagem, tamanho);
        }

        //
        // Métodos
        //

        private void troca_tiro_simples_para_duplo()
        {
            //flgTiroSimples = !flgTiroSimples;
        }
        
        //
        //  Implementações da interface - IObjeto2D
        //

        public void destruir()
        {
            this.flgExplodiu = true;
            this.segundoMomentoColisao = DateTime.Now.Second;
            this.imagem = EstaticosProjeto.imgExplosao;
        }

        public object mover(object obj)
        {
            throw new NotImplementedException();
        }

        public void add_pontuacao(int nPontuacao)
        {
            this.nPontuacao += nPontuacao;
        }

        //
        //  Implementações da interface - IPlayer
        //

        public void down()
        {
            this.posicao = new Point(
                this.posicao.X, 
                this.posicao.Y += this.progressao);
        }

        public void left()
        {
            this.posicao = new Point(
               this.posicao.X -= this.progressao,
               this.posicao.Y);
        }

        public void right()
        {
            this.posicao = new Point(
               this.posicao.X += this.progressao,
               this.posicao.Y);
        }
        
        public void up()
        {
            this.posicao = new Point(
               this.posicao.X,
               this.posicao.Y -= this.progressao);
        }

        //
        public void diagonal_superior_direita()
        {
            this.posicao = new Point(
               this.posicao.X += this.progressao,
               this.posicao.Y -= this.progressao);
        }

        public void diagonal_superior_esquerda()
        {
            this.posicao = new Point(
               this.posicao.X -= this.progressao,
               this.posicao.Y -= this.progressao);
        }

        public void diagonal_inferior_direita()
        {
            this.posicao = new Point(
                this.posicao.X += this.progressao,
                this.posicao.Y += this.progressao);
        }

        public void diagonal_inferior_esquerda()
        {
            this.posicao = new Point(
                this.posicao.X -= this.progressao,
                this.posicao.Y += this.progressao);
        }


        public void space()
        {
            if (nEscolhaArma == 0)
                tiro_simples();
            else if (nEscolhaArma == 1)
                tiro_duplo();
            else
                tiro_triplo();
        }

        //
        //  Implementações da interface - IPlayer
        //

        public void tiro_simples()
        {
            Point pCentro = this.posicao;
            pCentro.X += (this.tamanho.Width / 3);
            pCentro.Y -= 20;

            FormPrincipal.tiros.Add(new Tiro(10, pCentro,
                new Size(20, 20), EstaticosProjeto.caminho_missel));
        }

        public void tiro_duplo()
        {
            // esqueda
            Point pEsquerda = this.posicao;
            pEsquerda.Y -= 20;

            FormPrincipal.tiros.Add(new Tiro(10, pEsquerda,
                new Size(20, 20), EstaticosProjeto.caminho_missel));

            // direita
            Point pDireita = this.posicao;
            pDireita.X += (this.tamanho.Width / 2) + 10;    // '+10' da imagem do missel
            pDireita.Y -= 20;

            FormPrincipal.tiros.Add(new Tiro(10, pDireita,
                new Size(20, 20), EstaticosProjeto.caminho_missel));
        }

        public void tiro_triplo()
        {
            tiro_simples();
            tiro_duplo();
        }

        
    }// clas
}// namespace
