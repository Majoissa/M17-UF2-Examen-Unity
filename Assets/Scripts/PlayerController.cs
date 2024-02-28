using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Variables de animación
     [Header("Animation Variables")]
    [SerializeField] private Animator animator;
    [SerializeField] private KeyCode hurtKey = KeyCode.Alpha1;
    [SerializeField] private KeyCode dieKey = KeyCode. Alpha2;
    [SerializeField] private KeyCode attackKey = KeyCode.Alpha3;

    // Variables de teletransporte
    [Header("Teleport Variables")]
    [SerializeField] private float teleportDistanceX = 5f;
    [SerializeField] private float teleportDistanceY = 0f;

    private bool facingRight = true;
    private bool hasTeleportedDuringAttack = false;

     void Update()
    {
        // Control de dirección solamente si el jugador está en la animación Idle
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            if (horizontalInput != 0)
            {
                FlipCharacter(horizontalInput);
            }
        }

        // Detectar las teclas de animación
        if (Input.GetKeyDown(hurtKey))
        {
            animator.SetTrigger("Hurt");
        }
        else if (Input.GetKeyDown(dieKey))
        {
            animator.SetTrigger("Die");
        }
        else if (Input.GetKeyDown(attackKey))
        {
            animator.SetTrigger("Attack");
            hasTeleportedDuringAttack = false;
        }

        // Teleportación durante la animación de ataque
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.5f &&
                animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 0.75f &&
                !hasTeleportedDuringAttack)
            {
                Teleport();
                hasTeleportedDuringAttack = true; // Asegura que la teletransportación solo ocurra una vez por ataque
            }
        }
    }

    private void FlipCharacter(float horizontalInput)
    {
        // Si el personaje está mirando hacia la dirección incorrecta
        if (horizontalInput > 0 && !facingRight || horizontalInput < 0 && facingRight)
        {
            facingRight = !facingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1; // Cambia la dirección en el eje X
            transform.localScale = scale;
        }
    }

    private void Teleport()
    {
        // Asegúrate de teleportar en la dirección correcta basada en hacia dónde está mirando el personaje
        transform.position += new Vector3(teleportDistanceX * (facingRight ? 1 : -1), teleportDistanceY, 0);
    }

    void OnDrawGizmos()
    {
        // Dibuja la línea de teleportación en la dirección correcta
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(teleportDistanceX * (facingRight ? 1 : -1), teleportDistanceY, 0));
    }
}