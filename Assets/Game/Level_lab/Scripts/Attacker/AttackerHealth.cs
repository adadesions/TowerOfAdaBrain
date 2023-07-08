using Game.Level_1.Scripts.Managers;
using UnityEngine;

namespace Game.Level_lab.Scripts.Attacker
{
    public class AttackerHealth : MonoBehaviour
    {
        [SerializeField] private int _maxHp = 100;
        private int _curHp;

        // Start is called before the first frame update
        void Start()
        {
            _curHp = _maxHp;
        }

        public void TakeDamage(int damage)
        {
            _curHp -= damage;

            if (_curHp < 0)
            {
                _curHp = 0;
                OnDead();
            }
        }

        public void OnDead()
        {
            WaveManager.Instance.GlobalCapacity--;
            print("GlobalCap(Dead): " + WaveManager.Instance.GlobalCapacity);
            Destroy(gameObject);
        }
    }
}
