using UnityEngine;

public abstract class State : MonoBehaviour {

    public virtual string stateName { get { return GetType().Name; } }

    public virtual void Enter()
    {

    }

    public virtual void Exit()
    {

    }
}