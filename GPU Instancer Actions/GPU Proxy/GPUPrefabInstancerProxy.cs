using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GPUInstancer
{
public class GPUPrefabInstancerProxy : MonoBehaviour
{
    
     public GPUInstancerPrefabManager prefabManager;

     [HideInInspector]
     public GPUInstancerPrefab [] asteroidObjects;

     [HideInInspector]
     public string TagName;

     [HideInInspector]
    public GameObject objectname;
    
     [HideInInspector]
    GPUInstancerPrefab destroy;

    [HideInInspector]
    GPUInstancerPrefab toInstanncer;

    public void Execute()
    {
        
        GPUInstancerAPI.RegisterPrefabInstanceList(prefabManager, asteroidObjects);
        GPUInstancerAPI.InitializeGPUInstancer(prefabManager);
    }

    public void Add(){
        GameObject[] bodies;
        //GPUInstancerPrefab[] asteroidObjects;
         bodies = GameObject.FindGameObjectsWithTag (TagName);
         asteroidObjects = new GPUInstancerPrefab[bodies.Length];

      for(int i = 0; i < bodies.Length; i++){
      asteroidObjects[i] = bodies[i].GetComponent<GPUInstancerPrefab> ();
 }
        Execute();
    }

    public void Destroy(){
       destroy = objectname.GetComponent<GPUInstancerPrefab>();
        GPUInstancerAPI.RemovePrefabInstance(prefabManager,destroy);
    }


    public void AddPrefab (){
       toInstanncer = objectname.GetComponent<GPUInstancerPrefab>();
       GPUInstancerAPI.AddPrefabInstance(prefabManager,toInstanncer);
    }
   
}
}
