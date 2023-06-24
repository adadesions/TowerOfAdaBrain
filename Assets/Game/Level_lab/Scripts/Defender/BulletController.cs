using System;
using UnityEngine;

namespace Game.Level_lab.Scripts.Defender
{
    public class BulletController : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("monster"))
            {
                print("Bullet");
                Destroy(gameObject);
            }
        }
    }
}
