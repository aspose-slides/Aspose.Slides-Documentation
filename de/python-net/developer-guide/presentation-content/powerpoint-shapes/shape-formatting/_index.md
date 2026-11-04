---
title: PowerPoint-Formen in Python formatieren
linktitle: Formformatierung
type: docs
weight: 20
url: /de/python-net/shape-formatting/
keywords:
- Form formatieren
- Linie formatieren
- Skizzeeffekt
- Skizze-Formlinie
- Verbindungsstil formatieren
- Verlaufsfüllung
- Musterfüllung
- Bildfüllung
- Texturfüllung
- Einfarbige Füllung
- Form-Transparenz
- Schwarz-Weiß-Darstellung von Formen
- Graustufen-Darstellung von Formen
- Form drehen
- 3D-Kanten-Effekt
- 3D-Dreh-Effekt
- Formatierung zurücksetzen
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint-Formen in Python mit Aspose.Slides – Füll-, Linien- und Effekt-Stile für PPT-, PPTX- und ODP-Dateien präzise und vollständig steuern."
---
## **Einleitung**

Formatiere Formen in PowerPoint, indem du Konturen, Füllungen und Effekte anpasst. Aspose.Slides for Python via .NET ermöglicht es dir, diese Einstellungen programmgesteuert zu steuern, einschließlich Transparenz, Drehung und 3D‑Formatierung.

