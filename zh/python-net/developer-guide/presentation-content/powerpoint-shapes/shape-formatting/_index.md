---
title: 在 Python 中格式化 PowerPoint 形状
linktitle: 形状格式化
type: docs
weight: 20
url: /zh/python-net/shape-formatting/
keywords:
- 格式化形状
- 格式化线条
- 格式化连接样式
- 渐变填充
- 图案填充
- 图片填充
- 纹理填充
- 纯色填充
- 形状透明度
- 旋转形状
- 3D 倾斜效果
- 3D 旋转效果
- 重置格式
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides
description: "了解如何使用 Aspose.Slides 在 Python 中格式化 PowerPoint 形状——精准且完整地设置 PPT、PPTX 和 ODP 文件的填充、线条和效果样式。"
---

## **概述**

在 PowerPoint 中，您可以向幻灯片添加形状。形状由线组成，您可以通过修改或应用轮廓效果来格式化它们。此外，您还可以通过指定控制内部填充方式的设置来格式化形状。

![PowerPoint 中形状格式化](format-shape-powerpoint.png)

Aspose.Slides for Python 提供了类和属性，允许您使用 PowerPoint 中相同的选项来格式化形状。

## **格式线条**

使用 Aspose.Slides，您可以为形状指定自定义线条样式。以下步骤概述了该过程：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 向幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)。
1. 设置形状的 [line style](https://reference.aspose.com/slides/python-net/aspose.slides/linestyle/)。
1. 设置线宽。
1. 设置形状的 [dash style](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/)。
1. 设置形状的线条颜色。
1. 将修改后的演示文稿保存为 PPTX 文件。

以下 Python 代码演示如何格式化矩形 `AutoShape`：
```python
import aspose.slides as slides
import aspose.pydrawing as draw

# 实例化表示演示文稿文件的 Presentation 类。
with slides.Presentation() as presentation:

    # 获取第一张幻灯片。
    slide = presentation.slides[0]

    # 添加矩形类型的自动形状。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 75)

    # 设置矩形形状的填充颜色。
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    # 对矩形的线条应用格式化。
    shape.line_format.style = slides.LineStyle.THICK_THIN
    shape.line_format.width = 7
    shape.line_format.dash_style = slides.LineDashStyle.DASH

    # 设置矩形线条的颜色。
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue

    # 将 PPTX 文件保存到磁盘。
    presentation.save("formatted_lines.pptx", slides.export.SaveFormat.PPTX)
```


结果：

![演示文稿中已格式化的线条](formatted-lines.png)

## **格式连接样式**

以下是三种连接类型选项：

* 圆形
* 斜角
* 斜面

默认情况下，当 PowerPoint 在角度处（例如形状的拐角）连接两条线时，使用 **圆形** 设置。但如果您绘制的是尖角形状，可能更倾向于使用 **斜角** 选项。

![演示文稿中的连接样式](join-style-powerpoint.png)

以下 Python 代码演示如何使用斜角、斜面和圆形连接类型设置创建上图中的三个矩形：
```python
import aspose.slides as slides
import aspose.pydrawing as draw

# 实例化表示演示文稿文件的 Presentation 类。
with slides.Presentation() as presentation:

	# 获取第一张幻灯片。
	slide = presentation.slides[0]

	# 添加三个矩形类型的自动形状。
	shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 75)
	shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 210, 20, 150, 75)
	shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 135, 150, 75)

	# 为每个矩形形状设置填充颜色。
	shape1.fill_format.fill_type = slides.FillType.SOLID
	shape1.fill_format.solid_fill_color.color = draw.Color.black
	shape2.fill_format.fill_type = slides.FillType.SOLID
	shape2.fill_format.solid_fill_color.color = draw.Color.black
	shape3.fill_format.fill_type = slides.FillType.SOLID
	shape3.fill_format.solid_fill_color.color = draw.Color.black

	# 设置线宽。
	shape1.line_format.width = 15
	shape2.line_format.width = 15
	shape3.line_format.width = 15

	# 为每个矩形的线条设置颜色。
	shape1.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape1.line_format.fill_format.solid_fill_color.color = draw.Color.blue
	shape2.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape2.line_format.fill_format.solid_fill_color.color = draw.Color.blue
	shape3.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape3.line_format.fill_format.solid_fill_color.color = draw.Color.blue

	# 设置连接样式。
	shape1.line_format.join_style = slides.LineJoinStyle.MITER
	shape2.line_format.join_style = slides.LineJoinStyle.BEVEL
	shape3.line_format.join_style = slides.LineJoinStyle.ROUND

	# 为每个矩形添加文本。
	shape1.text_frame.text = "Miter Join style"
	shape2.text_frame.text = "Bevel Join style"
	shape3.text_frame.text = "Round Join style"

	# 将 PPTX 文件保存到磁盘。
	presentation.save("join_styles.pptx", slides.export.SaveFormat.PPTX)
```


## **渐变填充**

在 PowerPoint 中，渐变填充是一种格式化选项，可让您对形状应用连续的颜色混合。例如，您可以以一种颜色逐渐淡入另一种颜色的方式应用两种或更多颜色。

以下是使用 Aspose.Slides 为形状应用渐变填充的步骤：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 向幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)。
1. 将形状的 [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) 设置为 `GRADIENT`。
1. 使用 [GradientFormat](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/) 类公开的 `gradient_stops` 集合的 `add` 方法，添加您首选的两种颜色并定义位置。
1. 将修改后的演示文稿保存为 PPTX 文件。

