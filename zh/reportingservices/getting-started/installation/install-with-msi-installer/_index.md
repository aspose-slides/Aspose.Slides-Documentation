---
title: 使用 MSI 安装程序安装
type: docs
weight: 20
url: /zh/reportingservices/install-with-msi-installer/
keywords:
- MSI 安装程序
- 安装
- SQL Server 报表服务
- Power BI 报表服务器
- Aspose.Slides 用于报表服务
description: "使用 MSI 安装程序安装 Aspose.Slides for Reporting Services：安装程序的需求、它在每个报表服务器实例上所做的更改，以及如何检查结果。"
---
## **安装**

MSI 安装程序是安装 Aspose.Slides for Reporting Services 的最简方式。它需要 .NET Framework 3.5 并且在报表服务器上具有管理员权限；请参阅 [系统要求](/slides/zh/reportingservices/system-requirements/)。

1. 从 [下载页面](https://releases.aspose.com/slides/zh/reportingservices/) 下载 MSI 安装程序 *Aspose.Slides for Reporting Services XX.XX*，并复制到报表服务器。
2. 以管理员身份运行。如果缺少 .NET Framework 3.5，安装程序会停止并显示提示；请安装 .NET Framework 3.5 功能后重新运行。
3. 同意许可协议。
4. 在 **Custom Setup** 页面，功能树列出安装程序在机器上检测到的每个 SQL Server Reporting Services 和 Power BI Report Server 实例。要保持实例不变，请单击其图标并选择 **Entire feature will be unavailable**。Express 版不支持渲染扩展，请不要选择 Express 实例。安装程序会隐藏 SQL Server 2016 及更早版本的 Express 实例。
5. 选择 **Next**，然后 **Install**。

可选的 **Rpl Export** 功能默认未选中。它会添加一个隐藏扩展，可将报表保存为 RPL 格式，便于向 Aspose 发送问题报告；请参阅 [导出报告为 RPL 格式](/slides/zh/reportingservices/exporting-reports-to-rpl-format/)。

## **安装程序的更改内容**

安装程序将文件保存在 *Aspose\Aspose.Slides for Reporting Services* 下的 Program Files 文件夹中——在 64 位 Windows 上为 *Program Files (x86)*，因为安装程序是 32 位包。然后，对每个选中的实例，它会：

- 将 *Aspose.Slides.ReportingServices.dll* 复制到实例的 *ReportServer\bin* 文件夹——SQL Server 2005 的构建，或 SQL Server 2008 及更高版本和 Power BI Report Server 的构建；
- 向 *rsreportserver.config* 的 `<Render>` 元素添加六个渲染扩展——ASPPT、ASPPS、ASPPTX、ASPPSX、ASXPSS 和 ASODP；
- 向 *rssrvpolicy.config* 添加授予程序集完全信任的代码组；
- 保存每个被修改的配置文件的副本，文件名后添加 *.bak*。

[手动安装](/slides/zh/reportingservices/install-manually/) 逐步展示这些更改。

如果某个实例无法配置，安装程序会在消息中列出该实例并将详细信息写入安装文件夹中的 *rserrors&lt;date&gt;.log*。请手动在该实例上安装扩展。

## **检查安装**

在 Web 门户（SQL Server 2014 及更早版本的 Report Manager）中打开分页报表并打开 **Export** 列表。现在该列表包含以下格式：

- PPT - PowerPoint Presentation via Aspose.Slides
- PPS - PowerPoint SlideShow via Aspose.Slides
- PPTX - PowerPoint 2007 Presentation via Aspose.Slides
- PPSX - PowerPoint 2007 SlideShow via Aspose.Slides
- ODP - OpenDocument Presentation via Aspose.Slides
- XPS - via Aspose.Slides

如果没有许可，导出的文件会带有评估水印；请参阅 [许可](/slides/zh/reportingservices/license-aspose-slides-for-reporting-services/)。

## **何时手动安装**

在以下情况下请改为手动 [手动安装](/slides/zh/reportingservices/install-manually/) 扩展：

- 安装程序无法配置实例，例如服务器的安全设置导致；
- 升级后只想替换程序集，而不是卸载旧版本再运行新安装程序。

卸载产品会从每个实例中移除程序集和配置条目。