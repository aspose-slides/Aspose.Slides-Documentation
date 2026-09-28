---
title: 系統需求
type: docs
weight: 15
url: /zh-hant/reportingservices/system-requirements/
keywords:
- 系統需求
- SQL Server Reporting Services
- SSRS
- Power BI Report Server
- .NET Framework 3.5
- Aspose.Slides for Reporting Services
description: "在安裝前，檢查 Aspose.Slides for Reporting Services 需要哪些報表伺服器、版本與 .NET Framework 版本。"
---
## **概觀**

Aspose.Slides for Reporting Services 作為渲染擴充功能在報表伺服器內部執行。本頁列出在您[安裝](/slides/zh-hant/reportingservices/installing-aspose-slides-for-reporting-services/)之前，報表伺服器機器所需的條件。Microsoft PowerPoint 和 Microsoft Office 並非必要。

## **支援的報表伺服器**

- Microsoft SQL Server 2005 Reporting Services
- Microsoft SQL Server 2008 and 2008 R2 Reporting Services
- Microsoft SQL Server 2012 Reporting Services
- Microsoft SQL Server 2014 Reporting Services
- Microsoft SQL Server 2016 Reporting Services
- Microsoft SQL Server 2017 Reporting Services
- Microsoft SQL Server 2019 Reporting Services
- Power BI Report Server，用於分頁 (RDL) 報表

同時支援 32 位元 和 64 位元 報表伺服器。SQL Server 2005 使用其自有的擴充組建；所有較新版本以及 Power BI Report Server 使用相同的組建。[手動安裝](/slides/zh-hant/reportingservices/install-manually/)顯示要複製的檔案。

如果您的報表伺服器版本不在此清單中，請在部署前於[免費支援論壇](https://forum.aspose.com/c/slides/zh-hant/11)詢問。

## **報表伺服器版本**

對於 SQL Server 2016 Reporting Services 以及更新版本，以及 Power BI Report Server，Microsoft 在 Enterprise、Standard、Developer 與 Evaluation 版本中支援渲染擴充功能；Web 與 Express 版本不支援。請參閱[Reporting Services features supported by editions](https://learn.microsoft.com/en-us/sql/reporting-services/reporting-services-features-supported-by-the-editions-of-sql-server)。MSI 安裝程式會略過 SQL Server 2016 及更早版本的 Express 實例。

## **.NET Framework**

.NET Framework 3.5 必須安裝在報表伺服器機器上。擴充組件是為 .NET Framework 2.0 執行階段建置的，如果缺少 .NET Framework 3.5，MSI 安裝程式會顯示訊息並停止。在 Windows Server 上，於「新增角色與功能精靈」中加入**.NET Framework 3.5 Features**；請參閱[在 Windows 上安裝 .NET Framework 3.5]((https://learn.microsoft.com/en-us/dotnet/framework/install/dotnet-35-windows))。

## **權限**

安裝擴充功能會變更報表伺服器資料夾中的檔案，因此兩種安裝方式皆需要本機管理員權限。若在未具備權限的情況下啟動 MSI 安裝程式，系統會提供以管理員身分重新啟動。

## **常見問題**

**我需要在報表伺服器上安裝 Microsoft PowerPoint 嗎？**

不需要。此擴充功能自行產生簡報；不必安裝 PowerPoint 或 Microsoft Office。

**我可以在 Express 版上安裝此擴充功能嗎？**

不行。Express 版不支援渲染擴充功能。MSI 安裝程式會隱藏 SQL Server 2016 及更早版本的 Express 實例；在較新版本中，請勿選取 Express 實例。

**此擴充功能在匯出清單中會加入哪些格式？**

PPT、PPS、PPTX、PPSX、ODP 以及 XPS。請參閱[Supported File Formats](/slides/zh-hant/reportingservices/supported-file-formats/)。