---
title: 为什么不使用 Open XML SDK
type: docs
weight: 50
url: /net/why-not-open-xml-sdk/
---

## **什么是 Open XML SDK?**
有时，我们会遇到这样的问题：*我们为什么要使用 Aspose 产品而不是免费的 Open XML SDK?*

我们发现从功能和特性方面回答这个问题很简单。

根据 [MSDN Library](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk)，Open XML SDK 的定义如下：

> "Open XML SDK 2.0 简化了操纵 Open XML 包和包内基础 Open XML 模式元素的任务。Open XML SDK 2.0 封装了开发人员在 Open XML 包上执行的许多常见任务，因此您可以用少量代码执行复杂操作。OOXML 文档本质上是压缩的 XML 文件，而 Open XML SDK 是一个类的集合，使您可以以强类型的方式处理 OOXML 文档的内容。也就是说，Open XML SDK 提供了类来实现这一点，而不是解压文件以提取 XML，将该 XML 加载到 DOM 树中，并直接处理 XML 元素和属性。"

## **什么是 Aspose.Slides?**
Aspose.Slides 是一个类库，允许应用程序执行以下演示文稿处理任务：

- 使用演示对象模型进行编程。

- 涉及所有流行支持的 PowerPoint 演示文稿格式的高质量转换，包括转换为 PDF、XPS、TIFF 和打印。

- 生成已知格式的幻灯片缩略图，例如 PNG、JPEG 和 BMP，同时将幻灯片导出为 SVG。

- 从头构建演示文稿，或通过组合一个或多个文档中的元素来构建演示文稿。

- 添加动画、OLE 框架、表格，创建和管理图表。

- 控制（广泛控制）和管理文本框、段落和部分级别的文本格式。

  有关可用功能的更多详细信息，请参见 [Aspose.Slides Features](/slides/net/product-overview/) 页面。

## **比较 Open XML SDK 与 Aspose.Slides**
此表比较 Open XML SDK 的能力和特性与 Aspose.Slides。

|**特性或特性类别**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|支持的演示格式|PPTX|PPT，POT，PPS，PPTX，POTX，PPSX，ODP|
|从 PPT 转换为 PPTX|否|是|
|<p>使用演示文档对象模型 (DOM) 进行高层编程：</p><p>- 查找和替换文本。</p><p>- 在演示文稿中组装幻灯片。</p>|否|是|
|使用文档对象模型进行详细编程；访问个别元素和格式，例如 TextHolders、TextFrames、Paragraphs 和 Portions。|是|是|
|对底层 XML 元素和属性（如关系标识符、OOXML 文档的列表标识符）的低级直接完全访问。|是|否|
|<p>渲染和打印：</p><p>- 将演示文稿渲染为 PDF、PDF Notes、XPS、TIFF 图像。</p><p>- 将幻灯片缩略图渲染为 PNG、JPEG、BMP、SVG 和 TIFF。</p><p>- 指定图像分辨率、质量、压缩和其他选项。</p><p>- 使用 .NET 打印基础设施打印演示文稿。该组件具有内置打印方法以按 MS PowerPoint 的打印预览打印演示文稿。</p>|否|是|
|支持的平台|Windows，.NET|Windows，Linux，Java，.NET，Mono|

## **结论**
Open XML SDK 和 Aspose.Slides 并不直接竞争，因为它们满足的需求大相径庭，并且针对不同的受众。

{{% alert color="primary" %}}

Open XML SDK 是一个强类型的类库，用于处理 OOXML 文档，而 Aspose.Slides 是一个非常有用的演示文稿处理库，几乎支持所有 Microsoft PowerPoint 文件格式。

{{% /alert %}}

如果您的工作流程是对 PPTX 文档进行基本编程操作，那么 Open XML SDK 可能是一个不错的选择。使用 Open XML SDK，您应该能够轻松地执行诸如生成简单 PPTX 文档或删除注释、页眉/页脚、提取图像等简单任务。某些任务可以使用 Open XML SDK 执行，但无法使用 Aspose.Slides 执行。例如，如果需要直接访问 OOXML 文档的 XML 元素和属性，则应使用 Open XML SDK。

如果您需要对文档执行复杂任务——例如下面列表中的任务——则 Aspose.Slides 是您最佳的选择。

- 涉及较旧的 PowerPoint 格式（以及 PPTX）的操作。
- 以适当的方式组合对象、样式和其他格式在幻灯片内复制或克隆形状。
- 替换格式化或未格式化的文本。
- 应用动画并使用形状连接器。
- 将文档转换为 PDF、TIFF 或 XPS，使其看起来像 Microsoft PowerPoint 进行了转换。
- 在桌面和基于 Web 的环境中开发 .NET 或 Java 应用程序。