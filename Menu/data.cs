using UnityEngine;
using System.Collections;

public class data : MonoBehaviour {

    public GameObject GvrCam;

    public bool CamStateData = false;

    private Vector3 newPosition;
    
    private Color panelBlack = new Color(0, 0, 0, 0.4f);
    private Color panelWhite = new Color(1, 1, 1, 0.2f);

    // Use this for initialization
    void Start()
    {
        GvrCam = GameObject.Find("GvrViewerMain");
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            CamStateData = false;
            GvrCam.transform.position = new Vector3(0, 2f, -10f);
            newPosition = GvrCam.transform.position;
        }

        if (CamStateData == true)
        {
            GvrCam.transform.position = new Vector3(20f, 2f, -10f);
            newPosition = GvrCam.transform.position;
        }

    }

    public void lookAtPanel()
    {
        
        GetComponent<Renderer>().material.color = Color.Lerp(panelBlack, panelWhite, 1);

    }

    public void lookLeavePanel()
    {
        
        GetComponent<Renderer>().material.color = Color.Lerp(panelWhite, panelBlack, 1);

    }

    public void clickPanelData()
    {
        CamStateData = true;
    }

}
