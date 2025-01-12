using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        var player = collision.GetComponent<Movement>();

        if (player == null)
        {
            var movement = gameObject.GetComponentInParent<Movement>();

            if (movement != null)
            {
                movement.SetGroundedState(false);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        var player = collision.GetComponent<Movement>();

        if (player == null)
        {
            var movement = gameObject.GetComponentInParent<Movement>();

            if (movement != null)
            {
                movement.SetGroundedState(true);
            }
        }
    }
}