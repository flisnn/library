using UnityEngine;
using UnityEngine.Events;
public class MouseActions : MonoBehaviour
{
    public UnityEvent _interact;
    public UnityEvent _enter;
    public UnityEvent _exit;
    public GameObject _object;
    public void PickUp()
    {
        Destroy(_object);
    }
    private void Update()
    {
        _exit?.Invoke();
    }
}
