using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    private float m_horizontalInput;
    private float m_verticalInput;
    private Rigidbody2D m_rigidbody2D; 
    public float movementSpeed = 5f;
    [Tooltip("When true, player can move diagonally. When false, movement is restricted to the stronger axis.")]
    public bool allowDiagonalMovement = true;
    public bool allowMovement = true;

    private void Awake()
    {
       m_rigidbody2D = GetComponent<Rigidbody2D>();
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m_horizontalInput = Input.GetAxis("Horizontal");
        m_verticalInput = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        if (!allowMovement) return;

        Vector2 movement = new Vector2(m_horizontalInput, m_verticalInput);

        if (!allowDiagonalMovement)
        {
            if (Mathf.Abs(movement.x) > Mathf.Abs(movement.y))
                movement.y = 0f;
            else
                movement.x = 0f;
        }

        Vector2 newPos = m_rigidbody2D.position + movement * movementSpeed * Time.fixedDeltaTime;
        m_rigidbody2D.MovePosition(newPos);
        
    }

    void LateUpdate()
    {
        Debug.Log("Player actual position: " + transform.position);
    }
}
