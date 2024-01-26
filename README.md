# Learning C# exceptions

- try, catch, finally
  - multiple catch blocks
  - global try, catch blocks
- common in-built exception types
  - Exception (
    avoid catching and throwing the base exception type
    (except in a global try/catch block and
    sometimes when rethrowing an exception for an unknown operation
    (don't reset the stack trace)))
    - ArgumentException
      - ArgumentNullException
      - ArgumentOutOfRangeException
      - e.g., ArgumentOutOfRangeException.ThrowIfNegative()
    - DivideByZeroException
    - FormatException
    - IndexOutOfRangeException
    - InvalidOperationException
    - NotImplementedException
    - StackOverflowException
    - etc.
- rethrowing exceptions
  - resetting the stack trace `throw ex`
    - prefer `throw` to preserve the stack trace
- exception filters
  - `when`
- principle of least surprise when working with exceptions
- exceptions a part of method signature
- performance implications of thrown exceptions
- `goto` don't use this
