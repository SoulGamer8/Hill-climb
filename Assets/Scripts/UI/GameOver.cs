using UnityEngine;
using UnityEngine.SceneManagement;

namespace HillClimb.UI{
    public class GameOver : MonoBehaviour{
        public void Restart(){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Time.timeScale = 1;
        }

        public void Quit(){
            Application.Quit();
            
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #endif
        }
    }
}

