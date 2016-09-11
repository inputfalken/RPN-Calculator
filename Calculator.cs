using System.Collections.Generic;
using System.Linq;
namespace ConsoleApplication {
  public class Calculator {
    Queue<int> _queue = new Queue<int>();
    public int result => _queue.Dequeue();

    public Calculator AppendNumber(int num) {
      _queue.Enqueue(num);
      return this;
    }
    public Calculator Addition() {
        _queue.Enqueue(_queue.Dequeue() + _queue.Dequeue());
        return this;
    }

    public int Subtract() {
      var num = _queue.Dequeue();
      while(_queue.Any()) {
        num -= _queue.Dequeue();
      }
      return num;
    }
    public int Times() {
      var num = _queue.Dequeue();
      while(_queue.Any())
        num *= _queue.Dequeue();
      return num;
    }
  }
}
