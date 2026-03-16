public class SortStatistics
{
    public long Comparisons { get; set; }
    public long Copies { get; set; } 
    public long RecursiveCalls { get; set; }
    public long ExecutionTimeMs { get; set; }

    public void Reset()
    {
        Comparisons = 0;
        Copies = 0;
        RecursiveCalls = 0;
        ExecutionTimeMs = 0;
    }
}