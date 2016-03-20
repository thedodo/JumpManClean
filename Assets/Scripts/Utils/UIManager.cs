using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    public bool isSetting = false;
    private bool showSettingsGUI = false; 

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnGUI()
    {
        if (showSettingsGUI)
        {
            GUI.Box(new Rect(10, 10, 120, 70), "Save");
            //GUI.Button();
            if (GUI.Button(new Rect(10, 55, 60, 20), "Save"))
            {

            }
            if (GUI.Button(new Rect(70, 55, 60, 20), "Cancel"))
            {
                Debug.Log("Cancel!");
                showSettingsGUI = false;
            }

        }
    }

    public void OnMouseDown()
    {
        if(isSetting)
        {
            showSettingsGUI = true;
        }
    }

    public void setIsSetting()
    {
        isSetting = true;
    }

}
