using UnityEngine;


namespace HillClimb.Car{
    [RequireComponent(typeof(Rigidbody2D))]
    public class CarDrivingController : MonoBehaviour{
        private Rigidbody2D _carRB;
        private FuelController _fuelManager;

        
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
            _fuelManager = GetComponent<FuelController>();
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
            _fuelManager.StartMove();
        }

        public void StopMove(){
            _isMove = false;
            _fuelManager.StopMove();
        }

        private void RaiseSpeed(){
           _speed = Mathf.SmoothStep(_speed, _maxSpeed, _acceleration);
        }

        #endregion

        #region  Break
        public void Break(){
            _isBreak = true;
            _fuelManager.StopMove();
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
