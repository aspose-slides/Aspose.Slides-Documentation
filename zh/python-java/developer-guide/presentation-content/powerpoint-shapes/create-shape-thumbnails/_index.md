---
title: 使用 Python via Java 创建演示文稿形状的缩略图
linktitle: 形状缩略图
type: docs
weight: 70
url: /zh/python-java/create-shape-thumbnails/
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
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 从 PowerPoint 幻灯片生成高质量的形状缩略图——轻松创建并导出演示文稿缩略图。"
---
## **简介**

Aspose.Slides for Python via Java 可用于创建演示文稿文件，其中每页对应一张幻灯片。可以使用 Microsoft PowerPoint 打开演示文稿文件来查看幻灯片。但是，开发人员有时需要在图像查看器中单独查看形状的图像。在这种情况下，Aspose.Slides for Python via Java 可帮助他们生成幻灯片形状的缩略图图像。

本文说明了以不同方式生成形状缩略图的方法：

- 在幻灯片内生成形状缩略图。
- 为幻灯片形状生成具有用户自定义尺寸的形状缩略图。
- 在形状外观的边界内生成形状缩略图。

## **从幻灯片生成形状缩略图**

要使用 Aspose.Slides for Python via Java 从任意幻灯片生成形状缩略图，请执行以下操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类的实例。  
2. 使用其 ID 或索引获取对幻灯片的引用。  
3. [获取形状缩略图图像](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shape/#getImage)（在默认比例下）位于引用的幻灯片上的形状。  
4. 将缩略图图像保存为您首选的图像格式。

此示例代码展示了如何从幻灯片生成形状缩略图：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

# 实例化一个表示演示文稿文件的 Presentation 类。
presentation = Presentation("Thumbnail.pptx")
try:
    # 创建一个全比例图像。
    shape_image = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getImage()
    try:
        # 将图像以 PNG 格式保存到磁盘。
        shape_image.save("output.png", ImageFormat.Png)
    finally:
        shape_image.dispose()
finally:
    presentation.dispose()
```

## **使用用户自定义缩放因子生成缩略图**

要使用 Aspose.Slides for Python via Java 生成幻灯片的形状缩略图，请执行以下操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类的实例。  
2. 使用其 ID 或索引获取对幻灯片的引用。  
3. [获取形状缩略图图像](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shape/#getImage)（使用用户自定义尺寸）位于引用的幻灯片上的形状。  
4. 将缩略图图像保存为您首选的图像格式。

此示例代码展示了如何基于定义的缩放因子生成形状缩略图：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, ShapeThumbnailBounds

# 实例化一个表示演示文稿文件的 Presentation 类。
presentation = Presentation("Thumbnail.pptx")
try:
    # 创建一个在两个方向上均按 2 倍比例缩放的图像。
    shape_image = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Shape, 2, 2)
    try:
        # 将图像以 PNG 格式保存到磁盘。
        shape_image.save("output.png", ImageFormat.Png)
    finally:
        shape_image.dispose()
finally:
    presentation.dispose()
```

## **创建基于边界的形状外观缩略图**

此方法创建形状缩略图，使开发人员能够在形状外观的边界内生成缩略图。它考虑了所有形状效果。生成的形状缩略图受幻灯片边界的限制。要在外观边界内生成幻灯片形状的缩略图，请执行以下操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类的实例。  
2. 使用其 ID 或索引获取对幻灯片的引用。  
3. 使用外观边界获取引用幻灯片上形状的缩略图图像。  
4. 将缩略图图像保存为您首选的图像格式。

基于上述步骤的示例代码：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, ShapeThumbnailBounds

# 实例化一个表示演示文稿文件的 Presentation 类。
presentation = Presentation("Thumbnail.pptx")
try:
    # 创建一个全比例图像。
    shape_image = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1)
    try:
        # 将图像以 PNG 格式保存到磁盘。
        shape_image.save("output.png", ImageFormat.Png)
    finally:
        shape_image.dispose()
finally:
    presentation.dispose()
```

## **获取形状的实际可视边界**

[Shape](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shape/) 的框架属性——其 [getX](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shape/#getX)、[getY](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shape/#getY)、[getWidth](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shape/#getWidth) 和 [getHeight](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shape/#getHeight) 方法——描述了存储在演示模型中的矩形。实际渲染的内容可能超出该框架或占据不同的轴对齐矩形。旋转、轮廓、箭头、文本布局与溢出、生成的 SmartArt 几何以及其他渲染效果都可能改变占用区域。

使用 [Shape.getVisualBounds](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shape/#getVisualBounds) 可在不创建图像的情况下计算该占用区域。该方法返回以幻灯片坐标表示的 [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html)。返回的矩形未被裁剪到幻灯片内，因此当内容超出幻灯片原点时，其坐标可能为负。

以下示例获取并比较框架和可视边界：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from java.awt.geom import Rectangle2D

presentation = Presentation("example.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    visual_bounds = shape.getVisualBounds()
    frame_bounds = Rectangle2D.Float(shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight())

    print("Frame bounds:", frame_bounds)
    print("Visual bounds:", visual_bounds)
finally:
    presentation.dispose()
```

相同的 [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) 可用于将相邻形状对齐到其左、右、上或下边缘；在生成的布局中预留足够空间；或检测内容是否超出允许的区域。可视边界对于 SmartArt、文本框、箭头、图片、旋转形状和组合形状尤为有用，因为存储的框架可能未能完整表示渲染结果。

当您需要布局或验证的坐标且不需要位图时，请使用 [Shape.getVisualBounds]。当您需要渲染形状时，请使用 [Shape.getImage]。使用 [ShapeThumbnailBounds] 时， [ShapeThumbnailBounds.Shape] 根据形状边界（包括轮廓设置）确定图像大小，而 [ShapeThumbnailBounds.Appearance] 根据形状的外观确定大小并将结果限制在幻灯片边界内。相对而言，[Shape.getVisualBounds] 仅返回计算得到的矩形且不裁剪到幻灯片。

## **FAQ**

**保存形状缩略图时可以使用哪些图像格式？**  
[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/zh/python-java/aspose.slides/imageformat/)，以及其他格式。形状还可以通过将形状内容保存为 SVG 来[导出为矢量 SVG](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shape/#writeAsSvgToBytes)。

**在渲染缩略图时，Shape 边界和 Appearance 边界有什么区别？**  
`Shape` 使用形状的几何；`Appearance` 会考虑[视觉效果](/slides/zh/python-java/shape-effect/)（阴影、发光等）。

**如果形状被标记为隐藏会怎样？它仍会生成缩略图吗？**  
隐藏的形状仍是模型的一部分，可以渲染；隐藏标志影响幻灯片放映显示，但不会阻止生成形状的图像。

**是否支持组合形状、图表、SmartArt 和其他复杂对象？**  
是的。任何表示为 [Shape](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shape/)（包括 [GroupShape](https://reference.aspose.com/slides/zh/python-java/aspose.slides/groupshape/)、[Chart](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chart/) 和 [SmartArt](https://reference.aspose.com/slides/zh/python-java/aspose.slides/smartart/)）的对象均可保存为缩略图或 SVG。

**系统安装的字体会影响文本形状缩略图的质量吗？**  
会的。您应当[提供所需的字体](/slides/zh/python-java/custom-font/)（或[配置字体替换](/slides/zh/python-java/font-substitution/)）以避免不必要的回退和文本重排。