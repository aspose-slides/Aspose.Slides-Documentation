---
title: 部署與啟用
type: docs
weight: 20
url: /zh-hant/sharepoint/deployment-and-activation/
---
## **部署**
在部署期間，Aspose.Slides for SharePoint：

- 將 **Aspose.Slides.SharePoint.dll** 安裝到全域組件快取 (Global Assembly Cache)，並在 **web.config** 檔案中新增 SafeControl 項目。
- 將功能宣告以及其他必要檔案安裝至相應目錄。
- 在 SharePoint 資料庫中註冊功能，並使其在功能範圍內可供啟用。
## **啟用**
Aspose.Slides for SharePoint 以網站（網站集合）層級功能的形式封裝，可在網站集合上啟用或停用。啟用時，該功能會對網站集合之父 Web 應用程式的虛擬目錄進行一些變更。它：

- 將轉換設定頁面新增至 sitemap 檔案。
- 將必要的資源檔案複製到虛擬目錄中的 App_GlobalResources 資料夾。