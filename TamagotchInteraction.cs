namespace TamagotchiGame
{
    class TamagotchInteraction
    {
        static void Main(string[] args)
        {
            /// The entry point of the Tamagotchi game application.
            /// Initializes a new Tamagotchi, gets its name from the user, and runs the game loop where the user can choose actions to keep the Tamagotchi alive.
            /// The game continues until the Tamagotchi survives 10 rounds or dies.

            Tamagotchi tamagotchi = new Tamagotchi();

            tamagotchi.name = GetTamagotchiName();

            int roundsSurvived = 0;

            // Actual game logic 
            Console.WriteLine($"\nWelcome to Tamagotchi! You must survive 10 rounds to win!");
            do
            {
                PrintMenu(tamagotchi.name);
                int action = GetUserChoice();

                switch (action)
                {
                    case 1:
                        tamagotchi.FeedPet();
                        break;

                    case 2:
                        tamagotchi.PlayWithPet();
                        break;

                    case 3:
                        tamagotchi.GoToSleep();
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        break;
                }

                if (tamagotchi.IsAlive())
                {
                    roundsSurvived++;
                    Console.WriteLine($"Rounds survived: {roundsSurvived}\n");
                }
            } while (tamagotchi.IsAlive() && roundsSurvived != 10);


            // Checks if the tamagotchi is alive after the loop ends and displays the appropriate message.
            if (tamagotchi.IsAlive())
            {
                Console.WriteLine($"Congratulations! You kept {tamagotchi.name} alive for 10 rounds!");
                Console.WriteLine("You Win");
            }
            else
            {
                Console.WriteLine($"You neglected {tamagotchi.name} and now she's gone forever.");
            }


            // Gets the user's choice of action, ensuring it's a valid number.
            int GetUserChoice()
            {
                int userChoice = -1;
                do
                {
                    Console.WriteLine("Enter your choice: ");
                    try
                    {
                        string? userInput = Console.ReadLine();
                        userChoice = int.Parse(userInput);
                    }
                    catch
                    {
                        Console.WriteLine("Invalid number.");
                    }
                } while (userChoice < 1 || userChoice > 3);

                return userChoice;
            }

            // Gets the name of the tamagotchi from the user, ensuring it's not empty or null.
            string GetTamagotchiName()
            {
                string? tamagotchiName = "";
                do
                {
                    Console.WriteLine("What do you want to name your tamagotchi?");
                    try
                    {
                        string? userInput = Console.ReadLine();
                        tamagotchiName = userInput;
                    }
                    catch
                    {
                        Console.WriteLine("The name cannot be empty. Please enter a valid name.");
                    }
                } while (string.IsNullOrWhiteSpace(tamagotchiName));

                return tamagotchiName;
            }
        }

        // Prints the menu for the user to choose an action.
        static void PrintMenu(string tamagotchiName)
        {
            Console.WriteLine($"1. Feed {tamagotchiName}");
            Console.WriteLine($"2. Play with {tamagotchiName}");
            Console.WriteLine($"3. Put {tamagotchiName} to sleep");
            Console.WriteLine("Choose an action (1-3):");
        }
    }
}