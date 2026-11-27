---
title: 使用 Python 在演示文稿中应用形状效果
linktitle: 形状效果
type: docs
weight: 30
url: /zh/python-net/shape-effect
keywords:
- 形状效果
- 阴影效果
- 反射效果
- 辉光效果
- 柔和边缘效果
- 效果格式
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python 将您的 PPT、PPTX 和 ODP 文件转换为高级形状效果——在几秒钟内创建引人注目、专业的幻灯片。"
---
## **介绍**

虽然 PowerPoint 中的效果可用于使形状突出，但它们不同于[填充](/slides/zh/python-net/shape-formatting/#gradient-fill)或轮廓。使用 PowerPoint 效果，您可以在形状上创建逼真的反射，扩散形状的辉光等。

![形状效果](shape-effect.png)

PowerPoint 提供六种可应用于形状的效果。您可以对形状应用一个或多个效果。

某些效果组合看起来比其他的更好。因此，PowerPoint 在**Preset**下提供了选项。Preset 选项本质上是一种已知的美观组合，包含两个或多个效果。通过选择预设，您无需花时间测试或组合不同的效果来寻找合适的组合。

Aspose.Slides 在[EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/) 类下提供属性和方法，允许您对 PowerPoint 演示文稿中的形状应用相同的效果。

## **应用阴影效果**

Aspose.Slides for Python via .NET 支持形状的外部和内部阴影。您可以自定义其颜色、方向、距离和模糊半径，以匹配演示文稿的设计。

### **应用外部阴影**

使用外部阴影可以使卡片或面板在幻灯片背景中突出。阴影超出形状边缘，营造出形状浮起于幻灯片之上的效果。调整其颜色、方向、距离和模糊半径以匹配模板的光照和样式。

下面的 Python 代码展示了如何将[外部阴影效果](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/outer_shadow_effect/)应用于矩形：

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 100)
    shape.effect_format.enable_outer_shadow_effect()
    shape.effect_format.outer_shadow_effect.shadow_color.color = slides.Color.dark_gray
    shape.effect_format.outer_shadow_effect.distance = 10
    shape.effect_format.outer_shadow_effect.direction = 45

    presentation.save("shadow_effect.pptx", slides.export.SaveFormat.PPTX)
```

![阴影效果](shadow_effect.png)

#### **在形状旋转时控制阴影方向**

默认情况下，[OuterShadow.rotate_shadow_with_shape](https://reference.aspose.com/slides/python-net/aspose.slides.effects/outershadow/rotate_shadow_with_shape/) 为 `True`，因此阴影随形状旋转。若要使不同旋转角度的形状看起来来自相同方向的光照，请将此属性设为 `False` 并为它们的阴影设置相同的[方向](https://reference.aspose.com/slides/python-net/aspose.slides.effects/outershadow/direction/)。

该示例创建了两个箭头，灰色阴影向右偏移 42 点（`direction = 0`）。随后复制幻灯片并将两个箭头顺时针旋转 90°。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    before = presentation.slides[0]

    left = before.shapes.add_auto_shape(slides.ShapeType.RIGHT_ARROW, 55, 130, 110, 60)
    left.fill_format.fill_type = slides.FillType.SOLID
    left.fill_format.solid_fill_color.color = slides.Color.steel_blue
    left.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    left.effect_format.enable_outer_shadow_effect()
    shadow = left.effect_format.outer_shadow_effect
    shadow.shadow_color.color = slides.Color.gray
    shadow.direction = 0
    shadow.distance = 42
    shadow.blur_radius = 0
    shadow.rotate_shadow_with_shape = True

    right = before.shapes.add_clone(left)
    right.x = 395
    right.effect_format.outer_shadow_effect.rotate_shadow_with_shape = False

    after = presentation.slides.add_clone(before)
    for arrow in after.shapes:
        arrow.rotation = 90

    presentation.save("arrow_shadows.pptx", slides.export.SaveFormat.PPTX)
```

在第二张幻灯片上，左侧箭头的阴影向下投射，而右侧箭头的阴影仍然向右投射。两者的方向均保持为 0°。

