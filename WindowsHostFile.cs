class WindowsHostFile
    {
        public List<HostEntry> Entries { get; set; }
        public string Path;

        public WindowsHostFile(string path)
        {
            this.Path = path;         
        }

        public void WriteHostFile()
        {
            var na = Entries.Select(x => x.ToString()).ToList();
            File.WriteAllText(Path, string.Join("\n\r", na));
        }

        public static WindowsHostFile Parse(string path)
        {
            if (!File.Exists(path))
                return null;

            using (StreamReader reader = new StreamReader(path))
            {
                var list = new List<HostEntry>();
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (!string.IsNullOrWhiteSpace(line) && !line.StartsWith("#"))
                    {
                        string[] parts = line.Split(new char[] { ' ' }, 2);
                        string address = parts[0];
                        string host = parts.Length == 2 ? parts[1] : string.Empty;
                        list.Add(new HostEntry { Address = address, Host = host });
                    }
                }

                return new WindowsHostFile(path) { Entries = list };
            }
        }

        public class HostEntry
        {
            public string Address { get; set; }
            public string Host { get; set; }

            public override string ToString()
            {
                return $"{this.Address} {this.Host}";
            }
        }
