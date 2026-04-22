# AssetManager

一個用於管理個人資產與資金分配的系統，透過 ASP.NET Core Web API 建立。

---

## 📌 專案介紹

AssetManager 的目標是幫助使用者：

* 清楚掌握目前所有資產（銀行存款、股票、借貸）
* 將資金依用途分配（例如：緊急備用金、日本留學、治裝費等）
* 計算「自由額度」（實際可自由使用的金額）
* 了解資產結構與分布

本專案以「資金用途管理」為核心，而不只是單純記帳或投資紀錄。

---

## 🚀 目前版本

### v0.1.0

* 建立 ASP.NET Core Web API 專案
* 成功啟用 Swagger（API 測試介面）
* 完成 Git 與 GitHub 專案初始化

---

### v0.2.0

* 完成 BankAccount API（In-Memory CRUD）
* 支援以下操作：

  * GET /api/BankAccounts
  * GET /api/BankAccounts/{id}
  * POST /api/BankAccounts
  * PUT /api/BankAccounts/{id}
  * DELETE /api/BankAccounts/{id}
* 使用 List<T> 模擬資料庫（重新啟動後資料會重置）

---

### v0.3.0

* 建立 DTO 架構（Create / Update / Response）
* 使用 Data Annotations 加入欄位驗證
* API 改為使用 DTO，不再直接暴露 Model
* 實作 Model → Response DTO 的轉換
* 將刪除改為軟刪除（使用 IsActive）
* GetAll 僅回傳啟用中的帳戶

---

### v0.4.0

* 導入 Service Layer，將商業邏輯從 Controller 中分離
* 建立 BankAccountService 負責資料操作與邏輯處理
* Controller 僅負責處理 HTTP Request/Response
* 提升程式結構與可維護性

---

### v0.5.0

* 導入 Dependency Injection（DI）
* 使用建構子注入 Service
* 在 Program.cs 註冊 Service
* 移除 Controller 中手動 new Service
* 降低耦合度，提高可測試性

---

### v0.6.0

* 導入 Interface（IBankAccountService）作為服務層抽象
* Service 實作 Interface
* Controller 依賴 Interface（非具體類別）
* DI 改為 Interface 對應實作
* 提升系統彈性與可擴展性

---

### v0.7.0

* 導入 Entity Framework Core + SQLite
* 建立 AppDbContext 管理資料庫
* 使用 DbSet 定義資料表
* CRUD 改為透過資料庫操作
* 使用 Migration 建立資料表
* 資料持久化（重啟後仍保留）
* 修正 DI 為 Scoped（支援 DbContext）

---

### 🔧 v0.7.1 - Refactor Service Layer (DTO handling)

本版本進行架構優化，重點在於 **DTO 處理責任的重新分配**

#### ✨ 改動內容

* Service 改為直接回傳 DTO（不再回傳 Entity）
* DTO mapping 從 Controller 移至 Service
* Controller 移除所有轉換邏輯（如 ToResDto）
* Controller 不再操作 Entity

---

#### 🎯 改動目的

* 降低 Controller 複雜度（避免變胖）
* 避免資料模型（Entity）外洩
* 提升系統分層清晰度
* 為未來 Fund / Summary 功能做準備

---

#### 🔄 優化後資料流

```
Client → Controller → Service → DB
                         ↓
                      DTO
```

---

## 🧩 預計功能

* 銀行帳戶管理（BankAccount）
* 資金用途管理（Fund）🔥
* 股票持有管理（StockHolding）
* 借貸紀錄（DebtRecord）
* 每月預留支出（MonthlyPay）
* 自由額度計算（核心功能）
* 總資產與資產分布分析

---

## 🛠 技術架構

* C#
* ASP.NET Core Web API
* Entity Framework Core
* SQLite
* Swagger（OpenAPI）
* Git / GitHub

---

## 📈 開發路線（更新後）

* v0.7.1：Service Layer 重構（完成）
* v0.8：Fund（資金用途）🔥
* v0.9：Allocation（資金流）
* v1.0：Summary（自由額度計算）

---

## 📬 備註

本專案為個人學習與實作專案，採用逐步版本迭代方式開發。
重點在於建立正確的系統設計思維與後端架構能力，而非僅完成功能。