以下 Python 代码演示如何对椭圆应用渐变填充效果：
```python
import aspose.slides as slides

# 实例化表示演示文稿文件的 Presentation 类。
with slides.Presentation() as presentation:

    # 获取第一张幻灯片。
    slide = presentation.slides[0]

    # 添加椭圆类型的自动形状。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 150, 75)

    # 对椭圆应用渐变格式。
    shape.fill_format.fill_type = slides.FillType.GRADIENT
    shape.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR

    # 设置渐变的方向。
    shape.fill_format.gradient_format.gradient_direction = slides.GradientDirection.FROM_CORNER2

    # 添加两个渐变停止点。
    shape.fill_format.gradient_format.gradient_stops.add(1.0, slides.PresetColor.PURPLE)
    shape.fill_format.gradient_format.gradient_stops.add(0, slides.PresetColor.RED)

    # 将 PPTX 文件保存到磁盘。
    presentation.save("gradient_fill.pptx", slides.export.SaveFormat.PPTX)
```


结果：

![带有渐变填充的椭圆](gradient-fill.png)

## **图案填充**

在 PowerPoint 中，图案填充是一种格式化选项，可让您对形状应用两种颜色的设计——如点、条纹、交叉阴影或格子。您可以为图案的前景色和背景色选择自定义颜色。

Aspose.Slides 提供超过 45 种预定义图案样式，您可以将其应用于形状以增强演示文稿的视觉效果。即使选择了预定义图案，仍可指定其使用的确切颜色。

以下是使用 Aspose.Slides 为形状应用图案填充的步骤：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 向幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)。
1. 将形状的 [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) 设置为 `PATTERN`。
1. 从预定义选项中选择图案样式。
1. 设置图案的 [back_color](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/back_color/)。
1. 设置图案的 [fore_color](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/fore_color/)。
1. 将修改后的演示文稿保存为 PPTX 文件。

以下 Python 代码演示如何对矩形应用图案填充：
```python
import aspose.slides as slides
import aspose.pydrawing as draw

# 实例化表示演示文稿文件的 Presentation 类。
with slides.Presentation() as presentation:

    # 获取第一张幻灯片。
    slide = presentation.slides[0]

    # 添加矩形类型的自动形状。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # 将填充类型设置为 Pattern。
    shape.fill_format.fill_type = slides.FillType.PATTERN

    # 设置图案样式。
    shape.fill_format.pattern_format.pattern_style = slides.PatternStyle.TRELLIS

    # 设置图案的背景色和前景色。
    shape.fill_format.pattern_format.back_color.color = draw.Color.light_gray
    shape.fill_format.pattern_format.fore_color.color = draw.Color.yellow

    # 将 PPTX 文件保存到磁盘。
    presentation.save("pattern_fill.pptx", slides.export.SaveFormat.PPTX)
```


结果：

![带有图案填充的矩形](pattern-fill.png)

## **图片填充**

在 PowerPoint 中，图片填充是一种格式化选项，允许您在形状内部插入图像——实际上将图像用作形状的背景。

以下是使用 Aspose.Slides 为形状应用图片填充的步骤：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 向幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)。
1. 将形状的 [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) 设置为 `PICTURE`。
1. 将图片填充模式设置为 `TILE`（或其他首选模式）。
1. 使用要使用的图像创建一个 [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) 对象。
1. 将此图像分配给形状的 `picture_fill_format` 中的 `picture.image` 属性。
1. 将修改后的演示文稿保存为 PPTX 文件。

假设我们有一个名为 “lotus.png” 的文件，其图片如下：

![莲花图片](lotus.png)

以下 Python 代码演示如何使用图片填充形状：
```python
import aspose.slides as slides

# 实例化表示演示文稿文件的 Presentation 类。
with slides.Presentation() as presentation:

    # 获取第一张幻灯片。
    slide = presentation.slides[0]

    # 添加矩形类型的自动形状。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 192, 95)

    # 将填充类型设置为 Picture。
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # 设置图片填充模式。
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE

    # 加载图像并将其添加到演示文稿资源中。
    with slides.Images.from_file("lotus.png") as image:
        presentation_image = presentation.images.add_image(image)

    # 设置图片。
    shape.fill_format.picture_fill_format.picture.image = presentation_image

    # 将 PPTX 文件保存到磁盘。
    presentation.save("picture_fill.pptx", slides.export.SaveFormat.PPTX)
```


