using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class StateMachine : MonoBehaviour {

    public virtual State CurrentState
    {
        get { return _currentState; }
        set { Transition(value); }
    }

    protected State _currentState;
    protected bool _inTransition;

    public virtual T GetState<T>() where T : State
    {
        T target = GetComponent<T>();
        if (target == null)
            target = gameObject.AddComponent<T>();
        return target;
    }

    public virtual void ChangeState<T>() where T : State
    {
        CurrentState = GetState<T>();
    }

    protected virtual void Transition(State state)
    {
        if (_currentState == state || _inTransition)
            return;

        _inTransition = true;

        if (_currentState != null)
            _currentState.Exit();

        _currentState = state;

        if (_currentState != null)
            _currentState.Enter();

        _inTransition = false;
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(StateMachine))]
public class StateMachineEditor : Editor {

    public override void OnInspectorGUI()
    {
        GUI.enabled = false;
        EditorGUILayout.ObjectField("Script:", MonoScript.FromMonoBehaviour((StateMachine)target), typeof(StateMachine), false);
        GUI.enabled = true;

        StateMachine stateMachine = (StateMachine)target;
        State currentState = stateMachine.CurrentState;
        if (currentState != null)
            EditorGUILayout.LabelField("Current State:", 
                !string.IsNullOrEmpty(currentState.stateName) ? currentState.gameObject.name : currentState.GetType().Name);
        else
            EditorGUILayout.LabelField("Current State:", "None");
    }
}
#endif