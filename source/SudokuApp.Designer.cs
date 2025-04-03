namespace SudokuGameApp
{
    partial class SudokuApp
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SudokuApp));
            this.menuTopBar = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.fileSaveMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.fileLoadMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.fileExitMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showCollisionsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.collisionsOn = new System.Windows.Forms.ToolStripMenuItem();
            this.collisionsOff = new System.Windows.Forms.ToolStripMenuItem();
            this.useMultiThreadingMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.threadingOn = new System.Windows.Forms.ToolStripMenuItem();
            this.threadingOff = new System.Windows.Forms.ToolStripMenuItem();
            this.showTimerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showTimerOnMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showTimerOffMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectLanguageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englishLanguageMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.germanLanguageMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.japaneseLanguageMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearBoardMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkCollisionsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generatePuzzleMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.solvePuzzleMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startTimerMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopTimerMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetTimerMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.difficultyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.likeAGardenDifficultyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toasterDifficultyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hellDifficultyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ootwDifficultyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.helpRulesMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.gitHubToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.otherGamesGeneratorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.battleshipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.snowflakeIDGeneratorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pathCollisionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dDungeonBuilderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sevenBridgesOfKonigsbergToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sudokuGrid = new System.Windows.Forms.TableLayoutPanel();
            this.threadingBox = new System.Windows.Forms.CheckBox();
            this.settingsBox = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.generatePuzzle = new System.Windows.Forms.Button();
            this.checkCollisions = new System.Windows.Forms.Button();
            this.actionsTitle = new System.Windows.Forms.Label();
            this.clearBoardButton = new System.Windows.Forms.Button();
            this.responseTitle = new System.Windows.Forms.Label();
            this.responseMessageBox = new System.Windows.Forms.RichTextBox();
            this.maxThreadsToUseInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.solveButton = new System.Windows.Forms.Button();
            this.timerButton = new System.Windows.Forms.Button();
            this.timerLabel = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.resetTimer = new System.Windows.Forms.Button();
            this.menuTopBar.SuspendLayout();
            this.settingsBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuTopBar
            // 
            this.menuTopBar.BackColor = System.Drawing.Color.LightGray;
            this.menuTopBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.settingsMenuItem,
            this.actionsToolStripMenuItem,
            this.generationToolStripMenuItem,
            this.helpMenu});
            resources.ApplyResources(this.menuTopBar, "menuTopBar");
            this.menuTopBar.Name = "menuTopBar";
            // 
            // fileMenu
            // 
            this.fileMenu.BackColor = System.Drawing.Color.LightGray;
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileSaveMenu,
            this.fileLoadMenu,
            this.fileExitMenu});
            resources.ApplyResources(this.fileMenu, "fileMenu");
            this.fileMenu.Name = "fileMenu";
            // 
            // fileSaveMenu
            // 
            this.fileSaveMenu.BackColor = System.Drawing.SystemColors.Control;
            this.fileSaveMenu.Name = "fileSaveMenu";
            resources.ApplyResources(this.fileSaveMenu, "fileSaveMenu");
            this.fileSaveMenu.Click += new System.EventHandler(this.fileSaveMenu_Click);
            // 
            // fileLoadMenu
            // 
            this.fileLoadMenu.Name = "fileLoadMenu";
            resources.ApplyResources(this.fileLoadMenu, "fileLoadMenu");
            this.fileLoadMenu.Click += new System.EventHandler(this.fileLoadMenu_Click);
            // 
            // fileExitMenu
            // 
            this.fileExitMenu.Name = "fileExitMenu";
            resources.ApplyResources(this.fileExitMenu, "fileExitMenu");
            this.fileExitMenu.Click += new System.EventHandler(this.exitMenuItem_Click);
            // 
            // settingsMenuItem
            // 
            this.settingsMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showCollisionsMenuItem,
            this.useMultiThreadingMenuItem,
            this.showTimerToolStripMenuItem,
            this.selectLanguageToolStripMenuItem});
            this.settingsMenuItem.Name = "settingsMenuItem";
            resources.ApplyResources(this.settingsMenuItem, "settingsMenuItem");
            // 
            // showCollisionsMenuItem
            // 
            this.showCollisionsMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.collisionsOn,
            this.collisionsOff});
            this.showCollisionsMenuItem.Name = "showCollisionsMenuItem";
            resources.ApplyResources(this.showCollisionsMenuItem, "showCollisionsMenuItem");
            // 
            // collisionsOn
            // 
            this.collisionsOn.Name = "collisionsOn";
            resources.ApplyResources(this.collisionsOn, "collisionsOn");
            this.collisionsOn.Click += new System.EventHandler(this.collisionsOn_Click);
            // 
            // collisionsOff
            // 
            this.collisionsOff.Name = "collisionsOff";
            resources.ApplyResources(this.collisionsOff, "collisionsOff");
            this.collisionsOff.Click += new System.EventHandler(this.collisionsOff_Click);
            // 
            // useMultiThreadingMenuItem
            // 
            this.useMultiThreadingMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.threadingOn,
            this.threadingOff});
            this.useMultiThreadingMenuItem.Name = "useMultiThreadingMenuItem";
            resources.ApplyResources(this.useMultiThreadingMenuItem, "useMultiThreadingMenuItem");
            // 
            // threadingOn
            // 
            this.threadingOn.Name = "threadingOn";
            resources.ApplyResources(this.threadingOn, "threadingOn");
            this.threadingOn.Click += new System.EventHandler(this.threadingOn_Click);
            // 
            // threadingOff
            // 
            this.threadingOff.Name = "threadingOff";
            resources.ApplyResources(this.threadingOff, "threadingOff");
            this.threadingOff.Click += new System.EventHandler(this.threadingOff_Click);
            // 
            // showTimerToolStripMenuItem
            // 
            this.showTimerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showTimerOnMenuItem,
            this.showTimerOffMenuItem});
            this.showTimerToolStripMenuItem.Name = "showTimerToolStripMenuItem";
            resources.ApplyResources(this.showTimerToolStripMenuItem, "showTimerToolStripMenuItem");
            // 
            // showTimerOnMenuItem
            // 
            this.showTimerOnMenuItem.Name = "showTimerOnMenuItem";
            resources.ApplyResources(this.showTimerOnMenuItem, "showTimerOnMenuItem");
            this.showTimerOnMenuItem.Click += new System.EventHandler(this.showTimerOnMenuItem_Click);
            // 
            // showTimerOffMenuItem
            // 
            this.showTimerOffMenuItem.Name = "showTimerOffMenuItem";
            resources.ApplyResources(this.showTimerOffMenuItem, "showTimerOffMenuItem");
            this.showTimerOffMenuItem.Click += new System.EventHandler(this.offToolStripMenuItem_Click);
            // 
            // selectLanguageToolStripMenuItem
            // 
            this.selectLanguageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.englishLanguageMenuItem,
            this.germanLanguageMenuItem,
            this.japaneseLanguageMenuItem});
            this.selectLanguageToolStripMenuItem.Name = "selectLanguageToolStripMenuItem";
            resources.ApplyResources(this.selectLanguageToolStripMenuItem, "selectLanguageToolStripMenuItem");
            // 
            // englishLanguageMenuItem
            // 
            this.englishLanguageMenuItem.Name = "englishLanguageMenuItem";
            resources.ApplyResources(this.englishLanguageMenuItem, "englishLanguageMenuItem");
            this.englishLanguageMenuItem.Click += new System.EventHandler(this.englishLanguageMenuItem_Click);
            // 
            // germanLanguageMenuItem
            // 
            this.germanLanguageMenuItem.Name = "germanLanguageMenuItem";
            resources.ApplyResources(this.germanLanguageMenuItem, "germanLanguageMenuItem");
            this.germanLanguageMenuItem.Click += new System.EventHandler(this.germanLanguageMenuItem_Click);
            // 
            // japaneseLanguageMenuItem
            // 
            this.japaneseLanguageMenuItem.Name = "japaneseLanguageMenuItem";
            resources.ApplyResources(this.japaneseLanguageMenuItem, "japaneseLanguageMenuItem");
            this.japaneseLanguageMenuItem.Click += new System.EventHandler(this.japaneseLanguageMenuItem_Click);
            // 
            // actionsToolStripMenuItem
            // 
            this.actionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearBoardMenuItem,
            this.checkCollisionsMenuItem,
            this.generatePuzzleMenuItem,
            this.solvePuzzleMenuItem,
            this.timerToolStripMenuItem});
            this.actionsToolStripMenuItem.Name = "actionsToolStripMenuItem";
            resources.ApplyResources(this.actionsToolStripMenuItem, "actionsToolStripMenuItem");
            // 
            // clearBoardMenuItem
            // 
            this.clearBoardMenuItem.Name = "clearBoardMenuItem";
            resources.ApplyResources(this.clearBoardMenuItem, "clearBoardMenuItem");
            this.clearBoardMenuItem.Click += new System.EventHandler(this.clearBoardButton_Click);
            // 
            // checkCollisionsMenuItem
            // 
            this.checkCollisionsMenuItem.Name = "checkCollisionsMenuItem";
            resources.ApplyResources(this.checkCollisionsMenuItem, "checkCollisionsMenuItem");
            this.checkCollisionsMenuItem.Click += new System.EventHandler(this.checkCollisions_Click);
            // 
            // generatePuzzleMenuItem
            // 
            this.generatePuzzleMenuItem.Name = "generatePuzzleMenuItem";
            resources.ApplyResources(this.generatePuzzleMenuItem, "generatePuzzleMenuItem");
            this.generatePuzzleMenuItem.Click += new System.EventHandler(this.generatePuzzle_Click);
            // 
            // solvePuzzleMenuItem
            // 
            this.solvePuzzleMenuItem.Name = "solvePuzzleMenuItem";
            resources.ApplyResources(this.solvePuzzleMenuItem, "solvePuzzleMenuItem");
            this.solvePuzzleMenuItem.Click += new System.EventHandler(this.solveButton_Click);
            // 
            // timerToolStripMenuItem
            // 
            this.timerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startTimerMenuItem,
            this.stopTimerMenuItem,
            this.resetTimerMenuItem});
            this.timerToolStripMenuItem.Name = "timerToolStripMenuItem";
            resources.ApplyResources(this.timerToolStripMenuItem, "timerToolStripMenuItem");
            // 
            // startTimerMenuItem
            // 
            this.startTimerMenuItem.Name = "startTimerMenuItem";
            resources.ApplyResources(this.startTimerMenuItem, "startTimerMenuItem");
            this.startTimerMenuItem.Click += new System.EventHandler(this.startTimerMenuItem_Click);
            // 
            // stopTimerMenuItem
            // 
            this.stopTimerMenuItem.Name = "stopTimerMenuItem";
            resources.ApplyResources(this.stopTimerMenuItem, "stopTimerMenuItem");
            this.stopTimerMenuItem.Click += new System.EventHandler(this.stopTimerMenuItem_Click);
            // 
            // resetTimerMenuItem
            // 
            this.resetTimerMenuItem.Name = "resetTimerMenuItem";
            resources.ApplyResources(this.resetTimerMenuItem, "resetTimerMenuItem");
            this.resetTimerMenuItem.Click += new System.EventHandler(this.resetTimer_Click);
            // 
            // generationToolStripMenuItem
            // 
            this.generationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.difficultyToolStripMenuItem});
            this.generationToolStripMenuItem.Name = "generationToolStripMenuItem";
            resources.ApplyResources(this.generationToolStripMenuItem, "generationToolStripMenuItem");
            // 
            // difficultyToolStripMenuItem
            // 
            this.difficultyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.likeAGardenDifficultyMenuItem,
            this.toasterDifficultyMenuItem,
            this.hellDifficultyMenuItem,
            this.ootwDifficultyMenuItem});
            this.difficultyToolStripMenuItem.Name = "difficultyToolStripMenuItem";
            resources.ApplyResources(this.difficultyToolStripMenuItem, "difficultyToolStripMenuItem");
            // 
            // likeAGardenDifficultyMenuItem
            // 
            this.likeAGardenDifficultyMenuItem.Name = "likeAGardenDifficultyMenuItem";
            resources.ApplyResources(this.likeAGardenDifficultyMenuItem, "likeAGardenDifficultyMenuItem");
            this.likeAGardenDifficultyMenuItem.Click += new System.EventHandler(this.likeAGardenDifficultyMenuItem_Click);
            // 
            // toasterDifficultyMenuItem
            // 
            this.toasterDifficultyMenuItem.Name = "toasterDifficultyMenuItem";
            resources.ApplyResources(this.toasterDifficultyMenuItem, "toasterDifficultyMenuItem");
            this.toasterDifficultyMenuItem.Click += new System.EventHandler(this.toasterDifficultyMenuItem_Click);
            // 
            // hellDifficultyMenuItem
            // 
            this.hellDifficultyMenuItem.Name = "hellDifficultyMenuItem";
            resources.ApplyResources(this.hellDifficultyMenuItem, "hellDifficultyMenuItem");
            this.hellDifficultyMenuItem.Click += new System.EventHandler(this.hellDifficultyMenuItem_Click);
            // 
            // ootwDifficultyMenuItem
            // 
            this.ootwDifficultyMenuItem.Name = "ootwDifficultyMenuItem";
            resources.ApplyResources(this.ootwDifficultyMenuItem, "ootwDifficultyMenuItem");
            this.ootwDifficultyMenuItem.Click += new System.EventHandler(this.ootwDifficultyMenuItem_Click);
            // 
            // helpMenu
            // 
            this.helpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpRulesMenu,
            this.gitHubToolStripMenuItem,
            this.otherGamesGeneratorsToolStripMenuItem});
            this.helpMenu.Name = "helpMenu";
            resources.ApplyResources(this.helpMenu, "helpMenu");
            // 
            // helpRulesMenu
            // 
            this.helpRulesMenu.Name = "helpRulesMenu";
            resources.ApplyResources(this.helpRulesMenu, "helpRulesMenu");
            this.helpRulesMenu.Click += new System.EventHandler(this.helpRulesMenu_Click);
            // 
            // gitHubToolStripMenuItem
            // 
            this.gitHubToolStripMenuItem.Name = "gitHubToolStripMenuItem";
            resources.ApplyResources(this.gitHubToolStripMenuItem, "gitHubToolStripMenuItem");
            this.gitHubToolStripMenuItem.Click += new System.EventHandler(this.gitHubToolStripMenuItem_Click);
            // 
            // otherGamesGeneratorsToolStripMenuItem
            // 
            this.otherGamesGeneratorsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.battleshipToolStripMenuItem,
            this.toolStripMenuItem1,
            this.snowflakeIDGeneratorToolStripMenuItem,
            this.pathCollisionToolStripMenuItem,
            this.dDungeonBuilderToolStripMenuItem,
            this.sevenBridgesOfKonigsbergToolStripMenuItem});
            this.otherGamesGeneratorsToolStripMenuItem.Name = "otherGamesGeneratorsToolStripMenuItem";
            resources.ApplyResources(this.otherGamesGeneratorsToolStripMenuItem, "otherGamesGeneratorsToolStripMenuItem");
            // 
            // battleshipToolStripMenuItem
            // 
            this.battleshipToolStripMenuItem.Name = "battleshipToolStripMenuItem";
            resources.ApplyResources(this.battleshipToolStripMenuItem, "battleshipToolStripMenuItem");
            this.battleshipToolStripMenuItem.Click += new System.EventHandler(this.battleshipToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            this.toolStripMenuItem1.Click += new System.EventHandler(this.queenProblemStripMenuItem1_Click);
            // 
            // snowflakeIDGeneratorToolStripMenuItem
            // 
            this.snowflakeIDGeneratorToolStripMenuItem.Name = "snowflakeIDGeneratorToolStripMenuItem";
            resources.ApplyResources(this.snowflakeIDGeneratorToolStripMenuItem, "snowflakeIDGeneratorToolStripMenuItem");
            this.snowflakeIDGeneratorToolStripMenuItem.Click += new System.EventHandler(this.snowflakeIDGeneratorToolStripMenuItem_Click);
            // 
            // pathCollisionToolStripMenuItem
            // 
            this.pathCollisionToolStripMenuItem.Name = "pathCollisionToolStripMenuItem";
            resources.ApplyResources(this.pathCollisionToolStripMenuItem, "pathCollisionToolStripMenuItem");
            this.pathCollisionToolStripMenuItem.Click += new System.EventHandler(this.pathCollisionToolStripMenuItem_Click);
            // 
            // dDungeonBuilderToolStripMenuItem
            // 
            this.dDungeonBuilderToolStripMenuItem.Name = "dDungeonBuilderToolStripMenuItem";
            resources.ApplyResources(this.dDungeonBuilderToolStripMenuItem, "dDungeonBuilderToolStripMenuItem");
            this.dDungeonBuilderToolStripMenuItem.Click += new System.EventHandler(this.dDungeonBuilderToolStripMenuItem_Click);
            // 
            // sevenBridgesOfKonigsbergToolStripMenuItem
            // 
            this.sevenBridgesOfKonigsbergToolStripMenuItem.Name = "sevenBridgesOfKonigsbergToolStripMenuItem";
            resources.ApplyResources(this.sevenBridgesOfKonigsbergToolStripMenuItem, "sevenBridgesOfKonigsbergToolStripMenuItem");
            this.sevenBridgesOfKonigsbergToolStripMenuItem.Click += new System.EventHandler(this.sevenBridgesOfKonigsbergToolStripMenuItem_Click);
            // 
            // sudokuGrid
            // 
            resources.ApplyResources(this.sudokuGrid, "sudokuGrid");
            this.sudokuGrid.BackColor = System.Drawing.Color.WhiteSmoke;
            this.sudokuGrid.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.sudokuGrid.Name = "sudokuGrid";
            // 
            // threadingBox
            // 
            resources.ApplyResources(this.threadingBox, "threadingBox");
            this.threadingBox.BackColor = System.Drawing.Color.LightGray;
            this.threadingBox.Name = "threadingBox";
            this.threadingBox.UseVisualStyleBackColor = false;
            this.threadingBox.CheckedChanged += new System.EventHandler(this.threadingBox_CheckedChanged);
            // 
            // settingsBox
            // 
            resources.ApplyResources(this.settingsBox, "settingsBox");
            this.settingsBox.Controls.Add(this.label2);
            this.settingsBox.Controls.Add(this.generatePuzzle);
            this.settingsBox.Controls.Add(this.checkCollisions);
            this.settingsBox.Controls.Add(this.actionsTitle);
            this.settingsBox.Controls.Add(this.clearBoardButton);
            this.settingsBox.Controls.Add(this.responseTitle);
            this.settingsBox.Controls.Add(this.responseMessageBox);
            this.settingsBox.Controls.Add(this.maxThreadsToUseInput);
            this.settingsBox.Controls.Add(this.label1);
            this.settingsBox.Controls.Add(this.threadingBox);
            this.settingsBox.Controls.Add(this.solveButton);
            this.settingsBox.Name = "settingsBox";
            this.settingsBox.TabStop = false;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // generatePuzzle
            // 
            resources.ApplyResources(this.generatePuzzle, "generatePuzzle");
            this.generatePuzzle.Name = "generatePuzzle";
            this.generatePuzzle.UseVisualStyleBackColor = true;
            this.generatePuzzle.Click += new System.EventHandler(this.generatePuzzle_Click);
            // 
            // checkCollisions
            // 
            resources.ApplyResources(this.checkCollisions, "checkCollisions");
            this.checkCollisions.Name = "checkCollisions";
            this.checkCollisions.UseVisualStyleBackColor = true;
            this.checkCollisions.Click += new System.EventHandler(this.checkCollisions_Click);
            // 
            // actionsTitle
            // 
            resources.ApplyResources(this.actionsTitle, "actionsTitle");
            this.actionsTitle.Name = "actionsTitle";
            // 
            // clearBoardButton
            // 
            resources.ApplyResources(this.clearBoardButton, "clearBoardButton");
            this.clearBoardButton.Name = "clearBoardButton";
            this.clearBoardButton.UseVisualStyleBackColor = true;
            this.clearBoardButton.Click += new System.EventHandler(this.clearBoardButton_Click);
            // 
            // responseTitle
            // 
            resources.ApplyResources(this.responseTitle, "responseTitle");
            this.responseTitle.Name = "responseTitle";
            // 
            // responseMessageBox
            // 
            this.responseMessageBox.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.responseMessageBox.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.responseMessageBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.responseMessageBox, "responseMessageBox");
            this.responseMessageBox.Name = "responseMessageBox";
            this.responseMessageBox.ReadOnly = true;
            this.responseMessageBox.TabStop = false;
            // 
            // maxThreadsToUseInput
            // 
            resources.ApplyResources(this.maxThreadsToUseInput, "maxThreadsToUseInput");
            this.maxThreadsToUseInput.BackColor = System.Drawing.Color.RosyBrown;
            this.maxThreadsToUseInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.maxThreadsToUseInput.Name = "maxThreadsToUseInput";
            this.maxThreadsToUseInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.maxThreadsToUseInput_KeyPress);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // solveButton
            // 
            this.solveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            resources.ApplyResources(this.solveButton, "solveButton");
            this.solveButton.Name = "solveButton";
            this.solveButton.UseVisualStyleBackColor = false;
            this.solveButton.Click += new System.EventHandler(this.solveButton_Click);
            // 
            // timerButton
            // 
            resources.ApplyResources(this.timerButton, "timerButton");
            this.timerButton.Name = "timerButton";
            this.timerButton.UseVisualStyleBackColor = true;
            this.timerButton.Click += new System.EventHandler(this.timerButton_Click);
            // 
            // timerLabel
            // 
            resources.ApplyResources(this.timerLabel, "timerLabel");
            this.timerLabel.Name = "timerLabel";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // resetTimer
            // 
            resources.ApplyResources(this.resetTimer, "resetTimer");
            this.resetTimer.Name = "resetTimer";
            this.resetTimer.UseVisualStyleBackColor = true;
            this.resetTimer.Click += new System.EventHandler(this.resetTimer_Click);
            // 
            // SudokuApp
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.Controls.Add(this.timerLabel);
            this.Controls.Add(this.settingsBox);
            this.Controls.Add(this.sudokuGrid);
            this.Controls.Add(this.resetTimer);
            this.Controls.Add(this.timerButton);
            this.Controls.Add(this.menuTopBar);
            this.ForeColor = System.Drawing.Color.Black;
            this.MainMenuStrip = this.menuTopBar;
            this.Name = "SudokuApp";
            this.menuTopBar.ResumeLayout(false);
            this.menuTopBar.PerformLayout();
            this.settingsBox.ResumeLayout(false);
            this.settingsBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MenuStrip menuTopBar;
        private ToolStripMenuItem fileMenu;
        private ToolStripMenuItem helpMenu;
        private ToolStripMenuItem fileSaveMenu;
        private ToolStripMenuItem fileLoadMenu;
        private ToolStripMenuItem fileExitMenu;
        private ToolStripMenuItem helpRulesMenu;
        private TableLayoutPanel sudokuGrid;
        private CheckBox threadingBox;
        private GroupBox settingsBox;
        private TextBox maxThreadsToUseInput;
        private Label label1;
        private Label responseTitle;
        private RichTextBox responseMessageBox;
        private Label actionsTitle;
        private Button clearBoardButton;
        private Label label2;
        private Button checkCollisions;
        private Button generatePuzzle;
        private ToolStripMenuItem generationToolStripMenuItem;
        private ToolStripMenuItem difficultyToolStripMenuItem;
        private ToolStripMenuItem likeAGardenDifficultyMenuItem;
        private ToolStripMenuItem toasterDifficultyMenuItem;
        private ToolStripMenuItem hellDifficultyMenuItem;
        private ToolStripMenuItem ootwDifficultyMenuItem;
        private ToolStripMenuItem actionsToolStripMenuItem;
        private ToolStripMenuItem clearBoardMenuItem;
        private ToolStripMenuItem checkCollisionsMenuItem;
        private ToolStripMenuItem generatePuzzleMenuItem;
        private ToolStripMenuItem solvePuzzleMenuItem;
        private ToolStripMenuItem settingsMenuItem;
        private ToolStripMenuItem showCollisionsMenuItem;
        private ToolStripMenuItem collisionsOn;
        private ToolStripMenuItem collisionsOff;
        private ToolStripMenuItem useMultiThreadingMenuItem;
        private ToolStripMenuItem threadingOn;
        private ToolStripMenuItem threadingOff;
        private Button timerButton;
        private Label timerLabel;
        private System.Windows.Forms.Timer timer1;
        private Button resetTimer;
        private ToolStripMenuItem timerToolStripMenuItem;
        private ToolStripMenuItem startTimerMenuItem;
        private ToolStripMenuItem stopTimerMenuItem;
        private ToolStripMenuItem resetTimerMenuItem;
        private ToolStripMenuItem showTimerToolStripMenuItem;
        private ToolStripMenuItem onToolStripMenuItem;
        private ToolStripMenuItem showTimerOffMenuItem;
        private ToolStripMenuItem showTimerOnMenuItem;
        private Button solveButton;
        private ToolStripMenuItem gitHubToolStripMenuItem;
        private ToolStripMenuItem otherGamesGeneratorsToolStripMenuItem;
        private ToolStripMenuItem battleshipToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem snowflakeIDGeneratorToolStripMenuItem;
        private ToolStripMenuItem pathCollisionToolStripMenuItem;
        private ToolStripMenuItem dDungeonBuilderToolStripMenuItem;
        private ToolStripMenuItem sevenBridgesOfKonigsbergToolStripMenuItem;
        private ToolStripMenuItem selectLanguageToolStripMenuItem;
        private ToolStripMenuItem englishLanguageMenuItem;
        private ToolStripMenuItem germanLanguageMenuItem;
        private ToolStripMenuItem japaneseLanguageMenuItem;
    }
}