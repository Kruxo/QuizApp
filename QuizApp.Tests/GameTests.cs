namespace QuizApp.Tests;

public class GameTests

{
    [Fact]
    public void Game_ThrowsException_WhenQuestionsAreEmpty()
    {
        // Arrange
        var writer = new Writer(); //Instance of Writer to pass onto Game as a dependency
        var emptyQuestions = new List<Question>(); //Creating an empty list for simulating scenario with no questions available to load

        // Act & Assert
        Assert.Throws<Exception>(() //Checks if creating a new Game instance with an empty list raises an exception
            => new Game(emptyQuestions, writer)); //Test passes if an exception is thrown 
    }

    [Fact]
    public void Game_DoesNotThrowException_WhenQuestionsAreProvided()
    {
        // Arrange
        var writer = new Writer();
        var questions = new List<Question>
        {
            new Question("What is 5 + 3?", new List<string> { "7", "8", "9" }, 1)
        };

        // Act & Assert
        var exception = Record.Exception(() => new Game(questions, writer)); //Checks for any exceptions thrown when creating a new Game instance
        Assert.Null(exception); //Test passes if no exception is thrown, meaning Record.Exception is null so no exceptions
    }

}