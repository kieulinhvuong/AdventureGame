asciiadventure
===
Ascii adventure in C#

## Game files
* [screen.cs](screen.cs)
* [adventure.cs](adventure.cs)
* [gameobjects.cs](gameobjects.cs)
* [player.cs](player.cs)
* [mob.cs](mob.cs)



### Challenges
* Not the greatest class hierarchy
* Mobs can only move when the player moves. There's no timer in the background.
* Not possible for moving gameobjs to move over objects with replacing them
* Really clunky menu options
* Not great MVC for display; the Screen is essentially everything
    * Need to draw moving gameobjs over the top of the underlying stuff
    * Two layers? Basic stuff, plus moving things?
* Not well set up to have multiple screens connected by portals, or something

### Other notes
* Screen is one screen, with numRows and numCols
    * 
* GameObject is an object in the game.
    * Owned by Screen, and does not need to know about screen
    * Some GameObjects include Wall and Treasure
    * Is passable? If it's passable, you can walk over it.
* MovingGameObject extends GameObject, but adds movement as a possibility.
    * Knows about Screen
    * needs to ask Screen about legal moves

### Features added
* Jumping feature
    * Added 4 new functions for keys 't', 'f', 'g', 'h'. By pressing one of the keys, the player can move three steps at a time. 
    * Key 't': up
    * Key 'g': down
    * Key 'f': left
    * Key 'j': right
* Treasure1 
    * Added another MovingGameObject named treasure1, represented by 'T', which is the same as the original treasure to confuse the mob
    * treasure1 is passable, but it can only be eaten by the player, not the mob
    * treasure1 can move 1 step by pressing one of the keys 'i', 'j', 'k', 'l'
    * Key 'i': up
    * Key 'k': down
    * Key 'j': left
    * Key 'l': right
* Change screen color randomly 
    * Change the screen color by pressing key 'c'
* Heart 
    * Added a new GameObject named heart, represented by H. H cannot move
    * heart is passable. It can be eaten by the player and the mob
    * heart is the extra life for the player, if the player eats the heart, it wins. 
* Exit screen 
    * Press key 'e' to clear the screen and start over
    


