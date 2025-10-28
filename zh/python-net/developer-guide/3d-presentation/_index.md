---
title: 在 Python 中创建 3D 演示文稿
linktitle: 3D 演示文稿
type: docs
weight: 232
url: /zh/python-net/3d-presentation/
keywords:
- 3D PowerPoint
- 3D 演示文稿
- 3D 旋转
- 3D 深度
- 3D 拉伸
- 3D 渐变
- 3D 文本
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "使用 Aspose.Slides 在 Python 中轻松生成交互式 3D 演示文稿。快速导出为 PowerPoint 和 OpenDocument 格式，以实现多种使用场景。"
---

## **概述**

通常如何创建 3D PowerPoint 演示文稿？Microsoft PowerPoint 允许您添加 3D 模型、对形状应用 3D 效果、创建 3D 文本、插入 3D 图形，以及构建 3D 动画。

创建 3D 效果影响巨大，往往是将普通幻灯片转化为 3D 演示文稿的最简便方式。自 Aspose.Slides 20.9 起，新增了 **跨平台 3D 引擎**。该引擎支持导出并栅格化带有 3D 效果的形状和文本。早期版本中，带有 3D 效果的形状会被渲染为平面；而现在可以呈现 **完整的 3D**。您还可以通过 Aspose.Slides API 创建带有 3D 效果的形状。

在 Aspose.Slides API 中，要将形状设为 PowerPoint 3D 形状，请使用 [Shape.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/three_d_format/) 属性，该属性公开了 [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat) 类的成员：

- [bevel_bottom](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/bevel_bottom/) 和 [bevel_top](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/bevel_top/)：设置倒角，选择倒角类型（例如 Angle、Circle、SoftRound），并定义倒角的高度和宽度。
- [camera](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/camera/)：模拟相机围绕对象的运动；通过调整相机旋转、缩放等属性，可像在 PowerPoint 中操作 3D 模型一样操控形状。
- [contour_color](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/contour_color/) 和 [contour_width](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/contour_width/)：设置轮廓属性，使形状看起来像 3D PowerPoint 对象。
- [depth](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/depth/)、[extrusion_color](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_color/) 和 [extrusion_height](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_height/)：通过设置深度或拉伸，使形状拥有三维效果。
- [light_rig](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/light_rig/)：为 3D 形状创建光照效果；类似相机，您可以设置光源相对于 3D 形状的旋转并选择光源类型。
- [material](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/material/)：选择材质，使 3D 形状更具真实感。预定义材质包括 Metal、Plastic、Powder、Matte 等。

所有 3D 功能均可应用于形状和文本。下面的章节展示了如何访问这些属性并逐步进行演示。

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

您可以在三维空间中旋转 PowerPoint 3D 形状，以增加交互性。要在 PowerPoint 中旋转 3D 形状，请使用以下菜单：

![todo:image_alt_text](img_02_01.png)

在 Aspose.Slides API 中，您可以通过 [camera](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/camera/) 属性控制形状的 3D 旋转。

```py
shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)
shape.three_d_format.camera.set_rotation(20, 30, 40)
# ... 设置其他 3D 场景参数

with slide.get_image(image_scale, image_scale) as thumbnail:
    thumbnail.save("sample_3d.png")
```

## **3D 深度与拉伸**

要为形状添加第三维度并真正实现 3D，使用 [ThreeDFormat.extrusion_height](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_height/) 和 [ThreeDFormat.extrusion_color](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_color/) 属性：

```py
shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)
shape.three_d_format.camera.set_rotation(20, 30, 40)
shape.three_d_format.extrusion_height = 100
shape.three_d_format.extrusion_color.color = drawing.Color.purple
# ... 设置其他 3D 场景参数

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

效果如下：

![todo:image_alt_text](img_02_03.png)

除了渐变填充，您还可以使用图像填充形状：

```py
with open("image.png", "rb") as image_file:
    image_data = image_file.read()

    shape.fill_format.fill_type = slides.FillType.PICTURE
    shape.fill_format.picture_fill_format.picture.image = presentation.images.add_image(image_data)
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    # ... 设置 3D：shape.three_d_format.camera、shape.three_d_format.light_rig、shape.three_d_format.Extrusion* 等属性

    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("sample_3d.png")
```

呈现效果如下所示：

![todo:image_alt_text](img_02_04.png)

## **3D 文本（WordArt）**

Aspose.Slides 也支持对文本应用 3D 效果。要创建 3D 文本，您可以使用 WordArt 变换效果：

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
    # 设置 “Arch Up” WordArt 变换效果
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

会的。Slides 3D 引擎在导出为受支持的格式时会渲染 3D 效果（[图像](/slides/zh/python-net/convert-powerpoint-to-png/)、[PDF](/slides/zh/python-net/convert-powerpoint-to-pdf/)、[HTML](/slides/zh/python-net/convert-powerpoint-to-html/) 等）。

**我能获取考虑主题、继承等因素后的 “有效” 3D 参数值吗？**

可以。Slides 提供了 API 来 [读取有效值](/slides/zh/python-net/shape-effective-properties/)（包括 3D 的光照、倒角等），以查看最终应用的设置。

**在将演示文稿转换为视频时，3D 效果是否可用？**

可以。在 [生成视频帧](/slides/zh/python-net/convert-powerpoint-to-video/) 时，3D 效果会和 [导出图像](/slides/zh/python-net/convert-powerpoint-to-png/) 的渲染方式相同。