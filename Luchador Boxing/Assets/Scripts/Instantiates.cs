using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiates : MonoBehaviour {

    public Object PlayerPrefab;
    public Object AiPrefab;

    private void Awake ()
    {
     
        Instantiate(PlayerPrefab, new Vector3(-5.05f, -1.5f, 6.842743f), Quaternion.Euler(0, 0, 0));
        Instantiate(AiPrefab, new Vector3(6.5f, -1.83f, 6.842743f), Quaternion.Euler(0, 0, 0));

	}
	

}
