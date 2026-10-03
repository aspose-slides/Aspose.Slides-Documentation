---
title: 为什么不使用 Open XML SDK
type: docs
weight: 180
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
description: "看看为什么 Aspose.Slides 比免费的 Open XML SDK 更佳选择：比较功能、无自动化转换以及对 PPT、PPTX 和 ODP 的广泛支持。"
---
## **概述**

本文说明开发人员在处理演示文稿时何时可能选择 Open XML SDK 或 Aspose.Slides。它将 Open XML SDK 描述为用于操作 OOXML 包及其底层 XML 元素的库，而 Aspose.Slides 则被呈现为具有高级对象模型并支持许多 PowerPoint 相关任务的演示文稿处理库。

本文通过支持的格式、编程模型、渲染、平台支持和常见使用场景比较了两者。它还说明 Open XML SDK 可能适用于基本的 PPTX 操作或直接访问 OOXML 元素，而 Aspose.Slides 更适合处理复杂的演示任务，例如处理多种 PowerPoint 格式、复制或克隆形状、替换文本、应用动画以及将演示文稿转换为 PDF、TIFF 或 XPS。

## **Open XML SDK 是什么？**
根据 [MSDN 库](https://learn.microsoft.com/en-us/office/open-xml/open-xml-sdk) 的定义：

Open XML SDK 2.0 简化了操作 Open XML 包及其内部 Open XML 架构元素的任务。Open XML SDK 2.0 封装了开发人员在 Open XML 包上执行的许多常见任务，使您只需几行代码即可执行复杂操作。

OOXML 文档本质上是压缩的 XML 文件，Open XML SDK 是一组类，允许您以强类型方式处理 OOXML 文档的内容。这意味着无需解压文件提取 XML、将 XML 加载到 DOM 树并直接操作 XML 元素和属性，Open XML SDK 提供了相应的类来完成这些工作。

## **Aspose.Slides 是什么？**
Aspose.Slides 是一个类库，允许您的应用程序执行以下演示文稿处理任务：

- 使用 **Presentation** 对象模型进行编程。
- 在所有流行的支持的 PowerPoint 演示格式之间进行高质量转换，包括转换为 PDF、XPS 和 TIFF。
- 能够以 PNG、JPEG、BMP 等常用格式生成幻灯片缩略图，并支持导出为 SVG。
- 能够从头构建演示文稿或通过合并一个或多个文档创建演示文稿。
- 支持添加动画、Ole 帧、表格，创建和管理图表。
- 在 TextFrames、Paragraph 和 Portion 级别提供对文本格式的广泛控制。

有关支持的功能的更多详细信息，请访问 [Aspose.Slides 功能](/slides/zh/java/product-overview/)。

## **比较 Open XML SDK 与 Aspose.Slides**
{{% alert color="info" title="Note" %}}

下表比较了 Open XML SDK 和 Aspose.Slides 的功能。

{{% /alert %}}

|**功能或功能类别**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|支持的演示文稿格式|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|从 PPT 转换为 PPTX|否|是|
|<p>使用演示文稿文档对象模型（DOM）的高级编程：</p><p>- 查找并替换文本。</p><p>- 在演示文稿中组装幻灯片。</p>|否|是|
|使用文档对象模型进行详细编程，访问单个元素和格式，如 TextHolders、TextFrames、Paragraphs 和 Portions。|是|是|
|对底层 XML 元素和属性（如关系标识符、OOXML 文档的列表标识符）进行低级直接完整访问。|是|否|
|<p>渲染：</p><p>- 将演示文稿渲染为 PDF、PDF Notes、XPS、TIFF 图像。</p><p>- 将幻灯片缩略图渲染为 PNG、JPEG、BMP、SVG 和 TIFF。</p><p>- 指定图像分辨率、质量、压缩和其他选项。</p>|否|是|
|支持的平台|Windows, .NET|Windows, Linux,UNIX, MAC, Java, PHP, Mono|

## **结论**
{{% alert color="info" title="Note" %}}

Open XML SDK 与 Aspose.Slides 并非直接竞争，因为它们满足的需求和受众截然不同。Open XML SDK 是一个提供强类型方式操作 OOXML 文档的类库。Aspose.Slides 是一个非常实用的演示文稿处理库，对几乎所有 Microsoft PowerPoint 文件格式提供了出色的支持。

如果您只需要对 PPTX 文档进行相对基础的编程操作，那么 Open XML SDK 可能是合适的选择。使用 Open XML SDK，您可以轻松完成生成简单 PPTX 文档、删除批注、页眉/页脚、提取图像等简单任务。有些任务可以通过 Open XML SDK 实现，但 Aspose.Slides 无法实现。例如，如果您需要直接访问 OOXML 文档的 XML 元素和属性，则应使用 Open XML SDK。然而，如果您需要对文档执行复杂操作，例如以下任务，则使用 Aspose.Slides 是最佳方案：

- 支持除 PPTX 之外的旧 PowerPoint 格式。
- 以合适的方式复制或克隆幻灯片中的形状，保留对象、样式和其他格式。
- 替换带格式或不带格式的文本。
- 应用动画并使用形状连接线。
- 将文档转换为 PDF、TIFF 或 XPS，使其外观与 Microsoft PowerPoint 的转换结果完全一致。
- 在桌面和基于 Web 的环境中开发 .NET 或 Java 应用程序。

{{% /alert %}}