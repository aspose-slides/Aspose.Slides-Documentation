---
title: 系统要求
type: docs
weight: 15
url: /zh/reportingservices/system-requirements/
keywords:
- 系统要求
- SQL Server Reporting Services
- SSRS
- Power BI Report Server
- .NET Framework 3.5
- Aspose.Slides for Reporting Services
description: "在安装之前，检查 Aspose.Slides for Reporting Services 所需的报告服务器、版本以及 .NET Framework 版本。"
---
## **概述**

Aspose.Slides for Reporting Services 作为呈现扩展运行在报告服务器内部。此页面列出在您[安装](/slides/zh/reportingservices/installing-aspose-slides-for-reporting-services/)之前，报告服务器机器需要具备的条件。Microsoft PowerPoint 和 Microsoft Office 并非必需。

## **受支持的报告服务器**

- Microsoft SQL Server 2005 报告服务
- Microsoft SQL Server 2008 和 2008 R2 报告服务
- Microsoft SQL Server 2012 报告服务
- Microsoft SQL Server 2014 报告服务
- Microsoft SQL Server 2016 报告服务
- Microsoft SQL Server 2017 报告服务
- Microsoft SQL Server 2019 报告服务
- Power BI 报告服务器，用于分页（RDL）报告

支持 32 位和 64 位报告服务器。SQL Server 2005 使用其自带的扩展构建；所有后续版本和 Power BI 报告服务器使用相同的构建。[手动安装](/slides/zh/reportingservices/install-manually/) 显示要复制的文件。

如果您的报告服务器版本不在此列表中，请在部署前在[免费支持论坛](https://forum.aspose.com/c/slides/11)询问。

## **报告服务器版本**

对于 SQL Server 2016 报告服务及更高版本以及 Power BI 报告服务器，Microsoft 在 Enterprise、Standard、Developer 和 Evaluation 版中支持呈现扩展；Web 和 Express 版不支持。参见[按版本支持的 Reporting Services 功能](https://learn.microsoft.com/en-us/sql/reporting-services/reporting-services-features-supported-by-the-editions-of-sql-server)。MSI 安装程序会跳过 SQL Server 2016 及更早版本的 Express 版实例。

## **.NET 框架**

.NET Framework 3.5 必须安装在报告服务器机器上。扩展的程序集是为 .NET Framework 2.0 运行时构建的，如果缺少 .NET Framework 3.5，MSI 安装程序会停止并显示提示。在 Windows Server 上，请在“添加角色和功能向导”中添加 **.NET Framework 3.5 功能**；参见[在 Windows 上安装 .NET Framework 3.5](https://learn.microsoft.com/en-us/dotnet/framework/install/dotnet-35-windows)。

## **权限**

安装扩展会更改报告服务器文件夹中的文件，因此两种安装方式均需要本地管理员权限。如果在没有管理员权限的情况下启动 MSI 安装程序，它会提供以管理员权限重新启动。

## **常见问题**

**我需要在报告服务器上安装 Microsoft PowerPoint 吗？**

不需要。扩展会自行创建演示文稿；既不需要 PowerPoint，也不需要 Microsoft Office。

**我可以在 Express 版上安装该扩展吗？**

不可以。Express 版不支持呈现扩展。MSI 安装程序会隐藏 SQL Server 2016 及更早版本的 Express 实例；在更高版本中，请勿选择 Express 实例。

**该扩展向导出列表添加了哪些格式？**

PPT、PPS、PPTX、PPSX、ODP 和 XPS。参见[受支持的文件格式](/slides/zh/reportingservices/supported-file-formats/).