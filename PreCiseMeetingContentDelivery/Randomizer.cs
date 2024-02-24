namespace PreCiseMeetingContentDelivery
{
    public class Randomizer
    {
        public static List<string> RandomizeOrder(string[] names, DateTime updateDateTime)
        {
            if (names == null || names.Length <= 0 || updateDateTime == default)
            {
                return ["failed to identify meeting participants".ToUpper()];
            }

            int inclusiveLower = 0;
            int exclusiveUpper = names.Length;
            Random rand = GetRandomGenerator(updateDateTime);
            string[] order = Enumerable.Repeat(string.Empty, names.Length).ToArray();
            HashSet<string> participants = new HashSet<string>();
            do
            {
                int upNext = rand.Next(inclusiveLower, exclusiveUpper);
                if (names.Length > upNext && !string.IsNullOrEmpty(names[upNext]))
                {
                    // Even when randomly picked names are repeated & tossed here, the next pick will always be random.
                    if (!participants.Contains(names[upNext]))
                    {
                        // Add the participant name once and only once to the end of the current order.
                        order[participants.Count] = names[upNext];
                        participants.Add(names[upNext]);
                    }
                }
            }
            while (participants.Count < names.Length);

            return [.. order];
        }

        private static Random GetRandomGenerator(DateTime date)
        {
            /* 
             * Create a seed that is guarenteed to never repeat and therefore the order for all meetings is always different.
             *  I'm separating the range of allowable seed values per year into their own 1000 range of integer values.
             *  And to make this process human readable I've set the initial offset to the year this was created. For example:
             *  •   in 2024, seed range:    1 -  365    .... so Jan.8,2024 will have a seed = 8
             *  •   in 2025, seed range: 1000 - 1365    ... so Dec.31,2025 will have a seed = 1365
             *  •   in 2026, seed range: 2000 - 2365    .... so Jan.1,2025 will have a seed = 2001
             *  •   in 2026, seed range: 2000 - 2365    .... so Jan.8,2026 will have a seed = 2008
             */
            const int yearOfCreation = 2024;
            const int rangeSeparation = 1000;
            int rangeOffset = (date.Year - yearOfCreation) * rangeSeparation;

            // Prevent the order from refreshing on the site until it is 4am the morning of the meeting.
            const int refreshAfterHour = 4;
            DateTime refreshOrderAfter = new DateTime(date.Year, date.Month, date.Day,
                hour: refreshAfterHour, minute: 0, second: 0, date.Kind);
            int seed = (date >= refreshOrderAfter)
                ? rangeOffset + date.Day
                : rangeOffset + (date.Day - 1);

            Random random = new Random(seed);

            return random;
        }
    }
}
