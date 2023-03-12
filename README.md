# EasyTests
Simplify code testing

```C#
Tester<int[], int> tester0 = new Tester<int[], int>();

tester0.Tests.Add(new int[] { 1, 2, 3, 4, 0, -4, -3, -2, -1, -387, 214 });
tester0.Tests.Add(new int[] { 0x44, 0x45, 0x56, 0x00 });
tester0.Tests.Add(new int[] { 69 });

tester0.Validator = (int[] input, int output, double millis) =>
{
    return "Took " + millis + " ms for sum(" + ArrayToString(input) + ") => " + output;
};

tester0.TestFunc = (int[] input) =>
{
    return sum(input);
};

tester0.RunTests();
```
