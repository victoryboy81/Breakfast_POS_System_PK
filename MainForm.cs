using Microsoft.Data.SqlClient;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

using Image = System.Drawing.Image;

namespace BreakfastCart
{
    public partial class MainForm : Form
    {
        SqlDataAdapter adapter;
        private int custIDtemp = 0;
        private int ordermastercount;
        private int orderdetailcount;
        private SqlConnection cnn;
        private SqlCommand cmd;
        private string connectionString;
        private DataTable dt = new DataTable();
        private DataSet ds = new DataSet();
        private DataTable custdt = new DataTable();
        private DataTable ordermasterdt = new DataTable();
        private DataTable orderdetaildt = new DataTable();
        private List<Customer> custitems;
        private List<SalesMaster> ordermasteritems;
        private List<SalesDetail> orderdetailitems;
        private BindingSource custbs;
        private BindingSource ordermasterbs;
        private BindingSource orderdetailbs;
        private BindingList<MenuItem> allMenuItems;
        private List<CartItem> cartItems;
        private Order currentOrder;
        private BindingSource bs;
        private BindingSource adminbs;
        private BindingSource adminmenubs;
        private List<MenuItem> items;
        private int allMenuItemssortflag = 0;
        private int custItemssortflag = 0;
        private int ordermasterItemssortflag = 0;
        private int orderdetailItemssortflag = 0;
        private int cartItemssortflag = 0;

        public MainForm()
        {
            InitializeComponent();
            custitems = new List<Customer>();
            ordermasteritems = new List<SalesMaster>();
            orderdetailitems = new List<SalesDetail>();
            currentOrder = new Order();
            currentOrder.DiscountRate = 1.0m;
            allMenuItems = new BindingList<MenuItem>();
            currentOrder.Items = new List<CartItem>();
            cartItems = new List<CartItem>(currentOrder.Items);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            regioncombo.Items.Add("北");
            regioncombo.Items.Add("中");
            regioncombo.Items.Add("南");
            regioncombo.Items.Add("東");
            paycombo.Items.Add("現金");
            paycombo.Items.Add("LINE Pay");
            paycombo.Items.Add("信用卡");


            string fullPath;
            // 從資料庫抓取早餐品項資訊進行初始化
            string sql = @"SELECT ProductID 產品序號,ProductName 品項,UnitPrice 單價,ImagePath 圖片路徑 FROM Products ;";
            //connectionString = "Data Source=.\\sqlexpress;Initial Catalog=sales_db;Integrated Security=True; TrustServerCertificate=True; ";//使用Microsoft.Data.SqlClient模組時，職訓局MSSQL環境
            connectionString = "Data Source=.\\SQL2022;Initial Catalog=sales_db;Integrated Security=True; TrustServerCertificate=True;"; //使用Microsoft.Data.SqlClient模組，自己電腦MSSQL環境
            using (cnn = new SqlConnection(connectionString))
            {
                using (cmd = new SqlCommand(sql, cnn))
                {
                    adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(ds, "Products");
                    dt = ds.Tables["Products"];
                    items = dt.AsEnumerable().Select(row => new MenuItem
                    {
                        Id = row.Field<int>("產品序號"),
                        Name = row.Field<string>("品項"),
                        Price = row.Field<decimal>("單價"),
                        ImagePath = row.Field<string>("圖片路徑")

                    }).ToList();

                    // 遍歷每一列，將路徑轉為 Image 物件塞入 Cell
                    foreach (var item in items)
                    {
                        // 假設路徑存在 "ImagePath" 欄位中

                        fullPath = $@"Images/{item.Name}(32X32).png";
                        if (!string.IsNullOrEmpty(fullPath) && System.IO.File.Exists(fullPath))
                        {
                            // 將圖片物件放入剛建立的圖片欄位中
                            //MessageBox.Show($"{path}");
                            item.ProductPic = Image.FromFile(fullPath);
                        }
                        else
                        {
                            // 若無圖片，可給予預設圖或 null
                            item.ProductPic = null;
                        }
                    }








                }

            }

            //讀取資料庫訂單主檔筆數
            //cmd.Parameters.Clear();
            sql = @"SELECT COUNT(*) FROM SalesMaster ;";
            using (cnn = new SqlConnection(connectionString))
            {

                using (cmd = new SqlCommand(sql, cnn))
                {

                    try
                    {
                        //MessageBox.Show($"{ordermastercount}");
                        cnn.Open();
                        ordermastercount = (int)(cmd.ExecuteScalar());
                        //MessageBox.Show($"{ordermastercount}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("發生錯誤(ordermastercount): " + ex.Message);
                    }
                }
            }
            //讀取資料庫訂單主檔筆數
            //cmd.Parameters.Clear();
            sql = @"SELECT COUNT(*) FROM SalesDetail ;";
            using (cnn = new SqlConnection(connectionString))
            {

                using (cmd = new SqlCommand(sql, cnn))
                {

                    try
                    {
                        //MessageBox.Show($"{ordermastercount}");
                        cnn.Open();
                        orderdetailcount = (int)(cmd.ExecuteScalar());
                        //MessageBox.Show($"{orderdetailcount}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("發生錯誤(orderdetailcount): " + ex.Message);
                    }
                }
            }

            // 初始化假資料{
            /*
            items = new List<MenuItem>
            {
                new MenuItem { Id = 1, Name = "火腿蛋吐司", Price = 35, Category = "吐司" },
                new MenuItem { Id = 2, Name = "鮪魚蛋餅", Price = 40, Category = "蛋餅" },
                new MenuItem { Id = 3, Name = "蘿蔔糕", Price = 30, Category = "點心" },
                new MenuItem { Id = 4, Name = "大冰奶", Price = 25, Category = "飲料" },
                new MenuItem { Id = 5, Name = "卡拉雞腿堡", Price = 65, Category = "漢堡" },
                new MenuItem { Id = 6, Name = "鐵板麵(黑胡椒)", Price = 50, Category = "麵食" },
                new MenuItem { Id = 7, Name = "豆漿紅茶", Price = 20, Category = "飲料" }
            };
            */
            allMenuItems = new BindingList<MenuItem>(items);
            //items[0].DisplayName= $"{items[0].Name} (${items[0].Price:N0})";
            //foreach (var item in items) item.DisplayName = $"{item.Name} (${item.Price:N0})";
            UpdateMenuItem(items);

            adminbs = new BindingSource();
            adminbs.DataSource = allMenuItems;


            //}




            //dgvMenu.DataSource = allMenuItems;
            dgvMenu.DataSource = adminbs;
            adminbs.ResetBindings(false);
            if (dgvMenu.Columns.Contains("ImagePath"))
            {
                dgvMenu.Columns["ImagePath"].Visible = false; // 隱藏欄位，但資料還在
            }
            if (dgvMenu.Columns.Contains("Category"))
            {
                dgvMenu.Columns["Category"].Visible = false; // 隱藏欄位，但資料還在
            }
            if (dgvMenu.Columns.Contains("DisplayName"))
            {
                dgvMenu.Columns["DisplayName"].Visible = false; // 隱藏欄位，但資料還在
            }
            if (dgvMenu.Columns.Contains("Name"))
            {
                dgvMenu.Columns["Name"].HeaderText = "品項"; // 隱藏欄位，但資料還在
            }
            if (dgvMenu.Columns.Contains("Id"))
            {
                dgvMenu.Columns["Id"].HeaderText = "產品序號"; // 隱藏欄位，但資料還在
            }
            if (dgvMenu.Columns.Contains("Price"))
            {
                dgvMenu.Columns["Price"].HeaderText = "單價"; // 隱藏欄位，但資料還在
            }
            if (dgvMenu.Columns.Contains("ProductPic"))
            {
                dgvMenu.Columns["ProductPic"].HeaderText = "產品預覽"; // 隱藏欄位，但資料還在
            }
            /*
            // 建立一個圖片欄位並加入
            if (!dgvMenu.Columns.Contains("ProductPic"))
            {
                DataGridViewImageColumn imgCol = new DataGridViewImageColumn();
                imgCol.Name = "ProductPic";
                imgCol.HeaderText = "產品預覽";
                imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
                dgvMenu.Columns.Add(imgCol);
            }
            // 遍歷每一列，將路徑轉為 Image 物件塞入 Cell
            foreach (DataGridViewRow row in dgvMenu.Rows)
            {
                // 假設路徑存在 "ImagePath" 欄位中
                string path = row.Cells["ImagePath"].Value?.ToString();
                path = $@"Images/{row.Cells["Name"].Value?.ToString()}(32X32).png";
                if (!string.IsNullOrEmpty(path) && System.IO.File.Exists(path))
                {
                    // 將圖片物件放入剛建立的圖片欄位中
                    //MessageBox.Show($"{path}");
                    row.Cells["ProductPic"].Value = Image.FromFile(path);
                }
                else
                {
                    // 若無圖片，可給予預設圖或 null
                    row.Cells["ProductPic"].Value = null;
                }
            }

            // 隱藏原始的路徑文字欄位
            dgvMenu.Columns["ImagePath"].Visible = false;*/
            bs = new BindingSource();
            bs.DataSource = cartItems;
            dgvCart.DataSource = bs;
            if (dgvCart.Columns.Contains("Item"))
            {
                dgvCart.Columns["Item"].Visible = false; // 隱藏欄位，但資料還在
            }
            if (dgvCart.Columns.Contains("CartItemId"))
            {
                dgvCart.Columns["CartItemId"].Visible = false; // 隱藏欄位，但資料還在
            }
            if (dgvCart.Columns.Contains("Id"))
            {
                dgvCart.Columns["Id"].HeaderText = "產品序號"; // 隱藏欄位，但資料還在
            }
            if (dgvCart.Columns.Contains("ItemName"))
            {
                dgvCart.Columns["ItemName"].HeaderText = "品項"; // 隱藏欄位，但資料還在
            }
            if (dgvCart.Columns.Contains("Price"))
            {
                dgvCart.Columns["Price"].HeaderText = "單價"; // 隱藏欄位，但資料還在
            }
            if (dgvCart.Columns.Contains("Quantity"))
            {
                dgvCart.Columns["Quantity"].HeaderText = "數量"; // 隱藏欄位，但資料還在
            }
            if (dgvCart.Columns.Contains("SubTotal"))
            {
                dgvCart.Columns["SubTotal"].HeaderText = "小計總和"; // 隱藏欄位，但資料還在
            }



            //adminmenubs= new BindingSource();
            //adminmenubs.DataSource = allMenuItems;
            adminmenudgv.DataSource = adminbs;
            if (adminmenudgv.Columns.Contains("ImagePath"))
            {
                adminmenudgv.Columns["ImagePath"].Visible = false; // 隱藏欄位，但資料還在
            }
            if (adminmenudgv.Columns.Contains("DisplayName"))
            {
                adminmenudgv.Columns["DisplayName"].Visible = false; // 隱藏欄位，但資料還在
            }
            if (adminmenudgv.Columns.Contains("Category"))
            {
                adminmenudgv.Columns["Category"].Visible = false; // 隱藏欄位，但資料還在
            }

            if (adminmenudgv.Columns.Contains("Id"))
            {
                adminmenudgv.Columns["Id"].HeaderText = "產品序號"; // 隱藏欄位，但資料還在
            }
            if (adminmenudgv.Columns.Contains("Name"))
            {
                adminmenudgv.Columns["Name"].HeaderText = "品項"; // 隱藏欄位，但資料還在
            }
            if (adminmenudgv.Columns.Contains("Price"))
            {
                adminmenudgv.Columns["Price"].HeaderText = "單價"; // 隱藏欄位，但資料還在
            }
            if (adminmenudgv.Columns.Contains("ProductPic"))
            {
                adminmenudgv.Columns["ProductPic"].HeaderText = "產品預覽"; // 隱藏欄位，但資料還在
            }


            custbs = new BindingSource();
            custbs.DataSource = custitems;
            custdgv.DataSource = custbs;
            if (custdgv.Columns.Contains("customerID"))
            {
                custdgv.Columns["customerID"].HeaderText = "客戶序號"; // 隱藏欄位，但資料還在
            }
            if (custdgv.Columns.Contains("CustomerName"))
            {
                custdgv.Columns["CustomerName"].HeaderText = "客戶名稱"; // 隱藏欄位，但資料還在
            }
            if (custdgv.Columns.Contains("Region"))
            {
                custdgv.Columns["Region"].HeaderText = "地區"; // 隱藏欄位，但資料還在
            }
            if (custdgv.Columns.Contains("PaymentMethods"))
            {
                custdgv.Columns["PaymentMethods"].HeaderText = "付款方式"; // 隱藏欄位，但資料還在
            }

            ordermasterbs = new BindingSource();
            ordermasterbs.DataSource = ordermasteritems;
            ordermasterdgv.DataSource = ordermasterbs;
            if (ordermasterdgv.Columns.Contains("SaleID"))
            {
                ordermasterdgv.Columns["SaleID"].HeaderText = "訂單序號"; // 隱藏欄位，但資料還在
            }
            if (ordermasterdgv.Columns.Contains("CustomerID"))
            {
                ordermasterdgv.Columns["CustomerID"].HeaderText = "客戶序號"; // 隱藏欄位，但資料還在
            }
            if (ordermasterdgv.Columns.Contains("SaleDate"))
            {
                ordermasterdgv.Columns["SaleDate"].HeaderText = "下單日期"; // 隱藏欄位，但資料還在
            }
            if (ordermasterdgv.Columns.Contains("TotalAmount"))
            {
                ordermasterdgv.Columns["TotalAmount"].HeaderText = "訂單總金額"; // 隱藏欄位，但資料還在
            }
            if (ordermasterdgv.Columns.Contains("TotalQuantity"))
            {
                ordermasterdgv.Columns["TotalQuantity"].HeaderText = "總數量"; // 隱藏欄位，但資料還在
            }

            orderdetailbs = new BindingSource();
            orderdetailbs.DataSource = orderdetailitems;
            orderdetaildgv.DataSource = orderdetailbs;
            if (orderdetaildgv.Columns.Contains("DetailID"))
            {
                orderdetaildgv.Columns["DetailID"].HeaderText = "訂單明細序號"; // 隱藏欄位，但資料還在
            }
            if (orderdetaildgv.Columns.Contains("SaleID"))
            {
                orderdetaildgv.Columns["SaleID"].HeaderText = "訂單序號"; // 隱藏欄位，但資料還在
            }
            if (orderdetaildgv.Columns.Contains("CustomerID"))
            {
                orderdetaildgv.Columns["CustomerID"].HeaderText = "客戶序號"; // 隱藏欄位，但資料還在
            }
            if (orderdetaildgv.Columns.Contains("ProductID"))
            {
                orderdetaildgv.Columns["ProductID"].HeaderText = "產品序號"; // 隱藏欄位，但資料還在
            }
            if (orderdetaildgv.Columns.Contains("Quantity"))
            {
                orderdetaildgv.Columns["Quantity"].HeaderText = "數量"; // 隱藏欄位，但資料還在
            }
            if (orderdetaildgv.Columns.Contains("UnitPrice"))
            {
                orderdetaildgv.Columns["UnitPrice"].HeaderText = "當時單價"; // 隱藏欄位，但資料還在
            }
            if (orderdetaildgv.Columns.Contains("SubTotal"))
            {
                orderdetaildgv.Columns["SubTotal"].HeaderText = "小計總金額"; // 隱藏欄位，但資料還在
            }


            // 調整 DataGridView 欄位顯示
            ConfigureGrid(orderdetaildgv);
            ConfigureGrid(ordermasterdgv);
            ConfigureGrid(custdgv);
            ConfigureGrid(adminmenudgv);
            ConfigureGrid(dgvMenu);
            ConfigureGrid(dgvCart);
            UpdateTotalDisplay();
        }

