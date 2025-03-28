using System;
using UnityEngine;

public class fightSceneManager : MonoBehaviour
{
    public GameObject player;
    public GameObject monster;

    private Monster theMonster;

    private float timeSinceLastTimeDeltaTime = 0.0f;

    private Fight theFight;

    private Vector3 playerStartPos;
    private Vector3 monsterStartPos;
    private Vector3 attackMove = new Vector3(1, 0, 0);

    private bool isPlayerTurn = true;

    
    void Start()
    {
        this.playerStartPos = this.player.transform.position;
        this.monsterStartPos = this.monster.transform.position;

        this.theMonster = new Monster("Goblin");
        this.theFight = new Fight(this.theMonster);
        print("Player AC: " + Core.thePlayer.getAC());
        print("Monster AC: " + this.theMonster.getAC());

        

    }
    void Update()
    {
        this.timeSinceLastTimeDeltaTime += Time.deltaTime;

        if(this.timeSinceLastTimeDeltaTime >= 0.5f)
        {
            
            if(!this.theFight.isFightOver())
            {
                
                this.theFight.takeASwing(this.player, this.monster);
            }
            else
            {
                Debug.Log("Fight is over");
            }
            this.timeSinceLastTimeDeltaTime = 0.0f;
        }
    }
}
