using System;

namespace asciiadventure
{
    class Player : MovingGameObject
    {
        public Player(int row, int col, Screen screen, string name) : base(row, col, "@", screen)
        {
            Name = name;
        }
        //create IsHeart to check whether the player is having the heart 
        static bool IsHeart = false;
        public string Name
        {
            get;
            protected set;
        }
        public override Boolean IsPassable()
        {
            return true;
        }

        public String Action(int deltaRow, int deltaCol)
        {
            int newRow = Row + deltaRow;
            int newCol = Col + deltaCol;
            if (!Screen.IsInBounds(newRow, newCol))
            {
                return "nope";
            }
            GameObject other = Screen[newRow, newCol];
            if (other == null)
            {
                return "negative";
            }
            // TODO: Interact with the object
            if (other is Treasure)
            {
                other.Delete();
                return "Yay, we got the treasure!";
            }
            if (other is Treasure1)
            {
                other.Delete();
                return "Yay, we got the treasure!";
            }
            if (other is Heart)
            {
                other.Delete();
                Player.IsHeart = true;
                return "You have the heart!";
            }
            return "ouch";
        }
    }
}