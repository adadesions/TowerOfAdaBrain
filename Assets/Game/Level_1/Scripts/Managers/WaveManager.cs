using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.Level_1.Scripts.Managers
{
    public class WaveManager : MonoBehaviour
    {
        private static WaveManager _instance;
        [SerializeField] private List<GameObject> _monsterPrefab;
        [SerializeField] private List<Transform> _spawnerPoint;
        [SerializeField] private Transform _monsterSection;
        private float _lastTimeGenerated = 0.0f;
        [SerializeField] private float _cooldownSpawn = 0.5f;
        private bool _isAllowGenerate = true;
        private int _curCapacity = 0;
        [SerializeField] private List<int> _maxCapcityPerWave;
        private int _waveRound = 0;
        [SerializeField] private float _cooldownWave = 10.0f;
        private int _randIndex = 0;
        private int _probability = 0;
        private bool _isBossWave = false;
        [SerializeField] private int _bossWaveRound;
        private GameManager _gameManager;
        private int _globalCapacity = 0;

        public int GlobalCapacity
        {
            get => _globalCapacity;
            set => _globalCapacity = value;
        }

        public static WaveManager Instance
        {
            get => _instance;
            private set => _instance = value;
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

        private void Start()
        {
            _gameManager = GameManager.Instance;
        }

        // Update is called once per frame
        void Update()
        {
            WaveControl();
            MonsterGeneratorWithProbMap();
        }
        
        private void WaveControl()
        {
            try
            {
                _isAllowGenerate = _curCapacity < _maxCapcityPerWave[_waveRound];    
            }
            catch (ArgumentOutOfRangeException e)
            {
                _waveRound = _maxCapcityPerWave.Count;
            }
            
            if (!_isAllowGenerate && Time.time > _lastTimeGenerated + _cooldownWave)
            {
                _isAllowGenerate = true;
                _curCapacity = 0;
                _waveRound++;
                if (_waveRound >= _maxCapcityPerWave.Count)
                {
                    _isAllowGenerate = false;
                    if (_globalCapacity <= 0)
                    {
                        _gameManager.EndGame();
                    }
                    // _waveRound = 0;
                    // _isBossWave = false;
                }

                if (_waveRound == _bossWaveRound)
                {
                    _isBossWave = true;
                }
            }
            
        }

        private void MonsterGenerator()
        {
            if (!_isAllowGenerate) return;
            if (Time.time < _lastTimeGenerated + _cooldownSpawn) return;
            
            _lastTimeGenerated = Time.time;
            _randIndex = (int) Random.Range(0, _monsterPrefab.Count);
            var monsterClone = Instantiate(_monsterPrefab[_randIndex], _spawnerPoint[0].position, quaternion.identity);
            monsterClone.transform.SetParent(_monsterSection);
            _curCapacity++;
        }
        
        private void MonsterGeneratorWithProbMap()
        {
            if (!_isAllowGenerate) return;
            if (Time.time < _lastTimeGenerated + _cooldownSpawn) return;
            
            _lastTimeGenerated = Time.time;
            _probability = (int) Random.Range(0, 100) + 1;
            if (_probability <= 10)
            {
                if (!_isBossWave)
                {
                    _probability = (int) Random.Range(0, 100) + 1;
                }
                else
                {
                    _randIndex = 0;    
                }
            } 
            else if (_probability is > 10 and <= 40)
            {
                _randIndex = 1;
            }
            else
            {
                _randIndex = 2;
            }
            
            var monsterClone = Instantiate(_monsterPrefab[_randIndex], _spawnerPoint[0].position, quaternion.identity);
            monsterClone.transform.SetParent(_monsterSection);
            _curCapacity++;
            _globalCapacity++;
        }
    }
}
