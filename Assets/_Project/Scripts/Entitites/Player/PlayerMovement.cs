using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Настройка движения")]
    [SerializeField] private float _speed = 7f;
    [SerializeField] private float _screenLimit = 7.5f;

    [Header("Настройка стрельбы")]

    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _firePoint;

    private InputServices _InputService;

    public void Construct(InputServices inputServices)
    {
        _InputService = inputServices;

        if (_bulletPrefab == null)
        {
            Debug.Log("Сервис ввода успешно подключен к игроку.");
        }
    }


    void Update()
    {
        if (_InputService == null)
        {
            return;
        }

        float horizontalInput = _InputService.GetHorizontalAxis();
        transform.Translate(Vector2.right * horizontalInput * _speed * Time.deltaTime);

        float clampedX = Mathf.Clamp(transform.position.x, -_screenLimit, _screenLimit);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);

        if (_InputService.IsFirePressed())
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if (_bulletPrefab != null)
        {
            Vector3 spawnPosition = _firePoint != null ? _firePoint.position : transform.position;

            Instantiate(_bulletPrefab, spawnPosition, Quaternion.identity);
        }
        else
        {
            Debug.LogError("Player: Забыл перетащить префаб пули в инспектор!");
        }
    }

}

