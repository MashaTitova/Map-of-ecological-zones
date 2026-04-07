using WorkWithGraphsClassLibrary;

namespace WorkWithGraphsTest;

public class DijkstraAlgorithmTest
{

    [Fact]
    public void Dijkstra_SimpleGraph_ReturnsCorrectDistancesAndPaths()
    {

        var graph = new Dictionary<string, List<Tuple<string, double>>>
        {
            ["A"] = new List<Tuple<string, double>> { Tuple.Create("B", 4.0), Tuple.Create("C", 2.0) },
            ["B"] = new List<Tuple<string, double>> { Tuple.Create("C", 1.0), Tuple.Create("D", 5.0) },
            ["C"] = new List<Tuple<string, double>> { Tuple.Create("D", 8.0), Tuple.Create("E", 10.0) },
            ["D"] = new List<Tuple<string, double>> { Tuple.Create("E", 2.0) },
            ["E"] = new List<Tuple<string, double>>()
        };
        string startVertex = "A";

        var (distances, paths) = DijkstraAlgorithm.Dijkstra(startVertex, graph);

        // Assert
        Assert.Equal(0.0, distances["A"]);
        Assert.Equal(4.0, distances["B"]);
        Assert.Equal(2.0, distances["C"]);
        Assert.Equal(9.0, distances["D"]);
        Assert.Equal(11.0, distances["E"]);

        Assert.False(paths.ContainsKey("A"));  // A — стартовая вершина
        Assert.Equal("A", paths["B"]);
        Assert.Equal("A", paths["C"]);
        Assert.Equal("B", paths["D"]);
        Assert.Equal("D", paths["E"]);
    }

    [Fact]
    public void PrintShortestPath_ValidPath_ReturnsCorrectPath()
    {
        var distances = new Dictionary<string, double>
        {
            ["A"] = 0.0,
            ["B"] = 4.0,
            ["C"] = 2.0,
            ["D"] = 9.0,
            ["E"] = 11.0
        };

        var paths = new Dictionary<string, string>
        {
            ["B"] = "A",
            ["C"] = "A",
            ["D"] = "B",
            ["E"] = "D"
        };

        string start = "A";
        string end = "E";

        string result = DijkstraAlgorithm.PrintShortestPath(start, end, distances, paths);

        Assert.Equal("A -> B -> D -> E", result);
    }

    [Fact]
    public void PrintShortestPath_UnreachableVertex_ThrowsException()
    {
        var distances = new Dictionary<string, double>
        {
            ["A"] = 0.0,
            ["B"] = double.PositiveInfinity
        };

        var paths = new Dictionary<string, string>();

        string start = "A";
        string end = "B";

        var exception = Assert.Throws<Exception>(() =>
            DijkstraAlgorithm.PrintShortestPath(start, end, distances, paths));
        Assert.Contains("недостижима", exception.Message);
    }

    [Fact]
    public void PrintShortestPath_StartVertexNotFound_ThrowsException()
    {
        var distances = new Dictionary<string, double> { ["B"] = 5.0 };
        var paths = new Dictionary<string, string>();
        string start = "A";
        string end = "B";

        var exception = Assert.Throws<Exception>(() =>
            DijkstraAlgorithm.PrintShortestPath(start, end, distances, paths));
        Assert.Contains("не найдена в графе", exception.Message);
    }

    [Fact]
    public void PrintShortestPath_EndVertexNotFound_ThrowsException()
    {
        var distances = new Dictionary<string, double> { ["A"] = 0.0 };
        var paths = new Dictionary<string, string>();
        string start = "A";
        string end = "B";

        var exception = Assert.Throws<Exception>(() =>
            DijkstraAlgorithm.PrintShortestPath(start, end, distances, paths));
        Assert.Contains("не найдена в графе", exception.Message);
    }

    [Fact]
    public void Dijkstra_SingleVertexGraph_ReturnsZeroDistance()
    {
        var graph = new Dictionary<string, List<Tuple<string, double>>>
        {
            ["A"] = new List<Tuple<string, double>>()
        };
        string startVertex = "A";

        var (distances, paths) = DijkstraAlgorithm.Dijkstra(startVertex, graph);

        Assert.Equal(0.0, distances["A"]);
        Assert.False(paths.ContainsKey("A")); 
    }

    [Fact]
    public void Dijkstra_DisconnectedGraph_HandlesUnreachableVertices()
    {
        var graph = new Dictionary<string, List<Tuple<string, double>>>
        {
            ["A"] = new List<Tuple<string, double>> { Tuple.Create("B", 3.0) },
            ["B"] = new List<Tuple<string, double>>(),
            ["C"] = new List<Tuple<string, double>>() 
        };
        string startVertex = "A";

        var (distances, paths) = DijkstraAlgorithm.Dijkstra(startVertex, graph);

        Assert.Equal(0.0, distances["A"]);
        Assert.Equal(3.0, distances["B"]);
        Assert.True(double.IsPositiveInfinity(distances["C"])); 
    }


}