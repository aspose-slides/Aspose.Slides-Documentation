---
title: Formeffekte in Präsentationen mit Python anwenden
linktitle: Formeffekt
type: docs
weight: 30
url: /de/python-net/shape-effect
keywords:
- formeffekt
- schatteneffekt
- reflexionseffekt
- glüheffekt
- weiche kanten effekt
- effektformat
- PowerPoint
- OpenDocument
- präsentation
- Python
- Aspose.Slides
description: "Transformieren Sie Ihre PPT-, PPTX- und ODP-Dateien mit erweiterten Formeffekten mithilfe von Aspose.Slides für Python – erstellen Sie beeindruckende, professionelle Folien in Sekundenschnelle."
---

Während Effekte in PowerPoint verwendet werden können, um eine Form hervorzuheben, unterscheiden sie sich von [Füllungen](/slides/de/python-net/shape-formatting/#gradient-fill) oder Konturen. Mit PowerPoint-Effekten können Sie überzeugende Spiegelungen einer Form erzeugen, den Schein einer Form verbreiten usw.

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* PowerPoint bietet sechs Effekte, die auf Formen angewendet werden können. Sie können einen oder mehrere Effekte auf eine Form anwenden.  
* Einige Effektkombinationen sehen besser aus als andere. Aus diesem Grund gibt es in PowerPoint die Optionen unter **Preset**. Die Preset‑Optionen sind im Wesentlichen eine bewährte Kombination von zwei oder mehr Effekten. Auf diese Weise müssen Sie beim Auswählen eines Presets keine Zeit damit verbringen, verschiedene Effekte zu testen oder zu kombinieren, um eine schöne Kombination zu finden.

Aspose.Slides stellt Eigenschaften und Methoden in der Klasse [EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/) bereit, mit denen Sie dieselben Effekte auf Formen in PowerPoint‑Präsentationen anwenden können.

## **Schatteneffekt anwenden**

Dieses Python‑Beispiel zeigt, wie Sie den äußeren Schatteneffekt (`outer_shadow_effect`) auf ein Rechteck anwenden:

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

Dieses Python‑Beispiel zeigt, wie Sie den Reflexionseffekt auf eine Form anwenden:

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

## **Glüheffekt anwenden**

Dieses Python‑Beispiel zeigt, wie Sie den Glüheffekt auf eine Form anwenden:

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

Dieses Python‑Beispiel zeigt, wie Sie weiche Kanten auf eine Form anwenden:

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

Ja, Sie können verschiedene Effekte wie Schatten, Reflexion und Glühen auf einer einzelnen Form kombinieren, um ein dynamischeres Erscheinungsbild zu erzeugen.

**Auf welche Formen kann ich Effekte anwenden?**

Sie können Effekte auf verschiedene Formen anwenden, einschließlich Autoformen, Diagramme, Tabellen, Bilder, SmartArt‑Objekte, OLE‑Objekte und mehr.

**Kann ich Effekte auf gruppierte Formen anwenden?**

Ja, Sie können Effekte auf gruppierte Formen anwenden. Der Effekt wird dann auf die gesamte Gruppe angewendet.