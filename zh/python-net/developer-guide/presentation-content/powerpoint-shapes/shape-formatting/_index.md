---
title: 在 Python 中格式化 PowerPoint 形状
linktitle: 形状格式化
type: docs
weight: 20
url: /zh/python-net/shape-formatting/
keywords:
- 格式化形状
- 格式化线条
- 素描效果
- 素描形状线条
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
description: "了解如何使用 Aspose.Slides 在 Python 中格式化 PowerPoint 形状——精确且完整地设置 PPT、PPTX 和 ODP 文件的填充、线条和效果样式。"
---
## **简介**

在 PowerPoint 中，您可以向幻灯片添加形状。由于形状由线条组成，您可以通过修改或对其轮廓应用效果来对其进行格式化。此外，您还可以通过指定控制内部填充方式的设置来格式化形状。

![格式化形状 PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for Python 提供了类和属性，使您能够使用 PowerPoint 中的相同选项来格式化形状。

## **格式化线条**

使用 Aspose.Slides，您可以为形状指定自定义线条样式。以下步骤概述了操作过程：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 向幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/zh/python-net/aspose.slides/autoshape/)。
1. 设置形状的 [line style](https://reference.aspose.com/slides/zh/python-net/aspose.slides/linestyle/)。
1. 设置线宽。
1. 设置形状的 [dash style](https://reference.aspose.com/slides/zh/python-net/aspose.slides/linedashstyle/)。
1. 设置形状的线条颜色。
1. 将修改后的演示文稿保存为 PPTX 文件。

以下 Python 代码演示了如何格式化矩形 `AutoShape`：

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# 实例化表示演示文稿文件的 Presentation 类。
with slides.Presentation() as presentation:

    # 获取第一张幻灯片。
    slide = presentation.slides[0]

    # 添加一个矩形类型的自动形状。
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

![演示文稿中格式化的线条](formatted-lines.png)

## **对形状线条应用素描效果**

素描效果使形状线条看起来像手绘。使用 [Shape.line_format](https://reference.aspose.com/slides/zh/python-net/aspose.slides/shape/line_format/) 访问线条设置，使用 [LineFormat.sketch_format](https://reference.aspose.com/slides/zh/python-net/aspose.slides/lineformat/sketch_format/) 访问素描设置，并使用 [SketchFormat.sketch_type](https://reference.aspose.com/slides/zh/python-net/aspose.slides/sketchformat/sketch_type/) 从 [LineSketchType](https://reference.aspose.com/slides/zh/python-net/aspose.slides/linesketchtype/) 枚举中选择值。

以下 Python 代码展示了如何应用 [LineSketchType.CURVED](https://reference.aspose.com/slides/zh/python-net/aspose.slides/linesketchtype/) 效果，读取显式分配的值，并使用 [LineSketchType.NONE](https://reference.aspose.com/slides/zh/python-net/aspose.slides/linesketchtype/) 移除该效果：

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)

    # 访问形状的线条格式及其素描格式。
    sketch_format = shape.line_format.sketch_format

    # 应用素描效果。
    sketch_format.sketch_type = slides.LineSketchType.CURVED

    # 读取直接分配给形状的素描效果。
    explicit_sketch_type = sketch_format.sketch_type
    print(f"Explicit sketch type: {explicit_sketch_type}")

    # 移除素描效果。
    sketch_format.sketch_type = slides.LineSketchType.NONE
```

`SketchFormat.sketch_type` 返回的值表示直接分配给形状的设置。如果线条格式可以从主题、母版幻灯片或布局幻灯片继承，请使用 [LineFormat.get_effective](https://reference.aspose.com/slides/zh/python-net/aspose.slides/lineformat/get_effective/) ，访问返回对象的 `sketch_format` 属性，并读取其 `sketch_type` 属性。有效值反映了解决继承后实际应用的格式：

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    line_format = shape.line_format

    explicit_sketch_type = line_format.sketch_format.sketch_type
    effective_line_format = line_format.get_effective()
    effective_sketch_type = effective_line_format.sketch_format.sketch_type

    print(f"Explicit sketch type: {explicit_sketch_type}")
    print(f"Effective sketch type: {effective_sketch_type}")
```

## **格式化连接样式**

以下是三种连接类型选项：

* Round
* Miter
* Bevel

默认情况下，PowerPoint 在角度处（例如形状的拐角）连接两条线时使用 **Round** 设置。但是，如果绘制的形状具有锐角，您可能更倾向于使用 **Miter** 选项。

![演示文稿中的连接样式](join-style-powerpoint.png)

以下 Python 代码演示了如何使用 Miter、Bevel 和 Round 连接类型设置创建三个矩形（如上图所示）：

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

在 PowerPoint 中，渐变填充是一种格式化选项，允许您对形状应用连续的颜色混合。例如，您可以以一种颜色逐渐淡入另一种颜色的方式应用两种或更多颜色。

以下是在 Aspose.Slides 中对形状应用渐变填充的方法：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 向幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/zh/python-net/aspose.slides/autoshape/)。
1. 将形状的 [FillType](https://reference.aspose.com/slides/zh/python-net/aspose.slides/filltype/) 设置为 `GRADIENT`。
1. 使用 [GradientFormat](https://reference.aspose.com/slides/zh/python-net/aspose.slides/gradientformat/) 类公开的 `gradient_stops` 集合的 `add` 方法，按定义的位置添加您偏好的两种颜色。
1. 将修改后的演示文稿保存为 PPTX 文件。

以下 Python 代码演示了如何对椭圆应用渐变填充效果：

```python
import aspose.slides as slides

# 实例化表示演示文稿文件的 Presentation 类。
with slides.Presentation() as presentation:

    # 获取第一张幻灯片。
    slide = presentation.slides[0]

    # 添加一个椭圆类型的自动形状。
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

在 PowerPoint 中，图案填充是一种格式化选项，允许您对形状应用两种颜色的设计——如点、条纹、交叉线或方格。您可以为图案的前景色和背景色自定义颜色。

Aspose.Slides 提供了超过 45 种预定义图案样式，您可以将其应用于形状以提升演示文稿的视觉效果。即使选择了预定义图案，仍然可以指定其使用的确切颜色。

以下是在 Aspose.Slides 中对形状应用图案填充的方法：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 向幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/zh/python-net/aspose.slides/autoshape/)。
1. 将形状的 [FillType](https://reference.aspose.com/slides/zh/python-net/aspose.slides/filltype/) 设置为 `PATTERN`。
1. 从预定义选项中选择一种图案样式。
1. 设置图案的 [back_color](https://reference.aspose.com/slides/zh/python-net/aspose.slides/patternformat/back_color/)。
1. 设置图案的 [fore_color](https://reference.aspose.com/slides/zh/python-net/aspose.slides/patternformat/fore_color/)。
1. 将修改后的演示文稿保存为 PPTX 文件。

以下 Python 代码演示了如何对矩形应用图案填充：

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# 实例化表示演示文稿文件的 Presentation 类。
with slides.Presentation() as presentation:

    # 获取第一张幻灯片。
    slide = presentation.slides[0]

    # 添加一个矩形类型的自动形状。
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

在 PowerPoint 中，图片填充是一种格式化选项，允许您在形状内部插入图像——相当于将图像用作形状的背景。

以下是使用 Aspose.Slides 对形状应用图片填充的方法：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 向幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/zh/python-net/aspose.slides/autoshape/)。
1. 将形状的 [FillType](https://reference.aspose.com/slides/zh/python-net/aspose.slides/filltype/) 设置为 `PICTURE`。
1. 将图片填充模式设置为 `TILE`（或其他首选模式）。
1. 使用要使用的图像创建一个 [PPImage](https://reference.aspose.com/slides/zh/python-net/aspose.slides/ppimage/) 对象。
1. 将此图像分配给形状的 `picture_fill_format` 的 `picture.image` 属性。
1. 将修改后的演示文稿保存为 PPTX 文件。

假设我们有一个名为 “lotus.png” 的文件，内容如下：

![莲花图片](lotus.png)

以下 Python 代码演示了如何使用图片填充形状：

```python
import aspose.slides as slides

# 实例化表示演示文稿文件的 Presentation 类。
with slides.Presentation() as presentation:

    # 获取第一张幻灯片。
    slide = presentation.slides[0]

    # 添加一个矩形类型的自动形状。
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

如果要将平铺的图片设为纹理并自定义平铺行为，可使用 [PictureFillFormat](https://reference.aspose.com/slides/zh/python-net/aspose.slides/picturefillformat/) 类的以下属性：

- [picture_fill_mode](https://reference.aspose.com/slides/zh/python-net/aspose.slides/picturefillformat/picture_fill_mode/)：设置图片填充模式，可为 `TILE` 或 `STRETCH`。
- [tile_alignment](https://reference.aspose.com/slides/zh/python-net/aspose.slides/picturefillformat/tile_alignment/)：指定平铺在形状内的对齐方式。
- [tile_flip](https://reference.aspose.com/slides/zh/python-net/aspose.slides/picturefillformat/tile_flip/)：控制平铺是水平翻转、垂直翻转还是同时翻转。
- [tile_offset_x](https://reference.aspose.com/slides/zh/python-net/aspose.slides/picturefillformat/tile_offset_x/)：设置平铺相对于形状原点的水平偏移（以点为单位）。
- [tile_offset_y](https://reference.aspose.com/slides/zh/python-net/aspose.slides/picturefillformat/tile_offset_y/)：设置平铺相对于形状原点的垂直偏移（以点为单位）。
- [tile_scale_x](https://reference.aspose.com/slides/zh/python-net/aspose.slides/picturefillformat/tile_scale_x/)：定义平铺的水平缩放比例（百分比）。
- [tile_scale_y](https://reference.aspose.com/slides/zh/python-net/aspose.slides/picturefillformat/tile_scale_y/)：定义平铺的垂直缩放比例（百分比）。

以下代码示例展示了如何添加一个带平铺图片填充的矩形并配置平铺选项：

```py
import aspose.slides as slides

# 实例化表示演示文稿文件的 Presentation 类。
with slides.Presentation() as presentation:

    # 获取第一张幻灯片。
    first_slide = presentation.slides[0]

    # 添加一个矩形自动形状。
    shape = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 190, 95)

    # 将形状的填充类型设置为 Picture。
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # 加载图像并将其添加到演示文稿资源中。
    with slides.Images.from_file("lotus.png") as source_image:
        presentation_image = presentation.images.add_image(source_image)

    # 将图像分配给形状。
    picture_fill_format = shape.fill_format.picture_fill_format
    picture_fill_format.picture.image = presentation_image

    # 配置图片填充模式和平铺属性。
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

在 PowerPoint 中，纯色填充是一种格式化选项，可使用单一、均匀的颜色填充形状。该背景颜色不包含任何渐变、纹理或图案。

使用 Aspose.Slides 对形状应用纯色填充的步骤如下：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 向幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/zh/python-net/aspose.slides/autoshape/)。
1. 将形状的 [FillType](https://reference.aspose.com/slides/zh/python-net/aspose.slides/filltype/) 设置为 `SOLID`。
1. 为形状分配您偏好的填充颜色。
1. 将修改后的演示文稿保存为 PPTX 文件。

以下 Python 代码演示了如何在 PowerPoint 幻灯片中对矩形应用纯色填充：

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# 实例化表示演示文稿文件的 Presentation 类。
with slides.Presentation() as presentation:

    # 获取第一张幻灯片。
    slide = presentation.slides[0]

    # 添加一个矩形类型的自动形状。
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

在 PowerPoint 中，当为形状应用纯色、渐变、图片或纹理填充时，您还可以设置透明度级别以控制填充的不透明度。较高的透明度值会使形状更透明，从而部分显示背景或底层对象。

Aspose.Slides 通过在用于填充的颜色中调整 alpha 值来设置透明度。操作方法如下：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 向幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/zh/python-net/aspose.slides/autoshape/)。
1. 将填充类型设置为 `SOLID`。
1. 使用 `Color.from_argb` 定义带有透明度的颜色（`alpha` 分量控制透明度）。
1. 保存演示文稿。

以下 Python 代码演示了如何对矩形应用透明填充颜色：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# 实例化表示演示文稿文件的 Presentation 类。
with slides.Presentation() as presentation:

    # 获取第一张幻灯片。
    slide = presentation.slides[0]
    
    # 添加一个实心矩形自动形状。
    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # 在实心形状上方添加一个透明矩形自动形状。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 80, 150, 75)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.from_argb(128, 204, 102, 0)
    
    presentation.save("shape_transparency.pptx", slides.export.SaveFormat.PPTX)
```

结果：

![透明形状](shape-transparency.png)

## **旋转形状**

Aspose.Slides 允许您在 PowerPoint 演示文稿中旋转形状。这在需要特定对齐或设计需求的视觉元素定位时非常有用。

要在幻灯片上旋转形状，请按以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 向幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/zh/python-net/aspose.slides/autoshape/)。
1. 将形状的 `rotation` 属性设置为所需的角度。
1. 保存演示文稿。

以下 Python 代码演示了如何将形状旋转 5 度：

```python
import aspose.slides as slides

# 实例化表示演示文稿文件的 Presentation 类。
with slides.Presentation() as presentation:

    # 获取第一张幻灯片。
    slide = presentation.slides[0]

    # 添加一个矩形类型的自动形状。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # 将形状旋转 5 度。
    shape.rotation = 5

    # 将 PPTX 文件保存到磁盘。
    presentation.save("shape_rotation.pptx", slides.export.SaveFormat.PPTX)
```

结果：

![形状旋转](shape-rotation.png)

## **添加 3D 倾斜效果**

Aspose.Slides 通过配置形状的 [ThreeDFormat](https://reference.aspose.com/slides/zh/python-net/aspose.slides/threedformat/) 属性来应用 3D 倾斜效果。

要为形状添加 3D 倾斜效果，请按以下步骤操作：

1. 实例化 [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 类。
1. 通过索引获取幻灯片的引用。
1. 向幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/zh/python-net/aspose.slides/autoshape/)。
1. 配置形状的 [ThreeDFormat](https://reference.aspose.com/slides/zh/python-net/aspose.slides/threedformat/) 以定义倾斜设置。
1. 保存演示文稿。

以下 Python 代码展示了如何对形状应用 3D 倾斜效果：

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

Aspose.Slides 通过配置形状的 [ThreeDFormat](https://reference.aspose.com/slides/zh/python-net/aspose.slides/threedformat/) 属性来应用 3D 旋转效果。

要对形状应用 3D 旋转：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 向幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/zh/python-net/aspose.slides/autoshape/)。
1. 设置形状的 [camera_type](https://reference.aspose.com/slides/zh/python-net/aspose.slides/camera/camera_type/) 和 [light_type](https://reference.aspose.com/slides/zh/python-net/aspose.slides/lightrig/light_type/) 以定义 3D 旋转。
1. 保存演示文稿。

以下 Python 代码演示了如何对形状应用 3D 旋转效果：

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

以下 Python 代码展示了如何重置布局幻灯片（[LayoutSlide](https://reference.aspose.com/slides/zh/python-net/aspose.slides/layoutslide/)）上所有占位符形状的位置、大小和格式，恢复为默认设置：

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:

    for slide in presentation.slides:
        # 重置幻灯片上每个在布局中具有占位符的形状。
        slide.reset()

    presentation.save("reset_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **常见问题**

**形状格式化会影响最终演示文稿的文件大小吗？**

影响极小。嵌入的图像和媒体占据了大部分文件空间，而形状参数（如颜色、效果和渐变）作为元数据存储，几乎不增加额外大小。

**如何检测幻灯片上具有相同格式的形状，以便对其进行分组？**

比较每个形状的关键格式属性——填充、线条和效果设置。如果所有对应值匹配，则视为样式相同，可在逻辑上对这些形状进行分组，从而简化后续的样式管理。

**我可以将一套自定义形状样式保存到单独的文件，以便在其他演示文稿中复用吗？**

可以。将带有所需样式的示例形状保存到模板幻灯片集或 .POTX 模板文件中。创建新演示文稿时，打开模板，克隆所需的样式形状，并在需要的地方重新应用其格式。