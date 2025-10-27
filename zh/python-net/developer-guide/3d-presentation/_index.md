---
title: 用 Python 创建 3D 演示文稿
linktitle: 3D 演示文稿
type: docs
weight: 232
url: /zh/python-net/3d-presentation/
keywords:
- 3D PowerPoint
- 3D presentation
- 3D rotation
- 3D depth
- 3D extrusion
- 3D gradient
- 3D text
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "使用 Aspose.Slides 在 Python 中轻松生成交互式 3D 演示文稿。快速导出为 PowerPoint 和 OpenDocument 格式，以实现多用途使用。"
---

## **概览**

您通常如何创建 3D PowerPoint 演示文稿？Microsoft PowerPoint 允许您添加 3D 模型、对形状应用 3D 效果、创建 3D 文本、插入 3D 图形以及构建 3D 动画。

创建 3D 效果具有很大冲击力，往往是将普通幻灯片转变为 3D 演示的最简便方式。自 Aspose.Slides 20.9 起，新增了 **跨平台 3D 引擎**。该引擎支持导出并光栅化具有 3D 效果的形状和文本。早期版本中，具有 3D 效果的形状会被扁平化渲染；现在可以实现 **完整的 3D** 渲染。您也可以通过 Aspose.Slides API 创建带有 3D 效果的形状。

在 Aspose.Slides API 中，要将形状设为 PowerPoint 3D 形状，请使用 [Shape.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/three_d_format/) 属性，它公开了 [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat) 类的成员：

- [bevel_bottom](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/bevel_bottom/) 和 [bevel_top](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/bevel_top/)：设置倒角，选择倒角类型（例如 Angle、Circle、SoftRound），并定义倒角的高度和宽度。
- [camera](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/camera/)：模拟围绕对象的摄像机移动；通过调整摄像机旋转、缩放等属性，您可以像在 PowerPoint 中操作 3D 模型一样操作形状。
- [contour_color](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/contour_color/) 和 [contour_width](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/contour_width/)：设置轮廓属性，使形状看起来像 3D PowerPoint 对象。
- [depth](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/depth/)、[extrusion_color](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_color/)、[extrusion_height](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_height/)：通过设置深度或拉伸来使形状具备三维效果。
- [light_rig](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/light_rig/)：为 3D 形状创建光照效果；类似摄像机，您可以设置光源相对于 3D 形状的旋转并选择光源类型。
- [material](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/material/)：选择材质，使 3D 形状更逼真。预定义材质包括 Metal、Plastic、Powder、Matte 等。

所有 3D 功能均可应用于形状和文本。以下章节展示如何访问这些属性并逐步检查它们。

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

image_scale = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)
    shape.text_frame.text = "3D"
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 64

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(20, 30, 40)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 100
    shape.three_d_format.extrusion_color.color = drawing.Color.blue

    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("sample_3d.png")

    presentation.save("sandbox_3d.pptx", slides.export.SaveFormat.PPTX)
```

渲染后的缩略图如下所示：

![todo:image_alt_text](img_01_01.png)

## **3D 旋转**

您可以在三维空间中旋转 PowerPoint 3D 形状，以增加交互性。要在 PowerPoint 中旋转 3D 形状，请使用如下菜单：

![todo:image_alt_text](img_02_01.png)

在 Aspose.Slides API 中，您通过 [camera](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/camera/) 属性控制形状的 3D 旋转。

```py
shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)
shape.three_d_format.camera.set_rotation(20, 30, 40)
# ... set other 3D scene parameters

with slide.get_image(image_scale, image_scale) as thumbnail:
    thumbnail.save("sample_3d.png")
```

## **3D 深度和拉伸**

要为形状添加第三维度并实现真正的 3D，请使用 [ThreeDFormat.extrusion_height](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_height/) 和 [ThreeDFormat.extrusion_color](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_color/) 属性：

```py
shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)
shape.three_d_format.camera.set_rotation(20, 30, 40)
shape.three_d_format.extrusion_height = 100
shape.three_d_format.extrusion_color.color = drawing.Color.purple
# ... set other 3D scene parameters

