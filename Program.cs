using System;

namespace ConsoleApplication {
  public class Program  {
    public static void Main(string[] args) {
      Start();
    }

    private static void Start() {
      var calculator = new Calculator();
      Console.WriteLine("Type your Expression");
      string input = string.Empty;
      while(true) {
        input = Console.ReadLine();
        if(input == "calc") break;
        else {
          var token = calculator.ReadInput(input);
          if (token == Token.Number) Console.WriteLine($"Number {input} Added");
          else if (token == Token.Operator) Console.WriteLine($"Value after Operation: {calculator.Result}");
          else if (token == Token.Clear) Console.WriteLine("Cleared Calculator");
          else if (token == Token.Invalid) Console.WriteLine("Invalid Input");
        }
      }

      Console.WriteLine(calculator.Result);
    }
  }
}

