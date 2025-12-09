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
description: "学习如何在 Aspose.Slides for Python via .NET 中添加、读取、更新和删除标签及自定义数据，提供 PowerPoint 和 OpenDocument 演示文稿的示例。"
---

## **演示文稿文件中的数据存储**

PPTX 文件（扩展名为 .pptx 的项目）以 PresentationML 格式存储，该格式是 Office Open XML 规范的一部分。Office Open XML 规范定义了演示文稿中数据的结构。

在演示文稿中，*幻灯片* 是其中的一个元素，*幻灯片部件* 包含单个幻灯片的内容。幻灯片部件可以显式关联到许多部件——例如用户自定义标签——这些部件由 ISO/IEC 29500 定义。

自定义数据（特定于演示文稿）或用户可以以标签（[ITagCollection](https://reference.aspose.com/slides/python-net/aspose.slides/itagcollection/)）和 CustomXmlParts（[ICustomXmlPartCollection](https://reference.aspose.com/slides/python-net/aspose.slides/icustomxmlpartcollection/)）的形式存在。

{{% alert color="primary" %}} 
标签本质上是字符串-键 对值。
{{% /alert %}} 

## **获取标签的值**

在幻灯片中，标签对应于 IDocumentProperties.Keywords 属性。以下示例代码演示了如何使用 Aspose.Slides for Python via .NET 获取 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 的标签值：
```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    print(pres.document_properties.keywords)
```


## **向演示文稿添加标签**

Aspose.Slides 允许您向演示文稿添加标签。一个标签通常由两部分组成：

- 自定义属性的名称 - `MyTag`
- 自定义属性的值 - `My Tag Value`

如果您需要根据特定规则或属性对演示文稿进行分类，向其添加标签可能会有所帮助。例如，如果您想对来自北美国家的所有演示文稿进行归类，可以创建一个北美标签，然后将相关国家（美国、墨西哥和加拿大）设为其值。

以下示例代码演示了如何使用 Aspose.Slides for Python via .NET 向 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 添加标签：
```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
   tags = pres.custom_data.tags 
   tags.add("MyTag", "My Tag Value")
```


标签也可以为 [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/) 设置：
```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slide = pres.slides[0]
    tags = slide.custom_data.tags
    tags.add("tag", "value")
```


或者为任意单独的 [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) 设置：
```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slide = pres.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 50)
    shape.text_frame.text = "My text"
    shape.custom_data.tags.add("tag", "value")
```


## **常见问题**

**我可以一次性删除演示文稿、幻灯片或形状中的所有标签吗？**

可以。 [tag collection](https://reference.aspose.com/slides/python-net/aspose.slides/tagcollection/) 支持 [clear](https://reference.aspose.com/slides/python-net/aspose.slides/tagcollection/clear/) 操作，可一次删除所有键‑值对。

**如何在不遍历整个集合的情况下通过名称删除单个标签？**

使用 [remove(name)](https://reference.aspose.com/slides/python-net/aspose.slides/tagcollection/remove/) 操作在 [TagCollection](https://reference.aspose.com/slides/python-net/aspose.slides/tagcollection/) 上删除对应键的标签。

**如何检索所有标签名称的完整列表以进行分析或过滤？**

使用 [get_names_of_tags](https://reference.aspose.com/slides/python-net/aspose.slides/tagcollection/get_names_of_tags/) 在 [tag collection](https://reference.aspose.com/slides/python-net/aspose.slides/tagcollection/) 上；它会返回所有标签名称的数组。