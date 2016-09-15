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

    public Status ReadInput(string input) {
      input = input.Trim();
      double value = 0;
      if (double.TryParse(input, out value)){
        Stack.Push(value);
        return Status.Number;
      }
      if (input == "clear") {
        Stack.Clear();
        return Status.Clear;

      }

      if(Stack.Count >= 1){
        if (input == "sqrt") {
          Stack.Push(Math.Sqrt(Stack.Pop()));
          return Status.Operator;
        }
      }
      if (Stack.Count >= 2){
        if (input == "+") {
          Stack.Push(PerformCalculation((x,y) => x + y));
          return Status.Operator;
        }
        if (input == "-") {
          Stack.Push(PerformCalculation((x,y) => y - x ));
          return Status.Operator;
        }
        if (input == "*") {
          Stack.Push(PerformCalculation((x,y) => x * y));
          return Status.Operator;
        }
        if (input == "/") {
          Stack.Push(PerformCalculation((x,y) => y / x));
          return Status.Operator;
        }
        if (input == "pow") {
          Stack.Push(PerformCalculation((x,y) => Math.Pow(x,y)));
          return Status.Operator;
        }

      }
      return Status.Fail;
    }
    private double PerformCalculation(Func<double,double,double> func){
      return func(Stack.Pop(),Stack.Pop());
    }
  }
  public enum Status {
    Number,
    Operator,
    Fail,
    Clear
  }
}
