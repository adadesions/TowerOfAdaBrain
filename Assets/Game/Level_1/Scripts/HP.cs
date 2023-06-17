using System;
using System.Text;
using TMPro;
using UnityEngine;

namespace Game.Level_1.Scripts
{
    public class HP : MonoBehaviour
    {
        [SerializeField] int _maxHP = 10;
        [SerializeField] private TextMeshProUGUI _uiTextHP;

        private int _curHP;
        
        // Start is called before the first frame update
        void Start()
        {
            _curHP = _maxHP;
            UpdateTextHPFormat();
        }

        private void UpdateTextHPFormat()
        {
            _uiTextHP.text =  "HP: " + _curHP.ToString();
        }

        public void TakeDamage(int damage)
        {
            _curHP -= damage;
            if (_curHP < 0)
            {
                _curHP = 0;
            }

            UpdateTextHPFormat();
        } 
    }
}
