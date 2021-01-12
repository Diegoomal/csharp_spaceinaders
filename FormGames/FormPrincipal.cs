/*
    Links:
        http://seumestredaweb.blogspot.com.br/2012/06/java-games-2d-tutorial-parte-9.html

        http://pt.stackoverflow.com/questions/20962/como-fazer-colis%C3%A3o-em-jogo-com-java-2d-plataforma
        http://programadorprofissional.blogspot.com.br/2012/08/verificando-colisoes-entre-sprites.html
        http://seumestredaweb.blogspot.com.br/2012/06/java-games-2d-tutorial-parte-10.html

        https://social.msdn.microsoft.com/Forums/pt-BR/b7a33b8a-1313-4295-9d09-07fb4a58cd7d/girar-imagem?forum=vscsharppt
*/

using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace FormGames
{
    enum resolucaoTela
    {
        // link: https://msdn.microsoft.com/pt-br/library/sbbt4032.aspx
        resolucao240x144,
        resolucao320x240,
        resolucao400x300,
        resolucao512x384,
        resolucao640xx480,
        resolucao800x600,
        resolucao1024x768,
        resolucao1152x864,
        resolucao1280x960,
        resolucao1600x1200,
        resolucao2048x1536
    }

    public partial class FormPrincipal : Form, IGame
    {
        //
        // Variáveis e instâncias de objetos
        //

        //int nAlturaTela = 1024;
        //int nLarguraTela = 768;

        //int nAlturaTela = 480;
        //int nLarguraTela = 640;

        int nAlturaTela = EstaticosProjeto.altura;
        int nLarguraTela = EstaticosProjeto.largura;

        System.Windows.Forms.Timer timerJogo = null;

        Image imgbackground;

        Nave nave = null;
        List<Invader> invaders = null;
        public static List<Tiro> tiros = new List<Tiro>();

        Dictionary<Keys, IStrategyKeyDown> dictionaryKeyDown = null;

        // variáveis voltadas ao controle das threads
        public volatile bool flgThreadDraw = true;
        public volatile bool flgThreadUpdate = true;

        public int nTimeSleepThread = 50;

        public Thread t_desenha = null;
        public Thread t_update = null;

        private List<Keys> pressedKeys = new List<Keys>();          // lista para captura das teclas

        //
        // Construtor
        //

        public FormPrincipal()
        {
            InitializeComponent();

            //
            //
            //

            this.Width = nLarguraTela;
            this.Height = nAlturaTela;

            this.MinimumSize = new Size(nLarguraTela, nAlturaTela);
            this.MaximumSize = new Size(nLarguraTela, nAlturaTela);

            this.StartPosition = FormStartPosition.CenterScreen;

            this.Text = EstaticosProjeto.nome_jogo + " " + EstaticosProjeto.versao_jogo;

            this.KeyUp += evento_keyup;
            this.KeyDown += evento_keydown;
            
            // imagem redimensionada
            imgbackground = UtilImage.resizeImage(
                new Bitmap(EstaticosProjeto.caminho_background),
                new Size(nLarguraTela, nAlturaTela));
            
            // eventos do teclado
            dictionaryKeyDown = dictionaryTeclas();

            //
            invaders = lista_de_asteroides2();

            // cria objetos 2D que serão "printados" na tela
            int posicao_inicial_nave_x = (nLarguraTela / 2) - 25;
            int posicao_inicial_nave_y = nAlturaTela - (nAlturaTela / 3);

            nave = new Nave(5, EstaticosProjeto.caminho_nave, new Size(50, 50),
                new Point(posicao_inicial_nave_x, posicao_inicial_nave_y));
            
            //
            t_desenha = new Thread(thread_desenha);
            t_desenha.Start();

            t_update = new Thread(thread_update_async);
            t_update.Start();
        }

        //
        // Métodos
        //

        private int gera_randomico_limites(int min, int max)
        {
            Random rnd = new Random();
            return rnd.Next(min, max);
        }

        private List<Invader> lista_de_asteroides()
        {
            List<Invader> _asteroides = new List<Invader>();

            _asteroides.Add(new Invader(2, EstaticosProjeto.caminho_asteroid, new Size(30, 30), new Point(120, 50)));
            _asteroides.Add(new Invader(2, EstaticosProjeto.caminho_asteroid, new Size(30, 30), new Point(120, 90)));
            _asteroides.Add(new Invader(2, EstaticosProjeto.caminho_asteroid, new Size(30, 30), new Point(120, 130)));
            _asteroides.Add(new Invader(2, EstaticosProjeto.caminho_asteroid, new Size(30, 30), new Point(120, 170)));

            return _asteroides;
        }

        private List<Invader> lista_de_asteroides2()
        {
            List<Invader> _asteroides = new List<Invader>();

            _asteroides.Add(new Invader(2, EstaticosProjeto.caminho_invader, new Size(30, 30), new Point(120, 50),  10, 60));
            _asteroides.Add(new Invader(2, EstaticosProjeto.caminho_invader, new Size(30, 30), new Point(120, 90),  10, 60));
            _asteroides.Add(new Invader(2, EstaticosProjeto.caminho_invader, new Size(30, 30), new Point(120, 130), 10, 80));
            _asteroides.Add(new Invader(2, EstaticosProjeto.caminho_invader, new Size(30, 30), new Point(120, 170), 10, 120));

            return _asteroides;
        }

        private List<Invader> lista_de_asteroides3()
        {
            List<Invader> _asteroides = new List<Invader>();

            //_asteroides.Add(new Asteroide(2, StringsProjeto.caminho_asteroid, new Size(30, 30), new Point(120, 50), 10, 60));
            //_asteroides.Add(new Asteroide(2, StringsProjeto.caminho_asteroid, new Size(30, 30), new Point(120, 90), 10, 60));
            //_asteroides.Add(new Asteroide(2, StringsProjeto.caminho_asteroid, new Size(30, 30), new Point(120, 130), 10, 80));
            //_asteroides.Add(new Asteroide(2, StringsProjeto.caminho_asteroid, new Size(30, 30), new Point(120, 170), 10, 120));

            for (int i = 0; i < 4; i++)
            {
                int nLmtMnmTela = gera_randomico_limites(10, 60);
                int nLmtMxmTela = gera_randomico_limites(10, 60);

                int nPosicaoX = 120;
                int nPosicaoY = gera_randomico_limites(40, 150);

                _asteroides.Add(new Invader(2, EstaticosProjeto.caminho_asteroid, new Size(30, 30),
                    new Point(nPosicaoX, nPosicaoY), nLmtMnmTela, nLmtMxmTela));
            }                

            return _asteroides;
        }

        private Dictionary<Keys, IStrategyKeyDown> dictionaryTeclas()
        {
            Dictionary<Keys, IStrategyKeyDown>  dictionaryKeyDown = new Dictionary<Keys, IStrategyKeyDown>();

            //dictionaryKeyDown.Add(Keys.Up, new KeyDown_UP());
            //dictionaryKeyDown.Add(Keys.Down, new KeyDown_DOWN());
            //dictionaryKeyDown.Add(Keys.Left, new KeyDown_LEFT());
            //dictionaryKeyDown.Add(Keys.Right, new KeyDown_RIGHT());
            //dictionaryKeyDown.Add(Keys.Space, new KeyDown_SPACE());

            dictionaryKeyDown.Add(Keys.W, new KeyDown_UP());
            dictionaryKeyDown.Add(Keys.S, new KeyDown_DOWN());
            dictionaryKeyDown.Add(Keys.A, new KeyDown_LEFT());
            dictionaryKeyDown.Add(Keys.D, new KeyDown_RIGHT());
            dictionaryKeyDown.Add(Keys.Space, new KeyDown_SPACE());

            return dictionaryKeyDown;
        }

        private void formata_texto_score()
        {
            //label_score.ForeColor = Color.Red;
            //label_score.PointToScreen(new Point(0, 0));
            //label_score.Font = new Font(new FontFamily("Arial"), 22, FontStyle.Regular);
        }

        //
        // Métodos para rodarem threads
        //

        private void thread_desenha()
        {
            while (flgThreadDraw)
            {
                lock (t_desenha)
                {   
                    Thread.Sleep(nTimeSleepThread);
                    
                    this.CreateGraphics().DrawImage(imgbackground, new Point(0, 0));

                    this.CreateGraphics().DrawImage(nave.imagem, nave.posicao);

                    try
                    {
                        foreach (Invader invader in invaders)
                            this.CreateGraphics().DrawImage(invader.imagem, invader.posicao);

                        foreach (Tiro t in tiros)
                            this.CreateGraphics().DrawImage(t.imagem, t.posicao);
                    }
                    catch (Exception ex)
                    {
                        //
                        // sempre dando exception:
                        //  solução tecnica, passar por cima dele
                        //
                    }
                }// lock
            }// while
        }

        private void thread_update_async()
        {
            while (flgThreadUpdate)
            {
                lock (t_update)
                {
                    // tecla capturada
                    //foreach (var item in dictionaryKeyDown)
                    //    if (item.Key.ToString().Equals(sKeyCapturada))
                    //    {
                    //        sKeyCapturada = string.Empty;
                    //        object objNave = nave;
                    //        item.Value.processar(ref objNave);
                    //        nave = (Nave)objNave;
                    //    }

                    // sem teclas pressionadas
                    if (pressedKeys.Count == 0)
                    {
                        //player.parado();
                    }

                    ////houve conjunto de teclas pressionadas
                    //else if (pressedKeys.Contains(Keys.W)
                    //    && pressedKeys.Contains(Keys.D))
                    //{
                    //    //nave.up(); nave.right();
                    //    nave.diagonal_superior_direita();
                    //}
                    //else if (pressedKeys.Contains(Keys.W)
                    //    && pressedKeys.Contains(Keys.A))
                    //{
                    //    //nave.up(); nave.left();
                    //    nave.diagonal_superior_esquerda();
                    //}
                    //else if (pressedKeys.Contains(Keys.S)
                    //    && pressedKeys.Contains(Keys.A))
                    //{
                    //    //nave.down(); nave.left();
                    //    nave.diagonal_inferior_esquerda();
                    //}
                    //else if (pressedKeys.Contains(Keys.S)
                    //    && pressedKeys.Contains(Keys.D))
                    //{
                    //    //nave.down(); nave.right();
                    //    nave.diagonal_inferior_direita();
                    //}

                    // apenas teclas simples pressionadas
                    else if (pressedKeys.Contains(Keys.W))
                    {
                        // diagonais
                        if (pressedKeys.Contains(Keys.A))
                            nave.left();
                        else if (pressedKeys.Contains(Keys.D))
                            nave.right();
                         
                        nave.up();
                    }
                    else if (pressedKeys.Contains(Keys.S))
                    {
                        // diagonais
                        if (pressedKeys.Contains(Keys.A))
                            nave.left();
                        else if (pressedKeys.Contains(Keys.D))
                            nave.right();

                        nave.down();
                    }
                    else if (pressedKeys.Contains(Keys.A))
                    {
                        nave.left();
                    }
                    else if (pressedKeys.Contains(Keys.D))
                    {
                        nave.right();
                    }

                    if (pressedKeys.Contains(Keys.Space))
                    {
                        nave.space();
                    }

                    Thread.Sleep(nTimeSleepThread);
                    
                    VerificarColisao.colisao_objtos(
                        t_update, ref nave, ref invaders, ref tiros);

                    // movimenta objetos2d
                    foreach (Invader invader in invaders)
                        invader.mover(this);

                    foreach (Tiro tiro in tiros)
                        tiro.mover(null);

                    //this.Text = "tiros disparados " + tiros.Count.ToString();
                }// lock
            }// while
        }

        //
        // Eventos
        //
        
        private void desenha(object sender, EventArgs e)
        {
            // travar a thread melhora em questao das imagens ficarem 'piscando'
            lock (this)
            {
                //this.CreateGraphics().Clear(Color.FromArgb(240, 240, 240));
                this.CreateGraphics().DrawImage(imgbackground, new Point(0, 0));

                this.CreateGraphics().DrawImage(nave.imagem, nave.posicao);

                foreach (Invader asteroide in invaders)
                    this.CreateGraphics().DrawImage(asteroide.imagem, asteroide.posicao);

                foreach (Tiro t in tiros)
                    this.CreateGraphics().DrawImage(t.imagem, t.posicao);
            }
        }

        private void update_async(object sender, EventArgs e)
        {
            //VerificarColisao.colisao_objtos(this, ref nave, ref asteroides, ref tiros);

            // movimenta objetos2d
            foreach (Invader asteroide in invaders)
                asteroide.mover(this);

            foreach (Tiro tiro in tiros)
                tiro.mover(null);

            //this.Text = "tiros disparados " + tiros.Count.ToString();
        }      
        
        /// <summary>
        ///     só age quando algum botao é pressionado
        /// </summary>
        /// <param name="sender">   sem serventia por hora                  </param>
        /// <param name="e">        para capturar as teclas pressionadas    </param>
        private void evento_keydown(object sender, KeyEventArgs e)
        {
            //lock (t_update)
            //{
            //    //Thread.Sleep(nTimeSleepThread);
            //    //atualiza posicação do objeto conforme usuário pressiona o botao
            //    foreach (var item in dictionaryKeyDown)
            //        if (item.Key.Equals(e.KeyCode))
            //        {
            //            object objNave = nave;
            //            item.Value.processar(ref objNave);
            //            nave = (Nave)objNave;
            //        }
            //}

            //sKeyCapturada = e.KeyCode.ToString();

            pressedKeys.Add(e.KeyCode);
        }

        private void evento_keyup(object sender, KeyEventArgs e)
        {
            if (pressedKeys.Count >= 1)
                pressedKeys.Clear();
        }

        //
        //
        //

        //private void Paint(PaintEventArgs e)
        //{
        //    Font font = new Font(new FontFamily("Arial"), 22, FontStyle.Regular);
        //    e.Graphics.DrawString(string.Format("Score: {0}", nave.nPontuacao), 
        //        font, Brushes.Red, new Point(0, 0));
        //}

        //private void Paint(object sender, PaintEventArgs e)
        //{
        //    string strScore = string.Format("Score: {0}", nave.nPontuacao);
        //    Font font = new Font(new FontFamily("Arial"), 22, FontStyle.Regular);            
        //    e.Graphics.DrawString(strScore, font, Brushes.Red, new Point(0, 0));
        //}

        protected override void OnClosed(EventArgs e)
        {
            //Application.Exit();
            //thread_desenha.Close();
            //thread_desenha.Dispose();
            //thread_update_async.Close();
            //thread_update_async.Dispose();

            // Cortam o loop while das thread deixando terminar a execução
            flgThreadDraw = false;
            flgThreadUpdate = false;
            Thread.Sleep(100);
            
            //
            base.OnClosed(e);
        }

    }// class
}// namespace
