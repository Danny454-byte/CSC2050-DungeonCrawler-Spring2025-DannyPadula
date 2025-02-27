using System;
using UnityEngine;

public class Room 
{
    private Player thePlayer;
    private GameObject[] theDoors;
    private Exit[] availableExits = new Exit[4];
private int currNumberOfExits = 0;
    private string name;
    public Room(string name)
    {
        this.name = name;
        this.thePlayer = null;
    }
    public void setPlayer(Player p)
{
    this.thePlayer = p;
}

    public void addExit(string direction, Room destination)
    {
        if(this.currNumberOfExits <= 3)
        {
            Exit e = new Exit(direction, destination);
            this.availableExits[this.currNumberOfExits] = e;
            this.currNumberOfExits++;
        }
        else
        {
          Console.Error.WriteLine ("there are too many exits!!!!");
        }
    }
}
