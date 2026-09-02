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
- 可视边界
- 形状边界
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 从 PowerPoint 和 OpenDocument 幻灯片生成高质量的形状缩略图——轻松创建并导出演示文稿缩略图。"
---
## **简介**

Aspose.Slides for Python via .NET 用于创建每页为幻灯片的演示文稿文件。您可以通过打开演示文稿文件在 Microsoft PowerPoint 中查看这些幻灯片。但是，开发人员有时可能需要在图像查看器中单独查看形状的图像。在这种情况下，Aspose.Slides 可以为幻灯片形状生成缩略图图像。本文说明如何使用此功能。

## **从幻灯片生成形状缩略图**

当您需要特定对象的预览而不是整个幻灯片时，可以为单个形状渲染缩略图。Aspose.Slides 允许将任何形状导出为图像，轻松创建轻量级预览、图标或后续处理所需的资源。

要从任意形状生成缩略图：

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 类的实例。  
2. 通过 ID 或索引获取幻灯片的引用。  
3. 获取该幻灯片上形状的引用。  
4. 渲染形状的缩略图图像。  
5. 以所需格式保存缩略图图像。

下面的示例生成形状缩略图。

```py
import aspose.slides as slides

# 实例化 Presentation 类以打开演示文稿文件。
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # 使用默认比例创建图像。
    with shape.get_image() as thumbnail:
        # 以 PNG 格式将图像保存到磁盘。
        thumbnail.save("shape_thumbnail.png", slides.ImageFormat.PNG)
```

## **使用自定义缩放因子生成缩略图**

本节展示如何在 Aspose.Slides 中使用用户定义的缩放因子生成形状缩略图。通过控制比例，可以微调缩略图大小，以适应预览、导出或高 DPI 显示。

要为幻灯片上的任意形状生成缩略图：

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 类的实例。  
2. 通过 ID 或索引获取幻灯片。  
3. 获取该幻灯片上的目标形状。  
4. 使用指定的缩放比例渲染形状的缩略图图像。  
5. 以所需格式保存缩略图图像。

下面的示例生成具有用户定义缩放因子的缩略图。

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
        # 以 PNG 格式将图像保存到磁盘。
        thumbnail.save("scaling_factor.png", slides.ImageFormat.PNG)
```

## **使用形状外观边界生成缩略图**

本节展示如何在形状的外观边界内生成缩略图。它会考虑所有形状效果。生成的缩略图受幻灯片边界限制。

要在形状外观的边界内为任意幻灯片形状生成缩略图：

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 类的实例。  
2. 通过 ID 或索引获取幻灯片。  
3. 获取该幻灯片上的目标形状。  
4. 使用指定的边界渲染形状的缩略图图像。  
5. 以所需的图像格式保存缩略图图像。

下面的示例创建具有用户定义边界的缩略图。

```py
import aspose.slides as slides

image_bounds = slides.ShapeThumbnailBounds.APPEARANCE

# 实例化 Presentation 类以打开演示文稿文件。
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    # 创建外观边界形状图像。
    with shape.get_image(image_bounds, 1.0, 1.0) as thumbnail:
        # 以 PNG 格式将图像保存到磁盘。
        thumbnail.save("apperance_bounds.png", slides.ImageFormat.PNG)
```

## **获取形状的实际可视边界**

[Shape](https://reference.aspose.com/slides/zh/python-net/aspose.slides/shape/) 的框架属性——`Shape.x`、`Shape.y`、`Shape.width` 和 `Shape.height`——描述了存储在演示模型中的矩形。实际渲染的内容可能超出该框架或占用不同的轴对齐矩形。旋转、轮廓、箭头、文本布局与溢出、生成的 SmartArt 几何以及其他渲染效果都可能改变占用区域。

使用 [Shape.get_visual_bounds](https://reference.aspose.com/slides/zh/python-net/aspose.slides/shape/get_visual_bounds/) 可在不创建图像的情况下计算该占用区域。该方法返回幻灯片坐标系中的浮点矩形。返回的矩形未裁剪到幻灯片，因此当内容超出幻灯片原点时，其坐标可能为负。

以下示例获取并比较框架和可视边界：

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation("example.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    visual_bounds = shape.get_visual_bounds()

    frame_values = (shape.x, shape.y, shape.width, shape.height)
    visual_values = (visual_bounds.x, visual_bounds.y, visual_bounds.width, visual_bounds.height)

    print(f"Frame bounds (x, y, width, height): {frame_values}")
    print(f"Visual bounds (x, y, width, height): {visual_values}")
```

相同的矩形可用于将相邻形状对齐到其 `left`、`right`、`top` 或 `bottom` 边缘；在生成的布局中预留足够空间；或检测超出允许区域的内容。可视边界对 SmartArt、文本框、箭头、图片、旋转形状和组合形状尤为有用，因为存储的框架可能并未表示完整的渲染结果。

当需要布局或验证坐标且不需要位图时，请使用 [Shape.get_visual_bounds](https://reference.aspose.com/slides/zh/python-net/aspose.slides/shape/get_visual_bounds/)。需要渲染形状时，请使用 [Shape.get_image](https://reference.aspose.com/slides/zh/python-net/aspose.slides/shape/get_image/)。使用 [ShapeThumbnailBounds](https://reference.aspose.com/slides/zh/python-net/aspose.slides/shapethumbnailbounds/)，`ShapeThumbnailBounds.SHAPE` 根据形状边界（包括轮廓设置）确定图像大小，而 `ShapeThumbnailBounds.APPEARANCE` 根据形状的外观确定大小并将结果限制在幻灯片边界内。相比之下，`Shape.get_visual_bounds` 仅返回计算得到的矩形且不裁剪到幻灯片。

## **常见问题**

**保存形状缩略图时可以使用哪些图像格式？**  

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/zh/python-net/aspose.slides/imageformat/)，以及其他格式。形状也可以通过将形状内容保存为 SVG 来[导出为矢量 SVG](https://reference.aspose.com/slides/zh/python-net/aspose.slides/shape/write_as_svg/)。

**在渲染缩略图时，SHAPE 边界和 APPEARANCE 边界有什么区别？**  

`SHAPE` 使用形状的几何；`APPEARANCE` 考虑[视觉效果](/slides/zh/python-net/shape-effect/)(阴影、发光等)。

**如果形状被标记为隐藏会怎样？它仍会渲染为缩略图吗？**  

隐藏的形状仍然是模型的一部分并且可以渲染；隐藏标志影响幻灯片放映显示，但不会阻止生成形状的图像。

**是否支持组合形状、图表、SmartArt 和其他复杂对象？**  

是的。任何以 [Shape](https://reference.aspose.com/slides/zh/python-net/aspose.slides/shape/) 表示的对象（包括 [GroupShape](https://reference.aspose.com/slides/zh/python-net/aspose.slides/groupshape/)、[Chart](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/chart/)、和 [SmartArt](https://reference.aspose.com/slides/zh/python-net/aspose.slides.smartart/smartart/)）都可以保存为缩略图或 SVG。

**系统安装的字体会影响文本形状缩略图的质量吗？**  

会。您应[提供所需的字体](/slides/zh/python-net/custom-font/)（或[配置字体替代](/slides/zh/python-net/font-substitution/)），以避免不必要的回退和文本重排。