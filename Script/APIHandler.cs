using System.Net;
using System.IO;
using UnityEngine;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;

public class APIHandler : MonoBehaviour
{
     public static APIHandler instance;
     [SerializeField] UIManager ui;
     [SerializeField] GameEvent gotRootData;
     [SerializeField] Root root;




     void Awake()
     {
          instance=this;
          
     }

     void Start()
     {
          GetApi();
     }







   public  void GetApi()
   {
        HttpWebRequest request=(HttpWebRequest)WebRequest.Create("https://qa2.sunbasedata.com/sunbase/portal/api/assignment.jsp?cmd=client_data");
        HttpWebResponse response=(HttpWebResponse)request.GetResponse();
        StreamReader reader=new StreamReader(response.GetResponseStream());

        string json =reader.ReadToEnd();
        Root jsonData = JsonConvert.DeserializeObject<Root>(json);
        root=jsonData;
     // raise event and let other know
        gotRootData.Raise(this,jsonData);
   }

   void Update()
   {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GetApi();
        }
   }

  
}
