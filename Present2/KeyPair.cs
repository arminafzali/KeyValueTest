namespace Present2
{
    public class KeyPair
    {
        private readonly Dictionary<string, List<ValuePair>> KeyValuePairs = [];

        public string? GetByTimeStamp(string key, int ts)
        {
            if (!KeyValuePairs.TryGetValue(key, out var valuePairs))
                return null;

            int index = GetIndexByTimeStamp([.. valuePairs], ts);

            return index == -1 ? null : valuePairs[index].Value;
        }
        public void AddToDict(string key, int ts, string value)
        {
            var valuePair = new ValuePair(value, ts);

            if (!KeyValuePairs.TryGetValue(key, out var valuePairs))
            {
                KeyValuePairs[key] = [valuePair];
            }
            else
            {
                valuePairs.Add(valuePair);
            }
        }
        private static int GetIndexByTimeStamp(ValuePair[] valuePairs, int ts)
        {

            if (valuePairs.Length == 0 || ts < valuePairs[0].TimeStamp)
                return -1;

            int start = 0;
            int end = valuePairs.Length - 1;

            if (valuePairs[end].TimeStamp <= ts)
                return end;

            while (start < end)
            {
                int pivot = (start + end) / 2;

                if (valuePairs[pivot].TimeStamp == ts)
                    return pivot;

                if (valuePairs[pivot].TimeStamp < ts)
                    start = pivot + 1;

                else
                    end = pivot;
            }

            return start - 1;
        }
    }
}