![PowerPoint 在 90° 旋转前后的渲染。两个阴影均起始于右侧。旋转后，左箭头的阴影移至下方，右箭头的阴影仍在右侧。](arrow-shadow-rotation.png)

### **应用内部阴影**

在复现模板的视觉样式时，使用内部阴影可以为卡片或面板营造凹陷效果。外部阴影向外延伸，使形状看起来凸起；而内部阴影则在边缘内部着色。

调用[enable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/enable_inner_shadow_effect/)，然后配置[inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/inner_shadow_effect/)。更大的模糊半径值会产生更柔和的边缘。

下面的 Python 示例创建了一个浅蓝色卡片，带有深灰色内部阴影，并将其保存为 PPTX 文件：

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = slides.Color.light_blue
    shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    shape.effect_format.enable_inner_shadow_effect()
    shadow = shape.effect_format.inner_shadow_effect
    shadow.shadow_color.color = slides.Color.dim_gray
    shadow.direction = 225
    shadow.distance = 7
    shadow.blur_radius = 6

    presentation.save("inner_shadow_effect.pptx", slides.export.SaveFormat.PPTX)
```

![带内部阴影的浅蓝色矩形](inner_shadow_effect.png)

要移除内部阴影，请在形状的效果格式上调用[disable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_inner_shadow_effect/)。

### **应用、修改和移除预设阴影**

调用[enable_preset_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/enable_preset_shadow_effect/)并将阴影的[预设](https://reference.aspose.com/slides/python-net/aspose.slides.effects/presetshadow/preset/)属性设置为[PresetShadowType](https://reference.aspose.com/slides/python-net/aspose.slides/presetshadowtype/)值。要切换样式，可在同一形状上更改预设。调用[disable_preset_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_preset_shadow_effect/)可在保留填充和轮廓的同时移除阴影。

此示例在同一幻灯片上并排显示四个阶段。每次更改前都会克隆矩形，以便比较结果。两个阴影均偏移 10 点。225° 的方向将第一个阴影放置在矩形的左上方，45° 的方向将第二个阴影放置在右下方。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(800, 120, slides.SlideSizeScaleType.DO_NOT_SCALE)
    shapes = presentation.slides[0].shapes

    shape = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 15, 30, 170, 60)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = slides.Color.steel_blue
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = slides.Color.dark_blue
    shape.text_frame.text = "No shadow"
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 14
    shapes.add_clone(shape)

    shape.x += 200
    shape.effect_format.enable_preset_shadow_effect()
    shadow = shape.effect_format.preset_shadow_effect
    shadow.preset = slides.PresetShadowType.TOP_LEFT_DROP_SHADOW
    shadow.distance = 10
    shadow.direction = 225
    shape.text_frame.text = "TopLeftDropShadow"
    shapes.add_clone(shape)

    shape.x += 200
    shadow.preset = slides.PresetShadowType.BOTTOM_RIGHT_DROP_SHADOW
    shadow.direction = 45
    shape.text_frame.text = "BottomRightDropShadow"
    shapes.add_clone(shape)

    shape.x += 200
    shape.effect_format.disable_preset_shadow_effect()
    shape.text_frame.text = "No shadow"

    presentation.save("preset_shadows.pptx", slides.export.SaveFormat.PPTX)
```

| 原始 | 第一个预设 | 第二个预设 | 移除后 |
| :---: | :---: | :---: | :---: |
| ![无阴影](preset_shadow_original.png) | ![左上投影阴影](preset_shadow_top_left.png) | ![右下投影阴影](preset_shadow_bottom_right.png) | ![移除后无阴影](preset_shadow_removed.png) |

## **应用反射效果**

要在 Aspose.Slides for Python via .NET 中应用反射效果，您可以为形状添加类似镜面的反射，并调整距离、透明度和大小等参数。此效果通过为形状提供更光滑、精致的外观来提升演示文稿的美感。使用简单的代码即可轻松实现，并可快速在多个元素之间应用，以实现一致的设计。

