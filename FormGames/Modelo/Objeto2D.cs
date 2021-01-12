using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Drawing;

namespace FormGames
{
    public class Objeto2D
    {
        public int angulo;
        public int progressao;

        public string tag;
        public string caminho_imagem;
        
        public Point posicao;
        public Size tamanho;
        public Image imagem;

        public Objeto2D()
        {
            this.angulo = 0;
            this.progressao = 0;
            this.tag = string.Empty;
            this.caminho_imagem = string.Empty;
            this.posicao = new Point(0, 0);
            this.tamanho = new Size(50, 50);
            //inputImage(caminho_imagem);
        }

        public Objeto2D(string caminho_imagem)
        {
            this.angulo = 0;
            this.progressao = 0;
            this.tag = string.Empty;
            this.caminho_imagem = string.Empty;
            this.posicao = new Point(0, 0);
            this.tamanho = new Size(50, 50);
            inputImage(caminho_imagem);
        }

        public Objeto2D(string caminho_imagem, Size tamanho, Point posicao)
        {
            this.angulo = 0;
            this.progressao = 0;
            this.tag = string.Empty;
            this.caminho_imagem = caminho_imagem;
            this.posicao = posicao;
            this.tamanho = tamanho;
            inputImage(caminho_imagem, tamanho);
        }

        public Objeto2D(int progressao, string caminho_imagem, Size tamanho, Point posicao)
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
        // métodos
        //

        public virtual Rectangle getRectangle()
        {
            return new Rectangle(posicao, tamanho);
        }

        public virtual void inputImage(string caminho)
        {
            this.imagem = new Bitmap(this.caminho_imagem = caminho_imagem);
        }

        public virtual void inputImage(string caminho_imagem, Size tamanho)
        {
            this.imagem = UtilImage.resizeImage(
                new Bitmap(this.caminho_imagem = caminho_imagem),
                this.tamanho = tamanho);
        }

    }// clas
}// namespace
