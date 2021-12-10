using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_task_12
{
    class BankTransaction
    {
        private decimal money;

        private DateTime time;

        public BankTransaction(decimal money)
        {
            this.money = money;
            time = DateTime.Now;
        }

        public DateTime Time
        {
            get { return time; }
        }
        public decimal Money
        {
            get { return money; }
        }

    }
}
