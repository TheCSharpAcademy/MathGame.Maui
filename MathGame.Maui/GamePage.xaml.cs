namespace MathGame.Maui;

public partial class GamePage : ContentPage
{
    public string GameType { get; set; }
    int firstNumber = 0;
    int secondNumber = 0;
    int score = 0;
    int gamesLeft = 5;

    public GamePage(string gameType)
    {
        InitializeComponent();
        GameType = gameType;
        this.BindingContext = this;

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

        if (GameType == "Addition")
        {
            if (answer == firstNumber + secondNumber)
            {
                ++score;
                AnswerLabel.Text = "Correct!";
            } else
            {
                AnswerLabel.Text = "Wrong answer!";
            }
        }
        else if (GameType == "Subtraction")
        {
            if (answer == firstNumber - secondNumber)
            {
                ++score;
                AnswerLabel.Text = "Correct!";
            }
            else
            {
                AnswerLabel.Text = "Wrong answer!";
            }
        }
        else if (GameType == "Multiplication")
        {
            if (answer == firstNumber * secondNumber)
            {
                ++score;
                AnswerLabel.Text = "Correct!";
            }
            else
            {
                AnswerLabel.Text = "Wrong answer!";
            }
        }
        else if (GameType == "Division")
        {
            if (answer == firstNumber / secondNumber)
            {
                ++score;
                AnswerLabel.Text = "Correct!";
            }
            else
            {
                AnswerLabel.Text = "Wrong answer!";
            }
        }

        --gamesLeft;
        if (gamesLeft == 0)
        {
            GameOver(score);
        }
        else
        {
            CreateNewQuestion();
        }
    }
    private void GameOver(int score)
    {
    }

}