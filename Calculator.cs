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
    public string Calculation {get; private set;}

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
          var num = Stack.Pop();
          Calculation = $"√{num}";
          Stack.Push(Math.Sqrt(num));
          return Token.Operator;
        }
      }
      if (Stack.Count >= 2){
        if (input == "+") {
          Stack.Push(PerformCalculation((x,y) => {
                return x + y;
                }));
          return Token.Operator;
        }
        if (input == "-") {
          Stack.Push(PerformCalculation((x,y) => {
                Calculation = $"{y} - {x}";
                return y - x;
                }));
          return Token.Operator;
        }
        if (input == "*") {
          Stack.Push(PerformCalculation((x,y) => {
                Calculation = $"{x} * {y}";
                return x * y;
                }));
          return Token.Operator;
        }
        if (input == "/") {
          Stack.Push(PerformCalculation((x,y) => {
                Calculation = $"{y} / {x}";
                return y / x;
                }));
          return Token.Operator;
        }
        if (input == "pow") {
          Stack.Push(PerformCalculation((x,y) => {
                Calculation = $"{x} ^ {y}";
                return Math.Pow(x,y);
                }));
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
