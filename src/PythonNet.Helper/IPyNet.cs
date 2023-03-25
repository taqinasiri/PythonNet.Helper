namespace PythonNet.Helper;

public interface IPyNet
{
    #region Basics 
    public void RunPython(string pythonCode);
    public void RunPython(string pythonCode, IDictionary<string, object> parameters);
    public object[] RunPython(string pythonCode, string[] returnedVariableNames);
    public object[] RunPython(string pythonCode, IDictionary<string, object> parameters, string[] returnedVariableNames);
    #endregion

    #region Supplements
    public void RunPython(string pythonCode,(string key, object value) parameter);

    public object RunPython(string pythonCode, string returnedVariableName);

    public object[] RunPython(string pythonCode, (string key, object value) parameter, string[] returnedVariableNames);
    public object RunPython(string pythonCode, IDictionary<string, object> parameters, string returnedVariableName);
    public object RunPython(string pythonCode, (string key, object value) parameter, string returnedVariableName);
    #endregion
}
