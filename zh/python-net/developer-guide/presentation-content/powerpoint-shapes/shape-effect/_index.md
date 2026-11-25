---
title: 在演示文稿中使用 Python 应用形状效果
linktitle: 形状效果
type: docs
weight: 30
url: /zh/python-net/shape-effect
keywords:
- 形状效果
- 阴影效果
- 反射效果
- 发光效果
- 柔化边缘效果
- 效果格式
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python 将高级形状效果应用于您的 PPT、PPTX 和 ODP 文件——几秒钟内创建惊艳、专业的幻灯片。"
---
## **介绍**

虽然 PowerPoint 中的效果可用于让形状突出，但它们不同于 [填充](/slides/zh/python-net/shape-formatting/#gradient-fill) 或轮廓。使用 PowerPoint 效果，您可以在形状上创建逼真的反射、扩展形状的发光等。

![形状效果](shape-effect.png)

PowerPoint 提供六种可应用于形状的效果。您可以对一个形状应用一个或多个效果。

某些效果组合看起来比其他组合更好。因此，PowerPoint 在 **Preset** 下提供选项。Preset 选项本质上是一组已知的好看组合，两种或多种效果的组合。通过选择预设，您无需花时间测试或组合不同的效果来寻找合适的组合。

Aspose.Slides 在 [EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/) 类下提供属性和方法，允许您在 PowerPoint 演示文稿中对形状应用相同的效果。

## **应用阴影效果**

Aspose.Slides for Python via .NET 支持形状的外部和内部阴影。您可以自定义它们的颜色、方向、距离和模糊半径，以匹配演示文稿的设计。

### **应用外部阴影**

使用外部阴影使卡片或面板在幻灯片背景下突出。阴影延伸超出形状的边缘，营造形状在幻灯片上方的提升感。调整其颜色、方向、距离和模糊半径，以匹配模板的光照和样式。

此 Python 代码展示了如何将 [外部阴影效果](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/outer_shadow_effect/) 应用于矩形：

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

### **应用内部阴影**

在复制模板的视觉样式时，使用内部阴影为卡片或面板提供凹陷外观。外部阴影向形状外部延伸，使其看起来凸起，而内部阴影则在其边缘内部着色。调用 [enable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/enable_inner_shadow_effect/)，然后配置 [inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/inner_shadow_effect/)。较大的模糊半径值会产生更柔和的边缘。

此 Python 示例创建一个浅蓝色卡片，带深灰色内部阴影，并将其保存为 PPTX 文件：

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

要移除内部阴影，请对形状的 EffectFormat 调用 [disable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_inner_shadow_effect/)。

### **应用、更改和移除预设阴影**

调用 [enable_preset_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/enable_preset_shadow_effect/) 并将阴影的 [预设](https://reference.aspose.com/slides/python-net/aspose.slides.effects/presetshadow/preset/) 属性设置为 [PresetShadowType](https://reference.aspose.com/slides/python-net/aspose.slides/presetshadowtype/) 值。要切换样式，可在同一形状上更改预设。调用 [disable_preset_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_preset_shadow_effect/) 可在保留填充和轮廓的同时移除阴影。

此示例在一张幻灯片上并排显示四个阶段。它在每次更改前克隆矩形，以便您比较结果。两个阴影均偏移 10 点。225° 的方向使第一个阴影位于矩形的上方左侧，45° 的方向使第二个阴影位于右下方。

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

要在 Aspose.Slides for Python via .NET 中应用反射效果，您可以向形状添加镜面反射，调整距离、透明度和大小等参数。此效果通过提供更光滑、更精致的外观来提升演示文稿的美感。实现简单，只需少量代码即可在多个元素上快速应用，实现一致的设计。

此 Python 代码展示了如何将 [反射效果](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/reflection_effect/) 应用于形状：

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

## **应用发光效果**

要在 Aspose.Slides for Python via .NET 中对形状应用发光效果，您可以在形状周围添加柔和的光晕，调整颜色和大小等属性。此效果有助于使形状突出，并为演示文稿添加吸引人的视觉元素。实现简便，仅需少量代码，即可提升幻灯片的整体外观。

此 Python 代码展示了如何将 [发光效果](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/glow_effect/) 应用于形状：

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

![发光效果](glow_effect.png)

## **应用柔化边缘效果**

要在 Aspose.Slides for Python via .NET 中应用柔化边缘效果，您可以在形状的边缘周围创建平滑、模糊的过渡。此效果提供更细腻、精致的外观，适用于需要柔和外观的设计。您可以轻松调整半径等参数，以在演示文稿中的各种形状上实现所需效果。

此 Python 代码展示了如何将 [柔化边缘](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/soft_edge_effect/) 应用于形状：

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)
    shape.effect_format.enable_soft_edge_effect()
    shape.effect_format.soft_edge_effect.radius = 8

    presentation.save("soft_edges_effect.pptx", slides.export.SaveFormat.PPTX)
```

![柔化边缘效果](soft_edges_effect.png)

## **应用模糊效果**

使用形状模糊可以在保持形状可编辑的同时柔化形状的填充和轮廓。对形状的 EffectFormat 调用 [set_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/set_blur_effect/)。半径以点（1/72 英寸）为单位：使用非负值，较大的值会产生更强的模糊。半径为零时外观保持不变。

[ grow](https://reference.aspose.com/slides/python-net/aspose.slides.effects/blur/grow/) 设置控制效果的可见范围。设置为 `False` 时，模糊被裁剪到原始绘制范围（包括轮廓）。设置为 `True` 时，模糊可超出该范围。两种设置均不改变形状的位置或尺寸。

下面的比较使用了相同的填充、轮廓和形状尺寸。上排使用 `grow = False`；下排使用 `grow = True`。

![原始矩形与模糊半径为 5 和 15 点的比较，分别在禁用和启用 grow 情况下](shape_blur_comparison.png)

此 Python 示例创建一个橙色矩形，带深蓝色轮廓，先应用 5 点模糊，然后再次调用 [set_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/set_blur_effect/) 将模糊半径改为 15 点。它保存了两种模糊状态，然后调用 [disable_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_blur_effect/) 保存无模糊的形状。

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

形状模糊同时影响填充和轮廓。柔化边缘效果仅淡化形状的边缘，而阴影模糊仅软化阴影。图像转换效果作用于图像内容；本例直接对形状的 EffectFormat 应用模糊，无需将形状转换为图像。

## **常见问题**

**我可以对同一个形状应用多个效果吗？**

是的，您可以在单个形状上组合不同的效果，如阴影、反射和发光，以获得更具动感的外观。

**我可以对哪些形状应用效果？**

您可以对包括自动形状、图表、表格、图片、SmartArt 对象、OLE 对象等在内的各种形状应用效果。

**我可以对组合形状应用效果吗？**

是的，您可以对组合形状应用效果。该效果将作用于整个组合。