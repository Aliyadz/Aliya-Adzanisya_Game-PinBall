using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TZoomoutController : MonoBehaviour
{
    public Collider bola;
    public KameraController cameraController;

    private void OnTriggerEnter(Collider other)
    {
        if (other == bola)
        {
             cameraController.GoBackToDefault();
        }
	}
}
