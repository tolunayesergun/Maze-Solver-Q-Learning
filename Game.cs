﻿using MazeSolverQLearning.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MazeSolverQLearning
{
    public partial class Game : Form
    {
        #region Entities

        private readonly Random rnd = new Random(); // Random sayı üretmemiz için gerekli instance
        public static double learningRate = 0.9;
        public static int areaXSize = 26;   // Oyunda ki bir satırda ki kare sayısı
        public static int areaYSize = 26;   // Oyunda ki bir stunda ki kare sayısı
        public static int startPos = -1;
        public static int targetPos = -1;
        public static int minerPos = -1;
        public static int iterationCount = 0;
        public static bool canChange = true;

        public static Bitmap dirt = new Bitmap(Properties.Resources.Dirt);
        public static Bitmap miner = new Bitmap(Properties.Resources.GreenMinerDirt);
        public static Bitmap targetImage = new Bitmap(Properties.Resources.RedGoldDirt);
        public static Bitmap redDirt = new Bitmap(Properties.Resources.RedDirt);
        public static Bitmap greenDirt = new Bitmap(Properties.Resources.GreenDirt);
        public static Bitmap darkerRedDirt = new Bitmap(Properties.Resources.DarkerRedDirt);

        public static List<float> SuccessScore = new List<float>();
        public static List<float> StepCount = new List<float>();
        public static float lastRoamListCount = -1;
        public static float lastTotalScore = -1;

        public static int repeatCount = 0;
        public static double fnishScore = 100;
        public static double blockScore = -100;
        public static double roamScore = -0.01;
        public static double outScore = -100;
        public static double[,] qTable = new double[(areaXSize * areaYSize), 8];
        private int[] blockSpawns;

        public static List<int> roamList = new List<int>();

        #endregion Entities

        #region CreateGame

        public Game()
        {
            InitializeComponent();
        }

        private void Game_Load(object sender, EventArgs e)
        {
            CreateGame();
        }

        private void CreateGame()
        {
            pnlBoard.Controls.Clear();

            int areaTotalSize = areaXSize * areaYSize;   // Oyun alanında ki toplam kare sayısı
            int cellWidth = Convert.ToInt32(Math.Floor(Convert.ToDouble(pnlBoard.Width) / areaXSize));  // Alandaki Bir karenin genişliği
            int cellHeight = Convert.ToInt32(Math.Floor(Convert.ToDouble(pnlBoard.Height) / areaYSize)); // Alandaki Bir karenin uzunluğu

            GenerateMap(areaTotalSize, cellWidth, cellHeight);
            GenerateBlocks(areaTotalSize);
        }    // Oyunu oluşturan fonksiyon

        private void GenerateMap(int areaTotalSize, int cellWidth, int cellHeight)
        {
            int ButtonCount = 0;
            int x = 0, y = 0;
            for (int i = 0; i < areaTotalSize; i++)
            {
                Button btn = new Button
                {
                    Font = new System.Drawing.Font("Microsoft Sans Serif", (float)cellHeight / 5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162))),
                    Size = new System.Drawing.Size(cellWidth, cellHeight),
                    TextAlign = System.Drawing.ContentAlignment.BottomLeft,
                    BackColor = Color.White,
                    Text = (i).ToString(),
                    Name = "btn" + (i),
                    BackgroundImageLayout = ImageLayout.Stretch,
                    BackgroundImage = dirt,
                    //Enabled = false,
                    FlatStyle = System.Windows.Forms.FlatStyle.Popup
                };
                btn.Click += new EventHandler(Area_Click);

                if (ButtonCount < areaXSize)
                {
                    btn.Location = new Point(x, y);
                    pnlBoard.Controls.Add(btn);
                    x += cellWidth;
                    ButtonCount++;
                }
                else
                {
                    ButtonCount = 1;
                    x = 0;
                    y += cellHeight;
                    btn.Location = new Point(x, y);
                    pnlBoard.Controls.Add(btn);
                    x += cellWidth;
                }
            }
        }  // Oyun arenasını oluşturan fonksiyon

        private void GenerateBlocks(int areaTotalSize)
        {
            int blockIterator = 0;
            int wallSize = (areaXSize * 4) - 4;
            int totalBlocksCount = ((areaTotalSize * 30) / 100) + wallSize; // Alandaki Toplam Altın Sayısı
            blockSpawns = new int[totalBlocksCount + wallSize]; // Alandaki altınların yeri (Buton numarası olarak)

            for (int i = 0; i < areaXSize + 1; i++)
            {
                blockSpawns[blockIterator] = i;
                blockIterator++;
                var selectedButton = getButton(i);
                selectedButton.BackgroundImage = darkerRedDirt;
                selectedButton.Enabled = false;

                if (i != 0)
                {
                    blockSpawns[blockIterator] = i * areaXSize - 1;
                    blockIterator++;
                    var selectedButton2 = getButton(i * areaXSize - 1);
                    selectedButton2.BackgroundImage = darkerRedDirt;
                    selectedButton2.Enabled = false;
                }

                if (i != 0 && i != areaXSize)
                {
                    blockSpawns[blockIterator] = i * areaXSize;
                    blockIterator++;
                    var selectedButton2 = getButton(i * areaXSize);
                    selectedButton2.BackgroundImage = darkerRedDirt;
                    selectedButton2.Enabled = false;
                }

                if (i != 0 && i != areaXSize)
                {
                    blockSpawns[blockIterator] = i + (areaXSize * (areaXSize - 1));
                    blockIterator++;
                    var selectedButton2 = getButton(i + (areaXSize * (areaXSize - 1)));
                    selectedButton2.BackgroundImage = darkerRedDirt;
                    selectedButton2.Enabled = false;
                }
            }
            while (blockIterator < totalBlocksCount)
            {
                int nextNumber = rnd.Next(areaTotalSize);

                if (!(blockSpawns.Contains(nextNumber)))
                {
                    blockSpawns[blockIterator] = nextNumber;
                    blockIterator++;
                    var selectedButton = getButton(nextNumber);
                    selectedButton.BackgroundImage = redDirt;
                    selectedButton.Enabled = false;
                }
            }
        }

        private void Area_Click(object sender, EventArgs e)
        {
            if (canChange)
            {
                Button selectedArea = sender as Button;
                int selectedButton = Convert.ToInt32(selectedArea.Text);

                if (selectedButton == startPos)
                {
                    selectedArea.BackgroundImage = dirt;
                    startPos = -1;
                }
                else if (selectedButton == targetPos)
                {
                    selectedArea.BackgroundImage = dirt;
                    targetPos = -1;
                }
                else
                {
                    if (startPos == -1)
                    {
                        selectedArea.BackgroundImage = miner;
                        startPos = selectedButton;
                        minerPos = selectedButton;
                    }
                    else if (targetPos == -1)
                    {
                        selectedArea.BackgroundImage = targetImage;
                        targetPos = selectedButton;
                    }
                }
            }
        }

        #endregion CreateGame

        #region DrawFunctions

        private void DrawRoads()
        {
            if (roamList.Count > 0)
            {
                for (int i = 0; i < roamList.Count; i++)
                {
                    var selectedButton = getButton(roamList[i]);
                    selectedButton.BackgroundImage = greenDirt;
                }
                getButton(targetPos).BackgroundImage = targetImage;
            }
        }

        private void RemoveRoads()
        {
            if (roamList.Count > 0)
            {
                for (int i = 0; i < roamList.Count; i++)
                {
                    var selectedButton = getButton(roamList[i]);
                    if (selectedButton.Enabled == false) selectedButton.BackgroundImage = redDirt;
                    else selectedButton.BackgroundImage = dirt;
                }
                getButton(startPos).BackgroundImage = miner;
                getButton(targetPos).BackgroundImage = targetImage;
            }
            roamList.Clear();
        }

        #endregion DrawFunctions

        #region GlobalFunctions

        private Cordinant FindCordinant(int buttonNumber)
        {
            Cordinant map = new Cordinant
            {
                row = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(buttonNumber) / Convert.ToDouble(areaXSize)))
            };
            int rowLimit = map.row * areaXSize;
            map.column = areaXSize - (rowLimit - buttonNumber);
            return map;
        }  // Numarası verilen butonun satır ve stun bilgisini veriyor.

        public int getRandomValue(int max)
        {
            int nextValue;
            nextValue = rnd.Next(0, max);
            return nextValue;
        }  //Rastegele değer üreten fonksiyon (5-20) arası

        public void WriteText()
        {
            if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "/Results")) Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "/Results");
            string filePath = AppDomain.CurrentDomain.BaseDirectory + "/Results/" + "Game.txt";
            FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write);

            StreamWriter streamWriter = new StreamWriter(fileStream);

            streamWriter.WriteLine("*************************************************************************************************************************************************************************************");
            streamWriter.WriteLine();
            streamWriter.WriteLine(" Harita Ölçüleri = " + areaXSize.ToString() + " x " + areaYSize.ToString());
            streamWriter.WriteLine(" Baslangic karesi = " + startPos.ToString());
            streamWriter.WriteLine(" Hedef kare = " + targetPos.ToString());
            streamWriter.WriteLine(" Tablodaki D -> Duvar olduğunu göstermektedir.");
            streamWriter.WriteLine();
            streamWriter.WriteLine("*************************************************************************************************************************************************************************************");
            streamWriter.WriteLine();
            for (int i = 0; i < areaXSize * areaYSize; i++)
            {
                if (i % (areaXSize) == 0 && i != 0) streamWriter.WriteLine();
                if (blockSpawns.Contains(i)) streamWriter.Write("[ D-" + (i.ToString("0000")) + " ] ");
                else streamWriter.Write("[ " + (i.ToString("000000")) + " ] ");
            }
            streamWriter.WriteLine();
            streamWriter.WriteLine();
            streamWriter.WriteLine("*************************************************************************************************************************************************************************************");
            streamWriter.WriteLine();
            streamWriter.WriteLine(" Bulunan En Kısa Yol = " + string.Join("->", roamList));
            streamWriter.WriteLine();
            streamWriter.WriteLine("*************************************************************************************************************************************************************************************");

            streamWriter.Flush();

            streamWriter.Close();
            fileStream.Close();
        }   // Logları text dosyasına basan fonksiyon

        public Button getButton(int btnName)
        {
            return (pnlBoard.Controls["btn" + btnName.ToString()] as Button);
        }

        #endregion GlobalFunctions

        #region GameMechanics

        private void moveTimer_Tick(object sender, EventArgs e)
        {
            iterationCount++;
            button2.Text = "İterasyon Sayısı = " + iterationCount.ToString();
            GameMechanics();
        }

        private void GameMechanics()
        {
            RemoveRoads();
            double totalScore = 0;
            while (roamList.Count() < (areaXSize * areaYSize))
            {
                var area = getBiggestArea(minerPos);

                if (getButton(area.nextArea).Enabled == false)
                {
                    qTable[area.pastArea, area.pastAreaRotate] = blockScore + (learningRate * getBiggestArea(area.nextArea).pastAreaQScore);
                    break;
                }
                else if (area.nextArea == targetPos)
                {
                    var score = fnishScore + (learningRate * getBiggestArea(area.nextArea).pastAreaQScore);
                    qTable[area.pastArea, area.pastAreaRotate] = score;
                    totalScore += score;
                    roamList.Add(area.nextArea);
                    targetImage = new Bitmap(Properties.Resources.SuccessGreenDirt);
                    totalScore = Convert.ToDouble(decimal.Round(Convert.ToDecimal(totalScore), 2));

                    if (lastRoamListCount == roamList.Count() && lastTotalScore == Convert.ToSingle(totalScore)) repeatCount++;
                    else repeatCount = 0;
                    if (repeatCount < 5)
                    {
                        StepCount.Add(roamList.Count());
                        SuccessScore.Add(Convert.ToSingle(totalScore));
                        lastTotalScore = Convert.ToSingle(totalScore);
                        lastRoamListCount = roamList.Count();
                    }
                    else FnishSolve();

                    break;
                }
                else
                {
                    var score = roamScore + (learningRate * getBiggestArea(area.nextArea).pastAreaQScore);
                    qTable[area.pastArea, area.pastAreaRotate] = score;
                    roamList.Add(area.nextArea);
                    minerPos = area.nextArea;
                    totalScore += score;
                }
            }
            minerPos = startPos;
            DrawRoads();
        }

        public int findAreaSpot(int area, int rotate)
        {
            switch (rotate)
            {
                case 0:
                    return area - areaXSize - 1;

                case 1:

                    return area - areaXSize;

                case 2:

                    return area - areaXSize + 1;

                case 3:

                    return area - 1;

                case 4:

                    return area + 1;

                case 5:

                    return area + areaXSize - 1;

                case 6:

                    return area + areaXSize;

                case 7:

                    return area + areaXSize + 1;

                default:
                    return -100;
            }
        }

        public Area getBiggestArea(int currentPos)
        {
            var AreaValues = new List<AreaValues>();
            AreaValues.Add(new AreaValues() { maxIndex = 0, maxValue = -10000 });

            for (int i = 0; i < 8; i++)
            {
                if (qTable[currentPos, i] == AreaValues[0].maxValue)
                {
                    AreaValues.Add(new AreaValues() { maxIndex = i, maxValue = qTable[currentPos, i] });
                }
                else if (qTable[currentPos, i] > AreaValues[0].maxValue)
                {
                    AreaValues.Clear();
                    AreaValues.Add(new AreaValues() { maxIndex = i, maxValue = qTable[currentPos, i] });
                }
            }
            var rndValue = 0;
            if (AreaValues.Count > 0)
            {
                rndValue = getRandomValue(AreaValues.Count);
            }

            return new Area() { pastAreaQScore = AreaValues[rndValue].maxValue, nextArea = findAreaSpot(currentPos, AreaValues[rndValue].maxIndex), pastArea = currentPos, pastAreaRotate = AreaValues[rndValue].maxIndex };
        }

        private void startTimer(object sender, EventArgs e)
        {
            if (targetPos != -1 && startPos != -1)
            {
                canChange = false;
                moveTimer.Enabled = true;
            }
        }

        private void btnRestart(object sender, EventArgs e)
        {
            if (moveTimer.Enabled == true) moveTimer.Enabled = false;
            pnlBoard.Controls.Clear();
            areaXSize = (areaSizeTrack.Value + 11);
            areaYSize = (areaSizeTrack.Value + 11);
            qTable = new double[(areaXSize * areaYSize), 8];
            CreateGame();
            startPos = -1;
            targetPos = -1;
            minerPos = -1;
            canChange = true;
            targetImage = new Bitmap(Properties.Resources.RedGoldDirt);
            roamList = new List<int>();
            button2.Text = "Başlat";
            SuccessScore.Clear();
            StepCount.Clear();
        }

        private void btnRedraw(object sender, EventArgs e)
        {
            if (moveTimer.Enabled == true)
            {
                moveTimer.Enabled = false;
                RemoveRoads();
                getButton(startPos).BackgroundImage = dirt;
                getButton(targetPos).BackgroundImage = dirt;
                startPos = -1;
                targetPos = -1;
                minerPos = -1;
                canChange = true;
                targetImage = new Bitmap(Properties.Resources.RedGoldDirt);
                roamList = new List<int>();
                button2.Text = "Başlat";
                SuccessScore.Clear();
                StepCount.Clear();
            }
        }

        private void areaSizeTrack_Scroll(object sender, EventArgs e)
        {
            var size = (areaSizeTrack.Value + 10).ToString();
            lblAreaSize.Text = size + " x " + size;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FnishSolve();
        }

        private void FnishSolve()
        {
            if (moveTimer.Enabled == true) moveTimer.Enabled = false;
            DrawRoads();
            ChartForm chart = new ChartForm();
            chart.ShowDialog();

            WriteText();

            RemoveRoads();
            getButton(startPos).BackgroundImage = dirt;
            getButton(targetPos).BackgroundImage = dirt;
            startPos = -1;
            targetPos = -1;
            minerPos = -1;
            canChange = true;
            targetImage = new Bitmap(Properties.Resources.RedGoldDirt);
            roamList = new List<int>();
            button2.Text = "Başlat";
            SuccessScore.Clear();
            StepCount.Clear();
        }

        #endregion GameMechanics

    }
}