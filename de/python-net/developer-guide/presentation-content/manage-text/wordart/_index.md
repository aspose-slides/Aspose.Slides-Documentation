---
title: WordArt-Effekte in Python erstellen und anwenden
linktitle: WordArt
type: docs
weight: 110
url: /de/python-net/wordart/
keywords:
- WordArt
- WordArt erstellen
- WordArt-Vorlage
- WordArt-Effekt
- Schatteneffekt
- Reflexionseffekt
- Leuchteffekt
- WordArt-Transformation
- 3D-Effekt
- äußerer Schatteneffekt
- innerer Schatteneffekt
- Python
- Aspose.Slides
description: "Erstellen und Anpassen von WordArt-Effekten in Aspose.Slides für Python via .NET. Diese Schritt-für-Schritt-Anleitung unterstützt Entwickler dabei, Präsentationen mit professionellem Text in Python zu verbessern."
---
## **Übersicht**

WordArt-Effekte ermöglichen es Ihnen, Text mit Füllungen, Konturen, Schatten, Reflexionen, Leuchten, Transformationen und 3D-Formatierung zu gestalten. Dieser Artikel erklärt, wie Sie diese Effekte in PowerPoint‑Präsentationen mit Aspose.Slides für Python via .NET erstellen und anpassen, ohne dass Microsoft Office installiert ist.

## **Ein einfaches WordArt‑Template erstellen und auf Text anwenden**

Die folgenden Beispiele erstellen einen einfachen WordArt‑Stil, indem sie Text, Schriftart, Musterfüllung und Kontur festlegen.

Jedes Beispiel erstellt eine neue Präsentation und fügt ihrem ersten Folienblatt ein Rechteck hinzu; eine Eingabedatei ist nicht erforderlich. Das erste Beispiel setzt den Text auf „Aspose.Slides“. Die Position und Abmessungen der Form werden in Punkten gemessen:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)
    text_frame = auto_shape.text_frame

    portion = text_frame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"
```

Stellen Sie die Schriftart auf Arial Black mit 36 Punkten ein, um die Formatierung deutlicher zu machen:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)

    portion = auto_shape.text_frame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"
    portion.portion_format.latin_font = slides.FontData("Arial Black")
    portion.portion_format.font_height = 36
```

