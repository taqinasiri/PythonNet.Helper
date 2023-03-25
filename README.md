# PythonNet.Helper
Bring Python to C# !!!

[![Nuget](https://img.shields.io/nuget/v/PythonNet.Helper?logo=nuget&style=for-the-badge&color=00467C&labelColor=1c1917)](https://www.nuget.org/packages/PythonNet.Helper)

>This library is a help library for [PythonNet](https://github.com/pythonnet/pythonnet), if you find any bugs, please report them. Also let me know if you have any comments

## Install via NuGet
To install Atrob, run the following command in the Package Manager Console :
```powershell
PM> Install-Package PythonNet.Helper
```

## Usage
**To use this library, you must have .NET and Python installed**

To start, make an instance of PyNet as below and give the Python DLL path
```csharp
IPyNet pyNet = new PyNet(@"C:\Program Files\Python311\python311.dll");
```

Now you can use `RunPython` which has many overloads whose parameter list and input type are listed below

|Name|Type|Description|
|----|----|-----------|
|pythonCode|`string`|Python code to be executed|
|parameters|`IDictionary<string, object>`|The list of input parameters in the form of a dictionary, which is the key of the variable name in Python|
|returnedVariableNames|`string[]`|The names of the variables that are supposed to be taken from the Python code|
|returnedVariableNames|`string[]`|The names of the variables that are supposed to be taken from the Python code|
|parameter|`(string key, object value)`|To pass a parameter instead of using a dictionary|
|returnedVariableName|`string`|To get just one return value instead of using an array|

## Samples



### Run
```csharp
pyNet.RunPython("print('Welcome To PythonNet.Helper')");
```

### Run From File
You can give the address of the code file and use `ReadFile` to read the code as below
```csharp
pyNet.RunPython("PythonFiles/HelloWorld.py".ReadFile());
```

### By Parameters
- Parameter
```csharp
pyNet.RunPython(@$"print('Hello ' + name)", ("name", "Mohammad Taqi"));
```

- Parameters
```csharp
 pyNet.RunPython("print(fname + ' ' + lname)", new Dictionary<string, object>
{
    ["fname"] = "Mohammad Taqi",
    ["lname"] = "Nasiri"
});
```

- Model parameter

```csharp
public class UserModel
{
    public string Name { get; set; } = string.Empty;
    public string Family { get; set; } = string.Empty;
    public DateTime BirthDay { get; set; }
}
```

```csharp
pyNet.RunPython("print(f'Name : {user.Name} | Family : {user.Family} | BirthDay : {user.BirthDay}')",("user",new UserModel()
{
    Name = "Mohammad Taqi",
    Family = "Nasiri",
    BirthDay = DateTime.Now
}));
```

### By returned Variables

- Without parameter

```csharp
pyNet.RunPython("from datetime import date\n" + "today = date.today()", "today")
```


- By parameter
```csharp
int sumNumbers = Convert.ToInt32(pyNet.RunPython("sum = sum(nums)", ("nums", new List<int>() { 1, 5, 8, 7, 15, 20, 36 }), "sum").ToString())
```

>You can also pass multiple parameters with a dictionary