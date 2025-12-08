---
title: 使用 Python 管理演示文稿中的占位符
linktitle: 管理占位符
type: docs
weight: 10
url: /zh/python-net/manage-placeholder/
keywords:
- 占位符
- 文本占位符
- 图片占位符
- 图表占位符
- 提示文本
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides
description: "通过 .NET 在 Aspose.Slides for Python 中轻松管理占位符：替换文本、定制提示并在 PowerPoint 和 OpenDocument 中设置图像透明度。"
---

## **概述**

占位符在母版、布局和幻灯片上定义保留区域——例如标题、正文、图片、图表、日期/时间、幻灯片编号和页脚——用于控制内容放置位置以及格式继承方式。使用 Aspose.Slides for Python，您可以通过检查 `shape.placeholder` 是否为 `None` 来发现幻灯片、其布局或母版上的占位符，检查 `placeholder.type`，然后读取或修改相关的内容和格式。该 API 允许您向母版或布局添加新占位符，使其传播到后代幻灯片，重新定位和调整已有占位符的大小，将占位符转换为普通形状以获得完全控制，或删除占位符以简化设计。以下示例展示了如何枚举占位符、更新文本和样式，并通过在适当层级应用更改来保持布局的一致性。

## **更改占位符中的文本**

使用 Aspose.Slides for Python，您可以在演示文稿的幻灯片上查找并修改占位符。Aspose.Slides 允许您修改占位符中的文本。

**先决条件：** 您需要一个包含占位符的演示文稿。可以在 Microsoft PowerPoint 中创建此类演示文稿。

下面演示了如何使用 Aspose.Slides 替换占位符中的文本：

1. 实例化 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类并将演示文稿作为参数传入。  
2. 通过索引获取幻灯片的引用。  
3. 遍历形状以查找占位符。  
4. 使用与 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) 关联的 [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) 更改文本。  
5. 保存修改后的演示文稿。  

```python
import aspose.slides as slides

# 实例化 Presentation 类。
with slides.Presentation("ReplacingText.pptx") as presentation:
    # 访问第一张幻灯片。
    slide = presentation.slides[0]

    # 遍历形状以查找占位符。
    for shape in slide.shapes:
        if shape.placeholder is not None:
            # 更改每个占位符中的文本。
            shape.text_frame.text = "This is Placeholder"

    # 将演示文稿保存到磁盘。
    presentation.save("ReplacingText_out.pptx", slides.export.SaveFormat.PPTX)
```


## **为占位符设置提示文本**

标准和预构建布局包含占位符提示文本，例如 **Click to add a title** 或 **Click to add a subtitle**。使用 Aspose.Slides，您可以在占位符布局中将这些提示替换为自己的文本。

```python
import aspose.slides as slides

with slides.Presentation("PromptText.pptx") as presentation:
    slide = presentation.slides[0]

    # 遍历形状以查找占位符。
    for shape in slide.slide.shapes:
        if shape.placeholder is not None and type(shape) is slides.AutoShape:
            if shape.placeholder.type == slides.PlaceholderType.CENTERED_TITLE:
                text = "Add Title"
            elif shape.placeholder.type == slides.PlaceholderType.SUBTITLE:
                text = "Add Subtitle"

            shape.text_frame.text = text
            print(f"Placeholder with text: {text}")

    presentation.save("PromptText_out.pptx", slides.export.SaveFormat.PPTX)
```


## **在占位符中设置图像透明度**

Aspose.Slides 允许您在文本占位符中设置背景图像的透明度。通过调整该框架中图片的透明度，您可以根据颜色使文本或图像突出显示。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    auto_shape.fill_format.fill_type = slides.FillType.PICTURE

    with open("image.png", "rb") as image_stream:
        auto_shape.fill_format.picture_fill_format.picture.image = presentation.images.add_image(image_stream)
        auto_shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
        auto_shape.fill_format.picture_fill_format.picture.image_transform.add_alpha_modulate_fixed_effect(75)
```


## **常见问题**

**什么是基础占位符，它与幻灯片上的本地图形有何不同？**  
基础占位符是布局或母版上的原始形状，幻灯片的形状从中继承类型、位置和部分格式。本地图形是独立的；如果没有基础占位符，继承不适用。

**如何在不遍历每张幻灯片的情况下更新整个演示文稿中的所有标题或说明文字？**  
编辑布局或母版上的相应占位符。基于这些布局/母版的幻灯片会自动继承更改。

**如何控制标准的页眉/页脚占位符——日期时间、幻灯片编号和页脚文字？**  
在适当的范围（普通幻灯片、布局、母版、备注/讲义）使用 HeaderFooter 管理器，打开或关闭这些占位符并设置其内容。