using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class ScrollScript : MonoBehaviour
{
    public ScrollRect scrollView;
    public GameObject scrollContent;
    public GameObject scrollItemPrefab;

    public Text funciona;
    public Text nnum;

    // Start is called before the first frame update
    void Start()
    {
        for(int a = 1; a<=10; a++)
        {
            GenerarItem(a);
        }
        scrollView.verticalNormalizedPosition = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Getnum()
    {
        funciona.text = "99";
    }

    void GenerarItem(int itemNumber)
    {
        GameObject scrollItemObj = Instantiate(scrollItemPrefab);
        scrollItemObj.transform.SetParent(scrollContent.transform, false);
        //scrollItemObj.transform.Find("num").gameObject.GetComponent<Text>().text ="En Mantenimiento " + itemNumber.ToString();
        scrollItemObj.transform.Find("num").gameObject.GetComponent<Text>().text = "En Mantenimiento ";
    }

}