        private void ConfigureGrid(DataGridView dgv)
        {
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            var keyword = txtSearch.Text.ToLower();
            //keyword = "";
            var filtered = allMenuItems.Where(x => x.Name.ToLower().Contains(keyword)).ToList();
            //dgvMenu.DataSource = new BindingList<MenuItem>(filtered);
            //adminbs.DataSource = new BindingList<MenuItem>(filtered);
            //adminbs.ResetBindings(false);
            if (keyword != "")
            {
                adminbs.DataSource = new BindingList<MenuItem>(filtered);
                adminbs.ResetBindings(false);
            }
            else
            {
                adminbs.DataSource = allMenuItems;
                adminbs.ResetBindings(false);
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            decimal total = 0;
            MenuItem selectedItem = dgvMenu.CurrentRow?.DataBoundItem as MenuItem;
            //reviewimg.Image = Image.FromFile($@"Images/{selectedItem.Name}(h200).png");
            //if (dgvMenu.CurrentRow?.DataBoundItem is MenuItem selectedItem)
            if (dgvMenu.CurrentRow != null && dgvMenu.CurrentRow.Index >= 0)
            {
                var existing = cartItems.FirstOrDefault(x => x.Item.Id == selectedItem.Id);
                //int qty = (int)numQty.Value;
                int qty = 1;
                int identitynum = 0;
                if (existing != null)
                {
                    existing.Quantity += qty;
                }
                else
                {
                    identitynum++;
                    cartItems.Add(new CartItem
                    {
                        Item = selectedItem,
                        Quantity = qty,
                        CartItemId = Guid.NewGuid().ToString(),
                        Id = selectedItem.Id
                        /*CartItemId =(identitynum.ToString())*/
                    });
                }


                //foreach (var item in cartItems) total += item.SubTotal;
                //currentOrder.OriginalTotal = total;
                //currentOrder.FinalTotal= Math.Round(currentOrder.OriginalTotal * currentOrder.DiscountRate, 0);
                UpdateTotal();

                //dgvCart.Refresh(); // 強制重繪以更新 SubTotal
                //dgvCart.DataSource = null;
                //dgvCart.DataSource = cartItems;
                //bs.DataSource = cartItems;
                //dgvCart.DataSource = bs;
                bs.ResetBindings(false);
                UpdateTotalDisplay();
            }
        }
        private void UpdateMenuItem(List<MenuItem> items)
        {
            foreach (var item in items) item.DisplayName = $"{item.Name} (${item.Price:N0})";

        }
        private void UpdateTotal()
        {
            decimal total = 0;
            decimal quantitytotal = 0;
            List<decimal> Pricelist = new List<decimal>();
            List<string> ItemNamelist = new List<string>();

            for (int i = 0; i < cartItems.Count; i++)
            {
                //Pricelist.Add(Convert.ToDecimal(cartItems[i].Price));
                //ItemNamelist.Add(    Convert.ToString(   cartItems[i].Item.Name    )       );
                cartItems[i].ItemName = Convert.ToString(cartItems[i].Item.Name);
                cartItems[i].Price = Convert.ToDecimal(cartItems[i].Item.Price);
                cartItems[i].SubTotal = Convert.ToDecimal(cartItems[i].Item.Price) * Convert.ToDecimal(cartItems[i].Quantity);
            }
            foreach (var item in cartItems)
            {
                total += item.SubTotal;
                quantitytotal += item.Quantity;
                //Pricelist.Add(  Convert.ToDecimal( item.Price )  );
                //ItemNamelist.Add(item.Item.Name);
            }
            currentOrder.OriginalTotal = total;
            currentOrder.FinalTotal = Math.Round(currentOrder.OriginalTotal * currentOrder.DiscountRate, 0);
            currentOrder.quantityTotal = quantitytotal;
            //UpdateTotalDisplay();
        }
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            CartItem selectedCartItem = dgvCart.CurrentRow?.DataBoundItem as CartItem;
            //if (dgvCart.CurrentRow?.DataBoundItem is CartItem selectedCartItem)
            if (dgvCart.CurrentRow != null && dgvCart.CurrentRow.Index >= 0)
            {
                selectedCartItem.Quantity = Convert.ToInt32(numQty.Value);
                //dgvCart.Refresh();
                //dgvCart.DataSource = null;
                //dgvCart.DataSource = cartItems;
                cartItems[dgvCart.CurrentRow.Index].Quantity = Convert.ToInt32(numQty.Value);
                UpdateTotal();
                bs.ResetBindings(false);
                UpdateTotalDisplay();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            CartItem selectedCartItem = dgvCart.CurrentRow?.DataBoundItem as CartItem;
            //if (dgvCart.CurrentRow?.DataBoundItem is CartItem selectedCartItem)
            if (dgvCart.CurrentRow != null && dgvCart.CurrentRow.Index >= 0)
            {
                cartItems.Remove(selectedCartItem);
                bs.ResetBindings(false);
                UpdateTotal();
                UpdateTotalDisplay();
            }
        }

        /*
        private void DgvCart_SelectionChanged(object sender, EventArgs e)
        {

            if (dgvCart.CurrentRow?.DataBoundItem is CartItem selectedCartItem)
            {
                numQty.Value = selectedCartItem.Quantity;
            }
        }*/
        /*
                private void BtnPlayGame_Click(object sender, EventArgs e)
                {
                    using (var gameForm = new GameForm())
                    {
                        if (gameForm.ShowDialog() == DialogResult.OK)
                        {
                            currentOrder.DiscountRate = gameForm.DiscountRate;
                            UpdateTotalDisplay();
                        }
                    }
                }
        */
        private void UpdateTotalDisplay()
        {
            string discountText = currentOrder.DiscountRate == 1.0m ? "無" : $"{currentOrder.DiscountRate * 10:G} 折";
            //lblTotal.Text = $"原價: ${currentOrder.OriginalTotal:N0}  |  結帳: ${currentOrder.FinalTotal:N0}";
            lblTotal.Text = $"總金額(未折扣): ${currentOrder.OriginalTotal:N0}\n結帳金額: ${currentOrder.FinalTotal:N0}";
            lblDiscount.Text = $"目前折扣: {discountText}";
        }

        private void BtnCheckout_Click(object sender, EventArgs e)
        {
            if (cartItems.Count == 0)
            {
                MessageBox.Show("購物車是空的！");
                return;
            }
            //填入訂單主檔相關資訊到資料庫

            try  //使用try...catch...敘述來補捉異動資料可能發生的例外 
            {
                //填入訂單主檔相關資訊到資料庫
                //MessageBox.Show($"新增:{connectionString}");
                using (cnn = new SqlConnection(connectionString))
                {
                    string sql = "INSERT INTO SalesMaster(SaleID,CustomerID, SaleDate,TotalAmount,TotalQuantity) VALUES (@SaleID,@CustomerID, @SaleDate,@TotalAmount,@TotalQuantity)";
                    using (cmd = new SqlCommand(sql, cnn))
                    {
                        ordermastercount++;
                        cmd.CommandText = sql;
                        cmd.Parameters.Add(new SqlParameter("@SaleID", SqlDbType.Int));
                        cmd.Parameters["@SaleID"].Value = ordermastercount;
                        cmd.Parameters.Add(new SqlParameter("@CustomerID", SqlDbType.Int));
                        cmd.Parameters["@CustomerID"].Value = custIDtemp;
                        cmd.Parameters.Add(new SqlParameter("@SaleDate", SqlDbType.DateTime));
                        cmd.Parameters["@SaleDate"].Value = DateTime.Now;
                        cmd.Parameters.Add(new SqlParameter("@TotalAmount", SqlDbType.Decimal));
                        cmd.Parameters["@TotalAmount"].Value = currentOrder.FinalTotal;
                        cmd.Parameters.Add(new SqlParameter("@TotalQuantity", SqlDbType.Int));
                        cmd.Parameters["@TotalQuantity"].Value = currentOrder.quantityTotal;
                        cnn.Open();
                        cmd.ExecuteNonQuery();
                        //cnn.Close();
                    }
                }
                int i = 0;
                //填入訂單明細相關資訊到資料庫
                for (i = 0; i < cartItems.Count; i++)
                {
                    using (cnn = new SqlConnection(connectionString))
                    {
                        string sql = "INSERT INTO SalesDetail(DetailID,SaleID, ProductID,Quantity,UnitPrice,SubTotal) VALUES (@DetailID,@SaleID, @ProductID,@Quantity,@UnitPrice,@SubTotal)";
                        using (cmd = new SqlCommand(sql, cnn))
                        {

                            orderdetailcount++;
                            cmd.CommandText = sql;
                            cmd.Parameters.Add(new SqlParameter("@DetailID", SqlDbType.Int));
                            cmd.Parameters["@DetailID"].Value = orderdetailcount;
                            cmd.Parameters.Add(new SqlParameter("@SaleID", SqlDbType.Int));
                            cmd.Parameters["@SaleID"].Value = ordermastercount;
                            //MessageBox.Show($"{cartItems[0].Id}");
                            cmd.Parameters.Add(new SqlParameter("@ProductID", SqlDbType.Int));
                            cmd.Parameters["@ProductID"].Value = cartItems[i].Id;

                            cmd.Parameters.Add(new SqlParameter("@Quantity", SqlDbType.Int));
                            cmd.Parameters["@Quantity"].Value = cartItems[i].Quantity;
                            cmd.Parameters.Add(new SqlParameter("@UnitPrice", SqlDbType.Decimal));
                            cmd.Parameters["@UnitPrice"].Value = cartItems[i].Price;
                            cmd.Parameters.Add(new SqlParameter("@SubTotal", SqlDbType.Decimal));
                            cmd.Parameters["@SubTotal"].Value = cartItems[i].SubTotal;
                            cnn.Open();

                            cmd.ExecuteNonQuery();
                            //cnn.Close();
                        }

                    }
                }
                MessageBox.Show("訂單已成立了!");



            }
            catch (Exception ex)
            {
                cnn.Close();
                MessageBox.Show(ex.Message + ", 新增資料發生錯誤");
            }
            finally
            {
                cmd.Parameters.Clear();
            }
            /**/
            //
            //填入訂單明細相關資訊到資料庫
            /*
            try  //使用try...catch...敘述來補捉異動資料可能發生的例外 
            {
                //MessageBox.Show($"新增:{connectionString}");
                using (cnn = new SqlConnection(connectionString))
                {
                    string sql = "INSERT INTO SalesDetail(DetailID,SaleID, ProductID,Quantity,UnitPrice,SubTotal) VALUES (@DetailID,@SaleID, @ProductID,@Quantity,@UnitPrice,@SubTotal)";
                    using (cmd = new SqlCommand(sql, cnn))
                    {
                        
                        orderdetailcount++;
                        cmd.CommandText = sql;
                        cmd.Parameters.Add(new SqlParameter("@DetailID", SqlDbType.Int));
                        cmd.Parameters["@DetailID"].Value = orderdetailcount;
                        cmd.Parameters.Add(new SqlParameter("@SaleID", SqlDbType.Int));
                        cmd.Parameters["@SaleID"].Value = ordermastercount;
                        //MessageBox.Show($"{cartItems[0].Id}");
                        cmd.Parameters.Add(new SqlParameter("@ProductID", SqlDbType.Int));
                        cmd.Parameters["@ProductID"].Value = cartItems[0].Id;
                        
                        cmd.Parameters.Add(new SqlParameter("@Quantity", SqlDbType.Int));
                        cmd.Parameters["@Quantity"].Value = cartItems[0].Quantity;
                        cmd.Parameters.Add(new SqlParameter("@UnitPrice", SqlDbType.Decimal));
                        cmd.Parameters["@UnitPrice"].Value = cartItems[0].Price;
                        cmd.Parameters.Add(new SqlParameter("@SubTotal", SqlDbType.Decimal));
                        cmd.Parameters["@SubTotal"].Value = cartItems[0].SubTotal;
                        cnn.Open();
                        
                        cmd.ExecuteNonQuery();
                        //cnn.Close();
                    }
                }

                MessageBox.Show("新增資料成功");
                


            }
            catch (Exception ex)
            {
                cnn.Close();
                MessageBox.Show(ex.Message + ", 2新增資料發生錯誤");
            }
            finally
            {
                cmd.Parameters.Clear();
            }
            */
            //

            printPreviewDialog.Document = printDocument;
            printPreviewDialog.ShowDialog();
        }

        // 列印邏輯
        private void PrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //currentOrder.DiscountRate == 1.0m ? "無" : $"{currentOrder.DiscountRate * 10:G} 折"
            decimal discount = 0;
            discount = currentOrder.DiscountRate == 1.0m ? 10.0m : currentOrder.DiscountRate * 10;
            Graphics? g = e.Graphics;
            if (g == null) return;

            Font fontTitle = new Font("Microsoft JhengHei", 18, FontStyle.Bold);
            Font fontHeader = new Font("Microsoft JhengHei", 12, FontStyle.Bold);
            Font fontItem = new Font("Microsoft JhengHei", 12);
            Brush brush = Brushes.Black;

            int y = 50;
            int offset = 30;

            // 標題
            g.DrawString("訂單明細", fontTitle, brush, 200, y);
            y += 50;
            g.DrawString("訂單序號", fontItem, brush, 50, y);
            g.DrawString($"{ordermastercount}", fontItem, brush, 130, y);
            y += 50;
            g.DrawString("----------------------------------------------------------------", fontItem, brush, 50, y);
            y += 20;

            // 表頭
            g.DrawString("品項", fontHeader, brush, 50, y);
            g.DrawString("單價", fontHeader, brush, 250, y);
            g.DrawString("數量", fontHeader, brush, 350, y);
            g.DrawString("小計", fontHeader, brush, 450, y);
            y += offset;

            // 內容
            foreach (var item in cartItems)
            {
                g.DrawString(item.ItemName, fontItem, brush, 50, y);
                g.DrawString($"${item.Price}", fontItem, brush, 250, y);
                g.DrawString(item.Quantity.ToString(), fontItem, brush, 350, y);
                g.DrawString($"${item.SubTotal}", fontItem, brush, 450, y);
                y += offset;
            }

            g.DrawString("----------------------------------------------------------------", fontItem, brush, 50, y);
            y += offset;
            //總數量
            g.DrawString($"總數量:  {currentOrder.quantityTotal:N0}", fontItem, brush, 350, y);
            y += offset;
            // 總結
            g.DrawString($"總金額(未折扣): ${currentOrder.OriginalTotal:N0}", fontItem, brush, 350, y);
            y += offset;
            //g.DrawString($"折扣: {(currentOrder.DiscountRate * 10):G} 折", fontItem, brush, 350, y);
            if (discount == 10.0m)
            {
                g.DrawString($"折扣: 無 ", fontItem, brush, 350, y);
            }
            else
            {
                g.DrawString($"折扣: {discount} 折", fontItem, brush, 350, y);
            }


            y += offset;
            g.DrawString($"應付金額: ${currentOrder.FinalTotal:N0}", fontHeader, brush, 350, y);
        }

