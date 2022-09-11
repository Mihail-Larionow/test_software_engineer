namespace paycheck
{
    partial class Paycheck
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
            this.addButton = new System.Windows.Forms.Button();
            this.postСomboBox = new System.Windows.Forms.ComboBox();
            this.listView = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.connectionLabel = new System.Windows.Forms.Label();
            this.stateLabel = new System.Windows.Forms.Label();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.infoLabel3 = new System.Windows.Forms.Label();
            this.infoLabel2 = new System.Windows.Forms.Label();
            this.infoLabel1 = new System.Windows.Forms.Label();
            this.groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(227, 154);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(94, 27);
            this.addButton.TabIndex = 0;
            this.addButton.Text = "Добавить";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // postСomboBox
            // 
            this.postСomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.postСomboBox.FormattingEnabled = true;
            this.postСomboBox.Location = new System.Drawing.Point(15, 99);
            this.postСomboBox.Name = "postСomboBox";
            this.postСomboBox.Size = new System.Drawing.Size(200, 28);
            this.postСomboBox.TabIndex = 2;
            // 
            // listView
            // 
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView.GridLines = true;
            this.listView.Location = new System.Drawing.Point(12, 31);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(712, 236);
            this.listView.TabIndex = 3;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Должность";
            this.columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Дата";
            this.columnHeader2.Width = 80;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Ставка";
            this.columnHeader3.Width = 80;
            // 
            // connectionLabel
            // 
            this.connectionLabel.AutoSize = true;
            this.connectionLabel.Location = new System.Drawing.Point(23, 8);
            this.connectionLabel.Name = "connectionLabel";
            this.connectionLabel.Size = new System.Drawing.Size(0, 20);
            this.connectionLabel.TabIndex = 4;
            // 
            // stateLabel
            // 
            this.stateLabel.AutoSize = true;
            this.stateLabel.Location = new System.Drawing.Point(409, 449);
            this.stateLabel.Name = "stateLabel";
            this.stateLabel.Size = new System.Drawing.Size(0, 20);
            this.stateLabel.TabIndex = 5;
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.CustomFormat = "dd.MM.yyyy";
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker.Location = new System.Drawing.Point(15, 42);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(154, 27);
            this.dateTimePicker.TabIndex = 6;
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.numericUpDown);
            this.groupBox.Controls.Add(this.infoLabel3);
            this.groupBox.Controls.Add(this.dateTimePicker);
            this.groupBox.Controls.Add(this.infoLabel2);
            this.groupBox.Controls.Add(this.addButton);
            this.groupBox.Controls.Add(this.infoLabel1);
            this.groupBox.Controls.Add(this.postСomboBox);
            this.groupBox.Location = new System.Drawing.Point(12, 288);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(382, 196);
            this.groupBox.TabIndex = 7;
            this.groupBox.TabStop = false;
            // 
            // numericUpDown
            // 
            this.numericUpDown.Location = new System.Drawing.Point(15, 154);
            this.numericUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDown.Name = "numericUpDown";
            this.numericUpDown.Size = new System.Drawing.Size(154, 27);
            this.numericUpDown.TabIndex = 7;
            // 
            // infoLabel3
            // 
            this.infoLabel3.AutoSize = true;
            this.infoLabel3.Location = new System.Drawing.Point(15, 131);
            this.infoLabel3.Name = "infoLabel3";
            this.infoLabel3.Size = new System.Drawing.Size(55, 20);
            this.infoLabel3.TabIndex = 2;
            this.infoLabel3.Text = "Ставка";
            // 
            // infoLabel2
            // 
            this.infoLabel2.AutoSize = true;
            this.infoLabel2.Location = new System.Drawing.Point(15, 76);
            this.infoLabel2.Name = "infoLabel2";
            this.infoLabel2.Size = new System.Drawing.Size(86, 20);
            this.infoLabel2.TabIndex = 1;
            this.infoLabel2.Text = "Должность";
            // 
            // infoLabel1
            // 
            this.infoLabel1.AutoSize = true;
            this.infoLabel1.Location = new System.Drawing.Point(15, 19);
            this.infoLabel1.Name = "infoLabel1";
            this.infoLabel1.Size = new System.Drawing.Size(210, 20);
            this.infoLabel1.TabIndex = 0;
            this.infoLabel1.Text = "Дата начала действия ставки";
            // 
            // Paycheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 496);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.stateLabel);
            this.Controls.Add(this.connectionLabel);
            this.Controls.Add(this.listView);
            this.Name = "Paycheck";
            this.Text = "Ставка";
            this.Load += new System.EventHandler(this.Paycheck_Load);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button addButton;
        private ComboBox postСomboBox;
        private ListView listView;
        private Label connectionLabel;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private Label stateLabel;
        private DateTimePicker dateTimePicker;
        private GroupBox groupBox;
        private Label infoLabel3;
        private Label infoLabel2;
        private Label infoLabel1;
        private NumericUpDown numericUpDown;
    }
}