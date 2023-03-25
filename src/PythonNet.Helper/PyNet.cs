using Python.Runtime;

namespace PythonNet.Helper;

public class PyNet : IPyNet
{
    public PyNet(string pythonDllPath)
    {
        Environment.SetEnvironmentVariable("PYTHONNET_PYDLL", pythonDllPath);
        PythonEngine.Initialize();
    }

    public void RunPython(string pythonCode)
    {
        using (Py.GIL())
        {
            PythonEngine.RunSimpleString(pythonCode);
        }
    }
    public void RunPython(string pythonCode, IDictionary<string, object> parameters)
    {
        using (Py.GIL())
        {
            using PyModule scope = Py.CreateScope();
            foreach (var parameter in parameters)
                scope.Set(parameter.Key, parameter.Value.ToPython());
            scope.Exec(pythonCode);
        }
    }
    public object[] RunPython(string pythonCode, string[] returnedVariableNames)
    {
        object[] result = new object[returnedVariableNames.Length];
        using (Py.GIL())
        {
            using PyModule scope = Py.CreateScope();
            scope.Exec(pythonCode);
            for (int i = 0; i < returnedVariableNames.Length; i++)
                result[i] = scope.Get<object>(returnedVariableNames[i]);
        }
        return result;
    }
    public object[] RunPython(string pythonCode, IDictionary<string, object> parameters, string[] returnedVariableNames)
    {
        object[] result = new object[returnedVariableNames.Length];
        using (Py.GIL())
        {
            using PyModule scope = Py.CreateScope();
            foreach (var parameter in parameters)
                scope.Set(parameter.Key, parameter.Value.ToPython());
            scope.Exec(pythonCode);
            for (int i = 0; i < returnedVariableNames.Length; i++)
                result[i] = scope.Get<object>(returnedVariableNames[i]);
        }
        return result;
    }


    public void RunPython(string pythonCode, (string key, object value) parameter)
      => RunPython(pythonCode, new Dictionary<string, object>() { [parameter.key] = parameter.value });

    public object RunPython(string pythonCode, IDictionary<string, object> parameters, string returnedVariableName)
        => RunPython(pythonCode, parameters, new[] { returnedVariableName })[0];
    public object[] RunPython(string pythonCode, (string key, object value) parameter, string[] returnedVariableNames)
        => RunPython(pythonCode, new Dictionary<string, object>() { [parameter.key] = parameter.value }, returnedVariableNames);
    public object RunPython(string pythonCode, (string key, object value) parameter, string returnedVariableName)
        => RunPython(pythonCode, new Dictionary<string, object>() { [parameter.key] = parameter.value }, new[] { returnedVariableName })[0];


    public object RunPython(string pythonCode, string returnedVariableName)
        => RunPython(pythonCode, new[] { returnedVariableName })[0];
}
