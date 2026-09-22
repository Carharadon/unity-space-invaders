using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Настройки пули")]
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _lifeLimitY = 6f;

    private void Update()
    {
        transform.Translate(Vector2.up * _speed * Time.deltaTime);

        if (transform.position.y > _lifeLimitY)
        {
            Destroy(gameObject);
        }
    }
}