结果：

![带有图片填充的形状](picture-fill.png)

### **将图片平铺为纹理**

如果您希望将平铺图片作为纹理并自定义平铺行为，可以使用 [PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/) 类的以下属性：

- [picture_fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture_fill_mode/)：设置图片填充模式——`TILE` 或 `STRETCH`。
- [tile_alignment](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_alignment/)：指定平铺在形状内的对齐方式。
- [tile_flip](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_flip/)：控制平铺是水平翻转、垂直翻转或两者翻转。
- [tile_offset_x](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_offset_x/)：设置平铺相对于形状原点的水平偏移（以点为单位）。
- [tile_offset_y](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_offset_y/)：设置平铺相对于形状原点的垂直偏移（以点为单位）。
- [tile_scale_x](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_scale_x/)：定义平铺的水平缩放比例（百分比）。
- [tile_scale_y](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_scale_y/)：定义平铺的垂直缩放比例（百分比）。

以下代码示例演示如何添加一个带有平铺图片填充的矩形并配置平铺选项：
```py
import aspose.slides as slides

# 实例化表示演示文稿文件的 Presentation 类。
with slides.Presentation() as presentation:

    # 获取第一张幻灯片。
    first_slide = presentation.slides[0]

    # 添加矩形自动形状。
    shape = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 190, 95)

    # 将形状的填充类型设置为 Picture。
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # 加载图像并将其添加到演示文稿资源中。
    with slides.Images.from_file("lotus.png") as source_image:
        presentation_image = presentation.images.add_image(source_image)

    # 将图像分配给形状。
    picture_fill_format = shape.fill_format.picture_fill_format
    picture_fill_format.picture.image = presentation_image

    # 配置图片填充模式和瓦片属性。
    picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE
    picture_fill_format.tile_offset_x = -32
    picture_fill_format.tile_offset_y = -32
    picture_fill_format.tile_scale_x = 50
    picture_fill_format.tile_scale_y = 50
    picture_fill_format.tile_alignment = slides.RectangleAlignment.BOTTOM_RIGHT
    picture_fill_format.tile_flip = slides.TileFlip.FLIP_BOTH

    # 将 PPTX 文件保存到磁盘。
    presentation.save("tile.pptx", slides.export.SaveFormat.PPTX)
```


结果：

![平铺选项](tile-options.png)

## **纯色填充**

在 PowerPoint 中，纯色填充是一种格式化选项，可使用单一均匀的颜色填充形状。此纯色背景不含渐变、纹理或图案。

使用 Aspose.Slides 为形状应用纯色填充的步骤：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 向幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)。
1. 将形状的 [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) 设置为 `SOLID`。
1. 为形状指定首选的填充颜色。
1. 将修改后的演示文稿保存为 PPTX 文件。

以下 Python 代码演示如何在 PowerPoint 幻灯片中的矩形上应用纯色填充：
```python
import aspose.slides as slides
import aspose.pydrawing as draw

# 实例化表示演示文稿文件的 Presentation 类。
with slides.Presentation() as presentation:

    # 获取第一张幻灯片。
    slide = presentation.slides[0]

    # 添加矩形类型的自动形状。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # 将填充类型设置为 Solid。
    shape.fill_format.fill_type = slides.FillType.SOLID

    # 设置填充颜色。
    shape.fill_format.solid_fill_color.color = draw.Color.yellow

    # 将 PPTX 文件保存到磁盘。
    presentation.save("solid_color_fill.pptx", slides.export.SaveFormat.PPTX)
```


结果：

![带有纯色填充的形状](solid-color-fill.png)

## **设置透明度**

在 PowerPoint 中，对形状应用纯色、渐变、图片或纹理填充时，您也可以设置透明度级别以控制填充的不透明度。更高的透明度值使形状更透，从而部分显示背景或下层对象。

Aspose.Slides 通过调整用于填充的颜色的 alpha 值来设置透明度。操作步骤如下：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 向幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)。
1. 将填充类型设置为 `SOLID`。
1. 使用 `Color.from_argb` 定义带有透明度的颜色（alpha 分量控制透明度）。
1. 保存演示文稿。

