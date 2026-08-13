---
title: 为什么不用 Open XML SDK
type: docs
weight: 50
url: /zh/net/why-not-open-xml-sdk/
aliases:
  - /net/slides-on-cloud-platforms/extracting-text/open-xml-sdk/
keywords:
- Open XML SDK
- 比较
- 演示文稿对象模型
- 高质量转换
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "了解为什么 Aspose.Slides 是比免费 Open XML SDK 更好的选择：比较功能、免自动化转换以及对 PPT、PPTX 和 ODP 的广泛支持。"
---
## **概述**

本文解释了开发者在处理演示文稿时何时可能选择 Open XML SDK 或 Aspose.Slides。它将 Open XML SDK 描述为用于操作 OOXML 包及其底层 XML 元素的库，而 Aspose.Slides 则被呈现为具有高级对象模型并支持多种 PowerPoint 相关任务的演示文稿处理库。

本文通过支持的格式、编程模型、渲染和打印能力、平台支持以及常见使用场景对两者进行比较。它还阐明，Open XML SDK 可能适用于基本的 PPTX 操作或直接访问 OOXML 元素，而 Aspose.Slides 更适合处理复杂的演示任务，例如处理多种 PowerPoint 格式、复制或克隆形状、替换文本、应用动画以及将演示文稿转换为 PDF、TIFF 或 XPS。

## **Open XML SDK 是什么？**
有时，我们会收到这个问题：*为什么我们应该使用 Aspose 产品而不是免费 的 Open XML SDK？* 

我们发现从功能和特性方面回答这个问题很容易。 

根据[MSDN Library](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk)，Open XML SDK 的定义如下： 

> "The Open XML SDK 2.0 simplifies the task of manipulating Open XML packages and the underlying Open XML schema elements within a package. The Open XML SDK 2.0 encapsulates many common tasks that developers perform on Open XML packages, so that you can perform complex operations with just a few lines of code. OOXML documents are essentially zipped XML files and Open XML SDK is a collection of classes that allows you to work with the content of OOXML documents in a strongly-typed way. That is instead of unzipping a file to extract XML, loading that XML into a DOM tree, and working with XML elements and attributes directly, Open XML SDK provides classes to do that."

## **Aspose.Slides 是什么？**
Aspose.Slides 是一个类库，允许应用程序执行以下演示文稿处理任务：

- 使用演示文稿对象模型进行编程。  
- 涉及所有流行的受支持 PowerPoint 演示文稿格式的高质量转换，包括转换为 PDF、XPS、TIFF 和打印。  
- 以 PNG、JPEG、BMP 等常见格式生成幻灯片缩略图，同时支持将幻灯片导出为 SVG。  
- 从头构建演示文稿或通过组合一个或多个文档的元素来创建演示文稿。  
- 添加动画、OLE Frames、表格，创建和管理图表。  
- 在 TextFrames、Paragraphs 和 Portions 层面对文本格式进行（广泛）控制和管理。  

有关可用功能的更多细节，请参阅[Aspose.Slides Features](/slides/zh/net/product-overview/)页面。

## **Open XML SDK 与 Aspose.Slides 的比较**
此表比较了 Open XML SDK 与 Aspose.Slides 的功能和特性。

|**功能或功能类别**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|支持的演示文稿格式|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|从 PPT 转换为 PPTX|否|是|
|<p>使用 Presentation Document Object Model (DOM) 的高级编程：</p><p>- 查找并替换文本。</p><p>- 组装演示文稿中的幻灯片。</p>|否|是|
|使用文档对象模型的详细编程；访问诸如 TextHolders、TextFrames、Paragraphs 和 Portions 等单个元素和格式设置。|是|是|
|对底层 XML 元素和属性（如关系标识符、OOXML 文档的列表标识符）进行低层次的直接完整访问。|是|否|
|<p>渲染和打印：</p><p>- 将演示文稿渲染为 PDF、PDF Notes、XPS、TIFF 图像。</p><p>- 将幻灯片缩略图渲染为 PNG、JPEG、BMP、SVG 和 TIFF。</p><p>- 指定图像分辨率、质量、压缩和其他选项。</p><p>- 使用 .NET 打印基础设施打印演示文稿。组件内置打印方法，可按照 Microsoft PowerPoint 的打印预览方式打印演示文稿。</p>|否|是|
|支持的平台|Windows, .NET|Windows, Linux, Java, .NET, Mono|

## **结论**
Open XML SDK 与 Aspose.Slides 并不是直接竞争的关系，因为它们满足的需求大不相同，面向的受众也不同。

{{% alert color="info" %}} 

Open XML SDK 是一个类库，以强类型方式提供对 OOXML 文档的操作，而 Aspose.Slides 是一个功能极其强大的演示文稿处理库，几乎支持所有 Microsoft PowerPoint 文件格式。 

{{% /alert %}} 

如果您的工作流是对 PPTX 文档进行基本的编程操作，那么 Open XML SDK 可能是一个不错的选择。使用 Open XML SDK，您可以轻松完成生成简单 PPTX 文档、删除注释、页眉/页脚、提取图像等简单任务。某些任务可以使用 Open XML SDK 完成，但 Aspose.Slides 无法完成。例如，如果您需要直接访问 OOXML 文档的 XML 元素和属性，则应使用 Open XML SDK。 

如果您需要对文档执行复杂任务——例如以下列表中的任务——那么 Aspose.Slides 是您最佳的选择。 

- 涉及旧版 PowerPoint 格式的操作（以及 PPTX）。  
- 以适当的方式复制或克隆幻灯片中的形状，结合对象、样式和其他格式设置元素。  
- 替换已格式化或未格式化的文本。  
- 应用动画并使用连接器与形状配合。  
- 将文档转换为 PDF、TIFF 或 XPS，使其呈现效果如同 Microsoft PowerPoint 完成的转换。  
- 在桌面和基于 Web 的环境中开发 .NET 或 Java 应用程序。