using FluentAssertions;
using TaboolaMapTest.Service;

namespace TaboolaMapTest.UnitTest;

public class Tests
{
    private IItemLogger _itemLogger;
    
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void HasItemUpdatedSince_return_true_when_item_exist()
    {
        _itemLogger.HasItemUpdatedSince("item1", 1000001).Should().BeTrue();
        _itemLogger.HasItemUpdatedSince("item2", 1000010).Should().BeTrue();
    }
    
    [Test]
    public void HasItemUpdatedSince_return_false_when_time_lower_than_exist()
    {
        _itemLogger.HasItemUpdatedSince("item2", 1000010).Should().BeFalse();
    }
    
    [Test]
    public void HasItemUpdatedSince_return_false_when_key_not_exist()
    {
        _itemLogger.HasItemUpdatedSince("item3", 1000010).Should().BeFalse();
    }
}