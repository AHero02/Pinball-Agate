using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{

    private enum SwitchState
    {
        Off,
        On,
        Blink
    }
    public Collider bola;

    public Material offMaterial;
    public Material onMaterial;

    private bool isOn;
    private SwitchState state;
    private Renderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();

        Set(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other == bola)
        {
            Set(!isOn);
        }
    }

    private void Set(bool active)
    {
        isOn = active; 
        if(isOn == true)
        {
            renderer.material = onMaterial;
        }
        else
        {
            renderer.material = offMaterial;
        }
    }

    private void Toogle()
    {
        if(state == SwitchState.On)
        {
            Set(false );
        }
        else
        {
            Set(true);
        }
    }

    private IEnumerator Blink(int times)
    {
        state = SwitchState.Blink;

        for(int i = 0; i < times; i++)
        {
            renderer.material = onMaterial;
            yield return new WaitForSeconds(0.5f);
            renderer.material = offMaterial;
            yield return new WaitForSeconds(0.5f);
        }
        state = SwitchState.Off;

        StartCoroutine(BlinkTimerStart(5));
    }

    private IEnumerator BlinkTimerStart(float time)
    {
        yield return new WaitForSeconds(time);
        StartCoroutine(Blink(2));
    }
}
