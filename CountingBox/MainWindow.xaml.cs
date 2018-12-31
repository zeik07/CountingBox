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
            int textCount = 0;
            string text = TextToCount.Text;
            textCount = text.Length;
            CharCount.Content = textCount;
            int spacesTotal = Spaces(text);
            SpaceCount.Content = spacesTotal;
            int wordsTotal = Words(text);
            WordCount.Content = wordsTotal;
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
    }
}
