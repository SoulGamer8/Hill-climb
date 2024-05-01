using UnityEngine;


namespace HillClimb.Managers{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        [SerializeField] private GameObject _gameOverMenu;

        private void Awake(){
            if(Instance == null)
                Instance = this;
            else
                Debug.LogError("There is more than one GameManager in the scene");
        }

        public void GameOver(){
            _gameOverMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }
}