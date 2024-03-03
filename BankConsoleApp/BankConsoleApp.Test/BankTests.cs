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

    }

}

