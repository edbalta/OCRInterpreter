namespace OCRInterpreter;

class Program
{
    static void Main(string[] args)
    {
        // OCRJsons klasöründe bulunun tüm json dosyalarını yorumlamak için alıyoruz
        var di = new DirectoryInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "OCRJsons"));
        var files = di.GetFiles("*.json");
        
        foreach (var file in files)
        {
            var content = File.ReadAllText(file.FullName);
            var model = Interpreter.InterpretOCRJson(content);
            Console.WriteLine(model);
            Console.WriteLine("------------------");
        }
    }
}