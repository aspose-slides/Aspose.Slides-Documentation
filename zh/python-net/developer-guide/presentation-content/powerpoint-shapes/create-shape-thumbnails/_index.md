---
title: 使用 Python 创建演示文稿形状缩略图
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
description: "使用 Aspose.Slides for Python via .NET 从 PowerPoint 和 OpenDocument 幻灯片生成高质量的形状缩略图 —— 轻松创建并导出演示文稿缩略图。"
---

## **介绍**

Aspose.Slides for Python via .NET 用于创建演示文稿文件，每页对应一个幻灯片。您可以通过打开演示文稿文件在 Microsoft PowerPoint 中查看这些幻灯片。不过，开发者有时需要在图像查看器中单独查看形状的图像。此时，Aspose.Slides 可以为幻灯片形状生成缩略图。本文说明如何使用此功能。

## **从幻灯片生成形状缩略图**

当您只需要特定对象的预览而不是整张幻灯片时，可以为单个形状渲染缩略图。Aspose.Slides 允许将任意形状导出为图像，便于创建轻量级预览、图标或下游处理的资源。

生成任意形状的缩略图：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
1. 使用 ID 或索引获取幻灯片的引用。
1. 获取该幻灯片上某个形状的引用。
1. 渲染该形状的缩略图图像。
1. 将缩略图图像保存为所需格式。

下面的示例生成形状缩略图。
```py
import aspose.slides as slides

# 实例化 Presentation 类以打开演示文稿文件。
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # 创建一个使用默认比例的图像。
    with shape.get_image() as thumbnail:
        # 将图像以 PNG 格式保存到磁盘。
        thumbnail.save("shape_thumbnail.png", slides.ImageFormat.PNG)
```


## **使用自定义缩放因子生成缩略图**

本节展示如何在 Aspose.Slides 中使用用户定义的缩放因子生成形状缩略图。通过控制缩放比例，您可以微调缩略图尺寸，以适应预览、导出或高 DPI 显示。

生成幻灯片上任意形状的缩略图：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
1. 使用 ID 或索引获取幻灯片。
1. 获取该幻灯片上的目标形状。
1. 按指定的缩放比例渲染形状的缩略图图像。
1. 将缩略图图像保存为所需格式。

下面的示例生成带有用户自定义缩放因子的缩略图。
```py
import aspose.slides as slides

scale_x = 2.0
scale_y = scale_x

# 实例化 Presentation 类以打开演示文稿文件。
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # 使用定义的缩放比例创建图像。
    with shape.get_image(slides.ShapeThumbnailBounds.SHAPE, scale_x, scale_y) as thumbnail:
        # 将图像以 PNG 格式保存到磁盘。
        thumbnail.save("scaling_factor.png", slides.ImageFormat.PNG)
```


## **使用形状外观边界生成缩略图**

本节展示如何在形状的外观边界内生成缩略图。它会考虑所有形状效果。生成的缩略图受幻灯片边界限制。

在形状外观边界内为任意幻灯片形状生成缩略图：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
1. 使用 ID 或索引获取幻灯片。
1. 获取该幻灯片上的目标形状。
1. 按指定的边界渲染形状的缩略图图像。
1. 将缩略图图像保存为所需的图像格式。

下面的示例创建了带有用户自定义边界的缩略图。
```py
import aspose.slides as slides

image_bounds = slides.ShapeThumbnailBounds.APPEARANCE

# 实例化 Presentation 类以打开演示文稿文件。
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    # 创建外观边界形状图像。
    with shape.get_image(image_bounds, 1.0, 1.0) as thumbnail:
        # 将图像以 PNG 格式保存到磁盘。
        thumbnail.save("apperance_bounds.png", slides.ImageFormat.PNG)
```


## **FAQ**

**保存形状缩略图时可以使用哪些图像格式？**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/python-net/aspose.slides/imageformat/)，以及其他格式。形状还可以通过将内容保存为 SVG 来[导出为矢量 SVG](https://reference.aspose.com/slides/python-net/aspose.slides/shape/write_as_svg/)。

**在渲染缩略图时，SHAPE 边界和 APPEARANCE 边界有什么区别？**

`SHAPE` 使用形状的几何边界；`APPEARANCE` 会考虑[可视效果](/slides/zh/python-net/shape-effect/)（阴影、发光等）。

**如果形状被标记为隐藏，会怎样？它仍会渲染为缩略图吗？**

隐藏的形状仍是模型的一部分，可以渲染；隐藏标记仅影响幻灯片放映的显示，不会阻止生成形状图像。

**是否支持组形状、图表、SmartArt 及其他复杂对象？**

支持。任何以[Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) 表示的对象（包括[GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/)、[Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/)、以及[SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/)）都可以保存为缩略图或 SVG。

**系统安装的字体会影响文本形状缩略图的质量吗？**

会。您应当[提供所需字体](/slides/zh/python-net/custom-font/)（或[配置字体替换](/slides/zh/python-net/font-substitution/)），以避免出现不期望的回退和文本重新布局。