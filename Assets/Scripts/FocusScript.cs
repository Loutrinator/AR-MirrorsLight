using UnityEngine;
using Vuforia;

public class FocusScript : MonoBehaviour
{
    public void Focus()
    {
        CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_INFINITY);
    }

    private void Start()
    {
        VuforiaARController vuforia = VuforiaARController.Instance;
        vuforia.RegisterVuforiaStartedCallback(Focus);
    }
}
