using System;
using System.Collections.Generic;
using UnityEngine;
namespace SpaceInvaders.Core
{
    public class GameBootstrapper : MonoBehaviour
    {
        [Header("Ссылки на объекты сцены")]
        [SerializeField] private PlayerMovement _playerMovement;

        [Header("Настройки сетки мобов")]
        [SerializeField] private GameObject _enemyPrefab;
        [SerializeField] private int _rows = 4;
        [SerializeField] private int _columns = 6;
        [SerializeField] private float _xSpacing = 1.2f;
        [SerializeField] private float _ySpacing = 1.0f;
        [SerializeField] private Vector2 _spawnOrigin = new Vector2(-3f, 4f);
        [SerializeField] private float _stepInterval = 3f; 
        [SerializeField] private float _stepDistance = 0.5f;
        private float _stepTimer;

        private List<GameObject> _activeEnemies = new List<GameObject>();

        void Awake()
        {
            InputServices inputService = new InputServices();

            if (_playerMovement != null)
            {
                _playerMovement.Construct(inputService);
            }
            else
            {
                Debug.LogError("Bootstrapper: Не привязана ссылка на PlayerMovement!");
            }

            SpawnEnemyGrid();
            _stepTimer = _stepInterval;
        }

        private void SpawnEnemyGrid()
        {
            if (_enemyPrefab == null)
            {
                Debug.LogError("Bootstrapper: Не назначен префаб моба!");
            }

            for (int row = 0; row < _rows; row++)
            {
                for (int col = 0; col < _columns; col++)
                {
                    float posX = _spawnOrigin.x + (col * _xSpacing);
                    float posY = _spawnOrigin.y - (row * _ySpacing);
                    Vector3 spawnPosition = new Vector3(posX, posY, 0f);

                    GameObject newEnemy = Instantiate(_enemyPrefab, spawnPosition, Quaternion.identity);

                    _activeEnemies.Add(newEnemy);
                }
            }
        }

        void Update()
        {
            _stepTimer -= Time.deltaTime;

            if (_stepTimer <= 0f)

                MoveEnemiesDown();

                _stepTimer = _stepInterval;
            
        }

        private void MoveEnemiesDown()
        {
            for (int i = 0; i < _activeEnemies.Count; i++)
            {

                if (_activeEnemies[i] != null)
                {
                    Vector3 currentPos = _activeEnemies[i].transform.position;

                    currentPos.y -= _stepDistance;


                    _activeEnemies[i].transform.position = currentPos;
                }
            }
        }
    }
}
