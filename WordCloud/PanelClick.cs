using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PanelClick : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OpenWebsite()
    {
        Application.OpenURL("http://www.qgs.io/");

    }

    public void MoveCamera1()
    {
        var graphCam = GameObject.Find("VRMain");

        Vector3 cameraPosition = new Vector3(-15.626f, 31.809f, 14.544f);
        graphCam.transform.position = Vector3.Lerp(transform.position, cameraPosition, Time.deltaTime);
    }

    public void MoveCamera2()
    {
        var graphCam = GameObject.Find("VRMain");

        Vector3 cameraPosition = new Vector3(-39.63f, 10.816f, 1.82f);
        graphCam.transform.position = Vector3.Lerp(transform.position, cameraPosition, Time.deltaTime);
    }

    public void MoveCamera3()
    {
        var graphCam = GameObject.Find("VRMain");

        Vector3 cameraPosition = new Vector3(13.9556f, 33.1601f, -24.12077f);
        graphCam.transform.position = Vector3.Lerp(transform.position, cameraPosition, Time.deltaTime);
    }

    public void HomeScene()
    {
        SceneManager.LoadScene("ThirdView");
    }

    public void LoadGraph()
    {
        SceneManager.LoadScene("FourthView");
    }
}
