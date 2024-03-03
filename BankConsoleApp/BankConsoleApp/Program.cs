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

// Test dei metodi di gestione dei file CSV
// Aggiungi altri conti correnti
bank.AddAccount(new BankAccount("123", 1000, "Pino Deipalazzi", "Savings"));
bank.AddAccount(new BankAccount("456", 2000, "Dina Lazingara", "Investiments"));

// Crea un file CSV temporaneo
string tempFile = Path.GetTempFileName();

bank.WriteAccountsToCsv(tempFile);

// Leggi il file e verifica il contenuto
string[] lines = File.ReadAllLines(tempFile);

// Pulisci
File.Delete(tempFile);