using UnityEngine;
// UnityEngine UI is a library for FloatingText
using UnityEngine.UI;

public class FloatingText
{
    public bool active;
    public GameObject go;
    public Text txt;
    public Vector3 motion;
    public float duration;
    public float lastShown;

    
    public void Show()
    {
        active = true; 
        lastShown = Time.time; 
        go.SetActive(active);
    }

    public void Hide()
    {
        active = false;
        go.SetActive(active);
    }

    public void UpdateFloatingText()
    {
        if (!active)
        {
            return;
        }
        // Duration is a int variable to make sure the floatingtext isn't going to last forever
        if (Time.time - lastShown > duration)
        {
            Hide();
        }
        go.transform.position += motion * Time.deltaTime;
    }
}
