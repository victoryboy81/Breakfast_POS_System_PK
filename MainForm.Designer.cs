namespace BreakfastCart
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        
        private System.Windows.Forms.DataGridView dgvMenu;
        private System.Windows.Forms.DataGridView dgvCart;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.NumericUpDown numQty;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCheckout;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.GroupBox grpMenu;
        private System.Windows.Forms.GroupBox grpCart;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog;
        private System.Drawing.Printing.PrintDocument printDocument;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            Tab_usermenu = new TabPage();
            grpMenu = new GroupBox();
            panel2 = new Panel();
            reviewimg = new PictureBox();
            dgvMenu = new DataGridView();
            btnAdd = new Button();
            panel1 = new Panel();
            VIPcheckbtn = new Button();
            VIPIDtxt = new TextBox();
            VIPlab = new Label();
            lblSearch = new Label();
            txtSearch = new TextBox();
            dgvCart = new DataGridView();
            numQty = new NumericUpDown();
            lblQty = new Label();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnCheckout = new Button();
            lblTotal = new Label();
            lblDiscount = new Label();
            grpCart = new GroupBox();
            panel3 = new Panel();
            btnsort = new Button();
            printPreviewDialog = new PrintPreviewDialog();
            printDocument = new System.Drawing.Printing.PrintDocument();
            tabControl1 = new TabControl();
            Tab_adminmenu = new TabPage();
            groupBox1 = new GroupBox();
            panel4 = new Panel();
            txtlab = new Label();
            panel6 = new Panel();
            menuNametxt = new TextBox();
            menuNamelab = new Label();
            menuPricetxt = new TextBox();
            menuPricelab = new Label();
            ProductIdtxt = new TextBox();
            ProductIdlab = new Label();
            panel5 = new Panel();
            menuaddbtn = new Button();
            menudeletebtn = new Button();
            menuupdatebtn = new Button();
            menusortbtn = new Button();
            adminmenupicture = new PictureBox();
            label5 = new Label();
            searchtxt = new TextBox();
            searchlab = new Label();
            adminmenudgv = new DataGridView();
            Tab_MemberVIP = new TabPage();
            groupBox2 = new GroupBox();
            panel7 = new Panel();
            custdgv = new DataGridView();
            panel16 = new Panel();
            custsearchlab = new Label();
            custsearchtxt = new TextBox();
            panel9 = new Panel();
            custsortbtn = new Button();
            custdeletebtn = new Button();
            custupdatebtn = new Button();
            custaddbtn = new Button();
            panel8 = new Panel();
            custIDtxt = new TextBox();
            custIDlab = new Label();
            regioncombo = new ComboBox();
            custnametxt = new TextBox();
            paylab = new Label();
            paycombo = new ComboBox();
            regionlab = new Label();
            custnamelab = new Label();
            Tab_Order = new TabPage();
            groupBox3 = new GroupBox();
            panel10 = new Panel();
            ordermasterdgv = new DataGridView();
            panel12 = new Panel();
            ordermasterupdatebtn = new Button();
            ordermasteraddbtn = new Button();
            ordermastersortbtn = new Button();
            ordermasterdeletebtn = new Button();
            panel17 = new Panel();
            ordermastercustIDsearchlab = new Label();
            ordermastercustIDsearchtxt = new TextBox();
            panel11 = new Panel();
            totalquantitytxt = new TextBox();
            totalquantitylab = new Label();
            ordermasterIDtxt = new TextBox();
            ordermasterIDlab = new Label();
            ordermasterdatetxt = new TextBox();
            ordermastercustIDlab = new Label();
            ordermasterdatelab = new Label();
            ordermastercustIDtxt = new TextBox();
            ordermastertotaltxt = new TextBox();
            ordermastertotallab = new Label();
            Tab_OrderDetail = new TabPage();
            groupBox4 = new GroupBox();
            panel13 = new Panel();
            panel18 = new Panel();
            orderdetailcustIDsearchtxt = new TextBox();
            orderdetailcustIDsearchlab = new Label();
            orderdetaildgv = new DataGridView();
            panel15 = new Panel();
            orderdetailsortbtn = new Button();
            orderdetaildeletebtn = new Button();
            orderdetailupdatebtn = new Button();
            orderdetailaddbtn = new Button();
            panel14 = new Panel();
            numberIDtxt = new TextBox();
            numberIDlab = new Label();
            orderdetatilsubTotaltxt = new TextBox();
            orderdetatilsubTotallab = new Label();
            orderdetailPricetxt = new TextBox();
            orderdetailPricelab = new Label();
            orderdetailquantitytxt = new TextBox();
            orderdetailquantitylab = new Label();
            orderdetailProductIdtxt = new TextBox();
            orderdetailProductIdlab = new Label();
            orderdetailIDtxt = new TextBox();
            orderdetailIDlab = new Label();
            showVIPmessiagelab = new Label();
            Tab_usermenu.SuspendLayout();
            grpMenu.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)reviewimg).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvMenu).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCart).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numQty).BeginInit();
            grpCart.SuspendLayout();
            panel3.SuspendLayout();
            tabControl1.SuspendLayout();
            Tab_adminmenu.SuspendLayout();
            groupBox1.SuspendLayout();
            panel4.SuspendLayout();
            panel6.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)adminmenupicture).BeginInit();
            ((System.ComponentModel.ISupportInitialize)adminmenudgv).BeginInit();
            Tab_MemberVIP.SuspendLayout();
            groupBox2.SuspendLayout();
            panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)custdgv).BeginInit();
            panel16.SuspendLayout();
            panel9.SuspendLayout();
            panel8.SuspendLayout();
            Tab_Order.SuspendLayout();
            groupBox3.SuspendLayout();
            panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ordermasterdgv).BeginInit();
            panel12.SuspendLayout();
            panel17.SuspendLayout();
            panel11.SuspendLayout();
            Tab_OrderDetail.SuspendLayout();
            groupBox4.SuspendLayout();
            panel13.SuspendLayout();
            panel18.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)orderdetaildgv).BeginInit();
            panel15.SuspendLayout();
            panel14.SuspendLayout();
            SuspendLayout();
            // 
            // Tab_usermenu
            // 
            Tab_usermenu.BackColor = Color.DarkGray;
            Tab_usermenu.Controls.Add(grpMenu);
            Tab_usermenu.Location = new Point(4, 35);
            Tab_usermenu.Margin = new Padding(5);
            Tab_usermenu.Name = "Tab_usermenu";
            Tab_usermenu.Padding = new Padding(5);
            Tab_usermenu.Size = new Size(669, 893);
            Tab_usermenu.TabIndex = 0;
            Tab_usermenu.Text = "菜單(顧客)";
            // 
            // grpMenu
            // 
            grpMenu.BackColor = Color.FromArgb(224, 224, 224);
            grpMenu.Controls.Add(panel2);
            grpMenu.Controls.Add(panel1);
            grpMenu.Location = new Point(6, 5);
            grpMenu.Margin = new Padding(5);
            grpMenu.Name = "grpMenu";
            grpMenu.Padding = new Padding(5);
            grpMenu.Size = new Size(652, 871);
            grpMenu.TabIndex = 6;
            grpMenu.TabStop = false;
            grpMenu.Text = "早餐菜單";
            // 
            // panel2
            // 
            panel2.Controls.Add(reviewimg);
            panel2.Controls.Add(dgvMenu);
            panel2.Controls.Add(btnAdd);
            panel2.Location = new Point(13, 103);
            panel2.Margin = new Padding(5);
            panel2.Name = "panel2";
            panel2.Size = new Size(630, 759);
            panel2.TabIndex = 2;
            // 
            // reviewimg
            // 
            reviewimg.BorderStyle = BorderStyle.Fixed3D;
            reviewimg.Location = new Point(13, 408);
            reviewimg.Margin = new Padding(5);
            reviewimg.Name = "reviewimg";
            reviewimg.Size = new Size(204, 110);
            reviewimg.SizeMode = PictureBoxSizeMode.AutoSize;
            reviewimg.TabIndex = 6;
            reviewimg.TabStop = false;
            // 
            // dgvMenu
            // 
            dgvMenu.BackgroundColor = Color.White;
            dgvMenu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMenu.Location = new Point(5, 17);
            dgvMenu.Margin = new Padding(5);
            dgvMenu.Name = "dgvMenu";
            dgvMenu.RowHeadersWidth = 62;
            dgvMenu.Size = new Size(621, 294);
            dgvMenu.TabIndex = 0;
            dgvMenu.CurrentCellChanged += dgvMenu_CurrentCellChanged;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(255, 128, 255);
            btnAdd.Location = new Point(5, 320);
            btnAdd.Margin = new Padding(5);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(171, 61);
            btnAdd.TabIndex = 5;
            btnAdd.Text = "\U0001f6d2加入購物車";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += BtnAdd_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(VIPcheckbtn);
            panel1.Controls.Add(VIPIDtxt);
            panel1.Controls.Add(VIPlab);
            panel1.Controls.Add(lblSearch);
            panel1.Controls.Add(txtSearch);
            panel1.Location = new Point(9, 32);
            panel1.Margin = new Padding(5);
            panel1.Name = "panel1";
            panel1.Size = new Size(643, 61);
            panel1.TabIndex = 1;
            // 
            // VIPcheckbtn
            // 
            VIPcheckbtn.Location = new Point(546, 9);
            VIPcheckbtn.Name = "VIPcheckbtn";
            VIPcheckbtn.Size = new Size(84, 34);
            VIPcheckbtn.TabIndex = 5;
            VIPcheckbtn.Text = "驗證";
            VIPcheckbtn.UseVisualStyleBackColor = true;
            VIPcheckbtn.Click += VIPcheckbtn_Click;
            // 
            // VIPIDtxt
            // 
            VIPIDtxt.Location = new Point(402, 11);
            VIPIDtxt.Name = "VIPIDtxt";
            VIPIDtxt.Size = new Size(116, 30);
            VIPIDtxt.TabIndex = 4;
            VIPIDtxt.TextChanged += VIPIDtxt_TextChanged;
            // 
            // VIPlab
            // 
            VIPlab.AutoSize = true;
            VIPlab.Location = new Point(300, 18);
            VIPlab.Name = "VIPlab";
            VIPlab.Size = new Size(86, 23);
            VIPlab.TabIndex = 3;
            VIPlab.Text = "會員序號:";
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Location = new Point(25, 20);
            lblSearch.Margin = new Padding(5, 0, 5, 0);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(86, 23);
            lblSearch.TabIndex = 2;
            lblSearch.Text = "搜尋菜單:";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(126, 15);
            txtSearch.Margin = new Padding(5);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(134, 30);
            txtSearch.TabIndex = 1;
            txtSearch.TextChanged += TxtSearch_TextChanged;
            // 
            // dgvCart
            // 
            dgvCart.BackgroundColor = Color.White;
            dgvCart.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCart.Location = new Point(5, 9);
            dgvCart.Margin = new Padding(5);
            dgvCart.Name = "dgvCart";
            dgvCart.RowHeadersWidth = 62;
            dgvCart.Size = new Size(632, 428);
            dgvCart.TabIndex = 0;
            // 
            // numQty
            // 
            numQty.Location = new Point(709, 49);
            numQty.Margin = new Padding(5);
            numQty.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numQty.Name = "numQty";
            numQty.Size = new Size(71, 30);
            numQty.TabIndex = 3;
            numQty.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblQty
            // 
            lblQty.AutoSize = true;
            lblQty.Location = new Point(646, 52);
            lblQty.Margin = new Padding(5, 0, 5, 0);
            lblQty.Name = "lblQty";
            lblQty.Size = new Size(50, 23);
            lblQty.TabIndex = 4;
            lblQty.Text = "數量:";
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(662, 112);
            btnUpdate.Margin = new Padding(5);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(118, 54);
            btnUpdate.TabIndex = 1;
            btnUpdate.Text = "修改數量";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += BtnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(662, 204);
            btnDelete.Margin = new Padding(5);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(118, 52);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "刪除項目";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += BtnDelete_Click;
            // 
            // btnCheckout
            // 
            btnCheckout.BackColor = Color.LightGreen;
            btnCheckout.Location = new Point(5, 455);
            btnCheckout.Margin = new Padding(5);
            btnCheckout.Name = "btnCheckout";
            btnCheckout.Size = new Size(171, 61);
            btnCheckout.TabIndex = 4;
            btnCheckout.Text = "💰 結帳列印";
            btnCheckout.UseVisualStyleBackColor = false;
            btnCheckout.Click += BtnCheckout_Click;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Arial", 12F, FontStyle.Bold);
            lblTotal.Location = new Point(31, 596);
            lblTotal.Margin = new Padding(5, 0, 5, 0);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(125, 29);
            lblTotal.TabIndex = 5;
            lblTotal.Text = "總金額: $0";
            // 
            // lblDiscount
            // 
            lblDiscount.AutoSize = true;
            lblDiscount.ForeColor = Color.Red;
            lblDiscount.Location = new Point(31, 676);
            lblDiscount.Margin = new Padding(5, 0, 5, 0);
            lblDiscount.Name = "lblDiscount";
            lblDiscount.Size = new Size(109, 23);
            lblDiscount.TabIndex = 6;
            lblDiscount.Text = "目前折扣: 無";
            // 
            // grpCart
            // 
            grpCart.Controls.Add(panel3);
            grpCart.Controls.Add(lblTotal);
            grpCart.Controls.Add(lblDiscount);
            grpCart.Location = new Point(701, 97);
            grpCart.Margin = new Padding(5);
            grpCart.Name = "grpCart";
            grpCart.Padding = new Padding(5);
            grpCart.Size = new Size(817, 895);
            grpCart.TabIndex = 7;
            grpCart.TabStop = false;
            grpCart.Text = "購物車清單";
            // 
            // panel3
            // 
            panel3.Controls.Add(btnsort);
            panel3.Controls.Add(dgvCart);
            panel3.Controls.Add(btnDelete);
            panel3.Controls.Add(numQty);
            panel3.Controls.Add(lblQty);
            panel3.Controls.Add(btnUpdate);
            panel3.Controls.Add(btnCheckout);
            panel3.Location = new Point(9, 32);
            panel3.Margin = new Padding(5);
            panel3.Name = "panel3";
            panel3.Size = new Size(798, 541);
            panel3.TabIndex = 7;
            // 
            // btnsort
            // 
            btnsort.Location = new Point(662, 299);
            btnsort.Name = "btnsort";
            btnsort.Size = new Size(118, 52);
            btnsort.TabIndex = 5;
            btnsort.Text = "金額排序";
            btnsort.UseVisualStyleBackColor = true;
            btnsort.Click += btnsort_Click;
            // 
            // printPreviewDialog
            // 
            printPreviewDialog.AutoScrollMargin = new Size(0, 0);
            printPreviewDialog.AutoScrollMinSize = new Size(0, 0);
            printPreviewDialog.ClientSize = new Size(400, 300);
            printPreviewDialog.Enabled = true;
            printPreviewDialog.Icon = (Icon)resources.GetObject("printPreviewDialog.Icon");
            printPreviewDialog.Name = "printPreviewDialog";
            printPreviewDialog.Visible = false;
            // 
            // printDocument
            // 
            printDocument.PrintPage += PrintDocument_PrintPage;
            // 
            // tabControl1
            // 
            tabControl1.Appearance = TabAppearance.FlatButtons;
            tabControl1.Controls.Add(Tab_usermenu);
            tabControl1.Controls.Add(Tab_adminmenu);
            tabControl1.Controls.Add(Tab_MemberVIP);
            tabControl1.Controls.Add(Tab_Order);
            tabControl1.Controls.Add(Tab_OrderDetail);
            tabControl1.Location = new Point(14, 60);
            tabControl1.Margin = new Padding(5);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(677, 932);
            tabControl1.TabIndex = 8;
            tabControl1.Selecting += tabControl1_Selecting;
            // 
            // Tab_adminmenu
            // 
            Tab_adminmenu.BackColor = Color.DarkGray;
            Tab_adminmenu.Controls.Add(groupBox1);
            Tab_adminmenu.Location = new Point(4, 35);
            Tab_adminmenu.Margin = new Padding(5);
            Tab_adminmenu.Name = "Tab_adminmenu";
            Tab_adminmenu.Padding = new Padding(5);
            Tab_adminmenu.Size = new Size(669, 893);
            Tab_adminmenu.TabIndex = 1;
            Tab_adminmenu.Text = "菜單(管理員)";
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.FromArgb(224, 224, 224);
            groupBox1.Controls.Add(panel4);
            groupBox1.Controls.Add(adminmenudgv);
            groupBox1.Location = new Point(5, 5);
            groupBox1.Margin = new Padding(5);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(5);
            groupBox1.Size = new Size(651, 872);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "菜單管理";
            // 
            // panel4
            // 
            panel4.Controls.Add(txtlab);
            panel4.Controls.Add(panel6);
            panel4.Controls.Add(panel5);
            panel4.Controls.Add(adminmenupicture);
            panel4.Controls.Add(label5);
            panel4.Controls.Add(searchtxt);
            panel4.Controls.Add(searchlab);
            panel4.Location = new Point(9, 28);
            panel4.Margin = new Padding(5);
            panel4.Name = "panel4";
            panel4.Size = new Size(607, 414);
            panel4.TabIndex = 1;
            // 
            // txtlab
            // 
            txtlab.AutoSize = true;
            txtlab.Location = new Point(220, 262);
            txtlab.Margin = new Padding(5, 0, 5, 0);
            txtlab.Name = "txtlab";
            txtlab.Size = new Size(61, 23);
            txtlab.TabIndex = 15;
            txtlab.Text = "label1";
            // 
            // panel6
            // 
            panel6.Controls.Add(menuNametxt);
            panel6.Controls.Add(menuNamelab);
            panel6.Controls.Add(menuPricetxt);
            panel6.Controls.Add(menuPricelab);
            panel6.Controls.Add(ProductIdtxt);
            panel6.Controls.Add(ProductIdlab);
            panel6.Location = new Point(13, 11);
            panel6.Name = "panel6";
            panel6.Size = new Size(262, 150);
            panel6.TabIndex = 14;
            // 
            // menuNametxt
            // 
            menuNametxt.Location = new Point(119, 64);
            menuNametxt.Margin = new Padding(5);
            menuNametxt.Name = "menuNametxt";
            menuNametxt.Size = new Size(130, 30);
            menuNametxt.TabIndex = 3;
            // 
            // menuNamelab
            // 
            menuNamelab.AutoSize = true;
            menuNamelab.Location = new Point(16, 72);
            menuNamelab.Margin = new Padding(5, 0, 5, 0);
            menuNamelab.Name = "menuNamelab";
            menuNamelab.Size = new Size(46, 23);
            menuNamelab.TabIndex = 0;
            menuNamelab.Text = "品項";
            // 
            // menuPricetxt
            // 
            menuPricetxt.Location = new Point(119, 110);
            menuPricetxt.Margin = new Padding(5);
            menuPricetxt.Name = "menuPricetxt";
            menuPricetxt.Size = new Size(130, 30);
            menuPricetxt.TabIndex = 4;
            // 
            // menuPricelab
            // 
            menuPricelab.AutoSize = true;
            menuPricelab.Location = new Point(16, 118);
            menuPricelab.Margin = new Padding(5, 0, 5, 0);
            menuPricelab.Name = "menuPricelab";
            menuPricelab.Size = new Size(46, 23);
            menuPricelab.TabIndex = 1;
            menuPricelab.Text = "價格";
            // 
            // ProductIdtxt
            // 
            ProductIdtxt.Location = new Point(119, 20);
            ProductIdtxt.Margin = new Padding(5);
            ProductIdtxt.Name = "ProductIdtxt";
            ProductIdtxt.Size = new Size(130, 30);
            ProductIdtxt.TabIndex = 5;
            // 
            // ProductIdlab
            // 
            ProductIdlab.AutoSize = true;
            ProductIdlab.Location = new Point(16, 23);
            ProductIdlab.Margin = new Padding(5, 0, 5, 0);
            ProductIdlab.Name = "ProductIdlab";
            ProductIdlab.Size = new Size(82, 23);
            ProductIdlab.TabIndex = 2;
            ProductIdlab.Text = "產品序號";
            // 
            // panel5
            // 
            panel5.Controls.Add(menuaddbtn);
            panel5.Controls.Add(menudeletebtn);
            panel5.Controls.Add(menuupdatebtn);
            panel5.Controls.Add(menusortbtn);
            panel5.Location = new Point(281, 11);
            panel5.Name = "panel5";
            panel5.Size = new Size(300, 150);
            panel5.TabIndex = 13;
            // 
            // menuaddbtn
            // 
            menuaddbtn.BackColor = Color.FromArgb(255, 192, 128);
            menuaddbtn.FlatAppearance.BorderColor = Color.White;
            menuaddbtn.FlatStyle = FlatStyle.Flat;
            menuaddbtn.Location = new Point(39, 31);
            menuaddbtn.Margin = new Padding(5);
            menuaddbtn.Name = "menuaddbtn";
            menuaddbtn.Size = new Size(118, 35);
            menuaddbtn.TabIndex = 6;
            menuaddbtn.Text = "新增";
            menuaddbtn.UseVisualStyleBackColor = false;
            menuaddbtn.Click += menuaddbtn_Click;
            // 
            // menudeletebtn
            // 
            menudeletebtn.BackColor = Color.FromArgb(255, 192, 128);
            menudeletebtn.FlatAppearance.BorderColor = Color.White;
            menudeletebtn.FlatStyle = FlatStyle.Flat;
            menudeletebtn.Location = new Point(39, 86);
            menudeletebtn.Margin = new Padding(5);
            menudeletebtn.Name = "menudeletebtn";
            menudeletebtn.Size = new Size(118, 35);
            menudeletebtn.TabIndex = 8;
            menudeletebtn.Text = "刪除";
            menudeletebtn.UseVisualStyleBackColor = false;
            menudeletebtn.Click += menudeletebtn_Click;
            // 
            // menuupdatebtn
            // 
            menuupdatebtn.BackColor = Color.FromArgb(255, 192, 128);
            menuupdatebtn.FlatAppearance.BorderColor = Color.White;
            menuupdatebtn.FlatStyle = FlatStyle.Flat;
            menuupdatebtn.Location = new Point(178, 31);
            menuupdatebtn.Margin = new Padding(5);
            menuupdatebtn.Name = "menuupdatebtn";
            menuupdatebtn.Size = new Size(118, 35);
            menuupdatebtn.TabIndex = 7;
            menuupdatebtn.Text = "更新";
            menuupdatebtn.UseVisualStyleBackColor = false;
            menuupdatebtn.Click += menuupdatebtn_Click;
            // 
            // menusortbtn
            // 
            menusortbtn.BackColor = Color.FromArgb(255, 192, 128);
            menusortbtn.FlatAppearance.BorderColor = Color.White;
            menusortbtn.FlatStyle = FlatStyle.Flat;
            menusortbtn.Location = new Point(178, 86);
            menusortbtn.Margin = new Padding(5);
            menusortbtn.Name = "menusortbtn";
            menusortbtn.Size = new Size(118, 35);
            menusortbtn.TabIndex = 9;
            menusortbtn.Text = "排序";
            menusortbtn.UseVisualStyleBackColor = false;
            menusortbtn.Click += menusortbtn_Click;
            // 
            // adminmenupicture
            // 
            adminmenupicture.BorderStyle = BorderStyle.Fixed3D;
            adminmenupicture.Location = new Point(28, 255);
            adminmenupicture.Margin = new Padding(5);
            adminmenupicture.Name = "adminmenupicture";
            adminmenupicture.Size = new Size(177, 139);
            adminmenupicture.SizeMode = PictureBoxSizeMode.StretchImage;
            adminmenupicture.TabIndex = 2;
            adminmenupicture.TabStop = false;
            // 
            // label5
            // 
            label5.BorderStyle = BorderStyle.FixedSingle;
            label5.Location = new Point(28, 170);
            label5.Margin = new Padding(5, 0, 5, 0);
            label5.Name = "label5";
            label5.Size = new Size(554, 2);
            label5.TabIndex = 12;
            // 
            // searchtxt
            // 
            searchtxt.Location = new Point(132, 196);
            searchtxt.Margin = new Padding(5);
            searchtxt.Name = "searchtxt";
            searchtxt.Size = new Size(446, 30);
            searchtxt.TabIndex = 11;
            searchtxt.TextChanged += searchtxt_TextChanged;
            // 
            // searchlab
            // 
            searchlab.AutoSize = true;
            searchlab.Location = new Point(28, 199);
            searchlab.Margin = new Padding(5, 0, 5, 0);
            searchlab.Name = "searchlab";
            searchlab.Size = new Size(82, 23);
            searchlab.TabIndex = 10;
            searchlab.Text = "菜單查詢";
            // 
            // adminmenudgv
            // 
            adminmenudgv.BackgroundColor = Color.White;
            adminmenudgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            adminmenudgv.Location = new Point(35, 451);
            adminmenudgv.Margin = new Padding(5);
            adminmenudgv.Name = "adminmenudgv";
            adminmenudgv.RowHeadersWidth = 62;
            adminmenudgv.Size = new Size(607, 406);
            adminmenudgv.TabIndex = 0;
            adminmenudgv.CurrentCellChanged += adminmenudgv_CurrentCellChanged;
            // 
            // Tab_MemberVIP
            // 
            Tab_MemberVIP.BackColor = Color.DarkGray;
            Tab_MemberVIP.Controls.Add(groupBox2);
            Tab_MemberVIP.Location = new Point(4, 35);
            Tab_MemberVIP.Name = "Tab_MemberVIP";
            Tab_MemberVIP.Padding = new Padding(3);
            Tab_MemberVIP.Size = new Size(669, 893);
            Tab_MemberVIP.TabIndex = 2;
            Tab_MemberVIP.Text = "會員(管理員)";
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.FromArgb(224, 224, 224);
            groupBox2.Controls.Add(panel7);
            groupBox2.Location = new Point(6, 8);
            groupBox2.Margin = new Padding(5);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(5);
            groupBox2.Size = new Size(651, 869);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            groupBox2.Text = "會員管理";
            // 
            // panel7
            // 
            panel7.BackColor = Color.FromArgb(224, 224, 224);
            panel7.Controls.Add(custdgv);
            panel7.Controls.Add(panel16);
            panel7.Controls.Add(panel9);
            panel7.Controls.Add(panel8);
            panel7.Location = new Point(19, 26);
            panel7.Margin = new Padding(5);
            panel7.Name = "panel7";
            panel7.Size = new Size(622, 833);
            panel7.TabIndex = 0;
            // 
            // custdgv
            // 
            custdgv.BackgroundColor = Color.White;
            custdgv.BorderStyle = BorderStyle.None;
            custdgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            custdgv.Location = new Point(22, 270);
            custdgv.Margin = new Padding(5);
            custdgv.Name = "custdgv";
            custdgv.RowHeadersWidth = 62;
            custdgv.Size = new Size(575, 544);
            custdgv.TabIndex = 1;
            custdgv.CurrentCellChanged += custdgv_CurrentCellChanged;
            // 
            // panel16
            // 
            panel16.BackColor = Color.FromArgb(128, 255, 255);
            panel16.Controls.Add(custsearchlab);
            panel16.Controls.Add(custsearchtxt);
            panel16.Location = new Point(22, 221);
            panel16.Name = "panel16";
            panel16.Size = new Size(575, 49);
            panel16.TabIndex = 4;
            // 
            // custsearchlab
            // 
            custsearchlab.AutoSize = true;
            custsearchlab.Location = new Point(22, 12);
            custsearchlab.Margin = new Padding(5, 0, 5, 0);
            custsearchlab.Name = "custsearchlab";
            custsearchlab.Size = new Size(82, 23);
            custsearchlab.TabIndex = 2;
            custsearchlab.Text = "會員查詢";
            // 
            // custsearchtxt
            // 
            custsearchtxt.Location = new Point(137, 9);
            custsearchtxt.Margin = new Padding(5);
            custsearchtxt.Name = "custsearchtxt";
            custsearchtxt.Size = new Size(403, 30);
            custsearchtxt.TabIndex = 3;
            custsearchtxt.TextChanged += custsearchtxt_TextChanged;
            // 
            // panel9
            // 
            panel9.BackColor = Color.FromArgb(255, 255, 192);
            panel9.Controls.Add(custsortbtn);
            panel9.Controls.Add(custdeletebtn);
            panel9.Controls.Add(custupdatebtn);
            panel9.Controls.Add(custaddbtn);
            panel9.Location = new Point(22, 9);
            panel9.Margin = new Padding(5);
            panel9.Name = "panel9";
            panel9.Size = new Size(575, 78);
            panel9.TabIndex = 1;
            // 
            // custsortbtn
            // 
            custsortbtn.Location = new Point(421, 23);
            custsortbtn.Margin = new Padding(5);
            custsortbtn.Name = "custsortbtn";
            custsortbtn.Size = new Size(118, 35);
            custsortbtn.TabIndex = 3;
            custsortbtn.Text = "排序";
            custsortbtn.UseVisualStyleBackColor = true;
            custsortbtn.Click += custsortbtn_Click;
            // 
            // custdeletebtn
            // 
            custdeletebtn.Location = new Point(284, 23);
            custdeletebtn.Margin = new Padding(5);
            custdeletebtn.Name = "custdeletebtn";
            custdeletebtn.Size = new Size(118, 35);
            custdeletebtn.TabIndex = 2;
            custdeletebtn.Text = "刪除";
            custdeletebtn.UseVisualStyleBackColor = true;
            custdeletebtn.Click += custdeletebtn_Click;
            // 
            // custupdatebtn
            // 
            custupdatebtn.Location = new Point(149, 23);
            custupdatebtn.Margin = new Padding(5);
            custupdatebtn.Name = "custupdatebtn";
            custupdatebtn.Size = new Size(118, 35);
            custupdatebtn.TabIndex = 1;
            custupdatebtn.Text = "更新";
            custupdatebtn.UseVisualStyleBackColor = true;
            custupdatebtn.Click += custupdatebtn_Click;
            // 
            // custaddbtn
            // 
            custaddbtn.Location = new Point(22, 23);
            custaddbtn.Margin = new Padding(5);
            custaddbtn.Name = "custaddbtn";
            custaddbtn.Size = new Size(118, 35);
            custaddbtn.TabIndex = 0;
            custaddbtn.Text = "新增";
            custaddbtn.UseVisualStyleBackColor = true;
            custaddbtn.Click += custaddbtn_Click;
            // 
            // panel8
            // 
            panel8.BackColor = Color.FromArgb(128, 255, 128);
            panel8.Controls.Add(custIDtxt);
            panel8.Controls.Add(custIDlab);
            panel8.Controls.Add(regioncombo);
            panel8.Controls.Add(custnametxt);
            panel8.Controls.Add(paylab);
            panel8.Controls.Add(paycombo);
            panel8.Controls.Add(regionlab);
            panel8.Controls.Add(custnamelab);
            panel8.Location = new Point(22, 87);
            panel8.Margin = new Padding(5);
            panel8.Name = "panel8";
            panel8.Size = new Size(575, 133);
            panel8.TabIndex = 0;
            // 
            // custIDtxt
            // 
            custIDtxt.Location = new Point(134, 17);
            custIDtxt.Name = "custIDtxt";
            custIDtxt.Size = new Size(153, 30);
            custIDtxt.TabIndex = 7;
            // 
            // custIDlab
            // 
            custIDlab.AutoSize = true;
            custIDlab.Location = new Point(28, 17);
            custIDlab.Name = "custIDlab";
            custIDlab.Size = new Size(82, 23);
            custIDlab.TabIndex = 6;
            custIDlab.Text = "客戶序號";
            // 
            // regioncombo
            // 
            regioncombo.FormattingEnabled = true;
            regioncombo.Location = new Point(398, 80);
            regioncombo.Margin = new Padding(5);
            regioncombo.Name = "regioncombo";
            regioncombo.Size = new Size(90, 31);
            regioncombo.TabIndex = 5;
            // 
            // custnametxt
            // 
            custnametxt.Location = new Point(398, 11);
            custnametxt.Margin = new Padding(5);
            custnametxt.Name = "custnametxt";
            custnametxt.Size = new Size(155, 30);
            custnametxt.TabIndex = 4;
            // 
            // paylab
            // 
            paylab.AutoSize = true;
            paylab.Location = new Point(28, 83);
            paylab.Margin = new Padding(5, 0, 5, 0);
            paylab.Name = "paylab";
            paylab.Size = new Size(82, 23);
            paylab.TabIndex = 3;
            paylab.Text = "付款方式";
            // 
            // paycombo
            // 
            paycombo.FormattingEnabled = true;
            paycombo.Location = new Point(132, 83);
            paycombo.Margin = new Padding(5);
            paycombo.Name = "paycombo";
            paycombo.Size = new Size(155, 31);
            paycombo.TabIndex = 2;
            // 
            // regionlab
            // 
            regionlab.AutoSize = true;
            regionlab.Location = new Point(317, 80);
            regionlab.Margin = new Padding(5, 0, 5, 0);
            regionlab.Name = "regionlab";
            regionlab.Size = new Size(46, 23);
            regionlab.TabIndex = 1;
            regionlab.Text = "地區";
            // 
            // custnamelab
            // 
            custnamelab.AutoSize = true;
            custnamelab.Location = new Point(306, 12);
            custnamelab.Margin = new Padding(5, 0, 5, 0);
            custnamelab.Name = "custnamelab";
            custnamelab.Size = new Size(82, 23);
            custnamelab.TabIndex = 0;
            custnamelab.Text = "客戶名稱";
            // 
            // Tab_Order
            // 
            Tab_Order.BackColor = Color.DarkGray;
            Tab_Order.Controls.Add(groupBox3);
            Tab_Order.Location = new Point(4, 35);
            Tab_Order.Name = "Tab_Order";
            Tab_Order.Padding = new Padding(3);
            Tab_Order.Size = new Size(669, 893);
            Tab_Order.TabIndex = 3;
            Tab_Order.Text = "訂單主檔(管理員)";
            // 
            // groupBox3
            // 
            groupBox3.BackColor = Color.FromArgb(224, 224, 224);
            groupBox3.Controls.Add(panel10);
            groupBox3.Location = new Point(8, 8);
            groupBox3.Margin = new Padding(5);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(5);
            groupBox3.Size = new Size(649, 869);
            groupBox3.TabIndex = 0;
            groupBox3.TabStop = false;
            groupBox3.Text = "訂單主檔管理";
            // 
            // panel10
            // 
            panel10.Controls.Add(ordermasterdgv);
            panel10.Controls.Add(panel12);
            panel10.Controls.Add(panel17);
            panel10.Controls.Add(panel11);
            panel10.Location = new Point(17, 34);
            panel10.Margin = new Padding(5);
            panel10.Name = "panel10";
            panel10.Size = new Size(622, 840);
            panel10.TabIndex = 0;
            // 
            // ordermasterdgv
            // 
            ordermasterdgv.BackgroundColor = Color.White;
            ordermasterdgv.BorderStyle = BorderStyle.None;
            ordermasterdgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ordermasterdgv.Location = new Point(16, 304);
            ordermasterdgv.Margin = new Padding(5);
            ordermasterdgv.Name = "ordermasterdgv";
            ordermasterdgv.RowHeadersWidth = 62;
            ordermasterdgv.Size = new Size(602, 506);
            ordermasterdgv.TabIndex = 1;
            ordermasterdgv.CurrentCellChanged += ordermasterdgv_CurrentCellChanged;
            // 
            // panel12
            // 
            panel12.BackColor = Color.FromArgb(255, 255, 192);
            panel12.Controls.Add(ordermasterupdatebtn);
            panel12.Controls.Add(ordermasteraddbtn);
            panel12.Controls.Add(ordermastersortbtn);
            panel12.Controls.Add(ordermasterdeletebtn);
            panel12.Location = new Point(453, 17);
            panel12.Margin = new Padding(5);
            panel12.Name = "panel12";
            panel12.Size = new Size(165, 232);
            panel12.TabIndex = 7;
            // 
            // ordermasterupdatebtn
            // 
            ordermasterupdatebtn.Location = new Point(20, 74);
            ordermasterupdatebtn.Name = "ordermasterupdatebtn";
            ordermasterupdatebtn.Size = new Size(118, 35);
            ordermasterupdatebtn.TabIndex = 4;
            ordermasterupdatebtn.Text = "更新";
            ordermasterupdatebtn.UseVisualStyleBackColor = true;
            ordermasterupdatebtn.Click += ordermasterupdatebtn_Click;
            // 
            // ordermasteraddbtn
            // 
            ordermasteraddbtn.Location = new Point(20, 20);
            ordermasteraddbtn.Name = "ordermasteraddbtn";
            ordermasteraddbtn.Size = new Size(118, 35);
            ordermasteraddbtn.TabIndex = 3;
            ordermasteraddbtn.Text = "新增";
            ordermasteraddbtn.UseVisualStyleBackColor = true;
            ordermasteraddbtn.Click += ordermasteraddbtn_Click;
            // 
            // ordermastersortbtn
            // 
            ordermastersortbtn.Location = new Point(22, 173);
            ordermastersortbtn.Margin = new Padding(5);
            ordermastersortbtn.Name = "ordermastersortbtn";
            ordermastersortbtn.Size = new Size(118, 35);
            ordermastersortbtn.TabIndex = 2;
            ordermastersortbtn.Text = "排序";
            ordermastersortbtn.UseVisualStyleBackColor = true;
            ordermastersortbtn.Click += ordermastersortbtn_Click;
            // 
            // ordermasterdeletebtn
            // 
            ordermasterdeletebtn.Location = new Point(22, 123);
            ordermasterdeletebtn.Margin = new Padding(5);
            ordermasterdeletebtn.Name = "ordermasterdeletebtn";
            ordermasterdeletebtn.Size = new Size(118, 35);
            ordermasterdeletebtn.TabIndex = 1;
            ordermasterdeletebtn.Text = "刪除";
            ordermasterdeletebtn.UseVisualStyleBackColor = true;
            ordermasterdeletebtn.Click += ordermasterdeletebtn_Click;
            // 
            // panel17
            // 
            panel17.BackColor = Color.FromArgb(128, 255, 255);
            panel17.Controls.Add(ordermastercustIDsearchlab);
            panel17.Controls.Add(ordermastercustIDsearchtxt);
            panel17.Location = new Point(16, 248);
            panel17.Name = "panel17";
            panel17.Size = new Size(602, 58);
            panel17.TabIndex = 10;
            // 
            // ordermastercustIDsearchlab
            // 
            ordermastercustIDsearchlab.AutoSize = true;
            ordermastercustIDsearchlab.Location = new Point(16, 11);
            ordermastercustIDsearchlab.Margin = new Padding(5, 0, 5, 0);
            ordermastercustIDsearchlab.Name = "ordermastercustIDsearchlab";
            ordermastercustIDsearchlab.Size = new Size(118, 23);
            ordermastercustIDsearchlab.TabIndex = 8;
            ordermastercustIDsearchlab.Text = "客戶編號查詢";
            // 
            // ordermastercustIDsearchtxt
            // 
            ordermastercustIDsearchtxt.Location = new Point(152, 8);
            ordermastercustIDsearchtxt.Margin = new Padding(5);
            ordermastercustIDsearchtxt.Name = "ordermastercustIDsearchtxt";
            ordermastercustIDsearchtxt.Size = new Size(400, 30);
            ordermastercustIDsearchtxt.TabIndex = 9;
            ordermastercustIDsearchtxt.TextChanged += ordermastercustIDsearchtxt_TextChanged;
            // 
            // panel11
            // 
            panel11.BackColor = Color.FromArgb(128, 255, 128);
            panel11.Controls.Add(totalquantitytxt);
            panel11.Controls.Add(totalquantitylab);
            panel11.Controls.Add(ordermasterIDtxt);
            panel11.Controls.Add(ordermasterIDlab);
            panel11.Controls.Add(ordermasterdatetxt);
            panel11.Controls.Add(ordermastercustIDlab);
            panel11.Controls.Add(ordermasterdatelab);
            panel11.Controls.Add(ordermastercustIDtxt);
            panel11.Controls.Add(ordermastertotaltxt);
            panel11.Controls.Add(ordermastertotallab);
            panel11.Location = new Point(16, 17);
            panel11.Margin = new Padding(5);
            panel11.Name = "panel11";
            panel11.Size = new Size(437, 232);
            panel11.TabIndex = 6;
            // 
            // totalquantitytxt
            // 
            totalquantitytxt.Location = new Point(151, 150);
            totalquantitytxt.Name = "totalquantitytxt";
            totalquantitytxt.Size = new Size(155, 30);
            totalquantitytxt.TabIndex = 9;
            // 
            // totalquantitylab
            // 
            totalquantitylab.AutoSize = true;
            totalquantitylab.Location = new Point(20, 153);
            totalquantitylab.Name = "totalquantitylab";
            totalquantitylab.Size = new Size(64, 23);
            totalquantitylab.TabIndex = 8;
            totalquantitylab.Text = "總數量";
            // 
            // ordermasterIDtxt
            // 
            ordermasterIDtxt.Location = new Point(151, 15);
            ordermasterIDtxt.Name = "ordermasterIDtxt";
            ordermasterIDtxt.Size = new Size(221, 30);
            ordermasterIDtxt.TabIndex = 7;
            // 
            // ordermasterIDlab
            // 
            ordermasterIDlab.AutoSize = true;
            ordermasterIDlab.Location = new Point(20, 18);
            ordermasterIDlab.Name = "ordermasterIDlab";
            ordermasterIDlab.Size = new Size(82, 23);
            ordermasterIDlab.TabIndex = 6;
            ordermasterIDlab.Text = "訂單編號";
            // 
            // ordermasterdatetxt
            // 
            ordermasterdatetxt.Location = new Point(151, 97);
            ordermasterdatetxt.Margin = new Padding(5);
            ordermasterdatetxt.Name = "ordermasterdatetxt";
            ordermasterdatetxt.Size = new Size(221, 30);
            ordermasterdatetxt.TabIndex = 5;
            // 
            // ordermastercustIDlab
            // 
            ordermastercustIDlab.AutoSize = true;
            ordermastercustIDlab.Location = new Point(20, 57);
            ordermastercustIDlab.Margin = new Padding(5, 0, 5, 0);
            ordermastercustIDlab.Name = "ordermastercustIDlab";
            ordermastercustIDlab.Size = new Size(82, 23);
            ordermastercustIDlab.TabIndex = 0;
            ordermastercustIDlab.Text = "客戶編號";
            // 
            // ordermasterdatelab
            // 
            ordermasterdatelab.AutoSize = true;
            ordermasterdatelab.Location = new Point(20, 100);
            ordermasterdatelab.Margin = new Padding(5, 0, 5, 0);
            ordermasterdatelab.Name = "ordermasterdatelab";
            ordermasterdatelab.Size = new Size(82, 23);
            ordermasterdatelab.TabIndex = 4;
            ordermasterdatelab.Text = "下單日期";
            // 
            // ordermastercustIDtxt
            // 
            ordermastercustIDtxt.Location = new Point(151, 57);
            ordermastercustIDtxt.Margin = new Padding(5);
            ordermastercustIDtxt.Name = "ordermastercustIDtxt";
            ordermastercustIDtxt.Size = new Size(221, 30);
            ordermastercustIDtxt.TabIndex = 1;
            // 
            // ordermastertotaltxt
            // 
            ordermastertotaltxt.Location = new Point(151, 192);
            ordermastertotaltxt.Margin = new Padding(5);
            ordermastertotaltxt.Name = "ordermastertotaltxt";
            ordermastertotaltxt.Size = new Size(155, 30);
            ordermastertotaltxt.TabIndex = 3;
            // 
            // ordermastertotallab
            // 
            ordermastertotallab.AutoSize = true;
            ordermastertotallab.Location = new Point(20, 195);
            ordermastertotallab.Margin = new Padding(5, 0, 5, 0);
            ordermastertotallab.Name = "ordermastertotallab";
            ordermastertotallab.Size = new Size(100, 23);
            ordermastertotallab.TabIndex = 2;
            ordermastertotallab.Text = "訂單總金額";
            // 
            // Tab_OrderDetail
            // 
            Tab_OrderDetail.BackColor = Color.DarkGray;
            Tab_OrderDetail.Controls.Add(groupBox4);
            Tab_OrderDetail.Location = new Point(4, 35);
            Tab_OrderDetail.Name = "Tab_OrderDetail";
            Tab_OrderDetail.Padding = new Padding(3);
            Tab_OrderDetail.Size = new Size(669, 893);
            Tab_OrderDetail.TabIndex = 4;
            Tab_OrderDetail.Text = "訂單明細(管理員)";
            // 
            // groupBox4
            // 
            groupBox4.BackColor = Color.FromArgb(224, 224, 224);
            groupBox4.Controls.Add(panel13);
            groupBox4.Location = new Point(6, 6);
            groupBox4.Margin = new Padding(5);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new Padding(5);
            groupBox4.Size = new Size(651, 871);
            groupBox4.TabIndex = 0;
            groupBox4.TabStop = false;
            groupBox4.Text = "訂單明細檔管理";
            // 
            // panel13
            // 
            panel13.Controls.Add(panel18);
            panel13.Controls.Add(orderdetaildgv);
            panel13.Controls.Add(panel15);
            panel13.Controls.Add(panel14);
            panel13.Location = new Point(9, 29);
            panel13.Margin = new Padding(5);
            panel13.Name = "panel13";
            panel13.Size = new Size(611, 833);
            panel13.TabIndex = 0;
            // 
            // panel18
            // 
            panel18.BackColor = Color.FromArgb(128, 255, 255);
            panel18.Controls.Add(orderdetailcustIDsearchtxt);
            panel18.Controls.Add(orderdetailcustIDsearchlab);
            panel18.Location = new Point(33, 297);
            panel18.Name = "panel18";
            panel18.Size = new Size(572, 69);
            panel18.TabIndex = 4;
            // 
            // orderdetailcustIDsearchtxt
            // 
            orderdetailcustIDsearchtxt.Location = new Point(165, 18);
            orderdetailcustIDsearchtxt.Margin = new Padding(5);
            orderdetailcustIDsearchtxt.Name = "orderdetailcustIDsearchtxt";
            orderdetailcustIDsearchtxt.Size = new Size(364, 30);
            orderdetailcustIDsearchtxt.TabIndex = 3;
            orderdetailcustIDsearchtxt.TextChanged += orderdetailcustIDsearchtxt_TextChanged;
            // 
            // orderdetailcustIDsearchlab
            // 
            orderdetailcustIDsearchlab.AutoSize = true;
            orderdetailcustIDsearchlab.Location = new Point(20, 21);
            orderdetailcustIDsearchlab.Margin = new Padding(5, 0, 5, 0);
            orderdetailcustIDsearchlab.Name = "orderdetailcustIDsearchlab";
            orderdetailcustIDsearchlab.Size = new Size(118, 23);
            orderdetailcustIDsearchlab.TabIndex = 2;
            orderdetailcustIDsearchlab.Text = "訂單編號查詢";
            // 
            // orderdetaildgv
            // 
            orderdetaildgv.BackgroundColor = Color.White;
            orderdetaildgv.BorderStyle = BorderStyle.None;
            orderdetaildgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            orderdetaildgv.Location = new Point(33, 368);
            orderdetaildgv.Margin = new Padding(5);
            orderdetaildgv.Name = "orderdetaildgv";
            orderdetaildgv.RowHeadersWidth = 62;
            orderdetaildgv.Size = new Size(572, 431);
            orderdetaildgv.TabIndex = 1;
            orderdetaildgv.CurrentCellChanged += orderdetaildgv_CurrentCellChanged;
            // 
            // panel15
            // 
            panel15.BackColor = Color.FromArgb(255, 255, 192);
            panel15.Controls.Add(orderdetailsortbtn);
            panel15.Controls.Add(orderdetaildeletebtn);
            panel15.Controls.Add(orderdetailupdatebtn);
            panel15.Controls.Add(orderdetailaddbtn);
            panel15.Location = new Point(438, 9);
            panel15.Margin = new Padding(5);
            panel15.Name = "panel15";
            panel15.Size = new Size(167, 288);
            panel15.TabIndex = 1;
            // 
            // orderdetailsortbtn
            // 
            orderdetailsortbtn.Location = new Point(25, 192);
            orderdetailsortbtn.Margin = new Padding(5);
            orderdetailsortbtn.Name = "orderdetailsortbtn";
            orderdetailsortbtn.Size = new Size(118, 35);
            orderdetailsortbtn.TabIndex = 3;
            orderdetailsortbtn.Text = "排序";
            orderdetailsortbtn.UseVisualStyleBackColor = true;
            orderdetailsortbtn.Click += orderdetailsortbtn_Click;
            // 
            // orderdetaildeletebtn
            // 
            orderdetaildeletebtn.Location = new Point(25, 136);
            orderdetaildeletebtn.Margin = new Padding(5);
            orderdetaildeletebtn.Name = "orderdetaildeletebtn";
            orderdetaildeletebtn.Size = new Size(118, 35);
            orderdetaildeletebtn.TabIndex = 2;
            orderdetaildeletebtn.Text = "刪除";
            orderdetaildeletebtn.UseVisualStyleBackColor = true;
            orderdetaildeletebtn.Click += orderdetaildeletebtn_Click;
            // 
            // orderdetailupdatebtn
            // 
            orderdetailupdatebtn.Location = new Point(25, 80);
            orderdetailupdatebtn.Margin = new Padding(5);
            orderdetailupdatebtn.Name = "orderdetailupdatebtn";
            orderdetailupdatebtn.Size = new Size(118, 35);
            orderdetailupdatebtn.TabIndex = 1;
            orderdetailupdatebtn.Text = "更新";
            orderdetailupdatebtn.UseVisualStyleBackColor = true;
            orderdetailupdatebtn.Click += orderdetailupdatebtn_Click;
            // 
            // orderdetailaddbtn
            // 
            orderdetailaddbtn.Location = new Point(25, 23);
            orderdetailaddbtn.Margin = new Padding(5);
            orderdetailaddbtn.Name = "orderdetailaddbtn";
            orderdetailaddbtn.Size = new Size(118, 35);
            orderdetailaddbtn.TabIndex = 0;
            orderdetailaddbtn.Text = "新增";
            orderdetailaddbtn.UseVisualStyleBackColor = true;
            orderdetailaddbtn.Click += orderdetailaddbtn_Click;
            // 
            // panel14
            // 
            panel14.BackColor = Color.FromArgb(128, 255, 128);
            panel14.Controls.Add(numberIDtxt);
            panel14.Controls.Add(numberIDlab);
            panel14.Controls.Add(orderdetatilsubTotaltxt);
            panel14.Controls.Add(orderdetatilsubTotallab);
            panel14.Controls.Add(orderdetailPricetxt);
            panel14.Controls.Add(orderdetailPricelab);
            panel14.Controls.Add(orderdetailquantitytxt);
            panel14.Controls.Add(orderdetailquantitylab);
            panel14.Controls.Add(orderdetailProductIdtxt);
            panel14.Controls.Add(orderdetailProductIdlab);
            panel14.Controls.Add(orderdetailIDtxt);
            panel14.Controls.Add(orderdetailIDlab);
            panel14.Location = new Point(33, 8);
            panel14.Margin = new Padding(5);
            panel14.Name = "panel14";
            panel14.Size = new Size(407, 290);
            panel14.TabIndex = 0;
            // 
            // numberIDtxt
            // 
            numberIDtxt.Location = new Point(134, 15);
            numberIDtxt.Name = "numberIDtxt";
            numberIDtxt.Size = new Size(155, 30);
            numberIDtxt.TabIndex = 11;
            // 
            // numberIDlab
            // 
            numberIDlab.AutoSize = true;
            numberIDlab.Location = new Point(20, 18);
            numberIDlab.Name = "numberIDlab";
            numberIDlab.Size = new Size(82, 23);
            numberIDlab.TabIndex = 10;
            numberIDlab.Text = "明細序號";
            // 
            // orderdetatilsubTotaltxt
            // 
            orderdetatilsubTotaltxt.Location = new Point(134, 241);
            orderdetatilsubTotaltxt.Margin = new Padding(5);
            orderdetatilsubTotaltxt.Name = "orderdetatilsubTotaltxt";
            orderdetatilsubTotaltxt.Size = new Size(155, 30);
            orderdetatilsubTotaltxt.TabIndex = 9;
            // 
            // orderdetatilsubTotallab
            // 
            orderdetatilsubTotallab.AutoSize = true;
            orderdetatilsubTotallab.Location = new Point(20, 244);
            orderdetatilsubTotallab.Margin = new Padding(5, 0, 5, 0);
            orderdetatilsubTotallab.Name = "orderdetatilsubTotallab";
            orderdetatilsubTotallab.Size = new Size(82, 23);
            orderdetatilsubTotallab.TabIndex = 8;
            orderdetatilsubTotallab.Text = "小結總和";
            // 
            // orderdetailPricetxt
            // 
            orderdetailPricetxt.Location = new Point(134, 150);
            orderdetailPricetxt.Margin = new Padding(5);
            orderdetailPricetxt.Name = "orderdetailPricetxt";
            orderdetailPricetxt.Size = new Size(155, 30);
            orderdetailPricetxt.TabIndex = 7;
            // 
            // orderdetailPricelab
            // 
            orderdetailPricelab.AutoSize = true;
            orderdetailPricelab.Location = new Point(20, 153);
            orderdetailPricelab.Margin = new Padding(5, 0, 5, 0);
            orderdetailPricelab.Name = "orderdetailPricelab";
            orderdetailPricelab.Size = new Size(82, 23);
            orderdetailPricelab.TabIndex = 6;
            orderdetailPricelab.Tag = "";
            orderdetailPricelab.Text = "當時單價";
            // 
            // orderdetailquantitytxt
            // 
            orderdetailquantitytxt.Location = new Point(134, 199);
            orderdetailquantitytxt.Margin = new Padding(5);
            orderdetailquantitytxt.Name = "orderdetailquantitytxt";
            orderdetailquantitytxt.Size = new Size(155, 30);
            orderdetailquantitytxt.TabIndex = 5;
            // 
            // orderdetailquantitylab
            // 
            orderdetailquantitylab.AutoSize = true;
            orderdetailquantitylab.Location = new Point(20, 202);
            orderdetailquantitylab.Margin = new Padding(5, 0, 5, 0);
            orderdetailquantitylab.Name = "orderdetailquantitylab";
            orderdetailquantitylab.Size = new Size(46, 23);
            orderdetailquantitylab.TabIndex = 4;
            orderdetailquantitylab.Text = "數量";
            // 
            // orderdetailProductIdtxt
            // 
            orderdetailProductIdtxt.Location = new Point(134, 100);
            orderdetailProductIdtxt.Margin = new Padding(5);
            orderdetailProductIdtxt.Name = "orderdetailProductIdtxt";
            orderdetailProductIdtxt.Size = new Size(155, 30);
            orderdetailProductIdtxt.TabIndex = 3;
            // 
            // orderdetailProductIdlab
            // 
            orderdetailProductIdlab.AutoSize = true;
            orderdetailProductIdlab.Location = new Point(20, 103);
            orderdetailProductIdlab.Margin = new Padding(5, 0, 5, 0);
            orderdetailProductIdlab.Name = "orderdetailProductIdlab";
            orderdetailProductIdlab.Size = new Size(82, 23);
            orderdetailProductIdlab.TabIndex = 2;
            orderdetailProductIdlab.Text = "產品編號";
            // 
            // orderdetailIDtxt
            // 
            orderdetailIDtxt.Location = new Point(134, 60);
            orderdetailIDtxt.Margin = new Padding(5);
            orderdetailIDtxt.Name = "orderdetailIDtxt";
            orderdetailIDtxt.Size = new Size(155, 30);
            orderdetailIDtxt.TabIndex = 1;
            // 
            // orderdetailIDlab
            // 
            orderdetailIDlab.AutoSize = true;
            orderdetailIDlab.Location = new Point(20, 60);
            orderdetailIDlab.Margin = new Padding(5, 0, 5, 0);
            orderdetailIDlab.Name = "orderdetailIDlab";
            orderdetailIDlab.Size = new Size(82, 23);
            orderdetailIDlab.TabIndex = 0;
            orderdetailIDlab.Text = "訂單編號";
            // 
            // showVIPmessiagelab
            // 
            showVIPmessiagelab.AutoSize = true;
            showVIPmessiagelab.Font = new Font("Microsoft JhengHei UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 136);
            showVIPmessiagelab.ForeColor = Color.Red;
            showVIPmessiagelab.Location = new Point(732, 51);
            showVIPmessiagelab.Name = "showVIPmessiagelab";
            showVIPmessiagelab.Size = new Size(242, 41);
            showVIPmessiagelab.TabIndex = 9;
            showVIPmessiagelab.Text = "目前身分非會員";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1537, 1050);
            Controls.Add(showVIPmessiagelab);
            Controls.Add(tabControl1);
            Controls.Add(grpCart);
            Margin = new Padding(5);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "活力早晨早餐店 - 結帳系統";
            Load += MainForm_Load;
            Tab_usermenu.ResumeLayout(false);
            grpMenu.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)reviewimg).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvMenu).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCart).EndInit();
            ((System.ComponentModel.ISupportInitialize)numQty).EndInit();
            grpCart.ResumeLayout(false);
            grpCart.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            tabControl1.ResumeLayout(false);
            Tab_adminmenu.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)adminmenupicture).EndInit();
            ((System.ComponentModel.ISupportInitialize)adminmenudgv).EndInit();
            Tab_MemberVIP.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)custdgv).EndInit();
            panel16.ResumeLayout(false);
            panel16.PerformLayout();
            panel9.ResumeLayout(false);
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            Tab_Order.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            panel10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ordermasterdgv).EndInit();
            panel12.ResumeLayout(false);
            panel17.ResumeLayout(false);
            panel17.PerformLayout();
            panel11.ResumeLayout(false);
            panel11.PerformLayout();
            Tab_OrderDetail.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            panel13.ResumeLayout(false);
            panel18.ResumeLayout(false);
            panel18.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)orderdetaildgv).EndInit();
            panel15.ResumeLayout(false);
            panel14.ResumeLayout(false);
            panel14.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }
        private Panel panel2;
        private Panel panel1;
        private Panel panel3;
        private TabControl tabControl1;
        private TabPage Tab_usermenu;
        private TabPage Tab_adminmenu;
        private GroupBox groupBox1;
        private DataGridView adminmenudgv;
        private Panel panel4;
        private TextBox ProductIdtxt;
        private TextBox menuPricetxt;
        private TextBox menuNametxt;
        private Label ProductIdlab;
        private Label menuPricelab;
        private Label menuNamelab;
        private Button menusortbtn;
        private Button menudeletebtn;
        private Button menuupdatebtn;
        private Button menuaddbtn;
        private Label label5;
        private TextBox searchtxt;
        private Label searchlab;
        private Button btnsort;
        private PictureBox reviewimg;
        private TabPage Tab_MemberVIP;
        private TabPage Tab_Order;
        private TabPage Tab_OrderDetail;
        private PictureBox adminmenupicture;
        private Panel panel6;
        private Panel panel5;
        private Label txtlab;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private Panel panel7;
        private Panel panel9;
        private Panel panel8;
        private ComboBox paycombo;
        private Label regionlab;
        private Label custnamelab;
        private DataGridView custdgv;
        private TextBox custsearchtxt;
        private Label custsearchlab;
        private Button custsortbtn;
        private Button custdeletebtn;
        private Button custupdatebtn;
        private Button custaddbtn;
        private ComboBox regioncombo;
        private TextBox custnametxt;
        private Label paylab;
        private DataGridView ordermasterdgv;
        private Panel panel10;
        private Panel panel11;
        private TextBox ordermasterdatetxt;
        private Label ordermastercustIDlab;
        private Label ordermasterdatelab;
        private TextBox ordermastercustIDtxt;
        private TextBox ordermastertotaltxt;
        private Label ordermastertotallab;
        private TextBox ordermastercustIDsearchtxt;
        private Label ordermastercustIDsearchlab;
        private Panel panel12;
        private Button ordermastersortbtn;
        private Button ordermasterdeletebtn;
        private DataGridView orderdetaildgv;
        private Panel panel13;
        private TextBox orderdetailcustIDsearchtxt;
        private Label orderdetailcustIDsearchlab;
        private Panel panel15;
        private Panel panel14;
        private Label orderdetailIDlab;
        private Button orderdetailsortbtn;
        private Button orderdetaildeletebtn;
        private Button orderdetailupdatebtn;
        private Button orderdetailaddbtn;
        private TextBox orderdetatilsubTotaltxt;
        private Label orderdetatilsubTotallab;
        private TextBox orderdetailPricetxt;
        private Label orderdetailPricelab;
        private TextBox orderdetailquantitytxt;
        private Label orderdetailquantitylab;
        private TextBox orderdetailProductIdtxt;
        private Label orderdetailProductIdlab;
        private TextBox orderdetailIDtxt;
        private Panel panel16;
        private Panel panel17;
        private Panel panel18;
        private TextBox ordermasterIDtxt;
        private Label ordermasterIDlab;
        private Button ordermasterupdatebtn;
        private Button ordermasteraddbtn;
        private TextBox totalquantitytxt;
        private Label totalquantitylab;
        private Label custIDlab;
        private TextBox custIDtxt;
        private TextBox numberIDtxt;
        private Label numberIDlab;
        private Button VIPcheckbtn;
        private TextBox VIPIDtxt;
        private Label VIPlab;
        private Label showVIPmessiagelab;
    }
}
