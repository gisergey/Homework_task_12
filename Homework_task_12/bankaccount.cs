using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Homework_task_12
{
    public enum accounts
    {
        corrent,
        saving
    }
    class bankaccount
    { 

    private decimal balance;
    private accounts account_type;
    private Guid id { get; }
    private Queue<BankTransaction> Transactions = new Queue<BankTransaction>();

    public bankaccount(accounts type)
    {
        balance = 0;
        id = Guid.NewGuid();
        account_type = type;
    }
    public bankaccount(decimal money = 0)
    {
        id = Guid.NewGuid();
        balance = money;
        account_type = (accounts)0;
    }
    public bankaccount(decimal money, accounts type)
    {
        id = Guid.NewGuid();
        balance = money;
        account_type = type;
    }
        public override string ToString()
        {
            return "айди счета " + id.ToString() + " тип счета " + account_type.ToString() + " баланс " + balance.ToString();
        }
        public static bool operator ==(bankaccount a, bankaccount b)
        {
            if (a.id == b.id)
            {
                return true;
            }
            return false;
        }
        public static bool operator !=(bankaccount a, bankaccount b)
        {
            if (a.id == b.id)
            {
                return false;
            }
            return true;
        }
        public override bool Equals(object a)
        {
            bankaccount b = a as bankaccount;
            if (b!=null&&id == b.id)
            {
                return true;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return id.GetHashCode();
        }
        public void Sendmoney(bankaccount otherbill, decimal how_much_to_send)
    {
        if (balance > how_much_to_send)
        {
            otherbill.topaccount(how_much_to_send);
            this.withdrawaccount(how_much_to_send);
        }
    }

    public void topaccount(decimal money)
    {
        BankTransaction now = new BankTransaction(money);
        Transactions.Enqueue(now);
        balance += money;
    }
    public void withdrawaccount(decimal money)
    {
        if (money < balance)
        {
            BankTransaction now = new BankTransaction((-1) * money);
            Transactions.Enqueue(now);
            balance -= money;
        }
    }
    public void infoaccount()
    {
        Console.WriteLine($"Type {(accounts)account_type}\nID - {id}\nmoney = {balance}$");
    }
    public void Despose()
    {
        using (StreamWriter text = new StreamWriter("Transaction.txt", true))
        {
            foreach (BankTransaction tran in Transactions)
            {
                text.WriteLine($"{tran.Money} {tran.Time}");
                GC.SuppressFinalize(Transactions);
            }
        }

    }
}
}
