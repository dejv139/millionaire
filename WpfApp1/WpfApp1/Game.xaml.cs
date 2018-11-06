using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interakční logika pro Game.xaml
    /// </summary>
    public partial class Game : Page
    {

        List<Question> LoQ = new List<Question>
        {
            new Question { question = "Jaký typ zvířete je Medvěd", wrongAnswer1 = "plaz", wrongAnswer2 = "ptak", wrongAnswer3 = "ovoce", rightAnswer = "savec" },
            new Question { question = "Kdo je prezident ČR", wrongAnswer1 = "Hus", wrongAnswer2 = "Stalin", wrongAnswer3 = "Pewdiepie", rightAnswer = "Zeman" },
            new Question { question = "Jak dělá pes", wrongAnswer1 = "Mnau", wrongAnswer2 = "Píp", wrongAnswer3 = "Bzz", rightAnswer = "Woah" },
            new Question { question = "Jak dělá kohout", wrongAnswer1 = "Haf", wrongAnswer2 = "Čus", wrongAnswer3 = "Mlask", rightAnswer = "Kykyriký" },
            new Question { question = "Jak se dělá píves", wrongAnswer1 = "Z asfaltu", wrongAnswer2 = "Z chlupů", wrongAnswer3 = "z koberce", rightAnswer = "z chmele" },
            new Question { question = "Jak dělá auto", wrongAnswer1 = "Mnau", wrongAnswer2 = "Píp", wrongAnswer3 = "Bzz", rightAnswer = "Brum Brum" },
            new Question { question = "Jak dělá osel", wrongAnswer1 = "Mnau", wrongAnswer2 = "All star by smash mouth", wrongAnswer3 = "Bzz", rightAnswer = "íá" },
            new Question { question = "Jak dělá kuře", wrongAnswer1 = "Mnau", wrongAnswer2 = "haf", wrongAnswer3 = "Bzz", rightAnswer = "píp" },
            new Question { question = "Kdy naposledy pípne kuře", wrongAnswer1 = "Netušim", wrongAnswer2 = "Před zabitím", wrongAnswer3 = "Bzz", rightAnswer = "Na pokladně" },
            new Question { question = "Jak dělá spící člověk", wrongAnswer1 = "Mnau", wrongAnswer2 = "čus", wrongAnswer3 = "Bzz", rightAnswer = "chrrr" },
            new Question { question = "Jak dělá prase", wrongAnswer1 = "haf", wrongAnswer2 = "Píp", wrongAnswer3 = "Bzz", rightAnswer = "Chrochty chrocht" },
            new Question { question = "Jak dělá drak", wrongAnswer1 = "Mnau", wrongAnswer2 = "Píp", wrongAnswer3 = "Bzz", rightAnswer = "Ahoj, já jsem honza novák" },
            new Question { question = "Co udělala lžička, když spadla do kafíčka", wrongAnswer1 = "Nic", wrongAnswer2 = "WTF", wrongAnswer3 = "Bác", rightAnswer = "Plác" },
            new Question { question = "Co očekávám od týhle práce", wrongAnswer1 = "1", wrongAnswer2 = "1", wrongAnswer3 = "Dobrou známku", rightAnswer = "Doufám aspon v 4" },
            new Question { question = "Kde je bílý dům", wrongAnswer1 = "Most", wrongAnswer2 = "Nigerie", wrongAnswer3 = "Amazonský prales", rightAnswer = "Washington D.C" },
            new Question { question = "Odkud pocházejí bojovníci ninja", wrongAnswer1 = "Most", wrongAnswer2 = "Nigérie", wrongAnswer3 = "Amazonský prales", rightAnswer = "Japonsko" },
            new Question { question = "Jak dělá orel", wrongAnswer1 = "Mnau", wrongAnswer2 = "Píp", wrongAnswer3 = "Bzz", rightAnswer = "Aaaaaaaaa" },
            new Question { question = "Co představuje orel bělohlavý pro usa", wrongAnswer1 = "Smrt", wrongAnswer2 = "Naději", wrongAnswer3 = "Blaho", rightAnswer = "Freeeedom" },
            new Question { question = "Jak dela kočka", wrongAnswer1 = "Hop", wrongAnswer2 = "Mlok", wrongAnswer3 = "skok", rightAnswer = "mnau" }

        };
        public int qDecider;
        public int cycle = 0;
        private Frame frame;

        public Game()
        {
            InitializeComponent();

            ButtonContent();
        }

        public Game(Frame MainFrame) : this()
        {
            this.frame = MainFrame;
        }

        private void ButtonContent()
        {
            cycle++;
            if (cycle > 15)
            {
                frame.Navigate(new WinScreen(frame));
            }
            else
            {
                Random random = new Random();
                int decider1 = random.Next(0, 11);
                int decider2 = random.Next(0, 11);
                qDecider = random.Next(0, LoQ.Count);
                q.Content = LoQ[qDecider].question;
                if ((decider1 % 2) == 0 && (decider2 % 2) == 0)
                {
                    Answer1.Content = LoQ[qDecider].rightAnswer;
                    Answer2.Content = LoQ[qDecider].wrongAnswer1;
                    Answer3.Content = LoQ[qDecider].wrongAnswer2;
                    Answer4.Content = LoQ[qDecider].wrongAnswer3;
                }
                else if ((decider1 % 2) == 1 && (decider2 % 2) == 0)
                {
                    Answer1.Content = LoQ[qDecider].wrongAnswer1;
                    Answer2.Content = LoQ[qDecider].rightAnswer;
                    Answer3.Content = LoQ[qDecider].wrongAnswer2;
                    Answer4.Content = LoQ[qDecider].wrongAnswer3;
                }
                else if ((decider1 % 2) == 1 && (decider2 % 2) == 1)
                {
                    Answer1.Content = LoQ[qDecider].wrongAnswer1;
                    Answer2.Content = LoQ[qDecider].wrongAnswer2;
                    Answer3.Content = LoQ[qDecider].rightAnswer;
                    Answer4.Content = LoQ[qDecider].wrongAnswer3;
                }
                else if ((decider1 % 2) == 0 && (decider2 % 2) == 1)
                {
                    Answer1.Content = LoQ[qDecider].wrongAnswer1;
                    Answer2.Content = LoQ[qDecider].wrongAnswer2;
                    Answer3.Content = LoQ[qDecider].wrongAnswer3;
                    Answer4.Content = LoQ[qDecider].rightAnswer;
                }
            }
        }


        private void Answer1_Click(object sender, RoutedEventArgs e)
        {
            if ((string)Answer1.Content == LoQ[qDecider].rightAnswer)
            {
                ButtonContent();
            }
            else
            {
                frame.Navigate(new LossScreen(frame));
            }
        }

        private void Answer2_Click(object sender, RoutedEventArgs e)
        {
            if ((string)Answer2.Content == LoQ[qDecider].rightAnswer)
            {
                ButtonContent();
            }
            else
            {
                frame.Navigate(new LossScreen(frame));
            }
        }

        private void Answer3_Click(object sender, RoutedEventArgs e)
        {
            if ((string)Answer3.Content == LoQ[qDecider].rightAnswer)
            {
                ButtonContent();
            }
            else
            {
                frame.Navigate(new LossScreen(frame));

            }
        }

        private void Answer4_Click(object sender, RoutedEventArgs e)
        {
            if ((string)Answer4.Content == LoQ[qDecider].rightAnswer)
            {
                ButtonContent();
            }
            else
            {
                frame.Navigate(new LossScreen(frame));

            }
        }
    }
}
