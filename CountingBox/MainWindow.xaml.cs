using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CountingBox
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextToCount_TextChanged(object sender, TextChangedEventArgs e)
        {
            string text = TextToCount.Text;
            int minChars = CountValue(MinChars.Text);
            int maxChars = CountValue(MaxChars.Text);
            int minWords = CountValue(MinWords.Text);
            int maxWords = CountValue(MaxWords.Text);

            Tidy(minChars, maxChars, minWords, maxWords);

            int charsTotal = Chars(text);
            string charMod = CharsLimits(charsTotal, minChars, maxChars);
            CharCount.Content = charMod + charsTotal;

            int spacesTotal = Spaces(text);
            SpaceCount.Content = spacesTotal;

            int wordsTotal = Words(text);
            string wordMod = WordsLimits(wordsTotal, minWords, maxWords);
            WordCount.Content = wordMod + wordsTotal;
        }

        private int Chars(string textString)
        {
            return textString.Length;
        }

        private string CharsLimits(int total, int min, int max)
        {
            string modifier = "";
            if (max != 0 && total > max)
            {
                modifier = "+";
                CharCount.Foreground = Brushes.Red;
            }
            else if (min != 0 && total < min)
            {
                modifier = "-";
                CharCount.Foreground = Brushes.Red;
            }
            else
            {
                CharCount.Foreground = Brushes.Black;
            }
            return modifier;
        }

        private int Spaces(string textString)
        {
            int spacesTotal = 0;
            foreach (char test in textString)
            {
                if (test is ' ')
                {
                    spacesTotal += 1;
                }
            }
            return spacesTotal;
        }

        private int Words(string textString)
        {
            int wordsTotal = 0;
            string[] wordsSplit = textString.Split(' ');
            foreach (string singleWord in wordsSplit)
            {
                if (singleWord != "")
                {
                    wordsTotal += 1;
                }
            }
            return wordsTotal;
        }

        private string WordsLimits(int total, int min, int max)
        {
            string modifier = "";
            if (max != 0 && total > max)
            {
                modifier = "+";
                WordCount.Foreground = Brushes.Red;
            }
            else if (min != 0 && total < min)
            {
                modifier = "-";
                WordCount.Foreground = Brushes.Red;
            }
            else
            {
                WordCount.Foreground = Brushes.Black;
            }
            return modifier;
        }

        private int CountValue(string count)
        {
            int value = 0;

            try
            {
                value = Convert.ToInt32(count);
            }
            catch
            {
                value = 0;
            }

            return value;
        }

        private void Tidy(int minChars, int maxChars, int minWords, int maxWords)
        {
            if (minChars == 0)
            {
                MinChars.Text = "0";
            }
            if (maxChars == 0)
            {
                MaxChars.Text = "0";
            }
            if (minWords == 0)
            {
                MinWords.Text = "0";
            }
            if (maxWords == 0)
            {
                MaxWords.Text = "0";
            }
        }
    }
}
