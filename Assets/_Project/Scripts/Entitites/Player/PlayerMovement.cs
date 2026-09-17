using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Настройка движения")]
    [SerializeField] private float _speed = 7f;
    [SerializeField] private float _screenLimit = 7.5f;

    private InputServices _InputService;

    public void Construct(InputServices inputServices)
    {
        _InputService = inputServices;
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
    }
}

