using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotController : MonoBehaviour
{

    public void ApplyFunction()
    {
        StartCoroutine(ProcessInstruction());

    }

    private IEnumerator ProcessInstruction()
    {
        while (_instructionsQueue.Count > 0)
        {
            IInstruction _instruction = _instructionsQueue.Dequeue();
            yield return _instruction.ApplyInstruction(transform, 1f);
        }
    }

    public void MoveForward()
    {
        _instructionsQueue.Enqueue(moveForward);
    }

    public void TurnRight()
    {
        _instructionsQueue.Enqueue(turnRight);
    }

    public void TurnLeft()
    {   
        _instructionsQueue.Enqueue(turnLeft);
    }
    
    private Queue<IInstruction> _instructionsQueue = new();

    [SerializeField] private MoveForward moveForward;
    [SerializeField] private TurnLeft turnLeft;
    [SerializeField] private TurnRight turnRight;
}