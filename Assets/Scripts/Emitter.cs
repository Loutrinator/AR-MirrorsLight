using UnityEngine;

public class Emitter : MonoBehaviour
{
    public Laser laser;
    
    private void FixedUpdate()
    {
        laser.Recalculate();
    }
}
