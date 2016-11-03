using UnityEngine;
using System.Collections;

public class CloudCrafter : MonoBehaviour {
   
    public int numClouds = 40; 
    public GameObject[] cloudPrefabs; 
    public Vector3 cloudPosMin; 
    public Vector3 cloudPosMax; 
    public float cloudScaleMin = 1; 
    public float cloudScaleMAx = 5;
    public float cloudSpeedMult = 0.5f; 

    public bool ________________________;

    public GameObject[] cloudInstances;

    void Awake()
    {
        
        cloudInstances = new GameObject[numClouds];
        
        GameObject anchor = GameObject.Find("CloudAnchor");
       
        GameObject cloud;
        for (int i = 0; i < numClouds; i++)
        {
           
            int prefabNum = Random.Range(0, cloudPrefabs.Length);
            
            cloud = Instantiate(cloudPrefabs[prefabNum]) as GameObject;
            
            Vector3 cpos = Vector3.zero;
            cpos.x = Random.Range(cloudPosMin.x, cloudPosMax.x);
            cpos.y = Random.Range(cloudPosMin.y, cloudPosMax.y);
            
            float scaleU = Random.value;
            float scaleVal = Mathf.Lerp(cloudScaleMin, cloudScaleMAx, scaleU);
            
            cpos.y = Mathf.Lerp(cloudPosMin.y, cpos.y, scaleU);
            
            cpos.z = 100 - 90 * scaleU;
            
            cloud.transform.position = cpos;
            cloud.transform.localScale = Vector3.one * scaleVal;
            
            cloud.transform.parent = anchor.transform;
            
            cloudInstances[i] = cloud;
        }
    }

    void Update()
    {
        // Iterate over each cloud that was created
        foreach (GameObject cloud in cloudInstances)
        {
            // Get the cloud scale and position
            float scaleVal = cloud.transform.localScale.x;
            Vector3 cPos = cloud.transform.position;
            // Move larger clouds faster
            cPos.x -= scaleVal * Time.deltaTime * cloudSpeedMult;
            // If a cloud has moved too far to the left...
            if (cPos.x <= cloudPosMin.x)
            {
                // Move it to the far right
                cPos.x = cloudPosMax.x;
            }
            // Apply the new position to cloud
            cloud.transform.position = cPos;
        }
    }
}
