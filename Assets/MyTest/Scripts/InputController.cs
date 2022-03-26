using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    //public InputAction myInputAction;
    //public InputActionMap myInputActions;
    //public InputActionAsset myInputActionAsset;
    public InputActionReference fireAction;
    private InputActionRebindingExtensions.RebindingOperation rebindingOperation;
    //public PlayerInput playerInput;

    public void NewBinding()
    {
        fireAction.asset.Disable();
        rebindingOperation = fireAction.action.PerformInteractiveRebinding()
                .WithControlsExcluding("Mouse")
                .OnComplete(operation => RebindComplete())
                .Start();
    }
    public void RebindComplete() 
    {
        rebindingOperation.Dispose(); //Esto es para liberar la memoria
        fireAction.asset.Enable();
        Debug.Log("se ejecut� cambio");
    }

    private void Update()
    {
        Keyboard kb = InputSystem.GetDevice<Keyboard>();
        Mouse ms = InputSystem.GetDevice<Mouse>();

        if (kb.qKey.wasPressedThisFrame)
        {
            Debug.Log("Se presion� la tecla Q");
        }
        if (InputSystem.GetDevice<Mouse>().rightButton.wasPressedThisFrame)
        {
            Debug.Log("Se presion� el click derecho");
        }

        //Debug.Log(ms.position.ReadValue());
    }
}
