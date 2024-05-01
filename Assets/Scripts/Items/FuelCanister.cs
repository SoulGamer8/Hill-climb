using HillClimb.Car;
using UnityEngine;

namespace HillClimb.Items{
    [RequireComponent(typeof(BoxCollider2D))]
    public class FuelCanister : MonoBehaviour{
        [SerializeField] private int _fuelAmount;

        private void OnTriggerEnter2D(Collider2D other) {
            if(other.gameObject.tag == "Car"){
                other.GetComponent<FuelController>().ReFuel(_fuelAmount);
                Destroy(gameObject);
            }

        }
    }
}