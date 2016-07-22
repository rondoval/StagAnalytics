namespace StagAnalytics
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.oscMainFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.mapTabs = new System.Windows.Forms.TabControl();
            this.sampleQty = new System.Windows.Forms.TabPage();
            this.sampleQuantity = new System.Windows.Forms.DataGridView();
            this.pbMap = new System.Windows.Forms.TabPage();
            this.pbMapView = new System.Windows.Forms.DataGridView();
            this.lpgMap = new System.Windows.Forms.TabPage();
            this.lpgMapView = new System.Windows.Forms.DataGridView();
            this.diffMap = new System.Windows.Forms.TabPage();
            this.diffMapView = new System.Windows.Forms.DataGridView();
            this.multiplierMap = new System.Windows.Forms.TabPage();
            this.multiplierMapView = new System.Windows.Forms.DataGridView();
            this.adjMultiMap = new System.Windows.Forms.TabPage();
            this.adjustedMultiplierMap = new System.Windows.Forms.DataGridView();
            this.openButton = new System.Windows.Forms.Button();
            this.appendButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.oscAdditionalFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.minRedTemp = new System.Windows.Forms.NumericUpDown();
            this.minLpgTemp = new System.Windows.Forms.NumericUpDown();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pbQuota = new System.Windows.Forms.DataGridView();
            this.mapTabs.SuspendLayout();
            this.sampleQty.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sampleQuantity)).BeginInit();
            this.pbMap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMapView)).BeginInit();
            this.lpgMap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lpgMapView)).BeginInit();
            this.diffMap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.diffMapView)).BeginInit();
            this.multiplierMap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.multiplierMapView)).BeginInit();
            this.adjMultiMap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adjustedMultiplierMap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minRedTemp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minLpgTemp)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbQuota)).BeginInit();
            this.SuspendLayout();
            // 
            // oscMainFileDialog
            // 
            this.oscMainFileDialog.DefaultExt = "osc";
            this.oscMainFileDialog.Filter = "OSC Files|*.osc";
            this.oscMainFileDialog.InitialDirectory = "D:\\Users\\lr\\Dysk Google\\Samochody\\Superb\\LPG\\mobile";
            this.oscMainFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.oscMainFileDialog_FileOk);
            // 
            // mapTabs
            // 
            this.mapTabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mapTabs.Controls.Add(this.sampleQty);
            this.mapTabs.Controls.Add(this.pbMap);
            this.mapTabs.Controls.Add(this.lpgMap);
            this.mapTabs.Controls.Add(this.diffMap);
            this.mapTabs.Controls.Add(this.multiplierMap);
            this.mapTabs.Controls.Add(this.adjMultiMap);
            this.mapTabs.Controls.Add(this.tabPage1);
            this.mapTabs.Location = new System.Drawing.Point(12, 84);
            this.mapTabs.Multiline = true;
            this.mapTabs.Name = "mapTabs";
            this.mapTabs.SelectedIndex = 0;
            this.mapTabs.Size = new System.Drawing.Size(1046, 383);
            this.mapTabs.TabIndex = 0;
            // 
            // sampleQty
            // 
            this.sampleQty.Controls.Add(this.sampleQuantity);
            this.sampleQty.Location = new System.Drawing.Point(4, 22);
            this.sampleQty.Name = "sampleQty";
            this.sampleQty.Padding = new System.Windows.Forms.Padding(3);
            this.sampleQty.Size = new System.Drawing.Size(1038, 357);
            this.sampleQty.TabIndex = 5;
            this.sampleQty.Text = "Sample quantity";
            this.sampleQty.UseVisualStyleBackColor = true;
            // 
            // sampleQuantity
            // 
            this.sampleQuantity.AllowUserToAddRows = false;
            this.sampleQuantity.AllowUserToDeleteRows = false;
            this.sampleQuantity.AllowUserToResizeColumns = false;
            this.sampleQuantity.AllowUserToResizeRows = false;
            this.sampleQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sampleQuantity.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.sampleQuantity.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.sampleQuantity.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sampleQuantity.Location = new System.Drawing.Point(6, 6);
            this.sampleQuantity.Name = "sampleQuantity";
            this.sampleQuantity.ReadOnly = true;
            this.sampleQuantity.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.sampleQuantity.Size = new System.Drawing.Size(1026, 345);
            this.sampleQuantity.TabIndex = 1;
            // 
            // pbMap
            // 
            this.pbMap.Controls.Add(this.pbMapView);
            this.pbMap.Location = new System.Drawing.Point(4, 22);
            this.pbMap.Name = "pbMap";
            this.pbMap.Padding = new System.Windows.Forms.Padding(3);
            this.pbMap.Size = new System.Drawing.Size(1038, 357);
            this.pbMap.TabIndex = 0;
            this.pbMap.Text = "PB Fuel Trim";
            this.pbMap.UseVisualStyleBackColor = true;
            // 
            // pbMapView
            // 
            this.pbMapView.AllowUserToAddRows = false;
            this.pbMapView.AllowUserToDeleteRows = false;
            this.pbMapView.AllowUserToResizeColumns = false;
            this.pbMapView.AllowUserToResizeRows = false;
            this.pbMapView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbMapView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.pbMapView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.pbMapView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.pbMapView.Location = new System.Drawing.Point(6, 6);
            this.pbMapView.Name = "pbMapView";
            this.pbMapView.ReadOnly = true;
            this.pbMapView.Size = new System.Drawing.Size(1026, 345);
            this.pbMapView.TabIndex = 0;
            // 
            // lpgMap
            // 
            this.lpgMap.Controls.Add(this.lpgMapView);
            this.lpgMap.Location = new System.Drawing.Point(4, 22);
            this.lpgMap.Name = "lpgMap";
            this.lpgMap.Padding = new System.Windows.Forms.Padding(3);
            this.lpgMap.Size = new System.Drawing.Size(1038, 357);
            this.lpgMap.TabIndex = 1;
            this.lpgMap.Text = "LPG Fuel Trim";
            this.lpgMap.UseVisualStyleBackColor = true;
            // 
            // lpgMapView
            // 
            this.lpgMapView.AllowUserToAddRows = false;
            this.lpgMapView.AllowUserToDeleteRows = false;
            this.lpgMapView.AllowUserToResizeColumns = false;
            this.lpgMapView.AllowUserToResizeRows = false;
            this.lpgMapView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lpgMapView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.lpgMapView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.lpgMapView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.lpgMapView.Location = new System.Drawing.Point(6, 6);
            this.lpgMapView.Name = "lpgMapView";
            this.lpgMapView.ReadOnly = true;
            this.lpgMapView.Size = new System.Drawing.Size(1026, 345);
            this.lpgMapView.TabIndex = 1;
            // 
            // diffMap
            // 
            this.diffMap.Controls.Add(this.diffMapView);
            this.diffMap.Location = new System.Drawing.Point(4, 22);
            this.diffMap.Name = "diffMap";
            this.diffMap.Size = new System.Drawing.Size(1038, 357);
            this.diffMap.TabIndex = 2;
            this.diffMap.Text = "Fuel Trim Diff";
            this.diffMap.UseVisualStyleBackColor = true;
            // 
            // diffMapView
            // 
            this.diffMapView.AllowUserToAddRows = false;
            this.diffMapView.AllowUserToDeleteRows = false;
            this.diffMapView.AllowUserToResizeColumns = false;
            this.diffMapView.AllowUserToResizeRows = false;
            this.diffMapView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.diffMapView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.diffMapView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.diffMapView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.diffMapView.Location = new System.Drawing.Point(3, 3);
            this.diffMapView.Name = "diffMapView";
            this.diffMapView.ReadOnly = true;
            this.diffMapView.Size = new System.Drawing.Size(1032, 351);
            this.diffMapView.TabIndex = 2;
            // 
            // multiplierMap
            // 
            this.multiplierMap.Controls.Add(this.multiplierMapView);
            this.multiplierMap.Location = new System.Drawing.Point(4, 22);
            this.multiplierMap.Name = "multiplierMap";
            this.multiplierMap.Size = new System.Drawing.Size(1038, 357);
            this.multiplierMap.TabIndex = 3;
            this.multiplierMap.Text = "Current Multiplier";
            this.multiplierMap.UseVisualStyleBackColor = true;
            // 
            // multiplierMapView
            // 
            this.multiplierMapView.AllowUserToAddRows = false;
            this.multiplierMapView.AllowUserToDeleteRows = false;
            this.multiplierMapView.AllowUserToResizeColumns = false;
            this.multiplierMapView.AllowUserToResizeRows = false;
            this.multiplierMapView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.multiplierMapView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.multiplierMapView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.multiplierMapView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.multiplierMapView.Location = new System.Drawing.Point(6, 6);
            this.multiplierMapView.Name = "multiplierMapView";
            this.multiplierMapView.ReadOnly = true;
            this.multiplierMapView.Size = new System.Drawing.Size(1029, 348);
            this.multiplierMapView.TabIndex = 2;
            // 
            // adjMultiMap
            // 
            this.adjMultiMap.Controls.Add(this.adjustedMultiplierMap);
            this.adjMultiMap.Location = new System.Drawing.Point(4, 22);
            this.adjMultiMap.Name = "adjMultiMap";
            this.adjMultiMap.Padding = new System.Windows.Forms.Padding(3);
            this.adjMultiMap.Size = new System.Drawing.Size(1038, 357);
            this.adjMultiMap.TabIndex = 4;
            this.adjMultiMap.Text = "Adjusted Multiplier";
            this.adjMultiMap.UseVisualStyleBackColor = true;
            // 
            // adjustedMultiplierMap
            // 
            this.adjustedMultiplierMap.AllowUserToAddRows = false;
            this.adjustedMultiplierMap.AllowUserToDeleteRows = false;
            this.adjustedMultiplierMap.AllowUserToResizeColumns = false;
            this.adjustedMultiplierMap.AllowUserToResizeRows = false;
            this.adjustedMultiplierMap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.adjustedMultiplierMap.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.adjustedMultiplierMap.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.adjustedMultiplierMap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.adjustedMultiplierMap.Location = new System.Drawing.Point(6, 6);
            this.adjustedMultiplierMap.Name = "adjustedMultiplierMap";
            this.adjustedMultiplierMap.ReadOnly = true;
            this.adjustedMultiplierMap.Size = new System.Drawing.Size(1026, 345);
            this.adjustedMultiplierMap.TabIndex = 3;
            // 
            // openButton
            // 
            this.openButton.Location = new System.Drawing.Point(16, 13);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(75, 23);
            this.openButton.TabIndex = 1;
            this.openButton.Text = "Open new...";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // appendButton
            // 
            this.appendButton.Location = new System.Drawing.Point(98, 13);
            this.appendButton.Name = "appendButton";
            this.appendButton.Size = new System.Drawing.Size(75, 23);
            this.appendButton.TabIndex = 2;
            this.appendButton.Text = "Append";
            this.appendButton.UseVisualStyleBackColor = true;
            this.appendButton.Click += new System.EventHandler(this.appendButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(248, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Min.  red. temp.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(252, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Min. gas temp.";
            // 
            // oscAdditionalFileDialog
            // 
            this.oscAdditionalFileDialog.DefaultExt = "osc";
            this.oscAdditionalFileDialog.Filter = "OSC Files|*.osc";
            this.oscAdditionalFileDialog.InitialDirectory = "D:\\Users\\lr\\Dysk Google\\Samochody\\Superb\\LPG\\mobile";
            this.oscAdditionalFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.oscAdditionalFileDialog_FileOk);
            // 
            // minRedTemp
            // 
            this.minRedTemp.Enabled = false;
            this.minRedTemp.Location = new System.Drawing.Point(334, 16);
            this.minRedTemp.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.minRedTemp.Name = "minRedTemp";
            this.minRedTemp.Size = new System.Drawing.Size(69, 20);
            this.minRedTemp.TabIndex = 6;
            this.minRedTemp.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.minRedTemp.ValueChanged += new System.EventHandler(this.minRedTemp_ValueChanged);
            this.minRedTemp.EnabledChanged += new System.EventHandler(this.minRedTemp_EnabledChanged);
            // 
            // minLpgTemp
            // 
            this.minLpgTemp.Enabled = false;
            this.minLpgTemp.Location = new System.Drawing.Point(334, 43);
            this.minLpgTemp.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.minLpgTemp.Name = "minLpgTemp";
            this.minLpgTemp.Size = new System.Drawing.Size(69, 20);
            this.minLpgTemp.TabIndex = 7;
            this.minLpgTemp.ValueChanged += new System.EventHandler(this.minLpgTemp_ValueChanged);
            this.minLpgTemp.EnabledChanged += new System.EventHandler(this.minLpgTemp_EnabledChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pbQuota);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1038, 357);
            this.tabPage1.TabIndex = 6;
            this.tabPage1.Text = "PB quota";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // pbQuota
            // 
            this.pbQuota.AllowUserToAddRows = false;
            this.pbQuota.AllowUserToDeleteRows = false;
            this.pbQuota.AllowUserToResizeColumns = false;
            this.pbQuota.AllowUserToResizeRows = false;
            this.pbQuota.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbQuota.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.pbQuota.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.pbQuota.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.pbQuota.Location = new System.Drawing.Point(6, 6);
            this.pbQuota.Name = "pbQuota";
            this.pbQuota.ReadOnly = true;
            this.pbQuota.Size = new System.Drawing.Size(1026, 345);
            this.pbQuota.TabIndex = 4;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1070, 479);
            this.Controls.Add(this.minLpgTemp);
            this.Controls.Add(this.minRedTemp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.appendButton);
            this.Controls.Add(this.openButton);
            this.Controls.Add(this.mapTabs);
            this.Name = "Main";
            this.Text = "STAG Analytics";
            this.mapTabs.ResumeLayout(false);
            this.sampleQty.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sampleQuantity)).EndInit();
            this.pbMap.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbMapView)).EndInit();
            this.lpgMap.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lpgMapView)).EndInit();
            this.diffMap.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.diffMapView)).EndInit();
            this.multiplierMap.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.multiplierMapView)).EndInit();
            this.adjMultiMap.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.adjustedMultiplierMap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minRedTemp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minLpgTemp)).EndInit();
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbQuota)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog oscMainFileDialog;
        private System.Windows.Forms.TabControl mapTabs;
        private System.Windows.Forms.TabPage pbMap;
        private System.Windows.Forms.TabPage lpgMap;
        private System.Windows.Forms.TabPage diffMap;
        private System.Windows.Forms.TabPage multiplierMap;
        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.DataGridView pbMapView;
        private System.Windows.Forms.DataGridView lpgMapView;
        private System.Windows.Forms.DataGridView diffMapView;
        private System.Windows.Forms.DataGridView multiplierMapView;
        private System.Windows.Forms.TabPage adjMultiMap;
        private System.Windows.Forms.DataGridView adjustedMultiplierMap;
        private System.Windows.Forms.TabPage sampleQty;
        private System.Windows.Forms.DataGridView sampleQuantity;
        private System.Windows.Forms.Button appendButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog oscAdditionalFileDialog;
        private System.Windows.Forms.NumericUpDown minRedTemp;
        private System.Windows.Forms.NumericUpDown minLpgTemp;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView pbQuota;
    }
}

