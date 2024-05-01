using HillClimb.Managers;
using UnityEngine;

namespace HillClimb.Driver{
    [RequireComponent(typeof(PolygonCollider2D))]
    public class DriverDeath : MonoBehaviour{

        private void OnTriggerEnter2D(Collider2D other) {
            if(other.gameObject.tag == "Ground")
                GameManager.Instance.GameOver();
        }
    }
}
