using PokerHand;
using FluentAssertions;

namespace PokerHandTest
{
    public class PokerHandTests
    {
        [Fact]
        public void PlayerTies()
        {
            List<Player> players = new List<Player>()
            {
                    new Player()
                    {
                        Name = "Garret",
                        Hand = new List<Card>()
                        {
                            new Card("3C"),
                            new Card("2D"),
                            new Card("9H"),
                            new Card("KC"),
                            new Card("7C"),
                        }
                    },
                    new Player()
                    {
                        Name = "Boone",
                        Hand = new List<Card>()
                        {
                            new Card("3C"),
                            new Card("2D"),
                            new Card("9H"),
                            new Card("KC"),
                            new Card("7C"),
                        }
                    }
             };

            Hand round = new Hand();

            var result = round.SettleHand(players);

            result.Should().NotBeNull();
            result.Count.Should().Be(2);
        }

        [Theory]
        [MemberData(nameof(HighCardData))]
        [MemberData(nameof(PairData))]
        [MemberData(nameof(TwoPairData))]
        [MemberData(nameof(ThreeOfAKindData))]
        [MemberData(nameof(FourOfAKindData))]
        [MemberData(nameof(FlushData))]
        [MemberData(nameof(MultiPlayerData))]
        public void PlayerWins(List<Player> players, string winner)
        {          
            Hand round = new Hand();

            var result = round.SettleHand(players);

            result.Should().NotBeNull();
            result.Count.Should().Be(1);
            result[0].Name.Should().Be(winner);
        }

