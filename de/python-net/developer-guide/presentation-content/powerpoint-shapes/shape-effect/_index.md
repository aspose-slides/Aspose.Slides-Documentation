---
title: Formeffekt
type: docs
weight: 30
url: /de/python-net/shape-effect
keywords: "Formeffekt, PowerPoint-Präsentation, Python, Aspose.Slides für Python über .NET"
description: "Wenden Sie Effekte auf PowerPoint-Formen in Python an"
---

Während Effekte in PowerPoint verwendet werden können, um eine Form hervorzuheben, unterscheiden sie sich von [Füllungen](/slides/de/python-net/shape-formatting/#gradient-fill) oder Umrandungen. Mit PowerPoint-Effekten können Sie überzeugende Reflexionen auf einer Form erstellen, den Glanz einer Form verbreiten usw.

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* PowerPoint bietet sechs Effekte, die auf Formen angewendet werden können. Sie können ein oder mehrere Effekte auf eine Form anwenden.

* Einige Kombinationen von Effekten sehen besser aus als andere. Aus diesem Grund gibt es in PowerPoint Optionen unter **Vorgabe**. Die Vorgabeoptionen sind im Wesentlichen eine bekannte, ansprechend aussehende Kombination aus zwei oder mehr Effekten. So müssen Sie beim Auswählen einer Vorgabe keine Zeit mit dem Testen oder Kombinieren verschiedener Effekte verschwenden, um eine schöne Kombination zu finden.

Aspose.Slides bietet Eigenschaften und Methoden unter der [EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/) Klasse, die es Ihnen ermöglichen, dieselben Effekte auf Formen in PowerPoint-Präsentationen anzuwenden.

## **Schatten-Effekt anwenden**

Dieser Python-Code zeigt Ihnen, wie Sie den äußeren Schatteneffekt (`outer_shadow_effect`) auf ein Rechteck anwenden:

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

## **Reflexionseffekt anwenden**

Dieser Python-Code zeigt Ihnen, wie Sie den Reflexionseffekt auf eine Form anwenden:

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

## **Leuchteffekt anwenden**

Dieser Python-Code zeigt Ihnen, wie Sie den Leuchteffekt auf eine Form anwenden:

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

## **Weiche Kanten-Effekt anwenden**

Dieser Python-Code zeigt Ihnen, wie Sie die weichen Kanten auf eine Form anwenden:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)

    shape.effect_format.enable_soft_edge_effect()
    shape.effect_format.soft_edge_effect.radius = 15

    pres.save("softEdges.pptx", slides.export.SaveFormat.PPTX)
```