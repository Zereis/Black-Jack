using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment_4
{
    public delegate void DelegatePlayer();
    public delegate void DelegateRoundsOver();
    public delegate void Reset();
    public delegate void DelegateDealer();
    public delegate void DelegateCalculate();

    public partial class Form1 : Form
    {
        // Variables
        editForm editsForm = new editForm();
        //Player player;
        //Player dealer;

        Hand playersHand;
        Hand dealersHand;

        Deck decks;

        bool playerStand = false;
        bool dealerStand = false;

        DelegatePlayer playerTurn;
        DelegateRoundsOver roundsOver;
        Reset reset;
        DelegateDealer dealerTurn;
        DelegateCalculate calculate;

        public Form1()
        {
            InitializeComponent();
            playersHand = new Hand();
            dealersHand = new Hand();

            playerTurn = new DelegatePlayer(playersTurn);
            roundsOver = new DelegateRoundsOver(roundOver);
            reset = new Reset(Reset);
            dealerTurn = new DelegateDealer(dealersTurn);
            calculate = new DelegateCalculate(calculateRound);

        }

        // Using Lambda expression to delegate the event when the editform is closed
        private void Form1_Load(object sender, EventArgs e)
        {
            editsForm.Closed += delegate
            {
                label8.Text = editsForm.name;
                label9.Text = editsForm.amountOfDecks.ToString();

                int createDecks = int.Parse(label9.Text);
                // Create amount Of Decks
                decks = new Deck(createDecks);

                Logger.WriteLog("Filled Deck with cards");
                // Fill the Decks
                decks.FillDeck();

                Logger.WriteLog("Shuffled the Deck");
                // Shuffle the Decks;
                decks.Shuffle(decks.cards);

                label13.Text = decks.cards.Count().ToString();
                label14.Text = "Players Turn";

                decks.GameIsDone = false;

                // Continue playing until game is done
                if(decks.GameIsDone == false)
                {
                    Logger.WriteLog("Round begins: Players Turn");
                    playerTurn();
                }

                button1.Enabled = false;
            };
        }
        // Calculate players and dealers handvalue and then add the score
        public void calculateRound()
        {
            // calculate who wins
            Logger.WriteLog("Calculate who wins");
            if (playersHand.handValue > dealersHand.handValue && playersHand.handValue < 22)
            {
                // player wins
                label7.Text = label8.Text + " wins!";
                playersHand.Score++;
                label10.Text = playersHand.Score.ToString();
            }
            else if (playersHand.handValue < dealersHand.handValue && dealersHand.handValue < 22)
            {
                // dealer wins
                label7.Text = "Dealer wins!";
                dealersHand.Score++;
                label11.Text = dealersHand.Score.ToString();
            }
            else if (playersHand.handValue > 22 && dealersHand.handValue < 22)
            {
                //  player busted
                label7.Text = "Dealer wins!";
                dealersHand.Score++;
                label11.Text = dealersHand.Score.ToString();
            }
            else if (playersHand.handValue < 22 && dealersHand.handValue > 22)
            {
                // dealer busted
                label7.Text = label8.Text + " wins!";
                playersHand.Score++;
                label10.Text = playersHand.Score.ToString();
            }
            else if (playersHand.handValue == dealersHand.handValue && dealersHand.handValue < 22 && playersHand.handValue < 22)
            {
                // draw
                label7.Text = "It was a draw";
            }
        }
        // Players turn to perform actions
        public void playersTurn()
        {
            // Add card to player hand
            // Use foreach until a card isnt dupe

            Logger.WriteLog("Add 2 Card to players hand and delete 2 card from the deck");
            foreach (Card card in decks.cards.ToList())
            {
                if (playersHand.cards.Count < 2)
                {
                    playersHand.AddCard(card);
                    decks.removeCard(card, decks.cards);
                }
            }
            label16.Text = playersHand.handValue.ToString();

            richTextBox2.AppendText("Players hand: " + playersHand.ToString());

            label13.Text = decks.cards.Count().ToString();
        }
        // Dealer AI 
        public void dealersTurn()
        {
            Logger.WriteLog("Add Two cards dealers hand and remove the cards from the deck");
            // Add two to dealer hand
            foreach (Card card in decks.cards.ToList())
            {
                if (dealersHand.cards.Count < 2)
                {
                    dealersHand.AddCard(card);
                    decks.removeCard(card, decks.cards);
                }
            }
            richTextBox1.AppendText("Dealer hand: " + dealersHand.ToString());


            // if dealers card doesnt exeed 12 then draw else stand
            while (dealerStand != true)
            {
                if (dealersHand.handValue < 12 && dealersHand.handValue < playersHand.handValue)
                {
                    // Dealer draw 
                    Logger.WriteLog("Dealer draw card");
                    int addCard = 0;
                    foreach (Card card in decks.cards.ToList())
                    {
                        if (addCard == 0)
                        {
                            dealersHand.AddCard(card);
                            // Remove cards when draw
                            decks.removeCard(card, decks.cards);
                            richTextBox1.AppendText(" , " + card.ToString());
                            addCard++;
                        }
                    }
                    dealerStand = true;

                }
                else if(dealersHand.handValue > 21)
                {
                    Logger.WriteLog("Draw busted");
                    dealerStand = true;
                }
                else
                {
                    Logger.WriteLog("Dealer have higher handvalue than player");
                    dealerStand = true;
                }
            }
            label18.Text = dealersHand.handValue.ToString();
            label13.Text = decks.cards.Count().ToString();
        }
        // Perform this method when the round is over
        public void roundOver()
        {
            Logger.WriteLog("Round is over");
            if (decks.GameIsDone == true)
            {
                // when card.Count < 25 messagebox for adding another deck
                if (decks.cards.Count < 25)
                {
                    DialogResult dialogResult = MessageBox.Show("There are less than 25 cards, Do you wanna add another deck?", "Shuffle Box", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        // add another deck
                        decks.FillDeck();
                        decks.Shuffle(decks.cards);
                        label13.Text = decks.cards.Count().ToString();
                        decks.GameIsDone = false;
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        DialogResult dialogResults = MessageBox.Show("Do you wanna quit game?", "Quit Game", MessageBoxButtons.YesNo);
                        if (dialogResults == DialogResult.Yes)
                        {
                            // close the application
                            Application.Exit();
                        }
                        else if (dialogResults == DialogResult.No)
                        {
                            // continue playing
                            decks.GameIsDone = false;
                        }
                    }
                }
            }
        }
        // Show the editform and disable the new game Button
        private void button1_Click(object sender, EventArgs e)
        {
            editsForm.Show();
            button5.Enabled = false;
        }
        private void label7_Click(object sender, EventArgs e)
        {

        }
        private void eventLog1_EntryWritten(object sender, System.Diagnostics.EntryWrittenEventArgs e)
        {

        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            // Dealers Card Log
        }
        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
            // Player Card Log
      
        }
        // Button for adding card to players hand
        private void button3_Click(object sender, EventArgs e)
        {
            Logger.WriteLog("added a card from the deck to players hand and deleted the card from the deck");
            // Ádd another card to your hand
            int addCard = 0;
            foreach (Card card in decks.cards.ToList())
            {
                if(addCard == 0)
                {
                    playersHand.AddCard(card);
                    // Remove cards when draw
                    decks.removeCard(card, decks.cards);
                    richTextBox2.AppendText(" , " + card.ToString());
                    addCard++;
                }
            }
            label16.Text = playersHand.handValue.ToString();
        }
        // Button for shuffling the deck
        private void button2_Click(object sender, EventArgs e)
        {
            Logger.WriteLog("Shuffled the deck");
            // Shuffle
            DialogResult dialogResult = MessageBox.Show("Do you want to shuffle the deck", "Shuffle Box", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                // Shuffle the deck 
                decks.Shuffle(decks.cards);
            }
            else if (dialogResult == DialogResult.No)
            {
                // nothing happens
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click_1(object sender, EventArgs e)
        {
            // players name
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
        // Reset method to clear out player and dealers hand and reset all the relevant
        // label text to default and clear out the richtextbox and players.handvalue to 0
        public void Reset()
        {
            Logger.WriteLog("Reset the text");
            // remove card from dealer and players hand
            playersHand.Clear();
            dealersHand.Clear();
            label16.Text = "0";
            label18.Text = "0";
            label14.Text = "Players Turn";
            label7.Text = "";
            richTextBox1.Clear();
            richTextBox2.Clear();
            playersHand.handValue = 0;
            dealersHand.handValue = 0;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            calculate();

            roundsOver();

            reset();

            if (decks.GameIsDone == false)
            {
                playerTurn();
            }
            button5.Enabled = false;
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }
        // Button for not drawing more cards switch to dealers turn
        // if the deck has less than 25 cards ask if the player wants to add another deck
        // or if they player wants to quit
        private void button4_Click_1(object sender, EventArgs e)
        {
            Logger.WriteLog("players stand");
            // Stand (don't draw more cards)
            playerStand = true;

            //decks.GameIsDone = true;
            label14.Text = "Rounds Over";
            // calculate the final
            dealerTurn();

            if(decks.cards.Count < 25)
            {
                decks.GameIsDone = true;
                roundsOver();
                reset();
            }
            button5.Enabled = true;
        }
    }
}
