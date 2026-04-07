namespace WorkWithGraphsClassLibrary
{
    public class СrawlingАlgorithm
    {
        public static bool IsDirected(Dictionary<string, List<Tuple<string, double>>> adjacencyList)
        {
            var allEdges = new HashSet<(string, string)>(); 

            foreach (var vertex in adjacencyList.Keys)
            {
                foreach (var neighbor in adjacencyList[vertex])
                {
                    string neighborName = neighbor.Item1;
                    allEdges.Add((vertex, neighborName)); 
                }
            }

            foreach (var (from, to) in allEdges)
            {
                if (from == to) continue; 

                if (!allEdges.Contains((to, from))) 
                    return true;
            }

            return false;
        }

        public static List<string> BFS(string startVertex, Dictionary<string, List<Tuple<string, double>>> adjacencyList)
        {
            var visited = new HashSet<string>();
            var queue = new Queue<string>();
            var order = new List<string>();

            visited.Add(startVertex);
            queue.Enqueue(startVertex);

            while (queue.Count > 0)
            {
                string current = queue.Dequeue();
                order.Add(current);

                if (adjacencyList.ContainsKey(current))
                {
                    foreach (var neighbor in adjacencyList[current])
                    {
                        string neighborName = neighbor.Item1;
                        if (!visited.Contains(neighborName))
                        {
                            visited.Add(neighborName);
                            queue.Enqueue(neighborName);
                        }
                    }
                }
            }
            return order;
        }

        public static List<string> DFS(string startVertex, Dictionary<string, List<Tuple<string, double>>> adjacencyList)
        {

            var visited = new HashSet<string>();
            var order = new List<string>();

            DFSRecursive(startVertex, visited, order, adjacencyList);

            return order;
        }

        private static void DFSRecursive(string vertex, HashSet<string> visited, List<string> order, Dictionary<string, List<Tuple<string, double>>> adjacencyList)
        {
            visited.Add(vertex);
            order.Add(vertex);

            if (adjacencyList.ContainsKey(vertex))
            {
                foreach (var neighbor in adjacencyList[vertex])
                {
                    string neighborName = neighbor.Item1;
                    if (!visited.Contains(neighborName))
                    {
                        DFSRecursive(neighborName, visited, order, adjacencyList);
                    }
                }
            }
        }

        public static bool IsReachable(string vertexA, string vertexB, Dictionary<string, List<Tuple<string, double>>> adjacencyList)
        {
            var order = new List<string>();
            if (vertexA == vertexB)
                throw new ArgumentException("Начальная вершина равна конечной");
            var visited = new HashSet<string>();
            var queue = new Queue<string>();

            visited.Add(vertexA);
            queue.Enqueue(vertexA);

            while (queue.Count > 0)
            {
                string current = queue.Dequeue();
                order.Add(current);
                if (current == vertexB)
                {
                    return true;
                }
                if (adjacencyList.ContainsKey(current))
                {
                    foreach (var neighbor in adjacencyList[current])
                    {
                        string neighborName = neighbor.Item1;
                        if (!visited.Contains(neighborName))
                        {
                            visited.Add(neighborName);
                            queue.Enqueue(neighborName);
                        }
                    }
                }
            }
            return false;
        }

        public static List<List<string>> GetConnectedComponents(Dictionary<string, List<Tuple<string, double>>> adjacencyList)
        {
            if (IsDirected(adjacencyList))
                throw new ArgumentException("Граф ориентированный." +
            " Связность не определяется.");
            var allVertices = new HashSet<string>(adjacencyList.Keys);
            var visited = new HashSet<string>();
            var components = new List<List<string>>();

            foreach (string vertex in allVertices)
            {
                if (!visited.Contains(vertex))
                {
                    var component = BFS(vertex, adjacencyList);
                    components.Add(component);

                    foreach (string v in component)
                        visited.Add(v);
                }
            }

            return components;
        }

    }
}
