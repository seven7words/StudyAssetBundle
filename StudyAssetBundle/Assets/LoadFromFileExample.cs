using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Networking;
public class LoadFromFileExample : MonoBehaviour {

	// Use this for initialization
	void Start () {
        string dir = "AssetsBundles";
        AssetBundle ab =  AssetBundle.LoadFromFile(dir+"/scene/wall.unity3d");
        //GameObject go =  ab.LoadAsset<GameObject>("Cube");
        //Instantiate(go);
        Object[] objs = ab.LoadAllAssets();
        foreach(Object o in objs){
            Instantiate(o);
        }
	}

	

}
