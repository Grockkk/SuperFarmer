using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SuperFarmer
{
    public partial class FormWymiana : Form
    {
        private Player player;
        private Dictionary<string, int> glowneStado;
        public bool WymianaZatwierdzona { get; private set; } = false;

        public string FromAnimal => BoxFrom.SelectedItem?.ToString();
        public string ToAnimal => BoxTo.SelectedItem?.ToString();
        public int Amount => int.TryParse(textAmount.Text, out int val) ? val : 0;
        private List<Player> wszyscyGracze;
        private int indeksAktualnegoGracza;
        public string WybranyCel => comboTarget.SelectedItem?.ToString();

        public FormWymiana(Player gracz, Dictionary<string, int> stado, List<Player> gracze, int aktywnyIndex)
        {
            InitializeComponent();

            player = gracz;
            glowneStado = stado;
            wszyscyGracze = gracze;
            indeksAktualnegoGracza = aktywnyIndex;

            BoxFrom.Items.AddRange(new string[] {
                "Królik", "Owca", "Świnia", "Krowa", "Koń", "MałyPies", "DużyPies"
            });

            BoxTo.Items.AddRange(new string[] {
                "Królik", "Owca", "Świnia", "Krowa", "Koń", "MałyPies", "DużyPies"
            });

            comboTarget.Items.Add("Stado główne");

            for (int i = 0; i < gracze.Count; i++)
            {
                if (i != aktywnyIndex)
                {
                    comboTarget.Items.Add(gracze[i].Name);
                }
            }

            comboTarget.SelectedIndex = 0;
            UzupelnijTabeleWymian();
        }

        private void Accept_Click(object sender, EventArgs e)
        {
            if (FromAnimal == null || ToAnimal == null || Amount <= 0)
            {
                MessageBox.Show("Uzupełnij poprawnie wszystkie pola.");
                return;
            }

            WymianaZatwierdzona = true;
            this.Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UzupelnijTabeleWymian()
        {
            TabelaWymian.View = View.Details;
            TabelaWymian.Columns.Clear();
            TabelaWymian.Items.Clear();

            TabelaWymian.Columns.Add("Zabierasz", 120);
            TabelaWymian.Columns.Add("Oddajesz", 120);

            var wymiany = new Dictionary<string, string>
            {
                { "1 Owca", "6 Królików" },
                { "1 Świnia", "2 Owce" },
                { "1 Krowa", "3 Świnie" },
                { "1 Koń", "2 Krowy" },
                { "1 Mały pies", "1 Owca" },
                { "1 Duży pies", "1 Krowa" }
            };

            foreach (var wpis in wymiany)
            {
                var item = new ListViewItem(wpis.Key);
                item.SubItems.Add(wpis.Value);
                TabelaWymian.Items.Add(item);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