Wenden Sie ein [SMALL_GRID](https://reference.aspose.com/slides/de/python-net/aspose.slides/patternstyle/)‑Muster mit einem dunkelorangenen Vordergrund und einem weißen Hintergrund an und fügen Sie anschließend eine schwarze Textkontur mit einer Breite von 1 Punkt hinzu:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)

    portion = auto_shape.text_frame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"
    portion.portion_format.latin_font = slides.FontData("Arial Black")
    portion.portion_format.font_height = 36

    portion.portion_format.fill_format.fill_type = slides.FillType.PATTERN
    portion.portion_format.fill_format.pattern_format.fore_color.color = draw.Color.dark_orange
    portion.portion_format.fill_format.pattern_format.back_color.color = draw.Color.white
    portion.portion_format.fill_format.pattern_format.pattern_style = slides.PatternStyle.SMALL_GRID

    portion.portion_format.line_format.width = 1
    portion.portion_format.line_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.line_format.fill_format.solid_fill_color.color = draw.Color.black
```

Der resultierende Text:

![The simple WordArt template](WordArt_template.png)

## **Weitere WordArt‑Effekte anwenden**

Die folgenden Beispiele zeigen, wie Schatten, Reflexionen, Leuchten, Transformationen und 3D‑Effekte auf Text angewendet werden.

### **Äußere Schatteneffekte anwenden**

Ein äußerer Schatten verleiht Tiefe, indem er einen Schatten hinter den Text legt. Sie können seine Farbe, Richtung, Entfernung, Weichzeichnungsradius, Skalierung und Schrägstellung anpassen.

Dieses Beispiel ruft [enable_outer_shadow_effect](https://reference.aspose.com/slides/de/python-net/aspose.slides/effectformat/enable_outer_shadow_effect/) auf und setzt einen schwarzen Schatten mit einem Weichzeichnungsradius von 4 Punkten, einer Richtung von 230 Grad und einer Entfernung von 30 Punkten. Skalierungswerte von 100 erhalten die Schattengröße, während eine horizontale Schrägstellung ihn um 20 Grad neigt. Die Alpha‑Transformation setzt die Deckkraft auf 32 %:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)

    portion = auto_shape.text_frame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"
    portion.portion_format.latin_font = slides.FontData("Arial Black")
    portion.portion_format.font_height = 36

    portion.portion_format.effect_format.enable_outer_shadow_effect()
    portion.portion_format.effect_format.outer_shadow_effect.shadow_color.color = draw.Color.black
    portion.portion_format.effect_format.outer_shadow_effect.scale_horizontal = 100
    portion.portion_format.effect_format.outer_shadow_effect.scale_vertical = 100
    portion.portion_format.effect_format.outer_shadow_effect.blur_radius = 4
    portion.portion_format.effect_format.outer_shadow_effect.direction = 230
    portion.portion_format.effect_format.outer_shadow_effect.distance = 30
    portion.portion_format.effect_format.outer_shadow_effect.skew_horizontal = 20
    portion.portion_format.effect_format.outer_shadow_effect.skew_vertical = 0
    portion.portion_format.effect_format.outer_shadow_effect.shadow_color.color_transform.add(slides.ColorTransformOperation.SET_ALPHA, 0.32)
```

Der resultierende Text:

![The Outer Shadow effect](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- Wenn äußere und voreingestellte Schatten zusammen verwendet werden, wird nur der äußere Schatten angewendet.
- Werden äußere und innere Schatten gleichzeitig verwendet, hängt der resultierende Effekt von der PowerPoint-Version ab. In PowerPoint 2013 wird der Effekt verdoppelt, während in PowerPoint 2007 nur der äußere Schatten angewendet wird.
{{% /alert %}}

### **Reflexionseffekte anwenden**

Eine Reflexion erzeugt eine gespiegelte Kopie des Textes. Passen Sie Position, Skalierung, Weichzeichnung und Deckkraft an, um das Erscheinungsbild zu steuern.

Dieses Beispiel ruft [enable_reflection_effect](https://reference.aspose.com/slides/de/python-net/aspose.slides/effectformat/enable_reflection_effect/) auf und spiegelt die Reflexion vertikal mit einer Skalierung von -100 %. Es verwendet einen Weichzeichnungsradius von 0,5 Punkten und eine Entfernung von 4,72 Punkten. Die Deckkraft sinkt von 60 % auf 0,9 % zwischen den Positionen 0 % und 60 % entlang der Reflexion:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)

    portion = auto_shape.text_frame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"
    portion.portion_format.latin_font = slides.FontData("Arial Black")
    portion.portion_format.font_height = 36

    portion.portion_format.effect_format.enable_reflection_effect()
    portion.portion_format.effect_format.reflection_effect.blur_radius = 0.5
    portion.portion_format.effect_format.reflection_effect.distance = 4.72
    portion.portion_format.effect_format.reflection_effect.start_pos_alpha = 0
    portion.portion_format.effect_format.reflection_effect.end_pos_alpha = 60
    portion.portion_format.effect_format.reflection_effect.direction = 90
    portion.portion_format.effect_format.reflection_effect.scale_horizontal = 100
    portion.portion_format.effect_format.reflection_effect.scale_vertical = -100
    portion.portion_format.effect_format.reflection_effect.start_reflection_opacity = 60
    portion.portion_format.effect_format.reflection_effect.end_reflection_opacity = 0.9
    portion.portion_format.effect_format.reflection_effect.rectangle_align = slides.RectangleAlignment.BOTTOM_LEFT
```

![Der Reflexionseffekt](reflection_effect.png)

### **Leuchteffekte anwenden**

Ein Leuchten fügt um den Text eine weiche farbige Kontur hinzu. Passen Sie Farbe, Deckkraft und Radius an, um den Effekt zu steuern.

Dieses Beispiel ruft [enable_glow_effect](https://reference.aspose.com/slides/de/python-net/aspose.slides/effectformat/enable_glow_effect/) auf und wendet ein rotes Leuchten mit 54 % Deckkraft und einem Radius von 7 Punkten an:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)

    portion = auto_shape.text_frame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"
    portion.portion_format.latin_font = slides.FontData("Arial Black")
    portion.portion_format.font_height = 36

    portion.portion_format.effect_format.enable_glow_effect()
    portion.portion_format.effect_format.glow_effect.color.color = draw.Color.red
    portion.portion_format.effect_format.glow_effect.color.color_transform.add(slides.ColorTransformOperation.SET_ALPHA, 0.54)
    portion.portion_format.effect_format.glow_effect.radius = 7
```

![Der Leuchteffekt](glow_effect.png)

### **WordArt‑Transformationen anwenden**

WordArt‑Transformationen biegen, strecken oder verformen einen Textblock.

Setzen Sie [transform](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframeformat/transform/) auf [ARCH_UP_POUR](https://reference.aspose.com/slides/de/python-net/aspose.slides/textshapetype/), um den gesamten Textrahmen nach oben zu biegen:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)

    text_frame = auto_shape.text_frame
    text_frame.text = "Aspose.Slides"
    text_frame.text_frame_format.transform = slides.TextShapeType.ARCH_UP_POUR
```

![Die WordArt‑Transformation](transform_effect.png)

{{% alert color="info" title="Note" %}}
Aspose.Slides für Python via .NET bietet eine Reihe vordefinierter [Transformationsarten](https://reference.aspose.com/slides/de/python-net/aspose.slides/textshapetype/).
{{% /alert %}}

### **3D‑Effekte auf Formen und Text anwenden**

Sie können 3D‑Effekte auf eine Form oder deren Text anwenden. Abschrägungen, Extrusion, Beleuchtung und Kameraeinstellungen bestimmen das resultierende Aussehen.

Das folgende Beispiel verwendet [ThreeDFormat](https://reference.aspose.com/slides/de/python-net/aspose.slides/threedformat/), um dem Rechteck runde Abschrägungen, orangefarbene Extrusion und einen dunkelroten Kontur hinzuzufügen. Abschrägungsmaße, Extrusionshöhe, Konturbreite und Tiefe werden in Punkten gemessen. Ein Kunststoffmaterial, ausgewogene Beleuchtung, um 40 Grad um die Z‑Achse gedreht, und eine Perspektivkamera bestimmen das Erscheinungsbild:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)
    auto_shape.text_frame.text = "Aspose.Slides"

    auto_shape.three_d_format.bevel_bottom.bevel_type = slides.BevelPresetType.CIRCLE
    auto_shape.three_d_format.bevel_bottom.height = 10.5
    auto_shape.three_d_format.bevel_bottom.width = 10.5

    auto_shape.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    auto_shape.three_d_format.bevel_top.height = 12.5
    auto_shape.three_d_format.bevel_top.width = 11

    auto_shape.three_d_format.extrusion_color.color = draw.Color.orange
    auto_shape.three_d_format.extrusion_height = 6

    auto_shape.three_d_format.contour_color.color = draw.Color.dark_red
    auto_shape.three_d_format.contour_width = 1.5

    auto_shape.three_d_format.depth = 3

    auto_shape.three_d_format.material = slides.MaterialPresetType.PLASTIC

    auto_shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    auto_shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED
    auto_shape.three_d_format.light_rig.set_rotation(0, 0, 40)

    auto_shape.three_d_format.camera.camera_type = slides.CameraPresetType.PERSPECTIVE_CONTRASTING_RIGHT_FACING
```

![Der 3D‑Formeffekt](shape_3D_effect.png)

Dieses Beispiel wendet eine ähnliche 3D‑Formatierung auf den Text über [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframeformat/three_d_format/) an. Kleinere Abschrägungen formen die Buchstabenränder, während Extrusion und Beleuchtung dem Text Tiefe verleihen:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)
    text_frame = auto_shape.text_frame
    text_frame.text = "Aspose.Slides"

    text_frame.text_frame_format.three_d_format.bevel_bottom.bevel_type = slides.BevelPresetType.CIRCLE
    text_frame.text_frame_format.three_d_format.bevel_bottom.height = 3.5
    text_frame.text_frame_format.three_d_format.bevel_bottom.width = 3.5

    text_frame.text_frame_format.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    text_frame.text_frame_format.three_d_format.bevel_top.height = 4
    text_frame.text_frame_format.three_d_format.bevel_top.width = 4

    text_frame.text_frame_format.three_d_format.extrusion_color.color = draw.Color.orange
    text_frame.text_frame_format.three_d_format.extrusion_height = 6

    text_frame.text_frame_format.three_d_format.contour_color.color = draw.Color.dark_red
    text_frame.text_frame_format.three_d_format.contour_width = 1.5

    text_frame.text_frame_format.three_d_format.depth = 3

    text_frame.text_frame_format.three_d_format.material = slides.MaterialPresetType.PLASTIC

    text_frame.text_frame_format.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    text_frame.text_frame_format.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED
    text_frame.text_frame_format.three_d_format.light_rig.set_rotation(0, 0, 40)

    text_frame.text_frame_format.three_d_format.camera.camera_type = slides.CameraPresetType.PERSPECTIVE_CONTRASTING_RIGHT_FACING
```

![Der 3D‑Texteffekt](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
Die Anwendung von 3D‑Effekten auf Text oder deren Formen – und die Interaktion zwischen diesen Effekten – wird durch spezifische Regeln bestimmt. Betrachten Sie eine Szene, die sowohl Text als auch die ihn enthaltende Form umfasst. Ein 3D‑Effekt beinhaltet die 3D‑Darstellung des Objekts und die Szene, in der es platziert ist.

- Wenn für sowohl die Form als auch den Text eine Szene festgelegt ist, hat die Szene der Form Vorrang und die Szene des Textes wird ignoriert.
- Wenn die Form keine eigene Szene hat, aber eine 3D‑Darstellung besitzt, wird die Szene des Textes verwendet.
- Wenn die Form überhaupt keinen 3D‑Effekt hat, wird sie als flach behandelt und der 3D‑Effekt nur auf den Text angewendet.

Diese Verhaltensweisen beziehen sich auf die Eigenschaften [ThreeDFormat.light_rig](https://reference.aspose.com/slides/de/python-net/aspose.slides/threedformat/light_rig/) und [ThreeDFormat.camera](https://reference.aspose.com/slides/de/python-net/aspose.slides/threedformat/camera/).
{{% /alert %}}

Um Text flach und lesbar zu halten und gleichzeitig die 3D‑Formatierung seiner Form beizubehalten, siehe [Keep Text Flat on a 3D Shape](/slides/de/python-net/3d-presentation/) für einen Vergleich beider Einstellungen und ein vollständiges Python‑Beispiel.

## **FAQ**

**Kann ich WordArt‑Effekte mit verschiedenen Schriftarten oder Skripten (z. B. Arabisch, Chinesisch) verwenden?**

Ja, Aspose.Slides für Python via .NET unterstützt Unicode und funktioniert mit allen gängigen Schriftarten und Skripten. WordArt‑Effekte wie Schatten, Füllung und Kontur können unabhängig von der Sprache angewendet werden, wobei die Verfügbarkeit und das Rendering der Schriftarten von den Systemschriftarten abhängen können.

**Kann ich WordArt‑Effekte auf Elemente des Folienmasters anwenden?**

Ja, Sie können WordArt‑Effekte auf Formen in Master‑Folien anwenden, einschließlich Titel‑Platzhaltern, Fußzeilen oder Hintergrundtext. Änderungen am Master‑Layout wirken sich auf alle zugehörigen Folien aus.

**Beeinflussen WordArt‑Effekte die Dateigröße der Präsentation?**

Leicht. WordArt‑Effekte wie Schatten, Leuchten und Farbverlauf‑Füllungen können die Dateigröße aufgrund zusätzlicher Formatierungs‑Metadaten geringfügig erhöhen, aber der Unterschied ist in der Regel vernachlässigbar.

**Kann ich das Ergebnis von WordArt‑Effekten anzeigen, ohne die Präsentation zu speichern?**

Ja, Sie können Folien, die WordArt enthalten, mithilfe von [Slide.get_image](https://reference.aspose.com/slides/de/python-net/aspose.slides/slide/get_image/) in Bilder (z. B. PNG, JPEG) rendern oder einzelne Formen über [Shape.get_image](https://reference.aspose.com/slides/de/python-net/aspose.slides/shape/get_image/) rendern. So können Sie das Ergebnis im Speicher oder auf dem Bildschirm anzeigen, bevor Sie die gesamte Präsentation speichern oder exportieren.