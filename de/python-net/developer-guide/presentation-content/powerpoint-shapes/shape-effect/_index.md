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
- Weiche Kanten Effekt
- Effektformat
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Transformieren Sie Ihre PPT-, PPTX- und ODP-Dateien mit erweiterten Shape-Effekten mithilfe von Aspose.Slides für Python — erstellen Sie in Sekunden eindrucksvolle, professionelle Folien."
---
## **Einleitung**

Während Effekte in PowerPoint verwendet werden können, um eine Form hervorzuheben, unterscheiden sie sich von [Füllungen](/slides/de/python-net/shape-formatting/#gradient-fill) oder Konturen. Mit PowerPoint‑Effekten können Sie überzeugende Spiegelungen einer Form erzeugen, das Leuchten einer Form verbreiten usw.

![Formeffekt](shape-effect.png)

PowerPoint bietet sechs Effekte, die auf Formen angewendet werden können. Sie können einer Form einen oder mehrere Effekte zuweisen.

Einige Kombinationen von Effekten sehen besser aus als andere. Aus diesem Grund bietet PowerPoint Optionen unter **Preset**. Die Preset‑Optionen sind im Wesentlichen eine bekannte, gut aussehende Kombination aus zwei oder mehr Effekten. Auf diese Weise müssen Sie durch Auswahl eines Presets keine Zeit damit verbringen, verschiedene Effekte zu testen oder zu kombinieren, um eine schöne Kombination zu finden.

Aspose.Slides stellt Eigenschaften und Methoden der Klasse [EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/) bereit, mit denen Sie dieselben Effekte auf Formen in PowerPoint‑Präsentationen anwenden können.

## **Schatteneffekt anwenden**

Aspose.Slides für Python via .NET unterstützt äußere und innere Schatten für Formen. Sie können deren Farbe, Richtung, Abstand und Weichzeichnungsradius an das Design Ihrer Präsentation anpassen.

### **Äußeren Schatten anwenden**

Verwenden Sie einen äußeren Schatten, um eine Karte oder ein Panel gegenüber dem Folienhintergrund hervorzuheben. Der Schatten erstreckt sich über die Kanten der Form hinaus und erzeugt den Eindruck, dass die Form über die Folie gehoben ist. Passen Sie Farbe, Richtung, Abstand und Weichzeichnungsradius an die Beleuchtung und das Styling Ihrer Vorlage an.

Dieser Python‑Code zeigt, wie man den [äußerer Schatteneffekt](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/outer_shadow_effect/) auf ein Rechteck anwendet:

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

![Schatteneffekt](shadow_effect.png)

### **Inneren Schatten anwenden**

Wenn Sie das visuelle Styling einer Vorlage reproduzieren, verwenden Sie einen inneren Schatten, um einer Karte oder einem Panel ein vertieftes Aussehen zu verleihen. Ein äußerer Schatten erstreckt sich außerhalb der Form und lässt sie erhöht wirken, während ein innerer Schatten die Innenseiten ihrer Kanten abdunkelt.

Rufen Sie [enable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/enable_inner_shadow_effect/) auf und konfigurieren Sie anschließend [inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/inner_shadow_effect/). Größere Weichzeichnungsradius‑Werte erzeugen weichere Kanten.

Dieses Python‑Beispiel erstellt eine hellblaue Karte mit einem dunkelgrauen inneren Schatten und speichert sie als PPTX‑Datei:

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

![Hellblaues Rechteck mit innerem Schatten](inner_shadow_effect.png)

Um den inneren Schatten zu entfernen, rufen Sie [disable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_inner_shadow_effect/) im Effektformat der Form auf.

## **Reflexionseffekt anwenden**

Um in Aspose.Slides für Python via .NET einen Reflexionseffekt anzuwenden, können Sie Formen eine spiegelähnliche Reflexion hinzufügen und Parameter wie Abstand, Transparenz und Größe anpassen. Dieser Effekt verbessert die Ästhetik Ihrer Präsentationen, indem er Formen ein polierteres und anspruchsvolleres Aussehen verleiht. Er lässt sich mit einfachem Code leicht implementieren und ermöglicht eine schnelle Anwendung auf mehrere Elemente für ein konsistentes Design.

Dieser Python‑Code zeigt, wie man den [Reflexionseffekt](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/reflection_effect/) auf eine Form anwendet:

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

![Reflexionseffekt](reflection_effect.png)

## **Leuchteffekt anwenden**

Um in Aspose.Slides für Python via .NET einen Leuchteffekt auf eine Form anzuwenden, können Sie eine weiche, leuchtende Aura um die Formen hinzufügen und Eigenschaften wie Farbe und Größe anpassen. Dieser Effekt hilft, Formen hervorzuheben und verleiht Ihrer Präsentation ein attraktives, auffälliges visuelles Element. Er lässt sich mit minimalem Code leicht implementieren und verbessert das Gesamterscheinungsbild Ihrer Folien.

Dieser Python‑Code zeigt, wie man den [Leuchteffekt](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/glow_effect/) auf eine Form anwendet:

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

![Leuchteffekt](glow_effect.png)

## **Weiche Kanten Effekt anwenden**

Um in Aspose.Slides für Python via .NET einen Weiche‑Kanten‑Effekt anzuwenden, können Sie eine sanfte, unscharfe Übergangszone um die Kanten einer Form erstellen. Dieser Effekt verleiht ein subtileres und raffinierteres Aussehen, ideal für Designs, die ein sanftes, weicheres Erscheinungsbild benötigen. Sie können Parameter wie den Radius problemlos anpassen, um den gewünschten Effekt auf verschiedene Formen in Ihrer Präsentation zu erzielen.

Dieser Python‑Code zeigt, wie man die [Weichen Kanten](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/soft_edge_effect/) auf eine Form anwendet:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)
    shape.effect_format.enable_soft_edge_effect()
    shape.effect_format.soft_edge_effect.radius = 8

    presentation.save("soft_edges_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Weiche Kanten Effekt](soft_edges_effect.png)

## **Weichzeichner-Effekt anwenden**

Verwenden Sie Formen‑Weichzeichnung, um Füllung und Kontur einer Form zu verwischen, während die Form editierbar bleibt. Rufen Sie [set_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/set_blur_effect/) im Effektformat der Form auf. Der Radius wird in Punkten (1/72 Zoll) gemessen: Verwenden Sie einen nicht‑negativen Wert, wobei größere Werte eine stärkere Unschärfe erzeugen. Ein Radius von Null lässt das Aussehen unverändert.

Die [grow](https://reference.aspose.com/slides/python-net/aspose.slides.effects/blur/grow/) Einstellung steuert die sichtbaren Grenzen des Effekts. Bei `False` wird die Unschärfe auf die ursprünglich gemalten Grenzen, einschließlich der Kontur, zugeschnitten. Bei `True` kann die Unschärfe über diese Grenzen hinausreichen. Keine der Einstellungen ändert die Position oder Dimensionen der Form.

Der nachstehende Vergleich verwendet durchgehend dieselbe Füllung, Kontur und Formabmessungen. Die obere Zeile verwendet `grow = False`; die untere Zeile verwendet `grow = True`.

![Originales Rechteck im Vergleich mit Unschärferadien von 5 und 15 Punkten, bei deaktiviertem und aktiviertem grow](shape_blur_comparison.png)

Dieses Python‑Beispiel erstellt ein orangefarbenes Rechteck mit einer dunkelblauen Kontur, wendet eine Unschärfe von 5 Punkten an und aktualisiert es anschließend auf eine Unschärfe von 15 Punkten, indem es erneut [set_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/set_blur_effect/) aufruft. Es speichert beide unscharfen Zustände, ruft dann [disable_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_blur_effect/) auf und speichert die Form ohne Unschärfe.

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

Form‑Unschärfe wirkt sich gleichzeitig auf Füllung und Kontur aus. Ein Weiche‑Kanten‑Effekt verblasst die Kanten der Form, während Schatten‑Unschärfe nur den Schatten weicher macht. Bild‑Transformations‑Effekte wirken auf den Bildinhalt; dieses Beispiel wendet die Unschärfe direkt auf das Effektformat der Form an, ohne die Form in ein Bild zu konvertieren.

## **FAQ**

**Kann ich mehrere Effekte auf dieselbe Form anwenden?**

Ja, Sie können verschiedene Effekte, wie Schatten, Reflexion und Leuchteffekt, auf einer einzelnen Form kombinieren, um ein dynamischeres Aussehen zu erzeugen.

**Auf welche Formen kann ich Effekte anwenden?**

Sie können Effekte auf verschiedene Formen anwenden, einschließlich Autoformen, Diagrammen, Tabellen, Bildern, SmartArt‑Objekten, OLE‑Objekten und mehr.

**Kann ich Effekte auf gruppierte Formen anwenden?**

Ja, Sie können Effekte auf gruppierte Formen anwenden. Der Effekt wird auf die gesamte Gruppe angewendet.