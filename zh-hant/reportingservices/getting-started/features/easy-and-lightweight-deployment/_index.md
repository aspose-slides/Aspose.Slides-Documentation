---
title: 簡易且輕量化部署
type: docs
weight: 50
url: /zh-hant/reportingservices/easy-and-lightweight-deployment/
---
{{% alert color="primary" %}} 

Aspose.Slides for Reporting Services 是一個 [渲染擴充套件](http://msdn2.microsoft.com/en-us/library/ms154606.aspx) ，用於 Microsoft SQL Server Reporting Services。  
Aspose.Slides for Reporting Services 以單一 MSI 安裝程式提供，可安裝於執行下列其中一項的電腦上：

- Microsoft SQL Server 2005 Reporting Services（32-bit 和 64-bit）
- Microsoft SQL Server 2008 Reporting Services（32-bit 和 64-bit）

手動部署與管理 Aspose.Slides for Reporting Services 也相當簡易，因為它僅由一個 .NET 組件 *Aspose.Slides* *.ReportingServices.dll* 組成，完全以 C# 撰寫，符合 CLS，且只包含安全的受管理程式碼。

{{% /alert %}} 

MSI 安裝程式與 ZIP 下載檔案均包含 Aspose.Slides for ReportingServices：

- Bin\SSRS2005\Aspose.Slides.ReportingServices.dll – 為 Microsoft SQL Server 2005 與 .NET Framework 2.0 所建置（適用於 x86 與 x64）
- Bin\SSRS2008\Aspose.Slides.ReportingServices.dll – 為 Microsoft SQL Server 2008 與 .NET Framework 2.0 所建置（適用於 x86 與 x64）

安裝時，Aspose.Slides.ReportingServices.dll 會複製到 ReportServer\bin 目錄，且會更新設定檔讓 Reporting Services 知曉新的渲染擴充套件。這些步驟由 Aspose.Slides for Reporting Services 安裝程式執行，但您也可以依照本文件後續說明自行手動執行。

![todo:image_alt_text](easy-and-lightweight-deployment_1.png)

**圖**: Aspose.Slides.ReportingServices.dll 已複製至 **ReportServer\bin** 目錄。