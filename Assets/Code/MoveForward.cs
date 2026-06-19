using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "MoveForward", menuName = "Scriptable Objects/MoveForward")]
public class MoveForward : ScriptableObject, IInstruction
{
    public float m_distance;

    private IEnumerator Move(Transform target)
    {
        Vector3 initialPosition = target.position;
        float progress = 0f;
        
        while (progress < m_distance)
        {
            progress += Time.deltaTime;
            target.position = initialPosition + target.forward * progress;
            yield return null;
        }
        target.localPosition = initialPosition + m_distance * target.forward;
    }
    

    public IEnumerator ApplyInstruction(Transform transform, float timeToWait)
    {
        yield return Move(transform);
        yield return new WaitForSeconds(timeToWait);
    }
}