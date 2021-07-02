using System;
using System.Collections.Generic;
using UnityEngine;
    public class Player : MonoBehaviour
    {
    
       private Dictionary<Type, IPlayerBehavior> _behaviorMap;
       private IPlayerBehavior _behaviorCurrent;
       private void Start()
       {
           this.InitBehaviors();
           this.SetBehaviorByDefault();
       }

       private void Update()
       {
           _behaviorCurrent.Update();
       }

        private void FixedUpdate()
        {
            if(_behaviorCurrent.NeedFixedUpdate){
                _behaviorCurrent.FixedUpdate();
            }
            return;
        }
        private void InitBehaviors(){
            this._behaviorMap = new Dictionary<Type, IPlayerBehavior>();
            this._behaviorMap[typeof(PlayerBehaviorIdle)] =new PlayerBehaviorIdle();
            this._behaviorMap[typeof(PlayerBehaviorMove)] =new PlayerBehaviorMove();
            this._behaviorMap[typeof(PlayerBehaviorDead)] =new PlayerBehaviorDead();
            this._behaviorMap[typeof(PlayerBehaviorFly)] =new PlayerBehaviorFly();
        }
        private void SetBehavior(IPlayerBehavior _newBehavior){  
            if(_behaviorCurrent != null){
                _behaviorCurrent.Exit();
            }
                this._behaviorCurrent = _newBehavior;
                this._behaviorCurrent.Enter(this);

        }

        private void SetBehaviorByDefault(){
            this.SetBehaviorIdle();
        }

        private IPlayerBehavior GetBehavior<T>() where T : IPlayerBehavior{
            var _type = typeof(T);
            return this._behaviorMap[_type];
        }

        public void SetBehaviorIdle(){
            var _behavior = this.GetBehavior<PlayerBehaviorIdle>();
            this.SetBehavior(_behavior);
        }
        public void SetBehaviorMove(){
            var _behavior = this.GetBehavior<PlayerBehaviorMove>();
            this.SetBehavior(_behavior);
        }
        public void SetBehaviorDead(){
            var _behavior = this.GetBehavior<PlayerBehaviorDead>();
            this.SetBehavior(_behavior);
        }
        public void SetBehaviorFly(){
            var _behavior = this.GetBehavior<PlayerBehaviorFly>();
            this.SetBehavior(_behavior);
        }
        
        private void OnCollisionEnter(Collision other){
        if(other.gameObject.CompareTag("Ground")){
            PlayerData._singleton._isJumping = false;
            }
        }
    }


