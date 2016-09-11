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
}