![Shape formatting options in PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for Python via .NET stellt Klassen und Eigenschaften bereit, mit denen du Formen mit denselben Optionen formatieren kannst, die in PowerPoint verfügbar sind.

## **Linien formatieren**

Verwende [Shape.line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) um die Kontur einer Form zu steuern. Dieses Beispiel erstellt ein nicht ausgefülltes Rechteck mit einer blauen, gestrichelten Kontur. [LineFormat.style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/style/) wählt eine dick‑dünn Verbundlinie, während [LineFormat.width](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/width/) die Breite auf 7 Punkte setzt und [LineFormat.dash_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/) das Strichmuster auswählt.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.style = slides.LineStyle.THICK_THIN
    shape.line_format.width = 7
    shape.line_format.dash_style = slides.LineDashStyle.DASH
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue

    presentation.save("formatted_lines.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![The formatted lines in the presentation](formatted-lines.png)

### **Benutzerdefinierte Strichmuster festlegen**

Verwende [LineFormat.custom_dash_pattern](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/custom_dash_pattern/) wenn vordefinierte Linienstile die benötigten Strich‑ und Lückenlängen nicht bieten, zum Beispiel für markenspezifische Konturen oder technische Diagramme. Das Zuweisen eines Musters setzt automatisch [LineFormat.dash_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/) auf [LineDashStyle.CUSTOM](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/).

Die Listeneinträge wechseln zwischen Strich‑ und Lückenlängen, beginnend mit einem Strich. Jeder Wert ist ein Vielfaches der Linienbreite: `[4, 2]` bei einer Breite von 3 Punkten erzeugt einen 12‑Punkte‑Strich gefolgt von einer 6‑Punkte‑Lücke. Verwende Paare aus endlichen, nicht‑negativen Werten, um vollständige Strich‑und‑Lücken‑Segmente zu definieren. Das Beispiel verwendet positive Werte, damit jeder Strich und jede Lücke sichtbar bleibt.

Dieses Beispiel erstellt fünf blaue Linien mit gleicher Länge und flachen Enden. Die ersten drei vergleichen Muster bei einer Breite von 3 Punkten. Das vierte wiederholt das erste Muster bei doppelter Breite und verdoppelt sowohl Strich‑ als auch Lückenlänge. Die fünfte wechselt von einem benutzerdefinierten Muster zu einer durchgezogenen Linie.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(600, 300, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    patterns = [
        [4, 2],
        [1, 2],
        [6, 2, 1, 2],
        [4, 2],
        [4, 2]
    ]

    for i, pattern in enumerate(patterns):
        line = slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 50 + i * 50, 500, 0)
        line.line_format.width = 6 if i == 3 else 3
        line.line_format.fill_format.fill_type = slides.FillType.SOLID
        line.line_format.fill_format.solid_fill_color.preset_color = slides.PresetColor.DARK_BLUE
        line.line_format.cap_style = slides.LineCapStyle.FLAT
        line.line_format.begin_arrowhead_style = slides.LineArrowheadStyle.NONE
        line.line_format.end_arrowhead_style = slides.LineArrowheadStyle.NONE
        line.line_format.custom_dash_pattern = pattern

    # Setze die letzte Linie auf einen durchgezogenen Stil.
    slide.shapes[4].line_format.dash_style = slides.LineDashStyle.SOLID

    presentation.save("custom_dash_patterns.pptx", slides.export.SaveFormat.PPTX)
```

Um stattdessen zu einem vordefinierten gestrichelten Stil zurückzukehren, weise [LineDashStyle.DASH](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/) [LineFormat.dash_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/) zu. Der ausgewählte Stil bestimmt das Aussehen der Linie.

Das Ergebnis in PowerPoint, von oben nach unten: **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; und **Solid, 3 pt**.

![Three custom dash patterns, a wider line using the first pattern, and a solid line in PowerPoint](custom-dash-patterns.png)

### **Linienenden festlegen**

Verwende [LineFormat.cap_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/cap_style/) um die Enden einer offenen Linie zu setzen. Die Aufzählung [LineCapStyle](https://reference.aspose.com/slides/python-net/aspose.slides/linecapstyle/) liefert drei explizite Endstile:

- `FLAT`: Der Strich endet am Endpunkt.
- `ROUND`: Ein halbkreisförmiges Ende erstreckt sich über den Endpunkt hinaus um die halbe Linienbreite.
- `SQUARE`: Ein quadratisches Ende erstreckt sich über den Endpunkt hinaus um die halbe Linienbreite.

Die Aufzählung enthält außerdem `NOT_DEFINED`, was bedeutet, dass kein Endstil explizit zugewiesen wurde.

Enden unterscheiden sich von Pfeilspitzen, die Symbole an Linienenden hinzufügen, und von Verbindungen, die Ecken zwischen Liniensegmenten steuern. Dieses Beispiel deaktiviert Pfeilspitzen über [LineFormat.begin_arrowhead_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/begin_arrowhead_style/) und [LineFormat.end_arrowhead_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/end_arrowhead_style/), sodass nur die Endformen verglichen werden.

Das folgende Beispiel erstellt drei ansonsten identische horizontale Linien, 20 Punkte breit. Von oben nach unten verwenden sie flache, runde und quadratische Enden. Ihre Endpunkte haben dieselben horizontalen Koordinaten; die runden und quadratischen Enden erstrecken sich 10 Punkte über jeden Endpunkt hinaus.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(500, 240, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    cap_styles = [slides.LineCapStyle.FLAT, slides.LineCapStyle.ROUND, slides.LineCapStyle.SQUARE]

    for i, cap_style in enumerate(cap_styles):
        line = slide.shapes.add_auto_shape(slides.ShapeType.LINE, 100, 50 + i * 70, 300, 0)
        line.line_format.width = 20
        line.line_format.fill_format.fill_type = slides.FillType.SOLID
        line.line_format.fill_format.solid_fill_color.preset_color = slides.PresetColor.DARK_BLUE
        line.line_format.dash_style = slides.LineDashStyle.SOLID
        line.line_format.cap_style = cap_style
        line.line_format.begin_arrowhead_style = slides.LineArrowheadStyle.NONE
        line.line_format.end_arrowhead_style = slides.LineArrowheadStyle.NONE

    presentation.save("line_caps.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis in PowerPoint, von oben nach unten: **Flat**, **Round**, und **Square**.

![Flat, round, and square caps on identical thick lines in PowerPoint](line-caps.png)

## **Skizzeeffekte auf Formlinien anwenden**

Ein Skizzeeffekt lässt eine Formlinie handgezeichnet aussehen. Verwende [Shape.line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) um auf die Linieneinstellungen zuzugreifen, [LineFormat.sketch_format](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/sketch_format/) um die Skizzeeinstellungen zu erhalten und [SketchFormat.sketch_type](https://reference.aspose.com/slides/python-net/aspose.slides/sketchformat/sketch_type/) um einen Wert aus der Aufzählung [LineSketchType](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/) auszuwählen.

Der folgende Python‑Code zeigt, wie man einen [LineSketchType.CURVED](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/) Effekt anwendet, den explizit zugewiesenen Wert ausliest und den Effekt mit [LineSketchType.NONE](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/) entfernt:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)

    sketch_format = shape.line_format.sketch_format
    sketch_format.sketch_type = slides.LineSketchType.CURVED
    explicit_sketch_type = sketch_format.sketch_type
    print(f"Explicit sketch type: {explicit_sketch_type}")
    sketch_format.sketch_type = slides.LineSketchType.NONE
```

Der von [SketchFormat.sketch_type](https://reference.aspose.com/slides/python-net/aspose.slides/sketchformat/sketch_type/) zurückgegebene Wert stellt die direkt der Form zugewiesene Einstellung dar. Wenn die Linienformatierung von einem Design, einer Master‑Folien‑ oder Layout‑Folie geerbt werden kann, verwende [LineFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/get_effective/), greife auf [ILineFormatEffectiveData.sketch_format](https://reference.aspose.com/slides/python-net/aspose.slides/ilineformateffectivedata/sketch_format/) zu und lese [ISketchFormatEffectiveData.sketch_type](https://reference.aspose.com/slides/python-net/aspose.slides/isketchformateffectivedata/sketch_type/) aus. Der effektive Wert spiegelt die Formatierung wider, die nach Auflösung der Vererbung tatsächlich angewendet wird. Dieses Beispiel benötigt eine vorhandene Präsentation mit mindestens einer Form auf der ersten Folie und gibt beide Werte aus:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    line_format = shape.line_format
    explicit_sketch_type = line_format.sketch_format.sketch_type
    effective_line_format = line_format.get_effective()
    effective_sketch_type = effective_line_format.sketch_format.sketch_type

    print(f"Explicit sketch type: {explicit_sketch_type}")
    print(f"Effective sketch type: {effective_sketch_type}")
```

## **Verbindungsstile formatieren**

Hier sind die drei Optionen für den Verbindungstyp:

* Round
* Miter
* Bevel

Der Verbindungsstil bestimmt, wie zwei Kontursegmente an einer Ecke zusammenlaufen. Verwende **Round** für abgerundete Ecken, **Miter** für scharfe Ecken oder **Bevel** für abgeflachte Ecken.

![The join style in the presentation](join-style-powerpoint.png)

Dieses Beispiel erstellt drei schwarze Rechtecke mit blauen Konturen von 15 Punkten Breite. Es setzt [LineFormat.join_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/join_style/) auf die Miter‑, Bevel‑ und Round‑Werte von [LineJoinStyle](https://reference.aspose.com/slides/python-net/aspose.slides/linejoinstyle/), um zu vergleichen, wie die Ecken gezeichnet werden.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    miter_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 75)
    bevel_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 210, 20, 150, 75)
    round_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 135, 150, 75)

    miter_shape.fill_format.fill_type = slides.FillType.SOLID
    miter_shape.fill_format.solid_fill_color.color = draw.Color.black
    bevel_shape.fill_format.fill_type = slides.FillType.SOLID
    bevel_shape.fill_format.solid_fill_color.color = draw.Color.black
    round_shape.fill_format.fill_type = slides.FillType.SOLID
    round_shape.fill_format.solid_fill_color.color = draw.Color.black

    miter_shape.line_format.width = 15
    bevel_shape.line_format.width = 15
    round_shape.line_format.width = 15

    miter_shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    miter_shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue
    bevel_shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    bevel_shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue
    round_shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    round_shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue

    miter_shape.line_format.join_style = slides.LineJoinStyle.MITER
    bevel_shape.line_format.join_style = slides.LineJoinStyle.BEVEL
    round_shape.line_format.join_style = slides.LineJoinStyle.ROUND

    miter_shape.text_frame.text = "Miter Join Style"
    bevel_shape.text_frame.text = "Bevel Join Style"
    round_shape.text_frame.text = "Round Join Style"

    presentation.save("join_styles.pptx", slides.export.SaveFormat.PPTX)
```

### **Miter‑Verbindungen an scharfen Ecken begrenzen**

Verwende [LineFormat.miter_limit](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/miter_limit/) zusammen mit [LineFormat.join_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/join_style/) auf [LineJoinStyle.MITER](https://reference.aspose.com/slides/python-net/aspose.slides/linejoinstyle/), um zu begrenzen, wie weit eine scharfe Ecke reichen darf.

Der Grenzwert ist das Verhältnis des Abstands zwischen innerer und äußerer Ecke der Verbindung zur Linienbreite. Zum Beispiel erlaubt ein Wert von `8` eine Miter‑Länge von bis zu dem Achtfachen der Linienbreite; er ist keine Messung in Punkten. Wenn die Ecke den Grenzwert überschreiten würde, verwendet PowerPoint an dieser Ecke eine abgeschrägte Verbindung. Ein größerer Grenzwert ermöglicht spitzere Punkte. Die Einstellung wirkt sich nur auf Miter‑Verbindungen aus und hat keine sichtbare Auswirkung, wenn die Ecke innerhalb beider Grenzen bleibt.

Dieses Beispiel erstellt zwei identische, nicht ausgefüllte Dreiecke mit Konturen von 20 Punkten Breite. Das linke Dreieck verwendet einen Grenzwert von `2`, das rechte einen von `8`. Jedes Dreieck ist 80 Punkte breit und 160 Punkte hoch, wodurch das Verhältnis von Miter‑Länge zu Linienbreite an der oberen Ecke etwa `4.12` beträgt. Folglich schrägt PowerPoint die linke Spitze ab und belässt die rechte Spitze.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(500, 320, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    miter_limits = [2.0, 8.0]

    for i, miter_limit in enumerate(miter_limits):
        triangle = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 90 + i * 240, 110, 80, 160)
        triangle.fill_format.fill_type = slides.FillType.NO_FILL
        triangle.line_format.width = 20
        triangle.line_format.fill_format.fill_type = slides.FillType.SOLID
        triangle.line_format.fill_format.solid_fill_color.preset_color = slides.PresetColor.DARK_BLUE
        triangle.line_format.join_style = slides.LineJoinStyle.MITER
        triangle.line_format.miter_limit = miter_limit

    presentation.save("miter_limits.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis in PowerPoint: **Miter limit 2** links und **miter limit 8** rechts.

![A beveled apex with miter limit 2 and a pointed apex with miter limit 8 in PowerPoint](miter-limits.png)

## **Verlaufsfüllung**

Eine Verlaufsfüllung verblendet Farben über eine Form. Dieses Beispiel füllt eine Ellipse mit einem linearen Verlauf von Rot nach Lila unter einem Winkel von 45 Grad mittels [FillFormat.gradient_format](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/gradient_format/). Die Methode [GradientStopCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides/gradientstopcollection/add/) legt die Farbstopp‑Positionen bei 0 und 1 fest, also am Anfang und Ende des Verlaufs. Das Löschen vorhandener Stops stellt sicher, dass nur diese beiden Farben verwendet werden.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 150, 75)
    shape.fill_format.fill_type = slides.FillType.GRADIENT
    shape.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR
    shape.fill_format.gradient_format.linear_gradient_angle = 45
    shape.fill_format.gradient_format.gradient_stops.clear()
    shape.fill_format.gradient_format.gradient_stops.add(1.0, slides.PresetColor.PURPLE)
    shape.fill_format.gradient_format.gradient_stops.add(0.0, slides.PresetColor.RED)

    presentation.save("gradient_fill.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![The ellipse with gradient fill](gradient-fill.png)

Wenn ein Verlauf in einem exportierten Bild anders aussieht als in PowerPoint, siehe [Choose a Gradient Rendering Style](/slides/de/python-net/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Du kannst einen Renderstil auswählen, ohne die im Dokument gespeicherte Verlaufsfüllung zu ändern.

### **Den Winkel des linearen Verlaufs festlegen**

Verwende [GradientFormat.linear_gradient_angle](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/linear_gradient_angle/) um die Ausrichtung einer [GradientShape.LINEAR](https://reference.aspose.com/slides/python-net/aspose.slides/gradientshape/) Füllung zu steuern. Der Winkel wird in Grad gemessen und erhöht sich im Uhrzeigersinn: `0` verläuft von links nach rechts, `90` von oben nach unten, `180` von rechts nach links und `270` von unten nach oben. Bruchteile von Grad werden unterstützt. Endliche Winkel außerhalb `[0, 360)` werden zu einer Umdrehung normalisiert; zum Beispiel wird `-45` zu `315` und `360` zu `0`.

Dieses Beispiel erstellt sechs Rechtecke mit identischen roten, grünen und blauen Stopps an den Positionen `0`, `0.5` und `1`. Die Skalierung ist deaktiviert, damit der Winkel unabhängig von den Proportionen der Rechtecke verglichen werden kann. Die Winkel von links nach rechts sind `0`, `45` und `90` in der ersten Reihe sowie `135`, `180` und `270` in der zweiten Reihe.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 400, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    angles = [0, 45, 90, 135, 180, 270]

    for i, angle in enumerate(angles):
        x = 30 + (i % 3) * 230
        y = 30 + (i // 3) * 190

        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, y, 200, 150)
        shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
        shape.fill_format.fill_type = slides.FillType.GRADIENT

        gradient = shape.fill_format.gradient_format
        gradient.gradient_shape = slides.GradientShape.LINEAR
        gradient.gradient_stops.clear()
        gradient.gradient_stops.add(0.0, slides.PresetColor.RED)
        gradient.gradient_stops.add(0.5, slides.PresetColor.LIME)
        gradient.gradient_stops.add(1.0, slides.PresetColor.BLUE)
        gradient.linear_gradient_scaled = slides.NullableBool.FALSE
        gradient.linear_gradient_angle = angle

    presentation.save("linear_gradient_angles.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis in PowerPoint:

![Linear gradients at 0, 45, and 90 degrees in the top row, and 135, 180, and 270 degrees in the bottom row](linear-gradient-angles.png)

### **Einen linearen Verlauf mit der Form skalieren**

[GradientFormat.linear_gradient_scaled](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/linear_gradient_scaled/) akzeptiert einen [NullableBool](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/) Wert. Setze ihn explizit auf `FALSE`, um den geometrischen Verlaufswinkel beizubehalten, wenn sich die Proportionen der Form ändern, oder auf `TRUE`, um den Verlauf mit Breite und Höhe der Form zu skalieren. Bei aktivierter Skalierung kann der sichtbare Winkel von dem zugewiesenen Winkel bei einer nicht‑quadratischen Form abweichen.

Das folgende Beispiel verwendet einen Winkel von `45` Grad und dieselben Farbstopps wie beim Winkelvergleich. Die linke Spalte verwendet `FALSE`; die rechte Spalte verwendet `TRUE`. Jede Spalte enthält ein breites Rechteck über einem hohen Rechteck. Beide beginnen mit denselben breiten Abmessungen; das Ändern von Breite und Höhe des zweiten Rechtecks demonstriert, wie die Füllung auf Größenänderungen reagiert, ohne die Verlaufseinstellungen zu ändern.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 460, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    scaling_options = [slides.NullableBool.FALSE, slides.NullableBool.TRUE]

    for column, scaling in enumerate(scaling_options):
        for row in range(2):
            x = 30 + column * 360
            y = 30 if row == 0 else 150

            shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, y, 300, 90)
            shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
            shape.fill_format.fill_type = slides.FillType.GRADIENT

            gradient = shape.fill_format.gradient_format
            gradient.gradient_shape = slides.GradientShape.LINEAR
            gradient.gradient_stops.clear()
            gradient.gradient_stops.add(0.0, slides.PresetColor.RED)
            gradient.gradient_stops.add(0.5, slides.PresetColor.LIME)
            gradient.gradient_stops.add(1.0, slides.PresetColor.BLUE)
            gradient.linear_gradient_angle = 45
            gradient.linear_gradient_scaled = scaling

            if row == 1:
                shape.width = 90
                shape.height = 280

    presentation.save("linear_gradient_scaling.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis in PowerPoint, bei deaktivierter Skalierung links und aktivierter rechts:

![Wide and tall rectangles with a 45-degree gradient, comparing linear_gradient_scaled FALSE on the left with TRUE on the right](linear-gradient-scaling.png)

Sowohl Winkel‑ als auch Skalierungseinstellungen gelten für lineare Verläufe. Sie steuern nicht die Füllungen [GradientShape.RADIAL oder GradientShape.RECTANGLE](https://reference.aspose.com/slides/python-net/aspose.slides/gradientshape/).

### **Den Winkel mit Verlaufsrichtung kombinieren**

[GradientFormat.gradient_direction](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/gradient_direction/) wählt einen Verlaufsstil aus der Aufzählung [GradientDirection](https://reference.aspose.com/slides/python-net/aspose.slides/gradientdirection/) aus; er ist kein Ersatz für einen numerischen Winkel. Für einen linearen Verlauf können die Eckstile den Bereich, über den die Farben verteilt werden, ändern, ohne [linear_gradient_angle](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/linear_gradient_angle/) zu ändern. Lass die Richtung unverändert, wenn du Winkel oder Skalierung vergleichst.

Das folgende Beispiel wendet dieselben Einstellungen in umgekehrter Reihenfolge an. Die beiden Rechtecke sehen gleich aus: Das Zuweisen der Richtung vor oder nach dem Winkel ändert das Ergebnis nicht.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    for i in range(2):
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30 + i * 140, 320, 100)
        shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
        shape.fill_format.fill_type = slides.FillType.GRADIENT

        gradient = shape.fill_format.gradient_format
        gradient.gradient_shape = slides.GradientShape.LINEAR
        gradient.gradient_stops.clear()
        gradient.gradient_stops.add(0.0, slides.PresetColor.RED)
        gradient.gradient_stops.add(0.5, slides.PresetColor.LIME)
        gradient.gradient_stops.add(1.0, slides.PresetColor.BLUE)
        gradient.linear_gradient_scaled = slides.NullableBool.TRUE

        if i == 0:
            gradient.gradient_direction = slides.GradientDirection.FROM_CORNER1
            gradient.linear_gradient_angle = 30
        else:
            gradient.linear_gradient_angle = 30
            gradient.gradient_direction = slides.GradientDirection.FROM_CORNER1

    presentation.save("linear_gradient_direction.pptx", slides.export.SaveFormat.PPTX)
```

## **Musterfüllung**

Eine Musterfüllung wendet ein zweifarbiges Design an, z. B. Punkte, Streifen oder Karos. Dieses Beispiel verwendet [PatternFormat.pattern_style](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/pattern_style/) um ein Trellis‑Muster auszuwählen. [PatternFormat.back_color](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/back_color/) liefert den hellgrauen Hintergrund und [PatternFormat.fore_color](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/fore_color/) liefert die gelbe Musterfarbe.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    shape.fill_format.fill_type = slides.FillType.PATTERN
    shape.fill_format.pattern_format.pattern_style = slides.PatternStyle.TRELLIS
    shape.fill_format.pattern_format.back_color.color = draw.Color.light_gray
    shape.fill_format.pattern_format.fore_color.color = draw.Color.yellow

    presentation.save("pattern_fill.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![The rectangle with pattern fill](pattern-fill.png)

## **Bildfüllung**

Eine Bildfüllung verwendet ein Bild innerhalb einer Form. Dieses Beispiel benötigt ein lokales Bild und lädt es mit [Images.from_file](https://reference.aspose.com/slides/python-net/aspose.slides/images/from_file/) in die Bildsammlung der Präsentation. Das Setzen von [PictureFillFormat.picture_fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture_fill_mode/) auf den Kachel‑Modus wiederholt das Bild innerhalb des Rechtecks. Das hier verwendete Quellbild ist unten zu sehen:

![The lotus picture](lotus.png)

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 255, 130)
    shape.fill_format.fill_type = slides.FillType.PICTURE
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE

    with slides.Images.from_file("lotus.png") as image:
        presentation_image = presentation.images.add_image(image)
    shape.fill_format.picture_fill_format.picture.image = presentation_image

    presentation.save("picture_fill.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![The shape with picture fill](picture-fill.png)

### **Bild als Kachel‑Textur**

Wenn du ein gekacheltes Bild als Textur festlegen und das Kachelverhalten anpassen möchtest, kannst du die folgenden Eigenschaften der Klasse [PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/) verwenden:

- [picture_fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture_fill_mode/): Legt den Bildfüll‑Modus fest – entweder `TILE` oder `STRETCH`.
- [tile_alignment](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_alignment/): Gibt die Ausrichtung der Kacheln innerhalb der Form an.
- [tile_flip](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_flip/): Steuert, ob die Kachel horizontal, vertikal oder in beiden Richtungen gespiegelt wird.
- [tile_offset_x](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_offset_x/): Setzt den horizontalen Versatz der Kachel (in Punkten) vom Ursprung der Form.
- [tile_offset_y](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_offset_y/): Setzt den vertikalen Versatz der Kachel (in Punkten) vom Ursprung der Form.
- [tile_scale_x](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_scale_x/): Definiert die horizontale Skalierung der Kachel als Prozentsatz.
- [tile_scale_y](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_scale_y/): Definiert die vertikale Skalierung der Kachel als Prozentsatz.

Dieses Beispiel benötigt ein lokales Bild und konfiguriert [PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/) so, dass es bei 50 % seiner Originalgröße wiederholt wird. Offsets von −32 Punkten verschieben die Kacheln horizontal und vertikal; die Ausrichtung unten‑rechts und das Spiegeln in beiden Richtungen bestimmen, wie die wiederholte Textur angeordnet wird.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]

    shape = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 190, 95)
    shape.fill_format.fill_type = slides.FillType.PICTURE

    with slides.Images.from_file("lotus.png") as source_image:
        presentation_image = presentation.images.add_image(source_image)

    picture_fill_format = shape.fill_format.picture_fill_format
    picture_fill_format.picture.image = presentation_image
    picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE
    picture_fill_format.tile_offset_x = -32
    picture_fill_format.tile_offset_y = -32
    picture_fill_format.tile_scale_x = 50
    picture_fill_format.tile_scale_y = 50
    picture_fill_format.tile_alignment = slides.RectangleAlignment.BOTTOM_RIGHT
    picture_fill_format.tile_flip = slides.TileFlip.FLIP_BOTH

    presentation.save("tile.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![The tile options](tile-options.png)

## **Einfarbige Füllung**

Eine einfarbige Füllung verleiht einer Form eine einzige, gleichmäßige Farbe. Dieses Beispiel setzt [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) auf den einfarbigen Füllmodus und weist Gelb über [FillFormat.solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/) zu, dann speichert es das Rechteck in einer Präsentation.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.yellow

    presentation.save("solid_color_fill.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![The shape with solid color fill](solid-color-fill.png)

## **Folienhintergrund als Formfüllung verwenden**

Verwende [AutoShape.use_background_fill](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/use_background_fill/) wenn eine Form dem Folienhintergrund entsprechen soll, zum Beispiel in einer Vorlagenpräsentation. Setze zunächst [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) auf [FillType.NOT_DEFINED](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/), um eine explizite Füllung zu entfernen. Mit dieser Kombination verwendet die Form den Folienhintergrund anstelle ihrer Stil‑Füllung. Das Setzen des Flags allein entfernt keine bereits vorhandene explizite Füllung.

Dies unterscheidet sich von [FillType.NO_FILL](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/): Hintergrundfüllung deckt Objekte hinter der Form mit dem entsprechenden Bereich des Folienhintergrunds ab, während keine Füllung diese Objekte sichtbar lässt. Ein Verlauf bleibt an der Folie ausgerichtet, anstatt in jeder Form neu zu starten.

Das folgende Beispiel erstellt einen Master‑Hintergrund, der von der Folie geerbt wird, und legt ein magenta‑farbiges Band hinter drei Rechtecke. Das linke Rechteck verwendet den Hintergrund, das mittlere Rechteck hat keine Füllung und das rechte Rechteck wechselt von Hintergrundfüllung zu einer expliziten orangefarbenen Füllung.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 400, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    # Vererbe den Verlauf vom Master.
    slide.background.type = slides.BackgroundType.NOT_DEFINED
    slide.layout_slide.background.type = slides.BackgroundType.NOT_DEFINED
    background = slide.layout_slide.master_slide.background
    background.type = slides.BackgroundType.OWN_BACKGROUND
    background.fill_format.fill_type = slides.FillType.GRADIENT
    gradient = background.fill_format.gradient_format
    gradient.gradient_shape = slides.GradientShape.LINEAR
    gradient.linear_gradient_angle = 0
    gradient.gradient_stops.clear()
    gradient.gradient_stops.add(0, draw.Color.dark_blue)
    gradient.gradient_stops.add(1, draw.Color.light_sky_blue)

    # Füge dieses Objekt zuerst hinzu, damit es hinter den Rechtecken erscheint.
    band = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 25, 150, 670, 100)
    band.fill_format.fill_type = slides.FillType.SOLID
    band.fill_format.solid_fill_color.color = draw.Color.magenta
    band.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    background_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 100, 160, 200)
    background_shape.fill_format.fill_type = slides.FillType.NOT_DEFINED
    background_shape.use_background_fill = True

    no_fill_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 280, 100, 160, 200)
    no_fill_shape.fill_format.fill_type = slides.FillType.NO_FILL

    explicit_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 510, 100, 160, 200)
    explicit_shape.fill_format.fill_type = slides.FillType.NOT_DEFINED
    explicit_shape.use_background_fill = True

    # Deaktiviere die Hintergrundfüllung, bevor eine explizite Füllung angewendet wird.
    explicit_shape.use_background_fill = False
    explicit_shape.fill_format.fill_type = slides.FillType.SOLID
    explicit_shape.fill_format.solid_fill_color.color = draw.Color.orange

    presentation.save("background_fill.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis, von links nach rechts: **background fill**, **no fill**, und **explicit fill**. Das magenta Band wird von den linken und rechten Rechtecken verdeckt, bleibt aber durch das mittlere Rechteck sichtbar.

![Background fill, no fill, and explicit orange fill over a magenta band](background-fill.png)

Das gleiche Verhalten gilt für einen Hintergrund, der direkt auf der Folie definiert oder von einem Layout geerbt wird. Die Form verwendet den aufgelösten Folienhintergrund; das Beispiel lässt sowohl Folien‑ als auch Layout‑Hintergründe undefiniert, sodass der Master ihn liefert.

## **Transparenz festlegen**

Bei einer einfarbigen Füllung steuert die Alphakomponente der Farbe die Undurchsichtigkeit: 0 ist vollständig transparent und 255 vollständig undurchsichtig. Dieses Beispiel verwendet einen Alphawert von 128 für ein gelbes Rechteck, wodurch es etwa zu 50 % transparent wird, sodass das darunterliegende Rechteck sichtbar bleibt. Die Farbe wird über [FillFormat.solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/) zugewiesen.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

alpha = 128

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    solid_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    transparent_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 80, 150, 75)
    transparent_shape.fill_format.fill_type = slides.FillType.SOLID
    transparent_shape.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.yellow)

    presentation.save("shape_transparency.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![The transparent shape](shape-transparency.png)

## **Formen drehen**

Verwende [Shape.rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) um eine Form in der Folienebene zu drehen. Der Winkel wird in Grad gemessen; dieses Beispiel dreht ein Rechteck um 5 Grad im Uhrzeigersinn und speichert die Präsentation.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    shape.rotation = 5

    presentation.save("shape_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![The shape rotation](shape-rotation.png)

## **3D‑Kanten‑Effekte hinzufügen**

Verwende [Shape.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/three_d_format/) um einer Form Tiefe und abgeschrägte Kanten zu verleihen. Dieses Beispiel erstellt eine grüne Ellipse mit einer orangefarbenen Kontur, setzt [ThreeDFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/depth/) auf 4 Punkte und wendet über [ThreeDFormat.bevel_top](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/bevel_top/) einen kreisförmigen oberen Abschrägungsrand mit einer Breite und Höhe von 6 Punkten an. Eine frontale orthographische Kamera und eine Dreipunkt‑Beleuchtung machen den Abschrägung sichtbar.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.green
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.orange
    shape.line_format.width = 2.0
    shape.three_d_format.depth = 4
    shape.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    shape.three_d_format.bevel_top.height = 6
    shape.three_d_format.bevel_top.width = 6
    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.THREE_PT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP

    presentation.save("3D_bevel_effect.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![The 3D bevel effect](3D-bevel-effect.png)

## **3D‑Dreh‑Effekte hinzufügen**

Die 3D‑Ansicht einer Form wird durch ihre Kameraeinstellungen gesteuert. Dieses Beispiel verwendet [Camera.set_rotation](https://reference.aspose.com/slides/python-net/aspose.slides/camera/set_rotation/) mit Breitengrad‑, Längengrad‑ und Revolutionswinkeln von 40, 35 und 20 Grad. Es wählt über [Camera.camera_type](https://reference.aspose.com/slides/python-net/aspose.slides/camera/camera_type/) eine isometrische Kamera und über [LightRig.light_type](https://reference.aspose.com/slides/python-net/aspose.slides/lightrig/light_type/) eine ausgeglichene Beleuchtung, dann speichert das formatierte Rechteck.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    auto_shape.text_frame.text = "Hello, Aspose!"
    auto_shape.three_d_format.camera.camera_type = slides.CameraPresetType.ISOMETRIC_LEFT_UP
    auto_shape.three_d_format.camera.set_rotation(40, 35, 20)
    auto_shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED

    presentation.save("3D_rotation_effect.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![The 3D rotation effect](3D-rotation-effect.png)

## **Schwarz‑Weiß‑Darstellung für Formen steuern**

Die Eigenschaft [Shape.black_white_mode](https://reference.aspose.com/slides/python-net/aspose.slides/shape/black_white_mode/) gibt an, wie eine einzelne Form gerendert wird, wenn eine Präsentation im Schwarz‑Weiß‑Modus angezeigt oder verarbeitet wird. Sie aktiviert die Schwarz‑Weiß‑Anzeige nicht selbst und ändert die Füllung, Kontur oder andere Formatierungen der Form im normalen Farbmodus nicht.

Verwende einen Wert aus der Aufzählung [BlackWhiteMode](https://reference.aspose.com/slides/python-net/aspose.slides/blackwhitemode/), um das gewünschte Verhalten auszuwählen. Zum Beispiel lässt `AUTOMATIC` die Anwendung die Konvertierung wählen, `GRAY` und `LIGHT_GRAY` verwenden Grautöne, `BLACK_WHITE` nutzt nur Schwarz und Weiß, `BLACK` und `WHITE` erzwingen eine Einzelfarbe, `COLOR` erhält die normale Farbgebung und `HIDDEN` lässt die Form im Schwarz‑Weiß‑Modus wegfallen. `NOT_DEFINED` bedeutet, dass kein Form‑Ebene‑Modus zugewiesen ist.

Dieses Beispiel erstellt ein oranges Rechteck und setzt [Shape.black_white_mode](https://reference.aspose.com/slides/python-net/aspose.slides/shape/black_white_mode/) auf grau. Die gespeicherte Form behält ihre orange Füllung für die normale Farbanzeige bei und fordert Graufärbung von Anwendungen, die Schwarz‑Weiß‑Anzeigeeinstellungen berücksichtigen:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.orange
    shape.black_white_mode = slides.BlackWhiteMode.GRAY

    presentation.save("shape_black_white_mode.pptx", slides.export.SaveFormat.PPTX)
```

Im normalen Farbmodus behält das Rechteck seine orange Füllung. In einem Schwarz‑Weiß‑Anzeige‑Workflow nutzt es Graufärbung, weil sein Modus auf `GRAY` gesetzt ist. Das ermöglicht, eine Folie in Vollfarbe zu erhalten und gleichzeitig ein unterschiedliches Erscheinungsbild für Druck, Vorschau oder andere Workflows zu definieren, die die Schwarz‑Weiß‑Anzeigeeinstellungen der Präsentation berücksichtigen.

## **Formatierung zurücksetzen**

Verwende [Slide.reset](https://reference.aspose.com/slides/python-net/aspose.slides/slide/reset/) um Position, Größe und Formatierung von Folien‑Platzhaltern anhand ihrer zugehörigen Layout‑Platzhalter wiederherzustellen. Dieses Beispiel benötigt eine vorhandene Präsentation mit layout‑verknüpften Platzhaltern und setzt jede Folie zurück, bevor sie gespeichert wird. Formen ohne entsprechende Layout‑Platzhalter werden nicht zurückgesetzt.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    for slide in presentation.slides:
        slide.reset()

    presentation.save("reset_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Wirkt sich die Formatierung von Formen auf die endgültige Präsentationsdateigröße aus?**

Farben, Linienstile und Effekt‑Einstellungen fügen im Allgemeinen wenig Daten hinzu im Vergleich zu eingebetteten Bildern und Medien. Bildfüllungen können die Dateigröße erhöhen, weil ihre Bilder in der Präsentation gespeichert werden.

**Wie kann ich Formen auf einer Folie erkennen, die identische Formatierung besitzen, um sie zu gruppieren?**

Vergleiche die wichtigsten Formatierungseigenschaften jeder Form – Füllung, Linie und Effekte. Stimmen alle entsprechenden Werte überein, betrachte ihre Stile als identisch und gruppiere die Formen logisch, was die spätere Stilverwaltung vereinfacht.

**Kann ich ein Set benutzerdefinierter Formstile in einer separaten Datei zur Wiederverwendung in anderen Präsentationen speichern?**

Ja. Speichere Beispiel­formen mit den gewünschten Stilen in einem Vorlagen‑Slide‑Deck oder einer .POTX‑Vorlagendatei. Beim Erstellen einer neuen Präsentation öffne die Vorlage, klone die benötigten gestalteten Formen und wende deren Formatierung dort an, wo sie benötigt wird.