        private void menuaddbtn_Click(object sender, EventArgs e)
        {


            try  //使用try...catch...敘述來補捉異動資料可能發生的例外 
            {
                //MessageBox.Show($"新增:{connectionString}");
                using (cnn = new SqlConnection(connectionString))
                {
                    string sql = "INSERT INTO Products(ProductID, ProductName, UnitPrice) VALUES (@ProductID, @ProductName, @UnitPrice )";
                    using (cmd = new SqlCommand(sql, cnn))
                    {

                        cmd.CommandText = sql;

                        cmd.Parameters.Add(new SqlParameter("@ProductID", SqlDbType.Int));
                        cmd.Parameters["@ProductID"].Value = int.Parse(ProductIdtxt.Text.Trim());
                        cmd.Parameters.Add(new SqlParameter("@ProductName", SqlDbType.NVarChar));
                        cmd.Parameters["@ProductName"].Value = menuNametxt.Text.Trim();
                        cmd.Parameters.Add(new SqlParameter("@UnitPrice", SqlDbType.Decimal));
                        cmd.Parameters["@UnitPrice"].Value = Decimal.Parse(menuPricetxt.Text.Trim());
                        cnn.Open();
                        cmd.ExecuteNonQuery();
                        //cnn.Close();
                    }
                }


                MessageBox.Show("新增資料成功");


                allMenuItems.Add(new MenuItem { Name = menuNametxt.Text, Price = Convert.ToDecimal(menuPricetxt.Text), Id = Convert.ToInt32(ProductIdtxt.Text) });

                string fullPath;
                // 遍歷每一列，將路徑轉為 Image 物件塞入 Cell
                int index;
                index = int.Parse(ProductIdtxt.Text) - 1;
                // 假設路徑存在 "ImagePath" 欄位中

                fullPath = $@"Images/{allMenuItems[index].Name}(32X32).png";
                if (!string.IsNullOrEmpty(fullPath) && System.IO.File.Exists(fullPath))
                {
                    // 將圖片物件放入剛建立的圖片欄位中
                    //MessageBox.Show($"{path}");
                    allMenuItems[index].ProductPic = Image.FromFile(fullPath);
                }
                else
                {
                    // 若無圖片，可給予預設圖或 null
                    allMenuItems[index].ProductPic = null;
                }


                adminbs.ResetBindings(false);
                bs.ResetBindings(false);
                //MessageBox.Show($"{ Convert.ToInt32(ProductIdtxt.Text)}");

            }
            catch (Exception ex)
            {
                cnn.Close();
                MessageBox.Show(ex.Message + ", 新增資料發生錯誤");
            }
            finally
            {
                cmd.Parameters.Clear();
            }


            /*
                        allMenuItems.Add(new MenuItem { Name = menuNametxt.Text, Price = Convert.ToDecimal(menuPricetxt.Text), Id = Convert.ToInt32(ProductIdtxt.Text) });
                        adminbs.ResetBindings(false);
                        bs.ResetBindings(false);
                        //MessageBox.Show($"{ Convert.ToInt32(ProductIdtxt.Text)}");


                         */
        }

