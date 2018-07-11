using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSaveMain : MonoBehaviour
{
    public GameObject file1Obj;
    public GameObject file2Obj;
    public GameObject file3Obj;
    public GameObject file4Obj;
    public GameObject file5Obj;

    private Material file1Material;
    private Material file2Material;
    private Material file3Material;
    private Material file4Material;
    private Material file5Material;

    private RenderTexture loadedMap1;
    private RenderTexture loadedMap2;
    private RenderTexture loadedMap3;
    private RenderTexture loadedMap4;
    private RenderTexture loadedMap5;

    private string filePath1 = "D:\\SOS\\Work\\Documents\\test case scans\\clover grass\\QvmG7sfy50yXazkr9awV3g_4K_Diffuse.exr";
    //private string filePath1 = "D:\\SOS\\Work\\Documents\\test case scans\\Soil_Mulch_sfwnbgba\\sfwnbgba_8K_Albedo.exr";
    //"D:\\SOS\\Work\\Documents\\test case scans\\Soil_Mulch_sfwnbgba\\sfwnbgba_8K_Normal.exr";
    //"D:\\SOS\\Work\\Documents\\test case scans\\Soil_Mulch_sfwnbgba\\sfwnbgba_8K_Albedo.exr";
    private string filePath2 = "D:\\SOS\\Work\\Documents\\test case scans\\Grass_rmnkhgp0\\rmnkhgp_4K_Albedo.exr";
    //private string filePath2 = "D:\\SOS\\Work\\Documents\\test case scans\\Soil_Mulch_sfwnbgba\\sfwnbgba_8K_Normal.exr";
    private string filePath3 = "D:\\SOS\\Work\\Documents\\test case scans\\Ground_Forest_sbhit3p0\\sbhit3p_4K_Albedo.exr";
    private string filePath4 = "D:\\SOS\\Work\\Documents\\test case scans\\Ground_Grass_pjwfo0\\pjwfo_4K_Albedo.exr";
    private string filePath5 = "D:\\SOS\\Work\\Documents\\test case scans\\Soil_Mulch_sfwnbgba\\sfwnbgba_8K_Albedo.exr";

    // Use this for initialization
    void Start()
    {
        FreeImageManager.Instance.Test();
        if(file1Obj != null)
        {
            Renderer temp;
            temp = file1Obj.GetComponent<Renderer>();
            if(temp != null)
            {
                file1Material = temp.material;
            }
            temp = null;
            if(file2Obj)
                temp = file2Obj.GetComponent<Renderer>();
            if (temp != null)
            {
                file2Material = temp.material;
            }
            temp = null;
            if (file3Obj)
                temp = file3Obj.GetComponent<Renderer>();
            if (temp != null)
            {
                file3Material = temp.material;
            }
            temp = null;
            if (file4Obj)
                temp = file4Obj.GetComponent<Renderer>();
            if (temp != null)
            {
                file4Material = temp.material;
            }
            temp = null;
            if (file5Obj)
                temp = file5Obj.GetComponent<Renderer>();
            if (temp != null)
            {
                file5Material = temp.material;
            }

        }
    }

    public void CreateRT8K()
    {
        loadedMap1 = new RenderTexture(8192, 8192, 0, RenderTextureFormat.ARGBFloat);
        loadedMap1.Create();
    }
   
    public void LoadImage()
    {
        BrowseWrapper.Instance.Browse(callbackFunction: LoadImageFromDisk,
            browseType: BrowseWrapper.Type.FileOpen, browserTitle: "Choose image to load",
            root: "", extensionFilterPreset: BrowseWrapper.ExtensionFilterPreset.Images, multiSelect: true);
    }

    public void UnloadImage()
    {
        if(loadedMap1 != null)
        {
            file1Material.mainTexture = null;
            loadedMap1.Release();
            Destroy(loadedMap1);
        }
    }

    private void LoadImageFromDisk(string filePath)
    {
        loadedMap1 = FreeImageManager.Instance.LoadImage(filePath, isLinear: false);
        if (loadedMap1 != null && file1Material != null)
        {
            file1Material.mainTexture = loadedMap1;
        }
    }

    public void LoadMultipleImagesFromDisk()
    {
        if (file1Obj != null)
        {
            if(loadedMap1 != null)
            {
                loadedMap1.Release();
                Destroy(loadedMap1);
                loadedMap1 = null;
            }
            loadedMap1 = FreeImageManager.Instance.LoadImage(filePath1, isLinear: false);
            if (loadedMap1 != null && file1Material != null)
            {
                file1Material.mainTexture = loadedMap1;
            }
        }

        if (file2Obj != null)
        {
            loadedMap2 = FreeImageManager.Instance.LoadImage(filePath2, isLinear: false);
            if (loadedMap2 != null && file2Material != null)
            {
                file2Material.mainTexture = loadedMap2;
            }
        }

        if (file3Obj != null)
        {
            loadedMap3 = FreeImageManager.Instance.LoadImage(filePath3, isLinear: false);
            if (loadedMap3 != null && file3Material != null)
            {
                file3Material.mainTexture = loadedMap3;
            }
        }

        if (file4Obj != null)
        {
            loadedMap4 = FreeImageManager.Instance.LoadImage(filePath4, isLinear: false);
            if (loadedMap4 != null && file4Material != null)
            {
                file4Material.mainTexture = loadedMap4;
            }
        }

        if (file5Obj != null)
        {
            loadedMap5 = FreeImageManager.Instance.LoadImage(filePath5, isLinear: false);
            if (loadedMap5 != null && file5Material != null)
            {
                file5Material.mainTexture = loadedMap5;
            }
        }
    }

    public void CollectGarbage()
    {
        System.GC.Collect();
    }

    private void OnApplicationQuit()
    {
        if (loadedMap1 != null)
        {
            loadedMap1.Release();
            Destroy(loadedMap1);
            file1Material.mainTexture = null;
        }
    }
}
