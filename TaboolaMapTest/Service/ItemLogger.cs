namespace TaboolaMapTest.Service;

public class ItemLogger: IItemLogger
{
    private readonly Dictionary<int, Dictionary<string, long>> _map = new();
    
    public void LogItem(string item, long timeStamp)
    {
        var minute = DateTimeOffset.FromUnixTimeSeconds(timeStamp).Minute;

        if (!_map.ContainsKey(minute))
        {
            _map[minute] = new Dictionary<string, long>();
        }

        if (!_map[minute].ContainsKey(item))
        {
            _map[minute][item] = timeStamp;
            return;
        }

        _map[minute][item] = Math.Max(_map[minute][item], timeStamp);
    }

    public bool HasItemUpdatedSince(string item, long timeStamp)
    {
        var targetItem = _map.Values.FirstOrDefault(x => x.ContainsKey(item));

        if (targetItem == null)
        {
            return false;
        }
        
        return targetItem[item] > timeStamp;
    }
}