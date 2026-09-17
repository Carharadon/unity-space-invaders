using UnityEngine;
namespace SpaceInvaders.Core
{
    public class GameBootstrapper : MonoBehaviour
    {
        [Header("Ссылки на объекты сцены")]
        [SerializeField] private PlayerMovement _playerMovement;

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
        }
    }
}
