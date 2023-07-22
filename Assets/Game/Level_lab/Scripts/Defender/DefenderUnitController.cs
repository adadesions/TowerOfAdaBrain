using Unity.Mathematics;
using UnityEngine;

namespace Game.Level_lab.Scripts.Defender
{
    public class DefenderUnitController : MonoBehaviour
    {
        private GameObject _target;
        private Vector3 _direction;
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private float _bulletSpeed = 5.0f;
        [SerializeField] private Transform _muzzle;
        [SerializeField] private float _bulletSpeedScale = 100.0f;
        private float _lastTimeShot = 0.0f;
        [SerializeField] private float _shootingCooldown = 0.3f;
        private Transform _bulletStore;

        // Start is called before the first frame update
        void Start()
        {
            _bulletStore = GameObject.FindGameObjectWithTag("BulletStore").transform;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            Aiming();
            Shooting();
        }

        private void Shooting()
        {
            if (!_target) return;
            if (Time.time < _lastTimeShot + _shootingCooldown) return;
            
            _lastTimeShot = Time.time;
            var bullet = Instantiate(_bulletPrefab, _muzzle.position, quaternion.identity);
            bullet.transform.SetParent(_bulletStore);
            if (bullet.TryGetComponent<Rigidbody2D>(out var rb))
            {
                rb.velocity =  _bulletSpeed * _bulletSpeedScale * Time.fixedDeltaTime * _direction;
            }
        }

        private void Aiming()
        {
            if (!_target) return;

            _direction = _target.transform.position - transform.position;
            var angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg - 90f;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("monster") && !_target)
            {
                _target = other.gameObject;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("monster") && other.gameObject.Equals(_target))
            {
                _target = null;
            }
        }
    }
}
    