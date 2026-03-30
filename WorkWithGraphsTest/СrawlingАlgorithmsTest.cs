using WorkWithGraphsClassLibrary;

namespace CrawlingAlgorithmsTest
{
    public class CrawlingAlgorithmsTest
    {
        private Dictionary<string, List<Tuple<string, double>>> adjacencyList;

        public CrawlingAlgorithmsTest()
        {
            adjacencyList = new Dictionary<string, List<Tuple<string, double>>>();
            GetAdjacencyList();
        }

        private void GetAdjacencyList()
        {
            // Заполняем граф (как в исходном коде)
            adjacencyList.Add("A", new List<Tuple<string, double>>
            {
                Tuple.Create("B", 3.0),
                Tuple.Create("C", 1.5)
            });


            adjacencyList.Add("B", new List<Tuple<string, double>>
            {
                Tuple.Create("A", 3.0),
                Tuple.Create("D", 2.0)
            });

            adjacencyList.Add("C", new List<Tuple<string, double>>
            {
                Tuple.Create("A", 1.5),
                Tuple.Create("D", 4.0)
            });

            adjacencyList.Add("D", new List<Tuple<string, double>>
            {
                Tuple.Create("B", 2.0),
                Tuple.Create("C", 4.0)
            });
        }
        
        [Fact]
        public void IsDirected_NotDirectedGraph_ReturnsFalse()
        {
            Assert.False(СrawlingАlgorithms.IsDirected(adjacencyList));
        }
        [Fact]
        public void IsReachable_OneVertex_ThrowExeption()
        {
            var exception = Assert.Throws<ArgumentException>(
                () => СrawlingАlgorithms.IsReachable("A", "A", adjacencyList));

            Assert.Equal("Начальная вершина равна конечной", exception.Message);
        }
        [Fact]
        public void IsReachable_ReachableVertexes_ReturnsTrue()
        {
            Assert.True(СrawlingАlgorithms.IsReachable("D", "B", adjacencyList));
        }
        [Fact]
        public void GetConnectedComponents_OneComponent()
        {
            List<List<string>> component = СrawlingАlgorithms.GetConnectedComponents(adjacencyList);
            Assert.Equal(1, component.Count);
        }
        [Fact]
        public void IsReachable_NotReachableVertexes_ReturnsFalse()
        {
            adjacencyList.Add("F", new List<Tuple<string, double>>
            {
            });
            Assert.False(СrawlingАlgorithms.IsReachable("F", "B", adjacencyList));
        }
        [Fact]
        public void GetConnectedComponents_TwoComponents()
        {
            adjacencyList.Add("F", new List<Tuple<string, double>>
            {
            });
            List<List<string>> components = СrawlingАlgorithms.GetConnectedComponents(adjacencyList);
            Assert.Equal(2, components.Count);
        }
        [Fact]
        public void IsDirected_DirectedGraph_ReturnsTrue()
        {
            adjacencyList.Add("E", new List<Tuple<string, double>>
            {
                Tuple.Create("B", 2.6),
                Tuple.Create("C", 1.0)
            });
            Assert.True(СrawlingАlgorithms.IsDirected(adjacencyList));
        }
        [Fact]
        public void GetConnectedComponents_DirectedGraph_ThrowException()
        {
            adjacencyList.Add("E", new List<Tuple<string, double>>
            {
                Tuple.Create("B", 2.6),
                Tuple.Create("C", 1.0)
            });
            var exception = Assert.Throws<ArgumentException>(
                 () => СrawlingАlgorithms.GetConnectedComponents(adjacencyList));

            Assert.Equal("Граф ориентированный." +
            " Связность не определяется.", exception.Message);
        }
    }
}
