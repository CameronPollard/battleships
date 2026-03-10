using System.Diagnostics;

namespace Battle_Ships
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Random rdm = new Random();
        string[,] arrPlayer = new string[10, 10];
        string[,] arrEnemy = new string[10, 10];

        string[] ShipNames = new string[5] { "Carrier", "Battleship", "Cruiser", "Sub", "Destroyer" };
        string[] PlacedShips = new string[5] { "", "", "", "", "" };
        string[] EPlacedShips = new string[5] { "", "", "", "", "" };
        int[] ShipLengths = new int[5] { 5, 4, 3, 3, 2 };
        int[] ShipHp = new int[5] { 5, 4, 3, 3, 2 };
        int[] EShipHp = new int[5] { 5, 4, 3, 3, 2 };
        bool[] AttemptedDirections = new bool[4] { false, false, false, false };

        int placedships = 0, ShipNum, rowcoord = 0, colcoord = 0, centralrow, centralcol, LockRow, LockCol;
        string name = "";
        bool ingame = false, changedirection = false;
        string ShipDirection = "Unknown";
        bool shootagain = false, Lockedon = false;

        public String HitorMiss()
        {
            // If the CPU is 'Locked on' and misses, it will shoot in a different direction from the initial hit coordinates (Smart AI)
            if (Lockedon == true & arrPlayer[LockRow, LockCol] == "") GenerateDirection(); // This will be picking the last possible direction
            if (arrPlayer[LockRow, LockCol] == "") // If the CPU misses, the players tiles turns blue
            {
                dgvPlayer.Rows[LockRow].Cells[LockCol].Style.BackColor = Color.Blue;
                arrPlayer[LockRow, LockCol] = "miss"; // Memory in array changed so the CPU knows it has shot here for future reference
            }
            if (arrPlayer[LockRow, LockCol] != "" & arrPlayer[LockRow, LockCol] != "miss" & arrPlayer[LockRow, LockCol] != "hit") // If the CPU has hit a player ship (Easy or Smart AI)
            {
                dgvPlayer.Rows[LockRow].Cells[LockCol].Style.BackColor = Color.Red; // To display the CPU has gotten a hit

                name = arrPlayer[LockRow, LockCol];
                for (int i = 0; i < 5; i++)
                {
                    if (ShipNames[i] != name) continue;
                    ShipNum = i;
                }
                ShipHp[ShipNum] -= 1;
                if (ShipHp[ShipNum] == 0)
                {
                    Lockedon = false;
                    Array.Clear(AttemptedDirections);
                    for (int i = 0; i < 4; i++) AttemptedDirections[i] = false;
                }
                arrPlayer[LockRow, LockCol] = "hit"; // CPU knows it has hit here; preventing it from doing so again later
                // If the CPU has destroyed a ship, its information on the ex-ship is reset
                if (Lockedon == false) ShipDirection = "Unknown";
                // Checking if game ended
                for (int i = 0; i < 5; i++)
                {
                    if (i == 4 & ShipHp[i] == 0)
                    {// Lost game

                        dgvPlayer.Refresh();
                        dgvEnemy.Refresh();
                        Array.Clear(arrPlayer, 0, 0);
                        CycleCells("HighlightEnemy");
                        for (int row = 0; row < 10; row++)
                        {
                            for (int col = 0; col < 10; col++)
                            {
                                if (arrEnemy[row, col] != "miss" & arrEnemy[row, col] != "") // ship was/is there
                                {
                                    dgvEnemy.Rows[row].Cells[col].Style.BackColor = Color.Brown;
                                }
                            }
                        }
                        Array.Clear(arrEnemy, 0, 0);

                        label3.Visible = true;
                        btnRestart.Enabled = true;
                        btnRestart.Visible = true;
                        rtbShipsLeft.Visible = false;
                        btnStart.Visible = true;
                        label3.ForeColor = Color.Red;
                        label3.Text = "YOU LOSE";  // States that the player lost
                        ingame = false;  // Prevents continued shooting
                    }
                }
                return "hit";
            }
            return "miss";
        }

        private int GenerateDirection()
        {
            int direction = 0;
            // Possibly between unknown, vertical and horizontal. Seems unnecessary because of below chunk
            //if (ShipDirection == "Unknown") direction = rdm.Next(0, 4);
            //if (ShipDirection == "Unknown") direction = rdm.Next(0, 4);
            //if (ShipDirection == "Unknown") direction = rdm.Next(0, 4);

            bool Error = false;
            while (AttemptedDirections[direction] == true || Error == true)
            {
                Error = false;
                direction = rdm.Next(0, 4);
                if (direction == 0 & colcoord - 1 <= 0) Error = true;
                if (direction == 1 & rowcoord - 1 <= 0) Error = true;
                if (direction == 2 & colcoord + 1 >= 10) Error = true;
                if (direction == 3 & rowcoord + 1 >= 10) Error = true;
            }
            return direction;
        }

        private Array MovementChange(int direc)
        {
            int RowChange = 0, ColChange = 0;

            if (direc == 0 & colcoord - 1 > 0) ColChange = -1; // If direc == 0, it will shoot left
            if (direc == 1 & rowcoord - 1 > 0) RowChange = -1; // If direc == 1, it will shoot up
            if (direc == 2 & colcoord + 1 < 10) ColChange = 1; // If direc == 2, it will shoot right
            if (direc == 3 & rowcoord + 1 < 10) RowChange = 1; // If direc == 3, it will shoot down

            int[] Changes = new int[2] { RowChange, ColChange };
            return Changes;
        }
        private void CPU_Fire()
        {
            int direction = 0;

            if (Lockedon == false) // If the CPU is has not locked onto a ship, it will shoot randomly
            {
                RandomCoords();
                while (arrPlayer[rowcoord, colcoord] == "miss" | arrPlayer[rowcoord, colcoord] == "hit") // reselects location if hit previously
                {
                    RandomCoords();
                }
                // Since this can't be a previous miss or hit, if its not empty, there must be a ship
                if (arrPlayer[rowcoord, colcoord] != "")
                {
                    if (Lockedon == false) // If Lockedon is false, the CPU has discovered a new ship. All other parts of the ship are connected to this spot, and so is recorded in centralrow/col
                    {
                        centralrow = rowcoord;
                        centralcol = colcoord;
                        Lockedon = true;
                    }
                }
                HitorMiss();
            }
            else if (Lockedon == true)
            {
                if (ShipDirection == "Unknown") // Determine what direction ship is facing (2/ 3rd? shot)
                {
                    direction = GenerateDirection();
                    int[] Changes = (int[])MovementChange(direction);
                    LockRow += Changes[0];
                    LockCol += Changes[1];
                    string result = HitorMiss();
                    if (result == "hit")
                    {
                        if (direction % 2 == 0)
                        {
                            ShipDirection = "Vertical";
                            AttemptedDirections[1] = true;
                            AttemptedDirections[3] = true;
                        }
                        if (direction % 2 == 1)
                        {
                            ShipDirection = "Horizontal";
                            AttemptedDirections[0] = true;
                            AttemptedDirections[2] = true;
                        }
                    }
                    else if (result == "miss") AttemptedDirections[direction] = true;
                }

                else if (ShipDirection != "Unknown") // if the ship is determined to be horizontal or vertical
                {
                    // Last move failed, so change direction (As the ship being horizontal/vertical has been identified and 1 direction failed, 1 direction remains)
                    if (AttemptedDirections[direction] == true) direction = GenerateDirection();
                    {
                        LockCol = centralcol;
                        LockRow = centralrow;
                        if (direction % 2 == 0 & ShipDirection == "vertical" | direction % 2 == 1 & ShipDirection == "horizontal") // If the ship was originally shooting horizontal and the ship is vertical it will change to shooting vertically
                        {
                            direction = rdm.Next(0, 4);
                            while (direction % 2 == 0)
                            {
                                direction = rdm.Next(0, 4);
                            }
                        }
                        changedirection = false; // Stops the CPU from changing direction again unless it needs to                   
                    }
                    int[] Changes = (int[])MovementChange(direction);
                    LockRow += Changes[0];
                    LockCol += Changes[1];
                }
                if (changedirection == false) HitorMiss();
                // At this point, for example if the ship is vertical,
                // then direction 0 or 2 are possible. One of these is used already, so there is 1 possible direction left
                if (changedirection == true)
                {
                    GenerateDirection();
                    HitorMiss();
                }
            }
        }
        private void dgvEnemy_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int cells = 0;
            if (ingame == false) return;
            for (int row = 0; row < 10; row++)
            {
                for (int col = 0; col < 10; col++)
                {
                    if (dgvEnemy.Rows[row].Cells[col].Selected == false) continue;
                    if (arrEnemy[row, col] == "miss" || arrEnemy[row, col] == "hit") continue;
                    cells++; // cells is increased
                    colcoord = col; // coordinates of chosen tile is recorded
                    rowcoord = row;
                }
            }
            dgvEnemy.ClearSelection();
            if (cells != 1) return;// If only one tile has been selected, the game will accept the shot
            if (arrEnemy[rowcoord, colcoord] == "") // if the player misses
            {
                dgvEnemy.Rows[rowcoord].Cells[colcoord].Style.BackColor = Color.Blue;
                arrEnemy[rowcoord, colcoord] = "miss"; // records a miss to prevent reshooting
            }
            else // if the player hits
            {
                dgvEnemy.Rows[rowcoord].Cells[colcoord].Style.BackColor = Color.Red;
                name = arrEnemy[rowcoord, colcoord];
                for (int i = 0; i < 5; i++)
                {
                    if (name == ShipNames[i]) ShipNum = i;
                }
                EShipHp[ShipNum] -= 1;
                if (EShipHp[ShipNum] == 0) MessageBox.Show($"{name} destroyed");
                arrEnemy[rowcoord, colcoord] = "hit"; // Records the location was a hit
                rtbShipsLeft.Text = "Ships remaining:";
                for (int i = 0; i < 5; i++)
                {
                    if (EShipHp[i] > 0) rtbShipsLeft.AppendText($"\n{ShipNames[i]}");
                }
                for (int i = 0; i > 5; i++)
                {
                    if (EShipHp[i] > 0) break;
                    if (i == 4 & EShipHp[i] == 0) // All ships destroyed
                    {
                        dgvPlayer.Refresh();
                        dgvEnemy.Refresh();
                        Array.Clear(arrPlayer, 0, 0);
                        Array.Clear(arrEnemy, 0, 0);

                        label3.Visible = true;
                        btnRestart.Enabled = true;
                        btnRestart.Visible = true;
                        rtbShipsLeft.Visible = false;
                        btnStart.Visible = true;
                        lblStart.Visible = true;
                        label3.ForeColor = Color.LimeGreen;
                        label3.Text = "YOU WIN"; // States that the player won
                        ingame = false; // Prevents continued firing
                    }
                }
            }
            if (ingame == true & cells == 1) CPU_Fire();
        }

        void UndoThingies()
        {
            dgvPlayer.Refresh();
            dgvEnemy.Refresh();
            Array.Clear(arrPlayer, 0, 0);
            Array.Clear(arrEnemy, 0, 0);

            btnRestart.Enabled = true;
            btnRestart.Visible = true;
            rtbShipsLeft.Visible = false;
            btnStart.Visible = true;
            lblStart.Visible = true;
            lblStart.Enabled = false;
        }
        private void btnSmartAI_Click(object sender, EventArgs e) { UndoThingies(); }

        private void btnEasy_Click(object sender, EventArgs e) { UndoThingies(); }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgvPlayer.RowCount = 10; // To load the player and CPU DGVs
            dgvEnemy.RowCount = 10;
            dgvPlayer.ClearSelection();
            dgvEnemy.ClearSelection();
            for (int i = 1; i < 11; i++)
            {
                dgvPlayer.Rows[i - 1].HeaderCell.Value = i.ToString();
                dgvEnemy.Rows[i - 1].HeaderCell.Value = i.ToString();
            }
            btnSmartAI.BackColor = Color.LightBlue; // To display that the Smart AI mode (Normal) is currently selected
        }

        private Array ShipHeadGenerate(int direction, int length)
        {
            int rowcoord = -1, colcoord = -1;

            // final trial
            do
            {
                if (direction == 0)
                {
                    rowcoord = rdm.Next(0, 10);
                    colcoord = rdm.Next(0, 10 - length);
                }
                else if (direction == 1)
                {
                    rowcoord = rdm.Next(0, 10 - length);
                    colcoord = rdm.Next(0, 10);
                }
            }
            while (arrEnemy[rowcoord, colcoord] != "");

            //if (direction == 0)
            //{
                //original
                //do
                //{
                //    rowcoord = rdm.Next(0, 10);
                //    colcoord = rdm.Next(0, length + 1); // The amount that colcoord can be is reduced to prevent an out of array error. Builds right.
                //}
                //while (colcoord - 1 + ShipLengths[i] > 9 || arrEnemy[rowcoord, colcoord] != ""); // keeps running if the ship is out of the array or will place themself over another ship

                // trial
                //do
                //{
                //    rowcoord = rdm.Next(0, 10);
                //    colcoord = rdm.Next(0, 10 - length);
                //}
                //while (arrEnemy[rowcoord, colcoord] != "");

            //}
            //if (direction == 1)
            //{
                // original
                //do
                //{
                //    colcoord = rdm.Next(0, 10);
                //    rowcoord = rdm.Next(9 - length, 10); // The amount that rowcoord can be is reduced to prevent an out of array error. Builds down.
                //}
                //while (rowcoord + 1 - ShipLengths[i] < 0 || arrEnemy[rowcoord, colcoord] != "");

                // trial
                //do
                //{
                //    colcoord = rdm.Next(0, 10);
                //    rowcoord = rdm.Next(0, 10 - length);
                //}
                //while (arrEnemy[rowcoord, colcoord] != "");
            //}

            int[] Coordinates = new int[2] { rowcoord, colcoord };
            return Coordinates;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            bool conflictingtiles = false;
            btnStart.Enabled = false;
            btnStart.Visible = false;
            lblStart.Visible = false;
            lblStart.Enabled = false;
            btnSurrender.Visible = true;
            btnSurrender.Enabled = true;
            lblSurrender.Enabled = true;
            lblSurrender.Visible = true;
            btnPlace.Visible = false;
            btnPlace.Enabled = false;
            btnReset.Visible = false;
            btnReset.Enabled = false;
            rtbShipsLeft.Text = "Ships remaining:\nCarrier\nBattleship\nCruiser\nSubmarine\nDestroyer";
            ingame = true; // When the player has finished ship placement and is prepared to start, the CPU will then place their ships
            for (int i = 0; i < 5; i++)
            {
                while (EPlacedShips[i] == "")
                {
                    string[,] tempArrEnemy = new string[10, 10];

                    int direction = rdm.Next(0, 2);
                    int[] Coords = (int[])ShipHeadGenerate(direction, ShipLengths[i]);
                    int rowcoord = Coords[0], colcoord = Coords[1];

                    name = ShipNames[i];
                    tempArrEnemy[rowcoord, colcoord] = name; // places first side into a temporary array in case the ship needs to be placed again
                    for (int j = 0; j < ShipLengths[j] - 1; j++)
                    {
                        if (direction == 0) colcoord++; // If the ship is to go horizontal, the inside of the ship will go horizontal
                        if (direction == 1) rowcoord++; // If the ship is to go vertical, the inside of the ship will go vertical
                        try
                        {
                            if (arrEnemy[rowcoord, colcoord] != "") conflictingtiles = true;// If a part of the ship goes over an existing ship
                            else tempArrEnemy[rowcoord, colcoord] = name; // The part of the ship is placed into the temporary array
                        }
                        catch { conflictingtiles = true; } // This runs if the ship will go out of array, therefore must deny placement
                    }
                    if (conflictingtiles == true) continue; // If ship has gone over or off grid at any point.
                    for (int row = 0; row < 10; row++)
                    {
                        for (int col = 0; col < 10; col++)
                        {
                            // use object instead?
                            if (tempArrEnemy[row, col] == name) // To prevent every piece of memory in the temporary array from being added to the CPU array, and destroying other ships.
                            {
                                arrEnemy[row, col] = name; // Adds carrier to CPU array
                                PlacedShips[i] = "placed";
                            }
                        }
                    }
                }
            }
        }
        private void btnPlace_Click(object sender, EventArgs e)
        {
            // Name grab (Ships must be placed in order)
            int cells = 0;
            string name = "";
            for (int i = 0; i < 5; i++)
            {
                if (PlacedShips[i] != "") continue;
                ShipNum = i;
                name = ShipNames[i];
            }
            if (name == "") return; // all ships placed
            cells = CycleCells("AddHighlightedCells"); // Adds all the highlight cells and checks these if it runs over an existing ship (return -1 if so)
            if (cells != ShipLengths[ShipNum] || name == "") return;
            // If the ship didn't run over an existing ship, the ship will place
            placedships++; // amount of placed ships increases
            PlacedShips[ShipNum] = "placed";
            CycleCells("PlayerPlace");
            rtbShipsLeft.Clear();
            rtbShipsLeft.AppendText("Ships left: "); // To display which ships the player still needs to place
            for (int i = 0; i < 5; i++)
            {
                if (PlacedShips[i] == "") rtbShipsLeft.AppendText($"\n{ShipNames[i]}");
            }
            dgvPlayer.ClearSelection();
            if (name == "Destroyer") // Last ship
            {
                btnStart.Enabled = true;
                lblStart.Enabled = true;
            }
        }

        private void btnRestart_Click(object sender, EventArgs e) { Application.Restart(); }

        private void btnTutorial_Click(object sender, EventArgs e)
        {
            MessageBox.Show("     HOW TO PLACE     ");
            MessageBox.Show("Start by highlighting tiles on your grid, then\npress the PLACE SHIP button to place the ship");
            MessageBox.Show("They are to be placed in order of ship length (5, 4, 3, 3, 2)");
            MessageBox.Show("Ships can't be placed on each other or off the grid\nThe computer will also place their ships");
            MessageBox.Show("After placing all your ships, press the start game button");
        }

        private void btnTutorial2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("     HOW TO SHOOT     ");
            MessageBox.Show("Click on the tile on the enemy grid where you want to shoot");
            MessageBox.Show("Try to find and hit the enemy ships. The tile will\nturn red if you hit a ship and blue if you missed");
            MessageBox.Show("The computer will then try to hit your ships\nFirst side to destroy the enemies ships wins!");
        }

        private void btnSurrender_Click(object sender, EventArgs e)
        {
            CycleCells("Surrender");
            label3.Visible = true;
            btnRestart.Enabled = true;
            btnRestart.Visible = true;
            rtbShipsLeft.Visible = false;
            btnStart.Visible = true;
            lblStart.Visible = true;
            lblStart.Enabled = true;
            lblStart.Visible = true;
            label3.ForeColor = Color.Red;
            label3.Text = "YOU LOSE";
            ingame = false; // Prevents continued shooting
        }

        private void thisExit_Click(object sender, EventArgs e) { Application.Exit(); }

        private void RandomCoords()
        {
            rowcoord = rdm.Next(0, 10);
            colcoord = rdm.Next(0, 10);
        }

        private int CycleCells(string Process)
        {
            int cells = 0;
            for (int row = 0; row < 10; row++)
            {
                for (int col = 0; col < 10; col++)
                {
                    if (Process == "Surrender")
                    {
                        arrPlayer[row, col] = ""; // The player array and DGV is reset
                        dgvPlayer.Rows[row].Cells[col].Style.BackColor = Color.White;
                        if (arrEnemy[row, col] != "" & arrEnemy[row, col] != "miss") // To display all the enemy ship locations
                        {
                            dgvEnemy.Rows[row].Cells[col].Style.BackColor = Color.Brown;
                            arrEnemy[row, col] = "";
                        }
                    }
                    if (Process == "ResetGame")
                    {
                        dgvEnemy.Rows[row].Cells[col].Style.BackColor = Color.White; // All arrays and DGVs reset
                        arrEnemy[row, col] = "";
                        dgvPlayer.Rows[row].Cells[col].Style.BackColor = Color.White;
                        arrPlayer[row, col] = "";
                    }
                    if (Process == "PlayerPlace")
                    {
                        if (dgvPlayer.Rows[row].Cells[col].Selected == true) // If the tile was chosen to hold a ship
                        {
                            arrPlayer[row, col] = name;
                            dgvPlayer.Rows[row].Cells[col].Style.BackColor = Color.Green;
                        }
                    }
                    if (Process == "AddHighlightedCells")
                    {
                        if (dgvPlayer.Rows[row].Cells[col].Selected == true)
                        {
                            cells++;
                            if (arrPlayer[row, col] != "") return -1;
                        }
                    }
                    if (Process == "HighlightEnemy")
                    {
                        // Ship was / is there
                        if (arrEnemy[row, col] != "miss" & arrEnemy[row, col] != "") dgvEnemy.Rows[row].Cells[col].Style.BackColor = Color.Brown;
                    }
                }
            }
            return -1;
        }
    }
}