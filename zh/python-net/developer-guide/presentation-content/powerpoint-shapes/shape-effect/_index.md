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
- 光晕效果
- 柔化边缘效果
- 效果格式
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python 将 PPT、PPTX 和 ODP 文件转换为高级形状效果——在几秒钟内创建引人注目、专业的幻灯片。"
---
## **简介**

在 PowerPoint 中，效果可用于突出显示形状，但它们不同于 [填充](/slides/zh/python-net/shape-formatting/#gradient-fill) 或轮廓。使用 PowerPoint 效果，您可以在形状上创建逼真的反射、扩散形状的光晕等。

![形状效果](shape-effect.png)

PowerPoint 提供六种可应用于形状的效果。您可以对形状应用一种或多种效果。

某些效果组合比其他组合更好看。为此，PowerPoint 在 **预设** 下提供选项。预设选项本质上是两种或多种效果的已知好看组合。这样，选择预设后，您无需花时间测试或组合不同的效果来找到合适的组合。

Aspose.Slides 在 [EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/) 类中提供属性和方法，允许您在 PowerPoint 演示文稿中对形状应用相同的效果。

## **应用阴影效果**

Aspose.Slides for Python via .NET 支持形状的外部和内部阴影。您可以自定义其颜色、方向、距离和模糊半径，以匹配演示文稿的设计。

### **应用外部阴影**

使用外部阴影使卡片或面板在幻灯片背景上更突出。阴影延伸到形状边缘之外，营造形状悬浮在幻灯片上的感觉。调整其颜色、方向、距离和模糊半径，以匹配模板的光照和样式。

此 Python 代码演示如何对矩形应用 [外部阴影效果](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/outer_shadow_effect/)：

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

在复现模板的视觉样式时，使用内部阴影为卡片或面板提供凹陷外观。外部阴影延伸到形状外部，使其看起来凸起，而内部阴影则给边缘内部着色。

调用 [enable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/enable_inner_shadow_effect/)，然后配置 [inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/inner_shadow_effect/)。更大的模糊半径值会产生更柔和的边缘。

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

要移除内部阴影，请在形状的 EffectFormat 上调用 [disable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_inner_shadow_effect/)。

## **应用反射效果**

要在 Aspose.Slides for Python via .NET 中应用反射效果，您可以为形状添加类似镜面的反射，并调整距离、透明度和大小等参数。此效果通过为形状提供更精致、专业的外观来提升演示文稿的美感。使用简短代码即可轻松实现，可快速在多个元素上统一应用，实现一致的设计。

此 Python 代码演示如何对形状应用 [reflection effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/reflection_effect/)：

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

## **应用光晕效果**

要在 Aspose.Slides for Python via .NET 中对形状应用光晕效果，您可以在形状周围添加柔和的发光光环，并调整颜色和大小等属性。此效果帮助形状突出显示，并为您的演示文稿增添吸引人的视觉元素。实现起来代码极少，可提升整体幻灯片外观。

此 Python 代码演示如何对形状应用 [glow effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/glow_effect/)：

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

![光晕效果](glow_effect.png)

## **应用柔化边缘效果**

在 Aspose.Slides for Python via .NET 中应用柔化边缘效果，您可以在形状的边缘周围创建平滑、模糊的过渡。此效果增添更细腻、精致的外观，适用于需要柔和外观的设计。您可以轻松调整半径等参数，以在演示文稿中的各种形状上实现期望的效果。

此 Python 代码演示如何对形状应用 [柔化边缘](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/soft_edge_effect/)：

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

使用形状模糊可在保持形状可编辑的前提下柔化其填充和轮廓。调用 [set_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/set_blur_effect/) 在形状的 EffectFormat 上。半径以点为单位（1/72 英寸）：使用非负值，较大值产生更强的模糊。半径为零则保持外观不变。

[Grow](https://reference.aspose.com/slides/python-net/aspose.slides.effects/blur/grow/) 设置控制效果的可见范围。设为 `False` 时，模糊被裁剪到原始绘制范围（包括轮廓）。设为 `True` 时，模糊可以超出该范围。两种设置均不会改变形状的位置或尺寸。

下面的比较使用了相同的填充、轮廓和形状尺寸。顶部行使用 `grow = False`；底部行使用 `grow = True`。

![原始矩形与模糊半径为 5 和 15 点的比较，grow 为关闭和开启状态](shape_blur_comparison.png)

此 Python 示例创建一个橙色矩形，带深蓝色轮廓，先应用 5 点模糊，然后再次调用 [set_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/set_blur_effect/) 将模糊提升至 15 点。它保存了两个模糊状态，然后调用 [disable_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_blur_effect/) 并保存无模糊的形状。

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

形状模糊同时影响填充和轮廓。柔化边缘效果淡化形状的边缘，而阴影模糊仅软化阴影。图像变换效果作用于图像内容；本例直接在形状的 EffectFormat 上应用模糊，而不将形状转换为图像。

## **常见问题**

**我可以对同一形状应用多个效果吗？**

是的，您可以在单个形状上组合不同的效果，如阴影、反射和光晕，以创建更具动感的外观。

**我可以对哪些形状应用效果？**

您可以对各种形状应用效果，包括自动形状、图表、表格、图片、SmartArt 对象、OLE 对象等。

**我可以对组合形状应用效果吗？**

可以，您可以对组合形状应用效果。效果将作用于整个组合。