        public static IEnumerable<object[]> HighCardData =>
        new List<object[]>
        {
            new object[]
            { 
                new List<Player>
                {
                    new Player()
                    {
                        Name = "Garret",
                        Hand = new List<Card>()
                        {
                            new Card("3C"),
                            new Card("2D"),
                            new Card("9H"),
                            new Card("4C"),
                            new Card("7C"),
                        }
                    },
                    new Player()
                    {
                        Name = "Boone",
                        Hand = new List<Card>()
                        {
                            new Card("3C"),
                            new Card("2D"),
                            new Card("9H"),
                            new Card("KC"),
                            new Card("7C"),
                        }
                    }
                }, "Boone" 
            }            
        };
        public static IEnumerable<object[]> PairData =>
        new List<object[]>
        {
            new object[]
            {
                new List<Player>
                {
                    new Player()
                    {
                        Name = "Garret",
                        Hand = new List<Card>()
                        {
                            new Card("3C"),
                            new Card("9D"),
                            new Card("9H"),
                            new Card("4C"),
                            new Card("7C"),
                        }
                    },
                    new Player()
                    {
                        Name = "Boone",
                        Hand = new List<Card>()
                        {
                            new Card("3C"),
                            new Card("2D"),
                            new Card("9H"),
                            new Card("KC"),
                            new Card("7C"),
                        }
                    }
                }, "Garret"
            },
            new object[]
            {
                new List<Player>
                {
                    new Player()
                    {
                        Name = "Garret",
                        Hand = new List<Card>()
                        {
                            new Card("3C"),
                            new Card("9D"),
                            new Card("9H"),
                            new Card("4C"),
                            new Card("7C"),
                        }
                    },
                    new Player()
                    {
                        Name = "Boone",
                        Hand = new List<Card>()
                        {
                            new Card("3C"),
                            new Card("2D"),
                            new Card("KH"),
                            new Card("KC"),
                            new Card("7C"),
                        }
                    }
                }, "Boone"
            }
        };
        public static IEnumerable<object[]> TwoPairData =>
        new List<object[]>
        {
            new object[]
            {
                new List<Player>
                {
                    new Player()
                    {
                        Name = "Garret",
                        Hand = new List<Card>()
                        {
                            new Card("3C"),
                            new Card("9D"),
                            new Card("9H"),
                            new Card("4C"),
                            new Card("7C"),
                        }
                    },
                    new Player()
                    {
                        Name = "Boone",
                        Hand = new List<Card>()
                        {
                            new Card("3C"),
                            new Card("3D"),
                            new Card("9H"),
                            new Card("7C"),
                            new Card("7C"),
                        }
                    }
                }, "Boone"
            },
            new object[]
            {
                new List<Player>
                {
                    new Player()
                    {
                        Name = "Garret",
                        Hand = new List<Card>()
                        {
                            new Card("3C"),
                            new Card("KD"),
                            new Card("7H"),
                            new Card("3S"),
                            new Card("7C"),
                        }
                    },
                    new Player()
                    {
                        Name = "Boone",
                        Hand = new List<Card>()
                        {
                            new Card("3C"),
                            new Card("9D"),
                            new Card("KH"),
                            new Card("KC"),
                            new Card("9C"),
                        }
                    }
                }, "Boone"
            },
            new object[]
            {
                new List<Player>
                {
                    new Player()
                    {
                        Name = "Garret",
                        Hand = new List<Card>()
                        {
                            new Card("3C"),
                            new Card("KD"),
                            new Card("KH"),
                            new Card("3S"),
                            new Card("7C"),
                        }
                    },
                    new Player()
                    {
                        Name = "Boone",
                        Hand = new List<Card>()
                        {
                            new Card("3C"),
                            new Card("9D"),
                            new Card("KH"),
                            new Card("KC"),
                            new Card("9C"),
                        }
                    }
                }, "Boone"
            }
        };
        public static IEnumerable<object[]> ThreeOfAKindData =>
        new List<object[]>
        {
            new object[]
            {
                new List<Player>
                {
                    new Player()
                    {
                        Name = "Garret",
                        Hand = new List<Card>()
                        {
                            new Card("3C"),
                            new Card("9D"),
                            new Card("9H"),
                            new Card("9C"),
                            new Card("7C"),
                        }
                    },
                    new Player()
                    {
                        Name = "Boone",
                        Hand = new List<Card>()
                        {
                            new Card("3C"),
                            new Card("3D"),
                            new Card("3H"),
                            new Card("KC"),
                            new Card("7C"),
                        }
                    }
                }, "Garret"
            },
            new object[]
            {
                new List<Player>
                {
                    new Player()
                    {
                        Name = "Garret",
                        Hand = new List<Card>()
                        {
                            new Card("3C"),
                            new Card("9D"),
                            new Card("9H"),
                            new Card("9C"),
                            new Card("7C"),
                        }
                    },
                    new Player()
                    {
                        Name = "Boone",
                        Hand = new List<Card>()
                        {
                            new Card("3C"),
                            new Card("2D"),
                            new Card("KH"),
                            new Card("KC"),
                            new Card("7C"),
                        }
                    }
                }, "Garret"
            }
        };
        public static IEnumerable<object[]> FlushData =>
        new List<object[]>
        {
            new object[]
            {
                new List<Player>
                {
                    new Player()
                    {
                        Name = "Garret",
                        Hand = new List<Card>()
                        {
                            new Card("3C"),
                            new Card("9C"),
                            new Card("9C"),
                            new Card("9C"),
                            new Card("7C"),
                        }
                    },
                    new Player()
                    {
                        Name = "Boone",
                        Hand = new List<Card>()
                        {
                            new Card("3C"),
                            new Card("3D"),
                            new Card("3H"),
                            new Card("KC"),
                            new Card("7C"),
                        }
                    }
                }, "Garret"
            },
            new object[]
            {
                new List<Player>
                {
                    new Player()
                    {
                        Name = "Garret",
                        Hand = new List<Card>()
                        {
                            new Card("3C"),
                            new Card("9C"),
                            new Card("9C"),
                            new Card("9C"),
                            new Card("7C"),
                        }
                    },
                    new Player()
                    {
                        Name = "Boone",
                        Hand = new List<Card>()
                        {
                            new Card("4S"),
                            new Card("9S"),
                            new Card("9S"),
                            new Card("9S"),
                            new Card("7S"),
                        }
                    }
                }, "Boone"
            }
        };
        public static IEnumerable<object[]> FourOfAKindData =>
        new List<object[]>
        {
            new object[]
            {
                new List<Player>
                {
                    new Player()
                    {
                        Name = "Garret",
                        Hand = new List<Card>()
                        {
                            new Card("3C"),
                            new Card("9D"),
                            new Card("9H"),
                            new Card("9C"),
                            new Card("9D"),
                        }
                    },
                    new Player()
                    {
                        Name = "Boone",
                        Hand = new List<Card>()
                        {
                            new Card("3S"),
                            new Card("9S"),
                            new Card("2S"),
                            new Card("KS"),
                            new Card("7S"),
                        }
                    }
                }, "Garret"
            },
            new object[]
            {
                new List<Player>
                {
                    new Player()
                    {
                        Name = "Garret",
                        Hand = new List<Card>()
                        {
                            new Card("3C"),
                            new Card("9D"),
                            new Card("9H"),
                            new Card("9C"),
                            new Card("9S"),
                        }
                    },
                    new Player()
                    {
                        Name = "Boone",
                        Hand = new List<Card>()
                        {
                            new Card("3C"),
                            new Card("KD"),
                            new Card("KH"),
                            new Card("KC"),
                            new Card("KS"),
                        }
                    }
                }, "Boone"
            }
        };

