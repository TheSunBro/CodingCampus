using System;
using System.Security.Cryptography.X509Certificates;

namespace TrollyRoboter
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isRunning = true;
            Field startField = new Field(1, FieldType.STARTFIELD);
            Field a2 = new Field(2);
            Field a3 = new Field(3);
            Field a4 = new Field(4);
            Field a5 = new Field(5);
            Field a6 = new Field(6);
            Field a7 = new Field(7);
            Field a8 = new Field(8);
            Field a9 = new Field(9);
            Field a10 = new Field(10);
            Field a11 = new Field(11);
            Field a12 = new Field(12);
            Field a13 = new Field(13);
            Field a14 = new Field(14);
            Field a15 = new Field(15);
            Field a16 = new Field(16);
            Field a17 = new Field(17);
            Field a18 = new Field(18);
            Field a19 = new Field(19);
            Field a20 = new Field(20, FieldType.CHARGING_FIELD);
            Field a21 = new Field(21);
            Field a22 = new Field(22);
            Field a23 = new Field(23);
            Field a24 = new Field(24);

            GameManager gameManager = new GameManager();

            startField.LinkFields(a2, MovingType.EAST);
            a2.LinkFields(a3, MovingType.EAST);
            a3.LinkFields(a4, MovingType.SOUTH);
            a4.LinkFields(a5, MovingType.SOUTH);
            a4.LinkFields(a7, MovingType.EAST);
            a5.LinkFields(a6, MovingType.EAST);
            a6.LinkFields(a7, MovingType.NORTH);
            a7.LinkFields(a8, MovingType.NORTH);
            a7.LinkFields(a10, MovingType.EAST);
            a8.LinkFields(a9, MovingType.EAST);
            a9.LinkFields(a10, MovingType.SOUTH);
            a10.LinkFields(a11, MovingType.EAST);
            a11.LinkFields(a12, MovingType.SOUTH);
            a12.LinkFields(a13, MovingType.EAST);
            a13.LinkFields(a14, MovingType.EAST);
            a14.LinkFields(a15, MovingType.SOUTH);
            a15.LinkFields(a16, MovingType.SOUTH);
            a15.LinkFields(a18, MovingType.EAST);
            a16.LinkFields(a17, MovingType.EAST);
            a17.LinkFields(a18, MovingType.NORTH);
            a18.LinkFields(a19, MovingType.EAST);
            a19.LinkFields(a20, MovingType.NORTH);

            Robot trolly = new Robot(1,"Trolly", startField, 5, 200);
            Robot r2d2 = new Robot(2, "R2D2", startField, 3, 150);
            Robot c3Po = new Robot(3, "C3PO", startField, 2, 300);
            gameManager.AddRobotToList(trolly);
            gameManager.AddRobotToList(r2d2);
            gameManager.AddRobotToList(c3Po);
            gameManager.PrintMenu();

            Console.WriteLine($"Press {trolly.id} for {trolly.name}");
            Console.WriteLine($"Press {r2d2.id} for {r2d2.name}");
            Console.WriteLine($"Press {c3Po.id} for {c3Po.name}");

            int userInput = int.Parse(Console.ReadLine());
            bool isValid = false;
            while(!isValid)
            {
                switch (userInput)
                {
                    case 1:
                        gameManager.currentRobot = trolly;
                        isValid = true;
                        break;

                    case 2:
                        gameManager.currentRobot = r2d2;
                        isValid = true;
                        break;
                        
                    case 3:
                        gameManager.currentRobot = c3Po;
                        isValid = true;
                        break;

                    default:
                        Console.WriteLine("Incorrect Input");
                        isValid = false;
                        break;
                }
            }
            Console.WriteLine($"You have chosen {gameManager.currentRobot.name}. Very wisely");
            Console.WriteLine($"{gameManager.currentRobot.name} is on {gameManager.currentRobot.position.fieldType}");
            Console.WriteLine();
            while (isRunning)
            {
                Console.WriteLine();
                Console.WriteLine("Choose Direction you want to move");
                Console.WriteLine($"[W] UP\n[S] DOWN\n[A] LEFT\n[D] RIGHT");
                string userControl = Console.ReadLine();
                switch (userControl)
                {
                    case "w":
                        gameManager.currentRobot.Move(MovingType.NORTH);
                        gameManager.PrintGameStatus();
                        break;
                    case "s":
                        gameManager.currentRobot.Move(MovingType.SOUTH);
                        gameManager.PrintGameStatus();
                        break;
                    case "a":
                        gameManager.currentRobot.Move(MovingType.WEST);
                        gameManager.PrintGameStatus();
                        break;
                    case "d":
                        gameManager.currentRobot.Move(MovingType.EAST);
                        gameManager.PrintGameStatus();
                        break;
                    default:
                        Console.WriteLine("Incorrect Input.");
                        break;
                }   
            }   
        }
    }
}
