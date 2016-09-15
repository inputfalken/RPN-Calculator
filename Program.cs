using System;

namespace ConsoleApplication {
  public class Program  {
    public static void Main(string[] args) {
      Start();
    }

    private static void Start() {
      var calculator = new Calculator();
      Console.WriteLine("Input numbers...");
      string input = string.Empty;
      while(true) {
        input = Console.ReadLine();
        if(input == "calc") break;
        else {
          var token = calculator.ReadInput(input);
          if (token == Status.Number) Console.WriteLine($"Number {input} Added");
          else if (token == Status.OperatorAdded) Console.WriteLine($"Value after Operation: {calculator.Result}");
          else if (token == Status.Clear) Console.WriteLine("Cleared Calculator");
          else if (token == Status.Fail) Console.WriteLine("Fail Input");
        }
      }

      Console.WriteLine(calculator.Result);
    }
  }
}

