using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnCollisionDetection : MonoBehaviour
{
    public UnityEvent onCollisionEvent;
    public collisionEventWithPosition collisionEventWithPosition;



    private void Awake()
    {
        onCollisionEvent = new UnityEvent(); // dans le awake pour que ça soit bien avant les abonnements 
        collisionEventWithPosition = new collisionEventWithPosition();
    }

    private void OnCollisionEnter(Collision collision)
    {
        onCollisionEvent.Invoke();
        collisionEventWithPosition.Invoke(transform.position);
    }
}

public class collisionEventWithPosition : UnityEvent<Vector3>
{

}


