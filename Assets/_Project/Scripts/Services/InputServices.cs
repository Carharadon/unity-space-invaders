using UnityEngine;

public class InputServices
{
    public float GetHorizontalAxis()
    {
        return Input.GetAxisRaw("Horizontal");
    }

    public bool IsFirePressed()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }
}
