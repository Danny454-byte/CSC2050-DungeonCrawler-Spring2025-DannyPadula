using UnityEngine;

public class hpBarController : MonoBehaviour
{
    // this.gameobject is the gameobject associated with the red hp bar

    private float timeChange = 0.0f;
    private Vector3 scaleChange = new Vector3(0.01f, 0.0f, 0.0f);
    private Vector3 leftMove = new Vector3(0.005f, 0.0f, 0.0f);

        void Start()
    {
        
    }

        void Update()
    {
        this.timeChange += Time.deltaTime;
        if(this.timeChange >= 0.5f)
        {
            this.timeChange = 0.0f;
            this.gameObject.transform.localScale -= this.scaleChange;
            this.gameObject.transform.localPosition -= this.leftMove;
        }
    }
}
