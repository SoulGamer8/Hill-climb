using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace HillClimb.Car{
    [RequireComponent(typeof(Rigidbody2D))]
    public class CarDrivingController : MonoBehaviour{
        [SerializeField] private Rigidbody2D _frontTierRB;
        [SerializeField] private Rigidbody2D _backTierRB;
        [SerializeField] private Rigidbody2D _carRB;

        
        [Header("Setting Car")]
        [SerializeField] private float _maxSpeed;
        [SerializeField] private float _speed;

        [SerializeField] private float _rotationSpeed;


        private void Awake() {
            _carRB = GetComponent<Rigidbody2D>();
        }


        public void Move(){
            _carRB.velocity = new Vector2(_speed, _carRB.velocity.y);
            StartCoroutine(SpeedRise());
        }

        private IEnumerator SpeedRise(){
            while(true){
                if(_speed > _maxSpeed){
                    _speed += 0.1f * Time.deltaTime;
                    Debug.Log(_speed);
                    yield return new WaitForSeconds(0.1f);
                }
            }
        }

        public void StopMove(){
            _carRB.velocity = new Vector2(0, _carRB.velocity.y);
        }

        public void Breal(){

        }
    
    }
    
}
