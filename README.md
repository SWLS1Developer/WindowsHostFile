# WindowsHostFile

```csharp
            string file = Path.Combine(Path.GetPathRoot(Environment.SystemDirectory), "Windows\\System32\\Drivers\\Etc\\hosts");
            hosts = WindowsHostFile.Parse(file); 
```
