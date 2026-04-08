using WorkWithGraphsClassLibrary;

namespace WorkWithGraphsTest;

public class AdditionalAnalysisTest
{
    [Fact]
    public void MST_SimpleGraph_RuturnsCorrectMST()
    {
        var adjacencyList = new Dictionary<string, List<Tuple<string, double>>>
        {
            ["A"] = new List<Tuple<string, double>> { Tuple.Create("B", 1.0), Tuple.Create("C", 3.0) },
            ["B"] = new List<Tuple<string, double>> { Tuple.Create("A", 1.0), Tuple.Create("C", 2.0) },
            ["C"] = new List<Tuple<string, double>> { Tuple.Create("A", 3.0), Tuple.Create("B", 2.0) }
        };

        var (mst, totalWeight) = AdditionalAnalysis.MST(adjacencyList);

        Assert.Equal(2, mst.Count); // Должно быть 2 ребра 
        Assert.Equal(3.0, totalWeight); // A-B (1) + B-C (2) = 3

        var expectedEdges = new List<Tuple<string, string, double>>
        {
            Tuple.Create("A", "B", 1.0),
            Tuple.Create("B", "C", 2.0)
        };

        foreach (var edge in expectedEdges)
        {
            Assert.Contains(edge, mst);
        }
    }

    [Fact]
    public void MST_DirectedGraph_ThrowsException()
    {
        var adjacencyList = new Dictionary<string, List<Tuple<string, double>>>
        {
            ["A"] = new List<Tuple<string, double>> { Tuple.Create("B", 1.0), Tuple.Create("C", 3.0) },
            ["B"] = new List<Tuple<string, double>> { Tuple.Create("A", 1.0), Tuple.Create("C", 2.0) },
        };

        Assert.Throws<ArgumentException>(() => AdditionalAnalysis.MST(adjacencyList));
    }

    [Fact]
    public void MST_DisconnectedGraph_ThrowsException()
    {
        var adjacencyList = new Dictionary<string, List<Tuple<string, double>>>
        {
            ["A"] = new List<Tuple<string, double>> { Tuple.Create("B", 1.0) },
            ["B"] = new List<Tuple<string, double>> { Tuple.Create("A", 1.0) },
            ["C"] = new List<Tuple<string, double>>(), 
        };

        Assert.Throws<ArgumentException>(() => AdditionalAnalysis.MST(adjacencyList));
    }

    [Fact]
    public void FindArticulationPoints_OneArticulationPoint_ReturnsCorrectPoints()
    {

        var adjacencyList = new Dictionary<string, List<Tuple<string, double>>>
        {
            ["A"] = new List<Tuple<string, double>> { Tuple.Create("B", 1.0) },
            ["B"] = new List<Tuple<string, double>> { Tuple.Create("A", 1.0), Tuple.Create("C", 1.0) },
            ["C"] = new List<Tuple<string, double>> { Tuple.Create("B", 1.0) }
        };

        var articulationPoints = AdditionalAnalysis.FindArticulationPoints(adjacencyList);

        Assert.Single(articulationPoints); 
        Assert.Contains("B", articulationPoints);
    }

    [Fact]
    public void FindArticulationPoints_NoArticulationPoints_ReturnsEmpty()
    {
        var adjacencyList = new Dictionary<string, List<Tuple<string, double>>>
        {
            ["A"] = new List<Tuple<string, double>> { Tuple.Create("B", 1.0), Tuple.Create("C", 1.0) },
            ["B"] = new List<Tuple<string, double>> { Tuple.Create("A", 1.0), Tuple.Create("C", 1.0) },
            ["C"] = new List<Tuple<string, double>> { Tuple.Create("A", 1.0), Tuple.Create("B", 1.0) }
        };

        var articulationPoints = AdditionalAnalysis.FindArticulationPoints(adjacencyList);

        Assert.Empty(articulationPoints); 
    }

    [Fact]
    public void FindArticulationPoints_TwoDisconectedGraphs_ReturnsTwoArticulationPoints()
    {

        var adjacencyList = new Dictionary<string, List<Tuple<string, double>>>
        {
            ["A"] = new List<Tuple<string, double>> { Tuple.Create("B", 1.0) },
            ["B"] = new List<Tuple<string, double>> { Tuple.Create("A", 1.0), Tuple.Create("C", 1.0) },
            ["C"] = new List<Tuple<string, double>> { Tuple.Create("B", 1.0) },
            ["D"] = new List<Tuple<string, double>> { Tuple.Create("E", 1.0) },
            ["E"] = new List<Tuple<string, double>> { Tuple.Create("D", 1.0), Tuple.Create("F", 1.0) },
            ["F"] = new List<Tuple<string, double>> { Tuple.Create("E", 1.0) }
        };

        var articulationPoints = AdditionalAnalysis.FindArticulationPoints(adjacencyList);

        Assert.Equal(2, articulationPoints.Count);
        Assert.Contains("B", articulationPoints);
        Assert.Contains("E", articulationPoints);
    }
}

