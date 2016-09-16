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
      if (input == "clear") {
        Stack.Clear();
        return Token.Clear;

      }

      if(Stack.Count >= 1){
        if (input == "sqrt") {
          Stack.Push(Math.Sqrt(Stack.Pop()));
          return Token.Operator;
        }
      }
      if (Stack.Count >= 2){
        if (input == "+") {
          return PerformCalculation((x,y) => x + y);
        }
        if (input == "-") {
          return PerformCalculation((x,y) => y - x );
        }
        if (input == "*") {
          return PerformCalculation((x,y) => x * y);
        }
        if (input == "/") {
          return PerformCalculation((x,y) => y / x);
        }
        if (input == "pow") {
          return PerformCalculation((x,y) => Math.Pow(x,y));
        }

      }
      return Token.Invalid;
    }
    private Token PerformCalculation(Func<double,double,double> func){
      Stack.Push(func(Stack.Pop(),Stack.Pop()));
      return Token.Operator;
    }
  }
  public enum Token {
    Number,
    Operator,
    Invalid,
    Clear
  }
}
