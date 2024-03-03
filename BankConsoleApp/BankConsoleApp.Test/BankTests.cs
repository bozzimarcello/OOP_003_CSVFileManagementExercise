namespace BankConsoleApp.Test
{

    [TestFixture]
    public class BankTests
    {
        private Bank _bank;
        private BankAccount _account1;
        private BankAccount _account2;

        [SetUp]
        public void Setup()
        {
            _bank = new Bank();
            _account1 = new BankAccount();
            _account2 = new BankAccount();
        }

        [Test]
        public void Constructor_CreatesEmptyBank()
        {
            Assert.IsEmpty(_bank.GetAccounts());
        }

        [Test]
        public void AddAccount_AddsAccountToBank()
        {
            _bank.AddAccount(_account1);
            Assert.That(_bank.GetAccounts(), Does.Contain(_account1));
        }

        [Test]
        public void RemoveAccount_RemovesAccountFromBank()
        {
            _bank.AddAccount(_account1);
            _bank.RemoveAccount(_account1);
            Assert.That(_bank.GetAccounts().Contains(_account1), Is.False);
        }

        [Test]
        public void GetTotalBalance_ReturnsCorrectTotalBalance()
        {
            _account1.Deposit(100);
            _account2.Deposit(200);
            _bank.AddAccount(_account1);
            _bank.AddAccount(_account2);
            Assert.That(_bank.GetTotalBalance(), Is.EqualTo(300));
        }

        [Test]
        public void AddAccount_ThrowsExceptionWhenNullIsPassed()
        {
            Assert.Throws<ArgumentNullException>(() => _bank.AddAccount(null));
        }

        [Test]
        public void RemoveAccount_ThrowsExceptionWhenAccountDoesNotExist()
        {
            var nonExistentAccount = new BankAccount();
            Assert.Throws<InvalidOperationException>(() => _bank.RemoveAccount(nonExistentAccount));
        }

        [Test]
        public void ReadAccountsFromCsv_ReadsCorrectly()
        {
            // Crea un file CSV temporaneo
            string tempFile = Path.GetTempFileName();
            File.WriteAllText(tempFile, "123,1000,Pino Deipalazzi,Savings\n456,2000,Dina Lazingara,Investiments");

            _bank.ReadAccountsFromCsv(tempFile);

            // Pulisci
            File.Delete(tempFile);

            Assert.That(_bank.GetAccounts().Count, Is.EqualTo(2));
        }

        [Test]
        public void WriteAccountsToCsv_WritesCorrectly()
        {
            _bank.AddAccount(new BankAccount("123", 1000, "Pino Deipalazzi", "Savings"));
            _bank.AddAccount(new BankAccount("456", 2000, "Olga Lazingara", "Investiments"));

            // Crea un file CSV temporaneo
            string tempFile = Path.GetTempFileName();

            _bank.WriteAccountsToCsv(tempFile);

            // Leggi il file e verifica il contenuto
            string[] lines = File.ReadAllLines(tempFile);

            // Pulisci
            File.Delete(tempFile);

            Assert.That(lines.Length, Is.EqualTo(2));
            Assert.That(lines[0], Is.EqualTo("123,1000,Pino Deipalazzi,Savings"));
            Assert.That(lines[1], Is.EqualTo("456,2000,Olga Lazingara,Investiments"));
        }

        [Test]
        public void ReadAccountsFromCsv_ThrowsException_WhenFileDoesNotExist()
        {
            Assert.Throws<FileNotFoundException>(() => _bank.ReadAccountsFromCsv("non_existent_file.csv"));
        }

        [Test]
        public void ReadAccountsFromCsv_ThrowsException_WhenFileHasInvalidFormat()
        {
            // Crea un file CSV temporaneo con formato non valido
            string tempFile = Path.GetTempFileName();
            File.WriteAllText(tempFile, "invalid_format");

            Assert.Throws<InvalidOperationException>(() => _bank.ReadAccountsFromCsv(tempFile));

            // Pulisci
            File.Delete(tempFile);
        }

        [Test]
        public void WriteAccountsToCsv_ThrowsException_WhenFilePathIsInvalid()
        {
            Assert.Throws<ArgumentException>(() => _bank.WriteAccountsToCsv(string.Empty));
        }

    }

}

