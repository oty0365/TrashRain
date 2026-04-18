using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb2D;
    [SerializeField] private float moveSpeed = 5f;
    private PlayerInputController _playerInputController;

    private void Awake()
    {
        _playerInputController = GetComponent<PlayerInputController>();
    }
    private void OnEnable()
    {
        _playerInputController.OnMoveEvent += SetVelocity;
    }
    private void OnDisable()
    {
        _playerInputController.OnMoveEvent -= SetVelocity;
    }
    public void SetVelocity(Vector2 velocity)
    {
        rb2D.linearVelocity = velocity*moveSpeed;
    }
}
