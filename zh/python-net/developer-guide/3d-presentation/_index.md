---
title: 在 Python 中为演示文稿创建 3D 效果
linktitle: 3D 演示文稿
type: docs
weight: 232
url: /zh/python-net/3d-presentation/
keywords:
- PowerPoint 3D
- 3D 演示文稿
- 3D 旋转
- 3D 深度
- 3D 拉伸
- 3D 渐变
- 3D 文字
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides
description: "在 Python 中使用 Aspose.Slides 为 PowerPoint 形状和文字应用并渲染 3D 效果。配置相机、灯光、材质、拉伸、填充和 3D 文字。"
---
## **概述**

Aspose.Slides for Python via .NET 能够创建、编辑、保存并渲染 PowerPoint 样式的形状和文字的 3D 格式化。本篇文章涵盖旋转、拉伸、斜角、灯光、材质、渐变或图片填充以及 3D 文字等 3D 效果。

{{% alert color="primary" %}}
本文讨论的是 PowerPoint 形状和文字的 3D 格式化效果，并不涉及插入或编辑独立的 3D 模型文件。当您将幻灯片导出为图像、PDF 或 HTML 时，Aspose.Slides 会将这些 3D 效果渲染到导出的 2D 输出中。
{{% /alert %}}

## **3D 格式化概念**

