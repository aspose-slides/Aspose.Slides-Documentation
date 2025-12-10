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
description: "了解为什么 Aspose.Slides 是比免费 Open XML SDK 更好的选择：比较功能、免自动化转换以及对 PPT、PPTX 和 ODP 的广泛支持。"
---

{{% alert color="primary" %}} 

我们有时会听到这个问题：

**为什么我们应该使用 Aspose 产品而不是免费的 Open XML SDK？**

这个问题很容易回答：**功能和特性**。

{{% /alert %}} 
## **什么是 Open XML SDK？**
根据 [MSDN Library](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk) 的定义，Open XML SDK 被描述为：

Open XML SDK 2.0 简化了操作 Open XML 包及其内部 Open XML 架构元素的任务。Open XML SDK 2.0 封装了开发人员在 Open XML 包上执行的许多常见任务，使您只需几行代码即可执行复杂操作。

OOXML 文档本质上是压缩的 XML 文件，Open XML SDK 是一组类，允许您以强类型方式处理 OOXML 文档的内容。也就是说，您无需解压文件以提取 XML、将 XML 加载到 DOM 树并直接操作 XML 元素和属性，Open XML SDK 提供了相应的类来完成这些工作。
## **什么是 Aspose.Slides？**
Aspose.Slides 是一个类库，使您的应用程序能够执行以下演示文稿处理任务：

- 使用 **Presentation** 对象模型进行编程。
- 在所有流行的受支持 PowerPoint 演示文稿格式之间进行高质量转换，包括转换为 PDF、XPS 和 TIFF。
- 能够以常见格式（如 PNG、JPEG 和 BMP）生成幻灯片缩略图，并将幻灯片导出为 SVG。
- 能够从头创建演示文稿或通过合并一个或多个文档来构建演示文稿。
- 支持添加动画、Ole 框架、表格，创建和管理图表。
- 提供对 TextFrames、段落和 Portion 级别的文本格式进行广泛控制的功能。

欲了解支持的功能详情，请访问 [Aspose.Slides Features](/slides/zh/java/product-overview/)。
## **比较 Open XML SDK 与 Aspose.Slides**
{{% alert color="primary" %}} 

以下表格比较了 Open XML SDK 与 Aspose.Slides 的功能。

{{% /alert %}} 

|**功能或功能类别**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|支持的演示文稿格式|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|从 PPT 转换为 PPTX |No|Yes|
|<p>使用 Presentation Document Object Model (DOM) 的高级编程：</p><p>- 查找和替换文本。</p><p>- 组装演示文稿中的幻灯片。</p>|No|Yes|
|使用文档对象模型进行详细编程，访问单个元素及其格式，例如 TextHolders、TextFrames、Paragraphs 和 Portions。|Yes|Yes|
|对底层 XML 元素和属性（如关系标识符、OOXML 文档的列表标识符）进行低级直接完整访问。|Yes|No|
|<p>渲染：</p><p>- 将演示文稿渲染为 PDF、PDF 注释、XPS、TIFF 图像。</p><p>- 将幻灯片缩略图渲染为 PNG、JPEG、BMP、SVG 和 TIFF。</p><p>- 指定图像分辨率、质量、压缩及其他选项。</p>|No|Yes |
|支持的平台|Windows, .NET|Windows, Linux,UNIX, MAC, Java, PHP, Mono|

## **结论**
{{% alert color="primary" %}} 

Open XML SDK 与 Aspose.Slides 并不存在正面对决，因为它们满足的需求和受众截然不同。Open XML SDK 是一个类库，提供以强类型方式处理 OOXML 文档的能力。Aspose.Slides 是一个非常有用的演示文稿处理库，为几乎所有 Microsoft PowerPoint 文件格式提供了强大的支持。

如果您只需要对 PPTX 文档进行相对基础的编程操作，那么 Open XML SDK 可能是合适的选择。使用 Open XML SDK，您可以轻松完成生成简单 PPTX 文档、删除评论、页眉/页脚、提取图像等简单任务。有些任务可以通过 Open XML SDK 实现，但 Aspose.Slides 无法实现。例如，如果您需要直接访问 OOXML 文档的 XML 元素和属性，则应使用 Open XML SDK。但是，如果您需要对文档执行复杂操作，例如以下任务，那么使用 Aspose.Slides 是您的最佳选择：

- 支持除 PPTX 之外的旧版 PowerPoint 格式。
- 以适当的方式在幻灯片中复制或克隆形状，合并对象、样式和其他格式。
- 替换格式化或未格式化的文本。
- 应用动画并使用形状的连接线。
- 将文档转换为 PDF、TIFF 或 XPS，使其呈现效果完全与 Microsoft PowerPoint 转换时相同。
- 在桌面和基于 Web 的环境中开发 .NET 或 Java 应用程序。

{{% /alert %}}