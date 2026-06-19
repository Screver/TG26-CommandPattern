using System.Collections;
using UnityEngine;

public interface IInstruction
{
    public IEnumerator ApplyInstruction(Transform transform, float timeToWait);
}