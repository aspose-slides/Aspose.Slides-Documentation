---
title: 为什么不使用 Open XML SDK
type: docs
weight: 120
url: /zh/java/why-not-open-xml-sdk/
keywords:
- Open XML SDK
- 比较
- 演示文稿对象模型
- 高质量转换
- PowerPoint
- OpenDocument
- 演示文稿
- Java
- Aspose.Slides
description: "了解为何 Aspose.Slides 是比免费 Open XML SDK 更好的选择：比较功能、免自动化转换以及对 PPT、PPTX 和 ODP 的广泛支持。"
---
## **概述**

本文解释了开发人员在处理演示文稿文档时何时可能选择 Open XML SDK 或 Aspose.Slides。它将 Open XML SDK 描述为用于操作 OOXML 包及其底层 XML 元素的库，而 Aspose.Slides 则被呈现为具有高级对象模型并支持许多 PowerPoint 相关任务的演示处理库。

本文通过支持的格式、编程模型、渲染和打印功能、平台支持以及常见使用场景对两者进行比较。它还说明 Open XML SDK 可能适用于基本的 PPTX 操作或直接访问 OOXML 元素，而 Aspose.Slides 更适合处理复杂的演示任务，例如处理多种 PowerPoint 格式、复制或克隆形状、替换文本、应用动画以及将演示文稿转换为 PDF、TIFF 或 XPS。

## **什么是 Open XML SDK？**
根据 [MSDN 库](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk) 的定义：

Open XML SDK 2.0 简化了操作 Open XML 包及其内部 Open XML 架构元素的任务。Open XML SDK 2.0 封装了开发人员在 Open XML 包上执行的许多常见任务，使您只需几行代码即可完成复杂操作。

OOXML 文档本质上是压缩的 XML 文件，Open XML SDK 是一组类，允许您以强类型方式处理 OOXML 文档的内容。这意味着，您不必解压文件以提取 XML、将 XML 加载到 DOM 树并直接操作 XML 元素和属性，Open XML SDK 提供了相应的类来完成这些工作。

## **什么是 Aspose.Slides？**
Aspose.Slides 是一个类库，允许您的应用程序执行以下演示处理任务：

- 使用 **Presentation** 对象模型进行编程。
- 在所有流行的受支持 PowerPoint 演示格式之间进行高质量转换，包括转换为 PDF、XPS 和 TIFF。
- 能够以 PNG、JPEG、BMP 等常用格式生成幻灯片缩略图，并可将幻灯片导出为 SVG。
- 能够从头构建演示文稿或通过组合一个或多个文档创建演示文稿。
- 支持添加动画、Ole 框架、表格，创建和管理图表。
- 为在 TextFrames、段落和 Portion 级别管理文本格式提供广泛的控制。

有关支持的功能的详细信息，请访问 [Aspose.Slides 功能](/slides/zh/java/product-overview/)。

## **比较 Open XML SDK 与 Aspose.Slides**
{{% alert color="info" %}} 

以下表格比较了 Open XML SDK 和 Aspose.Slides 的功能。

{{% /alert %}} 

|**功能或功能类别**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|支持的演示文稿格式|PPTX|PPT、POT、PPS、PPTX、POTX、PPSX、ODP|
|从 PPT 转换为 PPTX|否|是|
|<p>使用演示文档对象模型 (DOM) 的高级编程：</p><p>- 查找并替换文本。</p><p>- 组装演示文稿中的幻灯片。</p>|否|是|
|使用文档对象模型进行详细编程，访问诸如 TextHolders、TextFrames、段落和 Portion 等单个元素及其格式。|是|是|
|对底层 XML 元素和属性（如关系标识符、OOXML 文档的列表标识符）进行低级直接完整访问。|是|否|
|<p>渲染：</p><p>- 将演示文稿渲染为 PDF、PDF 注释、XPS、TIFF 图像。</p><p>- 将幻灯片缩略图渲染为 PNG、JPEG、BMP、SVG 和 TIFF。</p><p>- 指定图像分辨率、质量、压缩及其他选项。</p>|否|是 |
|支持的平台|Windows、.NET|Windows、Linux、UNIX、MAC、Java、PHP、Mono|

## **结论**
{{% alert color="info" %}} 

Open XML SDK 和 Aspose.Slides 并非直接竞争，因为它们满足的需求和受众截然不同。Open XML SDK 是一个类库，提供强类型方式来处理 OOXML 文档。Aspose.Slides 是一个非常有用的演示处理库，几乎支持所有 Microsoft PowerPoint 文件格式。

如果您只需要对 PPTX 文档进行相对基本的编程操作，那么 Open XML SDK 可能是合适的选择。使用 Open XML SDK，您可以轻松完成生成简单 PPTX 文档、删除注释、页眉/页脚、提取图像等简单任务。有些任务可以通过 Open XML SDK 完成，但 Aspose.Slides 不能实现。例如，如果您需要直接访问 OOXML 文档的 XML 元素和属性，则应使用 Open XML SDK。然而，如果您需要对文档执行复杂操作，例如以下任务，则使用 Aspose.Slides 是最佳方案：

- 支持除 PPTX 之外的旧 PowerPoint 格式。
- 以合适的方式复制或克隆幻灯片中的形状，保留对象、样式和其他格式。
- 替换格式化或未格式化的文本。
- 应用动画并使用形状之间的连接线。
- 将文档转换为 PDF、TIFF 或 XPS，使其外观与 Microsoft PowerPoint 转换的结果完全一致。
- 在桌面和基于 Web 的环境中开发 .NET 或 Java 应用程序。

{{% /alert %}}