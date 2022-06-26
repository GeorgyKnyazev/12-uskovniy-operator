using System;

namespace _12_uskovniy_operator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int playerHealth = 1130;
            int playerStrikeDamage = 150;
            int lifeForSummoningOfSpirit = 100;
            int playerAndSpiritDamage = 300;
            int increasedHealthInRift = 200;
            int bossHealth = 950;
            int bossDamage = 230;
            int numberOfDeparturesInFult = 4;
            string userInput;
            bool isSpiritSummoned = false;

            Console.WriteLine("Начался бой");

            while (playerHealth > 0 && bossHealth >0 )
            {
                Console.WriteLine($"Жизни игрока: {playerHealth}, Жизни Босса: {bossHealth}, Вызван ли дух: {isSpiritSummoned}, Можно скрыться: {numberOfDeparturesInFult}" );
                Console.WriteLine("Выберите заклинание");
                Console.WriteLine($"1 - Удар (Наносит {playerAndSpiritDamage} ед. урона)");
                Console.WriteLine($"2 - Решамон (Призыв теневого духа. отнимает {lifeForSummoningOfSpirit} ед. здоровья игроку)");
                Console.WriteLine($"3 - Хуганзакура (Доступна после вызова духа. Наносит {playerAndSpiritDamage} ед. урона)");
                Console.WriteLine($"4 - Межпространственный разлом (Позволяет скрыться в разломе от урона противника и востановить {increasedHealthInRift} ед. здоровья.\n доступно: {numberOfDeparturesInFult}) ");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":                        
                            Console.WriteLine($"Вы нанесли {playerStrikeDamage} ед. урона Боссу. Босс вам нанес {bossDamage} ед. урона");
                            playerHealth -= bossDamage;
                            bossHealth -= playerStrikeDamage;
                            break;
                        
                    case "2":
                            if (isSpiritSummoned == false)
                            {
                                Console.WriteLine($"Вы призвали теневого духа из отдали за это {lifeForSummoningOfSpirit} ед. здоровья.\n Получили от Босса: {bossDamage} ед. урона ");
                                isSpiritSummoned = true;
                                playerHealth -= bossDamage;
                                playerHealth -= lifeForSummoningOfSpirit;
                            }
                            else
                            {
                                Console.WriteLine("Дух уже призван");
                            }
                            break;

                    case "3":
                            if (isSpiritSummoned == true)
                            {
                                Console.WriteLine($"Вы нанесли босу {playerAndSpiritDamage} ед. урона. Босс нанес вам {bossDamage} ед. урона.\n Призыв духа завершен.");
                                playerHealth -= bossDamage;
                                bossHealth -= playerAndSpiritDamage;
                            }
                            else 
                            {
                                Console.WriteLine("Вы не призвали духа.");
                            }
                            isSpiritSummoned = false;
                            break;
    
                    case "4":
                            if (numberOfDeparturesInFult > 0)
                            {
                                Console.WriteLine($"Вы спрятались в разломе и востановили жизнь на {increasedHealthInRift} ед. здоровья.");
                                playerHealth += increasedHealthInRift;
                                numberOfDeparturesInFult--;
                            }
                            break;
                }
                Console.Clear();
            }
            if (playerHealth <= 0 && bossHealth <= 0)
            {
                Console.WriteLine("Ничья");
            }
            else if (playerHealth <= 0)
            {
                Console.WriteLine("Игрок погиб");
            }
            else if (bossHealth <= 0)
            {
                Console.WriteLine("Вы выиграли. Босс погиб");
            }
        }
    }
}
