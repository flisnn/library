using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public float currentSpeed;
    public float walkSpeed;
    public float sprintSpeed;
    public float interactDistant = 10f;
    private bool hitSomething = false;
    MouseActions interactable;

    [SerializeField] private CharacterController _characterController;
    [SerializeField] private CinemachineCamera _cinCam;
    [SerializeField] private Camera _cam;
    [SerializeField] private GameObject _interactableObject;

    private Vector2 _move;

    private void Start()
    {
        currentSpeed = walkSpeed;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void InteractionRay()
    {
        Ray ray = _cam.ViewportPointToRay(Vector3.one / 2f);
        RaycastHit hit;
        hitSomething = false;

        if (Physics.Raycast(ray, out hit, interactDistant))
        {
            hitSomething = true;
            interactable = hit.collider.GetComponent<MouseActions>();
            if (hitSomething && interactable != null)
            {
                interactable._enter?.Invoke();
            }
        }
    }
    public void OnInteract()
    {
        if (hitSomething && interactable != null)
        {
            interactable._interact?.Invoke();
        }
    }
    public void OnMove(InputValue val)
    {
        _move = val.Get<Vector2>();
    }
    public void OnSprint(InputValue val)
    {
        if(val.Get<float>() > 0.5f)
        {
            currentSpeed = sprintSpeed;
        }
        else
        {
            currentSpeed = walkSpeed;
        }
    }
    private void Update()
    {
        _characterController.Move((GetForward() * _move.y + GetRight() * _move.x) * Time.deltaTime * currentSpeed);
        InteractionRay();
    }
    private Vector3 GetForward()
    {
        Vector3 forward = _cinCam.transform.forward;
        forward.y = 0;
        return forward.normalized;
    }

    private Vector3 GetRight()
    {
        Vector3 right = _cinCam.transform.right;
        right.y = 0;
        return right.normalized;
    }
}
