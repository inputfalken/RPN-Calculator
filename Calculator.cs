using System.Collections.Generic;
using System.Linq;
namespace ConsoleApplication {
  public class Calculator {
    Queue<int> _queue = new Queue<int>();

    public Calculator AppendNumber(int num) {
      _queue.Enqueue(num);
      return this;
    }
    public int Addition() => _queue.Sum();

    public int Subtract() {
      var num = _queue.Dequeue();
      while(_queue.Any()) {
        num -= _queue.Dequeue();
      }
      return num;
    }
  }
}
