---
title: Применение эффектов фигур в презентациях с помощью Python
linktitle: Эффект фигуры
type: docs
weight: 30
url: /ru/python-net/shape-effect
keywords:
- эффект фигуры
- эффект тени
- эффект отражения
- эффект свечения
- эффект мягких краев
- формат эффекта
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Трансформируйте файлы PPT, PPTX и ODP с помощью продвинутых эффектов фигур, используя Aspose.Slides для Python — создавайте яркие, профессиональные слайды за секунды."
---

Хотя эффекты в PowerPoint можно использовать, чтобы выделить фигуру, они отличаются от [заливки](/slides/ru/python-net/shape-formatting/#gradient-fill) или контуров. Используя эффекты PowerPoint, вы можете создать убедительные отражения на фигуре, распространить её свечение и т.д.

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* PowerPoint предоставляет шесть эффектов, которые можно применить к фигурам. К фигуре можно применить один или несколько эффектов. 

* Некоторые комбинации эффектов выглядят лучше, чем другие. По этой причине PowerPoint предлагает параметры под **Preset**. Параметры Preset представляют собой проверенные комбинации двух и более эффектов. Таким образом, выбирая предустановку, вам не придётся тратить время на тестирование или комбинирование разных эффектов в поисках удачной комбинации.

Aspose.Slides предоставляет свойства и методы в классе [EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/), позволяющие применять те же эффекты к фигурам в презентациях PowerPoint.

## **Применение эффекта тени**

Этот код на Python показывает, как применить внешний эффект тени (`outer_shadow_effect`) к прямоугольнику:

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

## **Применение эффекта отражения**

Этот код на Python показывает, как применить эффект отражения к фигуре:

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

## **Применение эффекта свечения**

Этот код на Python показывает, как применить эффект свечения к фигуре:

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

## **Применение эффекта мягких краев**

Этот код на Python показывает, как применить мягкие края к фигуре:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)

    shape.effect_format.enable_soft_edge_effect()
    shape.effect_format.soft_edge_effect.radius = 15

    pres.save("softEdges.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Можно ли применить несколько эффектов к одной и той же фигуре?**

Да, вы можете комбинировать различные эффекты, такие как тень, отражение и свечение, на одной фигуре, чтобы создать более динамичный вид.

**К каким фигурам можно применять эффекты?**

Эффекты можно применять к различным фигурам, включая автофигуры, диаграммы, таблицы, изображения, объекты SmartArt, OLE‑объекты и другие.

**Можно ли применять эффекты к сгруппированным фигурам?**

Да, эффекты можно применять к сгруппированным фигурам. Эффект будет применён ко всей группе.