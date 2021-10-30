using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PickAndRestriction
{
    public partial class Form1 : Form 
    {
        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 100;//0.1秒//敵人落下速度
            timer2.Interval = 1000;//一秒//計時60秒
            timer3.Interval = 1000;//記冷卻時間
            shot1 = new Button();
            shot1.Visible = false;
            shot2 = new Button();
            shot2.Visible = false;
        }
        int property = 1;//水是1，火是2，木是3
        int sec = 60;//記總時間
        int grade = 0;
        Button myself = new Button();
        /* 因為高度是400，最慢的水是100/s，兩者相向場上最多會有兩個子彈 */
        Button shot1 = new Button();
        Button shot2 = new Button();
        Button row1Enemy = new Button();
        Button row2Enemy = new Button();
        Button row3Enemy = new Button();
        Button row4Enemy = new Button();
        /* Label on the right side */
        Label lblPro = new Label();
        Label lblGrade = new Label();
        Label lbltime = new Label();
        /* Inherit velocity from other class */
        Enemy row1 = new Enemy();
        Enemy row2 = new Enemy();
        Enemy row3 = new Enemy();
        Enemy row4 = new Enemy();
        shot myshot1 = new shot();
        shot myshot2 = new shot();
        Random rand = new Random();//用來跑隨機顏色
        bool run1 = false;//子彈1是否可以跑
        bool run2 = false;//子彈二是否可以跑
        int cool = 1;//記冷卻時間
        bool kill = true;//滿一秒才可以射子彈
        private void btnWater_CheckedChanged(object sender, EventArgs e)
        {
            property = 1;
        }
        private void btnFire_CheckedChanged(object sender, EventArgs e)
        {
            property = 2;
        }
        private void btnTree_CheckedChanged(object sender, EventArgs e)
        {
            property = 3;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;//記得加!才會去感應鍵盤
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            switch (e.KeyCode)
            {
                case Keys.A:
                    if (myself.Location.X != 20)//在最左邊那排
                        myself.Location = new Point(myself.Location.X - 50, 300);
                    break;
                case Keys.D:
                    if (myself.Location.X != 170)//在最右邊那排
                        myself.Location = new Point(myself.Location.X + 50, 300);
                    break;
                case Keys.W:
                    if (kill)//冷卻1秒了
                    {
                        kill = false;
                        if (shot1.Visible)//如果子彈1已在場上，換子彈2出馬
                        {
                            kill = false;
                            run2 = true;
                            shot2.Visible = true;
                            Controls.Add(shot2);
                            shot2.Location = new Point(myself.Location.X + 10, myself.Location.Y);
                            shot2.Size = new Size(20, 20);
                            setColor(shot2, true);
                            timer3.Enabled = true;

                        }
                        else
                        {
                            kill = false;
                            run1 = true;
                            shot1.Visible = true;
                            Controls.Add(shot1);
                            shot1.Location = new Point(myself.Location.X + 10, myself.Location.Y);
                            shot1.Size = new Size(20, 20);
                            setColor(shot1, true);
                            timer3.Enabled = true;
                        }
                    }
                    break;
            }
        }
        public void setColor(Button btn, bool me)
        {
            if (me)//如果是自己或子彈，不需要隨機，只需要根據屬性去變顏色
            {
                if (property == 1) btn.BackColor = Color.Blue;
                else if (property == 2) btn.BackColor = Color.Red;
                else if (property == 3) btn.BackColor = Color.Green;
                if (btn == myself) btn.Text = "你";
                btn.ForeColor = Color.White;
            }
            else//4排的敵人去找隨機顏色
            {
                int[] color = new int[] { 1, 2, 3 };
                int loc = rand.Next(1, 4);
                if (loc == 1)
                {
                    btn.BackColor = Color.Blue;
                    btn.Text = "水";
                    btn.ForeColor = Color.White;
                }
                else if (loc == 2)
                {
                    btn.BackColor = Color.Red;
                    btn.Text = "火";
                    btn.ForeColor = Color.White;
                }
                else if (loc == 3)
                {
                    btn.BackColor = Color.Green;
                    btn.Text = "木";
                    btn.ForeColor = Color.White;
                }
            }
        }
        public void SetBtn(Button btn,int col,int height)
        {
            btn.Size = new Size(40, 40);
            btn.Location = new Point(20+col*50, height);
            Controls.Add(btn);
        }
        public void lblTxt()
        {
            if (property == 1) lblPro.Text = "目前屬性 : 水";
            else if (property == 2) lblPro.Text = "目前屬性 : 火";
            else if (property == 3) lblPro.Text = "目前屬性 : 木";
            lblGrade.Text = "目前分數 : " + grade;
            lbltime.Text = "剩餘時間 : " + sec;
        }
        public void SetLabel()
        {
            lblTxt();
            lblPro.Location = new Point(500, 10);
            lblGrade.Location = new Point(500, 30);
            lbltime.Location = new Point(500, 50);
            lblPro.Size = new Size(100, 15);
            lblGrade.Size = new Size(100, 15);
            lbltime.Size = new Size(100, 15);
            Controls.Add(lblPro);
            Controls.Add(lblGrade);
            Controls.Add(lbltime);
        }
        
        private void btnStart_Click(object sender, EventArgs e)
        {
            timer2.Enabled = true;
            timer1.Enabled = true;
            lblChoose.Visible = false;
            btnWater.Visible = false;
            btnFire.Visible = false;
            btnTree.Visible = false;
            btnStart.Visible = false;
            SetLabel();
            SetBtn(row1Enemy,0,20);
            setColor(row1Enemy,false);
            SetBtn(row2Enemy,1,20);
            setColor(row2Enemy,false);
            SetBtn(row3Enemy,2,20);
            setColor(row3Enemy,false);
            SetBtn(row4Enemy,3,20);
            setColor(row4Enemy, false);
            SetBtn(myself,1,300);
            setColor(myself, true);
            myself.BringToFront();
        }
        private void timer1_Tick(object sender, EventArgs e)//記落下時間
        {
           
            /* If enemy drop to buttom,we need to pull it up. */
            if (row1Enemy.Location.Y == 500)//10,20,30公倍數+20
            {
                row1Enemy.Location = new Point(row1Enemy.Location.X, 20);
                setColor(row1Enemy,false);
            }
            if (row2Enemy.Location.Y == 500)
            {
                row2Enemy.Location = new Point(row2Enemy.Location.X, 20);
                setColor(row2Enemy, false);
            }
            if (row3Enemy.Location.Y == 500)
            {
                row3Enemy.Location = new Point(row3Enemy.Location.X, 20);
                setColor(row3Enemy, false);
            }
            if (row4Enemy.Location.Y == 500)
            {
                row4Enemy.Location = new Point(row4Enemy.Location.X, 20);
                setColor(row4Enemy, false);
            }
            /* Move the button. */
            row1Enemy.Location = new Point(row1Enemy.Location.X, row1Enemy.Location.Y + row1.getV(row1Enemy.BackColor));
            row2Enemy.Location = new Point(row2Enemy.Location.X, row2Enemy.Location.Y + row2.getV(row2Enemy.BackColor));
            row3Enemy.Location = new Point(row3Enemy.Location.X, row3Enemy.Location.Y + row3.getV(row3Enemy.BackColor));
            row4Enemy.Location = new Point(row4Enemy.Location.X, row4Enemy.Location.Y + row4.getV(row4Enemy.BackColor));
            if (run1)
                shot1.Location = new Point(shot1.Location.X, shot1.Location.Y - myshot1.getV(myself.BackColor));
            if(run2)
                shot2.Location = new Point(shot2.Location.X, shot2.Location.Y - myshot2.getV(myself.BackColor));
            /* Check if enemy collide to myself or bullet. */
            boom(row1Enemy);
            boom(row2Enemy);
            boom(row3Enemy);
            boom(row4Enemy);
        }
        /*Check if the enemy touch myself or bullet .*/
        public void boom(Button enemy)
        {
            int rank = 1;//敵人屬性
            if (enemy.BackColor == Color.Blue) rank = 1;
            else if (enemy.BackColor == Color.Red) rank = 2;
            else if (enemy.BackColor == Color.Green) rank = 3;
            if (enemy.Location.X == myself.Location.X && (enemy.Location.Y >= myself.Location.Y - 40 && enemy.Location.Y <= myself.Location.Y + 40))//遇到其他button
            {
                if ((property == 1 && rank == 2) || (property == 2 && rank == 3) || (property == 3 && rank == 1))//遇到克制屬性
                {
                    grade += 5;
                    property = rank;//要把自己屬性換成對方的
                    setColor(myself, true);
                    enemy.Location = new Point(enemy.Location.X, 20);//撞到後重新把敵人拖回最上層並隨機改變屬性
                    setColor(enemy, false);
                    lblTxt();
                }
                else if ((property == 2 && rank == 1) || (property == 3 && rank == 2) || (property == 1 && rank == 3))//遇到被克制屬性
                {
                    grade -= 5;
                    enemy.Location = new Point(enemy.Location.X, 20);
                    setColor(enemy, false);
                    if(grade>=0)lblTxt();//小於0等到之後判定再顯示，否則會為負
                }
            }
            else if (shot1.Visible&& shot1.Location.X == enemy.Location.X + 10 && shot1.Location.Y <= enemy.Location.Y + 40)//遇到子彈
            {
                if ((property == 1 && rank == 2) || (property == 2 && rank == 3) || (property == 3 && rank == 1))
                {
                    afterKill(ref shot1, enemy, run1);
                    grade += 2;
                    lblTxt();
                }
                else if((property == 2 && rank == 1) || (property == 3 && rank == 2) || (property == 1 && rank == 3))
                {
                    afterKill(ref shot1, enemy, run1);
                    grade -= 2;
                    if (grade >= 0) lblTxt();
                }
                else
                {
                    afterKill(ref shot1, enemy, run1);
                    lblTxt();
                }
            }
            else if (shot2.Visible && shot2.Location.X == enemy.Location.X + 10 && shot2.Location.Y <= enemy.Location.Y + 40)//遇到子彈
            {
                if ((property == 1 && rank == 2) || (property == 2 && rank == 3) || (property == 3 && rank == 1))
                {
                    afterKill(ref shot2, enemy, run2);
                    grade += 2;
                    lblTxt();
                }
                else if ((property == 2 && rank == 1) || (property == 3 && rank == 2) || (property == 1 && rank == 3))
                {
                    afterKill(ref shot2, enemy, run2);
                    grade -= 2;
                    lblTxt();
                }
                else
                {
                    afterKill(ref shot2, enemy, run2);
                    lblTxt();
                }
            }
        }
        public void afterKill(ref Button shot,Button enemy,bool run)//子彈碰到後的動作
        {
            shot.Location = new Point(myself.Location.X + 10, myself.Location.Y * 2);//先移走.看不到再移除(否則移除的子彈的位置會影響之後敵人判定的結果)
            shot.Visible = false;
            Controls.Remove(shot);
            enemy.Location = new Point(enemy.Location.X, 20);
            setColor(enemy, false);
            run = false;//子彈停止跑動
        }
        private void timer2_Tick(object sender, EventArgs e)//記倒數時間
        {
            
            sec--;
            lblTxt();
            if (sec == 0)
            {
                timer1.Enabled = false;
                timer2.Enabled = false;
                MessageBox.Show("遊戲結束!" + Environment.NewLine + "你的分數 : " + grade, "", MessageBoxButtons.OK, MessageBoxIcon.None);
                Application.Exit();
            }
            else if (grade <0)
            {
                grade = 0;
                lblTxt();
                timer1.Enabled = false;
                timer2.Enabled = false;
                if (myself.BackColor == Color.Blue)
                {
                    MessageBox.Show("你枯竭了!" + Environment.NewLine + "你的分數 : 0", "", MessageBoxButtons.OK, MessageBoxIcon.None);
                    Application.Exit();//離開程式
                }
                else if (myself.BackColor == Color.Red)
                {
                    MessageBox.Show("你被熄滅了!" + Environment.NewLine + "你的分數 : 0", "", MessageBoxButtons.OK, MessageBoxIcon.None);
                    Application.Exit();
                }
                else if (myself.BackColor == Color.Green)
                {
                    MessageBox.Show("你燒起來了!" + Environment.NewLine + "你的分數 : 0", "", MessageBoxButtons.OK, MessageBoxIcon.None);
                    Application.Exit();
                }
                }
        }
        
        private void timer3_Tick(object sender, EventArgs e)
        {
            cool--;
            if (cool == 0)
            {
                kill = true;
                cool = 1;
            }
        }
    }
}
