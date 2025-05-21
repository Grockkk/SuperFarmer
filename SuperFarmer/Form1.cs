using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace SuperFarmer
{
    public partial class Form1 : Form
    {

        private string[] pictures1;
        private string[] pictures2;

        Random rnd = new Random();

        private List<Player> players = new List<Player>();

        private int currentPlayerIndex = 0;

        private bool isDiceUsed;
        private bool exchangeUsed;

        public Form1()
        {
            InitializeComponent();

            // two folders for two dices
            string folder1 = Path.Combine(Application.StartupPath, "Dice1");
            string folder2 = Path.Combine(Application.StartupPath, "Dice2");

            pictures1 = Directory.GetFiles(folder1, "*.png");
            pictures2 = Directory.GetFiles(folder2, "*.png");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int liczbaGraczy = 0;

            while (liczbaGraczy < 2 || liczbaGraczy > 4)
            {
                string input = Microsoft.VisualBasic.Interaction.InputBox("Wybierz liczbę graczy (2–4):", "Start gry", "2");

                if (!int.TryParse(input, out liczbaGraczy))
                {
                    liczbaGraczy = 0;
                    MessageBox.Show("Niepoprawna ilość graczy");
                }
            }

            players.Clear();

            for (int i = 1; i <= liczbaGraczy; i++)
                players.Add(new Player($"Gracz{i}", i));

            isDiceUsed = false;
            exchangeUsed = false;

            SetCollumns(listView1);
            SetCollumns(listView2);
            SetCollumns(listView3);
            SetCollumns(listView4);
            SetCollumns(listView5);

            EnterValuesListView(players[0], listView1);
            EnterValuesListView(players[1], listView2);
            EnterValuesListView(players.Count > 2 ? players[2] : new Player("", 2), listView3);
            EnterValuesListView(players.Count > 3 ? players[3] : new Player("", 3), listView4);
            EnterValuesListViewStado();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (isDiceUsed) return;

            int index1 = rnd.Next(pictures1.Length);
            int index2 = rnd.Next(pictures2.Length);

            string file1 = Path.GetFileName(pictures1[index1]);
            string file2 = Path.GetFileName(pictures2[index2]);

            pictureBox1.Image = Image.FromFile(pictures1[index1]);
            pictureBox2.Image = Image.FromFile(pictures2[index2]);

            string animal1 = mapaObrazow[file1];
            string animal2 = mapaObrazow[file2];

            Player player = players[currentPlayerIndex];

            bool foxRolled = animal1 == "Lis" || animal2 == "Lis";
            bool wolfRolled = animal1 == "Wilk" || animal2 == "Wilk";

            if (wolfRolled)
            {
                if (player.BigDogsNumber > 0)
                {
                    player.BigDogsNumber--;
                    glowneStado["DużyPies"]++;
                }
                else
                {
                    glowneStado["Owca"] += player.SheepNumber;
                    glowneStado["Świnia"] += player.PigNumber;
                    glowneStado["Krowa"] += player.CowNumber;

                    player.SheepNumber = 0;
                    player.PigNumber = 0;
                    player.CowNumber = 0;
                }
            }

            if (foxRolled)
            {
                if (player.SmallDogsNumber > 0)
                {
                    player.SmallDogsNumber--;
                    glowneStado["MałyPies"]++;
                    MessageBox.Show("Mały pies ochronił przed lisem!");
                }
                else if (player.RabbitNumber > 1)
                {
                    glowneStado["Królik"] += player.RabbitNumber - 1;
                    player.RabbitNumber = 1;
                }
            }

            Dictionary<string, int> rolledAnimals = new();
            if (animal1 != "Lis" && animal1 != "Wilk") rolledAnimals[animal1] = 1;
            if (animal2 != "Lis" && animal2 != "Wilk")
            {
                if (rolledAnimals.ContainsKey(animal2)) rolledAnimals[animal2]++;
                else rolledAnimals[animal2] = 1;
            }

            Dictionary<string, int> zdobyte = new();

            foreach (var kvp in rolledAnimals)
            {
                string animal = kvp.Key;
                int rolledCount = kvp.Value;
                int currentCount = animal switch
                {
                    "Królik" => player.RabbitNumber,
                    "Owca" => player.SheepNumber,
                    "Świnia" => player.PigNumber,
                    "Krowa" => player.CowNumber,
                    "Koń" => player.HorseNumber,
                    _ => 0
                };

                if (currentCount > 0)
                {
                    int total = currentCount + rolledCount;
                    int newAnimals = total / 2;
                    if (newAnimals > 0)
                    {
                        zdobyte[animal] = newAnimals;
                    }
                }
                else if (rolledCount == 2)
                {
                    zdobyte[animal] = 1;
                }
            }

            foreach (var kvp in zdobyte)
            {
                string animal = kvp.Key;
                int amount = kvp.Value;

                if (glowneStado.ContainsKey(animal) && glowneStado[animal] >= amount)
                {
                    glowneStado[animal] -= amount;

                    switch (animal)
                    {
                        case "Królik": player.RabbitNumber += amount; break;
                        case "Owca": player.SheepNumber += amount; break;
                        case "Świnia": player.PigNumber += amount; break;
                        case "Krowa": player.CowNumber += amount; break;
                        case "Koń": player.HorseNumber += amount; break;
                        case "DużyPies": player.BigDogsNumber += amount; break;
                        case "MałyPies": player.SmallDogsNumber += amount; break;
                    }
                }
                else
                {
                    MessageBox.Show($"Brak wystarczającej liczby zwierząt w głównym stadzie: {animal}");
                }
            }

            bool wygrana = player.RabbitNumber > 0 &&
                           player.SheepNumber > 0 &&
                           player.PigNumber > 0 &&
                           player.CowNumber > 0 &&
                           player.HorseNumber > 0;

            if (wygrana)
            {
                MessageBox.Show($"{player.Name} wygrał grę!");
                DialogResult result = MessageBox.Show("Czy chcesz zagrać od nowa?", "Nowa gra", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes) Application.Restart();
                else Application.Exit();
                return;
            }

            RefreshAllViews();
            EnterValuesListViewStado();
            isDiceUsed = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!isDiceUsed)
            {
                MessageBox.Show("Musisz najpierw rzucić kostkami!");
                return;
            }

            currentPlayerIndex++;

            if (currentPlayerIndex >= players.Count)
            {
                currentPlayerIndex = 0;
            }

            isDiceUsed = false;

            EnterValuesListView(players[currentPlayerIndex], GetListViewByPlayerIndex(currentPlayerIndex));
            RefreshAllViews();

            pictureBox1.Image = null;
            pictureBox2.Image = null;
        }

        private void EnterValuesListView(Player gracz, ListView lv)
        {
            lv.Items.Clear();

            if (players.Contains(gracz))
            {
                lv.Items.Add(new ListViewItem(new[] { "Królik", gracz.RabbitNumber.ToString() }));
                lv.Items.Add(new ListViewItem(new[] { "Owca", gracz.SheepNumber.ToString() }));
                lv.Items.Add(new ListViewItem(new[] { "Świnia", gracz.PigNumber.ToString() }));
                lv.Items.Add(new ListViewItem(new[] { "Krowa", gracz.CowNumber.ToString() }));
                lv.Items.Add(new ListViewItem(new[] { "Koń", gracz.HorseNumber.ToString() }));
                lv.Items.Add(new ListViewItem(new[] { "Mały pies", gracz.SmallDogsNumber.ToString() }));
                lv.Items.Add(new ListViewItem(new[] { "Duży pies", gracz.BigDogsNumber.ToString() }));
            }
            else
            {
                for (int i = 0; i < 7; i++)
                {
                    lv.Items.Add(new ListViewItem(new[] { "", "-" }));
                }
            }
        }

        private void SetCollumns(ListView lv)
        {
            lv.View = View.Details;
            lv.Columns.Clear();
            lv.Columns.Add("Zwierze", 100);
            lv.Columns.Add("Ilość", 50);
        }

        private void EnterValuesListViewStado()
        {
            listView5.Items.Clear();

            listView5.Items.Add(new ListViewItem(new[] { "Królik", glowneStado["Królik"].ToString() }));
            listView5.Items.Add(new ListViewItem(new[] { "Owca", glowneStado["Owca"].ToString() }));
            listView5.Items.Add(new ListViewItem(new[] { "Świnia", glowneStado["Świnia"].ToString() }));
            listView5.Items.Add(new ListViewItem(new[] { "Krowa", glowneStado["Krowa"].ToString() }));
            listView5.Items.Add(new ListViewItem(new[] { "Koń", glowneStado["Koń"].ToString() }));
            listView5.Items.Add(new ListViewItem(new[] { "Mały pies", glowneStado["MałyPies"].ToString() }));
            listView5.Items.Add(new ListViewItem(new[] { "Duży pies", glowneStado["DużyPies"].ToString() }));
        }

        private void RefreshAllViews()
        {
            for (int i = 0; i < 4; i++)
            {
                var listView = GetListViewByPlayerIndex(i);

                if (i < players.Count)
                {
                    EnterValuesListView(players[i], listView);
                    listView.BackColor = (i == currentPlayerIndex) ? Color.LightYellow : Color.White;
                }
                else
                {
                    EnterValuesListView(new Player("", i), listView);
                    listView.BackColor = Color.LightGray;
                }
            }

            EnterValuesListViewStado();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var player = players[currentPlayerIndex];

            FormWymiana form = new FormWymiana(player, glowneStado, players, currentPlayerIndex);
            form.ShowDialog();

            if (!form.WymianaZatwierdzona)
                return;

            string from = form.FromAnimal;
            string to = form.ToAnimal;
            int amount = form.Amount;
            string target = form.WybranyCel;

            if (from == to)
            {
                MessageBox.Show("Nie można wymieniać tego samego zwierzęcia.");
                return;
            }

            if (target == "Stado główne")
            {
                if (!exchangeRates.TryGetValue((from, to), out int rate) &&
                    !exchangeRates.TryGetValue((to, from), out rate))
                {
                    MessageBox.Show("Nie ma takiej wymiany w tabeli.");
                    return;
                }

                if (exchangeRates.TryGetValue((from, to), out rate))
                {
                    int requiredFrom = rate * amount;

                    if (GetPlayerAnimalCount(player, from) < requiredFrom)
                    {
                        MessageBox.Show($"Masz za mało: {from} ({requiredFrom} potrzebne)");
                        return;
                    }

                    if (!glowneStado.ContainsKey(to) || glowneStado[to] < amount)
                    {
                        MessageBox.Show($"W stadzie nie ma tylu: {to}");
                        return;
                    }

                    ChangePlayerAnimalCount(player, from, -requiredFrom);
                    ChangePlayerAnimalCount(player, to, amount);
                    glowneStado[from] += requiredFrom;
                    glowneStado[to] -= amount;
                }
                else
                {
                    int requiredFrom = amount;
                    int giveTo = rate * amount;

                    if (GetPlayerAnimalCount(player, to) < giveTo)
                    {
                        MessageBox.Show($"Masz za mało: {to} ({giveTo} potrzebne)");
                        return;
                    }

                    if (!glowneStado.ContainsKey(from) || glowneStado[from] < requiredFrom)
                    {
                        MessageBox.Show($"Stado nie ma: {from}");
                        return;
                    }

                    ChangePlayerAnimalCount(player, to, -giveTo);
                    ChangePlayerAnimalCount(player, from, requiredFrom);
                    glowneStado[to] += giveTo;
                    glowneStado[from] -= requiredFrom;
                }
            }
            else
            {
                var targetPlayer = players.FirstOrDefault(p => p.Name == target);

                if (targetPlayer == null)
                {
                    MessageBox.Show("Nie znaleziono gracza docelowego.");
                    return;
                }

                if (!exchangeRates.TryGetValue((from, to), out int rate) &&
                    !exchangeRates.TryGetValue((to, from), out rate))
                {
                    MessageBox.Show("Nie ma takiej wymiany w tabeli.");
                    return;
                }

                if (exchangeRates.TryGetValue((from, to), out rate))
                {
                    int requiredFrom = rate * amount;

                    if (GetPlayerAnimalCount(player, from) < requiredFrom)
                    {
                        MessageBox.Show($"Nie masz wystarczającej liczby: {from} ({requiredFrom} potrzebne)");
                        return;
                    }

                    if (GetPlayerAnimalCount(targetPlayer, to) < amount)
                    {
                        MessageBox.Show($"{targetPlayer.Name} nie ma wystarczającej liczby: {to} ({amount} potrzebne)");
                        return;
                    }

                    ChangePlayerAnimalCount(player, from, -requiredFrom);
                    ChangePlayerAnimalCount(player, to, amount);

                    ChangePlayerAnimalCount(targetPlayer, to, -amount);
                    ChangePlayerAnimalCount(targetPlayer, from, requiredFrom);
                }
                else
                {
                    int requiredFrom = amount;
                    int giveTo = rate * amount;

                    if (GetPlayerAnimalCount(player, to) < giveTo)
                    {
                        MessageBox.Show($"Nie masz wystarczającej liczby: {to} ({giveTo} potrzebne)");
                        return;
                    }

                    if (GetPlayerAnimalCount(targetPlayer, from) < requiredFrom)
                    {
                        MessageBox.Show($"{targetPlayer.Name} nie ma wystarczającej liczby: {from} ({requiredFrom} potrzebne)");
                        return;
                    }

                    ChangePlayerAnimalCount(player, to, -giveTo);
                    ChangePlayerAnimalCount(player, from, requiredFrom);

                    ChangePlayerAnimalCount(targetPlayer, from, -requiredFrom);
                    ChangePlayerAnimalCount(targetPlayer, to, giveTo);
                }
            }

            MessageBox.Show("Wymiana zakończona sukcesem.");
            RefreshAllViews();
            EnterValuesListViewStado();
            exchangeUsed = true;
        }

        Dictionary<(string from, string to), int> exchangeRates = new Dictionary<(string, string), int>
        {
            { ("Królik", "Owca"), 6 },
            { ("Owca", "Świnia"), 2 },
            { ("Świnia", "Krowa"), 3 },
            { ("Krowa", "Koń"), 2 },
            { ("Owca", "MałyPies"), 1 },
            { ("Krowa", "DużyPies"), 1 }
        };

        private int GetPlayerAnimalCount(Player player, string animal)
        {
            return animal switch
            {
                "Królik" => player.RabbitNumber,
                "Owca" => player.SheepNumber,
                "Świnia" => player.PigNumber,
                "Krowa" => player.CowNumber,
                "Koń" => player.HorseNumber,
                "MałyPies" => player.SmallDogsNumber,
                "DużyPies" => player.BigDogsNumber,
                _ => 0
            };
        }

        private void ChangePlayerAnimalCount(Player player, string animal, int delta)
        {
            switch (animal)
            {
                case "Królik": player.RabbitNumber += delta; break;
                case "Owca": player.SheepNumber += delta; break;
                case "Świnia": player.PigNumber += delta; break;
                case "Krowa": player.CowNumber += delta; break;
                case "Koń": player.HorseNumber += delta; break;
                case "MałyPies": player.SmallDogsNumber += delta; break;
                case "DużyPies": player.BigDogsNumber += delta; break;
            }
        }

        private Dictionary<string, string> mapaObrazow = new Dictionary<string, string>
        {
            { "rabbit1.png", "Królik" },
            { "rabbit2.png", "Królik" },
            { "rabbit3.png", "Królik" },
            { "rabbit4.png", "Królik" },
            { "rabbit5.png", "Królik" },
            { "rabbit6.png", "Królik" },
            { "sheep1.png", "Owca" },
            { "sheep2.png", "Owca" },
            { "sheep3.png", "Owca" },
            { "pig1.png", "Świnia" },
            { "pig2.png", "Świnia" },
            { "cow.png", "Krowa" },
            { "horse.png", "Koń" },
            { "fox.png", "Lis" },
            { "wolf.png", "Wilk" }
        };

        private Dictionary<string, int> glowneStado = new Dictionary<string, int>
        {
            { "Królik", 60 },
            { "Owca", 24 },
            { "Świnia", 20 },
            { "Krowa", 12 },
            { "Koń", 6 },
            { "MałyPies", 4 },
            { "DużyPies", 2 }
        };

        private ListView GetListViewByPlayerIndex(int index)
        {
            switch (index)
            {
                case 0: return listView1;
                case 1: return listView2;
                case 2: return listView3;
                case 3: return listView4;
                default: return null;
            }
        }
    }
}
