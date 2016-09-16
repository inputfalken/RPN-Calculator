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

    public Status ReadInput(string input) {
      input = input.Trim();
      double value = 0;
      if (double.TryParse(input, out value)){
        Stack.Push(value);
        return Status.NumberAdded;
      }
      if (input == "clear") {
        Stack.Clear();
        return Status.Clear;
      }

      if(Stack.Count >= 1){
        if (input == "sqrt") {
          var num = Stack.Pop();
          Calculation = $"√{num}";
          Stack.Push(Math.Sqrt(num));
          return Status.OperatorAdded;
        }
      }
      if (Stack.Count >= 2){
        if (input == "+") {
          return PerformCalculation((x,y) => {
              Calculation = $"{x} + {y}";
              return x + y;
              });
        }
        if (input == "-") {
          return PerformCalculation((x,y) => {
              Calculation = $"{y} - {x}";
              return y - x;
              });
        }
        if (input == "*") {
          return PerformCalculation((x,y) => {

              Calculation = $"{x} * {y}";
              return x * y;
              });
        }
        if (input == "/") {
          return PerformCalculation((x,y) =>{
              Calculation = $"{y} / {x}";
              return y / x;
              });
        }
        if (input == "pow") {
          return PerformCalculation((x,y) => {
              Calculation = $"{x} ^ {y}";
              return Math.Pow(x,y);
              });
        }
      }
      return Status.Fail;
    }
    private Status PerformCalculation(Func<double,double,double> func){
      Stack.Push(func(Stack.Pop(),Stack.Pop()));
      return Status.OperatorAdded;
    }
  }
  public enum Status {
    NumberAdded,
    OperatorAdded,
    Fail,
    Clear
  }
}
