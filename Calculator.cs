using System.Collections.Generic;
using System;
using System.Linq;
namespace ConsoleApplication {
  public class Calculator {

    private Stack<double> Stack {get;}

    public Calculator(){
      Stack = new Stack<double>();
    }

    public double Result => Stack.Peek();

    public Token ReadInput(string input) {
      input = input.Trim();
      double value = 0;
      if (double.TryParse(input, out value)){
        Stack.Push(value);
        return Token.Number;
      }
      if (Stack.Count >= 2){
        if (input == "+") {
          Stack.Push(PerformCalculation((x,y) => x + y));
          return Token.Operator;
        }
        if (input == "-") {
          Stack.Push(PerformCalculation((x,y) => y - x ));
          return Token.Operator;
        }
        if (input == "*") {
          Stack.Push(PerformCalculation((x,y) => x * y));
          return Token.Operator;
        }
        if (input == "/") {
          Stack.Push(PerformCalculation((x,y) => y / x));
          return Token.Operator;
        }
        if (input == "pow") {
          Stack.Push(PerformCalculation((x,y) => Math.Pow(x,y)));
          return Token.Operator;
        }

        if (input == "sqrt") {
          Stack.Push(PerformCalculation((x,y) => Math.Sqrt(x,y)));
          return Token.Operator;
        }
      }
      return Token.Invalid;
    }
    private double PerformCalculation(Func<double,double,double> func){
      return func(Stack.Pop(),Stack.Pop());
    }
  }
  public enum Token {
    Number,
    Operator,
    Invalid,
    Clear
  }
}
