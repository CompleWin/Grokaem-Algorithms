using System.Text;

namespace Grokaem_Algo;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.Unicode;

        #region Graphs

        // Dictionary<string, Dictionary<string, int>> graph = new Dictionary<string, Dictionary<string, int>>();
        // graph["начало"] = new Dictionary<string, int>();
        // graph["начало"]["a"] = 6;
        // graph["начало"]["b"] = 2;
        //
        // graph["a"] = new Dictionary<string, int>();
        // graph["a"]["конец"] = 1;
        //
        // graph["b"] =  new Dictionary<string, int>();
        // graph["b"]["a"] = 3;
        // graph["b"]["конец"] = 5;
        //
        // graph["конец"] = new Dictionary<string, int>();
        //
        // Dictionary<string, int> costs = new Dictionary<string, int>();
        //
        // costs["a"] = 6;
        // costs["b"] = 2;
        // costs["конец"] = int.MaxValue;
        //
        // Dictionary<string, string> parents = new Dictionary<string, string>();
        //
        // parents["a"] = "начало";
        // parents["b"] = "начало";
        // parents["in"] = String.Empty;
        //
        // List<string> processed =  new List<string>();
        //
        // Dictionary<string, Dictionary<string, int>> graph2 = new Dictionary<string, Dictionary<string, int>>();
        // graph2["начало"] = new Dictionary<string, int>()
        // {
        //     { "a", 5 },
        //     { "b", 2 }
        // };
        // graph2["a"] = new Dictionary<string, int>()
        // {
        //     { "d", 2 },
        //     { "c", 4 }
        // };
        // graph2["b"] = new Dictionary<string, int>()
        // {
        //     { "a", 8 },
        //     { "d", 7 }
        // };
        // graph2["c"] = new Dictionary<string, int>()
        // {
        //     { "d", 6 },
        //     { "конец", 3 }
        // };
        // graph2["d"] = new Dictionary<string, int>()
        // {
        //     { "конец", 1 }
        // };
        //
        // graph2["конец"] = new Dictionary<string, int>();
        //
        // Dictionary<string, int> costs2 = new Dictionary<string, int>()
        // {
        //     { "a", 5 },
        //     { "b", 2 },
        //     { "c", int.MaxValue},
        //     {"d", int.MaxValue},
        //     { "конец", int.MaxValue }
        // };
        //
        // Dictionary<string, string> parents2 = new Dictionary<string, string>()
        // {
        //     { "a", "начало" },
        //     { "b", "начало" },
        //     {"c", null},
        //     {"d", null},
        //     {"конец", null}
        // };
        //
        // Console.WriteLine(Algorithm.Deykstra(graph2, costs2, parents2));

        #endregion

        #region Greedy

        HashSet<string> statesNeeded = new HashSet<string>()
        {
            "mt", "wa", "or", "id", "nv", "ut", "ca", "az"
        };

        Dictionary<string, HashSet<string>> stations = new Dictionary<string, HashSet<string>>()
        {
            {"kone", new HashSet<string> {"id", "nv", "ut"}},
            {"ktwo", new HashSet<string> {"wa", "id", "mt"}},
            {"kthree", new HashSet<string> {"or", "nv", "ca"}},
            {"kfour", new HashSet<string> {"nv", "ut"}},
            {"kfive", new HashSet<string> {"ca", "az"}}
        };

        HashSet<string> answer = Algorithm.GreedyAlgo(statesNeeded, stations);

        foreach (string state in answer)
        {
            Console.WriteLine(state);
        }
        
        #endregion
        
    }
}