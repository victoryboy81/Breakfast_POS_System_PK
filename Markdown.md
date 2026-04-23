# 專案架構與需求規格書：早餐店購物車與互動折扣系統 (WinForms)

## 1. 專案概述 (Project Overview)
本專案為一個基於 **C# Windows Forms (WinForms)** 的桌面應用程式。主要功能為「早餐店點餐購物車」，包含完整的購物車 CRUD（新增、刪除、更新、查詢）功能、訂單預覽列印，以及一個結合「打鱷魚遊戲 (Whack-a-Crocodile)」的互動式折扣系統。

## 2. 技術棧 (Tech Stack)
* **語言**: C#
* **框架**: .NET 6.0 (或更新版本) / .NET Framework 4.8
* **UI 技術**: Windows Forms (WinForms)及盡量優先運用如Form1.Designer.cs規劃UI
* **架構模式**: 建議採用 MVP (Model-View-Presenter) 或事件驅動的模組化架構，以分離 UI 與業務邏輯。

## 3. 資料模型定義 (Data Models)
請在實作時建立以下核心類別 (C# Classes)：

* **`MenuItem` (菜單項目)**:
    * `Id` (int)
    * `Name` (string) - 例如：火腿蛋吐司、大冰奶、蘿蔔糕
    * `Price` (decimal)
    * `Category` (string)
* **`CartItem` (購物車項目)**:
    * `CartItemId` (string/Guid)
    * `MenuItem` (MenuItem)
    * `Quantity` (int)
    * `SubTotal` (decimal) -> `MenuItem.Price * Quantity`
* **`Order` (訂單)**:
    * `Items` (List<CartItem>)
    * `OriginalTotal` (decimal)
    * `DiscountRate` (decimal) - 預設為 1.0 (無折扣)
    * `FinalTotal` (decimal) -> `OriginalTotal * DiscountRate`

## 4. UI 介面與功能模組 (UI & Modules)

### 4.1 主視窗 (`MainForm`)
負責菜單展示與購物車的 CRUD 操作。
* **元件配置**:
    * `DataGridView` (或 `ListView`) x1：顯示菜單 (Menu)。
    * `DataGridView` x1：顯示當前購物車內容 (Cart)。
    * `TextBox` x1：用於查詢/過濾菜單項目 (Read/Search)。
    * `NumericUpDown` x1：選擇數量。
    * `Button` (加入購物車 - Create)：將選定菜單項目加入購物車。
    * `Button` (更新數量 - Update)：修改購物車內項目的數量。
    * `Button` (刪除項目 - Delete)：移除購物車內的指定項目。
    * `Label`：顯示總金額。
    * `Button` (抽取折扣 - 打鱷魚)：開啟 `GameForm`。
    * `Button` (結帳與預覽列印)：觸發 `PrintPreviewDialog`。

### 4.2 互動遊戲視窗 (`GameForm` - 打鱷魚遊戲)
用於獲取折扣的互動遊戲介面。
* **遊戲邏輯**:
    * 使用 3x3 的 `PictureBox` 或 `Button` 陣列作為地洞。
    * 使用 `System.Windows.Forms.Timer` 控制「鱷魚」隨機出現與消失的頻率 (例如每 800ms)。
    * 玩家點擊出現鱷魚的控制項即可得分 (`Score`)。
    * 遊戲限時 (例如 15 秒)。
* **折扣結算規則**:
    * `Score >= 20`: 7 折 (DiscountRate = 0.7)
    * `Score >= 10`: 85 折 (DiscountRate = 0.85)
    * `Score >= 5`: 9 折 (DiscountRate = 0.9)
    * `Score < 5`: 95 折 (DiscountRate = 0.95)
* **回傳機制**: 遊戲結束後，關閉 `GameForm` 並將 `DiscountRate` 回傳給 `MainForm` 重新計算總價。

### 4.3 列印預覽模組 (Print Module)
* **使用類別**: `System.Drawing.Printing.PrintDocument` 與 `System.Windows.Forms.PrintPreviewDialog`。
* **繪製邏輯 (`PrintPage` 事件)**:
    * 使用 `Graphics.DrawString` 繪製標題：「活力早晨早餐店 - 訂單明細」。
    * 迭代 `Order.Items`，逐行繪製品項名稱、數量、單價與小計。
    * 繪製分隔線。
    * 繪製原始總計、折扣成數 (由打鱷魚遊戲決定)、最終結帳總金額。

## 5. 實作步驟指南 (Implementation Steps for AI)
請 AI 依照以下順序生成程式碼：
1.  **Step 1**: 建立基本的 Data Models (`MenuItem`, `CartItem`, `Order`)，並在主程式初始化一份靜態的早餐店菜單資料 (假資料 Mock Data)。
2.  **Step 2**: 實作 `MainForm` UI 佈局，並綁定 DataGridView。完成購物車的 CRUD 核心邏輯 (加入、修改數量、刪除、關鍵字查詢菜單)。
3.  **Step 3**: 實作 `GameForm` 打鱷魚遊戲視窗，設定 Timer 與點擊事件，並計算分數與對應折扣，將結果傳遞回 `MainForm`。
4.  **Step 4**: 實作 `PrintDocument` 的 `PrintPage` 事件，將購物車內容格式化輸出，並透過 `PrintPreviewDialog` 顯示。

## 6. 注意事項
* 介面需保持友善，遊戲視窗的計時器需在關閉時正確 Dispose。
* 金額計算請務必使用 `decimal` 型別以避免浮點數誤差。
* 程式碼需包含適當的中文註解，解釋核心演算法（特別是遊戲與列印的排版邏輯）。