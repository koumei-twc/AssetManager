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

### v0.2.0

* 完成 BankAccount API（In-Memory CRUD）
* 支援以下操作：

  * GET /api/BankAccounts（取得全部帳戶）
  * GET /api/BankAccounts/{id}（取得單一帳戶）
  * POST /api/BankAccounts（新增帳戶）
  * PUT /api/BankAccounts/{id}（更新帳戶）
  * DELETE /api/BankAccounts/{id}（刪除帳戶）
* 加入基本資料驗證（Name 不可為空）
* 使用 List<T> 模擬資料庫（重新啟動後資料會重置）

### v0.3.0
- 建立 DTO 架構（Create / Update / Response）
- 使用 Data Annotations 加入欄位驗證
- API 改為使用 DTO，不再直接暴露 Model
- 實作 Model → Response DTO 的轉換
- 抽出共用轉換方法（ToResDto）
- 將刪除改為軟刪除（使用 IsActive）
- GetAll 僅回傳啟用中的帳戶

---

## 🧩 預計功能

* 銀行帳戶管理（BankAccount）
* 資金用途管理（Fund）
* 股票持有管理（StockHolding）
* 借貸紀錄（DebtRecord）
* 每月預留支出（MonthlyPay）
* 自由額度計算（核心功能）
* 總資產與資產分布分析

---

## 🛠 技術架構

* C#
* ASP.NET Core Web API
* Swagger（OpenAPI）
* Git / GitHub
* In-Memory Data Storage（v0.2.0）

---

## 📈 開發進度（預計）

* v0.2.0：BankAccount API（CRUD 完成）
* v0.3.0：Fund API
* v0.4.0：MonthlyPay API
* v0.5.0：DebtRecord API
* v0.6.0：StockHolding API
* v0.7.0：Summary（資產計算）
* v1.0.0：完整第一版

---

## 📬 備註

本專案為個人學習與實作專案，會逐步優化架構與功能，並模擬實際專案開發流程（版本控制、模組拆分、API 設計等）。
