using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public PlayerInput playerInput;
    public void Fire(InputAction.CallbackContext context)
    {
        Debug.Log("Fire!" + context.phase);
    }
    public void Move(InputAction.CallbackContext ctx)
    {
        Debug.Log("Im Moving!");
        if (ctx.performed)
        {

        }
    }

    private void Update()
    {
        Vector2 input = playerInput.actions["Move"].ReadValue<Vector2>();
        Vector3 move = new Vector3(input.x, input.y, 0f);

        transform.position += (move*0.1f);
    }
}
