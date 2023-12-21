using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheckPoint : MonoBehaviour
{
    public static readonly UnityEvent CheckPointEvent = new UnityEvent();
    // alternative avec event statique pour les portes qui ne sont pas dans la scène dès le début

    private void OnTriggerEnter(Collider other)
    {
        CheckPointEvent.Invoke();
    }
}