以下 Python 代码演示如何为矩形应用透明填充颜色：
```python
import aspose.pydrawing as draw
import aspose.slides as slides

# 实例化表示演示文稿文件的 Presentation 类。
with slides.Presentation() as presentation:

    # 获取第一张幻灯片。
    slide = presentation.slides[0]
    
    # 添加一个实心矩形自动形状。
    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # 在实心形状上添加一个透明矩形自动形状。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 80, 150, 75)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.from_argb(128, 204, 102, 0)
    
    presentation.save("shape_transparency.pptx", slides.export.SaveFormat.PPTX)
```


结果：

![透明形状](shape-transparency.png)

## **旋转形状**

Aspose.Slides 允许您在 PowerPoint 演示文稿中旋转形状。这在需要特定对齐或设计需求的视觉元素定位时非常有用。

在幻灯片上旋转形状的步骤：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 向幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)。
1. 将形状的 `rotation` 属性设置为所需的角度。
1. 保存演示文稿。

以下 Python 代码演示如何将形状旋转 5 度：
```python
import aspose.slides as slides

# 实例化表示演示文稿文件的 Presentation 类。
with slides.Presentation() as presentation:

    # 获取第一张幻灯片。
    slide = presentation.slides[0]

    # 添加矩形类型的自动形状。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # 将形状旋转 5 度。
    shape.rotation = 5

    # 将 PPTX 文件保存到磁盘。
    presentation.save("shape_rotation.pptx", slides.export.SaveFormat.PPTX)
```


结果：

![形状旋转](shape-rotation.png)

## **添加 3D 倾斜效果**

Aspose.Slides 通过配置形状的 [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) 属性，允许您对形状应用 3D 倾斜效果。

为形状添加 3D 倾斜效果的步骤：

1. 实例化 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类。
1. 通过索引获取幻灯片的引用。
1. 向幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)。
1. 配置形状的 [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) 以定义倾斜设置。
1. 保存演示文稿。

以下 Python 代码展示如何为形状应用 3D 倾斜效果：
```python
import aspose.slides as slides
import aspose.pydrawing as draw

# 创建 Presentation 类的实例。
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    # 向幻灯片添加形状。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.green
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.orange
    shape.line_format.width = 2.0

    # 设置形状的 ThreeDFormat 属性。
    shape.three_d_format.depth = 4
    shape.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    shape.three_d_format.bevel_top.height = 6
    shape.three_d_format.bevel_top.width = 6
    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.THREE_PT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP

    # 将演示文稿保存为 PPTX 文件。
    presentation.save("3D_bevel_effect.pptx", slides.export.SaveFormat.PPTX)
```


结果：

![3D 倾斜效果](3D-bevel-effect.png)

## **添加 3D 旋转效果**

Aspose.Slides 通过配置形状的 [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) 属性，允许您对形状应用 3D 旋转效果。

为形状应用 3D 旋转的步骤：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 向幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)。
1. 将形状的 [camera_type](https://reference.aspose.com/slides/python-net/aspose.slides/camera/camera_type/) 和 [light_type](https://reference.aspose.com/slides/python-net/aspose.slides/lightrig/light_type/) 设置为定义 3D 旋转。
1. 保存演示文稿。

以下 Python 代码演示如何为形状应用 3D 旋转效果：
```python
import aspose.slides as slides

# 创建 Presentation 类的实例。
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    auto_shape.text_frame.text = "Hello, Aspose!"

    auto_shape.three_d_format.depth = 6
    auto_shape.three_d_format.camera.set_rotation(40, 35, 20)
    auto_shape.three_d_format.camera.camera_type = slides.CameraPresetType.ISOMETRIC_LEFT_UP
    auto_shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED

    # 将演示文稿保存为 PPTX 文件。      
    presentation.save("3D_rotation_effect.pptx", slides.export.SaveFormat.PPTX)
```


结果：

![3D 旋转效果](3D-rotation-effect.png)

## **重置格式**

以下 Python 代码示例展示如何重置幻灯片的格式，并将所有带占位符的形状在 [LayoutSlide](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/) 上的位置、大小及格式恢复为默认设置：
```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:

    for slide in presentation.slides:
        # 重置每个在布局上具有占位符的形状。
        slide.reset()

    presentation.save("reset_formatting.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**形状格式化会影响最终演示文稿的文件大小吗？**

影响极小。嵌入的图像和媒体占用了大部分文件空间，而颜色、效果和渐变等形状参数作为元数据存储，几乎不增加额外大小。

**如何检测幻灯片上格式完全相同的形状，以便对它们进行分组？**

比较每个形状的关键格式属性——填充、线条和效果设置。如果所有对应值匹配，则视为相同样式，并在逻辑上将这些形状分组，便于后续的样式管理。

**是否可以将一套自定义形状样式保存到单独的文件，以便在其他演示文稿中复用？**

可以。将带有所需样式的示例形状保存到模板幻灯片或 .POTX 模板文件中。创建新演示文稿时，打开该模板，克隆所需的样式形状，并在需要的地方重新应用其格式。