using System.Collections.Generic;
using System;
using System.Linq;
namespace ConsoleApplication {
  public class Calculator {

    private Stack<int> Stack {get;}

    public Calculator(){
      Stack = new Stack<int>();
    }

    public int Result => Stack.Peek();

    public Token ReadInput(string input) {
      input = input.Trim();
      int value = 0;
      if (int.TryParse(input, out value)){
        Stack.Push(value);
        return Token.Number;
      }
      if (input == "clear") {
        Stack.Clear();
        return Token.Clear;

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
      }
      return Token.Invalid;
    }
    private int PerformCalculation(Func<int,int,int> func){
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
