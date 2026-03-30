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
                        panel_AdjacencyList.Visible = true;
                        panel_DescriptionOfThePeaks.Visible = true;
                    }

                    panel_Home.Visible = false;
                    button_Return.Visible = true;

                }
            }
        }
        private void ReturnInMenu_button_Click(object sender, EventArgs e)
        {
            panel_Home.Visible = true;
            button_Return.Visible = false;
            if (panel_BypassAlgorithm.Visible == true)
            {
                panel_BypassAlgorithm.Visible = false;
                panel_AdjacencyList.Visible = false;
                panel_DescriptionOfThePeaks.Visible = false;
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
                    List<string> order = СrawlingАlgorithms.BFS(comboBox_ChooseBFS.Text, adjacencyList);
                    for (int i = 0; i < order.Count - 1; i++)
                    {
                        orderStr += $"{order[i].ToString()}, ";
                    }
                    orderStr += $"{order[order.Count - 1].ToString()}";
                }
                textBox_OrderBFS.Text = orderStr;
            }
            if(tmp.Name == "button_DFS")
            {
                string orderStr = "";
                if (comboBox_ChooseDFS.Text != "")
                {
                    List<string> order = СrawlingАlgorithms.DFS(comboBox_ChooseDFS.Text, adjacencyList);
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
                    bool reachable = СrawlingАlgorithms.IsReachable(comboBox_VertexFrom.Text, comboBox_VertexIn.Text, adjacencyList);
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
            if(tmp.Name == "button_ConnectivityСomponents")
            {
                try
                {
                    List<List<string>> components = СrawlingАlgorithms.GetConnectedComponents(adjacencyList);
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
        private void GetInfo(object sender, EventArgs e)
        {
            if(tabControl_BypassAlgorithm.Visible == true)
            {

                MessageBox.Show(
                  "В  данном разделе производится обход карты экологических зон двумя способами (BFS и DFS)," +
                  " нахождение возможности перехода от одного экологического объекта к другому " +
                  "и определения экологических ареалов связности. \n" +
                  "В правой части окна можно увидеть исходные данные: описание природных объектов и экологических коридоров. \n" +
                  "В левой части при выборе раздела \"Алгоритмы обхода\" при нажатии соответствующих кнопок производится обход графа методами BFS и DFS. \n" +
                  "При выборе раздела \"Связность\" при нажатии соответствующих кнопок производятся нахождение возможности перехода от одного экологического объекта к другому и определение экологических ареалов связности.\n" +
                  "Для начала работы алгоритмов необходимо выбрать вершину из предложенных и нажать на сообветствующую подразделу кнопку  \"Рассчитать\".\n",
                  "Справка пользователя",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Asterisk);
            }
        }
    }

}
