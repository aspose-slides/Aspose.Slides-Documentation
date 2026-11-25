---
title: Formeffekte in Präsentationen mit Python anwenden
linktitle: Formeffekt
type: docs
weight: 30
url: /de/python-net/shape-effect
keywords:
- Formeffekt
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
description: "Transformieren Sie Ihre PPT-, PPTX- und ODP-Dateien mit erweiterten Formeffekten mithilfe von Aspose.Slides für Python – erstellen Sie innerhalb von Sekunden eindrucksvolle, professionelle Folien."
---
## **Einleitung**

Während Effekte in PowerPoint verwendet werden können, um eine Form hervorzuheben, unterscheiden sie sich von [Füllungen](/slides/de/python-net/shape-formatting/#gradient-fill) oder Konturen. Mit PowerPoint‑Effekten können Sie überzeugende Spiegelungen einer Form erzeugen, das Leuchten einer Form verbreiten usw.

![Formeffekt](shape-effect.png)

PowerPoint bietet sechs Effekte, die auf Formen angewendet werden können. Sie können ein oder mehrere Effekte auf eine Form anwenden.

Einige Kombinationen von Effekten sehen besser aus als andere. Aus diesem Grund bietet PowerPoint Optionen unter **Voreinstellung**. Die Voreinstellungsoptionen sind im Wesentlichen eine bewährte, gut aussehende Kombination aus zwei oder mehr Effekten. Auf diese Weise müssen Sie bei Auswahl einer Voreinstellung keine Zeit damit verschwenden, verschiedene Effekte zu testen oder zu kombinieren, um eine passende Kombination zu finden.

Aspose.Slides stellt Eigenschaften und Methoden in der Klasse [EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/) bereit, die es Ihnen ermöglichen, dieselben Effekte auf Formen in PowerPoint‑Präsentationen anzuwenden.

## **Schatteneffekt anwenden**

Aspose.Slides für Python via .NET unterstützt äußere und innere Schatten für Formen. Sie können deren Farbe, Richtung, Abstand und Unschärferadius an das Design Ihrer Präsentation anpassen.

### **Äußeren Schatten anwenden**

Verwenden Sie einen äußeren Schatten, um eine Karte oder ein Panel gegenüber dem Folienhintergrund hervorzuheben. Der Schatten erstreckt sich über die Kanten der Form hinaus und erzeugt den Eindruck, dass die Form über der Folie schwebt. Passen Sie Farbe, Richtung, Abstand und Unschärferadius an die Beleuchtung und das Design Ihrer Vorlage an.

Dieser Python‑Code zeigt, wie man den [Außen‑Schatten‑Effekt](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/outer_shadow_effect/) auf ein Rechteck anwendet:

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

Wenn Sie das visuelle Design einer Vorlage nachbilden, verwenden Sie einen inneren Schatten, um einer Karte oder einem Panel ein vertieftes Erscheinungsbild zu verleihen. Ein äußerer Schatten erstreckt sich außerhalb der Form und lässt sie erhöht erscheinen, während ein innerer Schatten die Innenseite ihrer Kanten abschattet.

Rufen Sie [enable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/enable_inner_shadow_effect/) auf und konfigurieren Sie anschließend [inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/inner_shadow_effect/). Größere Unschärferadiuswerte erzeugen weichere Kanten.

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

Um den inneren Schatten zu entfernen, rufen Sie [disable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_inner_shadow_effect/) im EffectFormat der Form auf.

### **Voreinstellungs‑Schatten anwenden, ändern und entfernen**

Rufen Sie [enable_preset_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/enable_preset_shadow_effect/) auf und setzen Sie die [preset](https://reference.aspose.com/slides/python-net/aspose.slides.effects/presetshadow/preset/)‑Eigenschaft des Schattens auf einen Wert vom Typ [PresetShadowType](https://reference.aspose.com/slides/python-net/aspose.slides/presetshadowtype/). Um den Stil zu wechseln, ändern Sie die Voreinstellung bei derselben Form. Rufen Sie [disable_preset_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_preset_shadow_effect/) auf, um den Schatten zu entfernen und dabei Füllung und Kontur beizubehalten.

Dieses Beispiel zeigt vier Phasen nebeneinander auf einer Folie. Es klont das Rechteck vor jeder Änderung, sodass Sie die Ergebnisse vergleichen können. Beide Schatten sind um 10 Punkte versetzt. Eine Richtung von 225° positioniert den ersten Schatten oberhalb und links vom Rechteck, und 45° positioniert den zweiten darunter und rechts.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(800, 120, slides.SlideSizeScaleType.DO_NOT_SCALE)
    shapes = presentation.slides[0].shapes

    shape = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 15, 30, 170, 60)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = slides.Color.steel_blue
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = slides.Color.dark_blue
    shape.text_frame.text = "No shadow"
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 14
    shapes.add_clone(shape)

    shape.x += 200
    shape.effect_format.enable_preset_shadow_effect()
    shadow = shape.effect_format.preset_shadow_effect
    shadow.preset = slides.PresetShadowType.TOP_LEFT_DROP_SHADOW
    shadow.distance = 10
    shadow.direction = 225
    shape.text_frame.text = "TopLeftDropShadow"
    shapes.add_clone(shape)

    shape.x += 200
    shadow.preset = slides.PresetShadowType.BOTTOM_RIGHT_DROP_SHADOW
    shadow.direction = 45
    shape.text_frame.text = "BottomRightDropShadow"
    shapes.add_clone(shape)

    shape.x += 200
    shape.effect_format.disable_preset_shadow_effect()
    shape.text_frame.text = "No shadow"

    presentation.save("preset_shadows.pptx", slides.export.SaveFormat.PPTX)
```

| Original | Erste Voreinstellung | Zweite Voreinstellung | Nach Entfernung |
| :---: | :---: | :---: | :---: |
| ![Kein Schatten](preset_shadow_original.png) | ![Schatten oben links](preset_shadow_top_left.png) | ![Schatten unten rechts](preset_shadow_bottom_right.png) | ![Kein Schatten nach Entfernung](preset_shadow_removed.png) |

## **Reflexionseffekt anwenden**

Um einen Reflexionseffekt in Aspose.Slides für Python via .NET anzuwenden, können Sie Formen eine spiegelähnliche Reflexion hinzufügen und Parameter wie Abstand, Transparenz und Größe anpassen. Dieser Effekt verbessert die Ästhetik Ihrer Präsentationen, indem er Formen ein eleganteres und anspruchsvolleres Aussehen verleiht. Er lässt sich mit einfachem Code leicht umsetzen und ermöglicht eine schnelle Anwendung auf mehrere Elemente für ein konsistentes Design.

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

Um einen Leuchteffekt auf eine Form in Aspose.Slides für Python via .NET anzuwenden, können Sie eine sanfte, leuchtende Aura um die Formen hinzufügen und Eigenschaften wie Farbe und Größe anpassen. Dieser Effekt hilft, Formen hervorzuheben und verleiht Ihrer Präsentation ein attraktives, ansprechendes visuelles Element. Er lässt sich mit minimalem Code leicht implementieren und verbessert das Gesamtbild Ihrer Folien.

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

## **Weiche Kanten‑Effekt anwenden**

Um einen Weiche‑Kanten‑Effekt in Aspose.Slides für Python via .NET anzuwenden, können Sie einen sanften, unscharfen Übergang um die Kanten einer Form erzeugen. Dieser Effekt verleiht ein dezenteres und raffinierteres Aussehen, ideal für Designs, die ein sanftes, weicheres Erscheinungsbild benötigen. Sie können Parameter wie den Radius leicht anpassen, um den gewünschten Effekt auf verschiedene Formen in Ihrer Präsentation zu erzielen.

Dieser Python‑Code zeigt, wie man den [Weiche‑Kanten‑Effekt](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/soft_edge_effect/) auf eine Form anwendet:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)
    shape.effect_format.enable_soft_edge_effect()
    shape.effect_format.soft_edge_effect.radius = 8

    presentation.save("soft_edges_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Weiche‑Kanten‑Effekt](soft_edges_effect.png)

## **Weichzeichner‑Effekt anwenden**

Verwenden Sie Form‑Weichzeichnen, um die Füllung und Kontur einer Form abzuschwächen, während die Form bearbeitbar bleibt. Rufen Sie [set_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/set_blur_effect/) im EffectFormat der Form auf. Der Radius wird in Punkten (1/72 Zoll) gemessen: Verwenden Sie einen nicht‑negativen Wert, wobei größere Werte eine stärkere Unschärfe erzeugen. Ein Radius von null lässt das Aussehen unverändert.

Die Einstellung [grow](https://reference.aspose.com/slides/python-net/aspose.slides.effects/blur/grow/) steuert die sichtbaren Grenzen des Effekts. Bei `False` wird die Unschärfe auf die ursprünglichen gemalten Grenzen, einschließlich der Kontur, beschränkt. Bei `True` kann die Unschärfe über diese Grenzen hinausgehen. Keine der Einstellungen ändert die Position oder die Abmessungen der Form.

Der Vergleich unten verwendet durchgehend dieselbe Füllung, Kontur und Formabmessungen. Die obere Zeile verwendet `grow = False`; die untere Zeile verwendet `grow = True`.

![Originales Rechteck im Vergleich mit Unschärferadiussen von 5 und 15 Punkten, Grow deaktiviert und aktiviert](shape_blur_comparison.png)

Dieses Python‑Beispiel erstellt ein oranges Rechteck mit einer dunkelblauen Kontur, wendet einen 5‑Punkte‑Unschärfeeffekt an und aktualisiert ihn anschließend auf eine 15‑Punkte‑Unschärfe, indem es erneut [set_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/set_blur_effect/) aufruft. Es speichert beide unscharfen Zustände, ruft dann [disable_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_blur_effect/) auf und speichert die Form ohne Unschärfe.

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

Form‑Weichzeichnen wirkt sowohl auf die Füllung als auch auf die Kontur. Ein Weiche‑Kanten‑Effekt verblasst die Kanten der Form, während Schatten‑Weichzeichnen nur den Schatten abschwächt. Bildtransformations‑Effekte arbeiten am Bildinhalt; dieses Beispiel wendet die Unschärfe direkt auf das EffectFormat der Form an, ohne die Form in ein Bild zu konvertieren.

## **FAQ**

**Kann ich mehrere Effekte auf dieselbe Form anwenden?**

Ja, Sie können verschiedene Effekte, wie Schatten, Reflexion und Leuchteffekt, auf einer einzelnen Form kombinieren, um ein dynamischeres Erscheinungsbild zu erzeugen.

**Auf welche Formen kann ich Effekte anwenden?**

Sie können Effekte auf verschiedene Formen anwenden, darunter Autoformen, Diagramme, Tabellen, Bilder, SmartArt‑Objekte, OLE‑Objekte und mehr.

**Kann ich Effekte auf gruppierte Formen anwenden?**

Ja, Sie können Effekte auf gruppierte Formen anwenden. Der Effekt wird auf die gesamte Gruppe angewendet.