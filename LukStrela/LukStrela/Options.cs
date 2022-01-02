using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LukStrela
{
    public partial class Options : Form
    {
        private int brojBalona, brzinaStrijele, brzinaCrtanjaBalona;
        public Options()
        {
            InitializeComponent();
            tbBrojBalona.Focus();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            bool proveraBrojaBalona = int.TryParse(tbBrojBalona.Text, out brojBalona);
            bool provereBrzineStrijele = int.TryParse(tbBrzinaStrijele.Text, out brzinaStrijele);
            bool proveraBrzineCrtanjaBalona = int.TryParse(tbBrzinaCrtanjaBalona.Text, out brzinaCrtanjaBalona);
            if(proveraBrojaBalona == true && provereBrzineStrijele == true && proveraBrzineCrtanjaBalona == true)
            {
                if(brojBalona > 0 && brzinaStrijele > 0 && brzinaCrtanjaBalona > 0)
                {
                    Form1 form1 = new Form1(brojBalona, brzinaStrijele, brzinaCrtanjaBalona);
                    form1.ShowDialog();
                    Reset();
                }
                else
                {
                    MessageBox.Show("Sva polja moraju biti cijeli brojevi veći od nule!");
                    Reset();
                }
            }
            else
            {
                MessageBox.Show("Sva polja moraju biti cijeli brojevi veći od nule!");
                Reset();
            }
        }
        private void Reset()
        {
            tbBrojBalona.Clear();
            tbBrzinaStrijele.Clear();
            tbBrzinaCrtanjaBalona.Clear();
            tbBrojBalona.Focus();
        }
    }
}
