using PythonNet.Helper.Sample.Models;

namespace PythonNet.Helper.Sample;

public class Samples
{

    private readonly IPyNet pyNet;
    public Samples(IPyNet pyNet)
        => this.pyNet = pyNet;

    #region Run
    public void PrintText()
        => pyNet.RunPython("print('Welcome To PythonNet.Helper')");
    #endregion

    #region Run By Parameter Without Output
    public void PrintHelloName(string name) => pyNet.RunPython(@$"print('Hello ' + name)", ("name", name));
    public void PrintNamesList(List<string> names)
        => pyNet.RunPython("for name in namesList: print(name)", ("namesList", names));
    public void PrintNameAndFamily(string name, string family)
        => pyNet.RunPython("print(lname + ' ' + fname)", new Dictionary<string, object>
        {
            ["lname"] = name,
            ["fname"] = family
        });
    public void PrintUserModel(UserModel user)
        => pyNet.RunPython("print(f'Name : {user.Name} | Family : {user.Family} | BirthDay : {user.BirthDay}')", ("user", user));
    #endregion

    #region Run Without Parameter By Output
    public DateTime GetToday()
        => Convert.ToDateTime(pyNet.RunPython("from datetime import date\n" + "today = date.today()", "today").ToString());
    #endregion


    #region Run By Parameter And Output
    public int SumNumbersList(List<int> numbers)
        => Convert.ToInt32(pyNet.RunPython("sum = sum(nums)", ("nums", numbers), "sum").ToString());
    #endregion

    #region Run File
    public void RunFile()
        => pyNet.RunPython("PythonFiles/HelloWorld.py".ReadFile());

    public void GenerateQR(string data, string fileNameToSave)
         => pyNet.RunPython("PythonFiles/GenerateQR.py".ReadFile(), new Dictionary<string, object>()
         {
             ["data"] = data,
             ["fileName"] = fileNameToSave
         });
    #endregion
}