using UnityEngine;

public class Springboard : MonoBehaviour
{
    private float _volume = 500f;
   private void OnTriggerEnter(Collider other)
   {
       if(other.gameObject.TryGetComponent(typeof(Player), out Component component)){
            PlayerData._singleton._jumpForse += _volume;
            PlayerData._singleton._doJump = true;
       }
   }
}
