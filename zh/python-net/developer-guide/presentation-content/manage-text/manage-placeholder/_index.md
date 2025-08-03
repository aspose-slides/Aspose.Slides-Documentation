---
title: 使用 Python 管理演示文稿中的占位符
linktitle: 管理占位符
type: docs
weight: 10
url: /zh/python-net/manage-placeholder/
keywords:
- 占位符
- 文本占位符
- 图像占位符
- 图表占位符
- 提示文本
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides
description: "在 Aspose.Slides for Python via .NET 中轻松管理占位符：替换文本、自定义提示，并在 PowerPoint 和 OpenDocument 中设置图像透明度。"
---

## **更改占位符中的文本**

使用 [Aspose.Slides for Python via .NET](/slides/zh/python-net/)，您可以查找和修改演示文稿中幻灯片上的占位符。Aspose.Slides 允许您更改占位符中的文本。

**先决条件**：您需要一个包含占位符的演示文稿。您可以在标准的Microsoft PowerPoint应用程序中创建这样的演示文稿。

以下是如何使用Aspose.Slides替换演示文稿中占位符文本的方法：

1. 实例化 [`Presentation`](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类并将演示文稿作为参数传递。
2. 通过其索引获取幻灯片引用。
3. 迭代形状以查找占位符。
4. 将占位符形状强制转换为 [`AutoShape`](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)，并使用 [`TextFrame`](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) 修改与 [`AutoShape`](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) 相关联的文本。
5. 保存修改后的演示文稿。

以下Python代码演示了如何更改占位符中的文本：

```python
import aspose.slides as slides

# 实例化演示文稿类
with slides.Presentation(path + "ReplacingText.pptx") as pres:
    # 访问第一张幻灯片
    sld = pres.slides[0]

    # 迭代形状以查找占位符
    for shp in sld.shapes:
        if shp.placeholder != None:
            # 更改每个占位符中的文本
            shp.text_frame.text = "这是占位符"

    # 将演示文稿保存到磁盘
    pres.save("output_out.pptx", slides.export.SaveFormat.PPTX)
```

## **设置占位符中的提示文本**
标准和预构建布局包含诸如 ***单击添加标题*** 或 ***单击添加副标题*** 的占位符提示文本。使用Aspose.Slides，您可以将所需的提示文本插入到占位符布局中。

以下Python代码演示了如何设置占位符中的提示文本：

```python
import aspose.slides as slides

with slides.Presentation(path + "Presentation2.pptx") as pres:
    slide = pres.slides[0]
    for shape in slide.slide.shapes: # 迭代幻灯片
        if shape.placeholder != None and type(shape) is slides.AutoShape:
            text = ""
            if shape.placeholder.type == slides.PlaceholderType.CENTERED_TITLE: # PowerPoint 显示 "单击添加标题"。
                text = "添加标题"
            elif shape.placeholder.type == slides.PlaceholderType.SUBTITLE: # 添加副标题。
                text = "添加副标题"

            shape.text_frame.text = text

            print("占位符文本为: {text}".format(text = text))

    pres.save("Placeholders_PromptText.pptx", slides.export.SaveFormat.PPTX)
```

## **设置占位符图像透明度**

Aspose.Slides 允许您设置文本占位符中背景图像的透明度。通过调整这种框架中图片的透明度，您可以使文本或图像突出（具体取决于文本和图像的颜色）。

以下Python代码演示了如何为图像背景（在形状内部）设置透明度：

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    autoShape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    
    autoShape.fill_format.fill_type = slides.FillType.PICTURE
    with open("image.png", "rb") as in_file:
        autoShape.fill_format.picture_fill_format.picture.image = presentation.images.add_image(in_file)

        autoShape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
        autoShape.fill_format.picture_fill_format.picture.image_transform.add_alpha_modulate_fixed_effect(75)

```