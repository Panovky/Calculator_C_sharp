namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // ����������� ����� ������ ��������� � ������� ������� �� ���� ������� �� 2 �������
        async void show_error_message()
        {
            label.Text = "";
            labelError.Visible = true;
            await Task.Delay(2000);
            labelError.Visible = false;
        }

        // ����� ���������, ����� �� ���������� �������� - ����� n - � textBox
        // � ���� �����, ������ ���
        void print_n(string n)
        {
            string tl = label.Text;
            string tt = textBox.Text;

            // ���� label ������ ��� ��� ���� ���� �������������� �������� ������ �� ����� 
            if (tl == "" || tl[^1] == '+' || tl[^1] == '-' || tl[^1] == '*' || tl[^1] == '/')
            {
                if (n != "0" && (tt == "" || tt != "" && (tt[0] != '0' || tt.Contains(','))))
                {
                    textBox.Text += n;
                }
                // ��������� �������� ��� ���� (����� ��������� ���������� ����):
                // ���� ���� ��� ����� ����� ������ ��� ����� �� ���������� � ���� ��� � ����� ���� �������
                else if (n == "0" && (tt == "" || tt[0] != '0' || tt.Contains(',')))
                {
                    textBox.Text += "0";
                }
            }
        }

        double do_math_operation()
        {
            // ��������� ����� ��������, ������� ���������� ���������
            char math_sign = label.Text[^1];

            // ��������� ������ ��������
            double a = Convert.ToDouble(label.Text.Substring(0, label.Text.Length - 1));

            // ��������� ������� ��������
            double b = Convert.ToDouble(textBox.Text);

            switch (math_sign)
            {
                case '+':
                    return a + b;
                case '-':
                    return a - b;
                case '*':
                    return a * b;
                case '/':
                    return a / b;
            }

            return 0;
        }

        void buttonOperation_Click(string math_sign)
        {
            string tl = label.Text;

            if (tl == "" && textBox.Text != "")
            {
                // ������� ����� � label ������ �� ������ �������������� ��������
                label.Text = $"{textBox.Text}{math_sign}";
                textBox.Clear();
            }
            else if (tl != "" && (tl[^1] != '+' && tl[^1] != '-' && tl[^1] != '*' && tl[^1] != '/'))
            {
                // ������������ ����� �������������� �������� ������ �� ����� � label
                label.Text += math_sign;
            }
            else if (tl != "" && textBox.Text == "" && (tl[^1] == '+' || tl[^1] == '-' || tl[^1] == '*' || tl[^1] == '/'))
            {
                // ����� ����� �������������� ��������
                label.Text = $"{label.Text.Substring(0, label.Text.Length - 1)}{math_sign}";
            }
            else if (textBox.Text != "")
            {
                // �������� �� ������� �� ����
                if (tl[^1] == '/' && textBox.Text == "0")
                {
                    show_error_message(); 
                }
                else 
                {
                    // ������ ���������� �������������� �������� � label
                    label.Text = $"{do_math_operation()}{math_sign}";
                }
                textBox.Clear();
            }
        }

        private void button0_Click(object sender, EventArgs e)
        {
            print_n("0");                
        }

        private void button1_Click(object sender, EventArgs e)
        {
            print_n("1");  
        }

        private void button2_Click(object sender, EventArgs e)
        {
            print_n("2");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            print_n("3");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            print_n("4");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            print_n("5");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            print_n("6");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            print_n("7");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            print_n("8");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            print_n("9");
        }

        private void buttonEqual_Click(object sender, EventArgs e)
        {
            string tl = label.Text;
            string tt = textBox.Text;

            // �������� �� ��, ����� �� ��������� �������� �� ������� ������ "�����"
            if (tt != "")
            {
                if (tl == "")
                {
                    // ������� ����� �� textBox � label
                    label.Text = tt;
                    textBox.Clear();
                }
                else
                {
                    // �������� �� ������� �� ����
                    if (tl[^1] == '/' && tt == "0")
                    {
                        show_error_message();
                    }
                    else
                    {
                        // ������ ���������� �������������� �������� � label
                        label.Text = Convert.ToString(do_math_operation());
                    }
                    textBox.Clear();
                }
            }
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            buttonOperation_Click("+");
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            buttonOperation_Click("-");
        }

        private void buttonMultiply_Click(object sender, EventArgs e)
        {
            buttonOperation_Click("*");
        }

        private void buttonDivide_Click(object sender, EventArgs e)
        {
            buttonOperation_Click("/");
        }

        private void buttonComma_Click(object sender, EventArgs e)
        {
            string b = textBox.Text;

            // �������� �� ����������� ������ ������� � textBox
            if (b != "" && !b.Contains(",")) 
            {
                textBox.Text += ",";
            }  
        }

        private void buttonC_Click(object sender, EventArgs e)
        {
            // �������� � label, � textBox
            label.Text = "";
            textBox.Clear();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            if (textBox.Text == "" && label.Text != "")
            {
                textBox.Text = label.Text;
                label.Text = "";

                // � textBox ������������ ������, ����������� �� ���� ������ ������
                textBox.Text = textBox.Text.Substring(0, textBox.Text.Length - 1);
            }
            else if (textBox.Text != "")
            {
                // � textBox ������������ ������, ����������� �� ���� ������ ������
                textBox.Text = textBox.Text.Substring(0, textBox.Text.Length - 1);
            }

            
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            if (textBox.Text != "") 
            {
                // ��������� ������� �������� �� textBox
                double b = Convert.ToDouble(textBox.Text);

                // ����������� ������� �������� � ��������������� ������ � textBox 
                textBox.Text = Convert.ToString(-b);
            } 
        }
    }
}