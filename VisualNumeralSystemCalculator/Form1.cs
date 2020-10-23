using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public static char[] arr = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        static public string ConvertFromIntPos(string num, int sys1, int sys2){
            string res = "";
            long InTen = 0;
            for(int i=0; i<num.Length; i++){
                InTen += Array.IndexOf(arr, num[i]) * Convert.ToInt64(Math.Pow(sys1,num.Length-i-1));}
            while (InTen!=0){
                res = arr[InTen % sys2]+res;
                InTen /= sys2;}
            return res;}
        static public string ConvertNegative(string num)
        {
            string pos = ConvertFromIntPos(num.Substring(1, num.Length - 1), 10, 2);
            string nepos = "0";
            for (int i = 0; i < pos.Length; i++)
            {
                if (pos[i] == '0')
                {
                    nepos += 1;
                }
                else
                {
                    nepos += 0;
                }
            }
            int k = 0;
            char[] arr = nepos.ToCharArray();
            while (arr[arr.Length - 1 - k] != '0')
            {
                arr[arr.Length - 1 - k] = '0';
                k++;
            }
            arr[arr.Length - 1 - k] = '1';
            nepos = "";
            for(int i=0; i<arr.Length; i++)
            {
                nepos += arr[i];
            }
            if (nepos[0] == '0')
            {
                nepos = nepos.Substring(1, nepos.Length - 1);
            }
            int l = 8;
            while (l < nepos.Length)
            {
                l += 8;
            }
            string bbb = "";
            for(int i = 0; i< l-nepos.Length; i++)
            {
                bbb += "1";
            }
            bbb += nepos;
            char[] g = bbb.ToCharArray();
            g[0] = '1';
            bbb = "";
            for (int i = 0; i < g.Length; i++)
            {
                bbb += g[i];
            }
            return "1."+bbb;
        }
        static public string ConvertFromDoubPos(string num, int sys1, int sys2)
        {
            string Int = num.Substring(0, num.IndexOf('.'));
            num = num.Replace(".", "");
            double InTen = 0;
            
            for (int i = 0; i < num.Length; i++)
            {
                InTen += Array.IndexOf(arr, num[i]) * Math.Pow(sys1, Int.Length - i - 1);
            }
            string res = ConvertFromIntPos(Int.ToString(), sys1, sys2)+".";
            double Double = InTen%1;
            int k = 0;
            while (Double != 0 && k<7)
            {
                res += arr[Convert.ToInt32(Double*sys2 - (Double * sys2) % 1)];
                Double = (Double * sys2) % 1;
                k++;
            }
            return res;
        }
        static public int FromLetterToInt (char c, char[] arr)
        {
            for(int i=0; i<arr.Length; i++)
            {
                if(arr[i] == c)
                {
                    return i;
                }
            }
            return -1;
        }
        static public char[] SubArray (int i)
        {
            char[] newarr = new char[i];
            for(int j=0; j<i; j++)
            {
                newarr[j] = arr[j];
            }
            return newarr;
        }
        static public void AddStandartText(RichTextBox r, string str)
        {
            r.SelectionFont = new Font(r.Font, FontStyle.Regular);
            r.SelectedText = str;
        }
        static public void AddStandartRedText(RichTextBox r, string str)
        {
            r.SelectionFont = new Font(r.Font, FontStyle.Regular);
            r.SelectionColor = Color.Black;
            r.SelectedText = str;
        }
        static public void AddUnderlineText(RichTextBox r, string str)
        {
            r.SelectionFont = new Font(r.Font, FontStyle.Underline);
            r.SelectedText = str;
        }
        static public string GetSpaces(int i)
        {
            string str = "";
            for(int j=0; j<i; j++)
            {
                str += " ";
            }
            return str;
        }
        static public string GetStringWithMetka(bool[] metka)
        {
            string str = "";
            for(int i=0; i<metka.Length; i++)
            {
                if (metka[i])
                {
                    str += ".";
                }
                else
                {
                    str += " ";
                }
            }
            return str;
        }
        static public string StringMinusString(string str1, string str2, int CC)
        {
            long l1 = long.Parse(ConvertFromIntPos(str1, CC, 10));
            long l2 = long.Parse(ConvertFromIntPos(str2, CC, 10));
            return ConvertFromIntPos((l1 - l2) + "", 10, CC);
        }
        static public string MaxStringInString(string str1, string str2, int CC)
        {
            long l1 = long.Parse(ConvertFromIntPos(str1, CC, 10));
            long l2 = long.Parse(ConvertFromIntPos(str2, CC, 10));
            return ConvertFromIntPos((l2*(l1/l2)) + "", 10, CC);
        }
        static public long StringDivisionString(string str1, string str2, int CC)
        {
            long l1 = long.Parse(ConvertFromIntPos(str1, CC, 10));
            long l2 = long.Parse(ConvertFromIntPos(str2, CC, 10));
            return l1/l2;
        }
        static public bool OnlyZero(string str)
        {
            for(int i=0; i<str.Length; i++)
            {
                if (str[i] != '0')
                {
                    return false;
                }
            }
            return true;
        }
        static public int HowManyZeroInBegin(string str)
        {
            int d = 0;
            while (str[d] == '0')
            {
                d++;
                if (d == str.Length)
                {
                    break;
                }
            }
            return d;
        }
        static public void OperationPLUS(RichTextBox r, string str1, string  str2, int CC)
        {
            
            if (str2.Length > str1.Length)
            {
                string s = str1;
                str1 = str2;
                str2 = s;
            }
            bool[] metka = new bool[str1.Length + 1];
            metka[metka.Length - 1] = false;
            string str3 = "";
            for(int j=0; j<str2.Length; j++)
            {
                int cur = FromLetterToInt(str1[str1.Length - j - 1], arr)+ FromLetterToInt(str2[str2.Length - j - 1], arr);
                if (metka[metka.Length - 1 - j])
                {
                    cur++;
                }
                str3 = arr[cur % CC] + str3;
                if (cur / CC == 1)
                {
                    metka[metka.Length - 2 - j] = true;
                }
                
            }
            for(int j=str1.Length-str2.Length-1; j>=0; j--)
            {

                int cur = FromLetterToInt(str1[j], arr);
                if (metka[j+1])
                {
                    cur++;
                }
                if (cur / CC == 1)
                {
                    metka[j] = true;
                }
                str3 = arr[cur % CC] + str3;
            }
            if (metka[0])
            {
                str3 = 1 + str3;
            }
            str3 = GetSpaces(str1.Length + 1 - str3.Length) + str3;
            AddStandartRedText(r, GetStringWithMetka(metka)+"\n");
            AddStandartText(r, $" {str1}\n");
            AddStandartText(r, $"+");
            AddUnderlineText(r, $"{GetSpaces(str1.Length-str2.Length)}{str2}\n");
            AddStandartRedText(r, str3);
        }
        static public void OperationMINUS(RichTextBox r, string str1, string str2, int CC)
        {
            bool MINUS = false;
            string str10 = ConvertFromIntPos(str1, CC, 10);
            string str20 = ConvertFromIntPos(str2, CC, 10);
            if (long.Parse(str10) < long.Parse(str20))
            {
                MINUS = true;
                string s = str1;
                str1 = str2;
                str2 = s;
            }
            bool[] metka = new bool[str1.Length + 1];
            metka[metka.Length - 1] = false;
            string str3 = "";

            for (int j = 0; j < str2.Length; j++)
            {
                int cur = FromLetterToInt(str1[str1.Length - j - 1], arr) - FromLetterToInt(str2[str2.Length - j - 1], arr);
                if (metka[metka.Length - 1 - j])
                {
                    cur--;
                }
                if (cur<0)
                {
                    cur += CC;
                    metka[metka.Length - 2 - j] = true;
                }
                str3 = arr[cur % CC] + str3;

            }
            for (int j = str1.Length - str2.Length - 1; j >= 0; j--)
            {

                int cur = FromLetterToInt(str1[j], arr);
                if (metka[j + 1])
                {
                    cur--;
                }
                if (cur<0)
                {
                    metka[j] = true;
                    cur += CC;
                }
                str3 = arr[cur % CC] + str3;
            }
            while (str3[0] == '0' && str3.Length!=1)
            {
                str3 = str3.Substring(1);
            }
            if (!MINUS)
            {
                str3 = GetSpaces(str1.Length + 1 - str3.Length) + str3;
                AddStandartRedText(r, GetStringWithMetka(metka) + "\n");
                AddUnderlineText(r, $" ");
                AddStandartText(r, $"{str1}\n");
                AddStandartText(r, $" ");
                AddUnderlineText(r, $"{GetSpaces(str1.Length - str2.Length)}{str2}\n");
                AddStandartRedText(r, str3);
            }
            else
            {
                str3 = '-' + str3;
                str1 = '-' + str1;
                str3 = GetSpaces(str1.Length + 1 - str3.Length) + str3;
                AddStandartText(r, $" ");
                AddStandartRedText(r, GetStringWithMetka(metka) + "\n");
                AddStandartText(r, $" ");
                AddStandartText(r, $"{str1}\n");
                AddStandartText(r, $"+");
                AddUnderlineText(r, $"{GetSpaces(str1.Length - str2.Length)}{str2}\n");
                AddStandartRedText(r, str3);
            }
        }
        static public void OperationMULTIPLY(RichTextBox r, string str1, string str2, int CC)
        {
            if (str1.Length<str2.Length)
            {
                string s = str1;
                str1 = str2;
                str2 = s;
            }
            string[] results = new string[str2.Length];
            for(int i=0; i<str2.Length; i++)
            {
                string str3 = "";
                int[] metka = new int[str1.Length + 1];
                metka[metka.Length - 1] = 0;
                for(int j=str1.Length-1; j>=0; j--)
                {
                    int cur = FromLetterToInt(str1[j], arr) * FromLetterToInt(str2[i], arr) + metka[j + 1];
                    str3 = arr[cur % CC]+str3;
                    metka[j] = cur / CC;
                }
                if (metka[0] != 0)
                {
                    str3 = arr[metka[0]] + str3;
                }
                results[i] = str3;
            }
            str1 = " " + str1;
            int len = str1.Length;
            if (results.Length > 1)
            {
                 len = results[results.Length-1].Length+results.Length;
            }
            
            AddStandartText(r, GetSpaces(len-str1.Length)+$"{str1}\n");
            AddStandartText(r, GetSpaces(len - str1.Length) + $"x");
            AddUnderlineText(r, GetSpaces(str1.Length - 1 - str2.Length) + str2+"\n");
            if (results.Length == 1)
            {
                AddStandartRedText(r, GetSpaces(len - results[0].Length) + results[0]);
            }

            else
            {
                for(int i=0; i<results.Length; i++)
                {

                    if (i == (results.Length-1) / 2 && results.Length-1!=i)
                    {
                        AddStandartText(r, "+" + GetSpaces(len - results[results.Length-1-i].Length - 1 - i) + results[results.Length - 1 - i] + GetSpaces(i)+"\n");
                    }
                    else if (i == (results.Length - 1) / 2 && results.Length - 1 == i)
                    {
                        AddStandartText(r, "+");
                        AddUnderlineText(r, GetSpaces(len - results[results.Length - 1 - i].Length - 1 - i) + results[results.Length - 1 - i] + GetSpaces(i) + "\n");
                    }
                    else if (i == results.Length - 1)
                    {
                        AddStandartText(r, GetSpaces(len - results[results.Length - 1 - i].Length - i));
                        AddUnderlineText(r, results[results.Length - 1 - i] + GetSpaces(i) + "\n");
                    }
                    else
                    {
                        AddStandartText(r, GetSpaces(len - results[results.Length - 1 - i].Length - i) + results[results.Length - 1 - i] + GetSpaces(i) + "\n");
                    }
                }
            }
            string answer = "";
            for (int i = 0; i <results.Length; i++)
            {
                for (int j = 0; j < results.Length-1-i; j++)
                {
                    results[i] += "0";
                }
                int l = results[i].Length;
                for (int j = 0; j < len - 1 - l; j++)
                {
                    results[i] = "0" + results[i];
                }
            }
            int[] metka0 = new int[len];
            metka0[metka0.Length - 1] = 0;
            for (int i = 0; i < len - 1; i++)
            {
                int cur = 0;
                for (int j = 0; j < results.Length; j++)
                {
                    cur += FromLetterToInt(results[j][results[j].Length - 1-i], arr);
                }
                cur += metka0[len - 1 - i];
                answer = arr[cur % CC]+answer;
                metka0[len - 2 - i] = cur / CC;
            }
            if (metka0[0] != 0)
            {
                answer = arr[metka0[0]] + answer;
            }
            if (results.Length != 1)
            {
                AddStandartRedText(r, GetSpaces(len-answer.Length)+answer);
            }
        }
        static public void OperationDIVISION(RichTextBox r, string str1, string str2, int CC)
        {
            long i1 = long.Parse(ConvertFromIntPos(str1, CC, 10));
            long i2 = long.Parse(ConvertFromIntPos(str2, CC, 10));
            string string1 = str1;
            string[] num1 = new string[1];
            string[] num2 = new string[1];
            string[] num3 = new string[1];
            string answer = "";   
            bool t = true;
            while (t)
            {
                if (num1[0] == null )
                {
                    if (i1 < i2)
                    {
                        answer = "0,";
                        int temp = 0;
                        while (i1 < i2)
                        {
                            string1 += "0";
                            i1 = long.Parse(ConvertFromIntPos(string1, CC, 10));
                            if (temp == 0)
                            {
                                temp++;
                            }
                            else
                            {
                                answer += "0";
                            }
                        }
                        num1[0] = string1;
                        num2[0] = MaxStringInString(string1, str2, CC);
                        num3[0] = StringMinusString(string1, num2[0], CC);
                        answer += arr[StringDivisionString(num1[0], str2, CC)];
                    }
                    else
                    {
                        if(long.Parse(ConvertFromIntPos(str1.Substring(0, str2.Length), CC, 10)) < i2)
                        {
                            num1[0] = str1.Substring(0, str2.Length + 1);
                        }
                        else
                        {
                            num1[0] = str1.Substring(0, str2.Length);
                        }
                        num2[0] = MaxStringInString(num1[0], str2, CC);
                        num3[0] = StringMinusString(num1[0], num2[0], CC);
                        answer += arr[StringDivisionString(num1[0], str2, CC)];
                    }
                }
                else
                {
                    string1 = string1.Substring(num1[num1.Length-1].Length);
                    string1 = num3[num3.Length - 1] + string1;
                    if (string1 == "")
                    {
                        t = false;
                        break;
                    }
                    if (OnlyZero(string1))
                    {
                        answer += string1;
                        t = false;
                        break;
                    }
                    if (long.Parse(ConvertFromIntPos(string1, CC, 10))< i2)
                    {
                        for(int i = 0; i<string1.Length-num3[num3.Length-1].Length; i++)
                        {
                            answer += "0";
                        }
                        if (answer.IndexOf(",") == -1)
                        {
                            answer += ",";
                        }
                        string1 = string1 + "0";
                        while (long.Parse(ConvertFromIntPos(string1, CC, 10)) < i2)
                        {
                            string1 += "0";
                            answer += "0";
                        }
                        Array.Resize(ref num1, num1.Length + 1);
                        Array.Resize(ref num2, num2.Length + 1);
                        Array.Resize(ref num3, num3.Length + 1);
                        num1[num1.Length - 1] = string1;
                        num2[num2.Length - 1] = MaxStringInString(string1, str2, CC);
                        num3[num3.Length - 1] = StringMinusString(string1, num2[num2.Length - 1], CC);

                        answer += arr[StringDivisionString(string1, str2, CC)];
                    }
                    else
                    {
                       
                        Array.Resize(ref num1, num1.Length + 1);
                        Array.Resize(ref num2, num2.Length + 1);
                        Array.Resize(ref num3, num3.Length + 1);
                        //while (string1[0] == '0')
                        //{
                        //    answer += "0";
                        //    string1 = string1.Substring(1);
                        //}
                        if (long.Parse(ConvertFromIntPos(string1.Substring(0, str2.Length), CC, 10)) < i2)
                        {
                            num1[num1.Length-1] = string1.Substring(0, str2.Length + 1);
                            
                        }
                        else
                        {
                            num1[num1.Length-1] = string1.Substring(0, str2.Length);
                        }
                        for (int i = 1; i < num1[num1.Length - 1].Length - num3[num3.Length - 2].Length; i++)
                        {
                            answer += "0";
                        }

                        num2[num2.Length - 1] = MaxStringInString(num1[num1.Length-1], str2, CC);
                        num3[num3.Length - 1] = StringMinusString(num1[num1.Length-1], num2[num2.Length - 1], CC);
                        answer += arr[StringDivisionString(num1[num1.Length-1], str2, CC)];
                    }
                    if (answer.IndexOf(",") != -1)
                    {
                        if (answer.Substring(answer.IndexOf(",") + 1).Length >= 5)
                        {
                            t = false;
                        break;
                        }
                            
                    }
                    
                }
            }

            
            AddUnderlineText(r, " ");
            if (long.Parse(ConvertFromIntPos(str1, CC, 10))< long.Parse(ConvertFromIntPos(str2, CC, 10)))
            {
                AddStandartText(r, num1[0] + "|");
            }
            else
            {
                AddStandartText(r, str1 + "|");
            }
            AddUnderlineText(r, str2 + "\n");
            AddStandartText(r, " "+ GetSpaces(num1[0].Length - num2[0].Length));
            AddUnderlineText(r, num2[0]);    
            AddStandartText(r, GetSpaces(str1.Length - num1[0].Length) + "|" );
            AddStandartRedText(r, answer + "\n");
            int g = num1[0].Length - num2[0].Length;
            for (int j = 0; j < num1.Length - 1; j++)
            {
                g +=  num2[j].Length- num3[j].Length;
                AddStandartText(r, GetSpaces(g+HowManyZeroInBegin(num1[j+1])));
                AddUnderlineText(r, " ");
                AddStandartText(r, num1[j + 1].Substring(HowManyZeroInBegin(num1[j + 1])) +"\n");
                g += num1[j + 1].Length - num2[j + 1].Length;
                AddStandartText(r, GetSpaces(g+1));
                AddUnderlineText(r, num2[j + 1]+"\n"); 
            }
            if (num3[num3.Length - 1] == "")
            {
                num3[num3.Length - 1] = "0";
            }
            AddStandartText(r, GetSpaces(g + num2[num2.Length-1].Length - num3[num3.Length-1].Length + 1));
            AddStandartText(r, num3[num3.Length-1] + "\n");
            
            
        }
        static public int GetNumberSystem(RadioButton r1, RadioButton r2, RadioButton r3, RadioButton r4, RadioButton r5, NumericUpDown n)
        {
            if (r1.Checked)
            {
                return 2;
            }
            else if (r2.Checked)
            {
                return 8;
            }
            else if (r3.Checked)
            {
                return 10;
            }
            else if (r4.Checked)
            {
                return 16;
            }
            else if (r5.Checked)
            {
                return Convert.ToInt32(n.Value);
            }
            else
            {
                return -1;
            }
        }
        public Form1()
        {
            InitializeComponent();
            Size = new Size(Size.Width, 472);
            
            
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void RadioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked)
            {
                numericUpDown1.Visible = true;
            }
            else
            {
                numericUpDown1.Visible = false;
            }
        }


      

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            button2.BackColor = Color.LightSalmon;
            button3.BackColor = SystemColors.Info;
            button4.BackColor = SystemColors.Info;
            button5.BackColor = SystemColors.Info;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            button3.BackColor = Color.LightSalmon;
            button2.BackColor = SystemColors.Info;
            button4.BackColor = SystemColors.Info;
            button5.BackColor = SystemColors.Info;
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            button4.BackColor = Color.LightSalmon;
            button3.BackColor = SystemColors.Info;
            button2.BackColor = SystemColors.Info;
            button5.BackColor = SystemColors.Info;
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            button5.BackColor = Color.LightSalmon;
            button3.BackColor = SystemColors.Info;
            button4.BackColor = SystemColors.Info;
            button2.BackColor = SystemColors.Info;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            RadioButton r1 = radioButton1;
            RadioButton r2 = radioButton2;
            RadioButton r3 = radioButton3;
            RadioButton r4 = radioButton4;
            RadioButton r5 = radioButton5;
            NumericUpDown n = numericUpDown1;
            if (textBox1.Text!="" && textBox2.Text != "")
            {
                Color c = Color.LightSalmon;
                if(button2.BackColor ==c || button3.BackColor == c || button4.BackColor == c || button5.BackColor == c)
                {
                    if (radioButton1.Checked || radioButton2.Checked || radioButton3.Checked || radioButton4.Checked  || radioButton5.Checked)
                    {
                        bool t = true;
                        for(int i=0; i<textBox1.Text.Length; i++)
                        {
                            if (FromLetterToInt(textBox1.Text[i], SubArray(GetNumberSystem(r1, r2, r3, r4, r5, n))) == -1)
                            {
                                MessageBox.Show("Запись содержит недопустимые символы");
                                t = false;
                                break;
                            }
                        }
                        if (t)
                        {
                            richTextBox1.Text = "";
                            label5.Location = new Point((this.Size.Width - label5.Size.Width) / 2, label5.Location.Y);
                            if (button2.BackColor == c)//+
                            {
                                OperationPLUS(richTextBox1, textBox1.Text, textBox2.Text, GetNumberSystem(r1, r2, r3, r4, r5, n));
                                richTextBox1.Size = richTextBox1.GetPreferredSize(MaximumSize);
                                richTextBox1.Size = new Size(richTextBox1.Size.Width - 40, richTextBox1.Size.Height);
                                richTextBox1.Location = new Point((this.Size.Width - richTextBox1.Size.Width) / 2, richTextBox1.Location.Y);
                                this.Size = new Size(this.Size.Width, richTextBox1.Location.Y + richTextBox1.Size.Height + 30);
                            }
                            if (button3.BackColor == c)//-
                            {
                                OperationMINUS(richTextBox1, textBox1.Text, textBox2.Text, GetNumberSystem(r1, r2, r3, r4, r5, n));
                                richTextBox1.Size = richTextBox1.GetPreferredSize(MaximumSize);
                                richTextBox1.Size = new Size(richTextBox1.Size.Width - 40, richTextBox1.Size.Height);
                                richTextBox1.Location = new Point((this.Size.Width - richTextBox1.Size.Width) / 2, richTextBox1.Location.Y);
                                this.Size = new Size(this.Size.Width, richTextBox1.Location.Y + richTextBox1.Size.Height + 30);
                            }
                            if (button4.BackColor == c)//%
                            {
                                OperationDIVISION(richTextBox1, textBox1.Text, textBox2.Text, GetNumberSystem(r1, r2, r3, r4, r5, n));
                                richTextBox1.Size = richTextBox1.GetPreferredSize(MaximumSize);
                                richTextBox1.Size = new Size(richTextBox1.Size.Width - 40, richTextBox1.Size.Height);
                                richTextBox1.Location = new Point((this.Size.Width - richTextBox1.Size.Width) / 2, richTextBox1.Location.Y);
                                this.Size = new Size(this.Size.Width, richTextBox1.Location.Y + richTextBox1.Size.Height + 30);
                            }
                            if (button5.BackColor == c)//*
                            {
                                OperationMULTIPLY(richTextBox1, textBox1.Text, textBox2.Text, GetNumberSystem(r1, r2, r3, r4, r5, n));
                                richTextBox1.Size = richTextBox1.GetPreferredSize(MaximumSize);
                                richTextBox1.Size = new Size(richTextBox1.Size.Width - 40, richTextBox1.Size.Height);
                                richTextBox1.Location = new Point((this.Size.Width - richTextBox1.Size.Width) / 2, richTextBox1.Location.Y);
                                this.Size = new Size(this.Size.Width, richTextBox1.Location.Y + richTextBox1.Size.Height + 30);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Выберите систему счисления");
                    }
                }
                else
                {
                    MessageBox.Show("Выберите операцию");
                }
            }
            else
            {
                MessageBox.Show("Введите числа");
            }
        }
    }
}
