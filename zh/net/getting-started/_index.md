---
title: 入门指南
type: docs
weight: 10
url: /zh/net/getting-started/
keywords:
- 入门
- 系统要求
- 安装
- 首次演示文稿
- NuGet
- PPT 处理
- PPTX 处理
- ODP 处理
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "从新 .NET 项目到使用 Aspose.Slides 保存的首个演示文稿的路径：检查需求，安装包，运行第一个程序，并继续完成常见任务。"
---
## **概述**

按照以下四个步骤依次进行。每个步骤说明要做的事情并链接到详细的文章。评估、授权和支持在步骤之后进行说明。

## **步骤 1：检查系统要求**

[Aspose.Slides for .NET](https://products.aspose.com/slides/net/) 可在 Windows、Linux 和 macOS 上运行。[系统要求](/slides/zh/net/system-requirements/) 列出了每个包支持的操作系统和 .NET 版本，以及 Linux 需要的额外库。

## **步骤 2：安装包**

Aspose.Slides for .NET 通过 NuGet 分发为两个提供相同类的包。将其中一个添加到项目中：

- 在 Windows 上：`dotnet add package Aspose.Slides.NET`
- 在 Linux 和 macOS 上：`dotnet add package Aspose.Slides.NET6.CrossPlatform`。在 Linux 上，请先安装 `fontconfig` 库。
- 在 Alpine Linux，以及 glibc 低于 2.23（x64）或 2.39（ARM64）的 Linux 系统上：Aspose.Slides.NET，需安装 `libgdiplus` 库。

[安装](/slides/zh/net/installation/) 提供了 Linux 命令、Aspose.Slides.NET 在 Linux 上需要的额外启动设置，以及 Visual Studio 的操作步骤。

## **步骤 3：创建您的第一个演示文稿**

[在 Aspose.Slides for .NET 首页的快速入门](/slides/zh/net/#your-first-presentation) 是一个完整的控制台程序：它向幻灯片添加文本框并将演示文稿保存为 PPTX 文件。[创建演示文稿](/slides/zh/net/create-presentation/) 详细解释了相同的步骤，并展示如何打开现有演示文稿并以其他格式保存。

## **步骤 4：继续常见任务**

- [打开演示文稿](/slides/zh/net/open-presentation/)
- [保存演示文稿](/slides/zh/net/save-presentation/)
- [将演示文稿转换为 PDF](/slides/zh/net/convert-powerpoint-to-pdf/)
- [将幻灯片渲染为图像](/slides/zh/net/convert-slide/)
- [编辑演示文稿文本](/slides/zh/net/manage-text/)
- [按幻灯片元素的示例](/slides/zh/net/examples/)

## **评估与授权**

没有授权时，Aspose.Slides 以评估模式运行：它会在每个保存的幻灯片上添加水印，并截断从演示文稿读取的文本。

- [评估 Aspose.Slides](/slides/zh/net/evaluate-aspose-slides/) 说明了评估限制以及如何申请临时授权。
- [授权](/slides/zh/net/licensing/) 展示了如何从文件、流或嵌入资源应用授权。
- [计量授权](/slides/zh/net/metered-licensing/) 介绍了按使用量计费的授权方式。
- [受支持的文件格式](/slides/zh/net/supported-file-formats/) 列出了 Aspose.Slides 能加载和保存的格式。

## **获取帮助**

[产品支持](/slides/zh/net/product-support/) 说明了如何在[免费支持论坛](https://forum.aspose.com/c/slides/11)提问以及报告问题时应包含哪些信息。

## **常见问题**

**我需要安装 Microsoft PowerPoint 吗？**

不需要。Aspose.Slides 能自行读取和写入演示文件，且不使用 PowerPoint，因此也可在服务器和 Linux 上运行。

**对于 .NET Framework 应用程序，我应该使用哪个包？**

Aspose.Slides.NET。它包含针对 .NET Framework 4.6.2 及更高版本、.NET 6 及更高版本以及 .NET Standard 2.0 的构建。Aspose.Slides.NET6.CrossPlatform 需要 .NET 6 或更高版本。