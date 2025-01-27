using UnityEngine;
using UnityEngine.InputSystem;

public class NewMovement : MonoBehaviour
{
    private InputActionAsset playerInputs;

    private Vector2 movementInput;

    [SerializeField]
    private float move;
    private void Awake()
    {
        playerInputs = GetComponent<InputActionAsset>();
    }
}
