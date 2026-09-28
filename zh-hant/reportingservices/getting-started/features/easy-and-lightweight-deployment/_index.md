---
title: 簡易且輕量的部署
type: docs
weight: 50
url: /zh-hant/reportingservices/easy-and-lightweight-deployment/
description: "了解 Aspose.Slides for Reporting Services 的部署方式：將組件放置於報表伺服器的 bin 資料夾，並在報表伺服器設定中註冊。"
---
{{% alert color="info" title="Note" %}}

Aspose.Slides for Reporting Services 是 Microsoft SQL Server Reporting Services 與 Power BI Report Server 的 [呈現擴充功能](https://learn.microsoft.com/en-us/sql/reporting-services/extensions/rendering-extension/rendering-extensions-overview)。
Aspose.Slides for Reporting Services 以單一 MSI 安裝程式提供，可安裝於執行受支援報表伺服器的電腦，支援 32 位元或 64 位元；請參閱 [系統需求](/slides/zh-hant/reportingservices/system-requirements/)。

手動部署與管理 Aspose.Slides for Reporting Services 也非常簡單，因為它僅包含一個 .NET 程式集 *Aspose.Slides* *.ReportingServices.dll*，完整以 C# 編寫，符合 CLS 標準，且僅包含安全的受管理程式碼。

{{% /alert %}}

ZIP 下載檔案包括兩個針對報表伺服器的 Aspose.Slides.ReportingServices.dll 組建版本：

- Bin\SSRS2005\Aspose.Slides.ReportingServices.dll – 為 Microsoft SQL Server 2005 與 .NET Framework 2.0 所建置（適用於 x86 與 x64）
- Bin\Universal\Aspose.Slides.ReportingServices.dll – 為 Microsoft SQL Server 2008 及更高版本、Power BI Report Server 與 .NET Framework 2.0 所建置（適用於 x86 與 x64）

MSI 安裝程式會安裝相同的兩個組建，並為每個報表伺服器實例挑選正確的組件。[手動安裝](/slides/zh-hant/reportingservices/install-manually/) 列出 ZIP 下載檔案中的所有檔案。

安裝時，Aspose.Slides.ReportingServices.dll 會被複製到 ReportServer\bin 目錄，並更新設定檔，使 Reporting Services 能識別新的呈現擴充功能。這些步驟由 Aspose.Slides for Reporting Services 安裝程式自動執行，但您也可以依照本文件後續說明手動執行。

![todo:image_alt_text](easy-and-lightweight-deployment_1.png)

**圖示**：Aspose.Slides.ReportingServices.dll 已複製至 **ReportServer\bin** 目錄。