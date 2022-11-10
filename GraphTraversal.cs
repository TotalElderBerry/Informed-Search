//------------------------------------------------------------------------
// 2022 IT-ELAI Introduction to AI
// Topic : Informed Search Algorithms
//------------------------------------------------------------------------
//
// File Name    :   GraphTraversal.cs
// Class Name:  :   GraphTraversal 
// Stereotype   :   
//
// GraphTraversal class:
//  Methods:
//      +add_place                       - Add a place in string format.
//      +connect                         - Connect one vertex to another vertex.
//      +displayAdjacencyList            - Display adjacency list.
//      +GreedyBestFirstSearch           - Traverse the map using Greedy best first search
//      +astar                           - Traverse the map using A*
//      
//  Utility:
//      -getNodeByName                   - search the map using the string name
//      -reconstruct_path                - reconstruct the solution/path
//      -getLowestFscore                 - get the lowest f(n) in the a list of Node
//      -solveHeuristic                  - get the heuristic value from the current Node to the goal Node
//  Attributes:
//      -graph(LinkedList<Node>)         - Number of places/vertices in the map.

//------------------------------------------------------------------------
// Notes:
//   Comment character code - UTF-8.
//------------------------------------------------------------------------
//  Change Activities:
// tag  Reason   Ver  Rev Date       Author      Description.
//------------------------------------------------------------------------
// $000 -------  0.1  001 2022-11-5 cabrillosa  First Release.
using System;
using System.Collections.Generic;
using System.Linq;

namespace BestFirstSearch
{
    public class GraphTraversal
    {
        //---------------------------------------------------------------------
        // Attribute Definition.
        //---------------------------------------------------------------------
        private LinkedList<Node> graph;

        //------------------------------------------------------------------------
        //  Method Name : GraphTraversal
        //  Description : Constructor. Initialize the need attributes.
        //  Arguments   : void.
        //  Return      : void.
        //------------------------------------------------------------------------
        public GraphTraversal()
        {
            //initialize the graph
            graph = new LinkedList<Node>();
        }

        //------------------------------------------------------------------------
        //  Method Name : add_place
        //  Description : Adds a place in string format and h(n) straight line distance.
        //  Arguments   : String place
        //                int h (h param should be pre-computed!)
        //  Return      : void
        //------------------------------------------------------------------------
        public void add_place(string place, double h)
        {
            place = place.ToLower();
            Node n = new Node();
            n.setName(place);
            n.setHvalue(h);
            graph.AddLast(n);

        }

        public void add_place(string place, double x, double y)
        {
            place = place.ToLower();
            Node n = new Node(x,y);
            n.setName(place);
            graph.AddLast(n);
        }
        
        //------------------------------------------------------------------------
        //  Method Name : connect
        //  Description : Connect one vertex to another vertex with specified weight
        //  Arguments   : string v1
        //                string v2
        //                int dist
        //  Return      : 0 (OK)
        //               -1 (NG - place is not in the list)
        //------------------------------------------------------------------------
        public int connect(string place1, string place2, double dist)
        {
            place1 = place1.ToLower();
            place2 = place2.ToLower();
            Node n1 = getNodeByName(place1);
            Node n2 = getNodeByName(place2);

            if (n1 == null || n2 == null)
            {
                return -1;
            }

            n1.AddNeighbors(n2, dist);
            n2.AddNeighbors(n1, dist);

            return 0;
        }

        //------------------------------------------------------------------------
        //  Method Name : displayAdjacencyList
        //  Description : Display adjacency list.
        //  Arguments   : None.
        //  Return      : None.
        //------------------------------------------------------------------------
        public void displayAdjacencyList()
        {
            LinkedList<Node>.Enumerator iterator = graph.GetEnumerator();

            while (iterator.MoveNext())
            {
                Console.Write(iterator.Current.getName() +"::");
                LinkedList<Edge>.Enumerator edges = iterator.Current.getNeighbors().GetEnumerator();

                while(edges.MoveNext())
                {
                    Console.Write(edges.Current.getNode().getName()+ " -> ");
                }
                Console.WriteLine(); 
            }
        }

        //------------------------------------------------------------------------
        //  Method Name : GreedyBestFirstSearch
        //  Description : Traverse the map using Greedy Best First Search
        //  Arguments   : string start_place
        //                string goal_place
        //  Return      : Void
        //------------------------------------------------------------------------
        public void GreedyBestFirstSearch(string start_place, string goal_place)
        {
            solveHeuristic(goal_place);
            start_place = start_place.ToLower();
            Node start = getNodeByName(start_place);
            if(start == null){
                Console.WriteLine("Place not found");
                return; //start place not found
            } 

            //openlist -> list of unexpanded nodes
            //closelist -> list of already expanded nodes
            LinkedList<Node> openlist = new LinkedList<Node>();
            LinkedList<Node> closedlist = new LinkedList<Node>();

            openlist.AddLast(start);

            //explore unexpanded nodes
            while(openlist.Count > 0){

                //choose the best node to expand
                start = getLowestFscore(openlist);

                //goal found
                if(start.getName() == goal_place){
                    reconstruct_path(start);
                    return;
                }
                
                LinkedList<Edge>.Enumerator edges = start.getNeighbors().GetEnumerator(); 
                
                //for every Neighbors temp_n of Parent start
                while(edges.MoveNext()){
                    Node temp_n = edges.Current.getNode();
                    
                    //check whether the Neighbor n has already been expanded
                    if(!closedlist.Contains(temp_n)){
                        temp_n.setParent(start);
                        openlist.AddFirst(temp_n);    
                    }
                }

                //move the current node from openlist to closedlist
                //meaning that the node has been expanded
                openlist.Remove(start);    
                closedlist.AddFirst(start);
            }
            Console.WriteLine("No Path");
        }

