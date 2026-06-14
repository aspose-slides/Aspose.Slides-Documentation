---
title: 簡介與環境設定
type: docs
weight: 10
url: /zh-hant/reportingservices/introduction-and-environment-setup/
---
{{% alert color="primary" %}} 

過去曾有關於 Aspose.Slides 與 Reporting Services 在 SharePoint 中整合的詢問。在本篇文章中，我們將聚焦於 SharePoint 2010。假設您已經建立了 SharePoint 農場環境。本文所示範的範例將使用完整的 SharePoint 雲端環境，但步驟對於 SharePoint Foundation 伺服器亦相似。在繼續之前，先從以下關鍵文件開始，您可以將其作為參考：

- [Reporting Services 與 SharePoint 技術整合概觀](https://docs.microsoft.com/en-us/previous-versions/sql/sql-server-2008-r2/bb326358(v=sql.105))
- [設定 Reporting Services 以整合 SharePoint 2010](https://docs.microsoft.com/en-us/previous-versions/sql/)

{{% /alert %}} 
#### **環境設定**
我們的設定將包含 **4 台伺服器**。其中包括 **Domain Controller**、**SQL Server**、**SharePoint Server** 以及 **Reporting Services** 伺服器。您可以選擇將 SharePoint 與 Reporting Services 部署在同一台機器上。