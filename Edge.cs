//------------------------------------------------------------------------
// 2022 IT-ELAI Introduction to AI
// Topic : Informed Search Algorithms
//------------------------------------------------------------------------
//
// File Name    :   Edge.cs
// Class Name:  :   Edge 
// Stereotype   :   
//
// Edge class:
//  Methods:
//  Utility:w
//  Attributes:
//      +weight(int)         - Weight from the parent node.
//      +node(Node)          - Node connected to the parent

//------------------------------------------------------------------------
// Notes:
//   Comment character code - UTF-8.
//------------------------------------------------------------------------
//  Change Activities:
// tag  Reason   Ver  Rev Date       Author      Description.
//------------------------------------------------------------------------
// $000 -------  0.1  001 2022-11-5 cabrillosa  First Release.
using System;
namespace BestFirstSearch
{
    public class Edge
    {
        //---------------------------------------------------------------------
        // Attribute Definition.
        //---------------------------------------------------------------------
        //should have getters and setters
        private int weight;
        private Node node;

        //------------------------------------------------------------------------
        //  Method Name : Edge
        //  Description : Constructor. Initialize the need attributes.
        //  Arguments   : Node n
        //                int weight
        //  Return      : void.
        //------------------------------------------------------------------------
        public Edge(Node n, int weight)
        {
            this.weight = weight;
            this.node = n;
        }

        public void setWeight(int weight){
            this.weight = weight;
        }

        public int getWeight(){
            return this.weight;
        }

        public void setNode(Node n){
            this.node = n;
        }
        public Node getNode(){
            return this.node;
        }
    }
}
//end of file
