using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.Level_1.Scripts.Managers
{
    public class PathManager : MonoBehaviour
    {
        private static PathManager _instance; 
        private List<Transform> _routePath = new List<Transform>();

        public static PathManager Instance
        {
            get => _instance;
            set => _instance = value;
        }

        public List<Transform> RoutePath
        {
            get => _routePath;
            set => _routePath = value;
        }

        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(this);
                return;
            }

            _instance = this;
        }

        // Start is called before the first frame update
        void Start()
        {
            SetupPath();
        }

        private void SetupPath()
        {
            var rawPaths = GameObject.FindGameObjectsWithTag("path");
            Array.Sort(rawPaths, (x, y) => String.Compare(x.name, y.name, StringComparison.Ordinal));
            foreach (var point in rawPaths)
            {
                _routePath.Add(point.transform);
            }
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
