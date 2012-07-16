using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Diagnostics;

namespace ActPlayResponsibly2012.Questions
{
    public class QuestionBank
    {
        private static QuestionBank current;
        public static QuestionBank Current
        {
            get
            {
                if (current == null)
                {
                    current = new QuestionBank();
                }
                return current;
            }
            private set
            {
                current = value;
            }
        }
        private List<Question> qList;
        public List<Question> QList
        {
            get
            {
                if (qList == null)
                {
                    qList = new List<Question>();
                }
                return qList;
            }
            set
            {
                qList = value;
            }
        }

        #region Multiple Categories [Obsolete]
        //private Queue<Question> queueRedNormal;
        //private Queue<Question> queueRedHard;
        //private Queue<Question> queueBlueNormal;
        //private Queue<Question> queueBlueHard;
        //private Queue<Question> queueYellowNormal;
        //private Queue<Question> queueYellowHard;
        //private Queue<Question> queueGreenNormal;
        //private Queue<Question> queueGreenHard;
        //private Queue<Question> queueGrayNormal;
        //private Queue<Question> queueGrayHard;
        #endregion

        #region Multiple Difficulties
        private Queue<Question> queueNormal;
        private Queue<Question> queueHard;
        #endregion

        private Queue<Question> queueQuestion;
        private Random random;

