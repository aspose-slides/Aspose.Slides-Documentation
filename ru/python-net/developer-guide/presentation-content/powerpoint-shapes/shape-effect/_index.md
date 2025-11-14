---
title: Эффект формы
type: docs
weight: 30
url: /ru/python-net/shape-effect
keywords: "Эффект формы, презентация PowerPoint, Python, Aspose.Slides для Python через .NET"
description: "Применить эффект к форме PowerPoint в Python"
---

Хотя эффекты в PowerPoint могут использоваться для того, чтобы выделить форму, они отличаются от [заливок](/slides/ru/python-net/shape-formatting/#gradient-fill) или контуров. Используя эффекты PowerPoint, вы можете создать убедительные отражения на форме, распространить свечение формы и т. д.

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* PowerPoint предоставляет шесть эффектов, которые можно применить к формам. Вы можете применить один или несколько эффектов к форме.

* Некоторые комбинации эффектов выглядят лучше, чем другие. По этой причине PowerPoint предлагает параметры под **Предустановки**. Параметры предустановок представляют собой известную хорошо выглядящую комбинацию двух или более эффектов. Таким образом, выбрав предустановку, вы не потратите время на тестирование или комбинирование различных эффектов в поисках красивой комбинации.

Aspose.Slides предоставляет свойства и методы в классе [EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/), которые позволяют применять одни и те же эффекты к формам в презентациях PowerPoint.

## **Применить эффект тени**

Этот код на Python показывает, как применить эффект внешней тени (`outer_shadow_effect`) к прямоугольнику:

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

## **Применить эффект отражения**

Этот код на Python показывает, как применить эффект отражения к форме:

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

## **Применить эффект свечения**

Этот код на Python показывает, как применить эффект свечения к форме:

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

## **Применить эффект мягких краев**

Этот код на Python показывает, как применить эффект мягких краев к форме:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)

    shape.effect_format.enable_soft_edge_effect()
    shape.effect_format.soft_edge_effect.radius = 15

    pres.save("softEdges.pptx", slides.export.SaveFormat.PPTX)
```