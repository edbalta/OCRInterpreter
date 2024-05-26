using System.Text;
using Newtonsoft.Json;
using OCRInterpreter.Models;

namespace OCRInterpreter;

public class Interpreter
{
    private static readonly int MaxLineHeight = 24;
    /// <summary>
    /// OCR tarafından üretilmiş json string
    /// </summary>
    /// <param name="jsonString"></param>
    /// <returns>OCR json dosyasının yorumlanmış string hali</returns>
    public static string InterpretOCRJson(string jsonString)
    {
        var responseArray = JsonConvert.DeserializeObject<List<OCRModel>>(jsonString);
        var modelLineDictionary = new Dictionary<int, List<OCRModel>>();
        if (responseArray == null)
            return "Json Parse Hatası";
        
        for (var i = 1; i < responseArray.Count; i++)
        {
            InsertModelToLine(modelLineDictionary, responseArray[i]);
        }
        var response = BuildResponse(modelLineDictionary);
        
        return response;
    }
    /// <summary>
    /// Gelen modeli ait oldugu satıra atar.
    /// </summary>
    /// <param name="modelLineDictionary"></param>
    /// <param name="model"></param>
    private static void InsertModelToLine(Dictionary<int, List<OCRModel>> modelLineDictionary, OCRModel model)
    {
        var found = false;
        var currentY = model.BoundingPoly.Vertices[0].Y;
        foreach (var (key, value) in modelLineDictionary)
            if (key - MaxLineHeight / 2 < currentY && key + MaxLineHeight / 2 > currentY)
            {
                value.Add(model);
                found = true;
                break;
            }

        if (!found) modelLineDictionary.Add(currentY, new List<OCRModel> {model});
    }
    /// <summary>
    /// Cevap stringini oluşturur
    /// </summary>
    /// <param name="modelLineDictionary"></param>
    /// <returns></returns>
    private static string BuildResponse(Dictionary<int, List<OCRModel>> modelLineDictionary)
    {
        var builder = new StringBuilder();
        builder.Append(" line   |    text");

        var line = 1;
        foreach (var (key, values) in modelLineDictionary)
        {
            var orderedValues = values.OrderBy(x => x.BoundingPoly.Vertices[0].X);

            builder.Append("\n   " + line + "    |  ");
            foreach (var value in orderedValues) builder.Append(" " + value.Description);
            line++;
        }

        return builder.ToString();
    }
    
}