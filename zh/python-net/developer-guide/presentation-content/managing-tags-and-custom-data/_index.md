---
title: 使用 Python 管理演示文稿中的标签和自定义数据
linktitle: 标签和自定义数据
type: docs
weight: 300
url: /zh/python-net/managing-tags-and-custom-data/
keywords:
- 文档属性
- 标签
- 自定义数据
- 添加标签
- 键值对
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides
description: "了解如何在 Aspose.Slides for Python via .NET 中添加、读取、更新和删除标签及自定义数据，并提供 PowerPoint 和 OpenDocument 演示文稿的示例。"
---
## **概述**

本文介绍了 Aspose.Slides 在 PowerPoint 演示文稿中如何使用标签和自定义数据。它简要概述了数据在 PPTX 文件中的存储方式，说明了演示文稿特定的数据可以以标签和自定义 XML 部分的形式存在，并将标签描述为键值字符串对。

它还展示了如何读取标签值以及如何向演示文稿、单个幻灯片或形状添加标签。此外，本文还涵盖了常见的标签管理任务，如清除所有标签、按名称删除标签以及获取标签名称列表。

## **演示文稿文件中的数据存储**

PPTX 文件（扩展名为 .pptx 的项目）采用 PresentationML 格式存储，该格式是 Office Open XML 规范的一部分。Office Open XML 格式定义了演示文稿中数据的结构。

在演示文稿中，*幻灯片* 是其中的一个元素，*幻灯片部件* 包含单个幻灯片的内容。幻灯片部件可以显式关联到多个部件，例如由 ISO/IEC 29500 定义的用户自定义标签。

自定义数据（特定于演示文稿）或用户可以以标签（[ITagCollection](https://reference.aspose.com/slides/zh/python-net/aspose.slides/itagcollection/)）和 CustomXmlParts（[ICustomXmlPartCollection](https://reference.aspose.com/slides/zh/python-net/aspose.slides/icustomxmlpartcollection/)）的形式存在。

{{% alert color="primary" %}} 
标签本质上是字符串键值对。 
{{% /alert %}} 

## **获取标签的值**

在幻灯片中，标签对应于 IDocumentProperties.Keywords 属性。以下示例代码演示了如何使用 Aspose.Slides for Python via .NET 获取 [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 的标签值：

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    print(pres.document_properties.keywords)
```

## **向演示文稿添加标签**

Aspose.Slides 允许您向演示文稿添加标签。标签通常由两部分组成：

- 自定义属性的名称 - `MyTag`
- 自定义属性的值 - `My Tag Value`

如果需要根据特定规则或属性对一些演示文稿进行分类，则可以通过向这些演示文稿添加标签来实现。例如，如果您想对来自北美国家的所有演示文稿进行分类或归为一类，可以创建一个 North American 标签，并将相关国家（美国、墨西哥和加拿大）作为其值。

以下示例代码演示了如何使用 Aspose.Slides for Python via .NET 向 [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 添加标签：

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
   tags = pres.custom_data.tags 
   tags.add("MyTag", "My Tag Value")
```

标签也可以为 [Slide](https://reference.aspose.com/slides/zh/python-net/aspose.slides/slide/) 设置：

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slide = pres.slides[0]
    tags = slide.custom_data.tags
    tags.add("tag", "value")
```

或任意单个 [Shape](https://reference.aspose.com/slides/zh/python-net/aspose.slides/shape/)：

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slide = pres.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 50)
    shape.text_frame.text = "My text"
    shape.custom_data.tags.add("tag", "value")
```

### **限制**

通过 `custom_data.tags` 集合添加的标签仅存储在 PowerPoint 文件中。导出为 PDF 时，这些标签 **不会** 转移到 PDF 的标签结构中。因此，作为标签分配的自定义标识符无法从带标签的 PDF 中检索。

**解决方法**：您可以将自定义标识符存储在对象的 **Alt Text** 中（例如，`shape.alternative_text = "MyId"`）。导出为 PDF 后，Alt Text 可能会出现在 PDF 的标签结构中。

## **常见问题**

**我可以一次性删除演示文稿、幻灯片或形状中的所有标签吗？**

是的。[tag collection](https://reference.aspose.com/slides/zh/python-net/aspose.slides/tagcollection/) 支持 [clear](https://reference.aspose.com/slides/zh/python-net/aspose.slides/tagcollection/clear/) 操作，可一次性删除所有键‑值对。

**如何在不遍历整个集合的情况下按名称删除单个标签？**

在 [TagCollection](https://reference.aspose.com/slides/zh/python-net/aspose.slides/tagcollection/) 上使用 [remove(name)](https://reference.aspose.com/slides/zh/python-net/aspose.slides/tagcollection/remove/) 操作即可按键删除标签。

**如何检索完整的标签名称列表以用于分析或过滤？**

在 [tag collection](https://reference.aspose.com/slides/zh/python-net/aspose.slides/tagcollection/) 上使用 [get_names_of_tags](https://reference.aspose.com/slides/zh/python-net/aspose.slides/tagcollection/get_names_of_tags/)；它会返回所有标签名称的数组。