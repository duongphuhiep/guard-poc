This is a POC for a (possibly) new `Guard` library.

* As in Jan 2022, my POC supports more customization-rich than any existing Guard library eg: [Ardalis.GuardClauses](https://www.nuget.org/packages/Ardalis.GuardClauses/), [Guard.Net](https://www.nuget.org/packages/Guard.Net/)...
* It make use of the `CallerArgumentExpression` in .NET 6 (C# 10). So you won't be able to use this POC for old .NET project
* `CallerArgumentExpression`s are evaluated in Compiled time so the Guard performance in runtime shouldn't be inferior to existings solutions. (TODO: Benchmark on performance comparision)
 
Here the usage's gist

```C#
var payment = new
{
    amount = -10
};

//Default case: by default my Guard library will throw ArgumentException with a nice message:
//the following code will throws: System.ArgumentException: Invalid 'payment.amount' = '-10' is a negative value
Guard.AgainstNegative(payment.amount);

//Custom exception: case we want to throw a custom exception but still keep the nice message:
//the following code will throws: InvalidAmountException: Invalid 'payment.amount' = '-10' is a negative value
Guard.AgainstNegative(payment.amount, niceMsg => new InvalidAmountException(niceMsg));

//Custom input expression: we don't want to see the expression 'payment.amount' in the nice message
//the following code will throws: System.ArgumentException: Invalid 'Payment Amount' = '-10' is a negative value
Guard.AgainstNegative(payment.amount, "Payment Amount");
//or the following code will throws: InvalidAmountException: Invalid 'Payment Amount' = '-10' is a negative value
Guard.AgainstNegative(payment.amount, niceMsg => new InvalidAmountException(niceMsg), "Payment Amount");

//Custom exeption and custom message
//the following code will throws: InvalidAmountException: the payment amount is invalid
Guard.AgainstNegative(payment.amount, _ => new InvalidAmountException("the payment amount is invalid"));
```

Final note:

I have no intention to make a real Guard library, because these nice small tools have never been useful for me... This POC allow me to try the `CallerArgumentExpression`, and show that it can be used for a better Guard library (or debug / logging).