        public static IEnumerable<object[]> MultiPlayerData =>
        new List<object[]>
        {
            new object[]
            {
                new List<Player>
                {
                    new Player()
                    {
                        Name = "Garret",
                        Hand = new List<Card>()
                        {
                            new Card("3C"),
                            new Card("9D"),
                            new Card("9H"),
                            new Card("4C"),
                            new Card("7C"),
                        }
                    },
                    new Player()
                    {
                        Name = "Boone",
                        Hand = new List<Card>()
                        {
                            new Card("3C"),
                            new Card("2D"),
                            new Card("9H"),
                            new Card("KC"),
                            new Card("7C"),
                        }
                    },
                    new Player()
                    {
                        Name = "Sully",
                        Hand = new List<Card>()
                        {
                            new Card("3C"),
                            new Card("2C"),
                            new Card("9C"),
                            new Card("KC"),
                            new Card("7C"),
                        }
                    }
                }, "Sully"
            },
            new object[]
            {
                new List<Player>
                {
                    new Player()
                    {
                        Name = "Garret",
                        Hand = new List<Card>()
                        {
                            new Card("3C"),
                            new Card("9D"),
                            new Card("9H"),
                            new Card("4C"),
                            new Card("7C"),
                        }
                    },
                    new Player()
                    {
                        Name = "Boone",
                        Hand = new List<Card>()
                        {
                            new Card("3C"),
                            new Card("2D"),
                            new Card("KH"),
                            new Card("KC"),
                            new Card("7C"),
                        }
                    },
                    new Player()
                    {
                        Name = "Sully",
                        Hand = new List<Card>()
                        {
                            new Card("3C"),
                            new Card("2C"),
                            new Card("9C"),
                            new Card("KC"),
                            new Card("7C"),
                        }
                    },
                    new Player()
                    {
                        Name = "Meaghan",
                        Hand = new List<Card>()
                        {
                            new Card("3C"),
                            new Card("4C"),
                            new Card("9C"),
                            new Card("KC"),
                            new Card("7C"),
                        }
                    },
                    new Player()
                    {
                        Name = "Kurt",
                        Hand = new List<Card>()
                        {
                            new Card("3C"),
                            new Card("2D"),
                            new Card("9H"),
                            new Card("4C"),
                            new Card("7C"),
                        }
                    }
                }, "Meaghan"
            }
        };
    }
}
