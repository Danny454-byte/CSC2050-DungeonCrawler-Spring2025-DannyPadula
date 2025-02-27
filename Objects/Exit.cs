using UnityEngine;

public class Exit 
{
private string direction;
Room destination; 
public Exit(string direction, Room destination)
{
this.direction = direction;
this.destination = destination; 
}
}
