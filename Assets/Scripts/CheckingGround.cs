using UnityEngine;

public class CheckingGround : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            var movement = gameObject.GetComponentInParent<Movemant>();

            if (movement != null)
            {
                movement.isGrounded = false;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            var movement = gameObject.GetComponentInParent<Movemant>();

            if (movement != null)
            {
                movement.isGrounded = true;
            }
        }
    }
}