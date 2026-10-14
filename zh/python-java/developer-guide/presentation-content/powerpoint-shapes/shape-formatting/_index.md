---
title: 在 Python via Java 中格式化 PowerPoint 形状
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
- 3D 倾斜效果
- 3D 旋转效果
- 重置格式
- PowerPoint
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides 在 Python via Java 中格式化 PowerPoint 形状——为 PPT、PPTX 和 ODP 文件精准设置填充、线条和效果样式，拥有完整控制。"
---
## **介绍**

在 PowerPoint 中，您可以向幻灯片添加形状。由于形状由线条组成，您可以通过修改或应用效果来格式化它们的轮廓。此外，您还可以通过指定控制内部填充方式的设置来格式化形状。

![PowerPoint 中的形状格式](format-shape-powerpoint.png)

Aspose.Slides for Python via Java 提供了类和方法，允许您使用 PowerPoint 中相同的选项来格式化形状。

## **格式线条**

使用 Aspose.Slides，您可以为形状指定自定义线条样式。以下步骤概述了该过程：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 向幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/)。
1. 设置形状的 [line style](https://reference.aspose.com/slides/python-java/aspose.slides/linestyle/)。
1. 设置线宽。
1. 设置线条的 [dash style](https://reference.aspose.com/slides/python-java/aspose.slides/linedashstyle/)。
1. 设置形状的线条颜色。
1. 将修改后的演示文稿保存为 PPTX 文件。

以下代码演示了如何格式化矩形 [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/)：

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

    # 添加矩形类型的自动形状。
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

结果：

![演示文稿中格式化的线条](formatted-lines.png)

## **对形状线条应用草图效果**

草图效果使形状线条看起来像手绘。使用 [Shape.getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat) 访问线条设置，使用 [LineFormat.getSketchFormat](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getSketchFormat) 访问草图设置，并使用 [SketchFormat.setSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/sketchformat/#setSketchType) 从 [LineSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/) 枚举中选择值。

以下 Python 代码展示了如何应用 [LineSketchType.Curved](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/#Curved) 效果、读取显式分配的值以及使用 [LineSketchType.None_](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/#None) 移除该效果：

```python
import jpype
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

[SketchFormat.getSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/sketchformat/#getSketchType) 返回的值表示直接分配给形状的设置。如果线条格式可以从主题、母版幻灯片或布局幻灯片继承，请使用 [LineFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getEffective)，访问 `LineFormatEffectiveData.getSketchFormat`，并读取 `SketchFormatEffectiveData.getSketchType`。有效值反映了解决继承后实际应用的格式：

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

## **格式连接样式**

以下是三种连接类型选项：

* 圆角
* 斜角
* 倾斜

默认情况下，PowerPoint 在形状的拐角处以 **圆角** 方式连接两条线。但如果您绘制的是锐角形状，可能更倾向于使用 **斜角** 选项。

![演示文稿中的连接样式](join-style-powerpoint.png)

以下 Python 代码演示了使用斜角、倾斜和圆角连接类型设置创建的三个矩形（如上图所示）：

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

    # 设置每个矩形形状的填充颜色。
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

    # 设置每个矩形线条的颜色。
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

    # 向每个矩形添加文本。
    miter_shape.getTextFrame().setText("Miter Join Style")
    bevel_shape.getTextFrame().setText("Bevel Join Style")
    round_shape.getTextFrame().setText("Round Join Style")

    # 将 PPTX 文件保存到磁盘。
    presentation.save("join_styles.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **渐变填充**

在 PowerPoint 中，渐变填充是一种格式化选项，允许您对形状应用连续的颜色混合。例如，您可以以一种颜色逐渐淡入另一种颜色的方式应用两种或多种颜色。

以下是使用 Aspose.Slides 为形状应用渐变填充的方法：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 向幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/)。
1. 将形状的 [FillType](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) 设置为 `Gradient`。
1. 使用 [GradientFormat](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/) 类公开的渐变停止集合的 [addPresetColor](https://reference.aspose.com/slides/python-java/aspose.slides/gradientstopcollection/#addPresetColor) 方法，添加您首选的两种颜色及其位置。
1. 将修改后的演示文稿保存为 PPTX 文件。

以下 Python 代码演示如何对椭圆应用渐变填充效果：

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

    # 添加椭圆类型的自动形状。
    shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75)

    # 对椭圆应用渐变格式。
    shape.getFillFormat().setFillType(FillType.Gradient)
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear)

    # 设置渐变方向。
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2)

    # 添加两个渐变停止点。
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0, PresetColor.Purple)
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0.0, PresetColor.Red)

    # 将 PPTX 文件保存到磁盘。
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

结果：

![带有渐变填充的椭圆](gradient-fill.png)

如果导出图像中的渐变与 PowerPoint 中显示的不同，请参阅 [Choose a Gradient Rendering Style](/slides/zh/python-java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style)。您可以在不更改演示文稿中存储的渐变填充的情况下选择渲染样式。

## **图案填充**

在 PowerPoint 中，图案填充是一种格式化选项，允许您对形状应用双颜色设计，例如点、条纹、交叉线或格子。您可以为图案的前景色和背景色选择自定义颜色。

Aspose.Slides 提供了超过 45 种预定义图案样式，您可以将其应用于形状以增强演示文稿的视觉效果。即使选择了预定义图案，仍然可以指定其使用的确切颜色。

以下是使用 Aspose.Slides 为形状应用图案填充的方法：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 向幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/)。
1. 将形状的 [FillType](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) 设置为 `Pattern`。
1. 从预定义选项中选择图案样式。
1. 设置图案的 [Background Color](https://reference.aspose.com/slides/python-java/aspose.slides/patternformat/#getBackColor)。
1. 设置图案的 [Foreground Color](https://reference.aspose.com/slides/python-java/aspose.slides/patternformat/#getForeColor)。
1. 将修改后的演示文稿保存为 PPTX 文件。

以下 Python 代码演示如何对矩形应用图案填充：

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

    # 添加矩形类型的自动形状。
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

结果：

![带有图案填充的矩形](pattern-fill.png)

## **图片填充**

在 PowerPoint 中，图片填充是一种格式化选项，允许您在形状内部插入图像——实际上将图像用作形状的背景。

以下是使用 Aspose.Slides 为形状应用图片填充的方法：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 向幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/)。
1. 将形状的 [FillType](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) 设置为 `Picture`。
1. 将图片填充模式设置为 `Tile`（或其他首选模式）。
1. 使用您想要的图像创建一个 [PPImage](https://reference.aspose.com/slides/python-java/aspose.slides/ppimage/) 对象。
1. 将图像传递给 `SlidesPicture.setImage` 方法。
1. 将修改后的演示文稿保存为 PPTX 文件。

假设我们有一个名为 “lotus.png” 的文件，内容如下：

![莲花图片](lotus.png)

以下 Python 代码演示如何使用图片填充形状：

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

    # 添加矩形类型的自动形状。
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130)
    
    # 将填充类型设置为图片。
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

结果：

![带有图片填充的形状](picture-fill.png)

### **将图片平铺为纹理**

如果您想将平铺的图片设为纹理并自定义平铺行为，可以使用 [PictureFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/) 类的以下方法：

- [setPictureFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setPictureFillMode)：设置图片填充模式——`Tile` 或 `Stretch`。
- [setTileAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileAlignment)：指定平铺在形状内部的对齐方式。
- [setTileFlip](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileFlip)：控制平铺是水平翻转、垂直翻转，还是两者都翻转。
- [setTileOffsetX](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileOffsetX)：设置平铺相对于形状原点的水平偏移（单位：磅）。
- [setTileOffsetY](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileOffsetY)：设置平铺相对于形状原点的垂直偏移（单位：磅）。
- [setTileScaleX](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileScaleX)：以百分比定义平铺的水平缩放比例。
- [setTileScaleY](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileScaleY)：以百分比定义平铺的垂直缩放比例。

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

    # 添加矩形自动形状。
    shape = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95)

    # 将形状的填充类型设置为图片。
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

结果：

![平铺选项](tile-options.png)

## **纯色填充**

在 PowerPoint 中，纯色填充是一种格式化选项，可将形状填充为单一、均匀的颜色。此背景颜色不包含任何渐变、纹理或图案。

使用 Aspose.Slides 为形状应用纯色填充的步骤如下：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 向幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/)。
1. 将形状的 [FillType](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) 设置为 `Solid`。
1. 为形状分配您首选的填充颜色。
1. 将修改后的演示文稿保存为 PPTX 文件。

以下 Python 代码演示如何对幻灯片中的矩形应用纯色填充：

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

    # 添加矩形类型的自动形状。
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # 将填充类型设置为实心。
    shape.getFillFormat().setFillType(FillType.Solid)

    # 设置填充颜色。
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW)

    # 将 PPTX 文件保存到磁盘。
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

结果：

![带有纯色填充的形状](solid-color-fill.png)

## **设置透明度**

在 PowerPoint 中，对形状应用纯色、渐变、图片或纹理填充时，您还可以设置透明度级别以控制填充的不透明度。更高的透明度值会使形状更透明，从而部分显示背景或底层对象。

Aspose.Slides 通过调整用于填充的颜色的 alpha 值来设置透明度。操作步骤如下：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 向幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/)。
1. 将 [FillType](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) 设置为 `Solid`。
1. 使用 [Color](https://docs.oracle.com/en/java/javase/17/docs/api/java.desktop/java/awt/Color.html) 定义具有透明度的颜色（`alpha` 分量控制透明度）。
1. 保存演示文稿。

以下 Python 代码演示如何对矩形应用透明填充颜色：

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

结果：

![透明形状](shape-transparency.png)

## **旋转形状**

Aspose.Slides 允许您在 PowerPoint 演示文稿中旋转形状。这在需要特定对齐或设计需求时十分有用。

要在幻灯片上旋转形状，请按以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 向幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/)。
1. 将形状的旋转属性设置为所需的角度。
1. 保存演示文稿。

以下 Python 代码演示如何将形状旋转 5 度：

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

    # 添加矩形类型的自动形状。
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # 将形状旋转 5 度。
    shape.setRotation(5)

    # 将 PPTX 文件保存到磁盘。
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

结果：

![形状旋转](shape-rotation.png)

## **添加 3D 倾斜效果**

Aspose.Slides 通过配置形状的 [ThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/) 属性来为形状添加 3D 倾斜效果。

要为形状添加 3D 倾斜效果，请按以下步骤操作：

1. 实例化 [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) 类。
1. 通过索引获取幻灯片的引用。
1. 向幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/)。
1. 配置形状的 [ThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/) 以定义倾斜设置。
1. 保存演示文稿。

以下 Python 代码展示了如何对形状应用 3D 倾斜效果：

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

结果：

![3D 倾斜效果](3D-bevel-effect.png)

## **添加 3D 旋转效果**

Aspose.Slides 通过配置形状的 [ThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/) 属性来为形状添加 3D 旋转效果。

要对形状应用 3D 旋转：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 向幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/)。
1. 使用 [setCameraType](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#setCameraType) 和 [setLightType](https://reference.aspose.com/slides/python-java/aspose.slides/lightrig/#setLightType) 方法定义 3D 旋转。
1. 保存演示文稿。

以下 Python 代码演示如何对形状应用 3D 旋转效果：

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

结果：

![3D 旋转效果](3D-rotation-effect.png)

## **控制形状的黑白渲染**

[Shape.setBlackWhiteMode](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setBlackWhiteMode) 方法指定在黑白模式下查看或处理演示文稿时单个形状的渲染方式。它本身并不会启用黑白显示，也不会在正常彩色模式下更改形状的填充、线条或其他格式。

使用 [BlackWhiteMode](https://reference.aspose.com/slides/python-java/aspose.slides/blackwhitemode/) 类中的值来选择所需行为。例如，`Automatic` 让渲染应用程序自行决定转换方式，`Gray` 和 `LightGray` 使用灰度，`BlackWhite` 仅使用黑白，`Black` 和 `White` 强制单色，`Color` 保持正常着色，`Hidden` 在黑白模式下隐藏形状，`NotDefined` 表示未为形状级别指定模式。

以下 Python 代码创建了一个彩色形状，并在黑白显示模式下将其呈现为灰色：

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

在正常彩色模式下，矩形保持橙色填充；在黑白显示工作流中，由于其模式被设置为 `Gray`，因此使用灰色显示。这样可以在保留全彩幻灯片的同时，为打印、预览或其他遵循黑白显示设置的工作流定义不同的外观。

## **重置格式**

以下 Python 代码展示了如何重置幻灯片的格式，并将 [LayoutSlide](https://reference.aspose.com/slides/python-java/aspose.slides/layoutslide/) 上所有占位符形状的位置、大小和格式恢复为默认设置：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    for slide in presentation.getSlides():
        # 重置幻灯片上每个在布局上有占位符的形状。
        slide.reset()

    presentation.save("reset_formatting.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **常见问题**

**形状格式化会影响最终演示文稿的文件大小吗？**

影响极小。嵌入的图像和媒体占据了文件的大部分空间，而颜色、效果和渐变等形状参数作为元数据存储，几乎不增加额外大小。

**如何检测幻灯片上具有相同格式的形状以便对它们进行分组？**

比较每个形状的关键格式属性——填充、线条和效果设置。如果所有对应值匹配，则视为相同样式，并在逻辑上将这些形状分组，从而简化后续的样式管理。

**我可以将一组自定义形状样式保存到单独的文件，以便在其他演示文稿中重用吗？**

可以。将带有所需样式的示例形状存储在模板幻灯片或 .POTX 模板文件中。创建新演示文稿时，打开该模板，克隆所需的样式形状，并在需要的地方重新应用其格式。