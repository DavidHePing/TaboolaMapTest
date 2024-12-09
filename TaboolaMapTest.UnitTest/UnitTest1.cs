using FluentAssertions;
using TaboolaMapTest.Service;

namespace TaboolaMapTest.UnitTest;

public class Tests
{
    private IItemLogger _itemLogger;

    [SetUp]
    public void Setup()
    {
        _itemLogger = new ItemLogger();
    }

    [Test]
    public void HasItemUpdatedSince_return_true_when_item_exist()
    {
        _itemLogger.LogItem("item1", DateTimeOffset.Parse("2024-12-05 00:10:00").ToUnixTimeSeconds());
        _itemLogger.HasItemUpdatedSince("item1", DateTimeOffset.Parse("2024-12-05 00:00:00").ToUnixTimeSeconds())
            .Should().BeTrue();
    }

    [Test]
    public void HasItemUpdatedSince_return_false_when_time_lower_than_exist()
    {
        _itemLogger.LogItem("item2", DateTimeOffset.Parse("2024-12-05 00:00:00").ToUnixTimeSeconds());
        _itemLogger.HasItemUpdatedSince("item2", DateTimeOffset.Parse("2024-12-05 00:10:00").ToUnixTimeSeconds())
            .Should().BeFalse();
    }

    [Test]
    public void HasItemUpdatedSince_return_false_when_key_not_exist()
    {
        _itemLogger.HasItemUpdatedSince("item3", DateTimeOffset.Parse("2024-12-05 00:00:00").ToUnixTimeSeconds()).Should().BeFalse();
    }
}