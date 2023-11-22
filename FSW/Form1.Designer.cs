namespace FSW
{
    partial class Form1
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
            textBoxSendMessage = new TextBox();
            textBoxReceivedMessages1 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            checkBoxCrypt = new CheckBox();
            btnSend1 = new Button();
            buttonClear = new Button();
            decryptButton = new Button();
            decryptedBox = new TextBox();
            label3 = new Label();
            SuspendLayout();
            // 
            // textBoxSendMessage
            // 
            textBoxSendMessage.Location = new Point(122, 55);
            textBoxSendMessage.Name = "textBoxSendMessage";
            textBoxSendMessage.Size = new Size(100, 23);
            textBoxSendMessage.TabIndex = 0;
            textBoxSendMessage.TextChanged += textBoxSendMessage_TextChanged;
            // 
            // textBoxReceivedMessages1
            // 
            textBoxReceivedMessages1.Location = new Point(453, 55);
            textBoxReceivedMessages1.Name = "textBoxReceivedMessages1";
            textBoxReceivedMessages1.Size = new Size(156, 23);
            textBoxReceivedMessages1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(133, 24);
            label1.Name = "label1";
            label1.Size = new Size(80, 15);
            label1.TabIndex = 2;
            label1.Text = "Unesi poruku:";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(453, 24);
            label2.Name = "label2";
            label2.Size = new Size(107, 15);
            label2.TabIndex = 3;
            label2.Text = "Kriptovana Poruka:";
            // 
            // checkBoxCrypt
            // 
            checkBoxCrypt.AutoSize = true;
            checkBoxCrypt.Location = new Point(313, 59);
            checkBoxCrypt.Name = "checkBoxCrypt";
            checkBoxCrypt.Size = new Size(85, 19);
            checkBoxCrypt.TabIndex = 4;
            checkBoxCrypt.Text = "kriptovanje";
            checkBoxCrypt.UseVisualStyleBackColor = true;
            checkBoxCrypt.CheckedChanged += checkBoxCrypt_CheckedChanged_1;
            // 
            // btnSend1
            // 
            btnSend1.Location = new Point(133, 110);
            btnSend1.Name = "btnSend1";
            btnSend1.Size = new Size(75, 23);
            btnSend1.TabIndex = 5;
            btnSend1.Text = "Send";
            btnSend1.UseVisualStyleBackColor = true;
            btnSend1.Click += btnSend1_Click;
            // 
            // buttonClear
            // 
            buttonClear.Location = new Point(629, 55);
            buttonClear.Name = "buttonClear";
            buttonClear.Size = new Size(75, 23);
            buttonClear.TabIndex = 6;
            buttonClear.Text = "Clear";
            buttonClear.UseVisualStyleBackColor = true;
            buttonClear.Click += buttonClear_Click;
            // 
            // decryptButton
            // 
            decryptButton.Location = new Point(629, 135);
            decryptButton.Name = "decryptButton";
            decryptButton.Size = new Size(75, 23);
            decryptButton.TabIndex = 7;
            decryptButton.Text = "Decrypt";
            decryptButton.UseVisualStyleBackColor = true;
            decryptButton.Click += decryptButton_Click;
            // 
            // decryptedBox
            // 
            decryptedBox.Location = new Point(453, 136);
            decryptedBox.Name = "decryptedBox";
            decryptedBox.Size = new Size(156, 23);
            decryptedBox.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(453, 110);
            label3.Name = "label3";
            label3.Size = new Size(120, 15);
            label3.TabIndex = 9;
            label3.Text = "Dekriptovana poruka:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(decryptedBox);
            Controls.Add(decryptButton);
            Controls.Add(buttonClear);
            Controls.Add(btnSend1);
            Controls.Add(checkBoxCrypt);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBoxReceivedMessages1);
            Controls.Add(textBoxSendMessage);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxSendMessage;
        private TextBox textBoxReceivedMessages1;
        private Label label1;
        private Label label2;
        private CheckBox checkBoxCrypt;
        private Button btnSend1;
        private Button buttonClear;
        private Button decryptButton;
        private TextBox decryptedBox;
        private Label label3;
    }
}
