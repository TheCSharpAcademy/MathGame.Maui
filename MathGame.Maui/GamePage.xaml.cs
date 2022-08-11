namespace MathGame.Maui;

public partial class GamePage : ContentPage
{
    public string GameType { get; set; }
    int firstNumber = 0;
    int secondNumber = 0;
    int score = 0;
    const int totalQuestions = 2;
    int gamesLeft = totalQuestions;

    public GamePage(string gameType)
    {
        InitializeComponent();
        GameType = gameType;
        BindingContext = this;

        CreateNewQuestion();
    }

    private void CreateNewQuestion()
    {
        var gameOperand = GameType switch
        {
            "Addition" => "+",
            "Subtraction" => "-",
            "Multiplication" => "*",
            "Division" => "/",
            _ => ""
        };

        var random = new Random();

        firstNumber = GameType != "Division" ? random.Next(1, 9) : random.Next(1, 99);
        secondNumber = GameType != "Division" ? random.Next(1, 9) : random.Next(1, 99);

        if (GameType == "Division")
        {
            while (firstNumber < secondNumber || firstNumber % secondNumber != 0)
            {
                firstNumber = random.Next(1, 99);
                secondNumber = random.Next(1, 99);
            }
        }

        QuestionLabel.Text = $"{firstNumber} {gameOperand} {secondNumber}";

    }

    private void OnAnswerSubmitted(object sender, EventArgs e)
    {
        var answer = Int32.Parse(Answer.Text);
        var isCorrect = false;

        switch (GameType)
        {
            case "Addition" :
                isCorrect = answer == firstNumber + secondNumber;
                ProcessAnswer(isCorrect);
                break;
            case "Subtraction":
                isCorrect = answer == firstNumber + secondNumber;
                ProcessAnswer(isCorrect);
                break;
            case "Multiplication":
                isCorrect = answer == firstNumber + secondNumber;
                ProcessAnswer(isCorrect);
                break;
            case "Division":
                isCorrect = answer == firstNumber + secondNumber;
                ProcessAnswer(isCorrect);
                break;
        };

        gamesLeft--;

        if (gamesLeft > 0)
            CreateNewQuestion();
        else
            GameOver();
    }

    private void ProcessAnswer(bool isCorrect)
    {
        score = isCorrect ? score += 1 : score;  
        AnswerLabel.Text = isCorrect ? "Correct!" : "Incorrect";
    }

    private void GameOver()
    {
        GameOverLabel.Text = $"Game over! Your got {score} out of {totalQuestions} right";
    }
}