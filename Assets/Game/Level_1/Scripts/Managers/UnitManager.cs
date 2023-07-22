using System;
using UnityEngine;

namespace Game.Level_1.Scripts.Managers
{
    public class UnitManager : MonoBehaviour
    {
        private static UnitManager _instance;
        private GameObject _selectedUnit;

        public static UnitManager Instance
        {
            get => _instance;
            set => _instance = value;
        }

        public GameObject SelectedUnit => _selectedUnit;

        private void Awake()
        {
            if (_instance != this && _instance != null)
            {
                Destroy(this);
                return;
            }

            _instance = this;

        }

        public void SetSelectedUnitFromUI(GameObject unitPrefab)
        {
            _selectedUnit = unitPrefab;
        }
    }
}
