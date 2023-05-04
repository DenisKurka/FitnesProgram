using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        int age = 0;
        double height = 0;
        double weight = 0;
        char gender = ' ';

        Console.Write("Welcome ! \n");
        Console.Write("This program will help you to create a presonal fitness program and also to protect the indicators to which you need to strive. \n");
        Console.Write(" \n");
        // Перевірка правильності віку
        do
        {
            Console.Write("Enter your age (from 1 to 100 years old): ");
            if (!int.TryParse(Console.ReadLine(), out age) || age < 1 || age > 100)
            {
                Console.WriteLine("Invalid input! Please enter a number between 1 and 100.");
            }
        } while (age < 1 || age > 100);

        // Перевірка правильності вводу зросту
        do
        {
            Console.Write("Enter your height in cm (from 100 to 240 cm): ");
            if (!double.TryParse(Console.ReadLine(), out height) || height < 100 || height > 240)
            {
                Console.WriteLine("Invalid input! Please enter a number from 100 to 240.");
            }
        } while (height < 100 || height > 240);

        // Перевірка правильності введення ваги
        do
        {
            Console.Write("Enter your weight in kg(from 40 to 120 kg): ");
            if (!double.TryParse(Console.ReadLine(), out weight) || weight < 40 || weight > 120)
            {
                Console.WriteLine("Invalid input! Please enter a number between 40 and 120.");
            }
        } while (weight < 40 || weight > 120);

        // Перевірка правильності введення статі
        do
        {
            Console.Write("Enter your gender (M/F): ");
            if (!char.TryParse(Console.ReadLine(), out gender) || (gender != 'м' && gender != 'ж'))
            {
                Console.WriteLine("Invalid input! Please enter 'M' for male or 'F' for female.");
            }
        } while (gender != 'м' && gender != 'ж');

        // Розрахунок здорових показників тіла
        double bmr = CalculateBMR(weight, height, age, gender);
        double bmi = CalculateBMI(weight, height);

        // Виведення результатів
        Console.WriteLine(" ");
        Console.WriteLine("Healthy body indicators:");
        Console.WriteLine("Basal metabolic rate(BMR) : {0} kcal / day", bmr);
        Console.WriteLine("Body mass index (BMS): {0:F1}", bmi);

        string[] workouts = { "Push-ups", "Squats", "Pull-ups", "Dumbbells", "Deadlift", "Press" };
        string[] additionalWorkouts = { "Strap", "Lunges", "Foot Press", "Lower Thigh Traction Unit", "Bicep Lift", "Upper Unit Traction" };

        int daysPerWeek = 3;
        int workoutsPerDay = 4;
        Random rnd = new Random();
        Console.WriteLine(" ");
        Console.WriteLine("Your training program: ");

        List<string> usedWorkouts = new List<string>();
        for (int i = 1; i <= daysPerWeek; i++)
        {
            Console.WriteLine("Day {0}:", i);
            for (int j = 1; j <= workoutsPerDay; j++)
            {
                string workout;
                do
                {
                    int workoutIndex = rnd.Next(workouts.Length + additionalWorkouts.Length);
                    if (workoutIndex < workouts.Length)
                    {
                        workout = workouts[workoutIndex];
                    }
                    else
                    {
                        workout = additionalWorkouts[workoutIndex - workouts.Length];
                    }
                } while (usedWorkouts.Contains(workout));

                usedWorkouts.Add(workout);
                Console.WriteLine("- {0}", workout);
            }
        }


        Console.ReadLine();
    }

    // Метод розрахунку основного обміну речовин (ООР)
    static double CalculateBMR(double weight, double height, int age, char gender)
    {
        double bmr = 0;
        if (gender == 'м')
        {
            bmr = 88.36 + (13.4 * weight) + (4.8 * height) - (5.7 * age);
        }
        else if (gender == 'ж')
        {
            bmr = 447.6 + (9.2 * weight) + (3.1 * height) - (4.3 * age);
        }
        return bmr;
    }

    // Метод розрахунку індексу маси тіла (ІМТ)
    static double CalculateBMI(double weight, double height)
    {
        double heightMeters = height / 100;
        return weight / (heightMeters * heightMeters);
    }
}
