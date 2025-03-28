using Unity.VisualScripting;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public GameObject[] theDoors;
    public GameObject mmRoomPrefab;
    private Dungeon theDungeon;

    private Vector3 mmCurrPos;

    
    void Start()
    {
        this.theDungeon = new Dungeon();
        this.setupRoom();
        this.mmCurrPos = Core.mmStartPos;
    }

    
    private void resetRoom()
    {
        this.theDoors[0].SetActive(false);
        this.theDoors[1].SetActive(false);
        this.theDoors[2].SetActive(false);
        this.theDoors[3].SetActive(false);
    }

    
    private void setupRoom()
    {
        Room currentRoom = Core.thePlayer.getCurrentRoom();
        this.theDoors[0].SetActive(currentRoom.hasExit("north"));
        this.theDoors[1].SetActive(currentRoom.hasExit("south"));
        this.theDoors[2].SetActive(currentRoom.hasExit("east"));
        this.theDoors[3].SetActive(currentRoom.hasExit("west"));
    }

    
    void Update()
    {
        bool didChangeRoom = false;
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            
            didChangeRoom = Core.thePlayer.getCurrentRoom().tryToTakeExit("north");
            if(didChangeRoom)
            {
                this.mmCurrPos.z = this.mmCurrPos.z + 1.2f;
                if(!Core.thePlayer.getCurrentRoom().getHasPlayerBeenHere())
                {
                    GameObject newMMRoom = Instantiate(this.mmRoomPrefab);
                    newMMRoom.transform.position = this.mmCurrPos;
                }  
            }   
        }
        else if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            
            didChangeRoom = Core.thePlayer.getCurrentRoom().tryToTakeExit("west");
            if(didChangeRoom)
            {
                this.mmCurrPos.x = this.mmCurrPos.x - 1.2f;
                if(!Core.thePlayer.getCurrentRoom().getHasPlayerBeenHere())
                {
                    GameObject newMMRoom = Instantiate(this.mmRoomPrefab);
                    newMMRoom.transform.position = this.mmCurrPos;
                }
            }   
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            
            didChangeRoom = Core.thePlayer.getCurrentRoom().tryToTakeExit("east");
            if(didChangeRoom)
            {
                this.mmCurrPos.x = this.mmCurrPos.x + 1.2f;
                if(!Core.thePlayer.getCurrentRoom().getHasPlayerBeenHere())
                {
                    GameObject newMMRoom = Instantiate(this.mmRoomPrefab); 
                    newMMRoom.transform.position = this.mmCurrPos;
                }
                
            }   

        }
        else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            
            didChangeRoom = Core.thePlayer.getCurrentRoom().tryToTakeExit("south");
            if(didChangeRoom)
            {
                this.mmCurrPos.z = this.mmCurrPos.z - 1.2f;
                if(!Core.thePlayer.getCurrentRoom().getHasPlayerBeenHere())
                {
                    GameObject newMMRoom = Instantiate(this.mmRoomPrefab);
                    newMMRoom.transform.position = this.mmCurrPos;
                }   
            }   
        }

       
        if(didChangeRoom)
        {
            this.setupRoom();
        }
    }
}