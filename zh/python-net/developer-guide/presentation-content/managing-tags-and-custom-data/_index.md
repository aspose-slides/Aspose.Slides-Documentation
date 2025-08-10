---
title: 用 Python 管理演示文稿中的标签和自定义数据
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
description: "了解如何在 Aspose.Slides for Python via .NET 中添加、读取、更新和删除标签与自定义数据，并提供适用于 PowerPoint 和 OpenDocument 演示文稿的示例。"
---

## 演示文稿文件中的数据存储

PPTX 文件——以 .pptx 扩展名结尾的项目——以 PresentationML 格式存储，该格式是 Office Open XML 规范的一部分。Office Open XML 格式定义了演示文稿中包含的数据的结构。

其中 *幻灯片* 是演示文稿中的一个元素，*幻灯片部分* 包含单个幻灯片的内容。幻灯片部分可以与许多部分（例如用户定义标签）具有明确的关系，这些部分由 ISO/IEC 29500 定义。

自定义数据（特定于演示文稿）或用户可以作为标签 ([ITagCollection](https://reference.aspose.com/slides/python-net/aspose.slides/itagcollection/)) 和 CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/python-net/aspose.slides/icustomxmlpartcollection/)) 存在。

{{% alert color="primary" %}} 

标签本质上是字符串键值对。

{{% /alert %}} 

## 获取标签的值

在幻灯片中，标签对应于 IDocumentProperties.Keywords 属性。以下示例代码展示了如何使用 Aspose.Slides for Python via .NET 获取标签的值，适用于 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)：

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    print(pres.document_properties.keywords)
```

## 向演示文稿添加标签

Aspose.Slides 允许您向演示文稿添加标签。标签通常由两个项目组成：

- 自定义属性的名称 - `MyTag` 
- 自定义属性的值 - `My Tag Value`

如果您需要根据特定规则或属性对一些演示文稿进行分类，那么您可以通过向这些演示文稿添加标签获取好处。例如，如果您想对来自北美国家的所有演示文稿进行分类或放在一起，您可以创建一个北美标签，然后将相关国家（美国、墨西哥和加拿大）作为值分配。

以下示例代码展示了如何使用 Aspose.Slides for Python via .NET 向 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 添加标签：

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
   tags = pres.custom_data.tags 
   tags.add("MyTag", "My Tag Value")
```

标签也可以设置在 [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/) 上：

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slide = pres.slides[0]
    tags = slide.custom_data.tags
    tags.add("tag", "value")
```

或者任何单独的 [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/)：

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slide = pres.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 50)
    shape.text_frame.text = "My text"
    shape.custom_data.tags.add("tag", "value")
```