下面的 Python 代码展示了如何将[反射效果](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/reflection_effect/)应用于形状：

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 100)
    shape.effect_format.enable_reflection_effect()
    shape.effect_format.reflection_effect.rectangle_align = slides.RectangleAlignment.BOTTOM
    shape.effect_format.reflection_effect.direction = 90
    shape.effect_format.reflection_effect.distance = 40
    shape.effect_format.reflection_effect.blur_radius = 2

    presentation.save("reflection_effect.pptx", slides.export.SaveFormat.PPTX)
```

![反射效果](reflection_effect.png)

## **应用辉光效果**

要在 Aspose.Slides for Python via .NET 中为形状应用辉光效果，您可以在形状周围添加柔和的发光光晕，并调整颜色和大小等属性。此效果有助于突出形状并为演示文稿增添吸引人的视觉元素。实现方法简洁，仅需少量代码即可提升幻灯片的整体外观。

下面的 Python 代码展示了如何将[辉光效果](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/glow_effect/)应用于形状：

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 100)
    shape.effect_format.enable_glow_effect()
    shape.effect_format.glow_effect.color.color = slides.Color.magenta
    shape.effect_format.glow_effect.radius = 15

    presentation.save("glow_effect.pptx", slides.export.SaveFormat.PPTX)
```

![辉光效果](glow_effect.png)

## **应用柔和边缘效果**

要在 Aspose.Slides for Python via .NET 中应用柔和边缘效果，您可以在形状的边缘创建平滑、模糊的过渡。此效果为设计增添更细腻、精致的外观，适用于需要柔和外观的设计。您可以轻松调整半径等参数，以在演示文稿中的各种形状上实现所需效果。

下面的 Python 代码展示了如何将[柔和边缘](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/soft_edge_effect/)应用于形状：

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)
    shape.effect_format.enable_soft_edge_effect()
    shape.effect_format.soft_edge_effect.radius = 8

    presentation.save("soft_edges_effect.pptx", slides.export.SaveFormat.PPTX)
```

![柔和边缘效果](soft_edges_effect.png)

## **应用模糊效果**

使用形状模糊可在保持形状可编辑的同时软化其填充和轮廓。对形状的效果格式调用[set_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/set_blur_effect/)。半径以点为单位（1/72 英寸）：使用非负值，值越大模糊越强。半径为零则保持外观不变。

[grow](https://reference.aspose.com/slides/python-net/aspose.slides.effects/blur/grow/) 设置控制效果的可见边界。`False` 时，模糊被限制在原始绘制边界（包括轮廓）内；`True` 时，模糊可以超出这些边界。两种设置都不会改变形状的位置或尺寸。

下图比较了相同填充、轮廓和形状尺寸下的效果。上排使用 `grow = False`，下排使用 `grow = True`。

![原始矩形与 5 点和 15 点模糊半径的比较，grow 为禁用和启用](shape_blur_comparison.png)

下面的 Python 示例创建了一个橙色矩形，带深蓝色轮廓，先应用 5 点模糊，然后再次调用[set_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/set_blur_effect/)将模糊半径更新为 15 点，并保存两种模糊状态。随后调用[disable_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_blur_effect/)并保存无模糊的形状。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 80, 160, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = slides.Color.orange
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = slides.Color.dark_blue
    shape.line_format.width = 8

    shape.effect_format.set_blur_effect(5, False)
    presentation.save("shape_blur_5.pptx", slides.export.SaveFormat.PPTX)

    shape.effect_format.set_blur_effect(15, True)
    presentation.save("shape_blur_15.pptx", slides.export.SaveFormat.PPTX)

    shape.effect_format.disable_blur_effect()
    presentation.save("shape_blur_removed.pptx", slides.export.SaveFormat.PPTX)
```

形状模糊同时影响填充和轮廓。柔和边缘效果淡化形状的边缘，而阴影模糊仅软化阴影本身。图像转换效果作用于图像内容；本示例直接在形状的效果格式上应用模糊，而不将形状转换为图像。

## **常见问题**

**我可以对同一形状应用多个效果吗？**

是的，您可以在单个形状上组合不同的效果，例如阴影、反射和辉光，以创建更具动感的外观。

**我可以对哪些形状应用效果？**

您可以为各种形状应用效果，包括自动形状、图表、表格、图片、SmartArt 对象、OLE 对象等。

**我可以对组合形状应用效果吗？**

可以，效果将应用于整个组合。