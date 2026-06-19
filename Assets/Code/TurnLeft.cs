using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "TurnLeft", menuName = "Scriptable Objects/TurnLeft")]
public class TurnLeft : ScriptableObject, IInstruction
{
    public float m_rotation = 90;
    public float m_angularVelocity = 180;

    private IEnumerator Turn(Transform target)
    {
        Vector3 initialRotation = target.rotation.eulerAngles;
        float progress = 0f;

        while (progress < Mathf.Abs(m_rotation))
        {
            progress += Time.deltaTime * m_angularVelocity;

            target.rotation = Quaternion.Euler(
                initialRotation.x,
                initialRotation.y + -1 * progress,
                initialRotation.z);

            yield return null;
        }
        target.rotation = Quaternion.Euler(
            initialRotation.x,
            initialRotation.y - m_rotation,
            initialRotation.z);
    }

    public IEnumerator ApplyInstruction(Transform transform, float timeToWait)
    {

        yield return Turn(transform);

        yield return new WaitForSeconds(timeToWait);
    }
}