使用 [Shape.three_d_format](https://reference.aspose.com/slides/zh/python-net/aspose.slides/shape/three_d_format/) 属性为形状应用 3D 格式化。该属性公开 [ThreeDFormat](https://reference.aspose.com/slides/zh/python-net/aspose.slides/threedformat/)，用于控制该形状的 3D 场景。

对于文字，使用 [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframeformat/three_d_format/) 属性。这会对文本框而不是形状本体应用 3D 格式化。

最重要的属性包括：

| 属性 | 控制内容 | 使用场景 |
|---|---|---|
| [camera](https://reference.aspose.com/slides/zh/python-net/aspose.slides/threedformat/camera/) | 视点、预设相机类型、旋转、缩放和透视。 | 在 3D 空间中旋转对象或匹配 PowerPoint 的 3D 旋转预设。 |
| [light_rig](https://reference.aspose.com/slides/zh/python-net/aspose.slides/threedformat/light_rig/) | 灯光预设、方向和灯光旋转。 | 改变 3D 表面上的高光和阴影表现。 |
| [material](https://reference.aspose.com/slides/zh/python-net/aspose.slides/threedformat/material/) | 表面材质，如平面、哑光、塑料或金属。 | 使相同几何体呈现更平坦、柔和、光亮或金属质感。 |
| [extrusion_height](https://reference.aspose.com/slides/zh/python-net/aspose.slides/threedformat/extrusion_height/) | 形状从正面向后延伸的距离。 | 将平面形状转换为可视的厚度 3D 对象。 |
| [extrusion_color](https://reference.aspose.com/slides/zh/python-net/aspose.slides/threedformat/extrusion_color/) | 拉伸侧面的颜色。 | 显示深度或让侧面颜色与正面填充相匹配。 |
| [depth](https://reference.aspose.com/slides/zh/python-net/aspose.slides/threedformat/depth/) | PowerPoint 3D 格式化使用的附加深度。 | 在形状或文字上微调深度，尤其与斜角和材质设置配合使用时。 |
| [bevel_top](https://reference.aspose.com/slides/zh/python-net/aspose.slides/threedformat/bevel_top/) 和 [bevel_bottom](https://reference.aspose.com/slides/zh/python-net/aspose.slides/threedformat/bevel_bottom/) | 正面和背面的凸起或圆角边缘。 | 为平面添加柔化或成型的边缘，而不是锐利的平面。 |
| [contour_color](https://reference.aspose.com/slides/zh/python-net/aspose.slides/threedformat/contour_color/) 和 [contour_width](https://reference.aspose.com/slides/zh/python-net/aspose.slides/threedformat/contour_width/) | 围绕 3D 对象的轮廓线。 | 在渲染输出中强调对象边界。 |

## **创建 3D 形状**

一个形状在看起来逼真 3D 之前通常需要四类设置：

- 相机设置，因为默认的正面视图可能看不见拉伸效果。
- 灯光设置，因为光照决定了各面是否可辨。
- 材质设置，因为表面材质影响光线的渲染方式。
- 拉伸或深度设置，因为平面形状需要厚度。

下面的示例创建一个矩形，在正面添加文字，应用 3D 格式化，将演示文稿保存为 PPTX，并将幻灯片渲染为 PNG 图像。

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

渲染后的幻灯片图像显示矩形为一个厚实的 3D 块：

![渲染的蓝色 3D 矩形，正面有白色 3D 文字](img_01_01.png)

## **使用相机旋转形状**

在 PowerPoint 中，3D 旋转通过“3‑D 旋转”窗格配置。X、Y、Z 旋转值对应通过相机 API 设置的旋转。

![PowerPoint 3‑D 旋转窗格，突出显示 X、Y、Z 旋转值](img_02_01.png)

在 Aspose.Slides 中，通过 [ThreeDFormat.camera](https://reference.aspose.com/slides/zh/python-net/aspose.slides/threedformat/camera/) 设置相机类型和旋转：

```py
shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
shape.three_d_format.camera.set_rotation(20, 30, 40)
```

当需要改变观看者看到对象的角度时使用相机。它不会改变幻灯片上 2D 形状的几何形状，只会改变 PowerPoint 和 Aspose.Slides 渲染时使用的 3D 视点。

## **添加拉伸和深度**

拉伸通过在正面后方延伸形状来实现厚度效果。在 PowerPoint 中，深度控制可见厚度，颜色控制侧面颜色。

![PowerPoint 深度控制映射到 extrusion_color 和 extrusion_height 属性](img_02_02.png)

使用 [ThreeDFormat.extrusion_height](https://reference.aspose.com/slides/zh/python-net/aspose.slides/threedformat/extrusion_height/) 设置厚度，使用 [ThreeDFormat.extrusion_color](https://reference.aspose.com/slides/zh/python-net/aspose.slides/threedformat/extrusion_color/) 设置侧面颜色：

```py
shape.three_d_format.camera.set_rotation(20, 30, 40)
shape.three_d_format.extrusion_height = 100
shape.three_d_format.extrusion_color.color = drawing.Color.purple
```

当需要直接使用 PowerPoint 的深度值或将深度与斜角、材质、文字效果组合时，使用 [ThreeDFormat.depth](https://reference.aspose.com/slides/zh/python-net/aspose.slides/threedformat/depth/)。在大多数形状场景下，使用 [ThreeDFormat.extrusion_height](https://reference.aspose.com/slides/zh/python-net/aspose.slides/threedformat/extrusion_height/) 更直观，因为它直接表示可见的拉伸高度。

## **在 3D 效果中使用渐变或图片填充**

3D 格式化与形状填充相互独立。您可以对正面使用纯色、渐变、图案或图片填充，同时保持相同的相机、灯光、材质和拉伸设置。

下面的示例对形状使用渐变填充，并为侧面指定更暗的拉伸颜色：

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

渲染结果保持正面的渐变，并单独渲染拉伸：

![渲染的 3D 矩形，正面为蓝‑橙渐变填充，侧面为橙色拉伸](img_02_03.png)

若想使用图片填充，请先将图像添加到演示文稿，然后将其分配给形状填充：

```py
with open("image.jpg", "rb") as image_file:
    image_data = image_file.read()

image = presentation.images.add_image(image_data)

shape.fill_format.fill_type = slides.FillType.PICTURE
shape.fill_format.picture_fill_format.picture.image = image
shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

shape.three_d_format.camera.set_rotation(10, 20, 30)
shape.three_d_format.extrusion_height = 150
shape.three_d_format.extrusion_color.color = drawing.Color.dark_orange
```

图片渲染在正面，拉伸则渲染为 3D 侧表面：

![渲染的 3D 矩形，正面为照片填充，侧面为橙色拉伸](img_02_04.png)

## **对文字应用 3D 格式化**

形状的 3D 格式化影响形状本体，文字的 3D 格式化影响文本框。这对类似 WordArt 的效果很有用，字母本身需要拉伸、材质、光照和相机设置。

下面的示例创建使用图案填充的文字，应用 WordArt 变换，并在 [TextFrameFormat](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframeformat/) 上配置 3D 设置：

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

文字呈现为弧形、拉伸的 3D 字母：

![渲染的 3D 文字，带拱形 WordArt 变换、橙色图案填充和深色拉伸](img_02_05.png)

## **导出和渲染行为**

Aspose.Slides 在保存为 PPTX 等 PowerPoint 格式时会保留 3D 格式化。渲染或导出为固定布局格式时，3D 场景会被光栅化或绘制为 2D 结果。此行为同样适用于将幻灯片渲染为 [PNG](/slides/zh/python-net/convert-powerpoint-to-png/)、导出为 [PDF](/slides/zh/python-net/convert-powerpoint-to-pdf/)、导出为 [HTML](/slides/zh/python-net/convert-powerpoint-to-html/)，或为 [视频转换](/slides/zh/python-net/convert-powerpoint-to-video/) 生成帧。

请注意以下要点：

- 导出的图像和 PDF 并非交互式，导出后观众无法旋转对象。
- 最终外观取决于相机、灯光组、材质、拉伸、填充和幻灯片缩放的组合。
- 如需检查继承或主题基的格式化值，请读取 [effective shape properties](/slides/zh/python-net/shape-effective-properties/)。
- 某些输出格式无法存储可编辑的 PowerPoint 3D 格式化。在这些格式中，视觉结果是渲染后的图像，而非可编辑的 3D 设置。

## **常见问题**

**Aspose.Slides 能创建交互式 3D 演示文稿吗？**

Aspose.Slides 可以创建并渲染 PowerPoint 形状和文字的 3D 效果，但不会将导出的图像、PDF 或 HTML 页面制作成交互式 3D 场景供观众旋转。在 PPTX 中，只要格式支持，3D 格式化仍保持可编辑。

**3D 模型和 3D 效果有什么区别？**

3D 模型是插入到演示文稿中的独立 3D 对象。3D 效果是对普通 PowerPoint 形状或文字应用的格式化，如旋转、拉伸、斜角、灯光和材质。本文讨论的正是 3D 效果。

**可见的 3D 形状需要哪些设置？**

最低要求是设置相机旋转并使用拉伸或深度。实际使用中，通常还会设置灯光组和材质，以确保渲染出的面具有明确的高光和阴影。

**可以对形状和文字同时应用 3D 效果吗？**

可以。对形状本体使用 [Shape.three_d_format](https://reference.aspose.com/slides/zh/python-net/aspose.slides/shape/three_d_format/)，对文字使用 [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframeformat/three_d_format/)。

**导出为图像、PDF、HTML 或视频帧时会出现 3D 效果吗？**

会。Aspose.Slides 在生成幻灯片图像、PDF、HTML 和用于视频转换的帧时，会渲染 3D 效果。导出的文件包含渲染后的外观，而不是可编辑的 3D 对象。

**能够读取继承和主题设置后最终的 3D 值吗？**

可以。使用文中提到的有效格式化 API（见 [Shape Effective Properties](/slides/zh/python-net/shape-effective-properties/)）即可读取最终的相机、灯光组、斜角等 3D 值。