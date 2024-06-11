using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace РГР
{
    public partial class Form1 : Form
    {

        public int playerCount = 2;
        private Player[] players;
        private Deck deck = new Deck();
        public string trump;
        public string trumpSuit;
        List<Control> playMenu = new List<Control> { };
        List<Control> lables = new List<Control> { };
        public int entrance = 0;
        private Player attacker;
        private Player deffenser;
        List<Card> playingCards = new List<Card>();
        public int rounds = 1;
        public int passed = 0;
        public Form1()
        {
            InitializeComponent();

            players = new Player[6];
            for (int i = 0; i < players.Length; i++)
            {
                players[i] = new Player { name = "Player" + i };
            }
            playMenu = new List<Control> { lbl1, lblTrump, lbCards, btnPlayCard, label3, label4, label5, label6,
                label7, label8, label9, label13, label10, label12, label11, label15, label14, label17, label16,
                label19, label18, label20, label21, label22, label23, label24, label25, label26, label27, label28,
                label29, label30, label32, label33, label31 };
            foreach (var control in playMenu)
            {
                control.Visible = false;
            }
            lables = new List<Control> {label20, label21, label22, label23, label24, label25, label26, label27, label28,
                label29, label30};
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn2players_Click(object sender, EventArgs e)
        {
            lblPlayers.Text = "2";
            playerCount = 2;
        }

        private void btn3players_Click(object sender, EventArgs e)
        {
            lblPlayers.Text = "3";
            playerCount = 3;
        }

        private void btn4players_Click(object sender, EventArgs e)
        {
            lblPlayers.Text = "4";
            playerCount = 4;
        }

        private void btn5players_Click(object sender, EventArgs e)
        {
            lblPlayers.Text = "5";
            playerCount = 5;
        }

        private void btn6players_Click(object sender, EventArgs e)
        {
            lblPlayers.Text = "6";
            playerCount = 6;
        }

        private void btnStartGame_Click(object sender, EventArgs e)
        {
            players[playerCount - 1].lastPlayer = true;
            int number = 0;
            deck.ShaffleDeck();
            trump = deck.cardsShaffle[35].CardSuit + " " + deck.cardsShaffle[35].CardRank;
            trumpSuit = deck.cardsShaffle[35].CardSuit;
            foreach (var player in players)
            {
                if (number < playerCount)
                {
                    player.hand = new List<Card> { };
                    for (int i = 0; i < 6; i++)
                    {
                        player.hand.Add(deck.cardsShaffle[0]);
                        deck.cardsShaffle.Remove(deck.cardsShaffle[0]);
                    }
                    //foreach (var item in player.hand)
                    //{
                    //    Console.WriteLine(item.CardSuit + " " + item.CardRank + " " + item.CardPower);
                    //}
                    //Console.WriteLine("");

                    number++;
                }
            }

            List<Control> startMenu = new List<Control> { btn2players, btn3players, btn4players, btn5players, btn6players, btnStartGame, label1, label2, lblPlayers };
            foreach (var control in startMenu)
            {
                control.Visible = false;
            }
            lblTrump.Text = trump;

            foreach (var control in playMenu)
            {
                control.Visible = true;
            }

            lbCards.Items.Add("Чекати .");
            lbCards.Items.Add("Пас");
            foreach (var i in players[0].hand)
            {
                string elem = i.CardSuit + " " + i.CardRank;
                lbCards.Items.Add(elem);
            }

            label33.Text = deck.cardsShaffle.Count.ToString();
        }

        private void lblTrump_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnPlayCard_Click(object sender, EventArgs e)//start
        {
            attacker = players[entrance % playerCount];
            deffenser = players[(entrance + 1) % playerCount];
            label33.Text = deck.cardsShaffle.Count.ToString();
            lblPass.Text = "";
            Console.WriteLine(attacker.name + " " + deffenser.name);
            if (lbCards.SelectedItem != null)
            {
                if (attacker == players[0])
                {
                    label7.Text = deffenser.name;
                    label5.Text = "Ваш";
                    if (rounds == 1)
                    {

                        string words = lbCards.SelectedItem.ToString();
                        string[] word = words.Split(' ');
                        if (word[0] != "Пас")
                        {
                            Card currentCard = new Card { CardRank = word[1], CardSuit = word[0] };
                            currentCard.CardPower = currentCard.CheckRank(currentCard.CardRank);//метод щоб зробити power

                            playingCards.Add(currentCard);
                            label20.Text = playingCards.Last().CardSuit + " " + playingCards.Last().CardRank;
                            lbCards.Items.Remove(lbCards.SelectedItem);
                            foreach (var item in players[0].hand.ToList())
                            {
                                if (item.CardSuit == currentCard.CardSuit && item.CardRank == currentCard.CardRank)
                                {
                                    //Console.WriteLine("Видалено");
                                    players[0].hand.Remove(item);
                                }
                            }

                            if (currentCard.CardSuit == trumpSuit) //чи карта э козирем
                            {
                                int i = 0;
                                bool hasPlayableCard = false;
                                foreach (var cardP in players[1].hand.ToList())
                                {
                                    if (cardP.CardPower > currentCard.CardPower && cardP.CardSuit == trumpSuit)
                                    {
                                        // чи карта переможе
                                        label21.Text = cardP.CardSuit + " " + cardP.CardRank;
                                        players[1].hand.Remove(cardP);
                                        playingCards.Add(cardP);
                                        rounds++;
                                        hasPlayableCard = true;
                                        break;
                                    }
                                    i++;
                                }

                                // якщо цикл завершився і не було знайдено жодної підходящої карти
                                if (!hasPlayableCard)
                                {
                                    foreach (var item in playingCards.ToList())
                                    {
                                        players[1].hand.Add(item);
                                        playingCards.Remove(item);
                                    }
                                    lblPass.Text = "Противник спасував!";
                                    entrance++;
                                    rounds = 1;
                                    foreach (var item in lables)
                                    {
                                        item.Text = "-";
                                    }
                                    while (true)//добір карт
                                    {
                                        try
                                        {
                                            if (players[0].hand.Count < 6)
                                            {
                                                for (int o = 0; o < 6; o++)
                                                {
                                                    players[0].hand.Add(deck.cardsShaffle[0]);
                                                    deck.cardsShaffle.Remove(deck.cardsShaffle[0]);
                                                }
                                            }
                                            else
                                            {
                                                break;
                                            }
                                        }
                                        catch
                                        {
                                            break;
                                        }
                                    }

                                }

                            }
                            else
                            {
                                int i = 0;
                                bool hasPlayableCard = false;
                                foreach (var cardP in players[1].hand.ToList())
                                {
                                    if ((cardP.CardPower > currentCard.CardPower && cardP.CardSuit == currentCard.CardSuit) || cardP.CardSuit == trumpSuit)
                                    {
                                        // чи карта переможе
                                        label21.Text = cardP.CardSuit + " " + cardP.CardRank;
                                        players[1].hand.Remove(cardP);
                                        playingCards.Add(cardP);
                                        rounds++;
                                        hasPlayableCard = true;
                                        break;
                                    }
                                    i++;
                                }

                                // якщо цикл завершився і не було знайдено жодної підходящої карти
                                if (!hasPlayableCard)
                                {
                                    foreach (var item in playingCards.ToList())
                                    {
                                        players[1].hand.Add(item);
                                        playingCards.Remove(item);
                                    }
                                    lblPass.Text = "Противник спасував!";
                                    entrance++;
                                    rounds = 1;
                                    foreach (var item in lables)
                                    {
                                        item.Text = "-";
                                    }
                                    while (true)//добір карт
                                    {
                                        try
                                        {
                                            if (players[0].hand.Count < 6)
                                            {
                                                for (int o = 0; o < 6; o++)
                                                {
                                                    players[0].hand.Add(deck.cardsShaffle[0]);
                                                    deck.cardsShaffle.Remove(deck.cardsShaffle[0]);
                                                }
                                            }
                                            else
                                            {
                                                break;
                                            }
                                        }
                                        catch
                                        {
                                            break;
                                        }
                                    }

                                }

                            }

                        }
                        else //якщо Пас 1 раунд
                        {

                        }
                    }
                    else
                    {
                        if (rounds == 2)///////////////////2 round
                        {
                            string words = lbCards.SelectedItem.ToString();
                            string[] word = words.Split(' ');
                            if (word[0] != "Пас")
                            {
                                Card currentCard = new Card { CardRank = word[1], CardSuit = word[0] };
                                currentCard.CardPower = currentCard.CheckRank(currentCard.CardRank);//метод щоб зробити power

                                if (currentCard.CardPower == playingCards[0].CardPower || currentCard.CardPower == playingCards[1].CardPower)
                                {
                                    playingCards.Add(currentCard);
                                    label23.Text = playingCards.Last().CardSuit + " " + playingCards.Last().CardRank;
                                    lbCards.Items.Remove(lbCards.SelectedItem);
                                    foreach (var item in players[0].hand.ToList())
                                    {
                                        if (item.CardSuit == currentCard.CardSuit && item.CardRank == currentCard.CardRank)
                                        {
                                            //Console.WriteLine("Видалено");
                                            players[0].hand.Remove(item);
                                        }
                                    }

                                    if (currentCard.CardSuit == trumpSuit) //чи карта э козирем
                                    {
                                        int i = 0;
                                        bool hasPlayableCard = false;
                                        foreach (var cardP in players[1].hand.ToList())
                                        {
                                            if (cardP.CardPower > currentCard.CardPower && cardP.CardSuit == trumpSuit)
                                            {
                                                // чи карта переможе
                                                label22.Text = cardP.CardSuit + " " + cardP.CardRank;
                                                players[1].hand.Remove(cardP);
                                                playingCards.Add(cardP);
                                                rounds++;
                                                hasPlayableCard = true;
                                                break;
                                            }
                                            i++;
                                        }

                                        // якщо цикл завершився і не було знайдено жодної підходящої карти
                                        if (!hasPlayableCard)
                                        {
                                            foreach (var item in playingCards.ToList())
                                            {
                                                players[1].hand.Add(item);
                                                playingCards.Remove(item);
                                            }
                                            lblPass.Text = "Противник спасував!";
                                            entrance++;
                                            rounds = 1;
                                            foreach (var item in lables)
                                            {
                                                item.Text = "-";
                                            }
                                            while (true)//добір карт
                                            {
                                                try
                                                {
                                                    if (players[0].hand.Count < 6)
                                                    {
                                                        for (int o = 0; o < 6; o++)
                                                        {
                                                            players[0].hand.Add(deck.cardsShaffle[0]);
                                                            deck.cardsShaffle.Remove(deck.cardsShaffle[0]);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        break;
                                                    }
                                                }
                                                catch
                                                {
                                                    break;
                                                }
                                            }

                                        }

                                    }
                                    else
                                    {
                                        int i = 0;
                                        bool hasPlayableCard = false;
                                        foreach (var cardP in players[1].hand.ToList())
                                        {
                                            if ((cardP.CardPower > currentCard.CardPower && cardP.CardSuit == currentCard.CardSuit) || cardP.CardSuit == trumpSuit)
                                            {
                                                // чи карта переможе
                                                label22.Text = cardP.CardSuit + " " + cardP.CardRank;
                                                players[1].hand.Remove(cardP);
                                                playingCards.Add(cardP);
                                                rounds++;
                                                hasPlayableCard = true;
                                                break;
                                            }
                                            i++;
                                        }

                                        // якщо цикл завершився і не було знайдено жодної підходящої карти
                                        if (!hasPlayableCard)
                                        {
                                            foreach (var item in playingCards.ToList())
                                            {
                                                players[1].hand.Add(item);
                                                playingCards.Remove(item);
                                            }
                                            lblPass.Text = "Противник спасував!";
                                            entrance++;
                                            rounds = 1;
                                            foreach (var item in lables)
                                            {
                                                item.Text = "-";
                                            }
                                            while (true)//добір карт
                                            {
                                                try
                                                {
                                                    if (players[0].hand.Count < 6)
                                                    {
                                                        for (int o = 0; o < 6; o++)
                                                        {
                                                            players[0].hand.Add(deck.cardsShaffle[0]);
                                                            deck.cardsShaffle.Remove(deck.cardsShaffle[0]);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        break;
                                                    }
                                                }
                                                catch
                                                {
                                                    break;
                                                }
                                            }

                                        }

                                    }
                                }
                                else
                                {
                                    lblPass.Text = "Ця карта не підходить!";
                                }
                            }
                            else//pass 2 roud
                            {
                                entrance++;
                                rounds = 1;
                                foreach (var item in lables)
                                {
                                    item.Text = "-";
                                }
                                foreach (var item in playingCards.ToList())//сброс
                                {
                                    playingCards.Remove(item);
                                }
                                while (true)
                                {
                                    try
                                    {
                                        if (players[0].hand.Count < 6)
                                        {
                                            players[0].hand.Add(deck.cardsShaffle[0]);
                                            deck.cardsShaffle.Remove(deck.cardsShaffle[0]);
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                    catch
                                    {
                                        break;
                                    }
                                }
                                while (true)
                                {
                                    try
                                    {
                                        if (players[1].hand.Count < 6)
                                        {
                                            players[1].hand.Add(deck.cardsShaffle[0]);
                                            deck.cardsShaffle.Remove(deck.cardsShaffle[0]);
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                    catch
                                    {
                                        break;
                                    }
                                }

                            }
                        }
                        else
                        {
                            if (rounds == 3)///////////////////3 round
                            {
                                string words = lbCards.SelectedItem.ToString();
                                string[] word = words.Split(' ');
                                if (word[0] != "Пас")
                                {
                                    Card currentCard = new Card { CardRank = word[1], CardSuit = word[0] };
                                    currentCard.CardPower = currentCard.CheckRank(currentCard.CardRank);//метод щоб зробити power

                                    if (currentCard.CardPower == playingCards[0].CardPower || currentCard.CardPower == playingCards[1].CardPower || currentCard.CardPower == playingCards[3].CardPower)
                                    {
                                        playingCards.Add(currentCard);
                                        label25.Text = playingCards.Last().CardSuit + " " + playingCards.Last().CardRank;
                                        lbCards.Items.Remove(lbCards.SelectedItem);
                                        foreach (var item in players[0].hand.ToList())
                                        {
                                            if (item.CardSuit == currentCard.CardSuit && item.CardRank == currentCard.CardRank)
                                            {
                                                //Console.WriteLine("Видалено");
                                                players[0].hand.Remove(item);
                                            }
                                        }

                                        if (currentCard.CardSuit == trumpSuit) //чи карта э козирем
                                        {
                                            int i = 0;
                                            bool hasPlayableCard = false;
                                            foreach (var cardP in players[1].hand.ToList())
                                            {
                                                if (cardP.CardPower > currentCard.CardPower && cardP.CardSuit == trumpSuit)
                                                {
                                                    // чи карта переможе
                                                    label24.Text = cardP.CardSuit + " " + cardP.CardRank;
                                                    players[1].hand.Remove(cardP);
                                                    playingCards.Add(cardP);
                                                    rounds++;
                                                    hasPlayableCard = true;
                                                    break;
                                                }
                                                i++;
                                            }

                                            // якщо цикл завершився і не було знайдено жодної підходящої карти
                                            if (!hasPlayableCard)
                                            {
                                                foreach (var item in playingCards.ToList())
                                                {
                                                    players[1].hand.Add(item);
                                                    playingCards.Remove(item);
                                                }
                                                lblPass.Text = "Противник спасував!";
                                                entrance++;
                                                rounds = 1;
                                                foreach (var item in lables)
                                                {
                                                    item.Text = "-";
                                                }
                                                while (true)//добір карт
                                                {
                                                    try
                                                    {
                                                        if (players[0].hand.Count < 6)
                                                        {
                                                            for (int o = 0; o < 6; o++)
                                                            {
                                                                players[0].hand.Add(deck.cardsShaffle[0]);
                                                                deck.cardsShaffle.Remove(deck.cardsShaffle[0]);
                                                            }
                                                        }
                                                        else
                                                        {
                                                            break;
                                                        }
                                                    }
                                                    catch
                                                    {
                                                        break;
                                                    }
                                                }

                                            }

                                        }
                                        else
                                        {
                                            int i = 0;
                                            bool hasPlayableCard = false;
                                            foreach (var cardP in players[1].hand.ToList())
                                            {
                                                if ((cardP.CardPower > currentCard.CardPower && cardP.CardSuit == currentCard.CardSuit) || cardP.CardSuit == trumpSuit)
                                                {
                                                    // чи карта переможе
                                                    label24.Text = cardP.CardSuit + " " + cardP.CardRank;
                                                    players[1].hand.Remove(cardP);
                                                    playingCards.Add(cardP);
                                                    rounds++;
                                                    hasPlayableCard = true;
                                                    break;
                                                }
                                                i++;
                                            }

                                            // якщо цикл завершився і не було знайдено жодної підходящої карти
                                            if (!hasPlayableCard)
                                            {
                                                foreach (var item in playingCards.ToList())
                                                {
                                                    players[1].hand.Add(item);
                                                    playingCards.Remove(item);
                                                }
                                                lblPass.Text = "Противник спасував!";
                                                entrance++;
                                                rounds = 1;
                                                foreach (var item in lables)
                                                {
                                                    item.Text = "-";
                                                }
                                                while (true)//добір карт
                                                {
                                                    try
                                                    {
                                                        if (players[0].hand.Count < 6)
                                                        {
                                                            for (int o = 0; o < 6; o++)
                                                            {
                                                                players[0].hand.Add(deck.cardsShaffle[0]);
                                                                deck.cardsShaffle.Remove(deck.cardsShaffle[0]);
                                                            }
                                                        }
                                                        else
                                                        {
                                                            break;
                                                        }
                                                    }
                                                    catch
                                                    {
                                                        break;
                                                    }
                                                }

                                            }

                                        }
                                    }
                                    else
                                    {
                                        lblPass.Text = "Ця карта не підходить!";
                                    }
                                }
                                else//pass 3 roud
                                {
                                    entrance++;
                                    rounds = 1;
                                    foreach (var item in lables)
                                    {
                                        item.Text = "-";
                                    }
                                    foreach (var item in playingCards.ToList())//сброс
                                    {
                                        playingCards.Remove(item);
                                    }
                                    while (true)
                                    {
                                        try
                                        {
                                            if (players[0].hand.Count < 6)
                                            {
                                                players[0].hand.Add(deck.cardsShaffle[0]);
                                                deck.cardsShaffle.Remove(deck.cardsShaffle[0]);
                                            }
                                            else
                                            {
                                                break;
                                            }
                                        }
                                        catch
                                        {
                                            break;
                                        }
                                    }
                                    while (true)
                                    {
                                        try
                                        {
                                            if (players[1].hand.Count < 6)
                                            {
                                                players[1].hand.Add(deck.cardsShaffle[0]);
                                                deck.cardsShaffle.Remove(deck.cardsShaffle[0]);
                                            }
                                            else
                                            {
                                                break;
                                            }
                                        }
                                        catch
                                        {
                                            break;
                                        }
                                    }

                                }
                            }
                            else
                            {
                                if (rounds == 4)///////////////////4 round
                                {
                                    string words = lbCards.SelectedItem.ToString();
                                    string[] word = words.Split(' ');
                                    if (word[0] != "Пас")
                                    {
                                        Card currentCard = new Card { CardRank = word[1], CardSuit = word[0] };
                                        currentCard.CardPower = currentCard.CheckRank(currentCard.CardRank);//метод щоб зробити power

                                        if (currentCard.CardPower == playingCards[0].CardPower || currentCard.CardPower == playingCards[1].CardPower || currentCard.CardPower == playingCards[3].CardPower || currentCard.CardPower == playingCards[5].CardPower)
                                        {
                                            Console.WriteLine("GAW");
                                            playingCards.Add(currentCard);
                                            label27.Text = playingCards.Last().CardSuit + " " + playingCards.Last().CardRank;
                                            lbCards.Items.Remove(lbCards.SelectedItem);
                                            foreach (var item in players[0].hand.ToList())
                                            {
                                                if (item.CardSuit == currentCard.CardSuit && item.CardRank == currentCard.CardRank)
                                                {
                                                    //Console.WriteLine("Видалено");
                                                    players[0].hand.Remove(item);
                                                }
                                            }

                                            if (currentCard.CardSuit == trumpSuit) //чи карта э козирем
                                            {
                                                int i = 0;
                                                bool hasPlayableCard = false;
                                                foreach (var cardP in players[1].hand.ToList())
                                                {
                                                    if (cardP.CardPower > currentCard.CardPower && cardP.CardSuit == trumpSuit)
                                                    {
                                                        // чи карта переможе
                                                        label26.Text = cardP.CardSuit + " " + cardP.CardRank;
                                                        players[1].hand.Remove(cardP);
                                                        playingCards.Add(cardP);
                                                        rounds++;
                                                        hasPlayableCard = true;
                                                        break;
                                                    }
                                                    i++;
                                                }

                                                // якщо цикл завершився і не було знайдено жодної підходящої карти
                                                if (!hasPlayableCard)
                                                {
                                                    foreach (var item in playingCards.ToList())
                                                    {
                                                        players[1].hand.Add(item);
                                                        playingCards.Remove(item);
                                                    }
                                                    lblPass.Text = "Противник спасував!";
                                                    entrance++;
                                                    rounds = 1;
                                                    foreach (var item in lables)
                                                    {
                                                        item.Text = "-";
                                                    }
                                                    while (true)//добір карт
                                                    {
                                                        try
                                                        {
                                                            if (players[0].hand.Count < 6)
                                                            {
                                                                for (int o = 0; o < 6; o++)
                                                                {
                                                                    players[0].hand.Add(deck.cardsShaffle[0]);
                                                                    deck.cardsShaffle.Remove(deck.cardsShaffle[0]);
                                                                }
                                                            }
                                                            else
                                                            {
                                                                break;
                                                            }
                                                        }
                                                        catch
                                                        {
                                                            break;
                                                        }
                                                    }

                                                }

                                            }
                                            else
                                            {
                                                int i = 0;
                                                bool hasPlayableCard = false;
                                                foreach (var cardP in players[1].hand.ToList())
                                                {
                                                    if ((cardP.CardPower > currentCard.CardPower && cardP.CardSuit == currentCard.CardSuit) || cardP.CardSuit == trumpSuit)
                                                    {
                                                        // чи карта переможе
                                                        label26.Text = cardP.CardSuit + " " + cardP.CardRank;
                                                        players[1].hand.Remove(cardP);
                                                        playingCards.Add(cardP);
                                                        rounds++;
                                                        hasPlayableCard = true;
                                                        break;
                                                    }
                                                    i++;
                                                }

                                                // якщо цикл завершився і не було знайдено жодної підходящої карти
                                                if (!hasPlayableCard)
                                                {
                                                    foreach (var item in playingCards.ToList())
                                                    {
                                                        players[1].hand.Add(item);
                                                        playingCards.Remove(item);
                                                    }
                                                    lblPass.Text = "Противник спасував!";
                                                    entrance++;
                                                    rounds = 1;
                                                    foreach (var item in lables)
                                                    {
                                                        item.Text = "-";
                                                    }
                                                    while (true)//добір карт
                                                    {
                                                        try
                                                        {
                                                            if (players[0].hand.Count < 6)
                                                            {
                                                                for (int o = 0; o < 6; o++)
                                                                {
                                                                    players[0].hand.Add(deck.cardsShaffle[0]);
                                                                    deck.cardsShaffle.Remove(deck.cardsShaffle[0]);
                                                                }
                                                            }
                                                            else
                                                            {
                                                                break;
                                                            }
                                                        }
                                                        catch
                                                        {
                                                            break;
                                                        }
                                                    }

                                                }

                                            }
                                        }
                                        else
                                        {
                                            lblPass.Text = "Ця карта не підходить!";
                                        }
                                    }
                                    else//pass 4 roud
                                    {
                                        entrance++;
                                        rounds = 1;
                                        foreach (var item in lables)
                                        {
                                            item.Text = "-";
                                        }
                                        foreach (var item in playingCards.ToList())//сброс
                                        {
                                            playingCards.Remove(item);
                                        }
                                        while (true)
                                        {
                                            try
                                            {
                                                if (players[0].hand.Count < 6)
                                                {
                                                    players[0].hand.Add(deck.cardsShaffle[0]);
                                                    deck.cardsShaffle.Remove(deck.cardsShaffle[0]);
                                                }
                                                else
                                                {
                                                    break;
                                                }
                                            }
                                            catch
                                            {
                                                break;
                                            }
                                        }
                                        while (true)
                                        {
                                            try
                                            {
                                                if (players[1].hand.Count < 6)
                                                {
                                                    players[1].hand.Add(deck.cardsShaffle[0]);
                                                    deck.cardsShaffle.Remove(deck.cardsShaffle[0]);
                                                }
                                                else
                                                {
                                                    break;
                                                }
                                            }
                                            catch
                                            {
                                                break;
                                            }
                                        }

                                    }
                                }
                                else
                                {
                                    if (rounds == 5)///////////////////5 round
                                    {
                                        string words = lbCards.SelectedItem.ToString();
                                        string[] word = words.Split(' ');
                                        if (word[0] != "Пас")
                                        {
                                            Card currentCard = new Card { CardRank = word[1], CardSuit = word[0] };
                                            currentCard.CardPower = currentCard.CheckRank(currentCard.CardRank);//метод щоб зробити power

                                            if (currentCard.CardPower == playingCards[0].CardPower || currentCard.CardPower == playingCards[1].CardPower || currentCard.CardPower == playingCards[3].CardPower || currentCard.CardPower == playingCards[5].CardPower || currentCard.CardPower == playingCards[7].CardPower)
                                            {
                                                playingCards.Add(currentCard);
                                                label29.Text = playingCards.Last().CardSuit + " " + playingCards.Last().CardRank;
                                                lbCards.Items.Remove(lbCards.SelectedItem);
                                                foreach (var item in players[0].hand.ToList())
                                                {
                                                    if (item.CardSuit == currentCard.CardSuit && item.CardRank == currentCard.CardRank)
                                                    {
                                                        //Console.WriteLine("Видалено");
                                                        players[0].hand.Remove(item);
                                                    }
                                                }

                                                if (currentCard.CardSuit == trumpSuit) //чи карта э козирем
                                                {
                                                    int i = 0;
                                                    bool hasPlayableCard = false;
                                                    foreach (var cardP in players[1].hand.ToList())
                                                    {
                                                        if (cardP.CardPower > currentCard.CardPower && cardP.CardSuit == trumpSuit)
                                                        {
                                                            // чи карта переможе
                                                            label28.Text = cardP.CardSuit + " " + cardP.CardRank;
                                                            players[1].hand.Remove(cardP);
                                                            playingCards.Add(cardP);
                                                            rounds++;
                                                            hasPlayableCard = true;
                                                            break;
                                                        }
                                                        i++;
                                                    }

                                                    // якщо цикл завершився і не було знайдено жодної підходящої карти
                                                    if (!hasPlayableCard)
                                                    {
                                                        foreach (var item in playingCards.ToList())
                                                        {
                                                            players[1].hand.Add(item);
                                                            playingCards.Remove(item);
                                                        }
                                                        lblPass.Text = "Противник спасував!";
                                                        entrance++;
                                                        rounds = 1;
                                                        foreach (var item in lables)
                                                        {
                                                            item.Text = "-";
                                                        }
                                                        while (true)//добір карт
                                                        {
                                                            try
                                                            {
                                                                if (players[0].hand.Count < 6)
                                                                {
                                                                    for (int o = 0; o < 6; o++)
                                                                    {
                                                                        players[0].hand.Add(deck.cardsShaffle[0]);
                                                                        deck.cardsShaffle.Remove(deck.cardsShaffle[0]);
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    break;
                                                                }
                                                            }
                                                            catch
                                                            {
                                                                break;
                                                            }
                                                        }

                                                    }

                                                }
                                                else
                                                {
                                                    int i = 0;
                                                    bool hasPlayableCard = false;
                                                    foreach (var cardP in players[1].hand.ToList())
                                                    {
                                                        if ((cardP.CardPower > currentCard.CardPower && cardP.CardSuit == currentCard.CardSuit) || cardP.CardSuit == trumpSuit)
                                                        {
                                                            // чи карта переможе
                                                            label28.Text = cardP.CardSuit + " " + cardP.CardRank;
                                                            players[1].hand.Remove(cardP);
                                                            playingCards.Add(cardP);
                                                            rounds++;
                                                            hasPlayableCard = true;
                                                            break;
                                                        }
                                                        i++;
                                                    }

                                                    // якщо цикл завершився і не було знайдено жодної підходящої карти
                                                    if (!hasPlayableCard)
                                                    {
                                                        foreach (var item in playingCards.ToList())
                                                        {
                                                            players[1].hand.Add(item);
                                                            playingCards.Remove(item);
                                                        }
                                                        lblPass.Text = "Противник спасував!";
                                                        entrance++;
                                                        rounds = 1;
                                                        foreach (var item in lables)
                                                        {
                                                            item.Text = "-";
                                                        }
                                                        while (true)//добір карт
                                                        {
                                                            try
                                                            {
                                                                if (players[0].hand.Count < 6)
                                                                {
                                                                    for (int o = 0; o < 6; o++)
                                                                    {
                                                                        players[0].hand.Add(deck.cardsShaffle[0]);
                                                                        deck.cardsShaffle.Remove(deck.cardsShaffle[0]);
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    break;
                                                                }
                                                            }
                                                            catch
                                                            {
                                                                break;
                                                            }
                                                        }

                                                    }

                                                }
                                            }
                                            else
                                            {
                                                lblPass.Text = "Ця карта не підходить!";
                                            }
                                        }
                                        else//pass 5 roud
                                        {
                                            entrance++;
                                            rounds = 1;
                                            foreach (var item in lables)
                                            {
                                                item.Text = "-";
                                            }
                                            foreach (var item in playingCards.ToList())//сброс
                                            {
                                                playingCards.Remove(item);
                                            }
                                            while (true)
                                            {
                                                try
                                                {
                                                    if (players[0].hand.Count < 6)
                                                    {
                                                        players[0].hand.Add(deck.cardsShaffle[0]);
                                                        deck.cardsShaffle.Remove(deck.cardsShaffle[0]);
                                                    }
                                                    else
                                                    {
                                                        break;
                                                    }
                                                }
                                                catch
                                                {
                                                    break;
                                                }
                                            }
                                            while (true)
                                            {
                                                try
                                                {
                                                    if (players[1].hand.Count < 6)
                                                    {
                                                        players[1].hand.Add(deck.cardsShaffle[0]);
                                                        deck.cardsShaffle.Remove(deck.cardsShaffle[0]);
                                                    }
                                                    else
                                                    {
                                                        break;
                                                    }
                                                }
                                                catch
                                                {
                                                    break;
                                                }
                                            }

                                        }
                                    }
                                    else
                                    {
                                        if (rounds == 6)///////////////////6 round
                                        {
                                            string words = lbCards.SelectedItem.ToString();
                                            string[] word = words.Split(' ');
                                            if (word[0] != "Пас")
                                            {
                                                Card currentCard = new Card { CardRank = word[1], CardSuit = word[0] };
                                                currentCard.CardPower = currentCard.CheckRank(currentCard.CardRank);//метод щоб зробити power

                                                if (currentCard.CardPower == playingCards[0].CardPower || currentCard.CardPower == playingCards[1].CardPower || currentCard.CardPower == playingCards[3].CardPower || currentCard.CardPower == playingCards[5].CardPower || currentCard.CardPower == playingCards[7].CardPower || currentCard.CardPower == playingCards[9].CardPower)
                                                {
                                                    playingCards.Add(currentCard);
                                                    label31.Text = playingCards.Last().CardSuit + " " + playingCards.Last().CardRank;
                                                    lbCards.Items.Remove(lbCards.SelectedItem);
                                                    foreach (var item in players[0].hand.ToList())
                                                    {
                                                        if (item.CardSuit == currentCard.CardSuit && item.CardRank == currentCard.CardRank)
                                                        {
                                                            //Console.WriteLine("Видалено");
                                                            players[0].hand.Remove(item);
                                                        }
                                                    }

                                                    if (currentCard.CardSuit == trumpSuit) //чи карта э козирем
                                                    {
                                                        int i = 0;
                                                        bool hasPlayableCard = false;
                                                        foreach (var cardP in players[1].hand.ToList())
                                                        {
                                                            if (cardP.CardPower > currentCard.CardPower && cardP.CardSuit == trumpSuit)
                                                            {
                                                                // чи карта переможе
                                                                label30.Text = cardP.CardSuit + " " + cardP.CardRank;
                                                                players[1].hand.Remove(cardP);
                                                                playingCards.Add(cardP);
                                                                rounds++;
                                                                hasPlayableCard = true;
                                                                break;
                                                            }
                                                            i++;
                                                        }

                                                        // якщо цикл завершився і не було знайдено жодної підходящої карти
                                                        if (!hasPlayableCard)
                                                        {
                                                            foreach (var item in playingCards.ToList())
                                                            {
                                                                players[1].hand.Add(item);
                                                                playingCards.Remove(item);
                                                            }
                                                            lblPass.Text = "Противник спасував!";
                                                            entrance++;
                                                            rounds = 1;
                                                            foreach (var item in lables)
                                                            {
                                                                item.Text = "-";
                                                            }
                                                            while (true)//добір карт
                                                            {
                                                                try
                                                                {
                                                                    if (players[0].hand.Count < 6)
                                                                    {
                                                                        for (int o = 0; o < 6; o++)
                                                                        {
                                                                            players[0].hand.Add(deck.cardsShaffle[0]);
                                                                            deck.cardsShaffle.Remove(deck.cardsShaffle[0]);
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        break;
                                                                    }
                                                                }
                                                                catch
                                                                {
                                                                    break;
                                                                }
                                                            }

                                                        }

                                                    }
                                                    else
                                                    {
                                                        int i = 0;
                                                        bool hasPlayableCard = false;
                                                        foreach (var cardP in players[1].hand.ToList())
                                                        {
                                                            if ((cardP.CardPower > currentCard.CardPower && cardP.CardSuit == currentCard.CardSuit) || cardP.CardSuit == trumpSuit)
                                                            {
                                                                // чи карта переможе
                                                                label30.Text = cardP.CardSuit + " " + cardP.CardRank;
                                                                players[1].hand.Remove(cardP);
                                                                playingCards.Add(cardP);
                                                                rounds++;
                                                                hasPlayableCard = true;
                                                                break;
                                                            }
                                                            i++;
                                                        }

                                                        // якщо цикл завершився і не було знайдено жодної підходящої карти
                                                        if (!hasPlayableCard)
                                                        {
                                                            foreach (var item in playingCards.ToList())
                                                            {
                                                                players[1].hand.Add(item);
                                                                playingCards.Remove(item);
                                                            }
                                                            lblPass.Text = "Противник спасував!";
                                                            entrance++;
                                                            rounds = 1;
                                                            foreach (var item in lables)
                                                            {
                                                                item.Text = "-";
                                                            }
                                                            while (true)//добір карт
                                                            {
                                                                try
                                                                {
                                                                    if (players[0].hand.Count < 6)
                                                                    {
                                                                        for (int o = 0; o < 6; o++)
                                                                        {
                                                                            players[0].hand.Add(deck.cardsShaffle[0]);
                                                                            deck.cardsShaffle.Remove(deck.cardsShaffle[0]);
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        break;
                                                                    }
                                                                }
                                                                catch
                                                                {
                                                                    break;
                                                                }
                                                            }

                                                        }

                                                    }
                                                }
                                                else
                                                {
                                                    lblPass.Text = "Ця карта не підходить!";
                                                }
                                            }
                                            else//pass 6 roud
                                            {
                                                entrance++;
                                                rounds = 1;
                                                foreach (var item in lables)
                                                {
                                                    item.Text = "-";
                                                }
                                                foreach (var item in playingCards.ToList())//сброс
                                                {
                                                    playingCards.Remove(item);
                                                }
                                                while (true)
                                                {
                                                    try
                                                    {
                                                        if (players[0].hand.Count < 6)
                                                        {
                                                            players[0].hand.Add(deck.cardsShaffle[0]);
                                                            deck.cardsShaffle.Remove(deck.cardsShaffle[0]);
                                                        }
                                                        else
                                                        {
                                                            break;
                                                        }
                                                    }
                                                    catch
                                                    {
                                                        break;
                                                    }
                                                }
                                                while (true)
                                                {
                                                    try
                                                    {
                                                        if (players[1].hand.Count < 6)
                                                        {
                                                            players[1].hand.Add(deck.cardsShaffle[0]);
                                                            deck.cardsShaffle.Remove(deck.cardsShaffle[0]);
                                                        }
                                                    }
                                                    catch
                                                    {
                                                        break;
                                                    }

                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else//інші гравці
                {
                    if (deffenser == players[0])// на мене
                    {
                        foreach (var lastPlayer in players)
                        {
                            if (lastPlayer.lastPlayer == true)
                            {
                                label7.Text = "Ви";
                                label5.Text = attacker.name;
                                if (rounds == 1) //round 1
                                {
                                    Card choosedCard = new Card { CardRank = lastPlayer.hand[0].CardRank, CardSuit = lastPlayer.hand[0].CardSuit, CardPower = lastPlayer.hand[0].CardPower };
                                    lastPlayer.hand.Remove(choosedCard);
                                    label20.Text = choosedCard.CardSuit + " " + choosedCard.CardRank;
                                    playingCards.Add(choosedCard);
                                    foreach (var item in lastPlayer.hand.ToList())
                                    {
                                        if (item.CardSuit == choosedCard.CardSuit && item.CardRank == choosedCard.CardRank)
                                        {
                                            lastPlayer.hand.Remove(item);
                                        }
                                    }
                                    string words = lbCards.SelectedItem.ToString();
                                    string[] word = words.Split(' ');
                                    if (word[0] != "Пас")
                                    {
                                        Card currentCard = new Card { CardRank = word[1], CardSuit = word[0] };
                                        currentCard.CardPower = currentCard.CheckRank(currentCard.CardRank);//метод щоб зробити power

                                        if (currentCard.CardSuit == trumpSuit) //чи карта э козирем
                                        {
                                            if (currentCard.CardPower > choosedCard.CardPower && currentCard.CardSuit == trumpSuit)
                                            {
                                                playingCards.Add(currentCard);
                                                label21.Text = playingCards.Last().CardSuit + " " + playingCards.Last().CardRank;
                                                lbCards.Items.Remove(lbCards.SelectedItem);
                                                foreach (var item in players[0].hand.ToList())
                                                {
                                                    if (item.CardSuit == currentCard.CardSuit && item.CardRank == currentCard.CardRank)
                                                    {
                                                        //Console.WriteLine("Видалено");
                                                        players[0].hand.Remove(item);
                                                    }
                                                }
                                                rounds++;
                                            }
                                            else
                                            {
                                                lblPass.Text = "Ця карта не підходить!";
                                            }
                                        }
                                        else
                                        {
                                            if ((currentCard.CardPower > choosedCard.CardPower && currentCard.CardSuit == choosedCard.CardSuit) || currentCard.CardSuit == trumpSuit)
                                            {
                                                playingCards.Add(currentCard);
                                                label21.Text = playingCards.Last().CardSuit + " " + playingCards.Last().CardRank;
                                                lbCards.Items.Remove(lbCards.SelectedItem);
                                                foreach (var item in players[0].hand.ToList())
                                                {
                                                    if (item.CardSuit == currentCard.CardSuit && item.CardRank == currentCard.CardRank)
                                                    {
                                                        //Console.WriteLine("Видалено");
                                                        players[0].hand.Remove(item);
                                                    }
                                                }
                                                rounds++;
                                            }
                                            else
                                            {
                                                lblPass.Text = "Ця карта не підходить!";
                                            }
                                        }
                                    }
                                    else//pass 1 round
                                    {
                                        lblPass.Text = "Ви спасували";
                                        foreach (var item in playingCards.ToList())
                                        {
                                            players[0].hand.Add(item);
                                            playingCards.Remove(item);
                                        }
                                        entrance++;
                                        rounds = 1;
                                        foreach (var item in lables)
                                        {
                                            item.Text = "-";
                                        }
                                        while (true)
                                        {
                                            try
                                            {
                                                if (lastPlayer.hand.Count < 6)
                                                {
                                                    for (int o = 0; o < 6; o++)
                                                    {
                                                        lastPlayer.hand.Add(deck.cardsShaffle[0]);
                                                        deck.cardsShaffle.Remove(deck.cardsShaffle[0]);
                                                    }
                                                }
                                                else
                                                {
                                                    break;
                                                }
                                            }
                                            catch
                                            {
                                                break;
                                            }
                                        }
                                    }
                                    foreach (var item in lastPlayer.hand)
                                    {
                                        Console.WriteLine(item.CardSuit + " " + item.CardRank + " " + item.CardPower);
                                    }

                                }
                                else
                                {
                                    if (rounds == 2) //round 2
                                    {
                                        foreach (var card in lastPlayer.hand)
                                        {
                                            if (card.CardPower == playingCards[0].CardPower || card.CardPower == playingCards[1].CardPower)
                                            {
                                                Card choosedCard = new Card { CardRank = lastPlayer.hand[0].CardRank, CardSuit = lastPlayer.hand[0].CardSuit, CardPower = lastPlayer.hand[0].CardPower };
                                                lastPlayer.hand.Remove(choosedCard);
                                                label23.Text = choosedCard.CardSuit + " " + choosedCard.CardRank;
                                                playingCards.Add(choosedCard);
                                                foreach (var item in lastPlayer.hand.ToList())
                                                {
                                                    if (item.CardSuit == choosedCard.CardSuit && item.CardRank == choosedCard.CardRank)
                                                    {
                                                        lastPlayer.hand.Remove(item);
                                                    }
                                                }
                                                string words = lbCards.SelectedItem.ToString();
                                                string[] word = words.Split(' ');
                                                if (word[0] != "Пас")
                                                {
                                                    Card currentCard = new Card { CardRank = word[1], CardSuit = word[0] };
                                                    currentCard.CardPower = currentCard.CheckRank(currentCard.CardRank);//метод щоб зробити power

                                                    if (currentCard.CardSuit == trumpSuit) //чи карта э козирем
                                                    {
                                                        if (currentCard.CardPower > choosedCard.CardPower && currentCard.CardSuit == trumpSuit)
                                                        {
                                                            playingCards.Add(currentCard);
                                                            label22.Text = playingCards.Last().CardSuit + " " + playingCards.Last().CardRank;
                                                            lbCards.Items.Remove(lbCards.SelectedItem);
                                                            foreach (var item in players[0].hand.ToList())
                                                            {
                                                                if (item.CardSuit == currentCard.CardSuit && item.CardRank == currentCard.CardRank)
                                                                {
                                                                    //Console.WriteLine("Видалено");
                                                                    players[0].hand.Remove(item);
                                                                }
                                                            }
                                                            rounds++;
                                                        }
                                                        else
                                                        {
                                                            lblPass.Text = "Ця карта не підходить!";
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if ((currentCard.CardPower > choosedCard.CardPower && currentCard.CardSuit == choosedCard.CardSuit) || currentCard.CardSuit == trumpSuit)
                                                        {
                                                            playingCards.Add(currentCard);
                                                            label22.Text = playingCards.Last().CardSuit + " " + playingCards.Last().CardRank;
                                                            lbCards.Items.Remove(lbCards.SelectedItem);
                                                            foreach (var item in players[0].hand.ToList())
                                                            {
                                                                if (item.CardSuit == currentCard.CardSuit && item.CardRank == currentCard.CardRank)
                                                                {
                                                                    //Console.WriteLine("Видалено");
                                                                    players[0].hand.Remove(item);
                                                                }
                                                            }
                                                            rounds++;
                                                        }
                                                        else
                                                        {
                                                            lblPass.Text = "Ця карта не підходить!";
                                                        }
                                                    }
                                                }
                                                else//pass 2 round
                                                {
                                                    lblPass.Text = "Ви спасували";
                                                    foreach (var item in playingCards.ToList())
                                                    {
                                                        players[0].hand.Add(item);
                                                        playingCards.Remove(item);
                                                    }
                                                    entrance++;
                                                    rounds = 1;
                                                    foreach (var item in lables)
                                                    {
                                                        item.Text = "-";
                                                    }
                                                    while (true)
                                                    {
                                                        try
                                                        {
                                                            if (lastPlayer.hand.Count < 6)
                                                            {
                                                                for (int o = 0; o < 6; o++)
                                                                {
                                                                    lastPlayer.hand.Add(deck.cardsShaffle[0]);
                                                                    deck.cardsShaffle.Remove(deck.cardsShaffle[0]);
                                                                }
                                                            }
                                                            else
                                                            {
                                                                break;
                                                            }
                                                        }
                                                        catch
                                                        {
                                                            break;
                                                        }
                                                    }
                                                }
                                                foreach (var item in lastPlayer.hand)
                                                {
                                                    Console.WriteLine(item.CardSuit + " " + item.CardRank + " " + item.CardPower);
                                                }
                                            }
                                            else
                                            {
                                                entrance++;
                                                rounds = 1;
                                                foreach (var item in lables)
                                                {
                                                    item.Text = "-";
                                                }
                                                foreach (var item in playingCards.ToList())//сброс
                                                {
                                                    playingCards.Remove(item);
                                                }
                                                while (true)
                                                {
                                                    try
                                                    {
                                                        if (players[0].hand.Count < 6)
                                                        {
                                                            players[0].hand.Add(deck.cardsShaffle[0]);
                                                            deck.cardsShaffle.Remove(deck.cardsShaffle[0]);
                                                        }
                                                        else
                                                        {
                                                            break;
                                                        }
                                                    }
                                                    catch
                                                    {
                                                        break;
                                                    }
                                                }
                                                while (true)
                                                {
                                                    try
                                                    {
                                                        if (players[1].hand.Count < 6)
                                                        {
                                                            players[1].hand.Add(deck.cardsShaffle[0]);
                                                            deck.cardsShaffle.Remove(deck.cardsShaffle[0]);
                                                        }
                                                    }
                                                    catch
                                                    {
                                                        break;
                                                    }

                                                }
                                            }
                                        }
                                    }                                
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
