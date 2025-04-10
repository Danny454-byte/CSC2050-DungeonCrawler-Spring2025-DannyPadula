using UnityEngine;

public class hpBarController : MonoBehaviour
{
    
    public bool isPlayer;

    private Inhabitant theInhabitant;

        void Start()
    {

        if(this.isPlayer)
        {
            this.theInhabitant = Core.thePlayer;
            print("********** SET THE PLAYER" + this.theInhabitant.getName());
        }
        else
        {
            this.theInhabitant = Core.theMonster;
            
            print("********** SET THE MONSTER" + this.theInhabitant.getName());

        }
    }

    
    void LateUpdate()
    {
        if(this.theInhabitant != null)
        {
            print(this.theInhabitant.getName());
            float hpPercent = (float)this.theInhabitant.getCurrHp() / (float)this.theInhabitant.getMaxHp();
            this.gameObject.transform.localScale = new Vector3(hpPercent, 
                                                this.gameObject.transform.localScale.y, 
                                                this.gameObject.transform.localScale.z);
        }
        
    }
}