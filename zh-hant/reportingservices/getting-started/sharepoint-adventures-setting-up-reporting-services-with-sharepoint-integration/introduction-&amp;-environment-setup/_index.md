---
title: 簡介 &amp; 環境設定
type: docs
weight: 10
url: /zh-hant/reportingservices/introduction-&amp;-environment-setup/
---
{{% alert color="primary" %}} 

過去曾有關於 Aspose.Slides 與 Reporting Services 在 SharePoint 上整合的查詢。在本文中，我們將聚焦於 SharePoint 2010。假設您已經建立了 SharePoint Farm 環境。本文中所示範的範例將使用完整的 SharePoint Cloud，但對於 SharePoint Foundation Server，步驟也相似。在繼續之前，讓我們先看看一些您可以參考的關鍵文件：

- [Reporting Services 與 SharePoint 技術整合概覽](https://docs.microsoft.com/en-us/previous-versions/sql/sql-server-2008-r2/bb326358(v=sql.105))
- [設定 Reporting Services 以整合 SharePoint 2010](https://docs.microsoft.com/en-us/previous-versions/sql/)

{{% /alert %}} 
#### **環境設定**
我們的設定包含 **4 台伺服器**。其中包括 **網域控制器**、**SQL Server**、**SharePoint Server** 以及 **Reporting Services** 伺服器。您也可以選擇在同一台機器上同時執行 SharePoint 與 Reporting Services。