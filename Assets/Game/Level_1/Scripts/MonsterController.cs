using Game.Level_1.Scripts.Managers;
using Game.Level_lab.Scripts.Attacker;
using Unity.VisualScripting;
using UnityEngine;

namespace Game.Level_1.Scripts
{
    public class MonsterController : MonoBehaviour
    {
        private PathManager _pathManager;
        private Transform _currentPoint;
        private int _idxPoint = 0;
        [SerializeField] private float _speed = 1.0f;
        [SerializeField] private int _damage = 1;
        private AttackerHealth _health;

        // Start is called before the first frame update
        void Start()
        {
            _pathManager = PathManager.Instance;
            _health = GetComponent<AttackerHealth>();
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            Movements();
        }

        private void Movements()
        {
            _currentPoint = _pathManager.RoutePath[_idxPoint];
            transform.position = Vector2.MoveTowards(
                transform.position, 
                _currentPoint.position, 
                _speed * Time.fixedDeltaTime);
        }

        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            if (collider2D.gameObject.CompareTag("path"))
            {
                if (_idxPoint < _pathManager.RoutePath.Count - 1)
                {
                    _idxPoint++;
                    print("IDX: " + _idxPoint);
                }

                var hp = collider2D.gameObject.GetComponent<HP>();
                if (hp)
                {
                    hp.TakeDamage(_damage);
                    Destroy(gameObject);
                }

            }

            if (collider2D.gameObject.CompareTag("Bullet"))
            {
                _health.TakeDamage(1);
            }
        }
        
    }
}
