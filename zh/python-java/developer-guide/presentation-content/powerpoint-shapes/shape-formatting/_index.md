---
title: 在 Python 中通过 Java 格式化 PowerPoint 形状
linktitle: 形状格式化
type: docs
weight: 20
url: /zh/python-java/shape-formatting/
keywords:
- 格式化形状
- 格式化线条
- 草图效果
- 草图形状线条
- 格式化连接样式
- 渐变填充
- 图案填充
- 图片填充
- 纹理填充
- 纯色填充
- 形状透明度
- 黑白形状渲染
- 灰度形状渲染
- 旋转形状
- 3d 倾斜效果
- 3d 旋转效果
- 重置格式
- PowerPoint
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "了解如何在 Python 中通过 Java 使用 Aspose.Slides 对 PowerPoint 形状进行格式化——为 PPT、PPTX 和 ODP 文件精确且全面地设置填充、线条和效果样式。"
---
## **简介**

在 PowerPoint 中，您可以向幻灯片添加形状。由于形状由线条组成，您可以通过修改或应用效果到其轮廓来格式化它们。此外，您还可以通过指定控制内部填充方式的设置来格式化形状。

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Python via Java 提供了类和方法，允许您使用 PowerPoint 中相同的选项来格式化形状。

## **格式线条**

