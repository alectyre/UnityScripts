using UnityEngine;

public abstract class SingletonBehaviour<T> : MonoBehaviour where T : Component
{
    private static T _instance;
    private static bool isShuttingDown;

    public static T instance
    {
        get
        {
            if (_instance == null && !isShuttingDown)
            {
                _instance = new GameObject().AddComponent<T>();
                _instance.name = _instance.GetType().Name;
                DontDestroyOnLoad(_instance.gameObject);
            }
            return _instance;
        }
    }

    protected virtual void OnDestroy()
    {
        isShuttingDown = true;
    }
}
