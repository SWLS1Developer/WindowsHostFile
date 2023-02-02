# Windows Host File

This class is designed to parse and manipulate the Windows host file. The host file is a simple text file used by Windows to map hostnames to IP addresses. 

## Available Functions

### Parse(string Path)

This function parses the host file located at the specified path and returns a WindowsHostFile object.

### WriteFile()

This function writes the contents of WindowsHostFile object to disk. 

## Example Usage


```csharp
string file = Path.Combine(Path.GetPathRoot(Environment.SystemDirectory), "Windows\\System32\\Drivers\\Etc\\hosts");
hosts = WindowsHostFile.Parse(file); 
```

## Notes

- It is important to ensure that the host file is only written to by trusted sources, as it can be used to redirect traffic and compromise security. 
- The host file should be backed up before making any changes. 
- It is recommended to run the program with elevated privileges (i.e. as administrator) in order to have access to write to the host file.
