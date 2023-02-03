using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenFood : MonoBehaviour
{
    public float minDelay = 1f;
    public float maxDelay = 3f;

    public float GetMaxDelay()
    {
        return maxDelay;
    }

    public float GetMinDelay()
    {
        return minDelay;
    }
}
