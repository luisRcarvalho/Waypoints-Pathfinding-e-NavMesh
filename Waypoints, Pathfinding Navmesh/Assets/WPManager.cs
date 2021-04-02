using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public struct Link
{
    public enum direction { UNI, BI }
    public GameObject node1;
    public GameObject node2;
    public direction dir;
}

public class WPManager : MonoBehaviour
{
    //Pontos que vai percorrer
    public GameObject[] waypoints;

    //Links dos pontos
    public Link[] links;

    //Instancia do Graph
    public Graph graph = new Graph();


    void Start()
    {
        //Verificação se o array nao está vazio
        if (waypoints.Length > 0)
        {
            //vai localizar quantos objetos tem no array
            foreach (GameObject wp in waypoints)
            {
                //e adiciona um nó pra cada objeto
                graph.AddNode(wp);
            }

            //vai localizar quantos objetos tem no array
            foreach (Link l in links)
            {
                //utiliza o metodo do graph para adicionar um ed
                graph.AddEdge(l.node1, l.node2);
                //verifica se a direção é igual BI
                if (l.dir == Link.direction.BI)
                    //utiliza o metodo do graph para adicionar um edge
                    graph.AddEdge(l.node2, l.node1);
            }
        }
    }
    void Update()
    {
        graph.debugDraw();
    }
}

