using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hometask_13
{
    class Program
    {

        static void Main(string[] args)
        {
            bankaccount Vova = new bankaccount(0,accounts.corrent);
            bankaccount Volodia = new bankaccount(0, accounts.corrent);
            Vova.topaccount(1000);
            Vova.Sendmoney(Volodia, 100);
            Console.WriteLine(Vova.ToString());
            Console.WriteLine(Volodia.ToString());
        }
    }
}
