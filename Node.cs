//------------------------------------------------------------------------
// 2022 IT-ELAI Introduction to AI
// Topic : Informed Search Algorithms
//------------------------------------------------------------------------
//
// File Name    :   Node.cs
// Class Name:  :   Node 
// Stereotype   :   
//
// Node class:
//  Methods:
//      +AddNeighbors                   - adds a neighbor to the current node
//  Utility:
//  Attributes:
//      +name(string)                   - text name of a place
//      +f(int)                         - holds the f(n)
//      +h(int)                         - holds the h(n)
//      +g(int)                         - holds the g(n)
//      +parent(Node)                   - pointer to the parent
//      +isVisited(bool)                - visited status
//      +neighbors(Linkedlist<Edge>     - list of node's edges/neighbors

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

namespace BestFirstSearch
{
    public class Node
    {
        //---------------------------------------------------------------------
        // Attribute Definition.
        //---------------------------------------------------------------------
        //better to have getters and setters
        private string name;
        private double f;
        private double h;
        private double g;
        private double x_coordinate;
        private double y_coordinate;
        private Node parent;
        private bool isVisited;
        private LinkedList<Edge> neighbors;

        public Node()
        {
            this.f = 0; //other sources prefers setting this to double.MAXVALUE
            this.g = 0;
            this.h = 0;
            this.isVisited = false;
            this.parent = null;
            this.neighbors = new LinkedList<Edge>();
        }

        public Node(double x,double y):this(){
            x_coordinate = x;
            y_coordinate = y;
        }

        //------------------------------------------------------------------------
        //  Method Name : AddNeighbors
        //  Description : adds a neighbor to the current node
        //  Arguments   : Node n
        //                double weight
        //  Return      : void
        //------------------------------------------------------------------------
        public void AddNeighbors(Node n, double weight)
        {
            Edge e = new Edge(n, weight);
            neighbors.AddLast(e);
        }

        public void setName(String name){
            this.name = name;
        }

        public String getName(){
            return this.name;
        }

        public double getXvalue(){
            return this.x_coordinate;
        }

        public double getYvalue(){
            return this.y_coordinate;
        }

        public double getManhattanDistance(Node target){
            return Math.Abs(this.getXvalue() - target.getXvalue()) + Math.Abs(this.getYvalue() - target.getYvalue());
        }

        public void setHvalue(Node target){
            this.h = this.f = getManhattanDistance(target);
        }

        public void setHvalue(double h){
            this.f = h;
            this.h = h;
        }

        public double getHvalue(){
            return this.h;
        }

        public void setGvalue(double g){
            this.g = g;
        }

        public double getGvalue(){
            return this.g;
        }

        public void setFvalue(){
            this.f = this.h;
        }

        public void setFvalue(double g_so_far){
            this.f = this.h + g_so_far;
        }

        public double getFvalue(){
            return this.f;
        }

        public void setParent(Node n){
            this.parent = n;
        }

        public Node getParent(){
            return this.parent;
        }

        public void setIsVisited(bool b){
            this.isVisited = b;
        }

        public bool getIsVisited(){
            return this.isVisited;
        }

        public LinkedList<Edge> getNeighbors(){
            return this.neighbors;
        }
    }
}
//end of file

