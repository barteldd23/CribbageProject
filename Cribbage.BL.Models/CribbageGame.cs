﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cribbage.BL.Models
{
    public class CribbageGame : Game
    {
            #region "Properties"
            public Player Player_1 { get; set; }
            public Player Player_2 { get; set; }
            public int Dealer { get; set; } = 1;
            public Player PlayerTurn { get; set; }
            public int GoCount { get; set; } = 0;
            public Player LastPlayerPlayed { get; set; }
            public Deck Deck { get; set; } = new Deck();
            public List<Card> Crib { get; set; } = new List<Card>();
            public Card CutCard { get; set; }
            public List<Card> PlayedCards { get; set; } = new List<Card>();
            public List<Card> CurrentRally { get; set; } = new List<Card>();
            public int CurrentCount { get { return getCount(); } }

            [DisplayName("Team 1 Score")]
            public int Team1_Score { get; set; }
            [DisplayName("Team 2 Score")]
            public int Team2_Score { get; set; }

            public int getCount()
            {
                int count = 0;
                if (CurrentRally.Count > 0)
                {
                    foreach (Card card in CurrentRally)
                    {
                        count += card.value;
                    }
                }
                return count;
            }
            #endregion

        
    }
}
