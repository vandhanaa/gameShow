using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Configuration;

using ActPlayResponsibly2012.Teams;
using System.Windows;
using ActPlayResponsibly2012.Questions;
using ActPlayResponsibly2012.FlashMessages;

namespace ActPlayResponsibly2012.Repository
{
    public class Repository
    {
        private static Repository current;
        public static Repository Current
        {
            get
            {
                if (current == null)
                {
                    current = new Repository();
                }
                return current;
            }
            private set
            {
                current = value;
            }
        }

        private Repository() { }

        #region Teams
        public List<Team> LoadTeams()
        {
            List<Team> result = new List<Team>();

            XmlSerializer xs = new XmlSerializer(typeof(TeamDataCollection));
            TeamDataCollection tc;

            try
            {
                using (StreamReader sr = new StreamReader(ConfigurationManager.AppSettings["XmlTeamsData"]))
                {
                    tc = xs.Deserialize(sr) as TeamDataCollection;
                }

                Team red = new Team(tc.RedTeam.Name, TeamId.Red,
                                    new BitmapImage(new Uri(Environment.CurrentDirectory + @"\" + tc.RedTeam.AvatarPath, UriKind.RelativeOrAbsolute)),
                                    new BitmapImage(new Uri(Environment.CurrentDirectory + @"\" + tc.RedTeam.BackgroundPath, UriKind.RelativeOrAbsolute)),
                                    tc.RedTeam.Path.Select(o => new Point(o[0], o[1])).ToList());
                result.Add(red);

                Team green = new Team(tc.GreenTeam.Name, TeamId.Green,
                                    new BitmapImage(new Uri(Environment.CurrentDirectory + @"\" + tc.GreenTeam.AvatarPath, UriKind.RelativeOrAbsolute)),
                                    new BitmapImage(new Uri(Environment.CurrentDirectory + @"\" + tc.GreenTeam.BackgroundPath, UriKind.RelativeOrAbsolute)),
                                    tc.GreenTeam.Path.Select(o => new Point(o[0], o[1])).ToList());
                result.Add(green);

                Team yellow = new Team(tc.YellowTeam.Name, TeamId.Yellow,
                                    new BitmapImage(new Uri(Environment.CurrentDirectory + @"\" + tc.YellowTeam.AvatarPath, UriKind.RelativeOrAbsolute)),
                                    new BitmapImage(new Uri(Environment.CurrentDirectory + @"\" + tc.YellowTeam.BackgroundPath, UriKind.RelativeOrAbsolute)),
                                    tc.YellowTeam.Path.Select(o => new Point(o[0], o[1])).ToList());
                result.Add(yellow);

                Team blue = new Team(tc.BlueTeam.Name, TeamId.Blue,
                                    new BitmapImage(new Uri(Environment.CurrentDirectory + @"\" + tc.BlueTeam.AvatarPath, UriKind.RelativeOrAbsolute)),
                                    new BitmapImage(new Uri(Environment.CurrentDirectory + @"\" + tc.BlueTeam.BackgroundPath, UriKind.RelativeOrAbsolute)),
                                    tc.BlueTeam.Path.Select(o => new Point(o[0], o[1])).ToList());
                result.Add(blue);
            }
            catch (Exception e) { }

            return result;
        }

        public void InitializeTeamDataXml()
        {
            TeamDataCollection tc = new TeamDataCollection();
            tc.RedTeam = new TeamData()
            {
                Id = "Red",
                Name = "Singapore [Red]",
                AvatarPath = @"Images\Teams\RedTeam",
                BackgroundPath = @"Images\Background\RedBackground",
                Path = new List<int[]>() { new int[] { 0, 0} }
            };
            tc.YellowTeam = new TeamData()
            {
                Id = "Yellow",
                Name = "Hong Kong [Yellow]",
                AvatarPath = @"Images\Teams\YellowTeam",
                BackgroundPath = @"Images\Background\YellowBackground",
                Path = new List<int[]>() { new int[] { 0, 0 } }
            };
            tc.GreenTeam = new TeamData()
            {
                Id = "Green",
                Name = "India [Green]",
                AvatarPath = @"Images\Teams\GreenTeam",
                BackgroundPath = @"Images\Background\GreenBackground",
                Path = new List<int[]>() { new int[] { 0, 0 } }
            };
            tc.BlueTeam = new TeamData()
            {
                Id = "Blue",
                Name = "Japan [Blue]",
                AvatarPath = @"Images\Teams\BlueTeam",
                BackgroundPath = @"Images\Background\BlueBackground",
                Path = new List<int[]>() { new int[] { 0, 0 } }
            };

            XmlSerializer xs = new XmlSerializer(typeof(TeamDataCollection));
            using (StreamWriter sw = new StreamWriter(@"D:\Teams.xml"))
            {
                xs.Serialize(sw, tc);
            }
        }
        #endregion

        #region Questions
        public void LoadQuestionsToSerialiser()
        {
            List<Question> QuestionList = new List<Question>();
            TextReader reader = new StreamReader(ConfigurationManager.AppSettings["XmlQuestionsText"]);
            String line;
            while ((line = reader.ReadLine()) != null)
            {
                Question ques = new Question();
                ques.QuestionContent = line;
                ques.A = reader.ReadLine();
                ques.B = reader.ReadLine();
                ques.C = reader.ReadLine();
                ques.D = reader.ReadLine();
                ques.CorrectAnswer = reader.ReadLine();
                line = reader.ReadLine();
                ques.Category = (QuestionCategory)Enum.Parse(typeof(QuestionCategory), line);
                line = reader.ReadLine();
                ques.Difficulty = (QuestionDifficulty)Enum.Parse(typeof(QuestionDifficulty), line);
                QuestionList.Add(ques);
            }
            reader.Close();
            SerialiseToXML(QuestionList);
        }

        private void SerialiseToXML(List<Question> QList)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Question>));
                TextWriter textWriter = new StreamWriter(ConfigurationManager.AppSettings["XmlQuestionsData"]);
                serializer.Serialize(textWriter, QList);
                Console.WriteLine();
                textWriter.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Inner Exception: {0}", ex.InnerException);
                Console.WriteLine("Message: {0}", ex.Message);
                Console.WriteLine("Exception Type: {0}", ex.GetType().FullName);
                Console.WriteLine("Source: {0}", ex.Source);
                Console.WriteLine("StrackTrace: {0}", ex.StackTrace);
                Console.WriteLine("TargetSite: {0}", ex.TargetSite);
            }
        }

        public QuestionBank LoadQuestionBank()
        {
            LoadQuestionsToSerialiser();
            TextReader textReader = new StreamReader(ConfigurationManager.AppSettings["XmlQuestionsData"]);
            XmlSerializer deserialiser = new XmlSerializer(typeof(List<Question>));
            var QList = (List<Question>)deserialiser.Deserialize(textReader);
            textReader.Close();
            QuestionBank xyz = QuestionBank.Current;
            xyz.SetQuestions(QList);
            return xyz;
        }
        #endregion

        #region Flash Messages
        public FlashMessageBank LoadFlashMessageBank()
        {
            // TODO: implement this
            return FlashMessageBank.Current;
        }
        #endregion
    }
}
