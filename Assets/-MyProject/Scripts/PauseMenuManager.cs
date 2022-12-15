using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuManager : MonoBehaviour
{
    private GameObject PauseMenuPanel;
    // Start is called before the first frame update
    void Start()
    {
        PauseMenuPanel = GameObject.Find("PauseMenuCanvas");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vHeadPos = Camera.main.transform.position;
        Vector3 vGazeDir = Camera.main.transform.forward;
        PauseMenuPanel.transform.position = (vHeadPos + vGazeDir * 2.0f) + new Vector3(0.0f, -.40f, 0.0f);
        Vector3 vRot = Camera.main.transform.eulerAngles; vRot.z = 0;
        PauseMenuPanel.transform.eulerAngles = vRot;
    }
}
