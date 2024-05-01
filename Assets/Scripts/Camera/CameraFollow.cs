using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HillClimb.Car
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform _carTarget;

        void Start(){
            if(_carTarget == null)
                GameObject.FindWithTag("Car").TryGetComponent<Transform>(out _carTarget);
            if(_carTarget == null)
                Debug.LogError("Car not found");
        }   


        private void Update() {
            
            transform.position = new Vector3(_carTarget.position.x, transform.position.y, transform.position.z);
        }
    }
}
