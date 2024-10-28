using System.Text.Json;
namespace QuizApp;
class JsonQuestionLoader
{
    public IEnumerable<Question> Questions { get; } //Declares the JsonQuestionLoader class with a public Questions property.

    public JsonQuestionLoader(string fileName) //Constructor initializes Questions by calling LoadQuestions method
    {
        Questions = LoadQuestions(fileName);
    }

    private static IEnumerable<Question> LoadQuestions(string filePath)
    {
        var json = File.ReadAllText(filePath); //Reads the contents of filePath as a JSON string.
        var questions = JsonSerializer.Deserialize<List<Question>>(json); //Deserializes the JSON string into a list of `Question` objects

        if (questions == null)
        {
            throw new Exception($"Couldn't load the file {filePath}");
        }
        return questions;
    }
}