using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TestAssignmentDesktop
{
    public class CryptoCurrency
    {
        public string Name { get; set; }
        public string Symbol { get; set; }
        public double CurrentPrice { get; set; }
    }
}
