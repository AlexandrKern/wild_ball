using UnityEngine;

public class PauseController : MonoBehaviour
{
    private bool _check;
     
    public void CheckPause()
    {
        _check = !_check;

        if (_check)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}
