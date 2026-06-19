using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "TurnRight", menuName = "Scriptable Objects/TurnRight")]
public class TurnRight : ScriptableObject, IInstruction
{
    private void Turn(Transform target)
    {
        target.Rotate(Vector3.up, 90);
    }

    public IEnumerator ApplyInstruction(Transform transform, float timeToWait)
    {
        Turn(transform);

        yield return new WaitForSeconds(timeToWait);
    }
}