---
title: 形状效果
type: docs
weight: 30
url: /python-net/shape-effect
keywords: "形状效果, PowerPoint演示文稿, Python, Aspose.Slides for Python via .NET"
description: "在Python中对PowerPoint形状应用效果"
---

虽然PowerPoint中的效果可以使形状更加突出，但它们与[填充](/slides/python-net/shape-formatting/#gradient-fill)或轮廓不同。通过使用PowerPoint效果，您可以在形状上创建逼真的反射，扩散形状的光晕等。

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* PowerPoint提供六种可以应用于形状的效果。您可以将一种或多种效果应用于形状。

* 某些效果组合的视觉效果优于其他组合。因此，PowerPoint在**预设**下提供了选项。预设选项本质上是两种或多种效果的已知良好组合。通过选择预设，您无需浪费时间测试或组合不同的效果以找到合适的组合。

Aspose.Slides提供了[EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/)类中的属性和方法，使您可以在PowerPoint演示文稿中的形状上应用相同的效果。

## **应用阴影效果**

以下Python代码演示如何在矩形上应用外阴影效果(`outer_shadow_effect`)：

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

以下Python代码演示如何对形状应用反射效果：

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

## **应用光晕效果**

以下Python代码演示如何对形状应用光晕效果：

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

以下Python代码演示如何对形状应用柔和边缘效果：

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)

    shape.effect_format.enable_soft_edge_effect()
    shape.effect_format.soft_edge_effect.radius = 15

    pres.save("softEdges.pptx", slides.export.SaveFormat.PPTX)
```