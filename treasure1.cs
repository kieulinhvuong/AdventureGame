using System;

namespace asciiadventure
{
    public class Treasure1 : MovingGameObject
    {
        public Treasure1(int row, int col, Screen screen) : base(row, col, "T", screen) { }
        public override Boolean IsPassable()
        {
            return true;
        }

        public string Move(int deltaRow, int deltaCol)
        {
            int newRow = deltaRow + Row;
            int newCol = deltaCol + Col;
            if (!Screen.IsInBounds(newRow, newCol))
            {
                return "";
            }
            GameObject gameObject = Screen[newRow, newCol];
            if (gameObject != null && !gameObject.IsPassable())
            {
                GameObject other = Screen[newRow, newCol];
                if (other == null)
                {
                    return "negative";
                }
                // TODO: Interact with the object

                return "ouch";
                // TODO: How to handle other objects?
                // walls just stop you
                // objects can be picked up
                // people can be interactd with
                // also, when you move, some things may also move
                // maybe i,j,k,l can attack in different directions?
                // can have a "shout" command, so some objects require shouting
                //return "TODO: Handle interaction";
            }
            // Now just make the move
            int originalRow = Row;
            int originalCol = Col;
            // now change the location of the object, if the move was legal
            Row = newRow;
            Col = newCol;
            Screen[originalRow, originalCol] = null;
            Screen[Row, Col] = this;
            return "";
        }
    }
}