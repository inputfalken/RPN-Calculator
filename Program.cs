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
          else if (token == Token.Operator) Console.WriteLine($"Performed operation: {calculator.Calculation}, new value: {calculator.Result} ");
          else if (token == Token.Clear) Console.WriteLine("Cleared Calculator");
          //Feature make add a check if the user provided a valid input but at a invalid moment
          else if (token == Token.Invalid) Console.WriteLine($"{input} is invalid");
        }
      }

      Console.WriteLine(calculator.Result);
    }
  }
}