        private QuestionBank() { random = new Random(); }
        public void SetQuestions(List<Question> QuesList)
        {
            QList = QuesList;
            QList = QList.OrderBy(p => random.NextDouble()).ToList();
            PopulateQueues();
        }
        private void PopulateQueues()
        {
            #region Multiple Categories [Obsolete]
            //List<Question> RedNormal = qList.FindAll(delegate(Question ques){return ques.Category==QuestionCategory.Red && ques.Difficulty==QuestionDifficulty.Normal;});
            //queueRedNormal = new Queue<Question>(RedNormal);
            //List<Question> RedHard = qList.FindAll(delegate(Question ques){return ques.Category==QuestionCategory.Red && ques.Difficulty==QuestionDifficulty.Hard;});
            //queueRedHard  = new Queue<Question>(RedHard);
            //List<Question> BlueNormal = qList.FindAll(delegate(Question ques){return ques.Category==QuestionCategory.Blue && ques.Difficulty==QuestionDifficulty.Normal;});
            //queueBlueNormal = new Queue<Question>(BlueNormal);
            //List<Question> BlueHard = qList.FindAll(delegate(Question ques){return ques.Category==QuestionCategory.Blue && ques.Difficulty==QuestionDifficulty.Hard;});
            //queueBlueHard = new Queue<Question>(BlueHard);
            //List<Question> GreenNormal = qList.FindAll(delegate(Question ques){return ques.Category==QuestionCategory.Green && ques.Difficulty==QuestionDifficulty.Normal;});
            //queueGreenNormal = new Queue<Question>(GreenNormal);
            //List<Question> GreenHard = qList.FindAll(delegate(Question ques){return ques.Category==QuestionCategory.Green && ques.Difficulty==QuestionDifficulty.Hard;});
            //queueGreenHard = new Queue<Question>(GreenHard);
            //List<Question> YellowNormal = qList.FindAll(delegate(Question ques){return ques.Category==QuestionCategory.Yellow && ques.Difficulty==QuestionDifficulty.Normal;});
            //queueYellowNormal = new Queue<Question>(YellowNormal);
            //List<Question> YellowHard = qList.FindAll(delegate(Question ques){return ques.Category==QuestionCategory.Yellow && ques.Difficulty==QuestionDifficulty.Hard;});
            //queueYellowHard = new Queue<Question>(YellowHard);
            //List<Question> GrayNormal = qList.FindAll(delegate(Question ques) { return ques.Category == QuestionCategory.Gray && ques.Difficulty == QuestionDifficulty.Normal; });
            //queueGrayNormal = new Queue<Question>(GrayNormal);
            //List<Question> GrayHard = qList.FindAll(delegate(Question ques) { return ques.Category == QuestionCategory.Gray && ques.Difficulty == QuestionDifficulty.Hard; });
            //queueGrayHard = new Queue<Question>(GrayHard);
            #endregion

            #region Multiple Difficulties
            queueNormal = new Queue<Question>(qList.Where<Question>(p => p.Difficulty == QuestionDifficulty.Normal));
            queueHard = new Queue<Question>(qList.Where<Question>(p => p.Difficulty == QuestionDifficulty.Hard));
            #endregion

            queueQuestion = new Queue<Question>(qList);
        }
        public Question GetQuestion(QuestionCategory category, QuestionDifficulty difficulty)
        {
            #region Obsolete
            /*if (category == QuestionCategory.Red)
                return new Question()
                {
                    QuestionContent = "Red " + difficulty.ToString() + ": How to design this screen??? How to design this screen??? How to design this screen???",
                    A = "Dunno lah",
                    B = "How can I know",
                    C = "No idea",
                    D = "Why have to design??? Hehehe",
                    CorrectAnswer = "A"
                };
            else if (category == QuestionCategory.Blue)
                return new Question()
                {
                    QuestionContent = "Blue " + difficulty.ToString() + ": Test",
                    A = "A",
                    B = "B",
                    C = "C",
                    D = "D",
                    CorrectAnswer = "A"
                };
            else if (category == QuestionCategory.Green)
                return new Question()
                {
                    QuestionContent = "Green " + difficulty.ToString() + ": Test",
                    A = "A",
                    B = "B",
                    C = "C",
                    D = "D",
                    CorrectAnswer = "B"
                };
            else if (category == QuestionCategory.Yellow)
                return new Question()
                {
                    QuestionContent = "Yellow " + difficulty.ToString() + ": Test",
                    A = "A",
                    B = "B",
                    C = "C",
                    D = "D",
                    CorrectAnswer = "C"
                };
            else if (category == QuestionCategory.Gray)
                return new Question()
                {
                    QuestionContent = "Gray Normal: Test",
                    A = "A",
                    B = "B",
                    C = "C",
                    D = "D",
                    CorrectAnswer = "D"
                };
            else
                return null;*/
            #endregion

            #region Multiple Categories [Obsolete]
            //string queueName = string.Format("queue" + category.ToString() + difficulty.ToString());
            //try
            //{
            //    if (queueName == "queueRedNormal")
            //        return queueRedNormal.Dequeue();
            //    else if (queueName == "queueRedHard")
            //        return queueRedHard.Dequeue();
            //    else if (queueName == "queueBlueNormal")
            //        return queueBlueNormal.Dequeue();
            //    else if (queueName == "queueBlueHard")
            //        return queueBlueHard.Dequeue();
            //    else if (queueName == "queueYellowNormal")
            //        return queueYellowNormal.Dequeue();
            //    else if (queueName == "queueYellowHard")
            //        return queueYellowHard.Dequeue();
            //    else if (queueName == "queueGreenNormal")
            //        return queueGreenNormal.Dequeue();
            //    else if (queueName == "queueGreenHard")
            //        return queueGreenHard.Dequeue();
            //    else if (queueName == "queueGrayNormal")
            //        return queueGrayNormal.Dequeue();
            //    else if (queueName == "queueGrayHard")
            //        return queueGrayHard.Dequeue();
            //    else
            //        return null;
            //}
            //catch(Exception e)
            //{
            //    Debug.WriteLine(e.Message);
            //    return null;
            //}
            #endregion

            #region Multiple Difficulties
            try
            {
                if (difficulty == QuestionDifficulty.Normal)
                    return queueNormal.Dequeue();
                else
                    return queueHard.Dequeue();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }
            #endregion

            //try
            //{
            //    return queueQuestion.Dequeue();
            //}
            //catch (Exception e)
            //{
            //    Debug.WriteLine(e.Message);
            //    return null;
            //}
        }
    }
}