        private void menuupdatebtn_Click(object sender, EventArgs e)
        {


            int rowsAffected;
            try  //使用try...catch...敘述來補捉異動資料可能發生的例外 
            {
                //MessageBox.Show($"更新:{connectionString}");
                using (cnn = new SqlConnection(connectionString))
                {
                    string sql = "UPDATE Products SET  ProductName =@ProductName, UnitPrice =@UnitPrice WHERE ProductID = @ProductID";
                    using (cmd = new SqlCommand(sql, cnn))
                    {

                        cmd.CommandText = sql;

                        cmd.Parameters.Add(new SqlParameter("@ProductID", SqlDbType.Int));
                        cmd.Parameters["@ProductID"].Value = int.Parse(ProductIdtxt.Text.Trim());
                        cmd.Parameters.Add(new SqlParameter("@ProductName", SqlDbType.NVarChar));
                        cmd.Parameters["@ProductName"].Value = menuNametxt.Text.Trim();
                        cmd.Parameters.Add(new SqlParameter("@UnitPrice", SqlDbType.Decimal));
                        cmd.Parameters["@UnitPrice"].Value = Decimal.Parse(menuPricetxt.Text.Trim());
                        cnn.Open();
                        rowsAffected = cmd.ExecuteNonQuery();
                        //cnn.Close();
                    }
                }

                if (rowsAffected > 0)
                {
                    MessageBox.Show("更新資料成功");
                }
                else
                {
                    MessageBox.Show("找不到該筆資料，未進行任何更新。");
                }



                MenuItem selectedItem = adminmenudgv.CurrentRow?.DataBoundItem as MenuItem;
                int index = 0;

                if (adminmenudgv.CurrentRow != null && adminmenudgv.CurrentRow.Index >= 0)
                {
                    //var existing = allMenuItems.FirstOrDefault(x => x.Id == selectedItem.Id);
                    //if (existing != null)
                    //{

                    for (int i = 0; i < allMenuItems.Count; i++)
                    {
                        if (allMenuItems[i].Id == selectedItem.Id)
                        {
                            index = i;
                            break;
                        }
                    }

                    allMenuItems[index].Price = Convert.ToDecimal(menuPricetxt.Text);
                    allMenuItems[index].Name = menuNametxt.Text;
                    //allMenuItems[index].Id = Convert.ToInt32(  ProductIdtxt.Text);

                    // }
                    string fullPath;
                    // 遍歷每一列，將路徑轉為 Image 物件塞入 Cell

                    // 假設路徑存在 "ImagePath" 欄位中

                    fullPath = $@"Images/{allMenuItems[index].Name}(32X32).png";
                    if (!string.IsNullOrEmpty(fullPath) && System.IO.File.Exists(fullPath))
                    {
                        // 將圖片物件放入剛建立的圖片欄位中
                        //MessageBox.Show($"{path}");
                        allMenuItems[index].ProductPic = Image.FromFile(fullPath);
                    }
                    else
                    {
                        // 若無圖片，可給予預設圖或 null
                        allMenuItems[index].ProductPic = null;
                    }



                    //adminbs.ResetCurrentItem();
                    adminbs.ResetBindings(false);
                    //adminmenudgv.DataSource = null;
                    //adminmenudgv.DataSource = allMenuItems; 

                    //adminmenudgv.Refresh();


                }


            }
            catch (Exception ex)
            {
                cnn.Close();
                MessageBox.Show(ex.Message + ", 更新資料發生錯誤");
            }
            finally
            {
                cmd.Parameters.Clear();
            }


            /*
                        MenuItem selectedItem = adminmenudgv.CurrentRow?.DataBoundItem as MenuItem;
                        int index = 0;

                        if (adminmenudgv.CurrentRow != null && adminmenudgv.CurrentRow.Index >= 0)
                        {
                            //var existing = allMenuItems.FirstOrDefault(x => x.Id == selectedItem.Id);
                            //if (existing != null)
                            //{

                            for (int i = 0; i < allMenuItems.Count; i++)
                            {
                                if (allMenuItems[i].Id == selectedItem.Id)
                                {
                                    index = i;
                                    break;
                                }
                            }

                            allMenuItems[index].Price = Convert.ToDecimal(menuPricetxt.Text);
                            allMenuItems[index].Name = menuNametxt.Text;
                            //allMenuItems[index].Id = Convert.ToInt32(  ProductIdtxt.Text);

                            // }
                            //adminbs.ResetCurrentItem();
                            adminbs.ResetBindings(false);
                            //adminmenudgv.DataSource = null;
                            //adminmenudgv.DataSource = allMenuItems; 

                            //adminmenudgv.Refresh();


                        }*/

            //bs.ResetBindings(false);





        }

        private void menudeletebtn_Click(object sender, EventArgs e)
        {


            int rowsAffected;
            try  //使用try...catch...敘述來補捉異動資料可能發生的例外 
            {
                //MessageBox.Show($"更新:{connectionString}");
                using (cnn = new SqlConnection(connectionString))
                {
                    string sql = "DELETE FROM Products  WHERE ProductID = @ProductID";
                    using (cmd = new SqlCommand(sql, cnn))
                    {

                        cmd.CommandText = sql;

                        cmd.Parameters.Add(new SqlParameter("@ProductID", SqlDbType.Int));
                        cmd.Parameters["@ProductID"].Value = int.Parse(ProductIdtxt.Text.Trim());

                        cnn.Open();
                        rowsAffected = cmd.ExecuteNonQuery();
                        //cnn.Close();
                    }
                }

                if (rowsAffected > 0)
                {
                    MessageBox.Show("刪除資料成功");
                }
                else
                {
                    MessageBox.Show("找不到該筆資料，未進行任何刪除。");
                }



                int idcount = 0;
                MenuItem selectedItem = adminmenudgv.CurrentRow?.DataBoundItem as MenuItem;
                if (adminmenudgv.CurrentRow != null && adminmenudgv.CurrentRow.Index >= 0)
                {
                    //var existing = allMenuItems.FirstOrDefault(x => x.Id == selectedItem.Id);
                    //if (existing != null)
                    //{
                    allMenuItems.Remove(selectedItem);
                    /*
                    for (int i = 0; i < allMenuItems.Count; i++)
                    {
                        idcount++;
                        allMenuItems[i].Id = idcount;
                    }
                    */
                    // }






                }
                adminbs.ResetBindings(false);


            }
            catch (Exception ex)
            {
                cnn.Close();
                MessageBox.Show(ex.Message + ", 刪除資料發生錯誤");
            }
            finally
            {
                cmd.Parameters.Clear();
            }


            /*
            int idcount = 0;
            MenuItem selectedItem = adminmenudgv.CurrentRow?.DataBoundItem as MenuItem;
            if (adminmenudgv.CurrentRow != null && adminmenudgv.CurrentRow.Index >= 0)
            {
                //var existing = allMenuItems.FirstOrDefault(x => x.Id == selectedItem.Id);
                //if (existing != null)
                //{
                allMenuItems.Remove(selectedItem);
                for (int i = 0; i < allMenuItems.Count; i++)
                {
                    idcount++;
                    allMenuItems[i].Id = idcount;
                }

                // }






            }
            adminbs.ResetBindings(false);
            //adminmenudgv.Refresh();
            //bs.ResetBindings(false);

*/




        }

        private void menusortbtn_Click(object sender, EventArgs e)
        {
            if (allMenuItemssortflag == 0)
            {
                // 1. 使用 LINQ 對原本的資料進行排序
                var sortedList = allMenuItems.OrderByDescending(x => x.Id).ToList();
                // 2. 清空原本的 BindingList 並重新加入排序後的資料
                allMenuItems.RaiseListChangedEvents = false; // 暫時關閉事件以增進效能
                allMenuItems.Clear();
                foreach (var item in sortedList)
                {
                    allMenuItems.Add(item);
                }
                allMenuItems.RaiseListChangedEvents = true; // 開啟事件
                                                            // 3. 通知 UI 更新
                allMenuItems.ResetBindings();
                adminbs.ResetBindings(false);
                allMenuItemssortflag = 1;
            }
            else if (allMenuItemssortflag == 1)
            {
                // 1. 使用 LINQ 對原本的資料進行排序
                var sortedList = allMenuItems.OrderBy(x => x.Id).ToList();
                // 2. 清空原本的 BindingList 並重新加入排序後的資料
                allMenuItems.RaiseListChangedEvents = false; // 暫時關閉事件以增進效能
                allMenuItems.Clear();
                foreach (var item in sortedList)
                {
                    allMenuItems.Add(item);
                }
                allMenuItems.RaiseListChangedEvents = true; // 開啟事件
                                                            // 3. 通知 UI 更新
                allMenuItems.ResetBindings();
                adminbs.ResetBindings(false);
                allMenuItemssortflag = 0;
            }
        }

        private void searchtxt_TextChanged(object sender, EventArgs e)
        {
            var keyword = "%" + searchtxt.Text.ToLower() + "%";
            //string sql = @"SELECT ProductID 產品序號,ProductName 品項,UnitPrice 單價,ImagePath 圖片路徑 FROM Products WHERE ProductID = @ProductID;";
            //keyword = "";
            //var filtered = allMenuItems.Where(x => x.Name.ToLower().Contains(keyword)).ToList();

            //dgvMenu.DataSource = new BindingList<MenuItem>(filtered);
            //adminmenudgv.DataSource = new BindingList<MenuItem>(filtered);
            //adminmenudgv.ResetBindings(false);
            if (searchtxt.Text.ToLower() != "")
            {
                string sql = @"SELECT ProductID 產品序號,ProductName 品項,UnitPrice 單價,ImagePath 圖片路徑 FROM Products WHERE ProductName like @ProductName;";
                using (cnn = new SqlConnection(connectionString))
                {
                    using (cmd = new SqlCommand(sql, cnn))
                    {
                        cmd.Parameters.Add(new SqlParameter("@ProductName", SqlDbType.NVarChar));
                        cmd.Parameters["@ProductName"].Value = keyword;

                        ds.Clear();
                        adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(ds, "Products");
                        dt = ds.Tables["Products"];
                        items = dt.AsEnumerable().Select(row => new MenuItem
                        {
                            Id = row.Field<int>("產品序號"),
                            Name = row.Field<string>("品項"),
                            Price = row.Field<decimal>("單價"),
                            ImagePath = row.Field<string>("圖片路徑")

                        }).ToList();
                        string fullPath;
                        // 遍歷每一列，將路徑轉為 Image 物件塞入 Cell
                        foreach (var item in items)
                        {
                            // 假設路徑存在 "ImagePath" 欄位中

                            fullPath = $@"Images/{item.Name}(32X32).png";
                            if (!string.IsNullOrEmpty(fullPath) && System.IO.File.Exists(fullPath))
                            {
                                // 將圖片物件放入剛建立的圖片欄位中
                                //MessageBox.Show($"{path}");
                                item.ProductPic = Image.FromFile(fullPath);
                                txtlab.Text = "";
                            }
                            else
                            {
                                // 若無圖片，可給予預設圖或 null
                                item.ProductPic = null;
                                txtlab.Text = $"請確認是否有放在指定路徑圖片與指定圖片命名:\n" +
                                                       $"1.Images/{item.Name}(h200).png" + "\n" +
                                                       $"2.Images/{item.Name}(32X32).png";
                            }
                        }



                    }
                }


                adminbs.DataSource = new BindingList<MenuItem>(items);
                adminbs.ResetBindings(false);
            }
            else
            {
                string sql = @"SELECT ProductID 產品序號,ProductName 品項,UnitPrice 單價,ImagePath 圖片路徑 FROM Products WHERE ProductName like @ProductName;";
                using (cnn = new SqlConnection(connectionString))
                {
                    using (cmd = new SqlCommand(sql, cnn))
                    {
                        cmd.Parameters.Add(new SqlParameter("@ProductName", SqlDbType.NVarChar));
                        cmd.Parameters["@ProductName"].Value = keyword;
                        ds.Clear();
                        adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(ds, "Products");
                        dt = ds.Tables["Products"];
                        items = dt.AsEnumerable().Select(row => new MenuItem
                        {
                            Id = row.Field<int>("產品序號"),
                            Name = row.Field<string>("品項"),
                            Price = row.Field<decimal>("單價"),
                            ImagePath = row.Field<string>("圖片路徑")

                        }).ToList();


                        string fullPath;
                        // 遍歷每一列，將路徑轉為 Image 物件塞入 Cell
                        foreach (var item in items)
                        {
                            // 假設路徑存在 "ImagePath" 欄位中

                            fullPath = $@"Images/{item.Name}(32X32).png";
                            if (!string.IsNullOrEmpty(fullPath) && System.IO.File.Exists(fullPath))
                            {
                                // 將圖片物件放入剛建立的圖片欄位中
                                //MessageBox.Show($"{path}");
                                item.ProductPic = Image.FromFile(fullPath);

                            }
                            else
                            {
                                // 若無圖片，可給予預設圖或 null
                                item.ProductPic = null;
                            }
                        }


                    }
                }

                allMenuItems = new BindingList<MenuItem>(items);
                adminbs.DataSource = allMenuItems;
                adminbs.ResetBindings(false);
            }


        }

