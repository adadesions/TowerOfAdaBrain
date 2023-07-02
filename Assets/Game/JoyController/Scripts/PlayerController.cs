using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Game.JoyController.Scripts
{
    public class PlayerController : MonoBehaviour
    {
        private Vector2 _playerInput;
        private Rigidbody2D _rb2d;
        [SerializeField] private float _walkSpeed = 5.0f;
        private Vector2 _nextPosition;

        // Start is called before the first frame update
        void Start()
        {
            _rb2d = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            Movements();
        }

        private void Update()
        {
            Attack();
        }

        private void Attack()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                print("Fire1");
            }
        }

        private void Movements()
        {
            _playerInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            if (_playerInput.magnitude > 0)
            {
                _nextPosition = _rb2d.position + _walkSpeed * Time.fixedDeltaTime * _playerInput;
                _rb2d.MovePosition(_nextPosition);
            }
        }
    }
}
