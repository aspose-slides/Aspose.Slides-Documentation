---
title: 为何不使用 Open XML SDK
type: docs
weight: 50
url: /zh/net/why-not-open-xml-sdk/
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
description: "了解为何 Aspose.Slides 是比免费 Open XML SDK 更好的选择：比较功能、无自动化转换以及对 PPT、PPTX 和 ODP 的广泛支持。"
---

## **Open XML SDK 是什么？**
有时我们会收到这样的问题：*为什么要使用 Aspose 产品而不是免费的 Open XML SDK？* 

我们很容易从功能和特性方面回答这个问题。 

根据 [MSDN Library](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk) 的定义，Open XML SDK 如下： 

> “Open XML SDK 2.0 简化了操作 Open XML 包以及包内底层 Open XML 架构元素的任务。Open XML SDK 2.0 封装了开发人员在 Open XML 包上执行的许多常见任务，使您只需几行代码即可完成复杂操作。OOXML 文档本质上是压缩的 XML 文件，Open XML SDK 是一组类，允许您以强类型方式处理 OOXML 文档的内容。这意味着不必解压文件提取 XML、将 XML 加载到 DOM 树中并直接操作 XML 元素和属性，Open XML SDK 提供了相应的类来完成这些工作。”

## **Aspose.Slides 是什么？**
Aspose.Slides 是一个类库，允许应用程序执行以下演示文稿处理任务： 

- 使用演示文稿对象模型进行编程。  
- 高质量转换，支持所有常见的 PowerPoint 演示文稿格式，包括转换为 PDF、XPS、TIFF 和打印。  
- 以 PNG、JPEG 和 BMP 等常用格式生成幻灯片缩略图，并可将幻灯片导出为 SVG。  
- 从头构建演示文稿或通过合并一个或多个文档的元素来创建演示文稿。  
- 添加动画、OLE 框、表格，创建和管理图表。  
- 对 TextFrames、Paragraphs 和 Portions 级别的文本格式进行（广泛的）控制和管理。  

  有关可用功能的更多详情，请参阅 [Aspose.Slides Features](/slides/zh/net/product-overview/) 页面。

## **将 Open XML SDK 与 Aspose.Slides 进行比较**
此表比较了 Open XML SDK 的能力和特性与 Aspose.Slides 的区别。

|**功能或功能类别**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|支持的演示文稿格式|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|从 PPT 转换为 PPTX|No|Yes|
|<p>使用演示文稿文档对象模型（DOM）的高级编程：</p><p>- 查找和替换文本。</p><p>- 在演示文稿中组装幻灯片。</p>|No|Yes|
|使用文档对象模型的详细编程；访问单个元素和格式，如 TextHolders、TextFrames、Paragraphs 和 Portions。|Yes|Yes|
|对底层 XML 元素和属性（如关系标识符、OOXML 文档的列表标识符）的低层直接完整访问。|Yes|No|
|<p>渲染和打印：</p><p>- 将演示文稿渲染为 PDF、PDF 注释、XPS、TIFF 图像。</p><p>- 将幻灯片缩略图渲染为 PNG、JPEG、BMP、SVG 和 TIFF。</p><p>- 指定图像分辨率、质量、压缩和其他选项。</p><p>- 使用 .NET 打印基础设施打印演示文稿。组件内置打印方法，可按 MS PowerPoint 打印预览的方式打印演示文稿。</p>|No|Yes|
|支持的平台|Windows, .NET|Windows, Linux, Java, .NET, Mono|

## **结论**
Open XML SDK 与 Aspose.Slides 并不直接竞争，因为它们满足的需求截然不同，针对的受众也不同。 

{{% alert color="primary" %}} 

Open XML SDK 是一个类库，提供以强类型方式处理 OOXML 文档的能力，而 Aspose.Slides 是一个功能极其强大的演示文稿处理库，几乎支持所有 Microsoft PowerPoint 文件格式。 

{{% /alert %}} 

如果您的工作流只是对 PPTX 文档进行基本的编程操作，那么 Open XML SDK 可能是一个不错的选择。使用 Open XML SDK，您可以轻松完成生成简单 PPTX 文档、删除批注、页眉/页脚、提取图像等简单任务。某些任务可以使用 Open XML SDK 完成，但在 Aspose.Slides 中无法实现。例如，如果需要直接访问 OOXML 文档的 XML 元素和属性，则应使用 Open XML SDK。 

如果您需要对文档执行复杂任务——如下面列表中的任务——则 Aspose.Slides 是最佳选项。 

- 处理旧版 PowerPoint 格式（以及 PPTX）。  
- 以适当的方式复制或克隆幻灯片中的形状，结合对象、样式和其他格式元素。  
- 替换格式化或未格式化的文本。  
- 应用动画并使用连接器与形状配合。  
- 将文档转换为 PDF、TIFF 或 XPS，使其呈现效果与 Microsoft PowerPoint 的转换一致。  
- 在桌面和基于 Web 的环境中开发 .NET 或 Java 应用程序。