using ChessPro.Domain;
using Xunit;

namespace ChessPro.Domain.Tests;

public class MoveTests
{
    [Theory]
    [InlineData(MoveFlag.Capture, true)]
    [InlineData(MoveFlag.EnPassant, true)]
    [InlineData(MoveFlag.PromotionCapture, true)]
    [InlineData(MoveFlag.Quiet, false)]
    [InlineData(MoveFlag.DoublePawnPush, false)]
    [InlineData(MoveFlag.CastleKingSide, false)]
    public void IsCapture_ShouldReflectFlag(MoveFlag flag, bool expected)
    {
        var move = new Move(Square.Parse("e4"), Square.Parse("e5"), flag);

        Assert.Equal(expected, move.IsCapture);
    }

    [Fact]
    public void IsPromotion_ShouldBeTrue_OnlyForPromotionFlags()
    {
        var promotion = new Move(Square.Parse("e7"), Square.Parse("e8"), MoveFlag.Promotion, PieceType.Queen);
        var quiet = new Move(Square.Parse("e2"), Square.Parse("e4"));

        Assert.True(promotion.IsPromotion);
        Assert.False(quiet.IsPromotion);
    }

    [Fact]
    public void TwoMoves_WithSameValues_ShouldBeEqual()
    {
        var a = new Move(Square.Parse("e2"), Square.Parse("e4"), MoveFlag.DoublePawnPush);
        var b = new Move(Square.Parse("e2"), Square.Parse("e4"), MoveFlag.DoublePawnPush);

        Assert.Equal(a, b);
    }
}
