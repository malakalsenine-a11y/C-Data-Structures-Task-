using System;
using System.Collections.Generic;

namespace StudentServiceCenter
{
    internal class Program
    {
        //1. Student Registration (Dictionary)
  

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

            // Update existing student name
            static void UpdateStudent()
            {
                Console.Write("Enter Student ID to update: ");
                int id = int.Parse(Console.ReadLine());

                // Check if student exists
                if (!students.ContainsKey(id))
                {
                    Console.WriteLine("Student not found!");
                    return;
                }

                Console.Write("Enter new name: ");
                string newName = Console.ReadLine();

                // Update value
                students[id] = newName;

                Console.WriteLine("Student updated successfully.");
            }

            // Remove student from Dictionary
            static void RemoveStudent()
            {
                Console.Write("Enter Student ID to remove: ");
                int id = int.Parse(Console.ReadLine());

                // Check if student exists
                if (!students.ContainsKey(id))
                {
                    Console.WriteLine("Student not found!");
                    return;
                }

                students.Remove(id);

                Console.WriteLine("Student removed successfully.");
            }

            // Display all students
            static void ShowAllStudents()
            {
                if (students.Count == 0)
                {
                    Console.WriteLine("No students found.");
                    return;
                }

                Console.WriteLine("\n--- Students List ---");

                foreach (var student in students)
                {
                    Console.WriteLine($"ID: {student.Key}, Name: {student.Value}");
                }
            }

            //2. Service Waiting Line (Queue)

            // Add student to service queue
            static void JoinQueue()
            {
                Console.Write("Enter Student ID to join queue: ");
                int id = int.Parse(Console.ReadLine());

                // Check if student exists
                if (!students.ContainsKey(id))
                {
                    Console.WriteLine("Student not found!");
                    return;
                }

                serviceQueue.Enqueue(id);

                Console.WriteLine($"{students[id]} added to the queue.");
            }

            // Serve next student
            static void ServeStudent()
            {
                if (serviceQueue.Count == 0)
                {
                    Console.WriteLine("No students in queue.");
                    return;
                }

                int servedId = serviceQueue.Dequeue();

                // Push to stack for undo
                servedStack.Push(servedId);

                Console.WriteLine($"{students[servedId]} has been served.");
            }

            // Display all students in queue
            static void ShowQueue()
            {
                if (serviceQueue.Count == 0)
                {
                    Console.WriteLine("Queue is empty.");
                    return;
                }

                Console.WriteLine("\n--- Waiting Queue ---");

                foreach (int id in serviceQueue)
                {
                    Console.WriteLine($"ID: {id}, Name: {students[id]}");
                }

                Console.WriteLine($"Total in queue: {serviceQueue.Count}");
            }

        }
    }
}