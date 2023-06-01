using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace TestAssignmentDesktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CryptoCurrency cryptoCurrency = new CryptoCurrency();
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            CryptoCurrency bitcoin = await GetBitcoinInfo();
            if (bitcoin != null)
            {
                TextBox1.Text = $"Name: {bitcoin.Name}\nSymbol: {bitcoin.Symbol}\nCurrent Price: {bitcoin.CurrentPrice}";
            }
            else
            {
                TextBox1.Text = "Failed to fetch Bitcoin information.";
            }
            
            CryptoCurrency ethereum = await GetCryptoCurrencyInfo("ethereum");
            if (ethereum != null)
            {
                TextBox2.Text = $"Name: {ethereum.Name}\nSymbol: {ethereum.Symbol}\nCurrent Price: {ethereum.CurrentPrice}";
            }

            CryptoCurrency dogecoin = await GetCryptoCurrencyInfo("dogecoin");
            if (dogecoin != null)
            {
                TextBox3.Text = $"Name: {dogecoin.Name}\nSymbol: {dogecoin.Symbol}\nCurrent Price: {dogecoin.CurrentPrice}";
            }

        }
        public async Task<CryptoCurrency> GetBitcoinInfo()
        {
            string url = "https://api.coingecko.com/api/v3/coins/bitcoin";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    CryptoCurrency bitcoin = JsonConvert.DeserializeObject<CryptoCurrency>(json);
                    return bitcoin;
                }
                else
                {
                    return null;
                }
            }
        }
        public async Task<CryptoCurrency> GetCryptoCurrencyInfo(string coinId)
        {
            string url = $"https://api.coingecko.com/api/v3/coins/{coinId}";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    CryptoCurrency cryptoCurrency = JsonConvert.DeserializeObject<CryptoCurrency>(json);
                    return cryptoCurrency;
                }
                else
                {
                    // Обробте помилку, якщо не вдалося отримати дані
                    return null;
                }
            }
        }
    }
}
