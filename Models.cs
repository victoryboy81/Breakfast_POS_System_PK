using System;
using System.Collections.Generic;

namespace BreakfastCart
{
    // 菜單項目
    public class MenuItem
    {
        public int Id { get; set; }
        //public int 產品序號 { get; set; }
        public string Name { get; set; }
        
        //public string 品項 { get; set; }
        
        public decimal Price { get; set; }
        //public decimal 單價 { get; set; }
        

        
        public string ImagePath { get; set; }
        //public string 圖片路徑 { get; set; }
        // 將圖片直接封裝在 Model 中，DataGridView 會自動 Binding
        public Image ProductPic { get; set; }
        public string DisplayName { get; set; } // 用於顯示
        public string Category { get; set; }
    }

    // 購物車項目
    public class CartItem
    {
        public string CartItemId { get; set; }
        public int Id { get; set; }
        public string ItemName { get; set; }
        public decimal Price { get; set; }


        
        public int Quantity { get; set; }
        public decimal SubTotal { get; set; }
        public MenuItem Item { get; set; }
        // 唯讀屬性方便 DataGridView 綁定顯示


       
    }

    // 訂單
    public class Order
    {
        //public List<CartItem> Items { get; set; } = new List<CartItem>();
        public List<CartItem> Items { get; set; }
        public decimal OriginalTotal {get;set;}
        public decimal quantityTotal { get; set; }
        public decimal DiscountRate { get; set; }  // 預設無折扣

        public decimal FinalTotal { get; set; }// 四捨五入到整數
    }
    //客戶
    public class Customer
    {
        public int customerID{get;set;}
        public string CustomerName { get; set; }
        public string Region { get; set; }
        public string PaymentMethods { get; set; }
     }

    //銷售主檔
    public class SalesMaster
    {
        public int SaleID { get; set; }
        public int CustomerID { get; set; }
        public DateTime SaleDate { get; set; }
        public int TotalQuantity { get; set; }
        public decimal TotalAmount { get; set; }

    }
    //銷售明細檔資料表
    public class SalesDetail
    {
        public int DetailID { get; set; }
        public int SaleID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal SubTotal { get; set; }

    }


}
