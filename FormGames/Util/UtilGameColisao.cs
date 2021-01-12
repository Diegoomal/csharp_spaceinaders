using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Drawing;

namespace FormGames
{
    public class UtilGameColisao
    {

        public static bool colisaoTirosRect(List<Point> tiros, Objeto2D obj)
        {
            //Rectangle r1 = new Rectangle(player.posicaoAtual, player.tamanho);

            List<Rectangle> lstRect = new List<Rectangle>();
            foreach (var item in tiros)
                lstRect.Add(new Rectangle(item, new Size(2, 5)));
            
            Rectangle r2 = new Rectangle(obj.posicao, obj.tamanho);

            foreach (var item in lstRect)
            {
                if (item.IntersectsWith(r2))
                    return true;
            }           

            return false;
        }

        public static bool colisaoRect(Objeto2D obj1, Objeto2D obj2)
        {
            Rectangle r1 = new Rectangle(obj1.posicao, obj1.tamanho);
            Rectangle r2 = new Rectangle(obj2.posicao, obj2.tamanho);

            if (r1.IntersectsWith(r2))
                return true;

            return false;
        }

        public static bool colisao(int obj1X, int obj1Y, int obj1W, int obj1H, int obj2X, int obj2Y, int obj2W, int obj2H)
        {          
            if ((obj1X >= obj2X && obj1X <= obj2X + obj2W) && (obj1Y >= obj2Y && obj1Y <= obj2Y + obj2H))
            {
                return true;
            }
            else if ((obj1X + obj1W >= obj2X && obj1X + obj1W <= obj2X + obj2W)
                && (obj1Y >= obj2Y && obj1Y <= obj2Y + obj2H))
            {
                return true;
            }
            else if ((obj1X >= obj2X && obj1X <= obj2X + obj2W)
                && (obj1Y + obj1H >= obj2Y && obj1Y + obj1H <= obj2Y + obj2H))
            {
                return true;
            }
            else if ((obj1X + obj1W >= obj2X && obj1X + obj1W <= obj2X + obj2W)
                && (obj1Y + obj1H >= obj2Y && obj1Y + obj1H <= obj2Y + obj2H))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool colisao(Objeto2D player, Objeto2D obj)
        {
            int obj1X = player.posicao.X;
            int obj1Y = player.posicao.Y;
            int obj1W = player.tamanho.Width;
            int obj1H = player.tamanho.Height;

            int obj2X = obj.posicao.X;
            int obj2Y = obj.posicao.Y;
            int obj2W = obj.tamanho.Width;
            int obj2H = obj.tamanho.Height;

            if ((obj1X >= obj2X && obj1X <= obj2X + obj2W) && (obj1Y >= obj2Y && obj1Y <= obj2Y + obj2H))
                return true;

            else if ((obj1X + obj1W >= obj2X && obj1X + obj1W <= obj2X + obj2W)
                && (obj1Y >= obj2Y && obj1Y <= obj2Y + obj2H))
                return true;

            else if ((obj1X >= obj2X && obj1X <= obj2X + obj2W)
                && (obj1Y + obj1H >= obj2Y && obj1Y + obj1H <= obj2Y + obj2H))
                return true;

            else if ((obj1X + obj1W >= obj2X && obj1X + obj1W <= obj2X + obj2W)
                && (obj1Y + obj1H >= obj2Y && obj1Y + obj1H <= obj2Y + obj2H))
                return true;

            else
                return false;
        }

        public static int ColisaoPorPixel(object objeto1, object objeto2)
        {
            //
            // link: http://pt.stackoverflow.com/questions/20962/como-fazer-colis%C3%A3o-em-jogo-com-java-2d-plataforma
            //
            //retorna 0 se não houve colisão, ou 1 se houve colisão
            //

            ////Define os pontos corners dos objetos
            //left1 = objeto1.x;
            //left2 = objeto2.x;
            //right1 = objeto1.x + object1.largura;
            //right2 = objeto2.x + object2.largura;
            //top1 = objeto1.y;
            //top2 = objeto2.y;
            //bottom1 = objeto1.y + object1.altura;
            //bottom2 = objeto2.y + object2.altura;

            ///*Teste de rejeição para colisão de polígonos circundantes*/
            //if (bottom1 < top2) returna(0);
            //if (top1 > bottom2) returna(0);

            //if (right1 < left2) returna(0);
            //if (left1 > right2) returna(0);


            ///*Se chegamos aqui é porque pode haver colisão, descubra o retângulo de sobreposição*/
            //if (bottom1 > bottom2)
            //    over_bottom = bottom2;
            //else
            //    over_bottom = bottom1;

            //if (top1 < top2)
            //    over_top = top2;
            //else
            //    over_top = top1;

            //if (right1 > right2)
            //    over_right = right2;
            //else
            //    over_right = right1;

            //if (left1 < left2)
            //    over_left = left2;
            //else
            //    over_left = left1;


            //// Agora situa as áreas de comparação nos dois objetos
            //i = ((over_top – objeto1.y) *objeto1.largura) +over_left;
            //pixel1 = objeto1.frames[objeto1.curr_frame] + i;

            //j = ((over_top - objeto2.y) * objeto2.largura) + over_left;
            //pixel2 = objeto2.frames[objeto2.curr_frame] + j;

            ///* Agora começa a varrer todos o retângulo de sobreposição, testando se o correspondente pixel de 
            //     cada bitmap de cada objeto,para ver se ambos são  
            //     diferentes de zero
            //     */

            //for (i = 0; i < over_height; i++)
            //{
            //    for (j = 0; j < over_width; j++)
            //    {
            //        if (objeto1[pixel1].cor > 0) && (objeto2[pixel2].cor > 0)
            //        {
            //            //houve colisão
            //            return (1);
            //        }
            //        pixel1++;
            //        pixel2++;
            //    }
            //    pixel1 += (objeto1.largura - over_width);
            //    pixel2 += (objeto2.largura - over_width);
            //}

            ///* Pior caso do algoritmo!  Varremos o retângulo de sobreposição e não encontramos nenhuma colisão*/

            return (0);
        }

        public static bool ColisaoPorPixel(Objeto2D objeto1, Objeto2D objeto2)
        {
            ////Define os pontos corners dos objetos

            int left1 = objeto1.posicao.X;
            int left2 = objeto2.posicao.Y;
            int right1 = objeto1.posicao.X + objeto1.tamanho.Width;
            int right2 = objeto2.posicao.X + objeto2.tamanho.Width;

            int top1 = objeto1.posicao.Y;
            int top2 = objeto2.posicao.Y;
            int bottom1 = objeto1.posicao.Y + objeto1.tamanho.Height;
            int bottom2 = objeto2.posicao.Y + objeto2.tamanho.Height;

            ///*Teste de rejeição para colisão de polígonos circundantes*/
            if (bottom1 < top2) return false;
            if (top1 > bottom2) return false;

            if (right1 < left2) return false;
            if (left1 > right2) return false;

            ///*Se chegamos aqui é porque pode haver colisão, descubra o retângulo de sobreposição*/
            int over_bottom = 0, over_top = 0, over_right = 0, over_left = 0;

            if (bottom1 > bottom2)
                over_bottom = bottom2;
            else
                over_bottom = bottom1;

            if (top1 < top2)
                over_top = top2;
            else
                over_top = top1;

            if (right1 > right2)
                over_right = right2;
            else
                over_right = right1;

            if (left1 < left2)
                over_left = left2;
            else
                over_left = left1;

            // Agora situa as áreas de comparação nos dois objetos
            int i = ((over_top - objeto1.posicao.Y) * objeto1.tamanho.Width) + over_left;
            //int pixel1 = objeto1.frames[objeto1.curr_frame] + i;

            int j = ((over_top - objeto2.posicao.Y) * objeto2.tamanho.Width) + over_left;
            //pixel2 = objeto2.frames[objeto2.curr_frame] + j;

            /* 
                Agora começa a varrer todos o retângulo de sobreposição, testando se o correspondente pixel de 
                cada bitmap de cada objeto,para ver se ambos são  
                diferentes de zero
            */

            int over_height = 0;
            int over_width = 0;

            //for (i = 0; i < over_height; i++)
            //{
            //    for (j = 0; j < over_width; j++)
            //    {
            //        if (objeto1[pixel1].cor > 0) && (objeto2[pixel2].cor > 0)                        
            //            return true;    //houve colisão
            //        pixel1++;
            //        pixel2++;
            //    }
            //    pixel1 += (objeto1.largura - over_width);
            //    pixel2 += (objeto2.largura - over_width);
            //}

            ///* Pior caso do algoritmo!  Varremos o retângulo de sobreposição e não encontramos nenhuma colisão*/

            return false;
        }

    }
}


/*
    private void buttonColisoes_Click(object sender, EventArgs e)
    {
        Sprite policia = new Sprite();
        policia.x = 10;                   
        policia.y = 10;
        policia.w = 10;
        policia.h = 10;

        Sprite ladrao = new Sprite();
        ladrao.x = 20;
        ladrao.y = 20;
        ladrao.w = 30;
        ladrao.h = 30;

        //todos os dois objetos possuem o metodo colideCom
        if (policia.colideCom(ladrao))
            MessageBox.Show("Test colidiu");
        else
            MessageBox.Show("Test nao colidiu");
    }

    public class Sprite
    {
        //link: http://programadorprofissional.blogspot.com.br/2012/08/verificando-colisoes-entre-sprites.html

        public int x;   // posição do vertice superior esquerdo no eixo horizontal
        public int y;   // posição do vertice superior esquerdo no eixo vertical
        public int w;   // largura do retangulo
        public int h;   // altura do retangulo

        //verifica colisão
        public bool colideCom(Sprite outro)
        {
            Rectangle r1 = new Rectangle(x, y, w, h);                           //esse sprite
            Rectangle r2 = new Rectangle(outro.x, outro.y, outro.w, outro.h);   // 

            if (r1.IntersectsWith(r2))
                return true;
            return false;
        }

    }

*/
