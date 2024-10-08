---
title: 为什么不使用 Open XML SDK
type: docs
weight: 100
url: /zh/cpp/why-not-open-xml-sdk/
---

## **什么是 Open XML SDK?**
我们有时会听到这样的问题：为什么我们应该使用 Aspose 产品而不是免费的 Open XML SDK？这个问题的答案很简单：功能和特性。根据[MSDN Library](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk)，Open XML SDK 被定义为：Open XML SDK 2.0 简化了操作 Open XML 包和包内基础 Open XML 模式元素的任务。Open XML SDK 2.0 封装了开发人员在 Open XML 包上执行的许多常见任务，使得您可以用几行代码执行复杂的操作。OOXML 文档本质上是压缩的 XML 文件，Open XML SDK 是一个类集合，允许您以强类型的方式处理 OOXML 文档的内容。也就是说，Open XML SDK 提供类来完成这些操作，而不是解压文件以提取 XML，将该 XML 加载到 DOM 树中并直接处理 XML 元素和属性。

## **什么是 Aspose.Slides?**
Aspose.Slides 是一个类库，使您的应用程序能够执行以下演示文稿处理任务：

- 使用 **Presentation** 对象模型进行编程。
- 在所有流行的支持的 PowerPoint 演示文稿格式之间进行高质量转换，包括转换为 PDF 和 XPS。
- 能够生成 PNG、JPEG 和 BMP 等常见格式的幻灯片缩略图，并将幻灯片导出为 SVG。
- 能够从头开始构建演示文稿或通过合并一个或多个文档。
- 支持添加动画、Ole 框架、表格，创建和管理图表。
- 提供对文本框、段落和部分级别的文本格式管理的广泛控制。
  有关支持的功能的更多详细信息，请访问 [Aspose.Slides Features](/slides/zh/net/product-overview/)。

## **比较 Open XML SDK 和 Aspose.Slides**
下表比较了 Open XML SDK 和 Aspose.Slides 的功能。

|**功能或功能类别**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|支持的演示文稿格式|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|从 PPT 转换为 PPTX|否|是|
|<p>使用演示文档对象模型 (DOM) 进行高级编程：</p><p>- 查找和替换文本。</p><p>- 在演示文稿中组装幻灯片。</p>|否|是|
|使用文档对象模型进行详细编程，访问单个元素和格式，例如 TextHolders、TextFrames、段落和部分。|是|是|
|对底层 XML 元素和属性（例如关系标识符、OOXML 文档的列表标识符）进行低级直接和完全访问。|是|否|
|<p>渲染：</p><p>- 将演示文稿渲染为 PDF、PDF 备注、XPS、TIFF 图像。</p><p>- 将幻灯片缩略图渲染为 PNG、JPEG、BMP、SVG 和 TIFF。</p><p>- 指定图像分辨率、质量、压缩和其他选项。</p>|否|是|

## **结论**
Open XML SDK 和 Aspose.Slides 不存在直接竞争，因为它们满足非常不同的需求和受众。Open XML SDK 是一个类库，提供了一种强类型的方式来处理 OOXML 文档。Aspose.Slides 是一个非常有用的演示文稿处理库，提供对几乎所有 Microsoft PowerPoint 文件格式的极大支持。如果您仅需要对 PPTX 文档进行相对基本的编程操作，那么 Open XML SDK 可能是一个合适的选择。使用 Open XML SDK，您将能够轻松地完成诸如生成简单 PPTX 文档或删除注释、页眉/页脚、提取图像等简单任务。某些任务可以使用 Open XML SDK 实现，但无法使用 Aspose.Slides 实现。例如，如果您需要直接访问 OOXML 文档的 XML 元素和属性，则应该使用 Open XML SDK。然而，如果您需要对文档执行复杂操作，例如以下某些任务，则使用 Aspose.Slides 是您的最佳选择：

- 除 PPTX 外，支持旧版 PowerPoint 格式。
- 在幻灯片内复制或克隆形状，以适当的方式组合对象、样式和其他格式。
- 替换格式化或未格式化的文本。
- 应用动画并使用与形状一起使用的连接器。
- 将文档转换为 PDF 或 XPS，使其外观与 Microsoft PowerPoint 的转换完全相同。
- 在桌面和控制台环境中开发 C++ 应用程序。