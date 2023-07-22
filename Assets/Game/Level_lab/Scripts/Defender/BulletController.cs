using System;
using UnityEngine;

namespace Game.Level_lab.Scripts.Defender
{
    public class BulletController : MonoBehaviour
    {
        private float _startTime = 0.0f;
        [SerializeField] private float _bulletDuration = 1.0f;

        private void Start()
        {
            _startTime = Time.time;
        }

        private void Update()
        {
            LifeCycle();
        }

        private void LifeCycle()
        {
            if (Time.time < _startTime + _bulletDuration) return;
            Destroy(gameObject);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("monster"))
            {
                Destroy(gameObject);
            }
        }
    }
}
