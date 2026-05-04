using System;
using System.Collections.Generic;

namespace StudentServiceCenter
{
    internal class Program
    {
        // Dictionary → StudentID , StudentName
        static Dictionary<int, string> students = new Dictionary<int, string>();

        // Queue → waiting students (store IDs)
        static Queue<int> serviceQueue = new Queue<int>();

        // Stack → served students (for undo)
        static Stack<int> servedStack = new Stack<int>();

        static void Main(string[] args)
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n--- Student Service Center ---");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Update Student");
                Console.WriteLine("3. Remove Student");
                Console.WriteLine("4. Show All Students");
                Console.WriteLine("5. Join Service Queue");
                Console.WriteLine("6. Serve Next Student");
                Console.WriteLine("7. Undo Last Service");
                Console.WriteLine("8. Show Queue");
                Console.WriteLine("9. Exit");

                Console.Write("Choose option: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddStudent();
                        break;

                    case 2:
                        UpdateStudent();
                        break;

                    case 3:
                        RemoveStudent();
                        break;

                    case 4:
                        ShowAllStudents();
                        break;

                    case 5:
                        JoinQueue();
                        break;

                    case 6:
                        ServeStudent();
                        break;

                    case 7:
                        UndoService();
                        break;

                    case 8:
                        ShowQueue();
                        break;

                    case 9:
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            }

            // Add new student
            static void AddStudent()
            {
                Console.Write("Enter Student ID: ");
                int id = int.Parse(Console.ReadLine());

                // Check if ID already exists
                if (students.ContainsKey(id))
                {
                    Console.WriteLine("Student ID already exists!");
                    return;
                }

                Console.Write("Enter Student Name: ");
                string name = Console.ReadLine();

                students.Add(id, name);

                Console.WriteLine("Student added successfully.");
            }

        }
    }
}