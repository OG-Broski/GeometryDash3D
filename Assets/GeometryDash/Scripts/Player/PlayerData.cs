
using UnityEngine;

public class PlayerData :MonoBehaviour
{
    public static PlayerData _singleton {get;private set;}
    

    public float _jumpForse = 0;
    [SerializeField] public  bool _isJumping = false; 
    [SerializeField] public  bool _doJump = false;

    
    public readonly float _minJumpForse = 500f;
    [SerializeField] public  float _moveSpeed = 3f;
    [SerializeField] public readonly float _fallMultiplier = 2.5f;
    [SerializeField] public  readonly float _lowjumpMultiplier = 2f;
    [SerializeField] public readonly  float _rotateSpeed = 4f;
    [SerializeField] public readonly float _rotateAngle = 90f;
    
    [SerializeField] public readonly float _defaulGravity = -9.8f;
   private void Awake()
   {
       _singleton = this;
   }
}
