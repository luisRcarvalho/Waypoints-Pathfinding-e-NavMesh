using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    /*/Variaveis usadas para waypoints

    //variavel com o transform do objetivo
    //Transform goal;
    //velocidade de locomoção do gameobject
    //float speed = 5.0f;
    // variavel para calcular a distancia para o ponto
    //float accuracy = 1.0f;
    //variavel da velocidade da rotação
    //float rotSpeed = 2.0f;
    /*/

    //variavel da instancia do wpManager
    public GameObject wpManager;
    //pontos que o gameobject ira passar
    GameObject[] wps;
    //variavel da instancia do navmesh agent
    UnityEngine.AI.NavMeshAgent agent;
    /*/codigo de waypoint
    // nó atual
    GameObject currentNode;
    //criando e definindo o ponto atual como 0
    int currentWP = 0;
    //varia da instancia do Graph
    Graph g;
    /*/
    void Start()
    {
        //pegando as variaveis das intancias 
        wps = wpManager.GetComponent<WPManager>().waypoints;
        agent = this.GetComponent<UnityEngine.AI.NavMeshAgent>();
        /*/codigo de waypoint
        g = wpManager.GetComponent<WPManager>().graph;
        definindo o nó atual como 0
        currentNode = wps[0];
        /*/
    }

    // metodo que vai para o botão fazer o tank ir ao helicoptero
    public void GoToHeli()
    {
        agent.SetDestination(wps[9].transform.position);
        /*/codigo de waypoint
        //pega o metodo do graph, onde é passado o ponto atual e o ponto final
        g.AStar(currentNode, wps[9]);
        //ao terminar, define o ponto como 0
        currentWP = 0;
        /*/
    }

    //  metodo que vai para o botão fazer o tank ir ao helicoptero ruinas 
    public void GoToRuin()
    {
        agent.SetDestination(wps[3].transform.position);
        /*/codigo de waypoint
        //pega o metodo do graph, onde é passado o ponto atual e o ponto final
        g.AStar(currentNode, wps[3]);
        //ao terminar, define o ponto como 0
        currentWP = 0;
        /*/
    }
    //metodo que vai para o botão fazer o tank ir a fabrica
    public void GoToFabrica()
    {
        agent.SetDestination(wps[10].transform.position);
        /*/codigo de waypoint
        //pega o metodo do graph, onde é passado o ponto atual e o ponto final
        g.AStar(currentNode, wps[10]);
        //ao terminar, define o ponto como 0
        currentWP = 0;
        /*/
    }

    /*/void LateUpdate() ---> Utilizado para waypoints
    {
        //se o caminho tiver finalizado, ele é zerado
        if (g.getPathLength() == 0 || currentWP == g.getPathLength())
          return;

        //o nó atual é igual ao ponto atual
        currentNode = g.getPathPoint(currentWP);

        //se a distancia do ponto atual para o proximo for menor que o valor setado em accuracy, ele soma mais um no ponto atual
        if (Vector3.Distance(g.getPathPoint(currentWP).transform.position,transform.position) < accuracy)
        {
            currentWP++;
        }

        //se o ponto atual for menor que o caminho
        if (currentWP < g.getPathLength())
        {
            //define o proximo ponto do caminho
            goal = g.getPathPoint(currentWP).transform;
            //ve aonde esta o proximo ponto
            Vector3 lookAtGoal = new Vector3(goal.position.x, this.transform.position.y,goal.position.z);
            //faz a rotação para o proximo ponto
            Vector3 direction = lookAtGoal - this.transform.position; this.transform.rotation = Quaternion.Slerp(this.transform.rotation,Quaternion.LookRotation(direction),Time.deltaTime * rotSpeed);
        }
        //realiza a movimentação do tank ao ponto
        this.transform.Translate(0, 0, speed * Time.deltaTime);
    }
        /*/
}
