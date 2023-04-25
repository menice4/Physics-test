using UnityEngine;

public class Crossbow : MonoBehaviour

{
    public GameObject ArrowPrefab;
    public Transform ArrowLaunch;
    public float ArrowSpeed;
    public float FireRate;
    public float firetimer;

    private Camera cam;
    void Start()
    {
        cam = GetComponentInParent<Camera>();

    }

    // Update is called once per frame
    void Update()
        
    {
        firetimer -= Time.deltaTime;
        if(Input.GetButtonDown("Fire1") && firetimer <= 0f)
        {
            Vector3 middleofScreen = cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 100f));
            ArrowLaunch.LookAt(middleofScreen);

            GameObject arrow = Instantiate(ArrowPrefab, ArrowLaunch.position, ArrowLaunch.rotation);
            arrow.GetComponent<Rigidbody>().velocity = arrow.transform.forward * ArrowSpeed;
            firetimer = FireRate;




        }
    }
}
