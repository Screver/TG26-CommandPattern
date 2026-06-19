using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "TurnLeft", menuName = "Scriptable Objects/TurnLeft")]
public class TurnLeft : ScriptableObject, IInstruction
{
    public float m_rotation = -90;
    
    private IEnumerator Turn(Transform target)
    {
        Quaternion initialRotation = target.rotation;
        float progress = 0f;
        
        while (progress < m_rotation)
        {
            progress += Time.deltaTime;
            target.Rotate(Vector3.up, progress);
            // target.rotation = Quaternion.Lerp(initialRotation, target.rotation, progress);
            yield return null;
        }
    }

    public IEnumerator ApplyInstruction(Transform transform, float timeToWait)
    {
        yield return Turn(transform);
        
        yield return new WaitForSeconds(timeToWait);
    }
}