使用 Aspose.Slides，您可以为形状指定自定义线条样式。以下步骤概述了该过程：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类的实例。  
1. 按索引获取幻灯片的引用。  
1. 向幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/zh/python-java/aspose.slides/autoshape/)。  
1. 设置形状的 [line style](https://reference.aspose.com/slides/zh/python-java/aspose.slides/linestyle/)。  
1. 设置线宽。  
1. 设置线条的 [dash style](https://reference.aspose.com/slides/zh/python-java/aspose.slides/linedashstyle/)。  
1. 设置形状的线条颜色。  
1. 将修改后的演示文稿保存为 PPTX 文件。

以下代码演示了如何格式化矩形 [AutoShape](https://reference.aspose.com/slides/zh/python-java/aspose.slides/autoshape/)：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineDashStyle, LineStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

# 实例化表示演示文稿文件的 Presentation 类。
presentation = Presentation()
try:
    # 获取第一张幻灯片。
    slide = presentation.getSlides().get_Item(0)

    # 添加一个矩形类型的自动形状。
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75)

    # 设置矩形形状的填充颜色。
    shape.getFillFormat().setFillType(FillType.NoFill)

    # 对矩形的线条应用格式化。
    shape.getLineFormat().setStyle(LineStyle.ThickThin)
    shape.getLineFormat().setWidth(7)
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash)

    # 设置矩形线条的颜色。
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    # 将 PPTX 文件保存到磁盘。
    presentation.save("formatted_lines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

结果如下：

![The formatted lines in the presentation](formatted-lines.png)

## **应用草图效果到形状线条**

草图效果使形状线条看起来像手绘。使用 [Shape.getLineFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shape/#getLineFormat) 访问线条设置，使用 [LineFormat.getSketchFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/lineformat/#getSketchFormat) 访问草图设置，并使用 [SketchFormat.setSketchType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/sketchformat/#setSketchType) 从 [LineSketchType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/linesketchtype/) 枚举中选择一个值。

以下 Python 代码展示了如何应用 [LineSketchType.Curved](https://reference.aspose.com/slides/zh/python-java/aspose.slides/linesketchtype/#Curved) 效果，读取显式分配的值，并使用 [LineSketchType.None_](https://reference.aspose.com/slides/zh/python-java/aspose.slides/linesketchtype/#None) 移除该效果：

```python
import jpide
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LineSketchType, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100)

    # 访问形状的线条格式及其草图格式。
    sketch_format = shape.getLineFormat().getSketchFormat()

    # 应用草图效果。
    sketch_format.setSketchType(LineSketchType.Curved)

    # 读取直接分配给形状的草图效果。
    explicit_sketch_type = sketch_format.getSketchType()
    print(f"Explicit sketch type: {explicit_sketch_type}")

    # 移除草图效果。
    sketch_format.setSketchType(LineSketchType.None_)
finally:
    presentation.dispose()
```

由 [SketchFormat.getSketchType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/sketchformat/#getSketchType) 返回的值表示直接分配给形状的设置。如果线条格式可以继承自主题、母版幻灯片或布局幻灯片，请使用 [LineFormat.getEffective](https://reference.aspose.com/slides/zh/python-java/aspose.slides/lineformat/#getEffective)，访问 `LineFormatEffectiveData.getSketchFormat`，并读取 `SketchFormatEffectiveData.getSketchType`。有效值反映了解决继承后实际应用的格式：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    line_format = shape.getLineFormat()

    explicit_sketch_type = line_format.getSketchFormat().getSketchType()
    effective_line_format = line_format.getEffective()
    effective_sketch_type = effective_line_format.getSketchFormat().getSketchType()

    print(f"Explicit sketch type: {explicit_sketch_type}")
    print(f"Effective sketch type: {effective_sketch_type}")
finally:
    presentation.dispose()
```

## **格式化连接样式**

以下是三种连接类型选项：

* Round
* Miter
* Bevel

默认情况下，当 PowerPoint 在角度处（例如形状的拐角）连接两条线时，会使用 **Round** 设置。然而，如果您绘制的是具有锐角的形状，可能更倾向于使用 **Miter** 选项。

![The join style in the presentation](join-style-powerpoint.png)

以下 Python 代码演示了如何使用 Miter、Bevel 和 Round 连接类型设置创建图中所示的三个矩形：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineJoinStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

# 实例化表示演示文稿文件的 Presentation 类。
presentation = Presentation()
try:
    # 获取第一张幻灯片。
    slide = presentation.getSlides().get_Item(0)

    # 添加三个矩形类型的自动形状。
    miter_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75)
    bevel_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75)
    round_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75)

    # 为每个矩形形状设置填充颜色。
    miter_shape.getFillFormat().setFillType(FillType.Solid)
    miter_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    bevel_shape.getFillFormat().setFillType(FillType.Solid)
    bevel_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    round_shape.getFillFormat().setFillType(FillType.Solid)
    round_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    # 设置线宽。
    miter_shape.getLineFormat().setWidth(15)
    bevel_shape.getLineFormat().setWidth(15)
    round_shape.getLineFormat().setWidth(15)

    # 为每个矩形的线条设置颜色。
    miter_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    miter_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    bevel_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    bevel_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    round_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    round_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    # 设置连接样式。
    miter_shape.getLineFormat().setJoinStyle(LineJoinStyle.Miter)
    bevel_shape.getLineFormat().setJoinStyle(LineJoinStyle.Bevel)
    round_shape.getLineFormat().setJoinStyle(LineJoinStyle.Round)

    # 为每个矩形添加文本。
    miter_shape.getTextFrame().setText("Miter Join Style")
    bevel_shape.getTextFrame().setText("Bevel Join Style")
    round_shape.getTextFrame().setText("Round Join Style")

    # 将 PPTX 文件保存到磁盘。
    presentation.save("join_styles.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **渐变填充**

在 PowerPoint 中，渐变填充是一种格式化选项，允许您对形状应用连续的颜色渐变。例如，您可以以一种颜色逐渐淡入另一种颜色的方式应用两种或多种颜色。

以下是在 Aspose.Slides 中对形状应用渐变填充的方法：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类的实例。  
1. 按索引获取幻灯片的引用。  
1. 向幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/zh/python-java/aspose.slides/autoshape/)。  
1. 将形状的 [FillType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/filltype/) 设置为 `Gradient`。  
1. 使用 [GradientFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/gradientformat/) 类公开的渐变停止集合的 [addPresetColor](https://reference.aspose.com/slides/zh/python-java/aspose.slides/gradientstopcollection/#addPresetColor) 方法，添加您首选的两种颜色并指定位置。  
1. 将修改后的演示文稿保存为 PPTX 文件。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, GradientDirection, GradientShape, Presentation, PresetColor, SaveFormat, ShapeType
from java.awt import Color

# 实例化表示演示文稿文件的 Presentation 类。
presentation = Presentation()
try:
    # 获取第一张幻灯片。
    slide = presentation.getSlides().get_Item(0)

    # 添加一个椭圆类型的自动形状。
    shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75)

    # 对椭圆应用渐变格式化。
    shape.getFillFormat().setFillType(FillType.Gradient)
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear)

    # 设置渐变的方向。
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2)

    # 添加两个渐变停止点。
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0, PresetColor.Purple)
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0.0, PresetColor.Red)

    # 将 PPTX 文件保存到磁盘。
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

结果如下：

![The ellipse with gradient fill](gradient-fill.png)

## **图案填充**

在 PowerPoint 中，图案填充是一种格式化选项，允许您对形状应用二色设计——如点、条纹、交叉阴影或格子。您可以为图案的前景色和背景色选择自定义颜色。

Aspose.Slides 提供了超过 45 种预定义图案样式，您可以将其应用于形状，以提升演示文稿的视觉效果。即使选择了预定义图案，也仍然可以指定其使用的精确颜色。

以下是在 Aspose.Slides 中对形状应用图案填充的方法：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类的实例。  
1. 按索引获取幻灯片的引用。  
1. 向幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/zh/python-java/aspose.slides/autoshape/)。  
1. 将形状的 [FillType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/filltype/) 设置为 `Pattern`。  
1. 从预定义选项中选择一种图案样式。  
1. 设置图案的 [Background Color](https://reference.aspose.com/slides/zh/python-java/aspose.slides/patternformat/#getBackColor)。  
1. 设置图案的 [Foreground Color](https://reference.aspose.com/slides/zh/python-java/aspose.slides/patternformat/#getForeColor)。  
1. 将修改后的演示文稿保存为 PPTX 文件。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, PatternStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

# 实例化表示演示文稿文件的 Presentation 类。
presentation = Presentation()
try:
    # 获取第一张幻灯片。
    slide = presentation.getSlides().get_Item(0)

    # 添加一个矩形类型的自动形状。
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # 将填充类型设置为 Pattern。
    shape.getFillFormat().setFillType(FillType.Pattern)

    # 设置图案样式。
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis)

    # 设置图案的背景色和前景色。
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY)
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW)

    # 将 PPTX 文件保存到磁盘。
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

结果如下：

![The rectangle with pattern fill](pattern-fill.png)

## **图片填充**

在 PowerPoint 中，图片填充是一种格式化选项，允许您在形状内部插入图像——实质上将图像用作形状的背景。

以下是使用 Aspose.Slides 对形状应用图片填充的方法：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类的实例。  
1. 按索引获取幻灯片的引用。  
1. 向幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/zh/python-java/aspose.slides/autoshape/)。  
1. 将形状的 [FillType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/filltype/) 设置为 `Picture`。  
1. 将图片填充模式设置为 `Tile`（或其他首选模式）。  
1. 从要使用的图像创建一个 [PPImage](https://reference.aspose.com/slides/zh/python-java/aspose.slides/ppimage/) 对象。  
1. 将图像传递给 `SlidesPicture.setImage` 方法。  
1. 将修改后的演示文稿保存为 PPTX 文件。

假设我们有一个名为 “lotus.png” 的文件，内容如下图所示：

![The lotus picture](lotus.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Images, PictureFillMode, Presentation, SaveFormat, ShapeType

# 实例化表示演示文稿文件的 Presentation 类。
presentation = Presentation()
try:
    # 获取第一张幻灯片。
    slide = presentation.getSlides().get_Item(0)

    # 添加一个矩形类型的自动形状。
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130)
    
    # 将填充类型设置为 Picture。
    shape.getFillFormat().setFillType(FillType.Picture)

    # 设置图片填充模式。
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile)

    # 加载图像并将其添加到演示文稿资源中。
    image = Images.fromFile("lotus.png")
    picture = presentation.getImages().addImage(image)
    image.dispose()

    # 设置图片。
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture)

    # 将 PPTX 文件保存到磁盘。
    presentation.save("picture_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

结果如下：

![The shape with picture fill](picture-fill.png)

### **将图片平铺为纹理**

如果您想将平铺的图片设置为纹理并自定义平铺行为，可以使用 [PictureFillFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/picturefillformat/) 类的以下方法：

- [setPictureFillMode](https://reference.aspose.com/slides/zh/python-java/aspose.slides/picturefillformat/#setPictureFillMode)：设置图片填充模式——`Tile` 或 `Stretch`。  
- [setTileAlignment](https://reference.aspose.com/slides/zh/python-java/aspose.slides/picturefillformat/#setTileAlignment)：指定平铺在形状内的对齐方式。  
- [setTileFlip](https://reference.aspose.com/slides/zh/python-java/aspose.slides/picturefillformat/#setTileFlip)：控制平铺是否水平翻转、垂直翻转或两者皆翻转。  
- [setTileOffsetX](https://reference.aspose.com/slides/zh/python-java/aspose.slides/picturefillformat/#setTileOffsetX)：设置平铺相对于形状原点的水平偏移（单位为点）。  
- [setTileOffsetY](https://reference.aspose.com/slides/zh/python-java/aspose.slides/picturefillformat/#setTileOffsetY)：设置平铺相对于形状原点的垂直偏移（单位为点）。  
- [setTileScaleX](https://reference.aspose.com/slides/zh/python-java/aspose.slides/picturefillformat/#setTileScaleX)：以百分比定义平铺的水平缩放。  
- [setTileScaleY](https://reference.aspose.com/slides/zh/python-java/aspose.slides/picturefillformat/#setTileScaleY)：以百分比定义平铺的垂直缩放。

以下代码示例展示了如何添加一个带有平铺图片填充的矩形形状并配置平铺选项：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Images, PictureFillMode, Presentation, RectangleAlignment, SaveFormat, ShapeType, TileFlip

# 实例化表示演示文稿文件的 Presentation 类。
presentation = Presentation()
try:
    # 获取第一张幻灯片。
    first_slide = presentation.getSlides().get_Item(0)

    # 添加一个矩形自动形状。
    shape = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95)

    # 将形状的填充类型设置为 Picture。
    shape.getFillFormat().setFillType(FillType.Picture)

    # 加载图像并将其添加到演示文稿资源中。
    source_image = Images.fromFile("lotus.png")
    presentation_image = presentation.getImages().addImage(source_image)
    source_image.dispose()

    # 将图像分配给形状。
    picture_fill_format = shape.getFillFormat().getPictureFillFormat()
    picture_fill_format.getPicture().setImage(presentation_image)

    # 配置图片填充模式和瓦片属性。
    picture_fill_format.setPictureFillMode(PictureFillMode.Tile)
    picture_fill_format.setTileOffsetX(-32)
    picture_fill_format.setTileOffsetY(-32)
    picture_fill_format.setTileScaleX(50)
    picture_fill_format.setTileScaleY(50)
    picture_fill_format.setTileAlignment(RectangleAlignment.BottomRight)
    picture_fill_format.setTileFlip(TileFlip.FlipBoth)

    # 将 PPTX 文件保存到磁盘。
    presentation.save("tile.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

结果如下：

![The tile options](tile-options.png)

## **纯色填充**

在 PowerPoint 中，纯色填充是一种格式化选项，用单一、统一的颜色填充形状。此纯色背景颜色不包含任何渐变、纹理或图案。

使用 Aspose.Slides 对形状应用纯色填充，请按以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类的实例。  
1. 按索引获取幻灯片的引用。  
1. 向幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/zh/python-java/aspose.slides/autoshape/)。  
1. 将形状的 [FillType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/filltype/) 设置为 `Solid`。  
1. 为形状分配您首选的填充颜色。  
1. 将修改后的演示文稿保存为 PPTX 文件。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# 实例化表示演示文稿文件的 Presentation 类。
presentation = Presentation()
try:
    # 获取第一张幻灯片。
    slide = presentation.getSlides().get_Item(0)

    # 添加一个矩形类型的自动形状。
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # 将填充类型设置为 Solid。
    shape.getFillFormat().setFillType(FillType.Solid)

    # 设置填充颜色。
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW)

    # 将 PPTX 文件保存到磁盘。
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

结果如下：

![The shape with solid color fill](solid-color-fill.png)

## **设置透明度**

在 PowerPoint 中，当您对形状应用纯色、渐变、图片或纹理填充时，还可以设置透明度级别以控制填充的透明度。更高的透明度值会使形状更透明，从而部分显示背景或底层对象。

Aspose.Slides 通过调整用于填充的颜色的 alpha 值来设置透明度。下面是实现方法：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类的实例。  
1. 按索引获取幻灯片的引用。  
1. 向幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/zh/python-java/aspose.slides/autoshape/)。  
1. 将 [FillType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/filltype/) 设置为 `Solid`。  
1. 使用 [Color](https://docs.oracle.com/en/java/javase/17/docs/api/java.desktop/java/awt/Color.html) 定义具有透明度的颜色（`alpha` 分量控制透明度）。  
1. 保存演示文稿。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# 实例化表示演示文稿文件的 Presentation 类。
presentation = Presentation()
try:
    # 获取第一张幻灯片。
    slide = presentation.getSlides().get_Item(0)

    # 添加实心矩形自动形状。
    solid_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # 在实心形状上添加透明矩形自动形状。
    transparent_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75)
    transparent_shape.getFillFormat().setFillType(FillType.Solid)
    transparent_color = Color(255, 255, 0, 204)
    transparent_shape.getFillFormat().getSolidFillColor().setColor(transparent_color)

    # 将 PPTX 文件保存到磁盘。
    presentation.save("shape_transparency.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

结果如下：

![The transparent shape](shape-transparency.png)

## **旋转形状**

Aspose.Slides 允许您在 PowerPoint 演示文稿中旋转形状。这在定位具有特定对齐或设计需求的视觉元素时非常有用。

要在幻灯片上旋转形状，请按以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类的实例。  
1. 按索引获取幻灯片的引用。  
1. 向幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/zh/python-java/aspose.slides/autoshape/)。  
1. 将形状的 rotation 属性设置为所需的角度。  
1. 保存演示文稿。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# 实例化表示演示文稿文件的 Presentation 类。
presentation = Presentation()
try:
    # 获取第一张幻灯片。
    slide = presentation.getSlides().get_Item(0)

    # 添加一个矩形类型的自动形状。
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # 将形状旋转 5 度。
    shape.setRotation(5)

    # 将 PPTX 文件保存到磁盘。
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

结果如下：

![The shape rotation](shape-rotation.png)

## **添加 3D 倾斜效果**

Aspose.Slides 通过配置形状的 [ThreeDFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/threedformat/) 属性来为形状添加 3D 倾斜效果。

要为形状添加 3D 倾斜效果，请按以下步骤操作：

1. 实例化 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类。  
1. 按索引获取幻灯片的引用。  
1. 向幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/zh/python-java/aspose.slides/autoshape/)。  
1. 配置形状的 [ThreeDFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/threedformat/) 以定义倾斜设置。  
1. 保存演示文稿。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BevelPresetType, CameraPresetType, FillType, LightRigPresetType, LightingDirection, Presentation, SaveFormat, ShapeType
from java.awt import Color

# 创建 Presentation 类的实例。
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # 向幻灯片添加形状。
    shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color.GREEN)
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.ORANGE)
    shape.getLineFormat().setWidth(2.0)

    # 设置形状的 ThreeDFormat 属性。
    shape.getThreeDFormat().setDepth(4)
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle)
    shape.getThreeDFormat().getBevelTop().setHeight(6)
    shape.getThreeDFormat().getBevelTop().setWidth(6)
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)

    # 将演示文稿保存为 PPTX 文件。
    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

结果如下：

![The 3D bevel effect](3D-bevel-effect.png)

## **添加 3D 旋转效果**

Aspose.Slides 通过配置形状的 [ThreeDFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/threedformat/) 属性来为形状应用 3D 旋转效果。

要对形状进行 3D 旋转，请：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类的实例。  
1. 按索引获取幻灯片的引用。  
1. 向幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/zh/python-java/aspose.slides/autoshape/)。  
1. 使用 [setCameraType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/camera/#setCameraType) 和 [setLightType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/lightrig/#setLightType) 方法定义 3D 旋转。  
1. 保存演示文稿。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, LightRigPresetType, Presentation, SaveFormat, ShapeType

# 创建 Presentation 类的实例。
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)
    auto_shape.getTextFrame().setText("Hello, Aspose!")

    auto_shape.getThreeDFormat().setDepth(6)
    auto_shape.getThreeDFormat().getCamera().setRotation(40, 35, 20)
    auto_shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp)
    auto_shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced)

    # 将演示文稿保存为 PPTX 文件。
    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

结果如下：

![The 3D rotation effect](3D-rotation-effect.png)

## **控制形状的黑白呈现**

[Shape.setBlackWhiteMode](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shape/#setBlackWhiteMode) 方法指定在以黑白模式查看或处理演示文稿时，单个形状的呈现方式。它本身不会启用黑白显示，也不会在正常彩色模式下更改形状的填充、线条或其他格式。

使用 [BlackWhiteMode](https://reference.aspose.com/slides/zh/python-java/aspose.slides/blackwhitemode/) 类中的值来选择所需的行为。例如，`Automatic` 让渲染应用程序自行选择转换方式，`Gray` 和 `LightGray` 使用灰色，`BlackWhite` 仅使用黑白，`Black` 和 `White` 强制单色，`Color` 保持正常着色，`Hidden` 在黑白模式下隐藏形状。`NotDefined` 表示未为形状级别指定模式。

以下 Python 代码创建了一个彩色形状，并在黑白显示模式下使其呈现为灰色：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BlackWhiteMode, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color.ORANGE)

    # 在彩色模式下保持橙色填充，但在黑白模式下以灰色渲染形状。
    shape.setBlackWhiteMode(BlackWhiteMode.Gray)

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

在正常彩色模式下，矩形保持橙色填充。在黑白显示工作流中，它使用灰色着色，因为其模式设置为 `Gray`。这使您能够在保留全彩幻灯片的同时，为打印、预览或其他遵循演示文稿黑白显示设置的工作流定义不同的外观。

## **重置格式**

以下 Python 代码展示了如何重置幻灯片的格式，并将 [LayoutSlide](https://reference.aspose.com/slides/zh/python-java/aspose.slides/layoutslide/) 上所有带占位符的形状的位置、大小和格式恢复为默认设置：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    for slide in presentation.getSlides():
        # 重置幻灯片上每个在布局中具有占位符的形状。
        slide.reset()

    presentation.save("reset_formatting.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**形状格式会影响最终演示文稿的文件大小吗？**

影响极小。嵌入的图像和媒体占据了大部分文件空间，而形状参数如颜色、效果和渐变仅以元数据形式存储，几乎不增加额外大小。

**如何检测幻灯片上具有相同格式的形状以便对其进行分组？**

比较每个形状的关键格式属性——填充、线条和效果设置。如果所有对应值匹配，则视其样式为相同，并在逻辑上对这些形状进行分组，这样可以简化后续的样式管理。

**我可以将一组自定义形状样式保存到单独的文件，以便在其他演示文稿中重用吗？**

可以。将带有所需样式的示例形状存放在模板幻灯片文稿或 .POTX 模板文件中。创建新演示文稿时，打开该模板，克隆所需的样式形状，并在需要的地方重新应用其格式。