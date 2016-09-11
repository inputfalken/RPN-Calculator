using System.Collections.Generic;
using System.Linq;
namespace ConsoleApplication {
  public class Calculator {
    Stack<int> _stack = new Stack<int>();

    public Calculator AppendNumber(int num) {
      _stack.Push(num);
      return this;
    }
    public int Addition() => _stack.Sum();
  }
}
