---
title: 使用 MSI 安裝程式安裝
type: docs
weight: 20
url: /zh-hant/reportingservices/install-with-msi-installer/
keywords:
- MSI 安裝程式
- 安裝
- SQL Server Reporting Services
- Power BI Report Server
- Aspose.Slides for Reporting Services
description: "使用 MSI 安裝程式安裝 Aspose.Slides for Reporting Services：安裝程式的需求、在每個報表伺服器實例上所做的變更，以及如何檢查結果。"
---
## **安裝**

MSI 安裝程式是安裝 Aspose.Slides for Reporting Services 最簡單的方式。它需要 .NET Framework 3.5 與報表伺服器的管理員權限；請參閱[系統需求](/slides/zh-hant/reportingservices/system-requirements/)。

1. 從[下載頁面](https://releases.aspose.com/slides/zh-hant/reportingservices/)下載 MSI 安裝程式 *Aspose.Slides for Reporting Services XX.XX*，並將其複製至報表伺服器。
2. 以管理員身分執行。如缺少 .NET Framework 3.5，安裝程式會停下並顯示訊息；請安裝 .NET Framework 3.5 功能後重新執行。
3. 同意授權條款。
4. 在 **Custom Setup** 頁面，功能樹會列出安裝程式在機器上偵測到的每個 SQL Server Reporting Services 與 Power BI Report Server 實例。若要保持某個實例不變，點選其圖示並選取 **Entire feature will be unavailable**。Express 版不支援呈現擴充功能，請勿選取 Express 實例。安裝程式會隱藏 SQL Server 2016 及更早版本的 Express 實例。
5. 按 **Next**，然後 **Install**。

預設未選取可選的 **Rpl Export** 功能。它會新增一個隱藏的擴充功能，以 RPL 格式儲存報表，當您向 Aspose 送出問題報告時相當有用；請參閱[匯出報表為 RPL 格式](/slides/zh-hant/reportingservices/exporting-reports-to-rpl-format/)。

## **安裝程式的變更**

安裝程式會將檔案保存在 *Program Files* 資料夾下的 *Aspose\Aspose.Slides for Reporting Services* 中——在 64 位元 Windows 上為 *Program Files (x86)*，因為安裝程式是 32 位元套件。然後，對於每個選取的實例，它會：

- 將 *Aspose.Slides.ReportingServices.dll* 複製到實例的 *ReportServer\bin* 資料夾——此為 SQL Server 2005 的組建，或 SQL Server 2008 及之後版本與 Power BI Report Server 的組建；
- 將六個呈現擴充功能——ASPPT、ASPPS、ASPPTX、ASPPSX、ASXPSS 與 ASODP——加入 *rsreportserver.config* 的 `<Render>` 元素；
- 在 *rssrvpolicy.config* 中新增一個代碼群組，授予組件完全信任；
- 為每個變更的組態檔儲存一個副本，檔名加上 *.bak*。

[手動安裝](/slides/zh-hant/reportingservices/install-manually/) 逐步說明這些變更。

如果無法為某個實例進行設定，安裝程式會在訊息中列出該實例，並將詳細資訊寫入安裝資料夾中的 *rserrors<date>.log*。請對該實例手動安裝擴充功能。

## **檢查安裝**

在 Web 入口網站（SQL Server 2014 及以前版本的 Report Manager）中開啟分頁報表，然後開啟 **Export** 清單。現在會包含以下格式：

- PPT - PowerPoint 簡報（使用 Aspose.Slides）
- PPS - PowerPoint 投影片放映（使用 Aspose.Slides）
- PPTX - PowerPoint 2007 簡報（使用 Aspose.Slides）
- PPSX - PowerPoint 2007 投影片放映（使用 Aspose.Slides）
- ODP - OpenDocument 簡報（使用 Aspose.Slides）
- XPS - 使用 Aspose.Slides

若未購買授權，匯出的檔案會帶有評估水印；請參閱[授權](/slides/zh-hant/reportingservices/license-aspose-slides-for-reporting-services/)。

## **何時手動安裝**

當以下情況發生時，請改為[手動安裝](/slides/zh-hant/reportingservices/install-manually/)：

- 安裝程式無法設定實例，例如伺服器上的安全性設定阻止；
- 升級後只想取代組件，而不願解除舊版並重新執行新安裝程式。

解除安裝產品會從每個實例中移除組件與組態項目。