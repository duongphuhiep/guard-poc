
try
{
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
    //the following code will throws: System.ArgumentException: Invalid 'payment amount' = '-10' is a negative value
    Guard.AgainstNegative(payment.amount, "payment amount");
    //or the following code will throws: InvalidAmountException: Invalid 'payment amount' = '-10' is a negative value
    Guard.AgainstNegative(payment.amount, niceMsg => new InvalidAmountException(niceMsg), "payment amount");

    //Custom exeption and custom message
    //the following code will throws: InvalidAmountException: the payment amount is invalid
    Guard.AgainstNegative(payment.amount, _ => new InvalidAmountException("the payment amount is invalid"));
}
catch (Exception ex)
{
    Console.Error.WriteLine(ex);
}

