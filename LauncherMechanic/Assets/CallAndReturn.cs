using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallAndReturn : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    public bool callHammer;
    public bool throwHammer;
    public Vector3 player;
    public int thrust;
    public Rigidbody2D rb2D;
    public Vector3 hammerStart;
    void Start()
    {
        throwHammer = true;
        callHammer = false;
    }

    // Update is called once per frame
    void Awake()
    {
        hammerStart = transform.position;
    }
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("nothing");
        }
        else if (Input.GetMouseButtonDown(0) && throwHammer == true && callHammer == false)
        {
            //throwingHammer();
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 0;
            Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
            mousePos.x = mousePos.x - objectPos.x;
            mousePos.y = mousePos.y - objectPos.y;
            float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            Vector3 targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPos.z = 0;
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
            Debug.Log("throwing");
            throwHammer = false;
            callHammer = true;
        }
        else if (Input.GetMouseButtonDown(0) && throwHammer == false && callHammer == true)
        {
            //callingHammer();
            transform.position = hammerStart;
            throwHammer = true;
            callHammer = false;
            Debug.Log("calling");
        }
        
    }
    private void throwingHammer()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 0;
        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;
        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        Vector3 targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPos.z = 0;
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
    }
}
