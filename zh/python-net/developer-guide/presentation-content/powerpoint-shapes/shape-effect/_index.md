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
- 发光效果
- 柔和边缘效果
- 效果格式
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python 将您的 PPT、PPTX 和 ODP 文件通过高级形状效果转换——只需几秒钟即可创建引人注目、专业的幻灯片。"
---

PowerPoint 中的效果可用于突出形状，但它们不同于 [填充](/slides/zh/python-net/shape-formatting/#gradient-fill) 或轮廓。使用 PowerPoint 效果，您可以在形状上创建逼真的反射，扩散形状的发光等。

<img src="shape-effect.png" alt="形状效果" style="zoom:50%;" />

* PowerPoint 提供六种可应用于形状的效果。您可以对形状应用一种或多种效果。 

* 某些效果组合比其他组合更好看。因此，PowerPoint 在 **预设** 下提供选项。预设实际上是两种或多种效果的已知美观组合。这样，选择预设后，您就无需浪费时间测试或组合不同的效果以找到合适的组合。

Aspose.Slides 在 [EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/) 类中提供属性和方法，允许您在 PowerPoint 演示文稿中对形状应用相同的效果。

## **应用阴影效果**

下面的 Python 代码演示如何将外部阴影效果 (`outer_shadow_effect`) 应用于矩形：

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)

    shape.effect_format.enable_outer_shadow_effect()
    shape.effect_format.outer_shadow_effect.shadow_color.color = draw.Color.dark_gray
    shape.effect_format.outer_shadow_effect.distance = 10
    shape.effect_format.outer_shadow_effect.direction = 45

    pres.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **应用反射效果**

下面的 Python 代码演示如何将反射效果应用于形状：

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)

    shape.effect_format.enable_reflection_effect()
    shape.effect_format.reflection_effect.rectangle_align = slides.RectangleAlignment.BOTTOM
    shape.effect_format.reflection_effect.direction = 90
    shape.effect_format.reflection_effect.distance = 55
    shape.effect_format.reflection_effect.blur_radius = 4

    pres.save("reflection.pptx", slides.export.SaveFormat.PPTX)
```

## **应用发光效果**

下面的 Python 代码演示如何将发光效果应用于形状：

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)

    shape.effect_format.enable_glow_effect()
    shape.effect_format.glow_effect.color.color = draw.Color.magenta
    shape.effect_format.glow_effect.radius = 15

    pres.save("glow.pptx", slides.export.SaveFormat.PPTX)
```

## **应用柔和边缘效果**

下面的 Python 代码演示如何将柔和边缘效果应用于形状：

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)

    shape.effect_format.enable_soft_edge_effect()
    shape.effect_format.soft_edge_effect.radius = 15

    pres.save("softEdges.pptx", slides.export.SaveFormat.PPTX)
```

## **常见问题**

**可以对同一个形状应用多个效果吗？**

可以，您可以在同一形状上组合不同的效果，例如阴影、反射和发光，以实现更具动感的外观。

**可以对哪些形状应用效果？**

您可以对多种形状应用效果，包括自动形状、图表、表格、图片、SmartArt 对象、OLE 对象等。

**可以对组合形状应用效果吗？**

可以，您可以对组合形状应用效果。该效果将应用于整个组合。