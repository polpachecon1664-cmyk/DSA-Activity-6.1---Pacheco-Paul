using System;
using System.Collections.Generic;

class Program
{
    static Queue<string> jobs = new Queue<string>();
    static int finishedJobs = 0;

    static void Main()
    {
        Console.WriteLine("Welcome to my JOB SCHEDULING");

        int choice = 0;

        while (choice != 7)
        {
            Console.WriteLine("\nChoose what you want to do?");
            Console.WriteLine("1 - NEW JOB");
            Console.WriteLine("2 - FINISH JOB");
            Console.WriteLine("3 - SEARCH JOB");
            Console.WriteLine("4 - CURRENT JOB");
            Console.WriteLine("5 - DISPLAY ALL JOBS");
            Console.WriteLine("6 - COUNT JOBS");
            Console.WriteLine("7 - EXIT");
            Console.Write("Enter code: ");

            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input!");
                choice = 0;
                continue;
            }

            switch (choice)
            {
                case 1:
                    NewJob();
                    break;

                case 2:
                    FinishJob();
                    break;

                case 3:
                    SearchJob();
                    break;

                case 4:
                    CurrentJob();
                    break;

                case 5:
                    DisplayJobs();
                    break;

                case 6:
                    CountJobs();
                    break;

                case 7:
                    Console.WriteLine("Thank you for using JOB SCHEDULING!");
                    break;

                default:
                    Console.WriteLine("Invalid code!");
                    break;
            }
        }
    }

    static void NewJob()
    {
        Console.Write("\nEnter new job: ");
        string job = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(job))
        {
            Console.WriteLine("Job cannot be empty!");
            return;
        }

        jobs.Enqueue(job);
        Console.WriteLine("New job has been added!");
    }

    static void FinishJob()
    {
        if (jobs.Count == 0)
        {
            Console.WriteLine("No job to finish!");
            return;
        }

        jobs.Dequeue();
        finishedJobs++;

        Console.WriteLine(
            "\nThe current job has been marked FINISH.");
        Console.WriteLine(
            "Total number of finished job: " + finishedJobs);
    }

    static void SearchJob()
    {
        Console.Write("\nEnter job to be searched: ");
        string search = Console.ReadLine();

        bool found = false;

        foreach (string job in jobs)
        {
            if (job.Equals(search,
                StringComparison.OrdinalIgnoreCase))
            {
                found = true;
                break;
            }
        }

        if (found)
            Console.WriteLine("Job found!");
        else
            Console.WriteLine("Job not found!");
    }

    static void CurrentJob()
    {
        if (jobs.Count == 0)
        {
            Console.WriteLine("\nNo current job!");
            return;
        }

        Console.WriteLine("\nCurrent job: " + jobs.Peek());
    }

    static void DisplayJobs()
    {
        if (jobs.Count == 0)
        {
            Console.WriteLine("\nNo jobs on the schedule!");
            return;
        }

        Console.WriteLine("\nList of all jobs:");

        int number = 1;

        foreach (string job in jobs)
        {
            Console.WriteLine(number + ". " + job);
            number++;
        }
    }

    static void CountJobs()
    {
        Console.WriteLine(
            "\nNumber of jobs on the schedule: " + jobs.Count);
    }
}
