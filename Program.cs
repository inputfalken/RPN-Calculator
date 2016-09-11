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
          Calculate(input, calculator);
        }
      }

      Console.WriteLine(calculator.Result);
    }
    private static void Calculate(string input, Calculator calculator) {
      int value = 0;
      if (int.TryParse(input, out value)){
        calculator.AppendNumber(value);
      }
      else if (input == "+") {
        calculator.Addition();
      }
      else if (input == "-") {
        calculator.Subtract();
      }
      else if (input == "*") {
        calculator.Times();
      }
      else if (input == "/") {
        calculator.Divide();
      }
      else {
        Console.WriteLine($"ERROR ON {input}");
      }
    }
  }
}

