using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
  

    private Root root;
    [SerializeField] Transform clientListContainer;
    [SerializeField] GameObject clientData;
    List<ClientDataHandeler> listOfClients=new List<ClientDataHandeler>(); //List to keep track of which objets are currently in scene
   



   
    //get Data From Api 
    //Listn to Event
   public void GetClinteInfo(Component sender,object data)
   {
        this.root=(Root)data;
        showClints();

   }


   void showClints()
   {
        //if there is already Objects destroy them
        DestroyAll();
        int length=root.clients.Count;
        //go through all Clints in root
        for (int i=0;i<length;i++)
        {
            ClientDataHandeler dataHandeler=Instantiate(clientData,clientListContainer).GetComponent<ClientDataHandeler>();
            //send the Root and index
            dataHandeler.ChooseClint(root, i);
            //add it in the list
            listOfClients.Add(dataHandeler);
            

        }
   }


    //Filter from dorpdown
   public void showClints(int val)
   {
        if(val==0)
        {
           showClints();
        }else if(val==1)
        {
            DestroyAll();
            int length=root.clients.Count;
            //go through all Clints in root
            for (int i=0;i<length;i++)
            {
                //if not manager return
                if(!root.clients[i].isManager) return;
                ClientDataHandeler dataHandeler=Instantiate(clientData,clientListContainer).GetComponent<ClientDataHandeler>();

                //send the Root and index
                dataHandeler.ChooseClint(root, i);
                //add it in the list
                listOfClients.Add(dataHandeler);

            }
          
        }else if(val==2){
            DestroyAll();
            
            int length=root.clients.Count;
            //go through all Clints in root
            for (int i=0;i<length;i++)
            {
                //if not manager return
                if(root.clients[i].isManager) return;
                ClientDataHandeler dataHandeler=Instantiate(clientData,clientListContainer).GetComponent<ClientDataHandeler>();

                //send the Root and index
                dataHandeler.ChooseClint(root, i);
                //add it in the list
                listOfClients.Add(dataHandeler);

            }
        }
   }

   void DestroyAll()
   {
     ClientDataHandeler temp;
     int length=listOfClients.Count;

     for(int i=length-1;i>=0;i--)
     {
           temp=(listOfClients[i]);
           listOfClients.Remove(temp);
           Destroy(temp.gameObject);
     }
       
   }

    //Button click exit
    public void OnClickExit()
    {
        Application.Quit();
    }

}
