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
    public float score;


    public ScoreManager scoreManager;

    private SwitchState state;
    private Renderer renderer;

    private void Start()
    {
        renderer = GetComponent<Renderer>();

        StartCoroutine(BlinkTimeStart(5));

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == bola)
        {
            Toggle();
        }
    }

    private void Set(bool active)
    {
	    
	    if (active == true)
	    {
            state = SwitchState.On;
		    renderer.material = onMaterial;
            StopAllCoroutines();
	    }
        else
	    {
            state = SwitchState.Off;
		    renderer.material = offMaterial;
            StartCoroutine(BlinkTimeStart(5));
	    }
    }

    private void Toggle()
    {
        if (state == SwitchState.On)
        {
            Set(false);
        }
        else
        {
            Set(true);
        }
        scoreManager.AddScore(score);
    }

    private IEnumerator Blink(int times)
    {
        state = SwitchState.Blink;

        for (int i = 0; i < times; i++)
        {
            renderer.material = onMaterial;
            yield return new WaitForSeconds(0.5f);
            renderer.material = offMaterial;
            yield return new WaitForSeconds(0.5f);
        }

        state = SwitchState.Off;
        StartCoroutine(BlinkTimeStart(5));
    }

    private IEnumerator BlinkTimeStart(float time)
    {
        yield return new WaitForSeconds(time);
        StartCoroutine(Blink(2));
    }
}
