namespace OrganizacaoArquivos
{
    partial class App
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
            this.btnGerar1mSequencial = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSeqNum = new System.Windows.Forms.NumericUpDown();
            this.btnBuscarSequencial = new System.Windows.Forms.Button();
            this.btnInserirSequencial = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtResultado = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGerar1mSequencialIndexado = new System.Windows.Forms.Button();
            this.btnInserirSequencialIndexado = new System.Windows.Forms.Button();
            this.btnBuscarSequencialIndexado = new System.Windows.Forms.Button();
            this.txtSeqIndexadoNum = new System.Windows.Forms.NumericUpDown();
            this.btnBuscarAcessoDireto = new System.Windows.Forms.Button();
            this.btnInserirAcessoDireto = new System.Windows.Forms.Button();
            this.btnGerar1mAcessoDireto = new System.Windows.Forms.Button();
            this.txtAcessoDiretoNum = new System.Windows.Forms.NumericUpDown();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSeqNum)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSeqIndexadoNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAcessoDiretoNum)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGerar1mSequencial
            // 
            this.btnGerar1mSequencial.Location = new System.Drawing.Point(256, 19);
            this.btnGerar1mSequencial.Name = "btnGerar1mSequencial";
            this.btnGerar1mSequencial.Size = new System.Drawing.Size(98, 23);
            this.btnGerar1mSequencial.TabIndex = 0;
            this.btnGerar1mSequencial.Text = "Gerar arquivo 1M";
            this.btnGerar1mSequencial.UseVisualStyleBackColor = true;
            this.btnGerar1mSequencial.Click += new System.EventHandler(this.btnGerar1mSequencial_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtSeqNum);
            this.groupBox1.Controls.Add(this.btnBuscarSequencial);
            this.groupBox1.Controls.Add(this.btnInserirSequencial);
            this.groupBox1.Controls.Add(this.btnGerar1mSequencial);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(360, 50);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sequencial";
            // 
            // txtSeqNum
            // 
            this.txtSeqNum.Location = new System.Drawing.Point(7, 19);
            this.txtSeqNum.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.txtSeqNum.Name = "txtSeqNum";
            this.txtSeqNum.Size = new System.Drawing.Size(90, 20);
            this.txtSeqNum.TabIndex = 3;
            // 
            // btnBuscarSequencial
            // 
            this.btnBuscarSequencial.Location = new System.Drawing.Point(103, 19);
            this.btnBuscarSequencial.Name = "btnBuscarSequencial";
            this.btnBuscarSequencial.Size = new System.Drawing.Size(55, 20);
            this.btnBuscarSequencial.TabIndex = 2;
            this.btnBuscarSequencial.Text = "Buscar";
            this.btnBuscarSequencial.UseVisualStyleBackColor = true;
            this.btnBuscarSequencial.Click += new System.EventHandler(this.btnBuscarSequencial_Click);
            // 
            // btnInserirSequencial
            // 
            this.btnInserirSequencial.Location = new System.Drawing.Point(175, 19);
            this.btnInserirSequencial.Name = "btnInserirSequencial";
            this.btnInserirSequencial.Size = new System.Drawing.Size(75, 23);
            this.btnInserirSequencial.TabIndex = 1;
            this.btnInserirSequencial.Text = "Inserir";
            this.btnInserirSequencial.UseVisualStyleBackColor = true;
            this.btnInserirSequencial.Click += new System.EventHandler(this.btnInserirSequencial_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtSeqIndexadoNum);
            this.groupBox2.Controls.Add(this.btnBuscarSequencialIndexado);
            this.groupBox2.Controls.Add(this.btnInserirSequencialIndexado);
            this.groupBox2.Controls.Add(this.btnGerar1mSequencialIndexado);
            this.groupBox2.Location = new System.Drawing.Point(12, 68);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(360, 50);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sequencial Indexado";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtAcessoDiretoNum);
            this.groupBox3.Controls.Add(this.btnGerar1mAcessoDireto);
            this.groupBox3.Controls.Add(this.btnInserirAcessoDireto);
            this.groupBox3.Controls.Add(this.btnBuscarAcessoDireto);
            this.groupBox3.Location = new System.Drawing.Point(12, 124);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(360, 50);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Acesso direto";
            // 
            // txtResultado
            // 
            this.txtResultado.Location = new System.Drawing.Point(12, 208);
            this.txtResultado.Multiline = true;
            this.txtResultado.Name = "txtResultado";
            this.txtResultado.Size = new System.Drawing.Size(360, 129);
            this.txtResultado.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 192);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Resultado";
            // 
            // btnGerar1mSequencialIndexado
            // 
            this.btnGerar1mSequencialIndexado.Location = new System.Drawing.Point(256, 19);
            this.btnGerar1mSequencialIndexado.Name = "btnGerar1mSequencialIndexado";
            this.btnGerar1mSequencialIndexado.Size = new System.Drawing.Size(98, 23);
            this.btnGerar1mSequencialIndexado.TabIndex = 0;
            this.btnGerar1mSequencialIndexado.Text = "Gerar arquivo 1M";
            this.btnGerar1mSequencialIndexado.UseVisualStyleBackColor = true;
            this.btnGerar1mSequencialIndexado.Click += new System.EventHandler(this.btnGerar1mSequencialIndexado_Click);
            // 
            // btnInserirSequencialIndexado
            // 
            this.btnInserirSequencialIndexado.Location = new System.Drawing.Point(175, 21);
            this.btnInserirSequencialIndexado.Name = "btnInserirSequencialIndexado";
            this.btnInserirSequencialIndexado.Size = new System.Drawing.Size(75, 23);
            this.btnInserirSequencialIndexado.TabIndex = 1;
            this.btnInserirSequencialIndexado.Text = "Inserir";
            this.btnInserirSequencialIndexado.UseVisualStyleBackColor = true;
            this.btnInserirSequencialIndexado.Click += new System.EventHandler(this.btnInserirSequencialIndexado_Click);
            // 
            // btnBuscarSequencialIndexado
            // 
            this.btnBuscarSequencialIndexado.Location = new System.Drawing.Point(103, 21);
            this.btnBuscarSequencialIndexado.Name = "btnBuscarSequencialIndexado";
            this.btnBuscarSequencialIndexado.Size = new System.Drawing.Size(55, 21);
            this.btnBuscarSequencialIndexado.TabIndex = 2;
            this.btnBuscarSequencialIndexado.Text = "Buscar";
            this.btnBuscarSequencialIndexado.UseVisualStyleBackColor = true;
            this.btnBuscarSequencialIndexado.Click += new System.EventHandler(this.btnBuscarSequencialIndexado_Click);
            // 
            // txtSeqIndexadoNum
            // 
            this.txtSeqIndexadoNum.Location = new System.Drawing.Point(7, 20);
            this.txtSeqIndexadoNum.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.txtSeqIndexadoNum.Name = "txtSeqIndexadoNum";
            this.txtSeqIndexadoNum.Size = new System.Drawing.Size(90, 20);
            this.txtSeqIndexadoNum.TabIndex = 3;
            // 
            // btnBuscarAcessoDireto
            // 
            this.btnBuscarAcessoDireto.Location = new System.Drawing.Point(103, 20);
            this.btnBuscarAcessoDireto.Name = "btnBuscarAcessoDireto";
            this.btnBuscarAcessoDireto.Size = new System.Drawing.Size(55, 20);
            this.btnBuscarAcessoDireto.TabIndex = 0;
            this.btnBuscarAcessoDireto.Text = "Buscar";
            this.btnBuscarAcessoDireto.UseVisualStyleBackColor = true;
            this.btnBuscarAcessoDireto.Click += new System.EventHandler(this.btnBuscarAcessoDireto_Click);
            // 
            // btnInserirAcessoDireto
            // 
            this.btnInserirAcessoDireto.Location = new System.Drawing.Point(175, 20);
            this.btnInserirAcessoDireto.Name = "btnInserirAcessoDireto";
            this.btnInserirAcessoDireto.Size = new System.Drawing.Size(75, 23);
            this.btnInserirAcessoDireto.TabIndex = 1;
            this.btnInserirAcessoDireto.Text = "Inserir";
            this.btnInserirAcessoDireto.UseVisualStyleBackColor = true;
            this.btnInserirAcessoDireto.Click += new System.EventHandler(this.btnInserirAcessoDireto_Click);
            // 
            // btnGerar1mAcessoDireto
            // 
            this.btnGerar1mAcessoDireto.Location = new System.Drawing.Point(257, 20);
            this.btnGerar1mAcessoDireto.Name = "btnGerar1mAcessoDireto";
            this.btnGerar1mAcessoDireto.Size = new System.Drawing.Size(97, 23);
            this.btnGerar1mAcessoDireto.TabIndex = 2;
            this.btnGerar1mAcessoDireto.Text = "Gerar arquivo 1M";
            this.btnGerar1mAcessoDireto.UseVisualStyleBackColor = true;
            this.btnGerar1mAcessoDireto.Click += new System.EventHandler(this.btnGerar1mAcessoDireto_Click);
            // 
            // txtAcessoDiretoNum
            // 
            this.txtAcessoDiretoNum.Location = new System.Drawing.Point(7, 20);
            this.txtAcessoDiretoNum.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.txtAcessoDiretoNum.Name = "txtAcessoDiretoNum";
            this.txtAcessoDiretoNum.Size = new System.Drawing.Size(90, 20);
            this.txtAcessoDiretoNum.TabIndex = 3;
            // 
            // App
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 351);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtResultado);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "App";
            this.Text = "Organização de Arquivos";
            this.Load += new System.EventHandler(this.App_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtSeqNum)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtSeqIndexadoNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAcessoDiretoNum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGerar1mSequencial;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnInserirSequencial;
        private System.Windows.Forms.Button btnBuscarSequencial;
        private System.Windows.Forms.TextBox txtResultado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown txtSeqNum;
        private System.Windows.Forms.Button btnGerar1mSequencialIndexado;
        private System.Windows.Forms.Button btnInserirSequencialIndexado;
        private System.Windows.Forms.Button btnBuscarSequencialIndexado;
        private System.Windows.Forms.NumericUpDown txtSeqIndexadoNum;
        private System.Windows.Forms.NumericUpDown txtAcessoDiretoNum;
        private System.Windows.Forms.Button btnGerar1mAcessoDireto;
        private System.Windows.Forms.Button btnInserirAcessoDireto;
        private System.Windows.Forms.Button btnBuscarAcessoDireto;
    }
}