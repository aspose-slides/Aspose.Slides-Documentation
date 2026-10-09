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
- 柔和边缘效果
- 效果格式
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python，将您的 PPT、PPTX 和 ODP 文件转换为高级形状效果——在几秒钟内创建醒目、专业的幻灯片。"
---
## **介绍**

虽然 PowerPoint 中的效果可以用于让形状突出，但它们不同于 [填充](/slides/zh/python-net/shape-formatting/#gradient-fill) 或轮廓。使用 PowerPoint 效果，您可以在形状上创建逼真的反射，扩展形状的发光等。

![形状效果](shape-effect.png)

PowerPoint 提供六种可应用于形状的效果。您可以对一个形状应用一个或多个效果。

某些效果组合看起来比其他组合更好。因此，PowerPoint 在 **预设** 下提供选项。预设 选项本质上是两个或多个效果的已知好看组合。这样，选择预设后，您就不必浪费时间测试或组合不同的效果来寻找合适的组合。

Aspose.Slides 在 [EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/) 类下提供属性和方法，允许您在 PowerPoint 演示文稿中对形状应用相同的效果。

## **应用阴影效果**

Aspose.Slides for Python via .NET 支持形状的外部和内部阴影。您可以自定义其颜色、方向、距离和模糊半径，以匹配演示文稿的设计。

### **应用外部阴影**

使用外部阴影可以使卡片或面板在幻灯片背景上突出。阴影延伸至形状边缘之外，产生形状悬浮于幻灯片上的感觉。调整其颜色、方向、距离和模糊半径，以匹配模板的光照和样式。

以下 Python 代码演示如何将 [外部阴影效果](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/outer_shadow_effect/) 应用于矩形：

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 100)
    shape.effect_format.enable_outer_shadow_effect()
    shape.effect_format.outer_shadow_effect.shadow_color.color = draw.Color.dark_gray
    shape.effect_format.outer_shadow_effect.distance = 10
    shape.effect_format.outer_shadow_effect.direction = 45

    presentation.save("shadow_effect.pptx", slides.export.SaveFormat.PPTX)
```

![阴影效果](shadow_effect.png)

### **应用内部阴影**

在复现模板的视觉样式时，可使用内部阴影为卡片或面板提供凹陷外观。外部阴影延伸至形状之外，使其看起来凸起，而内部阴影则在其边缘内部投射阴影。

调用 [enable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/enable_inner_shadow_effect/)，然后配置 [inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/inner_shadow_effect/)。更大的模糊半径值会产生更柔和的边缘。

以下 Python 示例创建一个浅蓝色卡片，带有深灰色内部阴影，并将其保存为 PPTX 文件：

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.light_blue
    shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    shape.effect_format.enable_inner_shadow_effect()
    shadow = shape.effect_format.inner_shadow_effect
    shadow.shadow_color.color = draw.Color.dim_gray
    shadow.direction = 225
    shadow.distance = 7
    shadow.blur_radius = 6

    presentation.save("inner_shadow_effect.pptx", slides.export.SaveFormat.PPTX)
```

![带内部阴影的浅蓝色矩形](inner_shadow_effect.png)

要移除内部阴影，请在形状的 effect format 上调用 [disable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_inner_shadow_effect/)。

## **应用反射效果**

要在 Aspose.Slides for Python via .NET 中应用反射效果，您可以为形状添加类似镜面的反射，并调整距离、透明度和大小等参数。此效果通过为形状提供更精致、专业的外观，提升演示文稿的美感。它易于使用简洁代码实现，可快速在多个元素间应用，以实现一致的设计。

以下 Python 代码演示如何将 [反射效果](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/reflection_effect/) 应用于形状：

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

要在 Aspose.Slides for Python via .NET 中为形状应用发光效果，您可以在形状周围添加柔和的光晕，并调整颜色和大小等属性。此效果有助于突出形状，并为演示文稿增添吸引人的视觉元素。它只需少量代码即可实现，提升幻灯片的整体外观。

以下 Python 代码演示如何将 [发光效果](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/glow_effect/) 应用于形状：

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 100)
    shape.effect_format.enable_glow_effect()
    shape.effect_format.glow_effect.color.color = draw.Color.magenta
    shape.effect_format.glow_effect.radius = 15

    presentation.save("glow_effect.pptx", slides.export.SaveFormat.PPTX)
```

![发光效果](glow_effect.png)

## **应用柔和边缘效果**

要在 Aspose.Slides for Python via .NET 中应用柔和边缘效果，您可以在形状的边缘创建平滑、模糊的过渡。此效果增加更细腻、精致的外观，适用于需要柔和外观的设计。您可以轻松调整半径等参数，以在演示文稿中的各种形状上实现所需效果。

以下 Python 代码演示如何将 [柔和边缘](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/soft_edge_effect/) 应用于形状：

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

## **常见问题**

**我可以对同一形状应用多个效果吗？**

是的，您可以在单个形状上组合不同的效果，如阴影、反射和发光，以实现更具动感的外观。

**我可以对哪些形状应用效果？**

您可以对多种形状应用效果，包括自动形状、图表、表格、图片、SmartArt 对象、OLE 对象等。

**我可以对组合形状应用效果吗？**

是的，您可以对组合形状应用效果。该效果会应用于整个组合。