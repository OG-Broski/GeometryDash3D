using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalToFly : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(typeof(Player), out Component component)){
            other.gameObject.GetComponent<Player>().SetBehaviorFly();
        }
    }
}
