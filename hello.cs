using System;
using System.Collections.Generic;

namespace BestFirstSearch
{
    class MainClass {
        public static void Main (string[] args) {
            GraphTraversal gt = new GraphTraversal();
            
            //places
            //add_place(place,heuristic value)
            gt.add_place("Cebu City Sports Center",0); // heuristic 0
            gt.add_place("Zapatera Elementary School",.8);
            gt.add_place("St. Peter",1.02);
            gt.add_place("DSWD 7",2.42);
            gt.add_place("Metrobank",2.93);
            gt.add_place("Landers Superstore",2.66);
            gt.add_place("Ayala Terraces",2.31);
            gt.add_place("Quest Hotel",2.24);
            gt.add_place("UP Cebu",2.4);
            gt.add_place("Waterfront Hotel",2.85);
            gt.add_place("Ayala Central Bloc",3.62);
            gt.add_place("Sugbo Mercado",3.65);
            gt.add_place("Apas Barangay Hall",4.21);
            gt.add_place("Marco Polo Plaza",4.52);
            gt.add_place("Oakridge Residences",4.6);
            gt.add_place("5G Coffee",4.25);
            gt.add_place("Gaisano Country Mall",4.62);
            gt.add_place("UC Banilad",4.52);
            gt.add_place("Banilad Town Center",4.86);
            gt.add_place("Coffee Factory",5.12);
            gt.add_place("UV Gullas",4.31);
            gt.add_place("Bright Academy",5.59);
            gt.add_place("USC Talamban",6.03);
            gt.add_place("Family Park",6.63);
            gt.add_place("Grand Mall Talamban",7.46);
            gt.add_place("Time Square Talamban",7.96);
            gt.add_place("Papsys's BBQ",8.25);
            gt.add_place("San Jose Barangay Hall",8.80);
            gt.add_place("Talamban Complex",7.91);
            gt.add_place("Cebu North General Hospital",8.33); 

            //connect edges
            gt.connect("Cebu City Sports Center","Zapatera Elementary School",1);
            gt.connect("Zapatera Elementary School","St. Peter",0.5);
            gt.connect("St. Peter","DSWD 7",2.2);
            gt.connect("DSWD 7","Metrobank",.55);
            gt.connect("DSWD 7","Landers Superstore",1.2);
            gt.connect("Metrobank","Landers Superstore",1.3);
            gt.connect("Landers Superstore","Ayala Terraces",0.55);
            gt.connect("Ayala Terraces","Quest Hotel",75);
            gt.connect("Quest Hotel","UP Cebu",0.75);
            gt.connect("UP Cebu","Waterfront Hotel",1.8);
            gt.connect("Waterfront Hotel","Ayala Central Bloc",1.3);
            gt.connect("Waterfront Hotel","Sugbo Mercado",2.8);
            gt.connect("Sugbo Mercado","Ayala Central Bloc",.24);
            gt.connect("Sugbo Mercado","Apas Barangay Hall",1.1);
            gt.connect("Apas Barangay Hall","Marco Polo Plaza",3.8);
            gt.connect("Apas Barangay Hall","5G Coffee",.19);
            gt.connect("Marco Polo Plaza","Oakridge Residences",2.2);
            gt.connect("Oakridge Residences","5G Coffee",.55);
            gt.connect("5G Coffee","Gaisano Country Mall",1);
            gt.connect("Gaisano Country Mall","Banilad Town Center",.28);
            gt.connect("Gaisano Country Mall","UC Banilad",.042);
            gt.connect("UC Banilad","Banilad Town Center",.4);
            gt.connect("Banilad Town Center","Coffee Factory",.5);
            gt.connect("Coffee Factory","UV Gullas",.8);
            gt.connect("UV Gullas","Bright Academy",.11);
            gt.connect("UV Gullas","Family Park",1.1);
            gt.connect("Bright Academy","USC Talamban",.85);
            gt.connect("USC Talamban","Family Park",.19);
            gt.connect("Family Park","Grand Mall Talamban",1.4);
            gt.connect("Grand Mall Talamban","Time Square Talamban",.7);
            gt.connect("Grand Mall Talamban","Talamban Complex",.65);
            gt.connect("Time Square Talamban","Papsys's BBQ",.45);
            gt.connect("Papsys's BBQ","Talamban Complex",.7);
            gt.connect("Talamban Complex","Cebu North General Hospital",.45);
            gt.connect("Talamban Complex","San Jose Barangay Hall",.65);
            gt.connect("Cebu North General Hospital","San Jose Barangay Hall",.7);
            gt.connect("UC Banilad","DSWD 7",3.2);

            

            //greedy bfs
            Console.WriteLine("Greedy BFS;: ");
            // gt.GreedyBestFirstSearch("cebu north general hospital","cebu city sports center");
            Console.WriteLine();
            //a star
            Console.WriteLine("A star:");
            // gt.myastar("cebu north general hospital","cebu city sports center");

        }
    }
}