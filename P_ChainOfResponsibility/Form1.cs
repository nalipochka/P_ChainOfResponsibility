
using System.Text;

namespace P_ChainOfResponsibility
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double diametr, weight;
                if (!double.TryParse(textBox1.Text, out diametr))
                    throw new Exception("Enter data correctly!");
                if (!double.TryParse(textBox2.Text, out weight))
                    throw new Exception("Enter data correctly!");
                Coin coin = new Coin { Diametr = diametr, Weight = weight };
                FiveCoinHandler fiveCoin = new FiveCoinHandler();
                TenCoinHandler tenCoin = new TenCoinHandler();
                TwentyFiveCoinHandler twentyFiveCoin = new TwentyFiveCoinHandler();
                FiftyCoinHandler fiftyCoin = new FiftyCoinHandler();
                HryvniaCoinHandler hryvniaCoin = new HryvniaCoinHandler();
                NullCoinHandler nullCoin = new NullCoinHandler();
                fiveCoin.Successor = tenCoin;
                tenCoin.Successor = twentyFiveCoin;
                twentyFiveCoin.Successor = fiftyCoin;
                fiftyCoin.Successor = hryvniaCoin;
                hryvniaCoin.Successor = nullCoin;

                double accepted—oin = fiveCoin.Handle(coin);

                if (accepted—oin == 0)
                    throw new Exception("Coin not recognized!");

                if (textBox3.Text == "0.00")
                    textBox3.Text = accepted—oin.ToString();
                else
                {
                    if (!double.TryParse(textBox3.Text, out double res))
                        throw new Exception("Result error!");
                    else
                    {
                        res += accepted—oin;
                        textBox3.Text = res.ToString();
                    }
                }
                StringBuilder sb = new StringBuilder(textBox4.Text);
                sb.AppendLine($"Added coin: {accepted—oin}");
                textBox4.Text = sb.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "24,0";
            textBox2.Text = "4,30";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "16,3";
            textBox2.Text = "1,70";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "20,8";
            textBox2.Text = "2,90";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = "23,0";
            textBox2.Text = "4,20";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text = "26,0";
            textBox2.Text = "7,10";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }
    }
}