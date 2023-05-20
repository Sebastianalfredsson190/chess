using ChessLib;
using Microsoft.Diagnostics.Tracing.Parsers.MicrosoftWindowsTCPIP;
using Rudzoft.ChessLib.Factories;
using Rudzoft.ChessLib.MoveGeneration;

namespace Chess
{
    public partial class Form1 : Form
    {
        public string fromPos = "";
        public string toPos = "";
        public List<string> avalibleMoves = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void FirstClick(object sender)
        {
            clearBoard();

            const string startFen = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";

            //const string fen = "rnbqkbnr/1ppQpppp/p2p4/8/8/2P5/PP1PPPPP/RNB1KBNR b KQkq - 1 6";

            var game = GameFactory.Create(startFen);

            Button b = (Button)sender;

            var moveList = game.Pos.GenerateMoves();

            Image myimage = new Bitmap(@"C:\Users\sebastian.alfredsso\Pictures\Grey-dot.png");

            //var currentPlayer = game.CurrentPlayer;

            string t2 = "";

            string t1 = "";


            for (int i = 0; i < moveList.Length; i++)
            {

                var move = moveList[i].Move;

                var t = move.ToString();

                t1 = t.Substring(0, 2);

                t2 = t.Substring(2);

                var destination = (Button)this.Controls[t2];


                if (t1 == b.Name)
                {
                    avalibleMoves.Add(t2);

                    destination.BackgroundImage = myimage;

                    if
                    fromPos = t1;


                }
            }

            

            //game.Pos.MakeMove(moveList[0], game.Pos.State);
        }

        private void SecondClick(object sender)
        {
            Button b = (Button)sender;

            for (var i = 0; i < avalibleMoves.Count; i++)
            {
                if (b.Name == avalibleMoves[i])
                {
                    clearBoard();
                    var firstButton = (Button)this.Controls[fromPos];
                    b.BackgroundImage = firstButton.BackgroundImage;
                    firstButton.BackgroundImage = null; 
                }
            }
        }




        private void buttonClick(object sender, EventArgs e)
        {
            


            if (fromPos.Length > 0)
            {
                SecondClick(sender);
            } 
            else
            {
                FirstClick(sender);
            }
            

        }


        private void clearBoard()
        {


            for(int i = 0; i < avalibleMoves.Count; i++)
            {
                var move = avalibleMoves[i];

                foreach (var button in this.Controls.OfType<Button>())
                {
                    if (button.Name == move)
                    {
                        button.BackgroundImage = null;
                    }
                }
            }
        }


        private void label29_Click(object sender, EventArgs e)
        {

        }

  
    }
}