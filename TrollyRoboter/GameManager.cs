using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace TrollyRoboter
{
    class GameManager
    {
        //public Field field;
        public List<Robot> robotList = new List<Robot>();
        public Robot currentRobot;
        public void AddRobotToList(Robot robot)
        {
            robotList.Add(robot);
        }
        public void RemoveRobotFromList(Robot robot)
        {
            robotList.Remove(robot);
        }

        public void PrintMenu()
        {
            Console.WriteLine("\t" + "Choose Your robot");
            Console.WriteLine("----------------------------------");
            foreach (Robot robot in this.robotList)
            {
                //Console.WriteLine("______________________________");
                Console.WriteLine($"Name: {robot.name} \nMax Packages: {robot.maxLoad} \nBattery Capacity {robot.batteryLife}");
                Console.WriteLine("______________________________");
            }
        }
        public void PrintGameStatus()
        {
            Console.WriteLine("-----------------------------------------------------------");
            if (currentRobot.position.fieldType == FieldType.STARTFIELD || currentRobot.position.fieldType == FieldType.CHARGING_FIELD)
            {
                Console.WriteLine($"{currentRobot.name} is on {currentRobot.position.fieldType}. He has unloaded all packages and fully recharged Battery");
            }
            Console.WriteLine($"{currentRobot.name} is on Field: {currentRobot.position.id} \nBattery Life: {currentRobot.batteryLife}");
            Console.WriteLine();
            if (currentRobot.hasFoundPackage)
            {
                Console.WriteLine($"Package found on Field {currentRobot.position.id}");
            }
            Console.WriteLine($"{currentRobot.name} has loaded {currentRobot.packagesLoaded.Count}/{currentRobot.maxLoad} packages");
           
            if (currentRobot.packagesLoaded.Count == currentRobot.maxLoad)
            {
                Console.WriteLine($"Cant load more packages. Go to {FieldType.STARTFIELD} to unload packages");
            }
            Console.Write("Visited Fields:");
            foreach (Field field in currentRobot.visitedFields)
            {
                Console.Write(" " + field.id);
            }
            Console.WriteLine();
            Console.WriteLine($"Packages to Collect: {Package.CountPackages}");
            if(Package.CountPackages == 0)
            {
                Console.WriteLine($"Congrats! {currentRobot.name} has Collected all packages");
            }
        }
    }
}
