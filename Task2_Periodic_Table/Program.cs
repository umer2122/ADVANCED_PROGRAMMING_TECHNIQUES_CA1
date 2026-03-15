using System;
using System.Collections.Generic;

namespace Que2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Dictionary to store first 30 elements
            Dictionary<int, (string Name, string Class, string Info)> elements =
                new Dictionary<int, (string, string, string)>
            {
                {1, ("Hydrogen", "Nonmetal", "Hydrogen is the lightest element.")},
                {2, ("Helium", "Noble Gas", "Helium is inert and used in balloons.")},
                {3, ("Lithium", "Alkali Metal", "Lithium is used in batteries.")},
                {4, ("Beryllium", "Alkaline Earth Metal", "Beryllium is hard and toxic.")},
                {5, ("Boron", "Metalloid", "Boron is used in glass and detergents.")},
                {6, ("Carbon", "Nonmetal", "Carbon forms many compounds, e.g., diamond, graphite.")},
                {7, ("Nitrogen", "Nonmetal", "Nitrogen makes up 78% of Earth's atmosphere.")},
                {8, ("Oxygen", "Nonmetal", "Oxygen is essential for respiration.")},
                {9, ("Fluorine", "Halogen", "Fluorine is highly reactive.")},
                {10, ("Neon", "Noble Gas", "Neon is used in signs and lights.")},
                {11, ("Sodium", "Alkali Metal", "Sodium is reactive with water.")},
                {12, ("Magnesium", "Alkaline Earth Metal", "Magnesium burns with bright light.")},
                {13, ("Aluminium", "Post-transition Metal", "Aluminium is lightweight and corrosion-resistant.")},
                {14, ("Silicon", "Metalloid", "Silicon is used in electronics.")},
                {15, ("Phosphorus", "Nonmetal", "Phosphorus is used in fertilizers.")},
                {16, ("Sulfur", "Nonmetal", "Sulfur is used in matches and chemicals.")},
                {17, ("Chlorine", "Halogen", "Chlorine is used in disinfectants.")},
                {18, ("Argon", "Noble Gas", "Argon is inert and used in lighting.")},
                {19, ("Potassium", "Alkali Metal", "Potassium reacts violently with water.")},
                {20, ("Calcium", "Alkaline Earth Metal", "Calcium is important for bones.")},
                {21, ("Scandium", "Transition Metal", "Scandium is a rare metal.")},
                {22, ("Titanium", "Transition Metal", "Titanium is strong and corrosion-resistant.")},
                {23, ("Vanadium", "Transition Metal", "Vanadium is used in steel alloys.")},
                {24, ("Chromium", "Transition Metal", "Chromium gives color to compounds.")},
                {25, ("Manganese", "Transition Metal", "Manganese is used in steel production.")},
                {26, ("Iron", "Transition Metal", "Iron is essential for hemoglobin.")},
                {27, ("Cobalt", "Transition Metal", "Cobalt is used in batteries and alloys.")},
                {28, ("Nickel", "Transition Metal", "Nickel is corrosion-resistant.")},
                {29, ("Copper", "Transition Metal", "Copper conducts electricity well.")},
                {30, ("Zinc", "Transition Metal", "Zinc is used in galvanization.")}
            };

            Console.WriteLine("Hi there! Happy to help!");

            bool keepGoing = true;

            while (keepGoing)
            {
                Console.Write("Provide atomic number of the element (1-30): ");
                string input = Console.ReadLine();
                if (!int.TryParse(input, out int atomicNumber) || atomicNumber < 1 || atomicNumber > 30)
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 30.");
                    continue;
                }

                var element = elements[atomicNumber];
                Console.WriteLine($"\nAtomic Number: {atomicNumber}");
                Console.WriteLine($"Name: {element.Name}");
                Console.WriteLine($"Class: {element.Class}");
                Console.WriteLine($"Info: {element.Info}\n");

                Console.Write("Do you want to know more elements [y/n]? ");
                string choice = Console.ReadLine();
                if (choice.ToLower() != "y")
                {
                    keepGoing = false;
                    Console.WriteLine("Thanks!");
                }
            }
        }
    }
}