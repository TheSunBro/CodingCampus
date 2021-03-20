using System;
using System.Collections.Generic;
using System.Text;

namespace TrollyRoboter
{
    class Field
    {
        public int id;
        public Field north;
        public Field east;
        public Field south;
        public Field west;
        public Package package;
        public FieldType fieldType = FieldType.NORMAL_FIELD;

        public Field(int id)
        {
            this.id = id;
            GetRandomParcel(); // bei jedem neuen Feld ein wird ein Paket zufällig erstellt
        }
        public Field(int id, FieldType fieldType)
        {
            this.fieldType = fieldType;
            this.id = id;
            
        }
        public Field GetFieldInDirection(MovingType direction) // Verknüpfung der Attribute east, north, west und south des Datentyp "Field" und vom Datentyp Enum Moving Type 
        {
            if (direction == MovingType.NORTH)
            {
                return north;
            }
            if (direction == MovingType.EAST)
            {
                return east;
            }
            if (direction == MovingType.SOUTH)
            {
                return south;
            }
            return west;
        }
        public bool CanMoveToDirection(MovingType direction) // Funktion ob man sich in die Richtung bewegen kann
        {
            Field fieldToMoveTo = GetFieldInDirection(direction);
            return fieldToMoveTo != null;                           // return true, wenn es nicht null ist. Die Variable "fieldToMoveTo" vom Typ "Field" wird true dh. Robot kann auf dieses Feld.
        }
        public void LinkFields(Field field, MovingType direction) // gegenseitige Verknüpfung von Feldern
        {
            switch (direction)
            {
                case MovingType.EAST:
                    field.west = this;
                    east = field;
                    break;
                case MovingType.NORTH:
                    field.south = this;
                    north = field;
                    break;
                case MovingType.SOUTH:
                    field.north = this;
                    south = field;
                    break;
                case MovingType.WEST:
                    field.east = this;
                    west = field;
                    break;
            }
        }
        public void GetRandomParcel() //Zufälliges Paket erstellen
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 2);
            if (randomNumber == 0)
            {
                Package package = new Package();
                this.package = package;
                Package.CountPackages++;
            }
        }
    }
}
