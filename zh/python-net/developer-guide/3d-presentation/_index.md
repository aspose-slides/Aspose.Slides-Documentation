---
title: 使用 Python 在演示文稿中创建 3D 效果
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
- 演示文稿
- Python
- Aspose.Slides
description: "使用 Aspose.Slides 在 Python 中应用并渲染 PowerPoint 形状和文本的 3D 效果。配置相机、照明、材质、拉伸、填充和 3D 文本。"
---
## **概述**

Aspose.Slides for Python via .NET 可以创建、编辑、保留并渲染 PowerPoint 样式的形状和文本的 3D 格式化。本文章涵盖旋转、拉伸、倒角、照明、材质、渐变或图片填充以及 3D 文本等 3D 效果。

{{% alert color="info" title="注意" %}}
本文讨论的是 PowerPoint 形状和文本的 3D 格式化效果，不涉及插入或编辑独立的 3D 模型文件。将幻灯片导出为图像、PDF 或 HTML 时，Aspose.Slides 会将这些 3D 效果渲染为导出的 2D 输出。
{{% /alert %}}

## **3D 格式化概念**

使用 [Shape.three_d_format](https://reference.aspose.com/slides/zh/python-net/aspose.slides/shape/three_d_format/) 属性对形状应用 3D 格式化。该属性公开 [ThreeDFormat](https://reference.aspose.com/slides/zh/python-net/aspose.slides/threedformat/)，用于控制该形状的 3D 场景。

对文本使用 [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframeformat/three_d_format/) 属性。这会对文本框而非形状主体应用 3D 格式化。

最重要的属性包括：

| Property | 控制内容 | 使用场景 |
|---|---|---|
| [camera](https://reference.aspose.com/slides/zh/python-net/aspose.slides/threedformat/camera/) | 观察点、预设相机类型、旋转、缩放和透视。 | 在 3D 空间中旋转对象或匹配 PowerPoint 的 3D 旋转预设。 |
| [light_rig](https://reference.aspose.com/slides/zh/python-net/aspose.slides/threedformat/light_rig/) | 光源预设、方向和光线旋转。 | 更改 3D 表面上的高光和阴影显示方式。 |
| [material](https://reference.aspose.com/slides/zh/python-net/aspose.slides/threedformat/material/) | 表面材质，如平面、哑光、塑料或金属。 | 让相同几何形状呈现出更平坦、柔和、光亮或金属感。 |
| [extrusion_height](https://reference.aspose.com/slides/zh/python-net/aspose.slides/threedformat/extrusion_height/) | 形状从前表面向后延伸的距离。 | 将平面形状转换为可见厚度的 3D 对象。 |
| [extrusion_color](https://reference.aspose.com/slides/zh/python-net/aspose.slides/threedformat/extrusion_color/) | 拉伸侧面的颜色。 | 显示深度或使侧面颜色与前填充颜色保持一致。 |
| [depth](https://reference.aspose.com/slides/zh/python-net/aspose.slides/threedformat/depth/) | PowerPoint 3D 格式化使用的附加深度。 | 对形状或文本进行微调，特别是配合倒角和材质设置时。 |
| [bevel_top](https://reference.aspose.com/slides/zh/python-net/aspose.slides/threedformat/bevel_top/) 和 [bevel_bottom](https://reference.aspose.com/slides/zh/python-net/aspose.slides/threedformat/bevel_bottom/) | 前后表面的凸起或圆角。 | 为平面面添加柔化或模具式边缘。 |
| [contour_color](https://reference.aspose.com/slides/zh/python-net/aspose.slides/threedformat/contour_color/) 和 [contour_width](https://reference.aspose.com/slides/zh/python-net/aspose.slides/threedformat/contour_width/) | 3D 对象的轮廓线颜色和宽度。 | 在渲染输出中强调对象边界。 |

## **创建 3D 形状**

形状通常需要四类设置才能看起来逼真 3D：

- 相机设置，因为默认的正视图可能隐藏拉伸效果。
- 光照设置，因为光照让各面和侧面可被辨识。
- 材质设置，因为表面材质影响光线的渲染方式。
- 拉伸或深度设置，因为平面形状需要厚度。

下面示例创建一个矩形，在其前表面添加文本，并应用 3D 格式化。相机旋转值以度为单位，拉伸高度为 100 点。示例将幻灯片渲染为 PNG 图像（尺寸为默认的两倍），并将演示文稿另存为 PPTX。

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

image_scale = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)

    shape.text_frame.text = "3D"
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 64

    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = drawing.Color.cornflower_blue

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(20, 30, 40)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 100
    shape.three_d_format.extrusion_color.color = drawing.Color.blue

    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("shape_3d.png")

    presentation.save("shape_3d.pptx", slides.export.SaveFormat.PPTX)
```

渲染后的幻灯片图像显示矩形为厚实的 3D 块：

![渲染的蓝色 3D 矩形，前表面有白色 3D 文本](img_01_01.png)

## **使用相机旋转形状**

在 PowerPoint 中，3D 旋转通过“3‑D 旋转”窗格配置。X、Y、Z 旋转值对应通过相机 API 设置的旋转。

![PowerPoint 3‑D 旋转窗格，突出显示 X、Y、Z 旋转值](img_02_01.png)

在 Aspose.Slides 中，通过 [ThreeDFormat.camera](https://reference.aspose.com/slides/zh/python-net/aspose.slides/threedformat/camera/) 访问相机。此示例创建一个矩形，选择正交前视图，并将其 X、Y、Z 旋转分别设为 20、30、40 度。示例在内存中配置形状，不会保存文件：

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(20, 30, 40)
```

当需要改变观察者看到对象的方式时使用相机。它不改变幻灯片上 2D 形状的几何形状，只改变 PowerPoint 和 Aspose.Slides 渲染时使用的 3D 视点。

## **添加拉伸和深度**

拉伸通过在前表面后方延伸来使形状看起来更厚。PowerPoint 中的深度控制决定可见厚度，颜色控制决定侧面颜色。

![PowerPoint 深度控制映射到拉伸颜色和拉伸高度属性](img_02_02.png)

设置 [ThreeDFormat.extrusion_height](https://reference.aspose.com/slides/zh/python-net/aspose.slides/threedformat/extrusion_height/) 以确定厚度，设置 [ThreeDFormat.extrusion_color](https://reference.aspose.com/slides/zh/python-net/aspose.slides/threedformat/extrusion_color/) 以确定侧面颜色。此示例为矩形设置 100 点拉伸并使用紫色侧面，同时旋转相机以展示其厚度。示例在内存中配置形状，不会保存文件：

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(20, 30, 40)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 100
    shape.three_d_format.extrusion_color.color = drawing.Color.purple
```

[ThreeDFormat.depth](https://reference.aspose.com/slides/zh/python-net/aspose.slides/threedformat/depth/) 属性设置 3D 形状的深度。 [extrusion_height](https://reference.aspose.com/slides/zh/python-net/aspose.slides/threedformat/extrusion_height/) 属性控制拉伸效果的高度，如本例所示。

## **在 3D 效果中使用渐变或图片填充**

3D 格式化独立于形状填充。可以对前表面应用纯色、渐变、图案或图片填充，同时仍使用相同的相机、光照、材质和拉伸设置。

此示例对前表面使用蓝到橙的渐变，对 150 点拉伸使用深橙色。渐变停止点 0 和 100 标记渐变的起始和结束位置。相机旋转值以度为单位。幻灯片渲染为 PNG 图像（尺寸为默认的两倍）：

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
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 150
    shape.three_d_format.extrusion_color.color = drawing.Color.dark_orange

    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("gradient_3d.png")
```

渲染输出保持前表面的渐变，并单独渲染拉伸：

![渲染的 3D 矩形，前表面蓝到橙渐变填充，橙色拉伸](img_02_03.png)

若要使用图片填充，请将图像添加到演示文稿并分配给形状填充。此示例假设工作目录中已有名为 "image.jpg" 的文件。它将图片拉伸以填满矩形，应用 150 点拉伸，并以度为单位设置相机旋转。示例在内存中配置形状，不会保存或渲染文件：

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with open("image.jpg", "rb") as image_file:
    image_data = image_file.read()

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 250, 250)

    image = presentation.images.add_image(image_data)

    shape.fill_format.fill_type = slides.FillType.PICTURE
    shape.fill_format.picture_fill_format.picture.image = image
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(10, 20, 30)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 150
    shape.three_d_format.extrusion_color.color = drawing.Color.dark_orange
```

图片在前表面渲染，拉伸作为 3D 侧面渲染：

![渲染的 3D 矩形，前表面图片填充，橙色拉伸](img_02_04.png)

## **对文本应用 3D 格式化**

形状的 3D 格式化影响形状主体，文本的 3D 格式化影响文本框。这对于需要字母本身拥有拉伸、材质、灯光和相机设置的 WordArt 类效果非常有用。

下面示例创建带有橙白网格图案的文本，应用向上拱形，并通过 [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframeformat/three_d_format/) 配置 3D 设置。拉伸高度和深度以点为单位，光线旋转以度为单位。隐藏形状填充和轮廓，只显示文本。示例将 PNG 图像渲染为默认幻灯片尺寸的两倍，并将演示文稿另存为 PPTX：

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

image_scale = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 250, 250)
    
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
    shape.text_frame.text = "3D Text"

    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.portion_format.fill_format.fill_type = slides.FillType.PATTERN
    portion.portion_format.fill_format.pattern_format.fore_color.color = drawing.Color.dark_orange
    portion.portion_format.fill_format.pattern_format.back_color.color = drawing.Color.white
    portion.portion_format.fill_format.pattern_format.pattern_style = slides.PatternStyle.LARGE_GRID

    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 128

    text_frame_format = shape.text_frame.text_frame_format
    text_frame_format.transform = slides.TextShapeType.ARCH_UP
    text_frame_format.three_d_format.extrusion_height = 3.5
    text_frame_format.three_d_format.depth = 3
    text_frame_format.three_d_format.material = slides.MaterialPresetType.PLASTIC
    text_frame_format.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    text_frame_format.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED
    text_frame_format.three_d_format.light_rig.set_rotation(0, 0, 40)
    text_frame_format.three_d_format.camera.camera_type = slides.CameraPresetType.PERSPECTIVE_CONTRASTING_RIGHT_FACING

    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("text_3d.png")

    presentation.save("text_3d.pptx", slides.export.SaveFormat.PPTX)
```

文本被渲染为弧形、拉伸的 3D 字体：

![渲染的 3D 文本，拱形 WordArt 变换，橙色图案填充，深色拉伸](img_02_05.png)

## **在 3D 形状上保持文本平面显示**

要在保持形状 3D 外观的同时让文本易读，需通过 [TextFrame.text_frame_format](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframe/text_frame_format/) 设置 [TextFrameFormat.keep_text_flat](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframeformat/keep_text_flat/)。当值为 `True` 时，文本保持在 3D 场景之外；为 `False` 时，文本参与场景并随 3D 方向变化。

此设置不会移除形状的 3D 格式化：其相机、灯光、材质和拉伸仍通过 [Shape.three_d_format](https://reference.aspose.com/slides/zh/python-net/aspose.slides/shape/three_d_format/) 配置。它也不同于普通旋转。[Shape.rotation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/shape/rotation/) 在幻灯片平面中旋转形状，而 [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframeformat/rotation_angle/) 控制文本在其边界框内的自定义旋转。保持文本不参与 3D 场景不会重置这两个角度。

下面的自包含示例创建一个带文本的蓝色矩形，并在原始矩形旁复制一份。两者具备相同的 3D 格式化，仅文本设置不同：左侧为 `False`，右侧为 `True`。相机角度以度为单位，拉伸高度为 40 点。示例将演示文稿保存为 PPTX，并将对比幻灯片渲染为 PNG（尺寸为默认的两倍）。

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 70, 160, 240, 140)

    shape.text_frame.text = "Readable text"
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 28
    shape.text_frame.paragraphs[0].paragraph_format.alignment = slides.TextAlignment.CENTER
    shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.CENTER
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = drawing.Color.cornflower_blue

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(30, 30, 0)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 40
    shape.three_d_format.extrusion_color.color = drawing.Color.royal_blue
    shape.text_frame.text_frame_format.keep_text_flat = False

    flat_text_shape = slide.shapes.add_clone(shape, 400, 160)
    flat_text_shape.text_frame.text_frame_format.keep_text_flat = True

    presentation.save("keep_text_flat.pptx", slides.export.SaveFormat.PPTX)
    with slide.get_image(2, 2) as image:
        image.save("keep_text_flat.png")
```

左侧文本随 3D 方向变化，右侧文本保持平面且更易阅读。两个矩形保持相同的可视拉伸和 3D 方向。

![并排 3D 矩形：左侧 keep_text_flat 为 False，右侧为 True](keep_text_flat.png)

## **导出和渲染行为**

Aspose.Slides 在保存为 PPTX 等 PowerPoint 格式时会保留 3D 格式化。渲染或导出为固定布局格式时，3D 场景会被光栅化或绘制为 2D 结果。这适用于将幻灯片渲染为 [PNG](/slides/zh/python-net/convert-powerpoint-to-png/)、导出为 [PDF](/slides/zh/python-net/convert-powerpoint-to-pdf/)、导出为 [HTML](/slides/zh/python-net/convert-powerpoint-to-html/)，或生成用于 [视频转换](/slides/zh/python-net/convert-powerpoint-to-video/) 的帧。

请注意以下要点：

- 导出的图像和 PDF 并非交互式。导出后对象无法被观看者旋转。
- 最终外观取决于相机、灯光装置、材质、拉伸、填充和幻灯片缩放的组合。
- 如需检查继承或主题基的格式化值，请读取 [effective shape properties](/slides/zh/python-net/shape-effective-properties/)。
- 某些输出格式无法存储可编辑的 PowerPoint 3D 格式化。在这些格式中，视觉结果是渲染后的，而不是可编辑的 3D 设置。

## **常见问题**

**Aspose.Slides 能创建交互式 3D 演示文稿吗？**

Aspose.Slides 创建并渲染 PowerPoint 形状和文本的 3D 效果。它不会使导出的图像、PDF 或 HTML 页面成为可交互的 3D 场景供观看者旋转。在 PPTX 中，只要格式支持，3D 格式化仍可在 PowerPoint 中编辑。

**3D 模型和 3D 效果有什么区别？**

3D 模型是插入到演示文稿中的独立 3D 对象。3D 效果是对普通 PowerPoint 形状或文本应用的格式化，如旋转、拉伸、倒角、照明和材质。本文仅讨论 3D 效果。

**实现可见 3D 形状需要哪些设置？**

至少要设置相机旋转以及拉伸或深度。实际使用中，还应设置灯光装置和材质，以确保渲染面的高光和阴影清晰可见。

**我可以同时对形状和文本应用 3D 效果吗？**

可以。对形状主体使用 [Shape.three_d_format](https://reference.aspose.com/slides/zh/python-net/aspose.slides/shape/three_d_format/)，对文本使用 [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframeformat/three_d_format/)。

**导出为图像、PDF、HTML 或视频帧时会显示 3D 效果吗？**

会。Aspose.Slides 在生成幻灯片图像、PDF、HTML 输出以及用于视频转换的帧时会渲染 3D 效果。导出的输出包含渲染后的外观，而不是可编辑的 3D 对象。

**我能读取继承和主题设置后最终的 3D 值吗？**

可以。使用在 [Shape Effective Properties](/slides/zh/python-net/shape-effective-properties/) 中描述的有效格式化 API，读取最终的相机、灯光装置、倒角和相关 3D 值。