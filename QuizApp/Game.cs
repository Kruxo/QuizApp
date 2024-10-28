namespace QuizApp;

class Game
{
    private int _score = 0; //Private int field to store user's score
    private readonly IEnumerable<Question> _questions; //Stores the questions
    private readonly Writer _writer;

    public Game(IEnumerable<Question> questions, Writer writer) //Constructor for game class with questions and writer as parameters
    {
        //Checks if there are any questions
        if (!questions.Any())
        {
            throw new Exception("Questions can't be null or empty!");
        }
        _questions = questions; //Initializes the fields with provided arguments to complete the constructor
        _writer = writer;
    }

    public void Start()
    {
        _writer.InfoLine("\n💥 Welcome to the Quiz Game! 💥\n");
        foreach (var question in _questions) //Iterates over each question from AskQuestion method
        {
            AskQuestion(question);
        }
        _writer.InfoLine($"Your final score is {_score}/{_questions.Count()}\n");
    }

    private void AskQuestion(Question question) //This method displays questions and check the answers
    {
        _writer.InfoLine($"{question.QuestionText}"); //Displays question text
        for (int i = 0; i < question.Options.Count; i++) //List all options for each question
        {
            _writer.InfoLine($"{i + 1}) {question.Options[i]}"); //added + 1 to output the first question as number 1
        }
        _writer.InfoLine(); //Adds a blank line for spacing

        Answer answer = GetAnswerFromUser(question.Options.Count); //Calls GetAnswerFromUser method to get the answer from user and stores it in answer variable
        if (answer.SelectedOption - 1 == question.CorrectOption) //Checks if the user input matches the anser's index, minus -1 index to correct the user input to the correct index, since we added +1 above
        {
            _writer.SuccesLine("Correct\n");
            _score++; //Updates score
        }
        else
        {
            _writer.ErrorLine($"Incorrect. The correct answer is: {question.Options[question.CorrectOption]}");
        }
    }

    private Answer GetAnswerFromUser(int numberOfOptions)
    {
        int selectedOption;
        while (true)
        {
            _writer.Info("Select an option: ");
            var input = Console.ReadLine();
            if (int.TryParse(input, out selectedOption) && selectedOption >= 0 && selectedOption < numberOfOptions)
            {
                break;
            }
            _writer.WarningLine("Invalid option. Please try again.\n");
        }
        return new Answer(selectedOption); //Returns Answer object with the selected option/input 
    }
}
