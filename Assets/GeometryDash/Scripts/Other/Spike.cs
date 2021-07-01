
using UnityEngine;

public class Spike : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.GetComponent<Player>() != null){
            other.gameObject.GetComponent<Player>().SetBehaviorDead(); 
        }
    }
}
