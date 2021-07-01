using UnityEngine;

public class ChangeOfGravity : MonoBehaviour
{
    [SerializeField] private float _directionGravityChange = -1;
        private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(typeof(Player), out Component component)){
            Physics.gravity = new Vector2(0, Physics.gravity.y * _directionGravityChange);
        }
    }
}
