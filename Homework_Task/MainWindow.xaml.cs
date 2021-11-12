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

namespace Homework_Task
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SearchSymbolAsync(tb.Text.ToString());
            SearchWordAsync(tb.Text.ToString());
            SearchSentenceAsync(tb.Text.ToString());
            //textBlock1.Text = SearchSymbol(tb.Text).ToString();
        }

        static int SearchSymbol (string s)
        {
            int result = 0;
            for (int i = 0; i < s.Length - 1; i++)
            {
                result++;
            }
            return result;
        }

        async void SearchSymbolAsync(string s)
        {
            int res = await Task.Run(() => SearchSymbol(s));
            textBlock1.Text = res.ToString();
        }

        static int SearchWord(string s)
        {
            char[] separators = {/* ',', */' '/*, ';', '.', '\\'*/ }; //создаём массив символов, служащих разделителями слова
            string[] words = s.Split(separators, StringSplitOptions.RemoveEmptyEntries); // із отриманих символів отримуємо масив слів
            int result = 0;
            foreach (string item in words)
            {
                result++;
            }
            return result;
        }

        async void SearchWordAsync(string s)
        {
            int res = await Task.Run(() => SearchWord(s));
            textBlock2.Text = res.ToString();
        }

        static int SearchSentence(string s)
        {
            char[] separators = { /*',', ' ', ';', */'.'/*, '\\'*/ }; //создаём массив речень, служащих разделителями слова
            string[] sentence = s.Split(separators, StringSplitOptions.RemoveEmptyEntries); // із отриманих символів отримуємо масив речень
            int result = 0;
            foreach (string item in sentence)
            {
                result++;
            }
            return result;
        }

        async void SearchSentenceAsync(string s)
        {
            int res = await Task.Run(() => SearchSentence(s));
            textBlock3.Text = res.ToString();
        }
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            tb.Clear();
            textBlock1.Text = null;
            textBlock2.Text = null;
            textBlock3.Text = null;
        }
    }
}
