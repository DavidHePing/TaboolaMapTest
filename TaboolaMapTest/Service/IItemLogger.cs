namespace TaboolaMapTest.Service;

public interface IItemLogger
{
    public void LogItem(string item, long timeStamp);

    public bool HasItemUpdatedSince(string item, long timeStamp);
}