using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Networking;
public class LoadFromFileExample : MonoBehaviour {

	// Use this for initialization
	IEnumerator Start () {
        string dir = "AssetsBundles";
	    string path = dir + "/cube.unity3d";
        //  AssetBundle ab =  AssetBundle.LoadFromFile(dir+"/scene/wall.unity3d");
        //GameObject go =  ab.LoadAsset<GameObject>("Cube");
        //Instantiate(go);
        //Object[] objs = ab.LoadAllAssets();
        //foreach(Object o in objs){
        //    Instantiate(o);
        //}
        //第一种加载AB的方式
        //  AssetBundleCreateRequest request=   AssetBundle.LoadFromMemoryAsync(File.ReadAllBytes(path));
        //第三种
	    //AssetBundleCreateRequest request = AssetBundle.LoadFromFileAsync(path);
     //   yield return request;
     //第四种
	    //while (Caching.ready == false)
	    //{
	    //    yield return null;
	    //}
        ///  file:// file:///本机皆可以
        /// @"file:///C:\Users\woopqww111\Documents\StudyAssetBundle\StudyAssetBundle\AssetsBundles\cube.unity3d"
        //   // WWW www = WWW.LoadFromCacheOrDownload(@"file:///C:\Users\woopqww111\Documents\StudyAssetBundle\StudyAssetBundle\AssetsBundles\cube.unity3d", 1);
        //WWW www = WWW.LoadFromCacheOrDownload(@"http://localhost/AssetBundles/cubewall.unity3d", 1);
        //  yield return www;
        //if (!string.IsNullOrEmpty(www.error))
        //{
        //    Debug.Log(www.error);
        //    yield break;
	    //}
	    ///AssetBundle ab = www.assetBundle;
        //第五种方式 使用UnityWebRequest
      string uri = @"file:///C:\Users\woopqww111\Documents\StudyAssetBundle\StudyAssetBundle\AssetsBundles\cube.unity3d";
	    //string uri = @"http://localhost/AssetBundles/cubewall.unity3d";

       UnityWebRequest request =  UnityWebRequest.GetAssetBundle(uri);
	    yield return request.Send();
        // AssetBundle ab = DownloadHandlerAssetBundle.GetContent(request);
	    AssetBundle ab = (request.downloadHandler as DownloadHandlerAssetBundle).assetBundle;
      //File.WriteAllBytes(request.downloadHandler.data);  
        GameObject go =  ab.LoadAsset<GameObject>("Cube");
	    Instantiate(go);
	    AssetBundle manifestAB=    AssetBundle.LoadFromFile("AssetsBundles/AssetsBundles");
	    AssetBundleManifest manifest = manifestAB.LoadAsset<AssetBundleManifest>("AssetBundleManifest");
	    foreach (string name in manifest.GetAllAssetBundles())
	    {
	     print(name);   
	    }
	 string[] strs =    manifest.GetAllDependencies("cube.unity3d");
	    foreach (string name in strs)
	    {
	        print(name);
	        AssetBundle.LoadFromFile("AssetsBundles/" + name);

	    }
        
	}
    ///// <summary>
    ///// 第二种加载方式
    ///// </summary>
    //void Start()
    //{
    //    string dir = "AssetsBundles";
    //    string path = dir + "/cube.unity3d";
    //    AssetBundle ab = AssetBundle.LoadFromMemory(File.ReadAllBytes(path));
    //    GameObject go = ab.LoadAsset<GameObject>("Cube");
    //    Instantiate(go);
    //}



}
