using System.Reflection;

namespace PreCiseMeetingContentDelivery
{
    public static class LastAssemblyBuild
    {
        private static DateTime? _Date = null;

        public static DateTime Date
        {
            get
            {
                if (_Date == null)
                {
                    _Date = GetLinkerTime(Assembly.GetExecutingAssembly());
                }
                return _Date.Value;
            }
        }

        private static DateTime GetLinkerTime(Assembly assembly)
        {
            var filePath = assembly.Location;
            const int c_PeHeaderOffset = 60;
            const int c_LinkerTimestampOffset = 8;

            var buffer = new byte[2048];

            using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                stream.Read(buffer, 0, 2048);

            var offset = BitConverter.ToInt32(buffer, c_PeHeaderOffset);
            var secondsSince1970 = BitConverter.ToInt32(buffer, offset + c_LinkerTimestampOffset);
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            var linkTimeUtc = epoch.AddSeconds(secondsSince1970);

            return linkTimeUtc;
        }
    }
}
