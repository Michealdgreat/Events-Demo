using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {

            CollegeClassModel history = new CollegeClassModel("History 101", 3);
            CollegeClassModel math = new CollegeClassModel("Calculus", 2);

            history.EnrollmentFUll += CollegeClass_EnrollmentFUll;

            history.SignUpStudent("Micheal Shpdamola").PrinttoConsole();
            history.SignUpStudent("Sule Olawale").PrinttoConsole();
            history.SignUpStudent("Yemi Alonge").PrinttoConsole();
            history.SignUpStudent("Sule Olawale").PrinttoConsole();
            history.SignUpStudent("Yemi Alonge").PrinttoConsole();

            math.EnrollmentFUll += CollegeClass_EnrollmentFUll; 

            math.SignUpStudent("Micheal Shpdamola").PrinttoConsole();
            math.SignUpStudent("Sule Olawale").PrinttoConsole();
            math.SignUpStudent("Yemi Alonge").PrinttoConsole();
            Console.ReadLine();
        }

        private static void CollegeClass_EnrollmentFUll(object sender, string e)
        {

            CollegeClassModel model = (CollegeClassModel)sender;

            Console.WriteLine();
            Console.WriteLine(model.CourseTitile);
            Console.WriteLine($"{model.CourseTitile}: full");
            Console.WriteLine();
        }
    }

        public static class ConsoleHelpers
    {
        public static void PrinttoConsole(this string message)
        {
            Console.WriteLine(message);
        }
    }

        public class CollegeClassModel
        {

            public event EventHandler<string> EnrollmentFUll;

            private List<string> enrolledStudent = new List<string>();
            private List<string> waitingList = new List<string>();

            public string CourseTitile { get; set; }
            public int maximumStudents { get; set; }
            public CollegeClassModel(string title, int maximunStdents)
            {
                CourseTitile = title;
                maximumStudents = maximunStdents;
            }

            public string SignUpStudent(string studentName)
            {
                string output = "";

                if (enrolledStudent.Count < maximumStudents)
                {
                    enrolledStudent.Add(studentName);
                    output = $"{studentName} was enrolled in {CourseTitile}";

                // check to see if we are maxed out
                if (enrolledStudent.Count == maximumStudents)
                {
                    EnrollmentFUll?.Invoke(this, $"{CourseTitile} enrollment is now full.");

    }               }
                else
                {
                    waitingList.Add(studentName);
                    output = $"{studentName} was enrolled in {CourseTitile}";
                }

                return output ;
            }
        }
    }
