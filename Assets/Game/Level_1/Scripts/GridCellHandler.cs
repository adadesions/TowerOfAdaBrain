using System;
using Game.Level_1.Scripts.Managers;
using Unity.Mathematics;
using UnityEngine;

namespace Game.Level_1.Scripts
{
    public class GridCellHandler : MonoBehaviour
    {
        private bool _isAvailable = true;
        private UnitManager _unitManager;
        private Transform _defenderParent;

        private void Start()
        {
            _unitManager = UnitManager.Instance;
            _defenderParent = GameObject.FindGameObjectWithTag("DefenderStore").transform;
        }


        private void OnMouseDown()
        {
            if (!_isAvailable || !_unitManager.SelectedUnit) return;
        
            var unit = Instantiate(
                _unitManager.SelectedUnit, 
                transform.position + new Vector3(0, 0, 0.5f), 
                quaternion.identity);
            
            unit.transform.SetParent(_defenderParent);
            _isAvailable = false;
        }
    }
}