        private void btnsort_Click(object sender, EventArgs e)
        {
            if (cartItemssortflag == 0)
            {
                // 1. 使用 LINQ 對原本的資料進行排序
                var sortedList = cartItems.OrderByDescending(x => x.SubTotal).ToList();
                // 2. 清空原本的 BindingList 並重新加入排序後的資料
                //cartItems.RaiseListChangedEvents = false; // 暫時關閉事件以增進效能
                cartItems.Clear();
                foreach (var item in sortedList)
                {
                    cartItems.Add(item);
                }
                //allMenuItems.RaiseListChangedEvents = true; // 開啟事件
                // 3. 通知 UI 更新
                //cartItems.ResetBindings();
                bs.ResetBindings(false);
                //bs.DataSource = null;
                //bs.DataSource = cartItems;
                cartItemssortflag = 1;
            }
            else if (cartItemssortflag == 1)
            {
                // 1. 使用 LINQ 對原本的資料進行排序
                var sortedList = cartItems.OrderBy(x => x.SubTotal).ToList();
                // 2. 清空原本的 BindingList 並重新加入排序後的資料
                //cartItems.RaiseListChangedEvents = false; // 暫時關閉事件以增進效能
                cartItems.Clear();
                foreach (var item in sortedList)
                {
                    cartItems.Add(item);
                }
                //cartItems.RaiseListChangedEvents = true; // 開啟事件
                // 3. 通知 UI 更新
                //cartItems.ResetBindings();
                bs.ResetBindings(false);
                //bs.DataSource = null;
                //bs.DataSource = cartItems;
                cartItemssortflag = 0;
            }

        }

        private void dgvMenu_CurrentCellChanged(object sender, EventArgs e)
        {
            MenuItem selectedItem = dgvMenu.CurrentRow?.DataBoundItem as MenuItem;
            if (selectedItem == null)
            {
                reviewimg.Image?.Dispose(); // 釋放舊資源
                reviewimg.Image = null;
                return;
            }
            string path = $@"Images/{selectedItem.Name}(h200).png";

            if (!string.IsNullOrEmpty(path) && System.IO.File.Exists(path))
            {
                // 將圖片物件放入剛建立的圖片欄位中
                //MessageBox.Show($"{path}");
                // 釋放上一張圖的記憶體
                reviewimg.Image?.Dispose();
                reviewimg.Image = Image.FromFile(path);
            }
            else
            {
                // 釋放上一張圖的記憶體
                reviewimg.Image?.Dispose();
                // 若無圖片，可給予預設圖或 null
                reviewimg.Image = null;
            }
        }

        private void adminmenudgv_CurrentCellChanged(object sender, EventArgs e)
        {
            MenuItem selectedItem = adminmenudgv.CurrentRow?.DataBoundItem as MenuItem;
            if (selectedItem == null)
            {
                adminmenupicture.Image?.Dispose(); // 釋放舊資源
                adminmenupicture.Image = null;
                return;
            }

            ProductIdtxt.Text = selectedItem.Id.ToString();
            menuNametxt.Text = selectedItem.Name.ToString();
            menuPricetxt.Text = selectedItem.Price.ToString();

            string path = $@"Images/{selectedItem.Name}(h200).png";

            if (!string.IsNullOrEmpty(path) && System.IO.File.Exists(path))
            {
                // 將圖片物件放入剛建立的圖片欄位中
                //MessageBox.Show($"{path}");
                // 釋放上一張圖的記憶體
                adminmenupicture.Image?.Dispose();
                adminmenupicture.Image = Image.FromFile(path);
                txtlab.Text = "";
            }
            else
            {
                // 釋放上一張圖的記憶體
                adminmenupicture.Image?.Dispose();
                // 若無圖片，可給予預設圖或 null
                adminmenupicture.Image = null;
                txtlab.Text = $"請確認是否有放在指定路徑圖片與指定圖片命名:\n" +
                    $"1.Images/{selectedItem.Name}(h200).png" + "\n" +
                    $"2.Images/{selectedItem.Name}(32X32).png";
            }
        }

        private void custaddbtn_Click(object sender, EventArgs e)
        {

            try  //使用try...catch...敘述來補捉異動資料可能發生的例外 
            {
                //MessageBox.Show($"新增:{connectionString}");
                using (cnn = new SqlConnection(connectionString))
                {
                    string sql = "INSERT INTO Customers(CustomerID,CustomerName, Region, PaymentMethods) VALUES (@CustomerID,@CustomerName, @Region, @PaymentMethods)";
                    using (cmd = new SqlCommand(sql, cnn))
                    {

                        cmd.CommandText = sql;
                        cmd.Parameters.Add(new SqlParameter("@CustomerID", SqlDbType.Int));
                        cmd.Parameters["@CustomerID"].Value = custIDtxt.Text.Trim();
                        cmd.Parameters.Add(new SqlParameter("@CustomerName", SqlDbType.NVarChar));
                        cmd.Parameters["@CustomerName"].Value = custnametxt.Text.Trim();
                        cmd.Parameters.Add(new SqlParameter("@Region", SqlDbType.NVarChar));
                        cmd.Parameters["@Region"].Value = regioncombo.Text.Trim();
                        cmd.Parameters.Add(new SqlParameter("@PaymentMethods", SqlDbType.NVarChar));
                        cmd.Parameters["@PaymentMethods"].Value = paycombo.Text.Trim();
                        cnn.Open();
                        cmd.ExecuteNonQuery();
                        //cnn.Close();
                    }
                }

                MessageBox.Show($"新增資料成功");
                custitems.Add(new Customer { customerID = Convert.ToInt32(custIDtxt.Text.Trim()), CustomerName = custnametxt.Text.Trim(), Region = regioncombo.Text.Trim(), PaymentMethods = paycombo.Text.Trim() });
                custbs.ResetBindings(false);


            }
            catch (Exception ex)
            {
                cnn.Close();
                MessageBox.Show(ex.Message + ", 新增資料發生錯誤");
            }
            finally
            {
                cmd.Parameters.Clear();
            }


        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            int countline = 0;
            custsearchtxt.Text = "";
            ordermastercustIDsearchtxt.Text = "";
            orderdetailcustIDsearchtxt.Text = "";
            searchtxt.Text = "";
            txtSearch.Text = "";
            if (tabControl1.SelectedTab.Name == "Tab_MemberVIP")
            {
                //MessageBox.Show("1");

                string sql = @"SELECT CustomerID 客戶序號,CustomerName 客戶名稱,Region 地區,PaymentMethods 付款方式 FROM Customers ;";
                using (cnn = new SqlConnection(connectionString))
                {
                    using (cmd = new SqlCommand(sql, cnn))
                    {
                        custdt.Clear();
                        adapter = new SqlDataAdapter(cmd);
                        countline = adapter.Fill(custdt);
                        if (countline > 0)
                        {
                            custitems = custdt.AsEnumerable().Select(row => new Customer
                            {
                                customerID = row.Field<int>("客戶序號"),
                                CustomerName = row.Field<string>("客戶名稱"),
                                Region = row.Field<string>("地區"),
                                PaymentMethods = row.Field<string>("付款方式")

                            }).ToList();
                            custbs.DataSource = custitems;
                            custbs.ResetBindings(false);
                        }
                        else
                        {

                            MessageBox.Show("查無產品資料");
                        }
                        //dt = ds.Tables["Products"];
                    }
                }
            }
            else if (tabControl1.SelectedTab.Name == "Tab_Order")
            {
                //MessageBox.Show("2");
                string sql = @"SELECT SaleID 訂單序號,CustomerID 客戶編號,SaleDate 下單日期,TotalQuantity 總數量,TotalAmount 總金額 FROM SalesMaster ;";
                using (cnn = new SqlConnection(connectionString))
                {
                    using (cmd = new SqlCommand(sql, cnn))
                    {
                        ordermasterdt.Clear();
                        adapter = new SqlDataAdapter(cmd);
                        countline = adapter.Fill(ordermasterdt);
                        //MessageBox.Show($"{countline}");
                        if (countline > 0)
                        {
                            ordermasteritems = ordermasterdt.AsEnumerable().Select(row => new SalesMaster
                            {
                                SaleID = row.Field<int>("訂單序號"),
                                CustomerID = row.Field<int>("客戶編號"),
                                SaleDate = row.Field<DateTime>("下單日期"),
                                TotalQuantity = row.Field<int>("總數量"),
                                TotalAmount = row.Field<decimal>("總金額")

                            }).ToList();
                            //MessageBox.Show($"{ordermasteritems}");
                            ordermasterbs.DataSource = ordermasteritems;
                            ordermasterbs.ResetBindings(false);
                        }
                        else
                        {

                            MessageBox.Show("查無產品資料");
                        }
                        //dt = ds.Tables["Products"];
                    }
                }
            }
            else if (tabControl1.SelectedTab.Name == "Tab_OrderDetail")
            {
                //MessageBox.Show("3");
                string sql = @"SELECT DetailID 訂單明細序號,SaleID 訂單編號,ProductID 產品序號,Quantity 數量,  UnitPrice 單價, SubTotal 小節總金額 FROM SalesDetail ;";
                using (cnn = new SqlConnection(connectionString))
                {
                    using (cmd = new SqlCommand(sql, cnn))
                    {
                        orderdetaildt.Clear();
                        adapter = new SqlDataAdapter(cmd);
                        countline = adapter.Fill(orderdetaildt);
                        //MessageBox.Show($"{countline}");
                        if (countline > 0)
                        {
                            orderdetailitems = orderdetaildt.AsEnumerable().Select(row => new SalesDetail
                            {
                                DetailID = row.Field<int>("訂單明細序號"),
                                SaleID = row.Field<int>("訂單編號"),
                                ProductID = row.Field<int>("產品序號"),
                                Quantity = row.Field<int>("數量"),
                                UnitPrice = row.Field<decimal>("單價"),
                                SubTotal = row.Field<decimal>("小節總金額")

                            }).ToList();
                            //MessageBox.Show($"{ordermasteritems}");
                            orderdetailbs.DataSource = orderdetailitems;
                            orderdetailbs.ResetBindings(false);
                        }
                        else
                        {

                            MessageBox.Show("查無產品資料");
                        }
                        //dt = ds.Tables["Products"];
                    }
                }

            }

        }
        //客戶主檔客戶名稱搜尋
        private void custsearchtxt_TextChanged(object sender, EventArgs e)
        {
            var keyword = "%" + custsearchtxt.Text.ToLower() + "%";
            int countline = 0;
            if (custsearchtxt.Text.ToLower() != "")
            {
                string sql = @"SELECT CustomerID 客戶序號,CustomerName 客戶名稱,Region 地區,PaymentMethods 付款方式 FROM Customers WHERE CustomerName like @CustomerName;";
                using (cnn = new SqlConnection(connectionString))
                {
                    using (cmd = new SqlCommand(sql, cnn))
                    {
                        cmd.Parameters.Add(new SqlParameter("@CustomerName", SqlDbType.NVarChar));
                        cmd.Parameters["@CustomerName"].Value = keyword;

                        custdt.Clear();
                        adapter = new SqlDataAdapter(cmd);
                        countline = adapter.Fill(custdt);

                        custitems = custdt.AsEnumerable().Select(row => new Customer
                        {
                            customerID = row.Field<int>("客戶序號"),
                            CustomerName = row.Field<string>("客戶名稱"),
                            Region = row.Field<string>("地區"),
                            PaymentMethods = row.Field<string>("付款方式")

                        }).ToList();
                        custbs.DataSource = custitems;
                        custbs.ResetBindings(false);


                    }
                }
            }
            else
            {
                string sql = @"SELECT CustomerID 客戶序號,CustomerName 客戶名稱,Region 地區,PaymentMethods 付款方式 FROM Customers ;";
                using (cnn = new SqlConnection(connectionString))
                {
                    using (cmd = new SqlCommand(sql, cnn))
                    {
                        //cmd.Parameters.Add(new SqlParameter("@CustomerName", SqlDbType.NVarChar));
                        //cmd.Parameters["@CustomerName"].Value = keyword;

                        custdt.Clear();
                        adapter = new SqlDataAdapter(cmd);
                        countline = adapter.Fill(custdt);
                        if (countline > 0)
                        {
                            custitems = custdt.AsEnumerable().Select(row => new Customer
                            {
                                customerID = row.Field<int>("客戶序號"),
                                CustomerName = row.Field<string>("客戶名稱"),
                                Region = row.Field<string>("地區"),
                                PaymentMethods = row.Field<string>("付款方式")

                            }).ToList();

                        }

                        //allMenuItems = new BindingList<MenuItem>(items);
                        custbs.DataSource = custitems;
                        custbs.ResetBindings(false);

                    }
                }
            }
        }

