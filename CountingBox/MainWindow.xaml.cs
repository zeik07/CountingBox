﻿using System;
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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
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
            
            int charsTotal = Chars(text);
            CharsLimits(charsTotal, minChars, maxChars);
            CharCount.Content = charsTotal;

            int spacesTotal = Spaces(text);
            SpaceCount.Content = spacesTotal;

            int wordsTotal = Words(text);
            WordsLimits(wordsTotal, minWords, maxWords);
            WordCount.Content = wordsTotal;
        }

        private int Chars(string textString)
        {
            return textString.Length;
        }

        private void CharsLimits(int total, int min, int max)
        {
            if (max != 0 && total > max)
            {
                CharCount.Foreground = Brushes.Red;
            }
            else if (min != 0 && total < min)
            {
                CharCount.Foreground = Brushes.Red;
            }
            else
            {
                CharCount.Foreground = Brushes.Black;
            }
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

        private void WordsLimits(int total, int min, int max)
        {
            if (max != 0 && total > max)
            {
                WordCount.Foreground = Brushes.Red;
            }
            else if (min != 0 && total < min)
            {
                WordCount.Foreground = Brushes.Red;
            }
            else
            {
                WordCount.Foreground = Brushes.Black;
            }
        }

        private int CountValue (string count)
        {
            int value = 0;

            if (count == "")
            {
                value = 0;
            }
            else
            {
                try
                {
                    value = Convert.ToInt32(count);
                }
                catch
                {
                    value = 0;
                }
            }

            return value;
        }
    }
}
