---
title: 在 Python 中格式化 PowerPoint 形状
linktitle: 形状格式设置
type: docs
weight: 20
url: /zh/python-net/shape-formatting/
keywords:
- 形状格式化
- 线条格式化
- 连接样式格式化
- 渐变填充
- 图案填充
- 图片填充
- 纹理填充
- 纯色填充
- 形状透明度
- 旋转形状
- 3D 倒角效果
- 3D 旋转效果
- 重置格式
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides
description: "学习如何在 Python 中使用 Aspose.Slides 格式化 PowerPoint 形状——以精确且完全可控的方式为 PPT、PPTX 和 ODP 文件设置填充、线条和效果样式。"
---

在 PowerPoint 中，您可以在幻灯片上添加形状。由于形状是由线条组成的，您可以通过修改或应用某些效果来格式化形状的构成线条。此外，您还可以通过指定设置来格式化形状，从而决定它们（其中的区域）如何填充。

![format-shape-powerpoint](format-shape-powerpoint.png)

**Aspose.Slides for Python via .NET** 提供的接口和属性允许您根据 PowerPoint 中已知的选项来格式化形状。

## **格式化线条**

使用 Aspose.Slides，您可以为形状指定所需的线条样式。这些步骤概述了这样一个过程：

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 向幻灯片添加 [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/)。
4. 为形状的线条设置颜色。
5. 为形状的线条设置宽度。
6. 为形状的线条设置 [line style](https://reference.aspose.com/slides/python-net/aspose.slides/linestyle/)。
7. 为形状的线条设置 [dash style](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/)。
8. 将修改后的演示文稿写入 PPTX 文件。

以下 Python 代码演示了格式化一个矩形 `AutoShape` 的操作：

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# 实例化一个表示 PPTX 文件的 Presentation 类
with slides.Presentation() as pres:
    # 获取第一张幻灯片
    sld = pres.slides[0]

    # 添加一个矩形自动形状
    shp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 75)

    # 设置矩形形状的填充颜色
    shp.fill_format.fill_type = slides.FillType.SOLID
    shp.fill_format.solid_fill_color.color = draw.Color.white

    # 对矩形的线条应用一些格式
    shp.line_format.style = slides.LineStyle.THICK_THIN
    shp.line_format.width = 7
    shp.line_format.dash_style = slides.LineDashStyle.DASH

    # 设置矩形线条的颜色
    shp.line_format.fill_format.fill_type = slides.FillType.SOLID
    shp.line_format.fill_format.solid_fill_color.color = draw.Color.blue

    # 将 PPTX 文件写入磁盘
    pres.save("RectShpLn_out-1.pptx", slides.export.SaveFormat.PPTX)
```

## **格式化连接样式**

这三种连接类型选项是：

* 圆角
* 切角
* 平角

默认情况下，当 PowerPoint 在一个角度（或形状的角落）连接两条线时，使用 **圆角** 设置。然而，如果您希望绘制具有非常尖锐角度的形状，则可能希望选择 **切角**。

![join-style-powerpoint](join-style-powerpoint.png)

以下 Python 代码演示了一个操作，其中创建了 3 个矩形（上图）并使用了切角、平角和圆角连接类型设置：

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# 实例化一个表示 PPTX 文件的 Presentation 类
with slides.Presentation() as pres:
	# 获取第一张幻灯片
	sld = pres.slides[0]

	# 添加 3 个矩形自动形状
	shp1 = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 100, 150, 75)
	shp2 = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 100, 150, 75)
	shp3 = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 250, 150, 75)

	# 设置矩形形状的填充颜色
	shp1.fill_format.fill_type = slides.FillType.SOLID
	shp1.fill_format.solid_fill_color.color = draw.Color.black
	shp2.fill_format.fill_type = slides.FillType.SOLID
	shp2.fill_format.solid_fill_color.color = draw.Color.black
	shp3.fill_format.fill_type = slides.FillType.SOLID
	shp3.fill_format.solid_fill_color.color = draw.Color.black

	# 设置线条的宽度
	shp1.line_format.width = 15
	shp2.line_format.width = 15
	shp3.line_format.width = 15

	# 设置矩形线条的颜色
	shp1.line_format.fill_format.fill_type = slides.FillType.SOLID
	shp1.line_format.fill_format.solid_fill_color.color = draw.Color.blue
	shp2.line_format.fill_format.fill_type = slides.FillType.SOLID
	shp2.line_format.fill_format.solid_fill_color.color = draw.Color.blue
	shp3.line_format.fill_format.fill_type = slides.FillType.SOLID
	shp3.line_format.fill_format.solid_fill_color.color = draw.Color.blue

	# 设置连接样式
	shp1.line_format.join_style = slides.LineJoinStyle.MITER
	shp2.line_format.join_style = slides.LineJoinStyle.BEVEL
	shp3.line_format.join_style = slides.LineJoinStyle.ROUND

	# 向每个矩形添加文本
	shp1.text_frame.text = "这是切角连接样式"
	shp2.text_frame.text = "这是平角连接样式"
	shp3.text_frame.text = "这是圆角连接样式"

	# 将 PPTX 文件写入磁盘
	pres.save("RectShpLnJoin_out-2.pptx", slides.export.SaveFormat.PPTX)
```


