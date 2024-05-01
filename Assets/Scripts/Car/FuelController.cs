using System.Collections;
using HillClimb.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace HillClimb.Car
{
    public class FuelController : MonoBehaviour
    {
        [SerializeField] private float _maxFuel;
        [SerializeField] private float _useFuelPerSecond;

        [Header("UI")]
        [SerializeField] private Slider _fuelSlider;
        [SerializeField] private GameObject _gameOverUI;
        private float _fuel;

        private Coroutine _useFuelCoroutine;

        private void Awake() {
            _fuelSlider.maxValue = _maxFuel;
            _fuelSlider.value = _maxFuel;
            _fuel = _maxFuel;
        }

        public void StartMove(){
            _useFuelCoroutine =StartCoroutine(UseFuelCoroutine());
        }

        public void StopMove(){
            StopCoroutine(_useFuelCoroutine);
        }


        private IEnumerator UseFuelCoroutine(){
            while(_fuel > 0){
                yield return new WaitForSeconds(0.25f);
                _fuel -= _useFuelPerSecond/4;
                UpdateSlider();
            }
            GameManager.Instance.GameOver();
            
        }

        public void ReFuel(float fuel){
            _fuel += fuel;
            if(_fuel > _maxFuel)
                _fuel = _maxFuel;
            UpdateSlider();
        }

        private void UpdateSlider(){
            _fuelSlider.value = _fuel;
        }
    }
}
