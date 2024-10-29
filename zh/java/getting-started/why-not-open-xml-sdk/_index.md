---
title: 为什么不使用 Open XML SDK
type: docs
weight: 120
url: /zh/java/why-not-open-xml-sdk/
---

{{% alert color="primary" %}} 

我们有时会听到这个问题：

**为什么我们应该使用 Aspose 产品，而不是免费的 Open XML SDK？**

这个问题很容易回答：**功能和特性**。

{{% /alert %}} 
## **什么是 Open XML SDK？**
根据 [MSDN Library](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk)，Open XML SDK 被定义为：

Open XML SDK 2.0 简化了操作 Open XML 包及其内部的 Open XML 架构元素的任务。Open XML SDK 2.0 封装了开发者在 Open XML 包上执行的许多常见任务，使您能够仅用几行代码执行复杂操作。

OOXML 文档本质上是已压缩的 XML 文件，Open XML SDK 是一组允许您以强类型方式处理 OOXML 文档内容的类。也就是说，Open XML SDK 提供类来处理此过程，而不是先解压文件以提取 XML，再将该 XML 加载到 DOM 树中并直接处理 XML 元素和属性。
## **什么是 Aspose.Slides？**
Aspose.Slides 是一个类库，允许您的应用执行以下演示文稿处理任务：

- 使用 **Presentation** 对象模型编程。
- 在所有流行的支持的 PowerPoint 演示文稿格式之间进行高质量转换，包括转换为 PDF、XPS 和 TIFF。
- 能够生成像 PNG、JPEG 和 BMP 等知名格式的幻灯片缩略图，以及幻灯片导出到 SVG。
- 能够从头开始构建演示文稿或通过组合多个文档来构建。
- 支持添加动画、Ole 样式框、表格，创建和管理图表。
- 为文本框架、段落和部分级别的文本格式管理提供广泛控制。

有关支持的功能的更多详细信息，请访问 [Aspose.Slides Features](/slides/zh/java/product-overview/)。
## **比较 Open XML SDK 和 Aspose.Slides**
{{% alert color="primary" %}} 

下表比较了 Open XML SDK 和 Aspose.Slides 的特性。

{{% /alert %}} 

|**特性或特性类别**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|支持的演示文稿格式|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|从 PPT 转换到 PPTX |否|是|
|<p>使用演示文档对象模型 (DOM) 进行高级编程：</p><p>- 查找和替换文本。</p><p>- 在演示文稿中组装幻灯片。</p>|否|是|
|使用文档对象模型的详细编程，访问各个元素和格式，例如 TextHolders、TextFrames、Paragraphs 和 Portions。|是|是|
|对底层 XML 元素和属性（例如关系标识符、OOXML 文档的列表标识符）的低级直接完全访问。|是|否|
|<p>渲染：</p><p>- 将演示文稿渲染为 PDF、PDF 注释、XPS、TIFF 图像。</p><p>- 将幻灯片缩略图渲染为 PNG、JPEG、BMP、SVG 和 TIFF。</p><p>- 指定图像分辨率、质量、压缩和其他选项。</p>|否|是 |
|支持的平台|Windows, .NET|Windows, Linux, UNIX, MAC, Java, PHP, Mono|
## **结论**
{{% alert color="primary" %}} 

Open XML SDK 和 Aspose.Slides 并不是直接竞争，因为它们满足非常不同的需求和受众。Open XML SDK 是一个类库，提供了一种强类型的方式来处理 OOXML 文档。Aspose.Slides 是一个非常有用的演示文稿处理库，提供对几乎所有 Microsoft PowerPoint 文件格式的良好支持。

如果您只需要对 PPTX 文档执行相对基本的编程操作，那么 Open XML SDK 可能是一个合适的选择。使用 Open XML SDK，您可以相对轻松地执行简单任务，例如生成简单的 PPTX 文档或删除评论、页眉/页脚、提取图像等。有些任务可以使用 Open XML SDK 完成，但无法通过 Aspose.Slides 完成。例如，如果您需要直接访问 OOXML 文档的 XML 元素和属性，则应使用 Open XML SDK。然而，如果您需要对文档执行复杂操作，例如以下某些任务，则使用 Aspose.Slides 是最佳选择：

- 除 PPTX 外，还支持旧版 PowerPoint 格式。
- 以合适的方式组合对象、样式和其他格式，在幻灯片中复制或克隆形状。
- 替换格式化或未格式化的文本。
- 应用动画并使用带有形状的连接器。
- 将文档转换为 PDF、TIFF 或 XPS，以便其外观与 Microsoft PowerPoint 转换的结果完全相同。
- 在桌面和基于 Web 的环境中开发 .NET 或 Java 应用程序。

{{% /alert %}}