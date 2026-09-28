---
title: 部署與啟用
type: docs
weight: 20
url: /zh-hant/sharepoint/deployment-and-activation/
description: "當 Aspose.Slides for SharePoint 解決方案部署至伺服器農場時所安裝的內容，以及啟用其網站集合功能時所新增的項目。"
---
## **部署**

在部署過程中，Aspose.Slides for SharePoint 解決方案會：

- 將其組件安裝到全域組件快取 (Global Assembly Cache)，並在 **web.config** 檔案中加入 SafeControl 項目。對於 SharePoint 2010 及之後的版本，該組件為 *Aspose.Slides.SharePoint2010.dll*、*Aspose.Slides.SharePoint2013.dll* 或 *Aspose.Slides.SharePoint2016.dll*（SharePoint 2019 套件也會安裝 *Aspose.Slides.SharePoint2016.dll*）。對於 SharePoint 2007，則是 *Aspose.Slides.SharePointUI.dll*，以及 *Aspose.Slides.SharePoint.Deployment.dll*。
- 將轉換頁面及其圖像與其他支援檔案複製到 SharePoint 安裝資料夾。
- 安裝功能，並使其可在網站集合上進行啟用。

## **啟用**

Aspose.Slides for SharePoint 以網站集合功能的形式封裝，可在網站集合上啟用或停用。啟用於網站集合時，該功能會加入以下項目：

- 在 SharePoint 2010 及之後的版本：
  - 將 **Convert via Aspose.Slides** 項目加入至文件庫中文件的功能表；
  - 在功能區加入 **Aspose Tools** 標籤，內含 **Convert Slides** 按鈕，可轉換所選文件；
  - 將 **View Slides** 項目加入 PPT、PPTX、PPS 與 PPSX 檔案的功能表。
- 在 SharePoint 2007：
  - 將 **Convert with Aspose.Slides** 項目加入文件庫中文件的功能表；
  - 將 **Convert All with Aspose.Slides** 項目加入文件庫的 **Actions** 功能表。

在 SharePoint 2007 上，啟用同時會對網站集合之父 Web 應用程式的虛擬目錄進行變更。它：

- 將轉換設定頁面加入至 sitemap 檔案。
- 將必要的資源檔案複製到虛擬目錄中的 App_GlobalResources 資料夾。

安裝程式會在您於[安裝](/slides/zh-hant/sharepoint/installing-aspose-slides-for-sharepoint/)階段選取的網站集合上啟用此功能。