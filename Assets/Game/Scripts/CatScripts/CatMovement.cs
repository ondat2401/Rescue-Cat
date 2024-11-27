using UnityEngine;

public class CatMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float changeDirectionInterval = 3f;
    [SerializeField] private float raycastDistance = 1f;
    [SerializeField] private Transform raycastOrigin;
    [SerializeField] private LayerMask obstacleMask;
    private float moveSpeed;

    [Header("Rotation Settings")]
    [SerializeField] private float rotationSpeed = 5f;

    private Vector3 moveDirection;
    private float timer;

    public bool isRunning = false;
    public bool isCaught = false;
    private void Start()
    {
        ChooseRandomDirection();
        moveSpeed = GameManager.Instance.catSpeed;
    }

    private void Update()
    {
        if (!isCaught)
        {
            
            if (isRunning && FindAnyObjectByType<PlayerCatchController>().isCatching)
            {
                RunningFromPlayer();
            }
            else
            {
                timer += Time.deltaTime;

                if (timer >= changeDirectionInterval || IsObstacleAhead())
                {
                    ChooseValidDirection();
                    timer = 0f;
                }

                Move();
                RotateTowardsMovement();
            }
        }
    }
    public void RunningFromPlayer()
    {
        Vector3 targetPosition = new Vector3(0, 0, 800);
        Vector3 direction = (targetPosition - transform.position).normalized;
        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
        transform.Translate(direction * (moveSpeed + 5f) * Time.deltaTime, Space.World);

    }

    private void Move() =>
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);

    public void ChooseRandomDirection()
    {
        float angle = Random.Range(0f, 360f) * Mathf.Deg2Rad;
        moveDirection = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)).normalized;
    }

    private void ChooseValidDirection()
    {
        const int maxAttempts = 10;
        for (int i = 0; i < maxAttempts; i++)
        {
            ChooseRandomDirection();
            if (!Physics.Raycast(transform.position, moveDirection, raycastDistance, obstacleMask))
                break;
        }
    }

    private bool IsObstacleAhead() =>
        Physics.Raycast(raycastOrigin.position, moveDirection, raycastDistance, obstacleMask);

    private void RotateTowardsMovement()
    {
        if (moveDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

    private void OnDrawGizmos()
    {
        if (raycastOrigin != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(raycastOrigin.position, raycastOrigin.position + moveDirection * raycastDistance);
        }
    }
}
