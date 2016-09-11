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
          if (token == Token.Number) Console.WriteLine("Number Added");
          else if (token == Token.Operator) Console.WriteLine($"Value {calculator.Result}");
          else if (token == Token.Invalid) Console.WriteLine("Invalid Input");
          else if (token == Token.Unknown) Console.WriteLine($"Unkown input {input}");
        }
      }

      Console.WriteLine(calculator.Result);
    }
  }
}

