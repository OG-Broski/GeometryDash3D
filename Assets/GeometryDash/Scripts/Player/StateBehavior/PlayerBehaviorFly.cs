
using UnityEngine;
using System;

public class PlayerBehaviorFly : IPlayerBehavior
{
    public bool NeedFixedUpdate { get; set;} = true;

    
    private PlayerData _playerData = PlayerData._singleton;
    [SerializeField] public Player _player;
    [SerializeField] private Rigidbody _rigidBody;
    public void Enter(Player player)
    {
      if(_rigidBody == null){
            _rigidBody = player.GetComponent<Rigidbody>();
            _player = player;
        }
        Debug.Log("Вход в состояние полета");
        _player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionZ;
        
    }
   public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            _playerData._doJump = true;
        }
    }
     public void FixedUpdate()
    {
        DoFly();
    }
    public void Exit()
    {
        Debug.Log("Выход с состояния Fly");
        _player.GetComponent<Rigidbody>().constraints =  RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX| RigidbodyConstraints.FreezeRotationY ;
    }

    public void DoFly(){
        Vector3 _moveVector = Vector3.right;
        _moveVector = _moveVector.normalized *_playerData._moveSpeed * Time.deltaTime;
        _rigidBody.MovePosition(_player.transform.position + _moveVector);  
        if(_playerData._doJump) {
                _playerData._doJump = false;
                _rigidBody.AddForce(new Vector2(0,Physics.gravity.y / _playerData._defaulGravity) * _playerData._jumpForse);
                _playerData._jumpForse = _playerData._minJumpForse;
        }
        if(_rigidBody.velocity.y < 0){
                    _rigidBody.velocity += Vector3.up * Physics.gravity.y *(_playerData._fallMultiplier - 1) * Time.deltaTime;
                   Quaternion _rotation = Quaternion.AngleAxis(-10, new Vector3(0,0,1));
                      _player.transform.rotation = _rotation;
        }
            else if(_rigidBody.velocity.y > 0 && !Input.GetKeyDown(KeyCode.Space)){
            _rigidBody.velocity += Vector3.up * Physics.gravity.y * (_playerData._lowjumpMultiplier- 1) * Time.deltaTime; 
              Quaternion _rotation = Quaternion.AngleAxis(10, new Vector3(0,0,1));
                      _player.transform.rotation = _rotation;
            }
    }

 
}
