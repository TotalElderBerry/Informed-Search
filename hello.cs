using System;
using System.Collections.Generic;

namespace BestFirstSearch
{
    class MainClass {
        public static void Main (string[] args) {
            GraphTraversal gt = new GraphTraversal();
            
            //places
            //add_place(place,lat,long)
            gt.add_place("Cebu City Sports Center",10.300473258744963, 123.89521345049); // heuristic 0
            gt.add_place("Zapatera Elementary School",10.30342890415081, 123.90173658279558);
            gt.add_place("St. Peter",10.304842838885044, 123.90374830062771);
            gt.add_place("DSWD 7",10.31365420297771, 123.9133464122676);
            gt.add_place("Metrobank",10.316461400495237, 123.91722766808745);
            gt.add_place("Landers Superstore",10.320327825522142, 123.90985882761167);
            gt.add_place("Ayala Terraces",10.318936645006398, 123.90593465581895);
            gt.add_place("Quest Hotel",10.319394764392595, 123.90304897361023);
            gt.add_place("UP Cebu",10.322305865721615, 123.89819663802805);
            gt.add_place("Waterfront Hotel",10.32480300743314, 123.90450027360997);
            gt.add_place("Ayala Central Bloc",10.33069098785508, 123.90732046747588);
            gt.add_place("Sugbo Mercado",10.332180261474713, 123.9060533067384);
            gt.add_place("Apas Barangay Hall",10.337522140962518, 123.90453440530622);
            gt.add_place("Marco Polo Plaza",10.341688993768013, 123.89749737116338);
            gt.add_place("Oakridge Residences",10.341046482426083, 123.90477093250587);
            gt.add_place("5G Coffee",10.33806554728433, 123.9056679852669);
            gt.add_place("Gaisano Country Mall",10.339503445552621, 123.91098516747601);
            gt.add_place("UC Banilad",10.338471106936128, 123.9119316263716);
            gt.add_place("Banilad Town Center",10.340930806846618, 123.91275886747594);
            gt.add_place("Coffee Factory",10.343195508485637, 123.91375459692412);
            gt.add_place("UV Gullas",10.336840584983879, 123.9112393257598);
            gt.add_place("Bright Academy",10.34781032411857, 123.91426039692371);
            gt.add_place("USC Talamban",10.352153835011382, 123.91325684904876);
            gt.add_place("Family Park",10.354954987073759, 123.91459308526713);
            gt.add_place("Grand Mall Talamban",10.366141337260789, 123.91374462576);
            gt.add_place("Time Square Talamban",10.369536850325836, 123.91844782576013);
            gt.add_place("Papsys's BBQ",10.371197228106535, 123.92166946808807);
            gt.add_place("San Jose Barangay Hall",10.379000372180425, 123.91654198343228);
            gt.add_place("Talamban Complex",10.3700771820755, 123.91666046808804);
            gt.add_place("Cebu North General Hospital",10.373131855776535, 123.91441806702308); 

            //connect edges
            gt.connect("Cebu City Sports Center","Zapatera Elementary School",1);
            gt.connect("Cebu City Sports Center","Quest Hotel",3.3);
            gt.connect("Zapatera Elementary School","St. Peter",0.5);
            gt.connect("St. Peter","DSWD 7",2.2);
            gt.connect("St. Peter","Ayala Terraces",3);
            gt.connect("DSWD 7","Metrobank",.55);
            gt.connect("Landers Superstore","Ayala Terraces",0.55);
            gt.connect("Landers Superstore","UC Banilad",3.9);
            gt.connect("Ayala Terraces","UC Banilad",2.6);
            gt.connect("Ayala Terraces","Waterfront Hotel",1.8);
            gt.connect("Ayala Terraces","Quest Hotel",0.55);
            gt.connect("UP Cebu","Sugbo Mercado",2.3);
            gt.connect("Waterfront Hotel","Ayala Central Bloc",1.3);
            gt.connect("Sugbo Mercado","Ayala Central Bloc",.24);
            gt.connect("Sugbo Mercado","Apas Barangay Hall",1);
            gt.connect("Apas Barangay Hall","Marco Polo Plaza",3.8);
            gt.connect("Apas Barangay Hall","5G Coffee",.19);
            gt.connect("Oakridge Residences","5G Coffee",.6);
            gt.connect("Oakridge Residences","Gaisano Country Mall",1.1);
            gt.connect("Gaisano Country Mall","Banilad Town Center",.28);
            gt.connect("Gaisano Country Mall","UC Banilad",.042);
            gt.connect("UC Banilad","Banilad Town Center",.4);
            gt.connect("Banilad Town Center","Coffee Factory",.5);
            gt.connect("Banilad Town Center","UV Gullas",1.1);
            gt.connect("UV Gullas","Bright Academy",.11);
            gt.connect("Bright Academy","USC Talamban",.85);
            gt.connect("USC Talamban","Family Park",.19);
            gt.connect("Family Park","Grand Mall Talamban",1.4);
            gt.connect("Grand Mall Talamban","Talamban Complex",.65);
            gt.connect("Talamban Complex","Time Square Talamban",.22);
            gt.connect("Talamban Complex","Cebu North General Hospital",.45);
            gt.connect("Cebu North General Hospital","San Jose Barangay Hall",.7);
            gt.connect("Time Square Talamban","Papsys's BBQ",.45);
            gt.connect("Papsys's BBQ","San Jose Barangay Hall",2.1);

            

            //greedy bfs
            Console.WriteLine("Greedy BFS;: ");
            gt.GreedyBestFirstSearch("cebu city sports center", "talamban complex");

            Console.WriteLine();

            //a star
            Console.WriteLine("A star:");
            gt.myastar("cebu city sports center", "talamban complex");

        }
    }
}