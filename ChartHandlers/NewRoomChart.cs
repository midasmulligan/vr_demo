using UnityEngine;
using System.Collections;
using CP.ProChart;

public class NewRoomChart : MonoBehaviour {

    public      BarChart         Dat2LineChart;
    ChartData2D dataSet          = new ChartData2D();      

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Dat2LineChart.SetValues(ref dataSet);
	}

    public void OnSelectDelegate (int row, int column)
    {

    }

    public void OnOverDelegate (int row, int column)
    {

    }

    void onEnable()
    {
        Dat2LineChart.onSelectDelegate += OnSelectDelegate;
        Dat2LineChart.onOverDelegate += OnOverDelegate;
    }

    void onDisable()
    {
        Dat2LineChart.onSelectDelegate -= OnSelectDelegate;
        Dat2LineChart.onOverDelegate -= OnOverDelegate;
    }

    void Dat2ChartData ()
    {
        dataSet[0, 0]   = 50;
        dataSet[1, 1]   = 30;
        dataSet[2, 2]   = 70;
        dataSet[3, 3]   = 60;
        dataSet[4, 4]   = 20;
        dataSet[5, 5]   = 50;
        dataSet[6, 6]   = 90;
        dataSet[7, 7]   = 100;
        dataSet[8, 8]   = 80;
        dataSet[9, 9]   = 25;
        dataSet[10, 10]  = 40;
    }
}
