---
title: 在 Python 中创建 3D 演示文稿
linktitle: 3D 演示
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
description: "使用 Aspose.Slides 在 Python 中轻松生成交互式 3D 演示文稿。快速导出为 PowerPoint 和 OpenDocument 格式，以实现多用途使用。"
---

## **概述**

您通常如何创建 3D PowerPoint 演示文稿？Microsoft PowerPoint 允许您添加 3D 模型、对形状应用 3D 效果、创建 3D 文本、插入 3D 图形以及构建 3D 动画。

创建 3D 效果影响显著，通常是将普通幻灯片转变为 3D 演示文稿的最简方法。自 Aspose.Slides 20.9 起，新增了 **跨平台 3D 引擎**。该引擎支持对带有 3D 效果的形状和文本进行导出和光栅化。早期版本中，带有 3D 效果的形状会被渲染为平面；现在可以实现 **完整的 3D** 渲染。您也可以通过 Aspose.Slides API 创建带有 3D 效果的形状。

在 Aspose.Slides API 中，若要将形状设为 PowerPoint 3D 形状，使用 [Shape.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/three_d_format/) 属性，该属性公开了 [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat) 类的成员：

- [bevel_bottom](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/bevel_bottom/) 与 [bevel_top](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/bevel_top/)：设置倒角，选择倒角类型（如 Angle、Circle、SoftRound），并定义倒角的高度和宽度。  
- [camera](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/camera/)：模拟相机围绕对象的运动；通过调整相机旋转、缩放等属性，可像在 PowerPoint 中操作 3D 模型一样操作形状。  
- [contour_color](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/contour_color/) 与 [contour_width](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/contour_width/)：设置轮廓属性，使形状看起来像 PowerPoint 中的 3D 对象。  
- [depth](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/depth/)、[extrusion_color](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_color/)、[extrusion_height](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_height/)：通过设置深度或拉伸来使形状具备三维感。  
- [light_rig](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/light_rig/)：为 3D 形状创建光照效果；类似相机，可设置光源相对于 3D 形状的旋转并选择光源类型。  
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

渲染后的缩略图如下：

![todo:image_alt_text](img_01_01.png)

## **3D 旋转**

您可以在三维空间中旋转 PowerPoint 3D 形状，以增加交互性。要在 PowerPoint 中旋转 3D 形状，请使用以下菜单：

![todo:image_alt_text](img_02_01.png)

在 Aspose.Slides API 中，可通过 [camera](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/camera/) 属性控制形状的 3D 旋转。

```py
shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)
shape.three_d_format.camera.set_rotation(20, 30, 40)
# ... 设置其他 3D 场景参数

with slide.get_image(image_scale, image_scale) as thumbnail:
    thumbnail.save("sample_3d.png")
```

## **3D 深度与拉伸**

若要为形状添加第三维度，使其真正成为 3D，请使用 [ThreeDFormat.extrusion_height](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_height/) 与 [ThreeDFormat.extrusion_color](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_color/) 属性：

```py
shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)
shape.three_d_format.camera.set_rotation(20, 30, 40)
shape.three_d_format.extrusion_height = 100
shape.three_d_format.extrusion_color.color = drawing.Color.purple
# ... 设置其他 3D 场景参数

with slide.get_image(image_scale, image_scale) as thumbnail:
    thumbnail.save("sample_3d.png")
```

在 PowerPoint 中，通常使用 **Depth** 菜单来设置 3D 形状的深度：

![todo:image_alt_text](img_02_02.png)

## **3D 渐变**

渐变可用于填充 PowerPoint 3D 形状。下面创建一个带有渐变填充并应用 3D 效果的形状：

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

除了渐变填充，还可以使用图片填充形状：

```py
with open("image.png", "rb") as image_file:
    image_data = image_file.read()

    shape.fill_format.fill_type = slides.FillType.PICTURE
    shape.fill_format.picture_fill_format.picture.image = presentation.images.add_image(image_data)
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    # ... 设置 3D：shape.three_d_format.camera, shape.three_d_format.light_rig, shape.three_d_format.Extrusion* 属性

    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("sample_3d.png")
```

效果如下：

![todo:image_alt_text](img_02_04.png)

## **3D 文本（WordArt）**

Aspose.Slides 也允许对文本应用 3D 效果。要创建 3D 文本，可使用 WordArt 变换效果：

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

结果如下：

![todo:image_alt_text](img_02_05.png)

## **常见问题**

**将演示文稿导出为图像/PDF/HTML 时，3D 效果会被保留吗？**

是的。Slides 3D 引擎在导出为受支持的格式时会渲染 3D 效果（[图像](/slides/zh/python-net/convert-powerpoint-to-png/)、[PDF](/slides/zh/python-net/convert-powerpoint-to-pdf/)、[HTML](/slides/zh/python-net/convert-powerpoint-to-html/) 等）。

**我能获取包含主题、继承等因素在内的“有效” 3D 参数值吗？**

是的。Slides 提供 API 可[读取有效值](/slides/zh/python-net/shape-effective-properties/)（包括 3D‑灯光、倒角等），帮助您查看最终应用的设置。

**在将演示文稿转换为视频时，3D 效果会工作吗？**

会的。当[为视频生成帧](/slides/zh/python-net/convert-powerpoint-to-video/)时，3D 效果会像[导出的图像](/slides/zh/python-net/convert-powerpoint-to-png/)一样被渲染。