using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementsManager : MonoBehaviour
{
    public OnCollisionDetection collisionDetectionSystem;
    public ParticleSystem foot;
    private int count=0;

    // Start is called before the first frame update
    void Start()
    {
        collisionDetectionSystem.onCollisionEvent.AddListener(unlockCollisionAchievment);
        collisionDetectionSystem.collisionEventWithPosition.AddListener(unlockCollisionAchievmentWithPosition);
        CheckPoint.CheckPointEvent.AddListener(checkPointPass); 
        // alternative avec event statique pour les portes qui ne sont pas dans la sc�ne d�s le d�but
    }

    private void unlockCollisionAchievment()
    {
        Debug.Log("bravo, une collision !");
    }
    private void unlockCollisionAchievmentWithPosition(Vector3 collisionPosition)
    {
        Debug.Log(collisionPosition);
        Instantiate(foot, collisionPosition, transform.rotation * Quaternion.Euler(-90, 0, 0));
    }

    private void checkPointPass()
    {
        count++;
        Debug.Log("passage"+count);
    }
}
