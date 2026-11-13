using ChessPro.Domain;
using Xunit;

namespace ChessPro.Domain.Tests;

public class SquareTests
{
    [Theory]
    [InlineData("a1", 0, 0)]
    [InlineData("h8", 7, 7)]
    [InlineData("e4", 4, 3)]
    public void Parse_ShouldReturnExpectedFileAndRank(string algebraic, int expectedFile, int expectedRank)
    {
        var square = Square.Parse(algebraic);

        Assert.Equal(expectedFile, square.File);
        Assert.Equal(expectedRank, square.Rank);
    }

    [Theory]
    [InlineData("a1")]
    [InlineData("h8")]
    [InlineData("e4")]
    public void ToString_ShouldRoundTrip_ThroughParse(string algebraic)
    {
        var square = Square.Parse(algebraic);

        Assert.Equal(algebraic, square.ToString());
    }

    [Theory]
    [InlineData("")]
    [InlineData("i1")]
    [InlineData("a9")]
    [InlineData("a0")]
    [InlineData("zz")]
    public void TryParse_ShouldReturnFalse_ForInvalidNotation(string algebraic)
    {
        bool result = Square.TryParse(algebraic, out _);

        Assert.False(result);
    }

    [Fact]
    public void Constructor_ShouldThrow_WhenOutOfBounds()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Square(8, 0));
        Assert.Throws<ArgumentOutOfRangeException>(() => new Square(0, -1));
    }

    [Fact]
    public void TwoSquares_WithSameFileAndRank_ShouldBeEqual()
    {
        var a = new Square(4, 3);
        var b = Square.Parse("e4");

        Assert.Equal(a, b);
        Assert.True(a == b);
    }
}
