﻿#region Header
using UnityEngine;
using System.Collections;
#endregion Header

#region Methods
public class data : MonoBehaviour {

    public   GameObject   GvrCam;
    public   bool         CamStateData = false;
    public   bool         CamStateHome = false;
    public   bool         CamStateWord = false;
    private  Vector3      homePosition = new Vector3(0, 2f, -10f);
    
    private  Color        panelBlack   = new Color(0, 0, 0, 0.4f);
    private  Color        panelWhite   = new Color(1, 1, 1, 0.2f);

    void Start()
    {
        GvrCam = GameObject.Find("GvrViewerMain");
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            CamStateData = false;
            CamStateWord = false;
            GvrCam.transform.position = homePosition;

        }

        if (CamStateData == true)
        {
            CamStateWord = false;
            CamStateHome = false;
            GvrCam.transform.position = new Vector3(-800f, 2f, -10f);
        }
        
        if (CamStateWord == true)
        {
            CamStateData = false;
            CamStateHome = false;
            GvrCam.transform.position = homePosition;
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

    #region Click Methods
    public void clickPanelData()
    {
        CamStateData = true;
    }
    public void panelClickHome()
    {
        CamStateHome = true;
    }
    public void clickPanelWord()
    {
        CamStateWord = true;
    }
    #endregion Click Methods

}
#endregion Methods