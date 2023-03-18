namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // асинхронный метод делает сообщение о запрете деления на ноль видимым на 2 секунды
        async void show_error_message()
        {
            label.Text = "";
            labelError.Visible = true;
            await Task.Delay(2000);
            labelError.Visible = false;
        }

        // метод проверяет, можно ли напечатать аргумент - цифру n - в textBox
        // и если можно, делает это
        void print_n(string n)
        {
            string tl = label.Text;
            string tt = textBox.Text;

            // если label пустая или там есть знак математической операции справа от числа 
            if (tl == "" || tl[^1] == '+' || tl[^1] == '-' || tl[^1] == '*' || tl[^1] == '/')
            {
                if (n != "0" && (tt == "" || tt != "" && (tt[0] != '0' || tt.Contains(','))))
                {
                    textBox.Text += n;
                }
                // отдельная проверка для нуля (чтобы исключить незначащие нули):
                // если поле для ввода числа пустое или число не начинается с нуля или в числе есть запятая
                else if (n == "0" && (tt == "" || tt[0] != '0' || tt.Contains(',')))
                {
                    textBox.Text += "0";
                }
            }
        }

        double do_math_operation()
        {
            // получение знака операции, которую необходимо выполнить
            char math_sign = label.Text[^1];

            // получение левого операнда
            double a = Convert.ToDouble(label.Text.Substring(0, label.Text.Length - 1));

            // получение правого операнда
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
                // перенос числа в label вместо со знаком математической операции
                label.Text = $"{textBox.Text}{math_sign}";
                textBox.Clear();
            }
            else if (tl != "" && (tl[^1] != '+' && tl[^1] != '-' && tl[^1] != '*' && tl[^1] != '/'))
            {
                // приписывание знака математической операции справа от числа в label
                label.Text += math_sign;
            }
            else if (tl != "" && textBox.Text == "" && (tl[^1] == '+' || tl[^1] == '-' || tl[^1] == '*' || tl[^1] == '/'))
            {
                // смена знака математической операции
                label.Text = $"{label.Text.Substring(0, label.Text.Length - 1)}{math_sign}";
            }
            else if (textBox.Text != "")
            {
                // проверка на деление на ноль
                if (tl[^1] == '/' && textBox.Text == "0")
                {
                    show_error_message(); 
                }
                else 
                {
                    // запись результата математической операции в label
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

            // проверка на то, нужно ли совершать действие по нажатию кнопки "равно"
            if (tt != "")
            {
                if (tl == "")
                {
                    // перенос числа из textBox в label
                    label.Text = tt;
                    textBox.Clear();
                }
                else
                {
                    // проверка на деление на ноль
                    if (tl[^1] == '/' && tt == "0")
                    {
                        show_error_message();
                    }
                    else
                    {
                        // запись результата математической операции в label
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

            // проверка на возможность печати запятой в textBox
            if (b != "" && !b.Contains(",")) 
            {
                textBox.Text += ",";
            }  
        }

        private void buttonC_Click(object sender, EventArgs e)
        {
            // очищение и label, и textBox
            label.Text = "";
            textBox.Clear();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            if (textBox.Text == "" && label.Text != "")
            {
                textBox.Text = label.Text;
                label.Text = "";

                // в textBox возвращается строка, укороченная на один символ справа
                textBox.Text = textBox.Text.Substring(0, textBox.Text.Length - 1);
            }
            else if (textBox.Text != "")
            {
                // в textBox возвращается строка, укороченная на один символ справа
                textBox.Text = textBox.Text.Substring(0, textBox.Text.Length - 1);
            }

            
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            if (textBox.Text != "") 
            {
                // получение правого операнда из textBox
                double b = Convert.ToDouble(textBox.Text);

                // возвращение правого операнда с противоположным знаком в textBox 
                textBox.Text = Convert.ToString(-b);
            } 
        }
    }
}