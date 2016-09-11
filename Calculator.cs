using System.Collections.Generic;
using System.Linq;
namespace ConsoleApplication {
  public class Calculator {
    Queue<int> _queue = new Queue<int>();
    public int result => _queue.Peek();

    public Calculator AppendNumber(int num) {
      _queue.Enqueue(num);
      return this;
    }
    public Calculator Addition() {
        _queue.Enqueue(_queue.Dequeue() + _queue.Dequeue());
        return this;
    }

    public Calculator Subtract() {
      _queue.Enqueue(_queue.Dequeue() - _queue.Dequeue());
      return this;
    }
  }
}