with slide.get_image(image_scale, image_scale) as thumbnail:
    thumbnail.save("sample_3d.png")
```

在 PowerPoint 中，您通常使用 **Depth** 菜单来设置 3D 形状的深度：

![todo:image_alt_text](img_02_02.png)

## **3D 渐变**

渐变可用于填充 PowerPoint 3D 形状。让我们创建一个带有渐变填充并应用 3D 效果的形状：

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

image_scale = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 250, 250)
    shape.text_frame.text = "3D Gradient"
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 64

    shape.fill_format.fill_type = slides.FillType.GRADIENT
    shape.fill_format.gradient_format.gradient_stops.add(0, drawing.Color.blue)
    shape.fill_format.gradient_format.gradient_stops.add(100, drawing.Color.orange)
   
    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(10, 20, 30)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.extrusion_height = 150
    shape.three_d_format.extrusion_color.color = drawing.Color.dark_orange
   
    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("sample_3d.png")
```

结果如下：

![todo:image_alt_text](img_02_03.png)

除了渐变填充，您还可以使用图片填充形状：

```py
with open("image.png", "rb") as image_file:
    image_data = image_file.read()

    shape.fill_format.fill_type = slides.FillType.PICTURE
    shape.fill_format.picture_fill_format.picture.image = presentation.images.add_image(image_data)
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    # ... setup 3D: shape.three_d_format.camera, shape.three_d_format.light_rig, shape.three_d_format.Extrusion* properties

    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("sample_3d.png")
```

效果如下：

![todo:image_alt_text](img_02_04.png)

## **3D 文本（WordArt）**

Aspose.Slides 也允许您对文本应用 3D 效果。要创建 3D 文本，可以使用 WordArt 变形效果：

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

image_scale = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 250, 250)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
    shape.text_frame.text = "3D text"
   
    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.portion_format.fill_format.fill_type = slides.FillType.PATTERN
    portion.portion_format.fill_format.pattern_format.fore_color.color = drawing.Color.dark_orange
    portion.portion_format.fill_format.pattern_format.back_color.color = drawing.Color.white
    portion.portion_format.fill_format.pattern_format.pattern_style = slides.PatternStyle.LARGE_GRID
   
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 128
   
    text_frame_format = shape.text_frame.text_frame_format
    # setup "Arch Up" WordArt transform effect
    text_frame_format.transform = slides.TextShapeType.ARCH_UP

    text_frame_format.three_d_format.extrusion_height = 3.5
    text_frame_format.three_d_format.depth = 3
    text_frame_format.three_d_format.material = slides.MaterialPresetType.PLASTIC
    text_frame_format.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    text_frame_format.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED
    text_frame_format.three_d_format.light_rig.set_rotation(0, 0, 40)
    text_frame_format.three_d_format.camera.camera_type = slides.CameraPresetType.PERSPECTIVE_CONTRASTING_RIGHT_FACING
   
    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("text3d.png")

    presentation.save("text3d.pptx", slides.export.SaveFormat.PPTX)
```

效果如下：

![todo:image_alt_text](img_02_05.png)

## **常见问题**

**将演示文稿导出为图像/PDF/HTML 时，3D 效果会被保留吗？**

是的。Slides 3D 引擎在导出为受支持的格式时会渲染 3D 效果（[图像](/slides/zh/python-net/convert-powerpoint-to-png/)、[PDF](/slides/zh/python-net/convert-powerpoint-to-pdf/)、[HTML](/slides/zh/python-net/convert-powerpoint-to-html/) 等）。

**我能获取考虑主题、继承等因素后的“有效”3D 参数值吗？**

可以。Slides 提供了 API 来 [读取有效值](/slides/zh/python-net/shape-effective-properties/)（包括 3D——光照、倒角等），以便查看最终应用的设置。

**将演示文稿转换为视频时，3D 效果会生效吗？**

会的。在 [生成视频帧](/slides/zh/python-net/convert-powerpoint-to-video/) 时，3D 效果的渲染方式与 [导出的图像](/slides/zh/python-net/convert-powerpoint-to-png/) 相同。