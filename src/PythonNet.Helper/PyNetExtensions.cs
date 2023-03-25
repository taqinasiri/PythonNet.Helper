using System.Text;

namespace PythonNet.Helper;

public static class PyNetExtensions
{
    public static string ReadFile(this string path) => File.ReadAllText(path, Encoding.UTF8);
}
