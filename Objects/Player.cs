using UnityEngine;

public class Player
{
    
    private string name;
    private Room currentRoom;

    public Player(string name)
    {
        this.name = name;
    }

    public void setCurrentRoom(Room r)
{
    this.currentRoom = r;
}
    
}
