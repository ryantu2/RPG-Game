using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardCodeTesting : MonoBehaviour {

    public Vector2 scr;
    public float xm;
    public float ym;

    //updates a lot of time too
    void OnGUI()
    {
        //box is an image
        //100 by 100, top left
        //GUI.Box(new Rect(0, 0, 100, 100), ""); dont do this
        if (scr.x != Screen.width /16)
        {
            scr.x = Screen.width / 16;
            scr.y = Screen.height / 9;
        }

        //GUI Type | Pos | Start x | Size x,y | Content
        //
        //GUI.Box(new Rect(0, 0, scr.x, scr.y), "");

        for (int i = 0; i < 16; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                GUI.Box(new Rect(scr.x * i, scr.y * j, scr.x, scr.y), "");
            }
        }
    }
}