## **渐变填充**
在 PowerPoint 中，渐变填充是一种格式选项，允许您将颜色的连续渐变应用于形状。例如，您可以在一个设置中应用两种或更多颜色，其中一种颜色逐渐淡出并变成另一种颜色。

以下方法是使用 Aspose.Slides 将渐变填充应用于形状：

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 向幻灯片添加 [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/)。
4. 将形状的 [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) 设置为 `Gradient`。
5. 使用 `GradientFormat` 类中与 `GradientStops` 集合关联的 `Add` 方法添加您首选的 2 种颜色及定义的位置。
6. 将修改后的演示文稿写入 PPTX 文件。

以下 Python 代码演示了在椭圆上使用渐变填充效果的操作：

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# 实例化一个表示演示文稿文件的 Presentation 类
with slides.Presentation() as pres:
    # 获取第一张幻灯片
    sld = pres.slides[0]

    # 添加一个椭圆自动形状
    shp = sld.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 150, 75, 150)

    # 对椭圆应用渐变格式
    shp.fill_format.fill_type = slides.FillType.GRADIENT
    shp.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR

    # 设置渐变的方向
    shp.fill_format.gradient_format.gradient_direction = slides.GradientDirection.FROM_CORNER2

    # 添加 2 个渐变停止
    shp.fill_format.gradient_format.gradient_stops.add(1.0, slides.PresetColor.PURPLE)
    shp.fill_format.gradient_format.gradient_stops.add(0, slides.PresetColor.RED)

    # 将 PPTX 文件写入磁盘
    pres.save("EllipseShpGrad_out-3.pptx", slides.export.SaveFormat.PPTX)
```


## **图案填充**
在 PowerPoint 中，图案填充是一种格式选项，允许您将由点、条纹、交叉线或方块组成的两种颜色设计应用于形状。此外，您可以选择图案前景和背景的首选颜色。

Aspose.Slides 提供了 45 种以上的预定义样式，可以用于格式化形状并丰富演示文稿。即使在选择了预定义图案后，您仍然可以指定图案必须包含的颜色。

以下方法是使用 Aspose.Slides 将图案填充应用于形状：

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 向幻灯片添加 [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/)。
4. 将形状的 [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) 设置为 `Pattern`。
5. 为形状设置首选的图案样式。
6. 为 [PatternFormat](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/) 设置背景颜色。
7. 为 [PatternFormat](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/) 设置前景颜色。
8. 将修改后的演示文稿写入 PPTX 文件。

以下 Python 代码演示了使用图案填充来美化矩形的操作：

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# 实例化一个表示演示文稿文件的 Presentation 类
with slides.Presentation() as pres:
    # 获取第一张幻灯片
    sld = pres.slides[0]

    # 添加一个矩形自动形状
    shp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 75, 150)

    # 将填充类型设置为图案
    shp.fill_format.fill_type = slides.FillType.PATTERN

    # 设置图案样式
    shp.fill_format.pattern_format.pattern_style = slides.PatternStyle.TRELLIS

    # 设置图案的背景色和前景色
    shp.fill_format.pattern_format.back_color.color = draw.Color.light_gray
    shp.fill_format.pattern_format.fore_color.color = draw.Color.yellow

    # 将 PPTX 文件写入磁盘
    pres.save("RectShpPatt_out-4.pptx", slides.export.SaveFormat.PPTX)
```


## **图片填充**
在 PowerPoint 中，图片填充是一种格式选项，允许您在形状内放置图片。实质上，您可以将图片用作形状的背景。

以下是使用 Aspose.Slides 用图片填充形状的方法：

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 向幻灯片添加 [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/)。
4. 将形状的 [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) 设置为 `Picture`。
5. 设置图片填充模式为瓷砖。
6. 使用将用于填充形状的图片创建一个 `IPPImage` 对象。
7. 将创建的 `IPPImage` 设置为 `PictureFillFormat` 对象的 `Picture.Image` 属性。
8. 将修改后的演示文稿写入 PPTX 文件。

以下 Python 代码展示了如何用图片填充形状的操作：

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# 实例化一个表示 PPTX 文件的 Presentation 类
with slides.Presentation() as pres:
    # 获取第一张幻灯片
    sld = pres.slides[0]

    # 添加一个矩形自动形状
    shp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 75, 150)

    # 将填充类型设置为图片
    shp.fill_format.fill_type = slides.FillType.PICTURE

    # 设置图片填充模式
    shp.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE

    # 设置图片
    img = draw.Bitmap(path + "Tulips.jpg")
    imgx = pres.images.add_image(img)
    shp.fill_format.picture_fill_format.picture.image = imgx

    # 将 PPTX 文件写入磁盘
    pres.save("RectShpPic_out-5.pptx", slides.export.SaveFormat.PPTX)
