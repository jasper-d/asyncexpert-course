using System;
using System.Collections.Generic;
using Xunit;

namespace Dotnetos.AsyncExpert.Homework.Module01.Benchmark.Tests
{
    public class BenchmarkTests
    {
        public static IEnumerable<object[]> GetTestData()
        {
            yield return new object[] { 0, 0 };
            yield return new object[] { 1, 1 };
            yield return new object[] { 2, 1 };
            yield return new object[] { 3, 2 };
            yield return new object[] { 4, 3 };
            yield return new object[] { 5, 5 };
            yield return new object[] { 6, 8 };
        }

        [Theory]
        [MemberData(nameof(GetTestData))]
        public void FibonacciTailRecursive(ulong n, ulong expected)
        {            
            // Arrange
            var fib = new FibonacciCalc();

            // Act
            var result = fib.TailRecursive(n);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(GetTestData))]
        public void Recursive(ulong n, ulong expected)
        {
            // Arrange
            var fib = new FibonacciCalc();

            // Act
            var result = fib.Recursive(n);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(GetTestData))]
        public void FibonacciImperative(ulong n, ulong expected)
        {
            // Arrange
            var fib = new FibonacciCalc();

            // Act
            var result = fib.Iterative(n);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(GetTestData))]
        public void FibonacciTailRecursiveMemoized(ulong n, ulong expected)
        {
            // Arrange
            var fib = new FibonacciCalc();

            // Act
            var result = fib.TailRecursiveMemoized(n);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
