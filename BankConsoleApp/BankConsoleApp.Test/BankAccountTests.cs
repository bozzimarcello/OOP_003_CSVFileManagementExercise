namespace BankConsoleApp.Test
{
    public class BankAccountTests
    {
        [Test]
        public void DefaultConstructor_SetsInitialValues()
        {
            // Arrange
            BankAccount account = new BankAccount();

            // Act & Assert
            Assert.IsEmpty(account.GetAccountNumber());
            Assert.That(account.GetBalance(), Is.EqualTo(0.0));
            Assert.IsEmpty(account.GetOwnerName());
            Assert.IsEmpty(account.GetAccountType());
        }

        [Test]
        public void ConstructorWithInitialBalance_SetsValuesCorrectly()
        {
            // Arrange
            double initialBalance = 100.0;
            BankAccount account = new BankAccount("ABC123", initialBalance);

            // Act & Assert
            Assert.That(account.GetAccountNumber(), Is.EqualTo("ABC123"));
            Assert.That(account.GetBalance(), Is.EqualTo(initialBalance));
            Assert.IsEmpty(account.GetOwnerName());
            Assert.IsEmpty(account.GetAccountType());
        }

        [Test]
        public void ConstructorWithFullDetails_SetsAllValuesCorrectly()
        {
            // Arrange
            string accountNumber = "DEF456";
            double initialBalance = 500.0;
            string ownerName = "John Doe";
            string accountType = "Savings";
            BankAccount account = new BankAccount(accountNumber, initialBalance, ownerName, accountType);

            // Act & Assert
            Assert.That(account.GetAccountNumber(), Is.EqualTo(accountNumber));
            Assert.That(account.GetBalance(), Is.EqualTo(initialBalance));
            Assert.That(account.GetOwnerName(), Is.EqualTo(ownerName));
            Assert.That(account.GetAccountType(), Is.EqualTo(accountType));
        }

        [Test]
        public void Deposit_IncreasesBalance_ValidAmount()
        {
            // Arrange
            BankAccount account = new BankAccount();
            double depositAmount = 25.0;

            // Act
            account.Deposit(depositAmount);

            // Assert
            Assert.That(account.GetBalance(), Is.EqualTo(depositAmount));
        }

        [Test]
        public void Deposit_ThrowsException_NegativeAmount()
        {
            // Arrange
            BankAccount account = new BankAccount();
            double invalidDeposit = -10.0;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => account.Deposit(invalidDeposit));
        }

        [Test]
        public void Withdraw_ReducesBalance_ValidAmount()
        {
            // Arrange
            string accountNumber = "DEF456";
            double initialBalance = 500.0;
            BankAccount account = new BankAccount(accountNumber, initialBalance);
            double withdrawalAmount = 50.0;

            // Act
            account.Withdraw(withdrawalAmount);

            // Assert
            Assert.That(account.GetBalance(), Is.EqualTo(initialBalance - withdrawalAmount));
        }

        [Test]
        public void Withdraw_ThrowsException_InsufficientFunds()
        {
            // Arrange
            string accountNumber = "DEF456";
            double initialBalance = 20.0;
            BankAccount account = new BankAccount(accountNumber, initialBalance);
            double invalidWithdrawal = 30.0;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => account.Withdraw(invalidWithdrawal));
        }

    }
}