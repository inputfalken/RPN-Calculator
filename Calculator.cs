using System.Collections.Generic;
using System;
using System.Linq;
namespace ConsoleApplication {
  public class Calculator {

    private Queue<int> _queue = new Queue<int>();

    public int Result => _queue.Peek();

    public Token ReadInput(string input) {
      input = input.Trim();
      int value = 0;
      if (int.TryParse(input, out value)){
        _queue.Enqueue(value);
        return Token.Number;
      }
      if (_queue.Count >= 2){
        if (input == "+") {
          _queue.Enqueue(PerformCalculation((x,y) => x + y));
          return Token.Operator;
        }
        if (input == "-") {
          _queue.Enqueue(PerformCalculation((x,y) => x - y));
          return Token.Operator;
        }
        if (input == "*") {
          _queue.Enqueue(PerformCalculation((x,y) => x * y));
          return Token.Operator;
        }
        if (input == "/") {
          _queue.Enqueue(PerformCalculation((x,y) => x / y));
          return Token.Operator;
        }
      }
      return Token.Invalid;
    }
    private int PerformCalculation(Func<int,int,int> func){
      return func(_queue.Dequeue(),_queue.Dequeue());
    }
  }
  public enum Token {
    Number,
    Operator,
    Invalid
  }
}
