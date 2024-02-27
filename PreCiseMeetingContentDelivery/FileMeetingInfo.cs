using System.IO;

namespace PreCiseMeetingContentDelivery
{
    public interface IMeetingInfo
    {
        public string[] GetFullNames();
        public string GetMeetingTimeZone();
    }

    public class FileMeetingInfo : IMeetingInfo
    {
        private const char NAME_DELIMITER = ',';
        private readonly string _filePath;
        private readonly string _timeZone;

        public FileMeetingInfo(string? filePath, string? timeZone)
        {
            _timeZone = timeZone ?? throw new ArgumentNullException(nameof(timeZone));
            _filePath = filePath ?? throw new ArgumentNullException(nameof(filePath));
            if (!File.Exists(filePath))
            {
                throw new ArgumentException("Failed to find file for meeting members");
            }
        }

        public string[] GetFullNames()
        {
            string[] result;
            try
            {
                if (string.IsNullOrWhiteSpace(_filePath))
                {
                    throw new ApplicationException("Invalid meeting members file path");
                }

                string fileText = File.ReadAllText(_filePath);
                if (string.IsNullOrWhiteSpace(fileText))
                {
                    throw new ApplicationException("Meeting members file is empty");
                }

                List<string> textLines = [.. fileText.Split(NAME_DELIMITER)];
                if (textLines == null || textLines.Count <= 0)
                {
                    throw new ApplicationException("Unable to read improperly formatted meeting members from file");
                }

                HashSet<string> parsedNames = new HashSet<string>();
                foreach (string textLine in textLines)
                {
                    if (!string.IsNullOrWhiteSpace(textLine) && textLine.Any(c => char.IsLetterOrDigit(c)))
                    {
                        string parsedFullName = new string(textLine.Where(c => (char.IsLetterOrDigit(c) || c == ' ')).ToArray());
                        if (!string.IsNullOrWhiteSpace(parsedFullName) && !parsedNames.Contains(parsedFullName))
                        {
                            parsedNames.Add(parsedFullName);
                        }
                    }
                }

                result = [.. parsedNames];
                if (result == null || result.Length <= 0)
                {
                    throw new ApplicationException("Failed to read meeting members from file");
                }
            }
            catch (IOException)
            {
                throw new IOException("Failed to read meeting members from file");
            }

            return result;
        }

        public string GetMeetingTimeZone()
        {
            return _timeZone;
        }
    }
}