        private void ordermastercustIDsearchtxt_TextChanged(object sender, EventArgs e)
        {

            var keyword = ordermastercustIDsearchtxt.Text.ToLower();
            int countline = 0;
            if (ordermastercustIDsearchtxt.Text.ToLower() != "" && int.TryParse(keyword, out _))
            {
                string sql = @"SELECT SaleID 訂單序號,CustomerID 客戶編號,SaleDate 下單日期,TotalAmount 訂單總金額 FROM SalesMaster WHERE CustomerID = @CustomerID;";
                using (cnn = new SqlConnection(connectionString))
                {
                    using (cmd = new SqlCommand(sql, cnn))
                    {
                        cmd.Parameters.Add(new SqlParameter("@CustomerID", SqlDbType.Int));
                        cmd.Parameters["@CustomerID"].Value = keyword;

                        ordermasterdt.Clear();
                        adapter = new SqlDataAdapter(cmd);
                        countline = adapter.Fill(ordermasterdt);

                        ordermasteritems = ordermasterdt.AsEnumerable().Select(row => new SalesMaster
                        {
                            SaleID = row.Field<int>("訂單序號"),
                            CustomerID = row.Field<int>("客戶編號"),
                            SaleDate = row.Field<DateTime>("下單日期"),
                            TotalAmount = row.Field<decimal>("訂單總金額")

                        }).ToList();
                        ordermasterbs.DataSource = ordermasteritems;
                        ordermasterbs.ResetBindings(false);


                    }
                }
            }
            else
            {
                if (!int.TryParse(keyword, out _) && keyword != "")
                {
                    MessageBox.Show("請輸入整數");
                }

                string sql = @"SELECT SaleID 訂單序號,CustomerID 客戶編號,SaleDate 下單日期,TotalAmount 訂單總金額 FROM SalesMaster ;";
                using (cnn = new SqlConnection(connectionString))
                {
                    using (cmd = new SqlCommand(sql, cnn))
                    {
                        //cmd.Parameters.Add(new SqlParameter("@CustomerID", SqlDbType.NVarChar));
                        //cmd.Parameters["@CustomerID"].Value = keyword;

                        ordermasterdt.Clear();
                        adapter = new SqlDataAdapter(cmd);
                        countline = adapter.Fill(ordermasterdt);

                        ordermasteritems = ordermasterdt.AsEnumerable().Select(row => new SalesMaster
                        {
                            SaleID = row.Field<int>("訂單序號"),
                            CustomerID = row.Field<int>("客戶編號"),
                            SaleDate = row.Field<DateTime>("下單日期"),
                            TotalAmount = row.Field<decimal>("訂單總金額")

                        }).ToList();
                        ordermasterbs.DataSource = ordermasteritems;
                        ordermasterbs.ResetBindings(false);

                    }
                }
            }
        }

        private void orderdetailcustIDsearchtxt_TextChanged(object sender, EventArgs e)
        {

            var keyword = orderdetailcustIDsearchtxt.Text.ToLower();

            int countline = 0;

            if (orderdetailcustIDsearchtxt.Text.ToLower() != "" && int.TryParse(keyword, out _))
            {

                string sql = @"SELECT DetailID 訂單明細序號,SaleID 訂單序號,ProductID 產品序號,Quantity 數量,UnitPrice 單價,SubTotal 小結總金額 FROM SalesDetail WHERE SaleID = @SaleID;";
                using (cnn = new SqlConnection(connectionString))
                {
                    using (cmd = new SqlCommand(sql, cnn))
                    {

                        cmd.Parameters.Add(new SqlParameter("@SaleID", SqlDbType.Int));
                        cmd.Parameters["@SaleID"].Value = keyword;

                        orderdetaildt.Clear();
                        adapter = new SqlDataAdapter(cmd);
                        countline = adapter.Fill(orderdetaildt);

                        orderdetailitems = orderdetaildt.AsEnumerable().Select(row => new SalesDetail
                        {
                            DetailID = row.Field<int>("訂單明細序號"),
                            SaleID = row.Field<int>("訂單序號"),
                            ProductID = row.Field<int>("產品序號"),
                            Quantity = row.Field<int>("數量"),
                            UnitPrice = row.Field<decimal>("單價"),
                            SubTotal = row.Field<decimal>("小結總金額")

                        }).ToList();
                        orderdetailbs.DataSource = orderdetailitems;
                        orderdetailbs.ResetBindings(false);


                    }
                }
            }
            else
            {
                if (!int.TryParse(keyword, out _) && keyword != "")
                {
                    MessageBox.Show("請輸入整數");
                }
                string sql = @"SELECT DetailID 訂單明細序號,SaleID 訂單序號,ProductID 訂單序號,Quantity 數量,UnitPrice 單價,SubTotal 小結總金額 FROM SalesDetail ;";
                using (cnn = new SqlConnection(connectionString))
                {
                    using (cmd = new SqlCommand(sql, cnn))
                    {
                        //cmd.Parameters.Add(new SqlParameter("@CustomerID", SqlDbType.NVarChar));
                        //cmd.Parameters["@CustomerID"].Value = keyword;

                        orderdetaildt.Clear();
                        adapter = new SqlDataAdapter(cmd);
                        countline = adapter.Fill(orderdetaildt);

                        orderdetailitems = orderdetaildt.AsEnumerable().Select(row => new SalesDetail
                        {
                            DetailID = row.Field<int>("訂單明細序號"),
                            SaleID = row.Field<int>("訂單序號"),
                            ProductID = row.Field<int>("訂單序號"),
                            Quantity = row.Field<int>("數量"),
                            UnitPrice = row.Field<decimal>("單價"),
                            SubTotal = row.Field<decimal>("小結總金額")

                        }).ToList();
                        orderdetailbs.DataSource = orderdetailitems;
                        orderdetailbs.ResetBindings(false);

                    }
                }
            }
        }

        private void custdgv_CurrentCellChanged(object sender, EventArgs e)
        {

            Customer selectedItem = custdgv.CurrentRow?.DataBoundItem as Customer;
            if (selectedItem == null)
            {

                return;
            }

            custnametxt.Text = selectedItem.CustomerName;
            paycombo.Text = selectedItem.PaymentMethods;
            regioncombo.Text = selectedItem.Region;
            custIDtxt.Text = selectedItem.customerID.ToString();
        }

        private void ordermasterdgv_CurrentCellChanged(object sender, EventArgs e)
        {

            SalesMaster selectedItem = ordermasterdgv.CurrentRow?.DataBoundItem as SalesMaster;
            if (selectedItem == null)
            {

                return;
            }

            ordermasterIDtxt.Text = selectedItem.SaleID.ToString();
            ordermastercustIDtxt.Text = selectedItem.CustomerID.ToString();
            ordermasterdatetxt.Text = selectedItem.SaleDate.ToString();
            ordermastertotaltxt.Text = selectedItem.TotalAmount.ToString();
            //totalquantitytxt.Text= selectedItem.TotalAmount.ToString();
            totalquantitytxt.Text = selectedItem.TotalQuantity.ToString();
        }

        private void orderdetaildgv_CurrentCellChanged(object sender, EventArgs e)
        {

            SalesDetail selectedItem = orderdetaildgv.CurrentRow?.DataBoundItem as SalesDetail;
            if (selectedItem == null)
            {

                return;
            }

            orderdetailIDtxt.Text = selectedItem.SaleID.ToString();
            orderdetailProductIdtxt.Text = selectedItem.ProductID.ToString();
            orderdetailPricetxt.Text = selectedItem.UnitPrice.ToString();
            orderdetailquantitytxt.Text = selectedItem.Quantity.ToString();
            orderdetatilsubTotaltxt.Text = selectedItem.SubTotal.ToString();
            numberIDtxt.Text = selectedItem.DetailID.ToString();
        }

        private void custupdatebtn_Click(object sender, EventArgs e)
        {
            int rowsAffected = 0;

            try  //使用try...catch...敘述來補捉異動資料可能發生的例外 
            {
                //MessageBox.Show($"新增:{connectionString}");
                using (cnn = new SqlConnection(connectionString))
                {
                    string sql = "UPDATE Customers SET  CustomerName =@CustomerName, Region =@Region,PaymentMethods=@PaymentMethods WHERE CustomerID = @CustomerID";
                    using (cmd = new SqlCommand(sql, cnn))
                    {

                        cmd.CommandText = sql;
                        cmd.Parameters.Add(new SqlParameter("@CustomerID", SqlDbType.Int));
                        cmd.Parameters["@CustomerID"].Value = custIDtxt.Text.Trim();
                        cmd.Parameters.Add(new SqlParameter("@CustomerName", SqlDbType.NVarChar));
                        cmd.Parameters["@CustomerName"].Value = custnametxt.Text.Trim();
                        cmd.Parameters.Add(new SqlParameter("@Region", SqlDbType.NVarChar));
                        cmd.Parameters["@Region"].Value = regioncombo.Text.Trim();
                        cmd.Parameters.Add(new SqlParameter("@PaymentMethods", SqlDbType.NVarChar));
                        cmd.Parameters["@PaymentMethods"].Value = paycombo.Text.Trim();
                        cnn.Open();
                        rowsAffected = cmd.ExecuteNonQuery();
                        //cnn.Close();
                    }
                }

                if (rowsAffected > 0)
                {
                    MessageBox.Show("更新資料成功");
                }
                else
                {
                    MessageBox.Show("找不到該筆資料，未進行任何更新。");
                }
                //custitems.Add(new Customer { CustomerName = custnametxt.Text.Trim(), Region = regioncombo.Text.Trim(), PaymentMethods = paycombo.Text.Trim() });
                Customer selectedItem = custdgv.CurrentRow?.DataBoundItem as Customer;
                int index = 0;

                if (custdgv.CurrentRow != null && custdgv.CurrentRow.Index >= 0)
                {
                    for (int i = 0; i < custitems.Count; i++)
                    {
                        if (custitems[i].customerID == selectedItem.customerID)
                        {
                            index = i;
                            break;
                        }
                    }

                    custitems[index].CustomerName = custnametxt.Text.Trim();
                    custitems[index].Region = regioncombo.Text.Trim();
                    custitems[index].PaymentMethods = paycombo.Text.Trim();
                }


                custbs.ResetBindings(false);


            }
            catch (Exception ex)
            {
                cnn.Close();
                MessageBox.Show(ex.Message + ", 更新資料發生錯誤");
            }
            finally
            {
                cmd.Parameters.Clear();
            }

        }

