using System;

namespace Bank.Entities.Entities
{
    public class BankAccount : IBankAccount
    {
        private string customerName;
        private double balance;
        public string CustomerName
        {
            get { return this.customerName; }
        }

        public void SetNameOfCustomer(string name)
        {
            this.customerName = name;
        }

        public double Balance
        {
            get { return this.balance; }
            set { this.balance = value; }
        }

        public double AddInterest(double interest)
        {
            return this.balance = balance + (balance * interest);
        }

        public BankAccount()
        {

        }
        public BankAccount(string customerName, double balance)
        {
            this.customerName = customerName;
            this.balance = balance;
        }

        // Credito(double amount)
        // Se amount < 0 lançar exception
        // balance += amount

        public double AddCredit(double amount)
        {
            if (amount <= 0)
            {
                throw new Exception("O valor creditado deve ser maior que zero");
            }
            else
            {
                return this.balance += amount;
            }

        }


        // Debito(double amount)
        // se amount > balance lançar exception
        // Se amount < 0 lançar exception
        // balance -= amount * 0.025


        public double Debit(double amount)
        {
            if (amount > Balance)
            {
                throw new Exception("O valor debitado não pode ser maior que o saldo");
            }  else if (amount <= 0)
            {
                throw new Exception("O valor debitado deve ser maior que zero");
            } else
            {
                return this.balance -= amount;
            }
        }
    }
}

