using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Level_1.Scripts.Managers
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager _instance;
        private UIManager _uiManager;

        public static GameManager Instance
        {
            get => _instance;
            private set => _instance = value;
        }

        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(this);
                return;
            }

            _instance = this;
        }

        public void EndGame()
        {
            _uiManager.ShowEndGamePanel();
            Time.timeScale = 0;
        }

        public void OnClickRestart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        // Start is called before the first frame update
        void Start()
        {
            Time.timeScale = 1;
            _uiManager = UIManager.Instance;
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
