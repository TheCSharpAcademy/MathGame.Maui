using System;
using System.Collections.Generic;
using System.Text;
using static Math_Game.MathQuestion;

namespace Math_Game
{
    public partial class MathQuestion
    {

        int _firstnumber { get; }
        int _secondnumber { get; }

        MathOperation _operation { get; }



        public MathQuestion(int Firstnumber, int Secondnumber, MathOperation Operation)
        {
            if (!Enum.IsDefined(typeof(MathOperation), Operation))
            {
                throw new ArgumentOutOfRangeException(nameof(Operation), "Unknown math operation");
            }

            if (Operation == MathOperation.Division)
            {
                if (Firstnumber < 0 || Firstnumber > 100)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(Firstnumber),
                        "The dividend must be between 0 and 100.");
                }

                if (Secondnumber == 0)
                {
                    throw new ArgumentException(
                        "The divisor cannot be zero.",
                        nameof(Secondnumber));
                }

                if (Firstnumber % Secondnumber != 0)
                {
                    throw new ArgumentException("Division must produce integer without aremainder", nameof(Secondnumber));
                }

            }
            this._firstnumber = Firstnumber;
            this._secondnumber = Secondnumber;
            _operation = Operation;
        }

        //public delegate int CalculationDelegate(int Num1,int Num2);


        public string GetQuestionText()
        {
            string operationSymbol = _operation switch
            {
                MathOperation.Addition => "+",
                MathOperation.Subtraction => "-",
                MathOperation.Multiplication => "*",
                MathOperation.Division => "/",

            };
            return $"{_firstnumber} {operationSymbol} {_secondnumber}";
        }

        public int CalculateCorrectAnswer()
        {
            return _operation switch
            {
                MathOperation.Addition => (_firstnumber + _secondnumber),
                MathOperation.Subtraction => (_firstnumber - _secondnumber),
                MathOperation.Multiplication => (_firstnumber * _secondnumber),
                MathOperation.Division => (_firstnumber / _secondnumber)
            };
        }

        public bool IsCorrect(int answer) => answer == CalculateCorrectAnswer();
    }
}
