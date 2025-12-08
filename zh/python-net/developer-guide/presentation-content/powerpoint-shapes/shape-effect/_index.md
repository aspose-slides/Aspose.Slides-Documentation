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
- 柔化边缘效果
- 效果格式
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python 将您的 PPT、PPTX 和 ODP 文件转化为高级形状效果——在几秒钟内创建引人注目、专业的幻灯片。"
---

虽然 PowerPoint 中的效果可用于让形状突出显示，但它们不同于 [fills](/slides/zh/python-net/shape-formatting/#gradient-fill) 或轮廓。使用 PowerPoint 效果，您可以在形状上创建逼真的反射、扩散形状的辉光等。

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* PowerPoint 提供六种可应用于形状的效果。您可以对一个形状应用一个或多个效果。 

* 某些效果组合比其他组合更好看。出于此原因，PowerPoint 在 **Preset** 下提供选项。Preset 选项本质上是两种或多种效果的已知美观组合。这样，选择预设后，您无需浪费时间测试或组合不同的效果来寻找合适的组合。

Aspose.Slides 在 [EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/) 类下提供属性和方法，允许您在 PowerPoint 演示文稿中对形状应用相同的效果。

## **应用阴影效果**

以下 Python 代码演示如何对矩形应用外部阴影效果（`outer_shadow_effect`）：
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

以下 Python 代码演示如何对形状应用反射效果：
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


## **应用辉光效果**

以下 Python 代码演示如何对形状应用辉光效果：
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


## **应用柔化边缘效果**

以下 Python 代码演示如何对形状应用柔化边缘效果：
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

**我可以对同一形状应用多个效果吗？**

是的，您可以在同一个形状上组合不同的效果，例如阴影、反射和辉光，以创建更具动感的外观。

**我可以对哪些形状应用效果？**

您可以对各种形状应用效果，包括自动形状、图表、表格、图片、SmartArt 对象、OLE 对象等。

**我可以对组合形状应用效果吗？**

是的，您可以对组合形状应用效果。效果将应用于整个组合。