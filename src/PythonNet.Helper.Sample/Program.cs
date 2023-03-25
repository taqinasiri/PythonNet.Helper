using PythonNet.Helper;
using PythonNet.Helper.Sample;

//Tip : To run, set the beginning of the DLL path, then uncomment any item you want and test it
const string PYTHONDLLPATH = @"C:\Program Files\Python311\python311.dll";


var pyNet = new Samples(new PyNet(PYTHONDLLPATH));


pyNet.PrintText();

//pyNet.PrintHelloName("Ali");

//pyNet.PrintNamesList(new List<string>() { "Mohammad", "Taqi", "Ali", "Javad", "Taha", "Iman", "Reza" });

//pyNet.PrintNameAndFamily("Mohammad Taqi", "Nasiri");

/*pyNet.PrintUserModel(new UserModel()
{
    Name = "Taqi",
    Family = "Nasiti",
    BirthDay = DateTime.Now
});*/

//WriteLine(pyNet.GetToday());

//WriteLine(pyNet.SumNumbersList(new List<int>() { 1, 5, 8, 7, 15, 20, 36 }));

//pyNet.RunFile();

//pyNet.GenerateQR("PythonNet.Helper","pynet.png");
