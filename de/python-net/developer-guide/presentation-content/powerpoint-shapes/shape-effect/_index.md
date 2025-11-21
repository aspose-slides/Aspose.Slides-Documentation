---
title: Shape-Effekte in Präsentationen mit Python anwenden
linktitle: Shape-Effekt
type: docs
weight: 30
url: /de/python-net/shape-effect
keywords:
- Shape-Effekt
- Schatteneffekt
- Reflexionseffekt
- Leuchteffekt
- Weiche Kanten-Effekt
- Effektformat
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Transformieren Sie Ihre PPT-, PPTX- und ODP-Dateien mit erweiterten Shape-Effekten mithilfe von Aspose.Slides für Python – erstellen Sie in Sekunden eindrucksvolle, professionelle Folien."
---

Während Effekte in PowerPoint verwendet werden können, um eine Form hervorzuheben, unterscheiden sie sich von [Füllungen](/slides/de/python-net/shape-formatting/#gradient-fill) oder Umrissen. Mit PowerPoint‑Effekten können Sie überzeugende Spiegelungen einer Form erzeugen, das Leuchten einer Form verbreiten usw.

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* PowerPoint bietet sechs Effekte, die auf Formen angewendet werden können. Sie können einer Form einen oder mehrere Effekte zuweisen. 

* Einige Kombinationen von Effekten sehen besser aus als andere. Aus diesem Grund gibt es in PowerPoint Optionen unter **Preset**. Die Preset‑Optionen sind im Wesentlichen eine bewährte, gut aussehende Kombination von zwei oder mehr Effekten. Auf diese Weise müssen Sie beim Auswählen eines Presets keine Zeit damit verbringen, verschiedene Effekte zu testen oder zu kombinieren, um eine passende Kombination zu finden.

Aspose.Slides stellt Eigenschaften und Methoden in der Klasse [EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/) bereit, mit denen Sie dieselben Effekte auf Formen in PowerPoint‑Präsentationen anwenden können.

## **Schatteneffekt anwenden**

Dieser Python‑Code zeigt, wie Sie den äußeren Schatteneffekt (`outer_shadow_effect`) auf ein Rechteck anwenden:
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

Dieser Python‑Code zeigt, wie Sie den Reflexionseffekt auf eine Form anwenden:
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

Dieser Python‑Code zeigt, wie Sie den Leuchteffekt auf eine Form anwenden:
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


## **Weiche Kanten‑Effekt anwenden**

Dieser Python‑Code zeigt, wie Sie weiche Kanten auf eine Form anwenden:
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

**Kann ich mehrere Effekte auf dieselbe Form anwenden?**

Ja, Sie können verschiedene Effekte, wie Schatten, Reflexion und Leuchten, auf einer einzelnen Form kombinieren, um ein dynamischeres Erscheinungsbild zu erzeugen.

**Auf welche Formen kann ich Effekte anwenden?**

Sie können Effekte auf verschiedene Formen anwenden, einschließlich Autoformen, Diagrammen, Tabellen, Bildern, SmartArt‑Objekten, OLE‑Objekten und mehr.

**Kann ich Effekte auf gruppierte Formen anwenden?**

Ja, Sie können Effekte auf gruppierte Formen anwenden. Der Effekt wird auf die gesamte Gruppe angewendet.