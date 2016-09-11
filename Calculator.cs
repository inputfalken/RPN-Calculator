using System.Collections.Generic;
using System;
using System.Linq;
namespace ConsoleApplication {
  public class Calculator {

    private Queue<int> _queue = new Queue<int>();

    public int Result => _queue.Peek();

    public Calculator AppendNumber(int num) {
      _queue.Enqueue(num);
      return this;
    }

    public Token ReadInput(string input) {
      input = input.Trim();
      int value = 0;
      if (int.TryParse(input, out value)){
        AppendNumber(value);
        return Token.Number;
      }
      if (_queue.Count < 2) {
        return Token.Invalid;
      }
      else {
         if (input == "+") {
          Addition();
          return Token.Operator;
        }
        else if (input == "-") {
          Subtract();
          return Token.Operator;
        }
        else if (input == "*") {
          Times();
          return Token.Operator;
        }
        else if (input == "/") {
          Divide();
          return Token.Operator;
        }
      }
      return Token.Unknown;
    }

    public Calculator Addition() {
      _queue.Enqueue(PerformCalculation((x,y) => x + y));
      return this;
    }

    public Calculator Subtract() {
      _queue.Enqueue(PerformCalculation((x,y) => x - y));
      return this;
    }

    public Calculator Times() {
      _queue.Enqueue(PerformCalculation((x,y) => x * y));
      return this;
    }

    public Calculator Divide() {
      _queue.Enqueue(PerformCalculation((x,y) => x / y));
      return this;
    }

    private int PerformCalculation(Func<int,int,int> func){
      return func(_queue.Dequeue(),_queue.Dequeue());
    }
  }
  public enum Token {
    Number,
    Operator,
    Invalid,
    Unknown
  }
}
