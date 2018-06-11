using System;
using Xunit;
using WordGuessGame;
using static WordGuessGame.Program;
// i mean, i tried.
namespace WordGuessGameTests
{
    public class UnitTests
    {
        [Theory]
        [InlineData(1,1)]
        [InlineData(2,2)]
        [InlineData(3,3)]
      
        public void CanHandleMenuInput(byte testSelection)
        {
            Assert.Equal(testSelection, HandleMenuInput(testSelection));
        }
    }
}