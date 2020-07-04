using UnityEngine;
using UnityEngine.Events;

public class SimpleTrigger : MonoBehaviour {
    [SerializeField] LayerMask layermask;
    [Space]
    [SerializeField] UnityEvent OnEnter;
    [SerializeField] UnityEvent OnExit;

    private void OnCollisionEnter(Collision collision)
    {
        if (OnEnter != null &&
            layermask == (layermask | (1 << collision.gameObject.layer)))
        {
            OnEnter.Invoke();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (OnEnter != null &&
            layermask == (layermask | (1 << other.gameObject.layer)))
        {
            Debug.Log("trigger enter " + gameObject.name);

            OnEnter.Invoke();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (OnExit != null &&
            layermask == (layermask | (1 << collision.gameObject.layer)))
        {
            OnExit.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (OnExit != null &&
            layermask == (layermask | (1 << other.gameObject.layer)))
        {
            Debug.Log("trigger exit " + gameObject.name);

            OnExit.Invoke();
        }
    }
}
