---
title: 在 Python 中创建演示文稿形状的缩略图
linktitle: 形状缩略图
type: docs
weight: 70
url: /zh/python-net/create-shape-thumbnails/
keywords:
- 形状缩略图
- 形状图像
- 渲染形状
- 形状渲染
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 从 PowerPoint 和 OpenDocument 幻灯片生成高质量的形状缩略图——轻松创建和导出演示文稿缩略图。"
---

## **简介**

Aspose.Slides for Python via .NET 用于创建每页都是幻灯片的演示文稿文件。您可以通过打开演示文稿文件在 Microsoft PowerPoint 中查看这些幻灯片。然而，开发人员有时需要在图像查看器中单独查看形状的图像。在这种情况下，Aspose.Slides 可以为幻灯片形状生成缩略图图像。本文档说明了如何使用此功能。

## **从幻灯片生成形状缩略图**

当您需要仅预览特定对象而不是整张幻灯片时，可以为单个形状渲染缩略图。Aspose.Slides 允许您将任意形状导出为图像，便于创建轻量级预览、图标或后续处理的资产。

要从任意形状生成缩略图：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
1. 通过 ID 或索引获取幻灯片的引用。
1. 获取该幻灯片上形状的引用。
1. 渲染形状的缩略图图像。
1. 将缩略图图像保存为所需格式。

下面的示例生成形状缩略图。

```py
import aspose.slides as slides

# 实例化 Presentation 类以打开演示文稿文件。
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # 使用默认比例创建图像。
    with shape.get_image() as thumbnail:
        # 将图像保存为 PNG 格式到磁盘。
        thumbnail.save("shape_thumbnail.png", slides.ImageFormat.PNG)
```

## **使用自定义缩放因子生成缩略图**

本节展示如何在 Aspose.Slides 中使用用户自定义的缩放因子生成形状缩略图。通过控制比例，您可以微调缩略图大小，以满足预览、导出或高 DPI 显示的需求。

要为幻灯片上的任意形状生成缩略图：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
1. 获取幻灯片的引用（通过 ID 或索引）。
1. 获取该幻灯片上目标形状的引用。
1. 使用指定的比例渲染形状的缩略图图像。
1. 将缩略图图像保存为所需格式。

下面的示例使用用户定义的缩放因子生成缩略图。

```py
import aspose.slides as slides

scale_x = 2.0
scale_y = scale_x

# 实例化 Presentation 类以打开演示文稿文件。
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # 使用定义的比例创建图像。
    with shape.get_image(slides.ShapeThumbnailBounds.SHAPE, scale_x, scale_y) as thumbnail:
        # 将图像保存为 PNG 格式到磁盘。
        thumbnail.save("scaling_factor.png", slides.ImageFormat.PNG)
```

## **使用形状外观边界生成缩略图**

本节展示如何在形状的外观边界内生成缩略图。它会考虑所有形状效果，生成的缩略图受幻灯片边界限制。

要在形状外观边界内为任意幻灯片形状生成缩略图：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
1. 获取幻灯片的引用（通过 ID 或索引）。
1. 获取该幻灯片上目标形状的引用。
1. 使用指定的边界渲染形状的缩略图图像。
1. 将缩略图图像保存为所需的图像格式。

下面的示例使用用户定义的边界创建缩略图。

```py
import aspose.slides as slides

image_bounds = slides.ShapeThumbnailBounds.APPEARANCE

# 实例化 Presentation 类以打开演示文稿文件。
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    # 创建外观边界的形状图像。
    with shape.get_image(image_bounds, 1.0, 1.0) as thumbnail:
        # 将图像保存为 PNG 格式到磁盘。
        thumbnail.save("apperance_bounds.png", slides.ImageFormat.PNG)
```

## **FAQ**

**保存形状缩略图时可以使用哪些图像格式？**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/python-net/aspose.slides/imageformat/)，以及其他格式。形状还可以通过将其内容保存为 SVG 来[导出为矢量 SVG](/slides/zh/python-net/shape/write_as_svg/)。

**渲染缩略图时 SHAPE 与 APPEARANCE 边界有何区别？**

`SHAPE` 使用形状的几何边界；`APPEARANCE` 会考虑[可视效果](/slides/zh/python-net/shape-effect/)（阴影、发光等）。

**如果形状被标记为隐藏，会怎样？它仍会生成缩略图吗？**

隐藏的形状仍是模型的一部分，可以被渲染；隐藏标记仅影响幻灯片放映的显示，不会阻止生成形状图像。

**是否支持组形状、图表、SmartArt 和其他复杂对象？**

是的。任何作为[Shape](/slides/zh/python-net/aspose.slides/shape/) 表示的对象（包括[GroupShape](/slides/zh/python-net/aspose.slides/groupshape/)、[Chart](/slides/zh/python-net/aspose.slides.charts/chart/)以及[SmartArt](/slides/zh/python-net/aspose.slides.smartart/smartart/)）都可以保存为缩略图或 SVG。

**系统安装的字体会影响文本形状缩略图的质量吗？**

会。您应当[提供所需的字体](/slides/zh/python-net/custom-font/)，或[配置字体替换](/slides/zh/python-net/font-substitution/)，以避免出现不期望的回退和文本重排。