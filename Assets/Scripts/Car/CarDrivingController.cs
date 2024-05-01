using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace HillClimb.Car{
    [RequireComponent(typeof(Rigidbody2D))]
    public class CarDrivingController : MonoBehaviour{
        [SerializeField] private Rigidbody2D _frontTierRB;
        [SerializeField] private Rigidbody2D _backTierRB;
        private Rigidbody2D _carRB;

        
        [Header("Setting Car")]
        [SerializeField] private float _maxSpeed;
        [SerializeField] private float _speed;

        [SerializeField] private float _acceleration;
        [SerializeField, Tooltip("Deceleration Speed when gas button is released")] private float _deceleration;
        

        [SerializeField,  Tooltip("Deceleration Speed when break button is pressed")] private float  _decelerationBreak;
        [SerializeField] private float _rotationSpeed;

        private bool _isMove = false;
        private bool _isBreak = false;

        private void Awake() {
            _carRB = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate() {
            if(_isMove)
                RaiseSpeed();
            else
                LowerSpeed();
                
            _carRB.velocity = new Vector2(_speed, _carRB.velocity.y);
        }

        #region Move
        public void StartMove(){
            _isMove = true;
        }

        public void StopMove(){
            _isMove = false;
        }

        private void RaiseSpeed(){
           _speed = Mathf.SmoothStep(_speed, _maxSpeed, _acceleration);
        }

        #endregion

        #region  Break
        public void Break(){
            _isBreak = true;
        }

        public void StopBreak(){
            _isBreak = false;
        }

        private void LowerSpeed(){
            if(_isBreak)
                _speed = Mathf.SmoothStep(_speed, 0, _decelerationBreak);
            else
                _speed = Mathf.SmoothStep(_speed, 0, _deceleration);
        }
        #endregion
    
    }
    
}
