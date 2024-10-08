---
title: 简单轻量的部署
type: docs
weight: 50
url: /zh/reportingservices/easy-and-lightweight-deployment/
---

{{% alert color="primary" %}} 

Aspose.Slides for Reporting Services 是一个为 Microsoft SQL Server Reporting Services 提供的 [渲染扩展](http://msdn2.microsoft.com/en-us/library/ms154606.aspx)。 
Aspose.Slides for Reporting Services 作为一个单一的 MSI 安装程序提供，可以安装在运行以下任一版本的计算机上：

- Microsoft SQL Server 2005 Reporting Services (32 位和 64 位)
- Microsoft SQL Server 2008 Reporting Services (32 位和 64 位)

Aspose.Slides for Reporting Services 也是易于手动部署和管理的，因为它仅包含一个 .NET 程序集 *Aspose.Slides* *.ReportingServices.dll*，完全用 C# 编写，符合 CLS 标准，并仅包含安全的托管代码。

{{% /alert %}} 

MSI 安装程序和 ZIP 下载包包括 Aspose.Slides for ReportingServices：

- Bin\SSRS2005\Aspose.Slides.ReportingServices.dll – 为 Microsoft SQL Server 2005 和 .NET Framework 2.0 构建（用于 x86 和 x64）
- Bin\SSRS2008\Aspose.Slides.ReportingServices.dll – 为 Microsoft SQL Server 2008 和 .NET Framework 2.0 构建（用于 x86 和 x64）

安装时，Aspose.Slides.ReportingServices.dll 会被复制到 ReportServer\bin 目录，并且配置文件会更新，以便 Reporting Services 认识到新的渲染扩展。 这些步骤由 Aspose.Slides for Reporting Services 安装程序执行，但您也可以按照本文件中进一步的描述手动执行这些步骤。

![todo:image_alt_text](easy-and-lightweight-deployment_1.png)

**图**：Aspose.Slides.ReportingServices.dll 被复制到 **ReportServer\bin** 目录中。