        private void custdeletebtn_Click(object sender, EventArgs e)
        {
            int rowsAffected = 0;

            try  //使用try...catch...敘述來補捉異動資料可能發生的例外 
            {
                //MessageBox.Show($"新增:{connectionString}");
                using (cnn = new SqlConnection(connectionString))
                {
                    string sql = "DELETE FROM Customers  WHERE CustomerID = @CustomerID";
                    using (cmd = new SqlCommand(sql, cnn))
                    {

                        cmd.CommandText = sql;
                        cmd.Parameters.Add(new SqlParameter("@CustomerID", SqlDbType.Int));
                        cmd.Parameters["@CustomerID"].Value = custIDtxt.Text.Trim();

                        cnn.Open();
                        rowsAffected = cmd.ExecuteNonQuery();
                        //cnn.Close();
                    }
                }

                if (rowsAffected > 0)
                {
                    MessageBox.Show("刪除資料成功");
                }
                else
                {
                    MessageBox.Show("找不到該筆資料，未進行任何更新。");
                }
                //custitems.Add(new Customer { CustomerName = custnametxt.Text.Trim(), Region = regioncombo.Text.Trim(), PaymentMethods = paycombo.Text.Trim() });
                Customer selectedItem = custdgv.CurrentRow?.DataBoundItem as Customer;
                int index = 0;

                if (custdgv.CurrentRow != null && custdgv.CurrentRow.Index >= 0)
                {
                    /*
                    for (int i = 0; i < custitems.Count; i++)
                    {
                        if (custitems[i].customerID == selectedItem.customerID)
                        {
                            index = i;
                            break;
                        }
                    }
                    */
                    custitems.Remove(selectedItem);

                }


                custbs.ResetBindings(false);


            }
            catch (Exception ex)
            {
                cnn.Close();
                MessageBox.Show(ex.Message + ", 更新資料發生錯誤");
            }
            finally
            {
                cmd.Parameters.Clear();
            }
        }

        private void custsortbtn_Click(object sender, EventArgs e)
        {

            if (custItemssortflag == 0)
            {
                // 1. 使用 LINQ 對原本的資料進行排序
                var sortedList = custitems.OrderByDescending(x => x.customerID).ToList();
                // 2. 清空原本的 BindingList 並重新加入排序後的資料

                custitems.Clear();
                foreach (var item in sortedList)
                {
                    custitems.Add(item);
                }

                // 3. 通知 UI 更新

                custbs.ResetBindings(false);
                custItemssortflag = 1;
            }
            else if (custItemssortflag == 1)
            {
                // 1. 使用 LINQ 對原本的資料進行排序
                var sortedList = custitems.OrderBy(x => x.customerID).ToList();
                // 2. 清空原本的 BindingList 並重新加入排序後的資料

                custitems.Clear();
                foreach (var item in sortedList)
                {
                    custitems.Add(item);
                }


                custbs.ResetBindings(false);
                custItemssortflag = 0;
            }
        }

        private void ordermasteraddbtn_Click(object sender, EventArgs e)
        {

            try  //使用try...catch...敘述來補捉異動資料可能發生的例外 
            {
                //MessageBox.Show($"新增:{connectionString}");
                using (cnn = new SqlConnection(connectionString))
                {
                    string sql = "INSERT INTO SalesMaster(SaleID,CustomerID, SaleDate,TotalAmount,TotalQuantity) VALUES (@SaleID,@CustomerID, @SaleDate,@TotalAmount,@TotalQuantity)";
                    using (cmd = new SqlCommand(sql, cnn))
                    {

                        cmd.CommandText = sql;
                        cmd.Parameters.Add(new SqlParameter("@SaleID", SqlDbType.Int));
                        cmd.Parameters["@SaleID"].Value = ordermasterIDtxt.Text.Trim();
                        cmd.Parameters.Add(new SqlParameter("@CustomerID", SqlDbType.Int));
                        cmd.Parameters["@CustomerID"].Value = ordermastercustIDtxt.Text.Trim();
                        cmd.Parameters.Add(new SqlParameter("@SaleDate", SqlDbType.DateTime));
                        cmd.Parameters["@SaleDate"].Value = ordermasterdatetxt.Text.Trim();
                        cmd.Parameters.Add(new SqlParameter("@TotalAmount", SqlDbType.Decimal));
                        cmd.Parameters["@TotalAmount"].Value = ordermastertotaltxt.Text.Trim();
                        cmd.Parameters.Add(new SqlParameter("@TotalQuantity", SqlDbType.Int));
                        cmd.Parameters["@TotalQuantity"].Value = totalquantitytxt.Text.Trim();
                        cnn.Open();
                        cmd.ExecuteNonQuery();
                        //cnn.Close();
                    }
                }


                ordermasteritems.Add(new SalesMaster { SaleID = Convert.ToInt32(ordermasterIDtxt.Text.Trim()), CustomerID = Convert.ToInt32(ordermastercustIDtxt.Text.Trim()), SaleDate = Convert.ToDateTime(ordermasterdatetxt.Text.Trim()), TotalAmount = Convert.ToDecimal(ordermastertotaltxt.Text.Trim()), TotalQuantity = Convert.ToInt32(totalquantitytxt.Text.Trim()) });
                ordermasterbs.ResetBindings(false);
                MessageBox.Show("新增資料成功");
                ordermastercount++;

            }
            catch (Exception ex)
            {
                cnn.Close();
                MessageBox.Show(ex.Message + ", 新增資料發生錯誤");
            }
            finally
            {
                cmd.Parameters.Clear();
            }

        }

        private void ordermasterupdatebtn_Click(object sender, EventArgs e)
        {
            int rowsAffected = 0;

            try  //使用try...catch...敘述來補捉異動資料可能發生的例外 
            {
                //MessageBox.Show($"新增:{connectionString}");
                using (cnn = new SqlConnection(connectionString))
                {
                    string sql = "UPDATE SalesMaster SET  CustomerID =@CustomerID, SaleDate =@SaleDate,TotalAmount=@TotalAmount,TotalQuantity=@TotalQuantity WHERE SaleID = @SaleID";
                    using (cmd = new SqlCommand(sql, cnn))
                    {

                        cmd.CommandText = sql;
                        cmd.Parameters.Add(new SqlParameter("@SaleID", SqlDbType.Int));
                        cmd.Parameters["@SaleID"].Value = ordermasterIDtxt.Text.Trim();
                        cmd.Parameters.Add(new SqlParameter("@CustomerID", SqlDbType.Int));
                        cmd.Parameters["@CustomerID"].Value = ordermastercustIDtxt.Text.Trim();
                        cmd.Parameters.Add(new SqlParameter("@SaleDate", SqlDbType.DateTime));
                        cmd.Parameters["@SaleDate"].Value = ordermasterdatetxt.Text.Trim();
                        cmd.Parameters.Add(new SqlParameter("@TotalAmount", SqlDbType.Decimal));
                        cmd.Parameters["@TotalAmount"].Value = ordermastertotaltxt.Text.Trim();
                        cmd.Parameters.Add(new SqlParameter("@TotalQuantity", SqlDbType.Int));
                        cmd.Parameters["@TotalQuantity"].Value = totalquantitytxt.Text.Trim();

                        cnn.Open();
                        rowsAffected = cmd.ExecuteNonQuery();
                        //cnn.Close();
                    }
                }

                if (rowsAffected > 0)
                {
                    MessageBox.Show("更新資料成功");
                }
                else
                {
                    MessageBox.Show("找不到該筆資料，未進行任何更新。");
                }
                //custitems.Add(new Customer { CustomerName = custnametxt.Text.Trim(), Region = regioncombo.Text.Trim(), PaymentMethods = paycombo.Text.Trim() });
                SalesMaster selectedItem = ordermasterdgv.CurrentRow?.DataBoundItem as SalesMaster;
                int index = 0;

                if (ordermasterdgv.CurrentRow != null && ordermasterdgv.CurrentRow.Index >= 0)
                {
                    for (int i = 0; i < ordermasteritems.Count; i++)
                    {
                        if (ordermasteritems[i].SaleID == selectedItem.SaleID)
                        {
                            index = i;
                            break;
                        }
                    }

                    ordermasteritems[index].CustomerID = Convert.ToInt32(ordermastercustIDtxt.Text.Trim());
                    ordermasteritems[index].SaleDate = Convert.ToDateTime(ordermasterdatetxt.Text.Trim());
                    ordermasteritems[index].TotalAmount = Convert.ToDecimal(ordermastertotaltxt.Text.Trim());
                    ordermasteritems[index].TotalQuantity = Convert.ToInt32(totalquantitytxt.Text.Trim());
                }


                ordermasterbs.ResetBindings(false);


            }
            catch (Exception ex)
            {
                cnn.Close();
                MessageBox.Show(ex.Message + ", 更新資料發生錯誤");
            }
            finally
            {
                cmd.Parameters.Clear();
            }
        }

        private void ordermasterdeletebtn_Click(object sender, EventArgs e)
        {
            int rowsAffected = 0;

            try  //使用try...catch...敘述來補捉異動資料可能發生的例外 
            {
                //MessageBox.Show($"新增:{connectionString}");
                using (cnn = new SqlConnection(connectionString))
                {
                    string sql = "DELETE FROM SalesMaster  WHERE SaleID = @SaleID";
                    using (cmd = new SqlCommand(sql, cnn))
                    {

                        cmd.CommandText = sql;
                        cmd.Parameters.Add(new SqlParameter("@SaleID", SqlDbType.Int));
                        cmd.Parameters["@SaleID"].Value = ordermasterIDtxt.Text.Trim();

                        cnn.Open();
                        rowsAffected = cmd.ExecuteNonQuery();
                        //cnn.Close();
                    }
                }

                if (rowsAffected > 0)
                {
                    MessageBox.Show("刪除資料成功");
                }
                else
                {
                    MessageBox.Show("找不到該筆資料，未進行任何更新。");
                }
                //custitems.Add(new Customer { CustomerName = custnametxt.Text.Trim(), Region = regioncombo.Text.Trim(), PaymentMethods = paycombo.Text.Trim() });
                SalesMaster selectedItem = ordermasterdgv.CurrentRow?.DataBoundItem as SalesMaster;
                int index = 0;

                if (ordermasterdgv.CurrentRow != null && ordermasterdgv.CurrentRow.Index >= 0)
                {
                    /*
                    for (int i = 0; i < custitems.Count; i++)
                    {
                        if (custitems[i].customerID == selectedItem.customerID)
                        {
                            index = i;
                            break;
                        }
                    }
                    */
                    ordermasteritems.Remove(selectedItem);
                    ordermastercount--;
                }


                ordermasterbs.ResetBindings(false);


            }
            catch (Exception ex)
            {
                cnn.Close();
                MessageBox.Show(ex.Message + ", 更新資料發生錯誤");
            }
            finally
            {
                cmd.Parameters.Clear();
            }
        }

        private void ordermastersortbtn_Click(object sender, EventArgs e)
        {

            if (ordermasterItemssortflag == 0)
            {
                // 1. 使用 LINQ 對原本的資料進行排序
                var sortedList = ordermasteritems.OrderByDescending(x => x.SaleID).ToList();
                // 2. 清空原本的 BindingList 並重新加入排序後的資料

                ordermasteritems.Clear();
                foreach (var item in sortedList)
                {
                    ordermasteritems.Add(item);
                }

                // 3. 通知 UI 更新

                ordermasterbs.ResetBindings(false);
                ordermasterItemssortflag = 1;
            }
            else if (ordermasterItemssortflag == 1)
            {
                // 1. 使用 LINQ 對原本的資料進行排序
                var sortedList = ordermasteritems.OrderBy(x => x.SaleID).ToList();
                // 2. 清空原本的 BindingList 並重新加入排序後的資料

                ordermasteritems.Clear();
                foreach (var item in sortedList)
                {
                    ordermasteritems.Add(item);
                }


                ordermasterbs.ResetBindings(false);
                ordermasterItemssortflag = 0;
            }
        }

