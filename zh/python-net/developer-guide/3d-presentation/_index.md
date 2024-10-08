---
title: 3D 演示文稿
type: docs
weight: 232
url: /python-net/3d-presentation/
keywords:
- 3D
- 3D PowerPoint
- 3D 演示文稿
- 3D 旋转
- 3D 深度
- 3D 拉伸
- 3D 渐变
- 3D 文本
- PowerPoint 演示文稿
- Python
- Aspose.Slides for Python via .NET
description: "Python 中的 3D PowerPoint 演示文稿"
---

## 概述
您通常如何创建 3D PowerPoint 演示文稿？
Microsoft PowerPoint 允许我们添加 3D 模型、对形状应用 3D 效果、创建 3D 文本、上传 3D 图形到演示文稿、创建 PowerPoint 3D 动画，从而创建 3D 演示文稿。

创建 3D 效果对提升演示文稿的呈现效果有很大影响，同时也是实现 3D 演示文稿最简单的实现方式。自 Aspose.Slides 20.9 版本以来，添加了一个新的 **跨平台 3D 引擎**。新的 3D 引擎能够导出和栅格化带 3D 效果的形状和文本。在先前的版本中，具备 3D 效果的幻灯片形状被渲染为平面。但现在可以实现 **完整的 3D 渲染**。
此外，现在可以通过Slides公共API创建带有3D效果的形状。

在 Aspose.Slides API 中，要使形状变成 PowerPoint 3D 形状，请使用 [IShape.ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/) 属性，该属性继承了 [IThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat) 接口的特性：
- [BevelBottom](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/) 
和 [BevelTop](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/): 为形状设置斜面，定义斜面类型（例如，角度、圆形、软圆），定义斜面的高度和宽度。
- [camera](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/): 用于模拟对象周围的相机运动。换句话说，通过设置相机的旋转、缩放和其他属性，您可以像在 PowerPoint 中与 3D 模型互动一样与您的形状互动。
- [ContourColor](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/) 
和 [ContourWidth](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/): 设置轮廓属性，使形状看起来像 3D PowerPoint 形状。
- [depth](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/)， 
[extrusion_color](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/) 
和 [extrusion_height](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/): 用于使形状具有三维效果，这意味着通过设置其深度或拉伸它将 2D 形状转换为 3D 形状。
- [light_rig](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/): 可以在 3D 形状上创建光效。此属性的逻辑与相机相近，您可以设置光线相对于 3D 形状的旋转并选择光源类型。
- [material](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/): 设置 3D 形状材料的类型可以为其带来更生动的效果。该属性提供了一组预定义材料，例如：金属、塑料、粉末、哑光等。

所有 3D 特性均可应用于形状和文本。让我们看看如何访问上述提到的属性，然后逐步详细了解它们：
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

渲染的缩略图如下所示：

![todo:image_alt_text](img_01_01.png)

## 3D 旋转
可以在 3D 平面中旋转 PowerPoint 3D 形状，从而增强互动性。要在 PowerPoint 中旋转 3D 形状，您通常使用以下菜单：

![todo:image_alt_text](img_02_01.png)

在 Aspose.Slides API 中，3D 形状旋转可以使用 [camera](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/) 属性进行管理：

```py
shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)
shape.three_d_format.camera.set_rotation(20, 30, 40)
# ... 设置其他 3D 场景参数

with slide.get_image(image_scale, image_scale) as thumbnail:
    thumbnail.save("sample_3d.png")
```

## 3D 深度和拉伸
要为您的形状带来第三维度并使其成为 3D 形状，请使用 [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/) 
和 [extrusion_color.color](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/) 属性：

```py
shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)
shape.three_d_format.camera.set_rotation(20, 30, 40)
shape.three_d_format.extrusion_height = 100
shape.three_d_format.extrusion_color.color = drawing.Color.purple
# ... 设置其他 3D 场景参数

with slide.get_image(image_scale, image_scale) as thumbnail:
    thumbnail.save("sample_3d.png")
```

通常，您会在 PowerPoint 中使用深度菜单来设置 PowerPoint 3D 形状的深度：

![todo:image_alt_text](img_02_02.png)


## 3D 渐变
渐变可用于填充 PowerPoint 3D 形状的颜色。让我们创建一个具有渐变填充颜色的形状并在其上应用 3D 效果：

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

image_scale = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 250, 250)
    shape.text_frame.text = "3D 渐变"
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

结果如下所示：

![todo:image_alt_text](img_02_03.png)

除了渐变填充颜色外，还可以用图像填充形状：
```py
with open("image.png", "rb") as image_file: 
    image_data = image_file.read()

    shape.fill_format.fill_type = slides.FillType.PICTURE
    shape.fill_format.picture_fill_format.picture.image = presentation.images.add_image(image_data)
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    # ... 设置 3D：shape.three_d_format.camera，shape.three_d_format.light_rig，shape.three_d_format.Extrusion* 属性

    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("sample_3d.png")
```


效果如下所示：

![todo:image_alt_text](img_02_04.png)

## 3D 文本 (艺术字)
Aspose.Slides 也允许在文本上应用 3D 效果。要创建 3D 文本，可以使用艺术字变换效果：

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
    shape.text_frame.text = "3D 文本"
   
    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.portion_format.fill_format.fill_type = slides.FillType.PATTERN
    portion.portion_format.fill_format.pattern_format.fore_color.color = drawing.Color.dark_orange
    portion.portion_format.fill_format.pattern_format.back_color.color = drawing.Color.white
    portion.portion_format.fill_format.pattern_format.pattern_style = slides.PatternStyle.LARGE_GRID
   
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 128
   
    text_frame_format = shape.text_frame.text_frame_format
    # 设置 "Arch Up" 艺术字变换效果
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


## 不支持 - 即将推出
以下 PowerPoint 3D 特性尚不支持：
- 斜面
- 材料
- 轮廓
- 照明

我们将继续改进我们的 3D 引擎，这些功能将是后续实现的目标。