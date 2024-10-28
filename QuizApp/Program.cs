namespace QuizApp;
public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; //Sets console output encoding to UTF-8 for special characters.
            var writer = new Writer(); //Instantiate Writer class for formatted console outputs

            string questionFileName = args.Length == 1 ? args[0] : "questions.json"; //Sets the question file name based on the command-line arguments, default to "questions.json" if no args.
            var questionLoader = new JsonQuestionLoader(questionFileName); //Instantiate JsonQuestionLoader class with fileName parameter. This instance loads questions from JSON file
            var game = new Game(questionLoader.Questions, writer); //Instantiate (To create an instance of) the Game with loaded questions (from the JSON file) and writer       

            game.Start();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Sorry, unexpected error: {ex.Message}");
        }
        Console.WriteLine();
    }
}
