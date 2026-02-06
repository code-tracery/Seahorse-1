using UnityEngine;

public class FrameRateLimit : MonoBehaviour
{
    public enum Limits
    {
        noLimit = 0,
        limit30 = 30,
        limit60 = 60,
    }

    public Limits limit;

    private void Awake()
    {
        Application.targetFrameRate = (int)limit;
    }

}
