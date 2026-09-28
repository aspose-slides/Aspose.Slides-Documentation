---
title: 简易且轻量级部署
type: docs
weight: 50
url: /zh/reportingservices/easy-and-lightweight-deployment/
description: "了解 Aspose.Slides for Reporting Services 的部署方式：一个程序集位于报告服务器的 bin 文件夹中，并已在报告服务器配置中注册。"
---
{{% alert color="info" title="Note" %}}
Aspose.Slides for Reporting Services 是 Microsoft SQL Server Reporting Services 和 Power BI Report Server 的 [rendering extension](https://learn.microsoft.com/en-us/sql/reporting-services/extensions/rendering-extension/rendering-extensions-overview)。

Aspose.Slides for Reporting Services 以单个 MSI 安装程序的形式提供，可在运行受支持报告服务器的计算机上安装，支持 32 位或 64 位；请参阅[System Requirements](/slides/zh/reportingservices/system-requirements/)。

手动部署和管理 Aspose.Slides for Reporting Services 也很简单，因为它仅由一个 .NET 程序集 *Aspose.Slides* *.ReportingServices.dll* 组成，完全使用 C# 编写，符合 CLS 并且仅包含安全的托管代码。
{{% /alert %}}

ZIP 下载包含两个用于报告服务器的 Aspose.Slides.ReportingServices.dll 版本：

- Bin\SSRS2005\Aspose.Slides.ReportingServices.dll – 为 Microsoft SQL Server 2005 和 .NET Framework 2.0 构建（用于 x86 和 x64）
- Bin\Universal\Aspose.Slides.ReportingServices.dll – 为 Microsoft SQL Server 2008 及更高版本、Power BI Report Server 和 .NET Framework 2.0 构建（用于 x86 和 x64）

MSI 安装程序会安装相同的两个版本，并为每个报告服务器实例选择正确的版本。[Install Manually](/slides/zh/reportingservices/install-manually/) 列出了 ZIP 下载中的所有文件。

安装时，Aspose.Slides.ReportingServices.dll 会被复制到 ReportServer\bin 目录，并更新配置文件，使 Reporting Services 能够识别新的呈现扩展。这些步骤由 Aspose.Slides for Reporting Services 安装程序执行，但您也可以按照本文档后面的说明手动执行这些步骤。

![todo:image_alt_text](easy-and-lightweight-deployment_1.png)

**图**: Aspose.Slides.ReportingServices.dll 已复制到 **ReportServer\bin** 目录。