---
title: 在 .NET 中管理演示文稿的标签和自定义数据
linktitle: 标签和自定义数据
type: docs
weight: 300
url: /zh/net/managing-tags-and-custom-data/
keywords:
- 文档属性
- 标签
- 自定义数据
- 添加标签
- 键值对
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "了解如何在 Aspose.Slides for .NET 中添加、读取、更新和删除标签及自定义数据，并提供 PowerPoint 和 OpenDocument 演示文稿的示例。"
---
## **概述**

本文介绍了 Aspose.Slides 如何在 PowerPoint 演示文稿中使用标签和自定义数据。简要说明了数据在 PPTX 文件中的存储方式，指出演示文稿特定的数据可以以标签和自定义 XML 部分的形式存在，并将标签描述为键值字符串对。

本文还展示了如何读取标签值以及如何向演示文稿、单个幻灯片或形状添加标签。另外，文章还涵盖了常见的标签管理任务，如清除所有标签、按名称删除标签以及获取标签名称列表。

## **演示文稿文件中的数据存储**

PPTX 文件——扩展名为 .pptx 的项——采用 PresentationML 格式存储，该格式是 Office Open XML 规范的一部分。Office Open XML 格式定义了演示文稿中数据的结构。

在演示文稿中，*slide*（幻灯片）是其中的元素之一，*slide part*（幻灯片部件）包含单个幻灯片的内容。幻灯片部件可以显式关联到许多部件——例如由 ISO/IEC 29500 定义的用户自定义标签。

自定义数据（特定于演示文稿）或用户可以以标签（[ITagCollection](https://reference.aspose.com/slides/zh/net/aspose.slides/itagcollection)）和自定义 XML 部分（[ICustomXmlPartCollection](https://reference.aspose.com/slides/zh/net/aspose.slides/icustomxmlpartcollection)）的形式存在。

{{% alert color="primary" %}} 
标签本质上是字符串键值对。 
{{% /alert %}} 

## **获取标签的值**

在 Slides 中，标签对应于 IDocumentProperties.Keywords 属性。下面的示例代码展示了如何使用 Aspose.Slides for .NET 获取 [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation) 中标签的值：

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   string keywords = pres.DocumentProperties.Keywords;
}
```

## **向演示文稿添加标签**

Aspose.Slides 允许向演示文稿添加标签。标签通常由两部分组成：

- 自定义属性的名称 - `MyTag` 
- 自定义属性的值 - `My Tag Value`

如果需要根据特定规则或属性对某些演示文稿进行分类，则可以通过添加标签受益。例如，如果想将来自北美国家的所有演示文稿归为一类，可以创建一个 North American 标签，然后将相关国家（美国、墨西哥和加拿大）设为其值。

下面的示例代码展示了如何使用 Aspose.Slides for .NET 向 [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation) 添加标签：

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   ITagCollection tags = pres.CustomData.Tags;
   pres.CustomData.Tags["MyTag"] = "My Tag Value";
}
```

标签也可以为 [Slide](https://reference.aspose.com/slides/zh/net/aspose.slides/slide) 设置：

```csharp
using(Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    slide.CustomData.Tags["tag"] = "value";
}
```

或为任意单独的 [Shape](https://reference.aspose.com/slides/zh/net/aspose.slides/shape) 设置：

```csharp
using(Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
    shape.TextFrame.Text = "My text";
    shape.CustomData.Tags["tag"] = "value";
}
```

### **限制**

通过 `CustomData.Tags` 集合添加的标签仅存储在 PowerPoint 文件内。它们在将演示文稿导出为 PDF 时 **不会** 转移到 PDF 的标签结构中。因此，作为标签分配的自定义标识符无法从已标记的 PDF 中检索。

**解决方法**：可以将自定义标识符存储在对象的 **Alt Text** 中（例如，`shape.AlternativeText = "MyId"`）。导出为 PDF 后，Alt Text 可能会出现在 PDF 的标签结构中。

## **FAQ**

**我可以一次性删除演示文稿、幻灯片或形状中的所有标签吗？**

可以。[tag collection](https://reference.aspose.com/slides/zh/net/aspose.slides/tagcollection/) 支持 [clear](https://reference.aspose.com/slides/zh/net/aspose.slides/tagcollection/clear/) 操作，可一次性删除所有键‑值对。

**如何在不遍历整个集合的情况下，仅通过名称删除单个标签？**

对 [TagCollection](https://reference.aspose.com/slides/zh/net/aspose.slides/tagcollection/) 使用 [Remove(name)](https://reference.aspose.com/slides/zh/net/aspose.slides/tagcollection/remove/) 操作即可通过键删除标签。

**如何检索标签名称的完整列表以进行分析或过滤？**

在 [tag collection](https://reference.aspose.com/slides/zh/net/aspose.slides/tagcollection/) 上使用 [GetNamesOfTags](https://reference.aspose.com/slides/zh/net/aspose.slides/tagcollection/getnamesoftags/)，它会返回所有标签名称的数组。