using System.Collections;
using System.Data;
using System.Xml.Linq;
using WorkWithGraphsClassLibrary;
using static System.Windows.Forms.LinkLabel;

namespace Map_of_ecological_zones
{
    public partial class Form_MapOfEcologicalZones : Form
    {
        private string selectedFilePath = "";
        DataTable inputDataTable = new DataTable();
        Dictionary<string, List<Tuple<string, double>>> adjacencyList =
            new Dictionary<string, List<Tuple<string, double>>>();
        public Form_MapOfEcologicalZones()
        {
            InitializeComponent();
            this.BackgroundImageLayout = ImageLayout.Stretch;
            dataGridView_DescriptionOfThePeaks.DataSource = inputDataTable;
            foreach (DataGridViewColumn column in dataGridView_DescriptionOfThePeaks.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void button_LoadFile_Click(object sender, EventArgs e)
        {
            if (inputDataTable.Rows.Count == 0)
            {
                LoadFile();
            }
            else
            {
                DialogResult result = MessageBox.Show(
                   "Вы уверены, что хотите перезаписать файл?",
                   "Предупреждение",
                   MessageBoxButtons.YesNo,
                   MessageBoxIcon.Warning
                );
                if (result == DialogResult.Yes)
                {
                    inputDataTable.Clear();
                    inputDataTable.Columns.Clear();
                    LoadFile();
                }
            }
        }
        private void LoadFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Настройка диалогового окна
            openFileDialog.Title = "Выберите файл";
            openFileDialog.Filter = "TXT files (*.txt)|*.txt|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                selectedFilePath = openFileDialog.FileName;
                if (selectedFilePath == "")
                {
                    MessageBox.Show(
                        "Файл не найден",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                FillData();
            }
        }
        private void FillData()
        {
            try
            {
                StreamReader g = new StreamReader(selectedFilePath);
            }
            catch (IOException ex)
            {
                if (ex.Message.Contains("being used by another process"))
                {
                    MessageBox.Show(
                       "Файл занят другим процессом. " +
                       "Закройте все приложения, использующие этот файл.",
                       "Ошибка",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(
                       "Ошибка при работе с файлом",
                       "Ошибка",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                }
                return;
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show(
                      "Нет доступа к файлу",
                      "Ошибка",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Error);
                return;
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Непредвиденная ошибка",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;

            }
            StreamReader f = new StreamReader(selectedFilePath);
            string[] allLines = File.ReadAllLines(selectedFilePath);
            int numberOfLines = allLines.Length;
            f.ReadLine();
            int n = 0;
            try
            {
                n = Convert.ToInt32(f.ReadLine());
            }
            catch (Exception)
            {
                MessageBox.Show(
                   "Количество объектов введено неверно \n" +
                   "Ошибка в строке 2",
                   "Ошибка",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                return;
            }
            if (n != (numberOfLines - 6) / 2)
            {
                MessageBox.Show(
                   "Количество объектов введено неверно \n" +
                   "Ошибка в строке 2",
                   "Ошибка",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                return;
            }

            f.ReadLine();
            string[] titles = Convert.ToString(f.ReadLine()).Split(",");
            inputDataTable.Columns.Add(titles[0], typeof(string));
            inputDataTable.Columns.Add(titles[1], typeof(string));
            inputDataTable.Columns.Add(titles[2], typeof(string));
            for (int i = 0; i < n; i++)
            {
                string def = f.ReadLine();

                if (string.IsNullOrEmpty(def.Trim()))
                {
                    MessageBox.Show(
                      "Значение введено неверно \n" +
                      $"Ошибка в строке {i + 5}",
                      "Ошибка",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Error);
                    return;
                }
                inputDataTable.Rows.Add(def.Split(","));
            }
            f.ReadLine();
            string text = $"{(f.ReadLine())}{Environment.NewLine}";
            for (int i = 0; i < n; i++)
            {
                string line = f.ReadLine();
                if (string.IsNullOrEmpty(line.Trim()))
                {
                    MessageBox.Show(
                      "Значение введено неверно \n" +
                      $"Ошибка в строке {i + n + 7}",
                      "Ошибка",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Error);
                    return;
                }
                text += $"{line} {Environment.NewLine}";

            }
            textBox_AdjacencyList.Text = text;
            string[] lines = text.Split("\n");
            lines = lines.Skip(1).ToArray();
            AjacencyLists(lines);
        }
        private void AjacencyLists(string[] lines)
        {
            for (int i = 0; i < lines.Length; i++)
            {
                if (string.IsNullOrEmpty(lines[i].Trim())) continue; // Пропускаем пустые строки
                var parts = lines[i].Split(':');
                var vertex = parts[0].Trim(); // Вершина (например, "L")
                if (vertex == "")
                {
                    MessageBox.Show(
                      "Значение введено неверно \n" +
                      $"Ошибка в строке {i + lines.Length + 6}",
                      "Ошибка",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Error);
                    return;
                }
                comboBox_VertexIn.Items.Add(vertex);
                comboBox_VertexFrom.Items.Add(vertex);
                comboBox_ChooseDFS.Items.Add(vertex);
                comboBox_ChooseBFS.Items.Add(vertex);
                comboBox_ShortestDistanceObject.Items.Add(vertex);


                var neighborsStr = parts[1].Trim(); // Список соседей (например, "E(11) K(8,9) D(4)")
                var neighborList = new List<Tuple<string, double>>();
                if (neighborsStr != "")
                {
                    var neighbors = neighborsStr.Split(' '); // Разбиваем по пробелам
                    foreach (var neighborStr in neighbors)
                    {
                        if (neighborsStr == "")
                        {
                            MessageBox.Show(
                                "Соседняя экологическая зона введена неверно \n" +
                                $"Ошибка в строке {i + lines.Length + 6}",
                                "Ошибка",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            return;
                        }
                        // Извлекаем название вершины и вес
                        var nameAndWeight = neighborStr.Trim();
                        var name = nameAndWeight.Split('(')[0]; // Название вершины (например, "E")
                        if (name == "")
                        {
                            MessageBox.Show(
                                "Имя соседней экологической зоны  введено неверно \n" +
                                $"Ошибка в строке {i + lines.Length + 6}",
                                "Ошибка",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            return;
                        }
                        string weightStr = nameAndWeight.Split('(')[1].Replace(")", "");
                        double weight;
                        try
                        {
                            weight = double.Parse(weightStr);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show(
                              "Длина экологического коридора введена неверно \n" +
                               $"Ошибка в строке {i + lines.Length + 6}",
                              "Ошибка",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
                            return;
                        }

                        neighborList.Add(Tuple.Create(name, weight));
                    }

                }
                adjacencyList[vertex] = neighborList;

            }
        }
        private void Home_button_Click(object sender, EventArgs e)
        {
            var tmp = (Button)sender;
            if (tmp.Name == "button_ExitApp")
            {
                DialogResult result = MessageBox.Show(
                   "Вы уверены, что хотите закрыть приложение?",
                   "Подтверждение",
                   MessageBoxButtons.YesNo,
                   MessageBoxIcon.Question
                );
                if (result == DialogResult.Yes)
                {
                    Application.Exit();
                }
            }
            else
            {
                if (inputDataTable.Rows.Count == 0)
                {
                    MessageBox.Show(
                        "Загрузите файл",
                        "Нет файла",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                else
                {
                    if (tmp.Name == "button_СrawlingАlgorithms")
                    {
                        panel_BypassAlgorithm.Visible = true;

                    }
                    if (tmp.Name == "button_DijkstraAlgorithm")
                    {
                        panel_DijkstraAlgorithm.Visible = true;
                    }
                    if (tmp.Name == "button_DepthAnalysis")
                    {
                        panel_AdditionalAnalysis.Visible = true;
                    }
                    panel_AdjacencyList.Visible = true;
                    panel_DescriptionOfThePeaks.Visible = true;
                    panel_Home.Visible = false;
                    button_Return.Visible = true;
                    
                }
            }

        }
        private void ReturnInMenu_button_Click(object sender, EventArgs e)
        {
            panel_Home.Visible = true;
            button_Return.Visible = false;
            panel_AdjacencyList.Visible = false;
            panel_DescriptionOfThePeaks.Visible = false;
            if (panel_BypassAlgorithm.Visible == true)
            {
                panel_BypassAlgorithm.Visible = false;
                comboBox_ChooseBFS.Text = "";
                textBox_OrderBFS.Text = "";
                comboBox_ChooseDFS.Text = "";
                textBox_OrderDFS.Text = "";
            }
            if (panel_DijkstraAlgorithm.Visible == true)
            {
                panel_DijkstraAlgorithm.Visible = false;
                comboBox_ShortestDistanceObject.Text = "";
                textBox_ShortestDistance.Text = "";
                textBox_Route.Text = "";
                textBox_ShortestPathObject1.Text = "";
                textBox_ShortestPathObject2.Text = "";
                textBox_ShortestPath.Text = "";
            }
            if(panel_AdditionalAnalysis.Visible == true)
            {
                panel_AdditionalAnalysis.Visible = false;
                textBox_EnviromentalNodes.Text = "";
                textBox_MSTEdges.Text = "";
                textBox_MainTask.Text = "";
            }

        }
        private void GetBypassAlgorithms(object sender, EventArgs e)
        {
            var tmp = (Button)sender;
            if (tmp.Name == "button_BFS")
            {
                string orderStr = "";
                if (comboBox_ChooseBFS.Text != "")
                {
                    List<string> order = СrawlingАlgorithm.BFS(comboBox_ChooseBFS.Text, adjacencyList);
                    for (int i = 0; i < order.Count - 1; i++)
                    {
                        orderStr += $"{order[i].ToString()}, ";
                    }
                    orderStr += $"{order[order.Count - 1].ToString()}";
                }
                textBox_OrderBFS.Text = orderStr;
            }
            if (tmp.Name == "button_DFS")
            {
                string orderStr = "";
                if (comboBox_ChooseDFS.Text != "")
                {
                    List<string> order = СrawlingАlgorithm.DFS(comboBox_ChooseDFS.Text, adjacencyList);
                    for (int i = 0; i < order.Count - 1; i++)
                    {
                        orderStr += $"{order[i].ToString()}, ";
                    }
                    orderStr += $"{order[order.Count - 1].ToString()}";
                }
                textBox_OrderDFS.Text = orderStr;
            }
            if (tmp.Name == "button_Reachability")
            {
                try
                {
                    bool reachable = СrawlingАlgorithm.IsReachable(comboBox_VertexFrom.Text, comboBox_VertexIn.Text, adjacencyList);
                    if (reachable)
                    {
                        textBox_Reachability.Text = $"Вершина {comboBox_VertexIn.Text} достижима из вершины {comboBox_VertexFrom.Text}";
                    }
                    else
                    {
                        textBox_Reachability.Text = $"Вершина {comboBox_VertexIn.Text} не достижима из вершины {comboBox_VertexFrom.Text}";
                    }
                }
                catch (ArgumentException ex)
                {
                    textBox_Reachability.Text = ex.Message;
                    return;
                }
            }
            if (tmp.Name == "button_ConnectivityСomponents")
            {
                try
                {
                    List<List<string>> components = СrawlingАlgorithm.GetConnectedComponents(adjacencyList);
                    for (int i = 0; i < components.Count; i++)
                    {
                        textBox_ConnectivityСomponents.Text += $"{string.Join(", ", components[i])}{Environment.NewLine}";
                    }
                }
                catch (ArgumentException ex)
                {
                    textBox_ConnectivityСomponents.Text = ex.Message;
                    return;
                }
            }
        }
        private void GetDijkstraAlgorithm(object sender, EventArgs e)
        {

            var tmp = (Button)sender;
            if (tmp.Name == "button_ShortestDistance")
            {
                textBox_ShortestDistance.Text = "";
                textBox_Route.Text = "";
                if (comboBox_ShortestDistanceObject.Text != "")
                {
                    Dictionary<string, double> distances = DijkstraAlgorithm.Dijkstra(comboBox_ShortestDistanceObject.Text, adjacencyList).Item1;
                    Dictionary<string, string> paths = DijkstraAlgorithm.Dijkstra(comboBox_ShortestDistanceObject.Text, adjacencyList).Item2;
                    foreach (var entry in distances)
                    {
                        if (entry.Value != double.PositiveInfinity && entry.Value != 0)
                            textBox_ShortestDistance.Text += $"Вершина {entry.Key}: расстояние = {entry.Value} {Environment.NewLine}";
                        else
                            if (entry.Value == double.PositiveInfinity)
                                textBox_ShortestDistance.Text += $"Вершина {entry.Key} недостижима {Environment.NewLine}";
                    }
                    foreach (var entry in paths)
                    {
                        textBox_Route.Text += $"Вершина {entry.Key}. Путь: {DijkstraAlgorithm.BuildPath(entry.Key, entry.Value, paths)}{Environment.NewLine}";
                    }
                }
            }
            if (tmp.Name == "button_ShortestPath")
            {
                textBox_ShortestPath.Text = "";
                if (textBox_ShortestPathObject1.Text != "" && textBox_ShortestPathObject2.Text != "")
                {
                    Dictionary<string, double> distances = DijkstraAlgorithm.Dijkstra(textBox_ShortestPathObject1.Text.ToUpper(), adjacencyList).Item1;
                    Dictionary<string, string> paths = DijkstraAlgorithm.Dijkstra(textBox_ShortestPathObject1.Text.ToUpper(), adjacencyList).Item2;
                    try
                    {
                        textBox_ShortestPath.Text = DijkstraAlgorithm.PrintShortestPath(textBox_ShortestPathObject1.Text.ToUpper(), textBox_ShortestPathObject2.Text.ToUpper(), distances, paths);
                    }
                    catch (Exception ex)
                    {
                        textBox_ShortestPath.Text = ex.Message;
                    }
                }
            }
        }
        private void GetAdditionalAnalysis(object sender, EventArgs e)
        {
            var tmp = (Button)sender;
            if (tmp.Name == "button_MSTEdges")
            {

                try
                {
                    (List<Tuple<string, string, double>> mst, double totalWeight) = AdditionalAnalysis.MST(adjacencyList);
                    textBox_MSTEdges.Text += $"Ребра минимального остовного дерева:{Environment.NewLine}";
                    foreach (var edge in mst)
                        textBox_MSTEdges.Text += $"{edge.Item1} — {edge.Item2}, вес: {edge.Item3}{Environment.NewLine}";
                    textBox_MSTEdges.Text += $"Вес минимального остовного дерева:{Environment.NewLine}";
                    textBox_MSTEdges.Text += $"{totalWeight}{Environment.NewLine}";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                       $"{ex.Message}",
                       "Несоответствие графа",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Warning);
                    return;
                }

            }
            if (tmp.Name == "button_EnviromentalNodes")
            {
                List<string> articulationPoints = AdditionalAnalysis.FindArticulationPoints(adjacencyList);
                for (int i = 0; i < articulationPoints.Count; i++)
                {
                    textBox_EnviromentalNodes.Text += $"{articulationPoints[i]}{Environment.NewLine}";
                }
            }
        }
        private void GetMainTask(object sender, EventArgs e)
        {
            foreach(var vertex  in adjacencyList.Keys) 
            {
                Dictionary<string, double> distances = DijkstraAlgorithm.Dijkstra(vertex, adjacencyList).Item1;
                Dictionary<string, string> paths = DijkstraAlgorithm.Dijkstra(vertex, adjacencyList).Item2;
                foreach (var entry in paths)
                {
                    textBox_Route.Text += $"Вершина {entry.Key}. Путь: {DijkstraAlgorithm.BuildPath(entry.Key, entry.Value, paths)}. ";
                }
                foreach (var entry in distances)
                {
                    if (entry.Value != double.PositiveInfinity && entry.Value != 0)
                        textBox_ShortestDistance.Text += $"Расстояние = {entry.Value} {Environment.NewLine}";
                }
                
            }
        }
        private void GetInfo(object sender, EventArgs e)
        {
            if (tabControl_BypassAlgorithm.Visible == true)
            {

                MessageBox.Show(
                  "     В  данном разделе производится обход карты экологических зон двумя способами (BFS и DFS)," +
                  " нахождение возможности перехода от одного экологического объекта к другому " +
                  "и определения экологических ареалов связности. \n" +
                  "     В правой части окна можно увидеть исходные данные: описание природных объектов и экологических коридоров. \n" +
                  "     В левой части при выборе раздела \"Алгоритмы обхода\" при нажатии соответствующих кнопок производится обход графа методами BFS и DFS. \n" +
                  "     При выборе раздела \"Связность\" при нажатии соответствующих кнопок производятся нахождение возможности перехода от одного экологического объекта к другому и определение экологических ареалов связности.\n" +
                  "     Для начала работы алгоритмов необходимо выбрать вершину из предложенных и нажать на соответствующую подразделу кнопку  \"Рассчитать\".\n",
                  "Справка пользователя",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Asterisk);
            }
            if (tabControl_DijkstraAlgorithm.Visible == true)
            {
                MessageBox.Show(
                 "      В  данном разделе производится нахождение кратчайшего пути между двумя вершинами алгоритмом Дейкстры.\n" +
                 "      в правой части окна можно увидеть исходные данные: описание природных объектов и экологических коридоров. \n" +
                 "      В левой части в подразделе \"Кратчайшее расстояние\" нужно выбрать начальный объект из предложенных.\n" +
                 "      После нажатии соответствующей кнопки \"Рассчитать\" в поле \"Кратчайшее расстояние\" появится кратчайшее расстояние от исходного объекта до кождого из остальных объектов," +
                 "в поле \"Маршрут\" выводится кратчайший маршрут до каждого объекта.\n" +
                 "      В подразделе  \"Кратчайший путь\" нужно ввести начальный и конечный объекты, при нажатии  соответствующей кнопки \"Рассчитать\" выводится кратчайший путь от начального объекта до конечного.\n",
                 "Справка пользователя",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Asterisk);
            }
        }
    }

}
