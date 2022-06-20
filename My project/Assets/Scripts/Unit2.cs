using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.Threading.Tasks;

public class Unit2 : MonoBehaviour
{
    
    private void Start()
    {
        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        CancellationToken cancellationToken = cancellationTokenSource.Token;
        Task task = Task1(1, cancellationToken);
        Task task2 = WainForFrames(60, cancellationToken);
        Task.WhenAll(task, task2);
    }
    private async Task Task1(int seconds, CancellationToken cancellationToken)
    {
        await Task.Delay((int)(seconds * 1000), cancellationToken);
        Debug.Log("Done");
    }
    private async Task WainForFrames(int Frames, CancellationToken cancellationToken)
    {
        for (int i = 0; i < Frames; i++)
        {
            await Task.Yield();

            if (cancellationToken.IsCancellationRequested) 
            {
                return;
            }
        }
        Debug.Log("60 frames done");
    }
}
