using System.Collections.Generic;

namespace TrollyRoboter
{
    class Robot
    {
        public bool hasFoundPackage;
        public int id;
        public int batteryLife;
        public const int BATTERY_DRAIN = 10;
        public int maxLoad;
        public int maxBatteryLoad;
        public string name;
        public Field position; // Durch den Datentyp "Field" kann die Variable "positon" in der Klasse "Robot" auf die Methoden und Attribute vom Datentyp "Field" zugreifen
        public List<Package> packagesLoaded = new List<Package>();
        public List<Field> visitedFields = new List<Field>();
        public Robot(int id, string name, Field position, int maxLoad, int batteryLife)
        {
            this.id = id;
            this.name = name;
            this.position = position;
            this.maxLoad = maxLoad;
            this.batteryLife = batteryLife;
            this.maxBatteryLoad = batteryLife;
        }
        public bool Move(MovingType direction)
        {
            if(batteryLife <= 0)
            {
                System.Console.WriteLine("BATTERY EMPTY");
                return false;
            }
            if (position.CanMoveToDirection(direction))
            {
                this.position = position.GetFieldInDirection(direction);
                Scan();
                LoadPackage();
                UnloadPackage();
                batteryLife -= BATTERY_DRAIN;
                ChargeBattery();
                if (!visitedFields.Contains(position))
                {
                    visitedFields.Add(position);
                }
                return true;
            }else
            {
                System.Console.WriteLine("CANT MOVE TO DIRECTION");
                return false;
            }
        }
        public void LoadPackage()
        {
            if(hasFoundPackage && packagesLoaded.Count < maxLoad && position.fieldType != FieldType.STARTFIELD)
            {
                packagesLoaded.Add(position.package);
                position.package = null;
                Package.CountPackages--;
            }
        }
        public void UnloadPackage()
        {
            if(position.fieldType == FieldType.STARTFIELD)
            {
                packagesLoaded.Clear(); 
            }
        }
        public void ChargeBattery()
        {
            if(position.fieldType == FieldType.STARTFIELD || position.fieldType == FieldType.CHARGING_FIELD)
            {
                this.batteryLife = this.maxBatteryLoad;
            }
        }
        public bool Scan()
        {
            if (position.package != null)
            {
                return this.hasFoundPackage = true;
            }
            return this.hasFoundPackage = false;
        }
    }
}
