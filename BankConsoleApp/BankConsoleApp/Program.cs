using BankConsoleApp;

BankAccount bankAccount = new BankAccount();

bankAccount.Deposit(100);

double balance = bankAccount.GetBalance();

Console.WriteLine($"New balance: {balance}");

BankAccount anotherAccount = new BankAccount("ABC123", 200);

anotherAccount.Deposit(100);

Console.WriteLine($"Another balance: {anotherAccount.GetBalance()}");

Bank bank = new Bank();

bank.AddAccount(bankAccount);

bank.AddAccount(anotherAccount);

double totalAccounts = bank.GetTotalBalance();

Console.WriteLine($"Total balance: {totalAccounts}");