namespace Map_of_ecological_zones
{
    partial class Form_MapOfEcologicalZones
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_MapOfEcologicalZones));
            panel_DescriptionOfThePeaks = new Panel();
            dataGridView_DescriptionOfThePeaks = new DataGridView();
            label_DescriptionOfThePeaks = new Label();
            panel_AdjacencyList = new Panel();
            textBox_AdjacencyList = new TextBox();
            label_AdjacencyList = new Label();
            panel_BypassAlgorithm = new Panel();
            tabControl_BypassAlgorithm = new TabControl();
            tabPage_BypassAlgorithms = new TabPage();
            panel_DFS = new Panel();
            comboBox_ChooseDFS = new ComboBox();
            label_ChooseDFS = new Label();
            button_DFS = new Button();
            label_OrderDFS = new Label();
            textBox_OrderDFS = new TextBox();
            label_DFS = new Label();
            panel_BFS = new Panel();
            comboBox_ChooseBFS = new ComboBox();
            label_ChooseBFS = new Label();
            button_BFS = new Button();
            label_OrderBFS = new Label();
            textBox_OrderBFS = new TextBox();
            label_BFS = new Label();
            tabPage_GraphСonnectivity = new TabPage();
            panel_Reachability = new Panel();
            button_Reachability = new Button();
            textBox_Reachability = new TextBox();
            comboBox_VertexFrom = new ComboBox();
            label_VertexFrom = new Label();
            label_VertexIn = new Label();
            comboBox_VertexIn = new ComboBox();
            label_Reachability = new Label();
            panel_ConnectivityСomponents = new Panel();
            button_ConnectivityСomponents = new Button();
            textBox_ConnectivityСomponents = new TextBox();
            label__ConnectivityСomponents = new Label();
            panel_Buttons = new Panel();
            button_Return = new Button();
            button_Info = new Button();
            panel_Home = new Panel();
            panel_HomeButtons = new Panel();
            button_LoadFile = new Button();
            button_СrawlingАlgorithms = new Button();
            button_DextraAlgorithm = new Button();
            button_DepthAnalysis = new Button();
            button_ExitApp = new Button();
            label_NameApp = new Label();
            label_TaskApp = new Label();
            panel_DescriptionOfThePeaks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_DescriptionOfThePeaks).BeginInit();
            panel_AdjacencyList.SuspendLayout();
            panel_BypassAlgorithm.SuspendLayout();
            tabControl_BypassAlgorithm.SuspendLayout();
            tabPage_BypassAlgorithms.SuspendLayout();
            panel_DFS.SuspendLayout();
            panel_BFS.SuspendLayout();
            tabPage_GraphСonnectivity.SuspendLayout();
            panel_Reachability.SuspendLayout();
            panel_ConnectivityСomponents.SuspendLayout();
            panel_Buttons.SuspendLayout();
            panel_Home.SuspendLayout();
            panel_HomeButtons.SuspendLayout();
            SuspendLayout();
            // 
            // panel_DescriptionOfThePeaks
            // 
            panel_DescriptionOfThePeaks.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel_DescriptionOfThePeaks.BackColor = Color.Transparent;
            panel_DescriptionOfThePeaks.Controls.Add(dataGridView_DescriptionOfThePeaks);
            panel_DescriptionOfThePeaks.Controls.Add(label_DescriptionOfThePeaks);
            panel_DescriptionOfThePeaks.Location = new Point(767, 12);
            panel_DescriptionOfThePeaks.Name = "panel_DescriptionOfThePeaks";
            panel_DescriptionOfThePeaks.Size = new Size(683, 600);
            panel_DescriptionOfThePeaks.TabIndex = 0;
            panel_DescriptionOfThePeaks.Visible = false;
            // 
            // dataGridView_DescriptionOfThePeaks
            // 
            dataGridView_DescriptionOfThePeaks.AllowUserToAddRows = false;
            dataGridView_DescriptionOfThePeaks.AllowUserToDeleteRows = false;
            dataGridView_DescriptionOfThePeaks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView_DescriptionOfThePeaks.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView_DescriptionOfThePeaks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_DescriptionOfThePeaks.Dock = DockStyle.Fill;
            dataGridView_DescriptionOfThePeaks.Location = new Point(0, 86);
            dataGridView_DescriptionOfThePeaks.Name = "dataGridView_DescriptionOfThePeaks";
            dataGridView_DescriptionOfThePeaks.RowHeadersWidth = 82;
            dataGridView_DescriptionOfThePeaks.Size = new Size(683, 514);
            dataGridView_DescriptionOfThePeaks.TabIndex = 3;
            // 
            // label_DescriptionOfThePeaks
            // 
            label_DescriptionOfThePeaks.BackColor = Color.Transparent;
            label_DescriptionOfThePeaks.Dock = DockStyle.Top;
            label_DescriptionOfThePeaks.Font = new Font("Calibri", 13.875F, FontStyle.Bold);
            label_DescriptionOfThePeaks.Location = new Point(0, 0);
            label_DescriptionOfThePeaks.Name = "label_DescriptionOfThePeaks";
            label_DescriptionOfThePeaks.Size = new Size(683, 86);
            label_DescriptionOfThePeaks.TabIndex = 2;
            label_DescriptionOfThePeaks.Text = "Природные объекты (вершины графа)";
            label_DescriptionOfThePeaks.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel_AdjacencyList
            // 
            panel_AdjacencyList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel_AdjacencyList.BackColor = Color.Transparent;
            panel_AdjacencyList.Controls.Add(textBox_AdjacencyList);
            panel_AdjacencyList.Controls.Add(label_AdjacencyList);
            panel_AdjacencyList.Location = new Point(767, 618);
            panel_AdjacencyList.Name = "panel_AdjacencyList";
            panel_AdjacencyList.Size = new Size(683, 600);
            panel_AdjacencyList.TabIndex = 1;
            panel_AdjacencyList.Visible = false;
            // 
            // textBox_AdjacencyList
            // 
            textBox_AdjacencyList.Dock = DockStyle.Fill;
            textBox_AdjacencyList.Location = new Point(0, 86);
            textBox_AdjacencyList.Multiline = true;
            textBox_AdjacencyList.Name = "textBox_AdjacencyList";
            textBox_AdjacencyList.ReadOnly = true;
            textBox_AdjacencyList.Size = new Size(683, 514);
            textBox_AdjacencyList.TabIndex = 5;
            // 
            // label_AdjacencyList
            // 
            label_AdjacencyList.BackColor = Color.Transparent;
            label_AdjacencyList.Dock = DockStyle.Top;
            label_AdjacencyList.Font = new Font("Calibri", 13.875F, FontStyle.Bold);
            label_AdjacencyList.Location = new Point(0, 0);
            label_AdjacencyList.Name = "label_AdjacencyList";
            label_AdjacencyList.Size = new Size(683, 86);
            label_AdjacencyList.TabIndex = 3;
            label_AdjacencyList.Text = "Экологические коридоры (ребра графа)";
            label_AdjacencyList.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel_BypassAlgorithm
            // 
            panel_BypassAlgorithm.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            panel_BypassAlgorithm.BackColor = Color.Transparent;
            panel_BypassAlgorithm.Controls.Add(tabControl_BypassAlgorithm);
            panel_BypassAlgorithm.Location = new Point(6, 12);
            panel_BypassAlgorithm.Name = "panel_BypassAlgorithm";
            panel_BypassAlgorithm.Size = new Size(763, 1072);
            panel_BypassAlgorithm.TabIndex = 2;
            panel_BypassAlgorithm.Visible = false;
            // 
            // tabControl_BypassAlgorithm
            // 
            tabControl_BypassAlgorithm.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl_BypassAlgorithm.Controls.Add(tabPage_BypassAlgorithms);
            tabControl_BypassAlgorithm.Controls.Add(tabPage_GraphСonnectivity);
            tabControl_BypassAlgorithm.Location = new Point(3, 3);
            tabControl_BypassAlgorithm.Name = "tabControl_BypassAlgorithm";
            tabControl_BypassAlgorithm.SelectedIndex = 0;
            tabControl_BypassAlgorithm.Size = new Size(760, 1066);
            tabControl_BypassAlgorithm.TabIndex = 2;
            // 
            // tabPage_BypassAlgorithms
            // 
            tabPage_BypassAlgorithms.Controls.Add(panel_DFS);
            tabPage_BypassAlgorithms.Controls.Add(panel_BFS);
            tabPage_BypassAlgorithms.Location = new Point(8, 46);
            tabPage_BypassAlgorithms.Name = "tabPage_BypassAlgorithms";
            tabPage_BypassAlgorithms.Padding = new Padding(3);
            tabPage_BypassAlgorithms.Size = new Size(744, 1012);
            tabPage_BypassAlgorithms.TabIndex = 0;
            tabPage_BypassAlgorithms.Text = "Алгоритмы обхода";
            tabPage_BypassAlgorithms.UseVisualStyleBackColor = true;
            // 
            // panel_DFS
            // 
            panel_DFS.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel_DFS.Controls.Add(comboBox_ChooseDFS);
            panel_DFS.Controls.Add(label_ChooseDFS);
            panel_DFS.Controls.Add(button_DFS);
            panel_DFS.Controls.Add(label_OrderDFS);
            panel_DFS.Controls.Add(textBox_OrderDFS);
            panel_DFS.Controls.Add(label_DFS);
            panel_DFS.Location = new Point(3, 511);
            panel_DFS.Name = "panel_DFS";
            panel_DFS.Size = new Size(738, 498);
            panel_DFS.TabIndex = 1;
            // 
            // comboBox_ChooseDFS
            // 
            comboBox_ChooseDFS.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_ChooseDFS.FormattingEnabled = true;
            comboBox_ChooseDFS.Location = new Point(609, 78);
            comboBox_ChooseDFS.Name = "comboBox_ChooseDFS";
            comboBox_ChooseDFS.Size = new Size(114, 40);
            comboBox_ChooseDFS.TabIndex = 12;
            // 
            // label_ChooseDFS
            // 
            label_ChooseDFS.Anchor = AnchorStyles.Top;
            label_ChooseDFS.BackColor = Color.Transparent;
            label_ChooseDFS.Font = new Font("Calibri", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label_ChooseDFS.ForeColor = SystemColors.ActiveCaptionText;
            label_ChooseDFS.Location = new Point(20, 64);
            label_ChooseDFS.Name = "label_ChooseDFS";
            label_ChooseDFS.Size = new Size(558, 50);
            label_ChooseDFS.TabIndex = 11;
            label_ChooseDFS.Text = "Выберете начальную зону";
            label_ChooseDFS.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button_DFS
            // 
            button_DFS.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button_DFS.Location = new Point(9, 394);
            button_DFS.Name = "button_DFS";
            button_DFS.Size = new Size(210, 104);
            button_DFS.TabIndex = 6;
            button_DFS.Text = "Рассчитать";
            button_DFS.UseVisualStyleBackColor = true;
            button_DFS.Click += GetBypassAlgorithms;
            // 
            // label_OrderDFS
            // 
            label_OrderDFS.Anchor = AnchorStyles.Right;
            label_OrderDFS.BackColor = Color.Transparent;
            label_OrderDFS.Font = new Font("Calibri", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label_OrderDFS.ForeColor = SystemColors.ActiveCaptionText;
            label_OrderDFS.Location = new Point(-3, 118);
            label_OrderDFS.Name = "label_OrderDFS";
            label_OrderDFS.Size = new Size(738, 50);
            label_OrderDFS.TabIndex = 6;
            label_OrderDFS.Text = "Порядок посещения экологических зон";
            label_OrderDFS.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBox_OrderDFS
            // 
            textBox_OrderDFS.Anchor = AnchorStyles.None;
            textBox_OrderDFS.Location = new Point(9, 167);
            textBox_OrderDFS.Multiline = true;
            textBox_OrderDFS.Name = "textBox_OrderDFS";
            textBox_OrderDFS.ReadOnly = true;
            textBox_OrderDFS.Size = new Size(732, 221);
            textBox_OrderDFS.TabIndex = 5;
            // 
            // label_DFS
            // 
            label_DFS.Anchor = AnchorStyles.Right;
            label_DFS.BackColor = Color.Transparent;
            label_DFS.Font = new Font("Calibri", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label_DFS.ForeColor = SystemColors.ActiveCaptionText;
            label_DFS.Location = new Point(0, 0);
            label_DFS.Name = "label_DFS";
            label_DFS.Size = new Size(738, 72);
            label_DFS.TabIndex = 3;
            label_DFS.Text = "DFS (обход в глубину)";
            label_DFS.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel_BFS
            // 
            panel_BFS.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel_BFS.Controls.Add(comboBox_ChooseBFS);
            panel_BFS.Controls.Add(label_ChooseBFS);
            panel_BFS.Controls.Add(button_BFS);
            panel_BFS.Controls.Add(label_OrderBFS);
            panel_BFS.Controls.Add(textBox_OrderBFS);
            panel_BFS.Controls.Add(label_BFS);
            panel_BFS.Location = new Point(3, 3);
            panel_BFS.Name = "panel_BFS";
            panel_BFS.Size = new Size(738, 505);
            panel_BFS.TabIndex = 0;
            // 
            // comboBox_ChooseBFS
            // 
            comboBox_ChooseBFS.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_ChooseBFS.FormattingEnabled = true;
            comboBox_ChooseBFS.Location = new Point(609, 70);
            comboBox_ChooseBFS.Name = "comboBox_ChooseBFS";
            comboBox_ChooseBFS.Size = new Size(114, 40);
            comboBox_ChooseBFS.TabIndex = 10;
            // 
            // label_ChooseBFS
            // 
            label_ChooseBFS.Anchor = AnchorStyles.Top;
            label_ChooseBFS.BackColor = Color.Transparent;
            label_ChooseBFS.Font = new Font("Calibri", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label_ChooseBFS.ForeColor = SystemColors.ActiveCaptionText;
            label_ChooseBFS.Location = new Point(20, 61);
            label_ChooseBFS.Name = "label_ChooseBFS";
            label_ChooseBFS.Size = new Size(561, 50);
            label_ChooseBFS.TabIndex = 6;
            label_ChooseBFS.Text = "Выберете начальную зону";
            label_ChooseBFS.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button_BFS
            // 
            button_BFS.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button_BFS.Font = new Font("Segoe UI", 9F);
            button_BFS.Location = new Point(3, 398);
            button_BFS.Name = "button_BFS";
            button_BFS.Size = new Size(210, 104);
            button_BFS.TabIndex = 5;
            button_BFS.Text = "Рассчитать";
            button_BFS.UseVisualStyleBackColor = true;
            button_BFS.Click += GetBypassAlgorithms;
            // 
            // label_OrderBFS
            // 
            label_OrderBFS.Anchor = AnchorStyles.Top;
            label_OrderBFS.BackColor = Color.Transparent;
            label_OrderBFS.Font = new Font("Calibri", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label_OrderBFS.ForeColor = SystemColors.ActiveCaptionText;
            label_OrderBFS.Location = new Point(3, 122);
            label_OrderBFS.Name = "label_OrderBFS";
            label_OrderBFS.Size = new Size(738, 50);
            label_OrderBFS.TabIndex = 4;
            label_OrderBFS.Text = "Порядок посещения экологических зон";
            label_OrderBFS.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBox_OrderBFS
            // 
            textBox_OrderBFS.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBox_OrderBFS.Location = new Point(3, 174);
            textBox_OrderBFS.Multiline = true;
            textBox_OrderBFS.Name = "textBox_OrderBFS";
            textBox_OrderBFS.ReadOnly = true;
            textBox_OrderBFS.Size = new Size(735, 218);
            textBox_OrderBFS.TabIndex = 3;
            // 
            // label_BFS
            // 
            label_BFS.Anchor = AnchorStyles.Top;
            label_BFS.BackColor = Color.Transparent;
            label_BFS.Font = new Font("Calibri", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label_BFS.ForeColor = SystemColors.ActiveCaptionText;
            label_BFS.Location = new Point(0, 0);
            label_BFS.Name = "label_BFS";
            label_BFS.Size = new Size(738, 45);
            label_BFS.TabIndex = 2;
            label_BFS.Text = "BFS (обход в ширину)";
            label_BFS.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tabPage_GraphСonnectivity
            // 
            tabPage_GraphСonnectivity.Controls.Add(panel_Reachability);
            tabPage_GraphСonnectivity.Controls.Add(panel_ConnectivityСomponents);
            tabPage_GraphСonnectivity.Location = new Point(8, 46);
            tabPage_GraphСonnectivity.Name = "tabPage_GraphСonnectivity";
            tabPage_GraphСonnectivity.Padding = new Padding(3);
            tabPage_GraphСonnectivity.Size = new Size(744, 1012);
            tabPage_GraphСonnectivity.TabIndex = 1;
            tabPage_GraphСonnectivity.Text = "Связность";
            tabPage_GraphСonnectivity.UseVisualStyleBackColor = true;
            // 
            // panel_Reachability
            // 
            panel_Reachability.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel_Reachability.Controls.Add(button_Reachability);
            panel_Reachability.Controls.Add(textBox_Reachability);
            panel_Reachability.Controls.Add(comboBox_VertexFrom);
            panel_Reachability.Controls.Add(label_VertexFrom);
            panel_Reachability.Controls.Add(label_VertexIn);
            panel_Reachability.Controls.Add(comboBox_VertexIn);
            panel_Reachability.Controls.Add(label_Reachability);
            panel_Reachability.Location = new Point(2, 3);
            panel_Reachability.Name = "panel_Reachability";
            panel_Reachability.Size = new Size(738, 505);
            panel_Reachability.TabIndex = 3;
            // 
            // button_Reachability
            // 
            button_Reachability.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button_Reachability.Location = new Point(1, 401);
            button_Reachability.Name = "button_Reachability";
            button_Reachability.Size = new Size(210, 104);
            button_Reachability.TabIndex = 14;
            button_Reachability.Text = "Рассчитать";
            button_Reachability.UseVisualStyleBackColor = true;
            button_Reachability.Click += GetBypassAlgorithms;
            // 
            // textBox_Reachability
            // 
            textBox_Reachability.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox_Reachability.Location = new Point(6, 152);
            textBox_Reachability.Multiline = true;
            textBox_Reachability.Name = "textBox_Reachability";
            textBox_Reachability.ReadOnly = true;
            textBox_Reachability.Size = new Size(732, 243);
            textBox_Reachability.TabIndex = 13;
            // 
            // comboBox_VertexFrom
            // 
            comboBox_VertexFrom.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_VertexFrom.FormattingEnabled = true;
            comboBox_VertexFrom.Location = new Point(499, 92);
            comboBox_VertexFrom.Name = "comboBox_VertexFrom";
            comboBox_VertexFrom.Size = new Size(114, 40);
            comboBox_VertexFrom.TabIndex = 12;
            // 
            // label_VertexFrom
            // 
            label_VertexFrom.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label_VertexFrom.BackColor = Color.Transparent;
            label_VertexFrom.Font = new Font("Calibri", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label_VertexFrom.ForeColor = SystemColors.ActiveCaptionText;
            label_VertexFrom.Location = new Point(106, 80);
            label_VertexFrom.Name = "label_VertexFrom";
            label_VertexFrom.Size = new Size(105, 52);
            label_VertexFrom.TabIndex = 11;
            label_VertexFrom.Text = "зоны";
            label_VertexFrom.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label_VertexIn
            // 
            label_VertexIn.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label_VertexIn.BackColor = Color.Transparent;
            label_VertexIn.Font = new Font("Calibri", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label_VertexIn.ForeColor = SystemColors.ActiveCaptionText;
            label_VertexIn.Location = new Point(350, 82);
            label_VertexIn.Name = "label_VertexIn";
            label_VertexIn.Size = new Size(153, 52);
            label_VertexIn.TabIndex = 10;
            label_VertexIn.Text = "из зоны";
            label_VertexIn.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // comboBox_VertexIn
            // 
            comboBox_VertexIn.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_VertexIn.FormattingEnabled = true;
            comboBox_VertexIn.Location = new Point(230, 92);
            comboBox_VertexIn.Name = "comboBox_VertexIn";
            comboBox_VertexIn.Size = new Size(114, 40);
            comboBox_VertexIn.TabIndex = 9;
            // 
            // label_Reachability
            // 
            label_Reachability.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label_Reachability.BackColor = Color.Transparent;
            label_Reachability.Font = new Font("Calibri", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label_Reachability.ForeColor = SystemColors.ActiveCaptionText;
            label_Reachability.Location = new Point(0, 0);
            label_Reachability.Name = "label_Reachability";
            label_Reachability.Size = new Size(738, 72);
            label_Reachability.TabIndex = 8;
            label_Reachability.Text = "Достижимость";
            label_Reachability.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel_ConnectivityСomponents
            // 
            panel_ConnectivityСomponents.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel_ConnectivityСomponents.Controls.Add(button_ConnectivityСomponents);
            panel_ConnectivityСomponents.Controls.Add(textBox_ConnectivityСomponents);
            panel_ConnectivityСomponents.Controls.Add(label__ConnectivityСomponents);
            panel_ConnectivityСomponents.Location = new Point(3, 508);
            panel_ConnectivityСomponents.Name = "panel_ConnectivityСomponents";
            panel_ConnectivityСomponents.Size = new Size(738, 498);
            panel_ConnectivityСomponents.TabIndex = 2;
            // 
            // button_ConnectivityСomponents
            // 
            button_ConnectivityСomponents.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button_ConnectivityСomponents.Location = new Point(8, 394);
            button_ConnectivityСomponents.Name = "button_ConnectivityСomponents";
            button_ConnectivityСomponents.Size = new Size(210, 104);
            button_ConnectivityСomponents.TabIndex = 9;
            button_ConnectivityСomponents.Text = "Рассчитать";
            button_ConnectivityСomponents.UseVisualStyleBackColor = true;
            button_ConnectivityСomponents.Click += GetBypassAlgorithms;
            // 
            // textBox_ConnectivityСomponents
            // 
            textBox_ConnectivityСomponents.Anchor = AnchorStyles.None;
            textBox_ConnectivityСomponents.Location = new Point(8, 75);
            textBox_ConnectivityСomponents.Multiline = true;
            textBox_ConnectivityСomponents.Name = "textBox_ConnectivityСomponents";
            textBox_ConnectivityСomponents.ReadOnly = true;
            textBox_ConnectivityСomponents.Size = new Size(732, 313);
            textBox_ConnectivityСomponents.TabIndex = 8;
            // 
            // label__ConnectivityСomponents
            // 
            label__ConnectivityСomponents.Anchor = AnchorStyles.Right;
            label__ConnectivityСomponents.BackColor = Color.Transparent;
            label__ConnectivityСomponents.Font = new Font("Calibri", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label__ConnectivityСomponents.ForeColor = SystemColors.ActiveCaptionText;
            label__ConnectivityСomponents.Location = new Point(-1, 0);
            label__ConnectivityСomponents.Name = "label__ConnectivityСomponents";
            label__ConnectivityСomponents.Size = new Size(738, 72);
            label__ConnectivityСomponents.TabIndex = 7;
            label__ConnectivityСomponents.Text = "Экологические ареалы связности";
            label__ConnectivityСomponents.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel_Buttons
            // 
            panel_Buttons.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            panel_Buttons.BackColor = Color.Transparent;
            panel_Buttons.Controls.Add(button_Return);
            panel_Buttons.Controls.Add(button_Info);
            panel_Buttons.Location = new Point(6, 1090);
            panel_Buttons.Name = "panel_Buttons";
            panel_Buttons.Size = new Size(763, 128);
            panel_Buttons.TabIndex = 3;
            // 
            // button_Return
            // 
            button_Return.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button_Return.BackColor = Color.Transparent;
            button_Return.Location = new Point(222, 21);
            button_Return.Name = "button_Return";
            button_Return.Size = new Size(210, 104);
            button_Return.TabIndex = 7;
            button_Return.Text = "Возврат в главное меню";
            button_Return.UseVisualStyleBackColor = false;
            button_Return.Visible = false;
            button_Return.Click += ReturnInMenu_button_Click;
            // 
            // button_Info
            // 
            button_Info.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button_Info.BackColor = Color.Transparent;
            button_Info.Location = new Point(6, 21);
            button_Info.Name = "button_Info";
            button_Info.Size = new Size(210, 104);
            button_Info.TabIndex = 6;
            button_Info.Text = "Справка пользователя";
            button_Info.UseVisualStyleBackColor = false;
            button_Info.Click += GetInfo;
            // 
            // panel_Home
            // 
            panel_Home.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel_Home.BackColor = Color.Transparent;
            panel_Home.Controls.Add(panel_HomeButtons);
            panel_Home.Controls.Add(label_NameApp);
            panel_Home.Controls.Add(label_TaskApp);
            panel_Home.Location = new Point(17, 12);
            panel_Home.Name = "panel_Home";
            panel_Home.Size = new Size(1433, 1206);
            panel_Home.TabIndex = 4;
            // 
            // panel_HomeButtons
            // 
            panel_HomeButtons.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel_HomeButtons.Controls.Add(button_LoadFile);
            panel_HomeButtons.Controls.Add(button_СrawlingАlgorithms);
            panel_HomeButtons.Controls.Add(button_DextraAlgorithm);
            panel_HomeButtons.Controls.Add(button_DepthAnalysis);
            panel_HomeButtons.Controls.Add(button_ExitApp);
            panel_HomeButtons.Location = new Point(434, 285);
            panel_HomeButtons.Name = "panel_HomeButtons";
            panel_HomeButtons.Size = new Size(582, 609);
            panel_HomeButtons.TabIndex = 15;
            // 
            // button_LoadFile
            // 
            button_LoadFile.Anchor = AnchorStyles.None;
            button_LoadFile.AutoSize = true;
            button_LoadFile.BackColor = Color.Transparent;
            button_LoadFile.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            button_LoadFile.Location = new Point(18, 71);
            button_LoadFile.Margin = new Padding(4, 2, 4, 2);
            button_LoadFile.Name = "button_LoadFile";
            button_LoadFile.Size = new Size(546, 90);
            button_LoadFile.TabIndex = 17;
            button_LoadFile.Text = "Загрузить файл";
            button_LoadFile.UseVisualStyleBackColor = false;
            button_LoadFile.Click += button_LoadFile_Click;
            // 
            // button_СrawlingАlgorithms
            // 
            button_СrawlingАlgorithms.Anchor = AnchorStyles.None;
            button_СrawlingАlgorithms.AutoSize = true;
            button_СrawlingАlgorithms.BackColor = Color.Transparent;
            button_СrawlingАlgorithms.Font = new Font("Calibri", 12F, FontStyle.Bold);
            button_СrawlingАlgorithms.Location = new Point(18, 165);
            button_СrawlingАlgorithms.Margin = new Padding(4, 2, 4, 2);
            button_СrawlingАlgorithms.Name = "button_СrawlingАlgorithms";
            button_СrawlingАlgorithms.Size = new Size(546, 90);
            button_СrawlingАlgorithms.TabIndex = 13;
            button_СrawlingАlgorithms.Text = "Алгоритмы обхода";
            button_СrawlingАlgorithms.UseVisualStyleBackColor = false;
            button_СrawlingАlgorithms.Click += Home_button_Click;
            // 
            // button_DextraAlgorithm
            // 
            button_DextraAlgorithm.Anchor = AnchorStyles.None;
            button_DextraAlgorithm.AutoSize = true;
            button_DextraAlgorithm.Font = new Font("Calibri", 12F, FontStyle.Bold);
            button_DextraAlgorithm.Location = new Point(18, 259);
            button_DextraAlgorithm.Margin = new Padding(4, 2, 4, 2);
            button_DextraAlgorithm.Name = "button_DextraAlgorithm";
            button_DextraAlgorithm.Size = new Size(546, 90);
            button_DextraAlgorithm.TabIndex = 14;
            button_DextraAlgorithm.Text = "Алгоритм Дейкстры";
            button_DextraAlgorithm.UseVisualStyleBackColor = true;
            button_DextraAlgorithm.Click += Home_button_Click;
            // 
            // button_DepthAnalysis
            // 
            button_DepthAnalysis.Anchor = AnchorStyles.None;
            button_DepthAnalysis.AutoSize = true;
            button_DepthAnalysis.Font = new Font("Calibri", 12F, FontStyle.Bold);
            button_DepthAnalysis.Location = new Point(18, 353);
            button_DepthAnalysis.Margin = new Padding(4, 2, 4, 2);
            button_DepthAnalysis.Name = "button_DepthAnalysis";
            button_DepthAnalysis.Size = new Size(546, 90);
            button_DepthAnalysis.TabIndex = 15;
            button_DepthAnalysis.Text = "Углублённый анализ графа";
            button_DepthAnalysis.UseVisualStyleBackColor = true;
            button_DepthAnalysis.Click += Home_button_Click;
            // 
            // button_ExitApp
            // 
            button_ExitApp.Anchor = AnchorStyles.None;
            button_ExitApp.AutoSize = true;
            button_ExitApp.Font = new Font("Calibri", 12F, FontStyle.Bold);
            button_ExitApp.Location = new Point(18, 447);
            button_ExitApp.Margin = new Padding(4, 2, 4, 2);
            button_ExitApp.Name = "button_ExitApp";
            button_ExitApp.Size = new Size(546, 90);
            button_ExitApp.TabIndex = 16;
            button_ExitApp.Text = "Выход из приложения";
            button_ExitApp.UseVisualStyleBackColor = true;
            button_ExitApp.Click += Home_button_Click;
            // 
            // label_NameApp
            // 
            label_NameApp.Anchor = AnchorStyles.Top;
            label_NameApp.Font = new Font("Calibri", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label_NameApp.Location = new Point(267, 33);
            label_NameApp.Name = "label_NameApp";
            label_NameApp.Size = new Size(888, 64);
            label_NameApp.TabIndex = 14;
            label_NameApp.Text = "Карта экологических зон";
            label_NameApp.TextAlign = ContentAlignment.TopCenter;
            // 
            // label_TaskApp
            // 
            label_TaskApp.Anchor = AnchorStyles.Top;
            label_TaskApp.Font = new Font("Calibri", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label_TaskApp.Location = new Point(267, 110);
            label_TaskApp.Name = "label_TaskApp";
            label_TaskApp.Size = new Size(888, 64);
            label_TaskApp.TabIndex = 13;
            label_TaskApp.Text = "Маршрут миграции животных между зонами";
            // 
            // Form_MapOfEcologicalZones
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1453, 1230);
            Controls.Add(panel_Buttons);
            Controls.Add(panel_BypassAlgorithm);
            Controls.Add(panel_AdjacencyList);
            Controls.Add(panel_DescriptionOfThePeaks);
            Controls.Add(panel_Home);
            Name = "Form_MapOfEcologicalZones";
            Text = "Карта экологических зон";
            panel_DescriptionOfThePeaks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView_DescriptionOfThePeaks).EndInit();
            panel_AdjacencyList.ResumeLayout(false);
            panel_AdjacencyList.PerformLayout();
            panel_BypassAlgorithm.ResumeLayout(false);
            tabControl_BypassAlgorithm.ResumeLayout(false);
            tabPage_BypassAlgorithms.ResumeLayout(false);
            panel_DFS.ResumeLayout(false);
            panel_DFS.PerformLayout();
            panel_BFS.ResumeLayout(false);
            panel_BFS.PerformLayout();
            tabPage_GraphСonnectivity.ResumeLayout(false);
            panel_Reachability.ResumeLayout(false);
            panel_Reachability.PerformLayout();
            panel_ConnectivityСomponents.ResumeLayout(false);
            panel_ConnectivityСomponents.PerformLayout();
            panel_Buttons.ResumeLayout(false);
            panel_Home.ResumeLayout(false);
            panel_HomeButtons.ResumeLayout(false);
            panel_HomeButtons.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel_DescriptionOfThePeaks;
        private Panel panel_AdjacencyList;
        private Panel panel_BypassAlgorithm;
        private Panel panel_Buttons;
        private Label label_DescriptionOfThePeaks;
        private Label label_AdjacencyList;
        private TabControl tabControl_BypassAlgorithm;
        private TabPage tabPage_BypassAlgorithms;
        private TabPage tabPage_GraphСonnectivity;
        private Panel panel_DFS;
        private Panel panel_BFS;
        private Label label_BFS;
        private Label label_DFS;
        private TextBox textBox_OrderBFS;
        private Label label_OrderDFS;
        private TextBox textBox_OrderDFS;
        private Label label_OrderBFS;
        private Button button_BFS;
        private Button button_DFS;
        private Button button_Return;
        private Button button_Info;
        private Panel panel_ConnectivityСomponents;
        private Button button_ConnectivityСomponents;
        private TextBox textBox_ConnectivityСomponents;
        private Label label__ConnectivityСomponents;
        private Panel panel_Reachability;
        private ComboBox comboBox_VertexIn;
        private Label label_Reachability;
        private TextBox textBox_Reachability;
        private ComboBox comboBox_VertexFrom;
        private Label label_VertexFrom;
        private Label label_VertexIn;
        private Button button_Reachability;
        private Panel panel_Home;
        private Label label_TaskApp;
        private Label label_NameApp;
        private Panel panel_HomeButtons;
        private Button button_LoadFile;
        private Button button_СrawlingАlgorithms;
        private Button button_DextraAlgorithm;
        private Button button_DepthAnalysis;
        private Button button_ExitApp;
        private TextBox textBox_AdjacencyList;
        private DataGridView dataGridView_DescriptionOfThePeaks;
        private Label label_ChooseBFS;
        private ComboBox comboBox_ChooseBFS;
        private ComboBox comboBox_ChooseDFS;
        private Label label_ChooseDFS;
    }
}
