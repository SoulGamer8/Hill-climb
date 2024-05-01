using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace HillClimb.Car
{
    public class CarBreakButton : MonoBehaviour,IPointerDownHandler, IPointerUpHandler{
        [SerializeField] private CarDrivingController _carDrivingController;

        public void OnPointerDown(PointerEventData eventData) {
            _carDrivingController.Break();
        }

        public void OnPointerUp(PointerEventData eventData) {
            _carDrivingController.StopBreak();
        }
    }
}