        //------------------------------------------------------------------------
        //  Method Name : astar
        //  Description : Traverse the map using A*
        //  Arguments   : string start_place
        //                string goal_place
        //  Return      : Void
        //------------------------------------------------------------------------
        public void myastar(string start_place,string goal_place){
                solveHeuristic(goal_place);
                start_place = start_place.ToLower();
                Node start = getNodeByName(start_place);
                if(start == null) {
                    Console.WriteLine("Place not found");
                    return; //start place not found
                } 


                //openlist -> list of unexpanded nodes
                //closelist -> list of already expanded nodes
                LinkedList<Node> openlist = new LinkedList<Node>();
                LinkedList<Node> closedlist = new LinkedList<Node>();
                

                openlist.AddFirst(start);

                //explore unexpanded nodes
                while(openlist.Count > 0){
                  
                    //choose the best node to expand
                    start = getLowestFscore(openlist);

                    //goal found
                    if(start.getName() == goal_place){
                        reconstruct_path(start);
                        return;
                    }

                    LinkedList<Edge>.Enumerator neighbors = start.getNeighbors().GetEnumerator();

                    //for every Neighbors n of Parent start
                    while(neighbors.MoveNext()){
                        Node n = neighbors.Current.getNode();
                        double g_so_far = start.getGvalue() + neighbors.Current.getWeight();
                        n.setGvalue(g_so_far);
                        n.setFvalue(g_so_far);

                        //check whether the Neighbor n has already been expanded
                        if(!closedlist.Contains(n)){
                            n.setParent(start);
                            openlist.AddFirst(n);    
                        }
                    }

                    //move the current node from openlist to closedlist
                    //meaning that the node has been expanded
                    openlist.Remove(start);
                    closedlist.AddFirst(start);
                } 
                Console.WriteLine("No path");    
        }   


        // ----------------------
        //  UTILITY FUNCTIONS
        //-----------------------

        //------------------------------------------------------------------------
        //  Method Name : getNodeByName
        //  Description : get the node by its name
        //  Arguments   : string name
        //  Return      : Node, if name is found
        //                null, if name is not found
        //------------------------------------------------------------------------
        private Node getNodeByName(string name)
        {
            name = name.ToLower();
            LinkedList<Node>.Enumerator iterator = graph.GetEnumerator();

            while(iterator.MoveNext()) //n = n.next
            {
                Node n = iterator.Current;

                if(n.getName() == name)
                {
                    //string is in the graph, return!
                    return n;
                }
            }

            return null;
        }

        //------------------------------------------------------------------------
        //  Method Name : reconstruct_path
        //  Description : reconstruct the path from goal to start
        //  Arguments   : string name
        //  Return      : Node, if name is found
        //                null, if name is not found
        //------------------------------------------------------------------------
        private void reconstruct_path(Node path)
        {
            LinkedList<Node> nodes = new LinkedList<Node>();
           

          while(path != null)
            {
                nodes.AddFirst(path);
                path = path.getParent();
            }

            LinkedList<Node>.Enumerator temp = nodes.GetEnumerator();

            while(temp.MoveNext())
            {
                Console.Write(temp.Current.getName() + "->");
            }
            Console.WriteLine();

        }

        //------------------------------------------------------------------------
        //  Method Name : getLowestFscore
        //  Description : gets the lowest f(n) in a given list of nodes
        //  Arguments   : LinkedList<Node> list
        //  Return      : Node with lowest fscore
        //------------------------------------------------------------------------
        private Node getLowestFscore(LinkedList<Node> list)
        {
            LinkedList<Node>.Enumerator iterator = list.GetEnumerator();

            iterator.MoveNext();
            Node lowest = iterator.Current;

            while(iterator.MoveNext())
            {
                if(lowest.getFvalue() > iterator.Current.getFvalue())
                {
                    lowest = iterator.Current;
                }
            }
            return lowest;
        }

        //------------------------------------------------------------------------
        //  Method Name : solveHeuristic
        //  Description : Computes the heuristic value from the current state to the targe
        //  Arguments   : String target_place
        //  Return      : void
        //------------------------------------------------------------------------
        private void solveHeuristic(string target_place){
            target_place = target_place.ToLower();
            Node target = getNodeByName(target_place);
            LinkedList<Node>.Enumerator iterator = graph.GetEnumerator();
            while(iterator.MoveNext()){
                Node start = iterator.Current;
                start.setHvalue(target);
            }
        }
    }
}

//end of file

