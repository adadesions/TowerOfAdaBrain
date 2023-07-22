using System;
using UnityEngine;

namespace Game.Level_1.Scripts
{
    public class UnitButton : MonoBehaviour
    {
        private bool _isClicked;

        public bool IsClicked
        {
            get => _isClicked;
            set => _isClicked = value;
        }

        // Start is called before the first frame update
        void Start()
        {
            IsClicked = false;
        }

        private void OnMouseDown()
        {
            print("Clicked");
        }
    }
}
