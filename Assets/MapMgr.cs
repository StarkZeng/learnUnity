using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMgr : MonoBehaviour {

	// Use this for initialization
	void Start () {

        GameObject obj = new GameObject();
        SpriteRenderer spRender =  obj.AddComponent<SpriteRenderer>();
        Sprite[] spList = Resources.LoadAll<Sprite>("");
        Debug.Log(spList.Length);
        spRender.sprite = spList[0];

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
