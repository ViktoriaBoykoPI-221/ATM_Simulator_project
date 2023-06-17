using System;
public sealed class ATM { //запрещает наследовать от этого класса
  private static ATM instance = null;
  private decimal balance;
  public ATM() {
    balance = 0;
  }
  public static ATM Instance { 
    get {
      if (instance == null) {//возвращает единственный экземпляр класса ATM
        instance = new ATM();
      }
      return instance;
    }
  }
  public decimal GetBalance() {
    return balance;
  }
  public void Deposit(decimal amount) {
    balance += amount;
    Console.WriteLine("Операция выполнена.");
  }
  public void Withdraw(decimal amount) {
    if (balance >= amount) {
      balance -= amount;
      Console.WriteLine("Операция завершена, заберите деньги.");
    }
    else {
      Console.WriteLine("На счете недостаточно средств.");
    }
  }
  public void Transfer(decimal amount, ATM targetATM) {
    if (balance >= amount) {
      balance -= amount;
      targetATM.Deposit(amount);
      Console.WriteLine("Перевод успешно выполнен.");
    }
    else {
      Console.WriteLine("На счете недостаточно средств.");
    }
  }
}

public class Program {
  public static void Main(string [] args) {
    ATM atm = ATM.Instance;

    while (true) {
      Console.WriteLine("Меню:");
      Console.WriteLine("1. Внести");
      Console.WriteLine("2. Снять");
      Console.WriteLine("3. Перевести");
      Console.WriteLine("4. Проверить баланс");
      Console.WriteLine("5. Выйти");

      Console.Write("Введите номер операции (1-5): ");
      string choice = Console.ReadLine();

      Console.WriteLine();

      switch (choice) {
        case "1":
        Console.Write("Ввнесите сумму: ");
        decimal depositAmount = Convert.ToDecimal(Console.ReadLine());
        atm.Deposit(depositAmount);
        Console.WriteLine();
        break;

        case "2":
        Console.Write("Выберите сумму: ");
        decimal withdrawAmount = Convert.ToDecimal(Console.ReadLine());
        atm.Withdraw(withdrawAmount);
        Console.WriteLine();
        break;

        case "3":
        Console.Write("Введите сумму для перевода: ");
        decimal transferAmount = Convert.ToDecimal(Console.ReadLine());
        Console.Write("Введите номер получателя: ");
        int targetATMNumber = Convert.ToInt32(Console.ReadLine());
      
        ATM targetATM = new ATM();// Создаем экземпляр банкомата-получателя
        atm.Transfer(transferAmount, targetATM); // Производим перевод с текущего банкомата на целевой
        Console.WriteLine();
        break;

        case "4":
        Console.WriteLine("Баланс: " + atm.GetBalance());
        Console.WriteLine();
        break;

        case "5":
        Console.WriteLine("До свидания!");
        return;

        default:
        Console.WriteLine("Неверная операция. Пожалуйста, повторите попытку (1-5).");
        Console.WriteLine();
        break;
      }
    }
  }
}