```


## **纯色填充**
在 PowerPoint 中，纯色填充是一种格式选项，允许您用单一颜色填充形状。所选择的颜色通常是平坦的颜色。该颜色应用于形状的背景，没有任何特殊效果或修改。

以下方法是使用 Aspose.Slides 将纯色填充应用于形状：

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 向幻灯片添加 [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/)。
4. 将形状的 [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) 设置为 `Solid`。
5. 为形状设置首选颜色。
6. 将修改后的演示文稿写入 PPTX 文件。

以下 Python 代码展示了如何将纯色填充应用于 PowerPoint 中的一个框：

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:

    # 获取第一张幻灯片
    slide = presentation.slides[0]

    # 添加一个矩形自动形状
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 75, 150)

    # 设置填充类型为纯色
    shape.fill_format.fill_type = slides.FillType.SOLID

    # 设置矩形的颜色
    shape.fill_format.solid_fill_color.color = draw.Color.yellow

    # 将 PPTX 文件写入磁盘
    presentation.save("RectShpSolid_out-6.pptx", slides.export.SaveFormat.PPTX)
```

## **设置透明度**

在 PowerPoint 中，当您用纯色、渐变、图片或纹理填充形状时，可以指定透明度级别，这决定了填充的透明度。例如，如果您设置较低的透明度级别，幻灯片对象或填充（形状）后面的背景将透过来。

Aspose.Slides 允许您以以下方式为形状设置透明度级别：

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 向幻灯片添加 [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/)。
4. 使用 `Color.FromArgb` 设置 alpha 组件。
5. 将对象保存为 PowerPoint 文件。

以下 Python 代码演示了该过程：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    
    # 添加一个实心形状
    solidShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 75, 175, 75, 150)

    # 在实心形状上添加一个透明形状
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 75, 150)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.from_argb(128, 204, 102, 0)
    
    presentation.save("ShapeTransparentOverSolid_out.pptx", slides.export.SaveFormat.PPTX)

```

## **旋转形状**
Aspose.Slides 允许您以以下方式旋转添加到幻灯片的形状：

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 向幻灯片添加 [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/)。
4. 按所需的度数旋转形状。
5. 将修改后的演示文稿写入 PPTX 文件。

以下 Python 代码展示了如何将形状旋转 90 度：

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    # 获取第一张幻灯片
    sld = pres.slides[0]

    # 添加一个矩形自动形状
    shp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 75, 150)

    # 将形状旋转 90 度
    shp.rotation = 90

    # 将 PPTX 文件写入磁盘
    pres.save("RectShpRot_out-7.pptx", slides.export.SaveFormat.PPTX)
```


## **添加 3D 凹凸效果**
Aspose.Slides for Python via .NET 允许您通过修改其 [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) 属性为形状添加 3D 凹凸效果，步骤如下：

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 向幻灯片添加 [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/)。
4. 为形状的 [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) 属性设置您首选的参数。
5. 将演示文稿写入磁盘。

以下 Python 代码展示了如何为形状添加 3D 凹凸效果：

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# 创建 Presentation 类的实例
with slides.Presentation() as pres:
    slide = pres.slides[0]

    # 向幻灯片添加一个形状
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 30, 30, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.green
    format = shape.line_format.fill_format
    format.fill_type = slides.FillType.SOLID
    format.solid_fill_color.color = draw.Color.orange
    shape.line_format.width = 2.0

    # 设置形状的 ThreeDFormat 属性
    shape.three_d_format.depth = 4
    shape.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    shape.three_d_format.bevel_top.height = 6
    shape.three_d_format.bevel_top.width = 6
    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.THREE_PT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP

    # 将演示文稿保存为 PPTX 文件
    pres.save("Bavel_out-8.pptx", slides.export.SaveFormat.PPTX)
```


## **添加 3D 旋转效果**
Aspose.Slides 允许您通过修改其 [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) 属性来为形状应用 3D 旋转效果，步骤如下：

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 向幻灯片添加 [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/)。
4. 为 CameraType 和 LightType 指定您首选的参数。
5. 将演示文稿写入磁盘。

以下 Python 代码展示了如何为形状应用 3D 旋转效果：

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# 创建 Presentation 类的实例
with slides.Presentation() as pres:
    autoShape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 200, 200)

    autoShape.three_d_format.depth = 6
    autoShape.three_d_format.camera.set_rotation(40, 35, 20)
    autoShape.three_d_format.camera.camera_type = slides.CameraPresetType.ISOMETRIC_LEFT_UP
    autoShape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED

    autoShape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.LINE, 30, 300, 200, 200)
    autoShape.three_d_format.depth = 6
    autoShape.three_d_format.camera.set_rotation(0, 35, 20)
    autoShape.three_d_format.camera.camera_type = slides.CameraPresetType.ISOMETRIC_LEFT_UP
    autoShape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED

            
    pres.save("Rotation_out-9.pptx", slides.export.SaveFormat.PPTX)
```

## **重置格式**

以下 Python 代码展示了如何重置幻灯片中的格式，并将每个在 [LayoutSlide](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/) 上有占位符的形状的位置、大小和格式还原为默认值：

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    for slide in pres.slides:
        # 幻灯片上每个具有布局占位符的形状将被还原
        slide.reset()
```