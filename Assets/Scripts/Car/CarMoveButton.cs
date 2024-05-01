using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace HillClimb.Car{
    public class CarMoveButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler{
        [SerializeField] private CarDrivingController _carDrivingController;

        public void OnPointerDown(PointerEventData eventData) {
            _carDrivingController.Move();
        }

        public void OnPointerUp(PointerEventData eventData) {
            _carDrivingController.StopMove();
        }
    }
}