        private void orderdetailaddbtn_Click(object sender, EventArgs e)
        {

            try  //使用try...catch...敘述來補捉異動資料可能發生的例外 
            {
                //MessageBox.Show($"新增:{connectionString}");
                using (cnn = new SqlConnection(connectionString))
                {
                    string sql = "INSERT INTO SalesDetail(DetailID,SaleID, ProductID,Quantity,UnitPrice,SubTotal) VALUES (@DetailID,@SaleID, @ProductID,@Quantity,@UnitPrice,@SubTotal)";
                    using (cmd = new SqlCommand(sql, cnn))
                    {

                        cmd.CommandText = sql;
                        cmd.Parameters.Add(new SqlParameter("@DetailID", SqlDbType.Int));
                        cmd.Parameters["@DetailID"].Value = numberIDtxt.Text.Trim();
                        cmd.Parameters.Add(new SqlParameter("@SaleID", SqlDbType.Int));
                        cmd.Parameters["@SaleID"].Value = orderdetailIDtxt.Text.Trim();
                        cmd.Parameters.Add(new SqlParameter("@ProductID", SqlDbType.Int));
                        cmd.Parameters["@ProductID"].Value = orderdetailProductIdtxt.Text.Trim();
                        cmd.Parameters.Add(new SqlParameter("@Quantity", SqlDbType.Int));
                        cmd.Parameters["@Quantity"].Value = orderdetailquantitytxt.Text.Trim();
                        cmd.Parameters.Add(new SqlParameter("@UnitPrice", SqlDbType.Decimal));
                        cmd.Parameters["@UnitPrice"].Value = orderdetailPricetxt.Text.Trim();
                        cmd.Parameters.Add(new SqlParameter("@SubTotal", SqlDbType.Decimal));
                        cmd.Parameters["@SubTotal"].Value = orderdetatilsubTotaltxt.Text.Trim();
                        cnn.Open();
                        cmd.ExecuteNonQuery();
                        //cnn.Close();
                    }
                }


                orderdetailitems.Add(new SalesDetail
                {
                    DetailID = Convert.ToInt32(numberIDtxt.Text.Trim()),
                    SaleID = Convert.ToInt32(orderdetailIDtxt.Text.Trim()),
                    ProductID = Convert.ToInt32(orderdetailProductIdtxt.Text.Trim()),
                    Quantity = Convert.ToInt32(orderdetailquantitytxt.Text.Trim()),
                    UnitPrice = Convert.ToDecimal(orderdetailPricetxt.Text.Trim()),
                    SubTotal = Convert.ToDecimal(orderdetatilsubTotaltxt.Text.Trim())
                });
                MessageBox.Show("新增資料成功");
                orderdetailcount++;

                orderdetailbs.ResetBindings(false);


            }
            catch (Exception ex)
            {
                cnn.Close();
                MessageBox.Show(ex.Message + ", 新增資料發生錯誤");
            }
            finally
            {
                cmd.Parameters.Clear();
            }
        }

        private void orderdetailupdatebtn_Click(object sender, EventArgs e)
        {
            int rowsAffected = 0;

            try  //使用try...catch...敘述來補捉異動資料可能發生的例外 
            {
                //MessageBox.Show($"新增:{connectionString}");
                using (cnn = new SqlConnection(connectionString))
                {
                    string sql = "UPDATE SalesDetail SET  SaleID =@SaleID, ProductID =@ProductID,Quantity=@Quantity,UnitPrice=@UnitPrice,SubTotal=@SubTotal WHERE DetailID = @DetailID";
                    using (cmd = new SqlCommand(sql, cnn))
                    {

                        cmd.CommandText = sql;
                        cmd.Parameters.Add(new SqlParameter("@DetailID", SqlDbType.Int));
                        cmd.Parameters["@DetailID"].Value = numberIDtxt.Text.Trim();
                        cmd.Parameters.Add(new SqlParameter("@SaleID", SqlDbType.Int));
                        cmd.Parameters["@SaleID"].Value = orderdetailIDtxt.Text.Trim();
                        cmd.Parameters.Add(new SqlParameter("@ProductID", SqlDbType.Int));
                        cmd.Parameters["@ProductID"].Value = orderdetailProductIdtxt.Text.Trim();
                        cmd.Parameters.Add(new SqlParameter("@Quantity", SqlDbType.Int));
                        cmd.Parameters["@Quantity"].Value = orderdetailquantitytxt.Text.Trim();
                        cmd.Parameters.Add(new SqlParameter("@UnitPrice", SqlDbType.Decimal));
                        cmd.Parameters["@UnitPrice"].Value = orderdetailPricetxt.Text.Trim();
                        cmd.Parameters.Add(new SqlParameter("@SubTotal", SqlDbType.Decimal));
                        cmd.Parameters["@SubTotal"].Value = orderdetatilsubTotaltxt.Text.Trim();

                        cnn.Open();
                        rowsAffected = cmd.ExecuteNonQuery();
                        //cnn.Close();
                    }
                }

                if (rowsAffected > 0)
                {
                    MessageBox.Show("更新資料成功");
                }
                else
                {
                    MessageBox.Show("找不到該筆資料，未進行任何更新。");
                }
                //custitems.Add(new Customer { CustomerName = custnametxt.Text.Trim(), Region = regioncombo.Text.Trim(), PaymentMethods = paycombo.Text.Trim() });
                SalesDetail selectedItem = orderdetaildgv.CurrentRow?.DataBoundItem as SalesDetail;
                int index = 0;

                if (orderdetaildgv.CurrentRow != null && orderdetaildgv.CurrentRow.Index >= 0)
                {
                    for (int i = 0; i < orderdetailitems.Count; i++)
                    {
                        if (orderdetailitems[i].DetailID == selectedItem.DetailID)
                        {
                            index = i;
                            break;
                        }
                    }

                    orderdetailitems[index].SaleID = Convert.ToInt32(orderdetailIDtxt.Text.Trim());
                    orderdetailitems[index].ProductID = Convert.ToInt32(orderdetailProductIdtxt.Text.Trim());
                    orderdetailitems[index].Quantity = Convert.ToInt32(orderdetailquantitytxt.Text.Trim());
                    orderdetailitems[index].UnitPrice = Convert.ToDecimal(orderdetailPricetxt.Text.Trim());
                    orderdetailitems[index].SubTotal = Convert.ToDecimal(orderdetatilsubTotaltxt.Text.Trim());
                }


                orderdetailbs.ResetBindings(false);


            }
            catch (Exception ex)
            {
                cnn.Close();
                MessageBox.Show(ex.Message + ", 更新資料發生錯誤");
            }
            finally
            {
                cmd.Parameters.Clear();
            }
        }

        private void orderdetaildeletebtn_Click(object sender, EventArgs e)
        {
            int rowsAffected = 0;

            try  //使用try...catch...敘述來補捉異動資料可能發生的例外 
            {
                //MessageBox.Show($"新增:{connectionString}");
                using (cnn = new SqlConnection(connectionString))
                {
                    string sql = "DELETE FROM SalesDetail  WHERE DetailID = @DetailID";
                    using (cmd = new SqlCommand(sql, cnn))
                    {

                        cmd.CommandText = sql;
                        cmd.Parameters.Add(new SqlParameter("@DetailID", SqlDbType.Int));
                        cmd.Parameters["@DetailID"].Value = numberIDtxt.Text.Trim();

                        cnn.Open();
                        rowsAffected = cmd.ExecuteNonQuery();
                        //cnn.Close();
                    }
                }

                if (rowsAffected > 0)
                {
                    MessageBox.Show("刪除資料成功");
                }
                else
                {
                    MessageBox.Show("找不到該筆資料，未進行任何更新。");
                }
                //custitems.Add(new Customer { CustomerName = custnametxt.Text.Trim(), Region = regioncombo.Text.Trim(), PaymentMethods = paycombo.Text.Trim() });
                SalesDetail selectedItem = orderdetaildgv.CurrentRow?.DataBoundItem as SalesDetail;
                int index = 0;

                if (orderdetaildgv.CurrentRow != null && orderdetaildgv.CurrentRow.Index >= 0)
                {
                    /*
                    for (int i = 0; i < custitems.Count; i++)
                    {
                        if (custitems[i].customerID == selectedItem.customerID)
                        {
                            index = i;
                            break;
                        }
                    }
                    */
                    orderdetailitems.Remove(selectedItem);
                    orderdetailcount--;
                }


                orderdetailbs.ResetBindings(false);


            }
            catch (Exception ex)
            {
                cnn.Close();
                MessageBox.Show(ex.Message + ", 更新資料發生錯誤");
            }
            finally
            {
                cmd.Parameters.Clear();
            }
        }

        private void orderdetailsortbtn_Click(object sender, EventArgs e)
        {

            if (orderdetailItemssortflag == 0)
            {
                // 1. 使用 LINQ 對原本的資料進行排序
                var sortedList = orderdetailitems.OrderByDescending(x => x.DetailID).ToList();
                // 2. 清空原本的 BindingList 並重新加入排序後的資料

                orderdetailitems.Clear();
                foreach (var item in sortedList)
                {
                    orderdetailitems.Add(item);
                }

                // 3. 通知 UI 更新

                orderdetailbs.ResetBindings(false);
                orderdetailItemssortflag = 1;
            }
            else if (orderdetailItemssortflag == 1)
            {
                // 1. 使用 LINQ 對原本的資料進行排序
                var sortedList = orderdetailitems.OrderBy(x => x.DetailID).ToList();
                // 2. 清空原本的 BindingList 並重新加入排序後的資料

                orderdetailitems.Clear();
                foreach (var item in sortedList)
                {
                    orderdetailitems.Add(item);
                }


                orderdetailbs.ResetBindings(false);
                orderdetailItemssortflag = 0;
            }
        }

        private void VIPcheckbtn_Click(object sender, EventArgs e)
        {
            int countline = 0;
            string sql = @"SELECT CustomerID 客戶序號 ,CustomerName 客戶名稱 FROM Customers WHERE CustomerID =@CustomerID ;";
            using (cnn = new SqlConnection(connectionString))
            {
                using (cmd = new SqlCommand(sql, cnn))
                {
                    custdt.Clear();
                    custitems.Clear();
                    if (VIPIDtxt.Text.Trim() != "" && int.TryParse(VIPIDtxt.Text.Trim(), out _))
                    {
                        cmd.Parameters.Add(new SqlParameter("@CustomerID", SqlDbType.Int));
                        cmd.Parameters["@CustomerID"].Value = VIPIDtxt.Text.Trim();
                    }
                    else if (VIPIDtxt.Text.Trim() == "")
                    {
                        cmd.Parameters.Add(new SqlParameter("@CustomerID", SqlDbType.Int));
                        cmd.Parameters["@CustomerID"].Value = "0";//散戶
                    }
                    else if (!int.TryParse(VIPIDtxt.Text.Trim(), out _))
                    {
                        MessageBox.Show("請輸入整數");
                        cmd.Parameters.Add(new SqlParameter("@CustomerID", SqlDbType.Int));
                        cmd.Parameters["@CustomerID"].Value = "0";//散戶
                    }
                    adapter = new SqlDataAdapter(cmd);
                    countline = adapter.Fill(custdt);
                    if (countline == 1)
                    {
                        custitems = custdt.AsEnumerable().Select(row => new Customer
                        {
                            customerID = row.Field<int>("客戶序號"),
                            CustomerName = row.Field<string>("客戶名稱"),

                        }).ToList();
                        foreach (var item in custitems)
                        {
                            if (item.customerID != 0) {
                                custIDtemp = item.customerID;
                                showVIPmessiagelab.Text = $"~~~~歡迎尊貴VIP會員 {item.CustomerName}先生/女士~~~~";
                            }
                            else
                                showVIPmessiagelab.Text = $"目前身分非會員";
                        }
                    }
                    else
                    {
                        custIDtemp = 0;
                        showVIPmessiagelab.Text = $"目前身分非會員";
                        //MessageBox.Show("非會員");
                    }
                    //dt = ds.Tables["Products"];
                }
            }
        }

        private void VIPIDtxt_TextChanged(object sender, EventArgs e)
        {
            if (VIPIDtxt.Text == "")
            {
                custIDtemp = 0;
                showVIPmessiagelab.Text = $"目前身分非會員";
            }
        }

        /*  private void label2_Click(object sender, EventArgs e)
          {

          }*/
    }
}
