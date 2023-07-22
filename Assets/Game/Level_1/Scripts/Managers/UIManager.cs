using System;
using Unity.Mathematics;
using UnityEngine;

namespace Game.Level_1.Scripts.Managers
{
    public class UIManager : MonoBehaviour
    {
        private static UIManager _instance;
        [SerializeField] private GameObject _endGamePanel;
        private UnitManager _unitManager;

        public static UIManager Instance
        {
            get => _instance;
            private set => _instance = value;
        }

        private void Awake()
        {
            if (_instance != this && _instance != null)
            {
                Destroy(this);
                return;
            }

            _instance = this;
        }

        public void ShowEndGamePanel()
        {
            _endGamePanel.SetActive(true);
        }

        // Start is called before the first frame update
        void Start()
        {
            _endGamePanel.SetActive(false);
            _unitManager = UnitManager.Instance;
        }

        public void OnSelectUnit(GameObject unitPrefab)
        {
            _unitManager.SetSelectedUnitFromUI(_unitManager.SelectedUnit ? null : unitPrefab);
        }

        public void ToggleButtonState(UnitButton unitButton)
        {
            // Use it later
            unitButton.IsClicked = !unitButton.IsClicked;
        }
        
    }
}
