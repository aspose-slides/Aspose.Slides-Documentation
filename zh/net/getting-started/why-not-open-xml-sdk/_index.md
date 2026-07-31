---
title: 为什么不使用 Open XML SDK
type: docs
weight: 50
url: /zh/net/why-not-open-xml-sdk/
aliases:
  - /net/slides-on-cloud-platforms/extracting-text/open-xml-sdk/
keywords:
- Open XML SDK
- 比较
- 演示对象模型
- 高质量转换
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "了解为何 Aspose.Slides 是比免费 Open XML SDK 更好的选择：对比功能、免自动化转换以及对 PPT、PPTX 和 ODP 的广泛支持。"
---
## **概述**

本文解释了开发人员何时可能选择 Open XML SDK 或 Aspose.Slides 来处理演示文稿。它将 Open XML SDK 描述为用于操作 OOXML 包及其底层 XML 元素的库，而 Aspose.Slides 则被呈现为具有高级对象模型并支持众多 PowerPoint 相关任务的演示处理库。

本文通过支持的格式、编程模型、渲染和打印功能、平台支持以及常见使用场景对两者进行比较。它还说明 Open XML SDK 可能适用于基本的 PPTX 操作或直接访问 OOXML 元素，而 Aspose.Slides 更适合处理复杂的演示任务，例如处理多种 PowerPoint 格式、复制或克隆形状、替换文本、应用动画以及将演示文稿转换为 PDF、TIFF 或 XPS。

## **Open XML SDK 是什么？**

有时我们会遇到这样的问题：*为什么我们应该使用 Aspose 产品而不是免费的 Open XML SDK？*  

我们发现可以很容易地从功能和特性方面来回答这个问题。

根据 [MSDN库](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk)，Open XML SDK 的定义如下：

> “Open XML SDK 2.0 简化了操作 Open XML 包及其内部 Open XML 架构元素的任务。Open XML SDK 2.0 封装了开发人员在 Open XML 包上执行的许多常见任务，从而只需几行代码即可完成复杂操作。OOXML 文档本质上是压缩的 XML 文件，Open XML SDK 是一组类，允许以强类型方式处理 OOXML 文档的内容。这意味着不必先解压文件提取 XML，将 XML 加载到 DOM 树中，然后直接操作 XML 元素和属性，Open XML SDK 提供了相应的类来完成这些工作。”

## **Aspose.Slides 是什么？**

Aspose.Slides 是一个类库，允许应用程序执行以下演示处理任务：

- 使用演示对象模型进行编程。  
- 涉及所有流行的受支持 PowerPoint 演示格式的高质量转换，包括转换为 PDF、XPS、TIFF 以及打印。  
- 以 PNG、JPEG、BMP 等常用格式生成幻灯片缩略图，并将幻灯片导出为 SVG。  
- 从头创建演示文稿或通过组合一个或多个文档的元素来构建演示文稿。  
- 添加动画、OLE 框、表格，创建和管理图表。  
- 在 TextFrames、Paragraphs 和 Portions 级别上进行（广泛的）文本格式控制和管理。  

有关可用功能的详细信息，请参阅 [Aspose.Slides Features](/slides/zh/net/product-overview/) 页面。

## **Open XML SDK 与 Aspose.Slides 对比**

|**功能或功能类别**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|支持的演示文稿格式|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|从 PPT 转换为 PPTX |No|Yes|
|<p>使用演示文稿对象模型 (DOM) 的高级编程：</p><p>- 查找并替换文本。</p><p>- 在演示文稿中组装幻灯片。</p>|No|Yes|
|使用文档对象模型进行详细编程；访问单个元素和格式，例如 TextHolders、TextFrames、Paragraphs 和 Portions。|Yes|Yes|
|低级直接完整访问底层 XML 元素和属性，例如关系标识符、OOXML 文档的列表标识符。|Yes|No|
|<p>渲染和打印：</p><p>- 将演示文稿渲染为 PDF、PDF 备注、XPS、TIFF 图像。</p><p>- 将幻灯片缩略图渲染为 PNG、JPEG、BMP、SVG 和 TIFF。</p><p>- 指定图像分辨率、质量、压缩和其他选项。</p><p>- 使用 .NET 打印基础设施打印演示文稿。组件内置打印方法，可如 MS PowerPoint 打印预览般打印演示文稿。</p>|No|Yes|
|支持的平台|Windows, .NET|Windows, Linux, Java, .NET, Mono|

## **结论**

Open XML SDK 和 Aspose.Slides 并不直接竞争，因为它们满足的需求截然不同，面向的受众也不同。

{{% alert color="primary" %}} 

Open XML SDK 是一个类库，以强类型方式处理 OOXML 文档，而 Aspose.Slides 是一个功能极其强大的演示处理库，对几乎所有 Microsoft PowerPoint 文件格式提供了出色的支持。 

{{% /alert %}} 

如果您的工作流是对 PPTX 文档进行基本的编程操作，那么 Open XML SDK 可能是一个不错的选择。使用 Open XML SDK，您应该能够轻松完成生成简单 PPTX 文档、删除批注、页眉/页脚、提取图像等简单任务。某些任务可以通过 Open XML SDK 实现，但 Aspose.Slides 并不能完成。例如，需要直接访问 OOXML 文档的 XML 元素和属性时，应使用 Open XML SDK。

如果需要对文档执行复杂任务——例如以下列表中的任务——则 Aspose.Slides 是最佳选项。

- 处理旧版 PowerPoint 格式（以及 PPTX）。
- 在幻灯片中复制或克隆形状，并以适当方式组合对象、样式和其他格式元素。
- 替换格式化或未格式化的文本。
- 应用动画并使用连接线连接形状。
- 将文档转换为 PDF、TIFF 或 XPS，使其呈现效果如同 Microsoft PowerPoint 完成的转换。
- 在桌面和基于 Web 的环境中开发 .NET 或 Java 应用程序。