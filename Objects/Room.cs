using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Room
{
    private Player thePlayer;

    private GameObject[] theDoors;
    private Exit[] availableExits = new Exit[4];
    private int currNumberOfExits = 0;

    private bool hasPlayerBeenHere;

    private string name;

    public Room(string name)
    {
        this.name = name;
        this.thePlayer = null;
        this.hasPlayerBeenHere = false;
    }

    public bool getHasPlayerBeenHere()
    {
        return this.hasPlayerBeenHere;
    }

    public Player getPlayer()
    {
        return this.thePlayer;
}
    public string getName()
    {
        return this.name;
    }

    public bool tryToTakeExit(string direction)
    {
        Exit theExit = this.getExit(direction);
        if(theExit != null)
        {
            
            Core.thePlayer.getCurrentRoom().removePlayer();

            
            Room destinationRoom = theExit.getDestination();
            destinationRoom.setPlayer(Core.thePlayer);
            
            
            return true;
        }
        else
        {
            Debug.Log("No Exit In This Direction");
            return false;
        }
    }

    private Exit getExit(string direction)
    {
        if(this.hasExit(direction))
        {
            for(int i = 0; i < this.currNumberOfExits; i++)
            {
                if(String.Equals(this.availableExits[i].getDirection(), direction))
                {
                    return this.availableExits[i];
                }
            }
        }
        return null;
    }

    public bool hasExit(string direction)
    {
        for(int i = 0; i < this.currNumberOfExits; i++)
        {
            if(String.Equals(this.availableExits[i].getDirection(), direction))
            {
                return true;
            }
        }
        return false;
    }

    public void removePlayer()
    {
        this.thePlayer = null;
        this.hasPlayerBeenHere = true;
    }

    public void setPlayer(Player p)
    {
        this.thePlayer = p;
        this.thePlayer.setCurrentRoom(this);
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
            Console.Error.WriteLine("there are too many exits!!!!");
        }
    }

}
