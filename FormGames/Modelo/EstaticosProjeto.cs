using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace FormGames
{
    //public static class StringsProjeto
    //{
    //    public const string caminho_nave = @"C:\Users\diego maldonado\documents\visual studio 2015\Projects\FormGames\FormGames\Resources\imgs\naves\alienblaster.png";
    //    public const string caminho_missel = @"C:\Users\diego maldonado\documents\visual studio 2015\Projects\FormGames\FormGames\Resources\imgs\misseis\missel.png";
    //    public const string caminho_explosao = @"C:\Users\diego maldonado\documents\visual studio 2015\Projects\FormGames\FormGames\Resources\imgs\explosoes\explosao2.png";
    //    public const string caminho_asteroid = @"C:\Users\diego maldonado\documents\visual studio 2015\Projects\FormGames\FormGames\Resources\imgs\asteroids\asteroid2.png";
    //    public const string caminho_background = @"C:\Users\diego maldonado\Documents\Visual Studio 2015\Projects\FormGames\FormGames\Resources\imgs\background\backgroud.png";
    //}// public static class StringsProjeto


    public class EstaticosProjeto
    {
        public static int altura = 640;
        public static int largura = 480;

        public static string caminho_nave       =   UtilSDK.pega_caminho() + @"\Resources\imgs\naves\alienblaster.png";
        public static string caminho_missel     =   UtilSDK.pega_caminho() + @"\Resources\imgs\misseis\missel.png";
        public static string caminho_explosao   =   UtilSDK.pega_caminho() + @"\Resources\imgs\explosoes\explosao2.png";
        public static string caminho_asteroid   =   UtilSDK.pega_caminho() + @"\Resources\imgs\asteroids\asteroid2.png";
        public static string caminho_background =   UtilSDK.pega_caminho() + @"\Resources\imgs\background\backgroud.png";
        public static string caminho_invader    =   UtilSDK.pega_caminho() + @"\Resources\imgs\invaders\invader.png";

        public static string versao_jogo = "v0.1";
        public static string nome_jogo = "Space Invaders";


        public static Image imgExplosao = UtilImage.resizeImage(new Bitmap(caminho_explosao), new Size(50, 50));

        //
        // Métodos
        //

        public static void printa_score_na_tela(Form form, int nPontuacao)
        {
            Font font = new Font(new FontFamily("Arial"), 22, FontStyle.Regular);
            
        }

    }// public static class StringsProjeto
}// namespace
