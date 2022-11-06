using System;

namespace BestFirstSearch
{
    class MainClass {
        public static void Main (string[] args) {
            GraphTraversal gt = new GraphTraversal();
            gt.add_place("arad",366);
            gt.add_place("zerind",374);
            gt.add_place("timisoara",329);
            gt.add_place("sibiu",253);
            gt.add_place("oradea",71);
            gt.add_place("fagaras",176);
            gt.add_place("rv",193);
            gt.add_place("pitesti",10);
            gt.add_place("bucharest",0);
            gt.connect("arad","zerind",75);
            gt.connect("arad","timisoara",118);
            gt.connect("zerind","oradea",71);
            gt.connect("arad","sibiu",140);
            gt.connect("sibiu","rv",80);
            gt.connect("sibiu","fagaras",99);
            gt.connect("rv","pitesti",97);
            gt.connect("fagaras","bucharest",211);
            gt.connect("pitesti","bucharest",101);
            gt.astar("arad","bucharest");
        }
    }
}