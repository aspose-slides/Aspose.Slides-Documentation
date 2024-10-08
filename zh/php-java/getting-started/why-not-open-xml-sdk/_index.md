---
title: 为什么不使用 Open XML SDK
type: docs
weight: 120
url: /php-java/why-not-open-xml-sdk/
---

{{% alert color="primary" %}} 

我们有时会听到这个问题：

**我们为什么要使用 Aspose 产品而不是免费的 Open XML SDK？**

这个问题很容易回答：**功能和特性**。

{{% /alert %}} 
## **什么是 Open XML SDK？**
根据 [MSDN 库](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk)，Open XML SDK 被定义为： 

Open XML SDK 2.0 简化了操作 Open XML 包及其内部 Open XML 模式元素的任务。Open XML SDK 2.0 封装了开发人员在 Open XML 包上执行的许多常见任务，因此您只需几行代码即可执行复杂的操作。

OOXML 文档本质上是压缩的 XML 文件，而 Open XML SDK 是一组类，允许您以强类型的方式与 OOXML 文档的内容进行交互。也就是说，与解压文件以提取 XML、将该 XML 加载到 DOM 树以及直接操作 XML 元素和属性不同，Open XML SDK 提供类来完成这些操作。
## **什么是 Aspose.Slides？**
Aspose.Slides 是一个类库，允许您的应用程序执行以下演示处理任务：

- 使用 **Presentation** 对象模型编程。
- 在所有流行的 PowerPoint 演示格式之间进行高质量转换，包括转换为 PDF、XPS 和 TIFF。
- 能够生成常见格式（如 PNG、JPEG 和 BMP）的幻灯片缩略图，以及将幻灯片导出为 SVG。
- 能够从头开始构建演示文稿，或通过组合一个或多个文档来构建。
- 支持添加动画、OLE 框架、表格，创建和管理图表。
- 提供广泛的控制，以管理文本框、段落和部分级别的文本格式。

有关支持的功能的更多详细信息，请访问 [Aspose.Slides 功能](/slides/php-java/product-overview/)。
## **比较 Open XML SDK 和 Aspose.Slides**
{{% alert color="primary" %}} 

下表比较了 Open XML SDK 和 Aspose.Slides 的特性。

{{% /alert %}} 

|**特性或特性类别**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|支持的演示格式|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|从 PPT 转换到 PPTX |否|是|
|<p>使用演示文档对象模型（DOM）进行高级编程：</p><p>- 查找和替换文本。</p><p>- 组装演示文稿中的幻灯片。</p>|否|是|
|使用文档对象模型的详细编程，访问单个元素和格式，例如文本占位符、文本框、段落和部分。|是|是|
|对基础 XML 元素和属性（例如关系标识符、OOXML 文档的列表标识符）进行低级直接和完全访问。|是|否|
|<p>呈现：</p><p>- 将演示文稿呈现为 PDF、PDF 注释、XPS、TIFF 图像。</p><p>- 将幻灯片缩略图呈现为 PNG、JPEG、BMP、SVG 和 TIFF。</p><p>- 指定图像分辨率、质量、压缩和其他选项。</p>|否|是|
|支持的平台|Windows, .NET|Windows, Linux, UNIX, MAC, Java, PHP, Mono|
## **结论**
{{% alert color="primary" %}} 

Open XML SDK 和 Aspose.Slides 不会直接竞争，因为它们满足的需求和受众截然不同。Open XML SDK 是一个类库，提供了一种强类型的方式来处理 OOXML 文档。Aspose.Slides 是一个非常有用的演示处理库，提供了对几乎所有 Microsoft PowerPoint 文件格式的良好支持。

如果您只需要对 PPTX 文档执行相对简单的编程操作，则 Open XML SDK 可能是合适的选择。通过 Open XML SDK，您可以相对轻松地完成简单任务，比如生成一个简单的 PPTX 文档或删除注释、页眉/页脚、提取图像等。有些任务可以使用 Open XML SDK 来完成，但无法使用 Aspose.Slides 来完成。例如，如果您需要直接访问 OOXML 文档的 XML 元素和属性，则应使用 Open XML SDK。然而，如果您需要对文档执行复杂操作，例如以下某些任务，则使用 Aspose.Slides 是您最好的选择：

- 除 PPTX 外，支持较旧的 PowerPoint 格式。
- 以合适的方式组合对象、样式和其他格式在幻灯片中复制或克隆形状。
- 替换格式化或未格式化的文本。
- 应用动画，并使用与形状相关的连接器。
- 将文档转换为 PDF、TIFF 或 XPS，以使其看起来像 Microsoft PowerPoint 转换的样子。
- 在桌面和基于 Web 的环境中开发 .NET 或 Java 应用程序。

{{% /alert %}}