using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    private Vector3 _cursorInput;
    [SerializeField] private float _moveSpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movements();
    }

    private void Movements()
    {
        _cursorInput = new Vector3(Input.GetAxis ("Horizontal_Left"), Input.GetAxis("Vertical_Left"), 0);
        if (_cursorInput.magnitude > 0)
        {
            transform.position = transform.position + _moveSpeed * Time.deltaTime * _cursorInput;
        }
    }
}
