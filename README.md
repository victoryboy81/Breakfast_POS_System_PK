# 早餐店購物車與互動折扣系統 (Breakfast Cart & Interactive Discount System)

這是一個基於 **C# Windows Forms (WinForms)** 開發的桌面應用程式，旨在提供直觀的早餐點餐體驗，並結合趣味性的「打鱷魚」遊戲來決定結帳折扣。

## 1. 系統概述 (System Overview)
本系統模擬現代早餐店的數位點餐流程，包含菜單瀏覽、購物車管理、動態折扣獲取以及訂單列印預覽。系統採用事件驅動架構，確保 UI 響應流暢，並透過數據綁定 (Data Binding) 技術實現資料與介面的即時同步。

---

## 2. 技術規格 (Technical Stack)
*   **開發框架**: .NET 6.0 (Windows Forms)
*   **程式語言**: C# 10.0
*   **介面技術**: WinForms GDI+ (用於列印與遊戲渲染)
*   **資料管理**: `BindingList<T>` 實現資料與 DataGridView 的自動雙向同步
*   **專案結構**: 
    *   `Models.cs`: 定義核心業務實體。
    *   `MainForm`: 主控介面，處理點餐與購物車邏輯。
    *   `GameForm`: 互動遊戲模組，處理折扣演算法。
    *   `Program.cs`: 系統環境初始化。

---

## 3. 核心功能模組 (Functional Modules)

### 3.1 菜單與搜尋系統 (Menu & Search)
*   **菜單展示**: 使用 `DataGridView` 顯示預設的早餐品項（吐司、蛋餅、飲料等）。
*   **關鍵字過濾**: 支援即時搜尋功能，使用者輸入關鍵字時，菜單會自動過濾匹配的品項名稱。

### 3.2 購物車 CRUD 管理 (Cart Management)
*   **新增 (Create)**: 選擇菜單項目與數量後，加入購物車。若品項已存在，則自動累加數量。
*   **讀取 (Read)**: 即時計算並顯示各品項小計、原始總額、折扣成數及最終應付金額。
*   **更新 (Update)**: 選取購物車項目後，可透過數量調整控制項修改該品項的購買數量。
*   **刪除 (Delete)**: 支援移除購物車中的指定品項。

### 3.3 互動折扣遊戲 (Interactive Game - Whack-a-Crocodile)
為了增加系統趣味性，結帳前可進入「打鱷魚遊戲」抽取折扣：
*   **遊戲機制**: 3x3 地洞陣列，隨機出現鱷魚標記 (🐊)，玩家需在 15 秒內點擊得分。
*   **折扣規則**:
    *   **20 分以上**: 7 折 (大獎)
    *   **10 ~ 19 分**: 85 折
    *   **5 ~ 9 分**: 9 折
    *   **5 分以下**: 95 折 (安慰獎)

### 3.4 訂單列印預覽 (Print Preview)
*   使用 `PrintDocument` 自定義繪圖邏輯。
*   產出包含店名、品項明細（單價、數量、小計）、折扣資訊及最終結帳總額的專業收據格式。

---

## 4. 資料模型 (Data Models)
*   **`MenuItem`**: `Id`, `Name`, `Price`, `Category`
*   **`CartItem`**: `CartItemId`, `Item`, `Quantity`, `SubTotal`
*   **`Order`**: `Items`, `OriginalTotal`, `DiscountRate`, `FinalTotal`

---

## 5. 安裝與執行 (Installation & Running)
1.  確保您的環境已安裝 **.NET 6.0 SDK** 或更新版本。
2.  將本專案原始碼存放在同一目錄下。
3.  在終端機執行以下指令啟動程式：
    ```bash
    dotnet run
    ```

---

## 6. 注意事項 (Notes)
*   **精確度**: 金額計算一律使用 `decimal` 型別，確保財務計算無浮點數誤差。
*   **UI 體驗**: 建議在支援 High DPI 的顯示器上運行，系統已開啟 `SystemAware` 模式以保持介面清晰。
*   **遊戲資源**: 遊戲圖示採用標準 Unicode Emoji (🐊, 💥)，無需額外圖片資源，具備高度可移植性。

---
**本系統由資深架構師規劃開發，具備良好的擴展性與維護性。**
