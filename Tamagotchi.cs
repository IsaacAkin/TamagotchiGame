namespace TamagotchiGame
{
    class Tamagotchi
    {
        public string? name;
        private int foodLevel = 5;
        private int tiredness = 0;
        private bool isAlive = true;
        private bool isAsleep = false;

        // Feeds the tamagotchi when the opion is chosen, increases food level and tiredness.
        public void FeedPet()
        {
            Console.WriteLine($"You fed {name}.");

            foodLevel++;
            tiredness++;

            if (foodLevel > 10)
            {
                Die();
            }
            else if (tiredness > 10)
            {
                Console.WriteLine($"{name} is tired.\n");
                isAsleep = true;
                GoToSleep();
            }

            Console.WriteLine("");

            if (isAlive == true)
            {
                GetFoodLevel();
                GetTiredness();
            }

        }

        // Puts the tamagotchi to sleep, decreases food level and tiredness.
        public void GoToSleep()
        {
            isAsleep = true;
            Console.WriteLine($"{name} went to sleep.");
            for (int i = 0; i < 3; i++)
            {
                Thread.Sleep(1000);
                Console.WriteLine("Zzz...");
                foodLevel--;
                if (foodLevel <= 0)
                {
                    Console.WriteLine($"{name} is very hungry.");
                    Die();
                }
            }
            isAsleep = false;
            tiredness = 0;

            Thread.Sleep(1000);
            Console.WriteLine("");

            if (isAlive == true)
            {
                GetFoodLevel();
                GetTiredness();
            }
        }

        // Plays with the tamagotchi, decreases food level and increases tiredness.
        public void PlayWithPet()
        {
            string[] activities = { "Go fetch!", "Do a flip!" };

            Console.WriteLine($"You play with {name}.");
            for (int i = 0; i < activities.Length; i++)
            {
                Thread.Sleep(1000);
                Console.WriteLine(activities[i]);
                foodLevel--;
                tiredness++;
                if (foodLevel <= 0)
                {
                    Console.WriteLine($"{name} is very hungry.");
                    Die();
                }
                else if (tiredness > 10)
                {
                    Console.WriteLine($"{name} is tired.\n");
                    isAsleep = true;
                    GoToSleep();
                }
            }

            Thread.Sleep(1000);
            Console.WriteLine("");

            if (isAlive == true)
            {
                GetFoodLevel();
                GetTiredness();
            }
        }

        // Checks if the tamagotchi is dead and prints the appropriate message.
        private void Die()
        {
            if (foodLevel <= 0 && isAsleep == true)
            {
                Console.WriteLine($"{name} died of hunger in their sleep");
                isAlive = false;
            }
            else if (foodLevel <= 0)
            {
                Console.WriteLine($"{name} died of starvation");
                isAlive = false;
            }
            else
            {
                Console.WriteLine($"{name} died of overeating");
            }
        }

        // Getters for foodLevel, tiredness and life status.
        public void GetFoodLevel()
        {
            Console.WriteLine($"{name}'s food level is: {foodLevel}");
        }

        public void GetTiredness()
        {
            Console.WriteLine($"{name}'s tiredness level is: {tiredness}");
        }

        public bool IsAlive()
        {
            return isAlive;
        }
    }
}
