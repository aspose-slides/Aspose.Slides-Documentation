---
title: "PowerPoint-Formen in Python über Java formatieren"
linktitle: "Formformatierung"
type: docs
weight: 20
url: /de/python-java/shape-formatting/
keywords:
- "Form formatieren"
- "Linie formatieren"
- "Skizzen‑Effekt"
- "Skizzenformlinie"
- "Verbindungsstil formatieren"
- "Verlaufsfüllung"
- "Musterfüllung"
- "Bildfüllung"
- "Texturfüllung"
- "Einfarbige Füllung"
- "Formtransparenz"
- "Schwarz‑Weiß‑Darstellung von Formen"
- "Graustufen‑Darstellung von Formen"
- "Form drehen"
- "3D‑Stufen‑Effekt"
- "3D‑Rotations‑Effekt"
- "Formatierung zurücksetzen"
- "PowerPoint"
- "Präsentation"
- "Python"
- "Java"
- "Aspose.Slides"
description: "Erfahren Sie, wie Sie PowerPoint‑Formen in Python über Java mit Aspose.Slides formatieren – füllen, Linien und Effektstile für PPT‑ und PPTX‑Dateien präzise und vollständig steuern."
---
## **Einführung**

Formatiere Formen in PowerPoint, indem du ihre Konturen, Füllungen und Effekte anpasst. Aspose.Slides für Python via Java ermöglicht die programmgesteuerte Steuerung dieser Einstellungen, einschließlich Transparenz, Drehung und 3D-Formatierung.

![Formatiermöglichkeiten für Formen in PowerPoint](format-shape-powerpoint.png)

Aspose.Slides für Python via Java bietet Klassen und Methoden, mit denen du Formen formatieren kannst, indem du dieselben Optionen wie in PowerPoint nutzt.

## **Linien formatieren**

Verwende [Shape.getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat) um die Kontur einer Form zu steuern. Dieses Beispiel erzeugt ein nicht gefülltes Rechteck mit einer blauen, gestrichelten Kontur. [LineFormat.setStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setStyle) wählt eine dick-dünn Verbundlinie, während [LineFormat.setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setWidth) die Breite auf 7 Punkte festlegt und [LineFormat.setDashStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setDashStyle) das Strichmuster auswählt.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineDashStyle, LineStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getLineFormat().setStyle(LineStyle.ThickThin)
    shape.getLineFormat().setWidth(7)
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash)
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    presentation.save("formatted_lines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Das Ergebnis:

![Die formatierten Linien in der Präsentation](formatted-lines.png)

### **Benutzerdefinierte Linienmuster festlegen**

Verwende [LineFormat.setCustomDashPattern](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setCustomDashPattern), wenn vordefinierte Linienstile nicht die benötigten Strichlängen und Lücken bieten, zum Beispiel für Marken‑Konturen oder technische Diagramme. Das Zuweisen eines Musters ändert den Strichstil der Linie automatisch zu [LineDashStyle.Custom](https://reference.aspose.com/slides/python-java/aspose.slides/linedashstyle/).

Array‑Einträge wechseln zwischen Strich‑ und Lückenlängen, beginnend mit einem Strich. Jeder Wert ist ein Vielfaches der Linienbreite: `[4, 2]` bei einer Breite von 3 Punkten erzeugt einen 12‑Punkt‑Strich, gefolgt von einer 6‑Punkt‑Lücke. Verwende Paare aus endlichen, nicht‑negativen Werten, um vollständige Strich‑und‑Lücken‑Segmente zu definieren. Das Beispiel verwendet positive Werte, damit jeder Strich und jede Lücke sichtbar bleibt.

Dieses Beispiel erstellt fünf blaue Linien mit gleicher Länge und flachen Enden. Die ersten drei vergleichen Muster bei einer Breite von 3 Punkten. Die vierte wiederholt das erste Muster bei doppelter Breite und verdoppelt dabei sowohl die Strich‑ als auch die Lückenlängen. Die fünfte wechselt von einem benutzerdefinierten Muster zu einer durchgezogenen Linie.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineArrowheadStyle, LineCapStyle, LineDashStyle, Presentation, SaveFormat, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(600, 300, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    patterns = [
        [4, 2],
        [1, 2],
        [6, 2, 1, 2],
        [4, 2],
        [4, 2]
    ]

    for i, pattern in enumerate(patterns):
        line = slide.getShapes().addAutoShape(ShapeType.Line, 50, 50 + i * 50, 500, 0)
        line.getLineFormat().setWidth(6 if i == 3 else 3)
        line.getLineFormat().getFillFormat().setFillType(FillType.Solid)
        color = Color(0, 0, 139)
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(color)
        line.getLineFormat().setCapStyle(LineCapStyle.Flat)
        line.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.None_)
        line.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.None_)
        line.getLineFormat().setCustomDashPattern(jpype.JArray(jpype.JFloat)(pattern))

    # Setze die letzte Linie auf einen durchgezogenen Stil.
    slide.getShapes().get_Item(4).getLineFormat().setDashStyle(LineDashStyle.Solid)

    presentation.save("custom_dash_patterns.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Um stattdessen zu einem vordefinierten gestrichelten Stil zurückzukehren, übergebe [LineDashStyle.Dash](https://reference.aspose.com/slides/python-java/aspose.slides/linedashstyle/) an [LineFormat.setDashStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setDashStyle). Der ausgewählte Stil steuert das Aussehen der Linie.

Das Ergebnis in PowerPoint von oben nach unten: **{4, 2}, 3 Pt**; **{1, 2}, 3 Pt**; **{6, 2, 1, 2}, 3 Pt**; **{4, 2}, 6 Pt**; und **Solid, 3 Pt**.

![Drei benutzerdefinierte Strichmuster, eine breitere Linie mit dem ersten Muster und eine durchgezogene Linie in PowerPoint](custom-dash-patterns.png)

### **Linienenden festlegen**

Verwende [LineFormat.setCapStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setCapStyle), um die Enden einer offenen Linie festzulegen. Die Klasse [LineCapStyle](https://reference.aspose.com/slides/python-java/aspose.slides/linecapstyle/) bietet drei explizite Endstil‑arten:

- `Flat`: Der Strich endet am Endpunkt.
- `Round`: Eine halbrunde Endung reicht über den Endpunkt hinaus um die halbe Linienbreite.
- `Square`: Eine quadratische Endung reicht über den Endpunkt hinaus um die halbe Linienbreite.

Die Klasse enthält außerdem `NotDefined`, was bedeutet, dass kein Endstil explizit zugewiesen ist.

Enden unterscheiden sich von Pfeilspitzen, die Symbole an Linienenden hinzufügen, und von Verbindungen, die Ecken zwischen Linienelementen steuern. Dieses Beispiel deaktiviert Pfeilspitzen über [LineFormat.setBeginArrowheadStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setBeginArrowheadStyle) und [LineFormat.setEndArrowheadStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setEndArrowheadStyle), sodass nur die Endformen verglichen werden.

Das folgende Beispiel erzeugt drei ansonsten identische horizontale Linien, 20 Punkte breit. Von oben nach unten verwenden sie flache, runde und quadratische Enden. Ihre Endpunkte haben dieselben Horizontal‑Koordinaten; die runden und quadratischen Enden reichen 10 Punkte über jeden Endpunkt hinaus.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineArrowheadStyle, LineCapStyle, LineDashStyle, Presentation, SaveFormat, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(500, 240, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    cap_styles = [LineCapStyle.Flat, LineCapStyle.Round, LineCapStyle.Square]

    for i, cap_style in enumerate(cap_styles):
        line = slide.getShapes().addAutoShape(ShapeType.Line, 100, 50 + i * 70, 300, 0)
        line.getLineFormat().setWidth(20)
        line.getLineFormat().getFillFormat().setFillType(FillType.Solid)
        color = Color(0, 0, 139)
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(color)
        line.getLineFormat().setDashStyle(LineDashStyle.Solid)
        line.getLineFormat().setCapStyle(cap_style)
        line.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.None_)
        line.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.None_)

    presentation.save("line_caps.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Das Ergebnis in PowerPoint von oben nach unten: **Flat**, **Round** und **Square**.

![Flache, runde und quadratische Enden bei identischen dicken Linien in PowerPoint](line-caps.png)

## **Skizze‑Effekte auf Formlinien anwenden**

Ein Skizzen‑Effekt lässt eine Formlinie handgezeichnet wirken. Verwende [Shape.getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat), um die Linieneinstellungen zu erhalten, [LineFormat.getSketchFormat](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getSketchFormat), um die Skizzen‑Einstellungen zu erhalten, und [SketchFormat.setSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/sketchformat/#setSketchType), um einen Wert aus der Klasse [LineSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/) auszuwählen.

Der folgende Python‑Code zeigt, wie man einen [LineSketchType.Curved](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/)‑Effekt anwendet, den explizit zugewiesenen Wert ausliest und den Effekt mit [LineSketchType.None_](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/) entfernt:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LineSketchType, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100)

    sketch_format = shape.getLineFormat().getSketchFormat()
    sketch_format.setSketchType(LineSketchType.Curved)
    explicit_sketch_type = sketch_format.getSketchType()
    print("Explicit sketch type:", explicit_sketch_type)
    sketch_format.setSketchType(LineSketchType.None_)
finally:
    presentation.dispose()
```

Der von [SketchFormat.getSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/sketchformat/#getSketchType) zurückgegebene Wert repräsentiert die direkt an die Form zugewiesene Einstellung. Wenn die Linienformatierung von einem Thema, einer Master‑Folie oder einer Layout‑Folie vererbt werden kann, verwende [LineFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getEffective) und lies den Skizzentyp aus der zurückgegebenen effektiven Linienformatierung, wie unten gezeigt. Der effektive Wert spiegelt die tatsächlich angewandte Formatierung wider, nachdem die Vererbung aufgelöst wurde. Dieses Beispiel erfordert eine vorhandene Präsentation mit mindestens einer Form auf der ersten Folie und gibt beide Werte aus:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)

    line_format = shape.getLineFormat()
    explicit_sketch_type = line_format.getSketchFormat().getSketchType()
    effective_line_format = line_format.getEffective()
    effective_sketch_type = effective_line_format.getSketchFormat().getSketchType()

    print("Explicit sketch type:", explicit_sketch_type)
    print("Effective sketch type:", effective_sketch_type)
finally:
    presentation.dispose()
```

## **Verbindungs­stile formatieren**

Hier sind die drei Optionen für Verbindungs‑typen:

* Round
* Miter
* Bevel

Der Verbindungsstil bestimmt, wie zwei Kontursegmente an einer Ecke zusammenstoßen. Verwende **Round** für abgerundete Ecken, **Miter** für spitze Ecken oder **Bevel** für abgeflachte Ecken.

![Der Verbindungsstil in der Präsentation](join-style-powerpoint.png)

Dieses Beispiel erstellt drei schwarze Rechtecke mit blauen Konturen von 15 Punkten Breite. Es verwendet [LineFormat.setJoinStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setJoinStyle), um die miter, bevel und round Werte von [LineJoinStyle](https://reference.aspose.com/slides/python-java/aspose.slides/linejoinstyle/) jeweils zu setzen, um zu vergleichen, wie die Ecken gezeichnet werden.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineJoinStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    miter_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75)
    bevel_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75)
    round_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75)

    miter_shape.getFillFormat().setFillType(FillType.Solid)
    miter_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    bevel_shape.getFillFormat().setFillType(FillType.Solid)
    bevel_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    round_shape.getFillFormat().setFillType(FillType.Solid)
    round_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    miter_shape.getLineFormat().setWidth(15)
    bevel_shape.getLineFormat().setWidth(15)
    round_shape.getLineFormat().setWidth(15)

    miter_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    miter_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    bevel_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    bevel_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    round_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    round_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    miter_shape.getLineFormat().setJoinStyle(LineJoinStyle.Miter)
    bevel_shape.getLineFormat().setJoinStyle(LineJoinStyle.Bevel)
    round_shape.getLineFormat().setJoinStyle(LineJoinStyle.Round)

    miter_shape.getTextFrame().setText("Miter Join Style")
    bevel_shape.getTextFrame().setText("Bevel Join Style")
    round_shape.getTextFrame().setText("Round Join Style")

    presentation.save("join_styles.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Miter‑Verbindungen an spitzen Ecken begrenzen**

Verwende [LineFormat.setMiterLimit](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setMiterLimit) zusammen mit [LineFormat.setJoinStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setJoinStyle), das auf [LineJoinStyle.Miter](https://reference.aspose.com/slides/python-java/aspose.slides/linejoinstyle/) gesetzt ist, um zu begrenzen, wie weit eine spitze Ecke ausdehnen kann.

Das Limit ist ein Verhältnis des Abstands zwischen den inneren und äußeren Ecken der Verbindung zur Linienbreite. Zum Beispiel erlaubt ein Wert von `8` eine Miter‑Länge von bis zu achtfacher Linienbreite; es ist keine Messgröße in Punkten. Wenn die Ecke das Limit überschreiten würde, verwendet PowerPoint an dieser Ecke eine abgeschrägte Verbindung. Ein größeres Limit erlaubt schärfere Spitzen. Die Einstellung wirkt sich nur auf Miter‑Verbindungen aus, und eine Änderung hat keine sichtbare Auswirkung, solange die Ecke innerhalb beider Limits bleibt.

Dieses Beispiel erstellt zwei identische, nicht gefüllte Dreiecke mit Konturen von 20 Punkten Breite. Das linke Dreieck verwendet ein Limit von `2`, das rechte von `8`. Jedes Dreieck ist 80 Punkte breit und 160 Punkte hoch, was seinem oberen Eck ein Miter‑Längen‑zu‑Linienbreite‑Verhältnis von etwa `4.12` verleiht. Folglich schlägt PowerPoint die linke Spitze ab und behält die rechte Spitze bei.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineJoinStyle, Presentation, SaveFormat, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(500, 320, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    miter_limits = [2.0, 8.0]

    for i, miter_limit in enumerate(miter_limits):
        triangle = slide.getShapes().addAutoShape(ShapeType.Triangle, 90 + i * 240, 110, 80, 160)
        triangle.getFillFormat().setFillType(FillType.NoFill)
        triangle.getLineFormat().setWidth(20)
        triangle.getLineFormat().getFillFormat().setFillType(FillType.Solid)
        color = Color(0, 0, 139)
        triangle.getLineFormat().getFillFormat().getSolidFillColor().setColor(color)
        triangle.getLineFormat().setJoinStyle(LineJoinStyle.Miter)
        triangle.getLineFormat().setMiterLimit(miter_limit)

    presentation.save("miter_limits.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Das Ergebnis in PowerPoint: **Miter limit 2** links und **miter limit 8** rechts.

![Ein abgeflachter Scheitel mit Miter‑Limit 2 und ein spitzer Scheitel mit Miter‑Limit 8 in PowerPoint](miter-limits.png)

## **Verlaufsfüllung**

Eine Verlaufsfüllung mischt Farben über eine Form hinweg. Dieses Beispiel füllt eine Ellipse mit einem linearen Verlauf im 45‑Grad‑Winkel von Rot nach Violett unter Verwendung von [FillFormat.getGradientFormat](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getGradientFormat). Die Methode [GradientStopCollection.addPresetColor](https://reference.aspose.com/slides/python-java/aspose.slides/gradientstopcollection/#addPresetColor) platziert die Farb‑Stops bei 0 und 1, dem Beginn bzw. Ende des Verlaufs. Das Löschen der vorhandenen Stops stellt sicher, dass nur diese beiden Farben verwendet werden.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, GradientShape, Presentation, PresetColor, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75)
    shape.getFillFormat().setFillType(FillType.Gradient)
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear)
    shape.getFillFormat().getGradientFormat().setLinearGradientAngle(45)
    shape.getFillFormat().getGradientFormat().getGradientStops().clear()
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0, PresetColor.Purple)
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0.0, PresetColor.Red)

    presentation.save("gradient_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Das Ergebnis:

![Die Ellipse mit Verlaufsfüllung](gradient-fill.png)

Wenn ein Verlauf in einem exportierten Bild anders aussieht als in PowerPoint, siehe [Choose a Gradient Rendering Style](/slides/de/python-java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Du kannst einen Render‑Stil auswählen, ohne die im Dokument gespeicherte Verlaufsfüllung zu ändern.

### **Linear‑Verlauf‑Winkel festlegen**

Verwende [GradientFormat.setLinearGradientAngle](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/#setLinearGradientAngle), um die Ausrichtung einer [GradientShape.Linear](https://reference.aspose.com/slides/python-java/aspose.slides/gradientshape/)‑Füllung zu steuern. Der Winkel wird in Grad gemessen und nimmt im Uhrzeigersinn zu: `0` verläuft von links nach rechts, `90` von oben nach unten, `180` von rechts nach links und `270` von unten nach oben. Bruch‑Winkel werden unterstützt. Endliche Winkel außerhalb `[0, 360)` werden auf eine Umdrehung normalisiert; zum Beispiel wird `-45` zu `315` und `360` zu `0`.

Dieses Beispiel erstellt sechs Rechtecke mit identischen Rot‑, Grün‑ und Blau‑Stops an den Positionen `0`, `0.5` und `1`. Skalierung ist deaktiviert, damit der Winkel unabhängig von den Proportionen der Rechtecke verglichen werden kann. Die Winkel von links nach rechts sind in der ersten Reihe `0`, `45` und `90` und in der zweiten Reihe `135`, `180` und `270`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, GradientShape, NullableBool, Presentation, SaveFormat, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(720, 400, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    angles = [0, 45, 90, 135, 180, 270]

    for i, angle in enumerate(angles):
        x = 30 + (i % 3) * 230
        y = 30 + (i // 3) * 190

        shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, y, 200, 150)
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
        shape.getFillFormat().setFillType(FillType.Gradient)

        gradient = shape.getFillFormat().getGradientFormat()
        gradient.setGradientShape(GradientShape.Linear)
        gradient.getGradientStops().clear()
        gradient.getGradientStops().add(0, Color.RED)
        gradient.getGradientStops().add(0.5, Color.GREEN)
        gradient.getGradientStops().add(1, Color.BLUE)
        gradient.setLinearGradientScaled(NullableBool.False_)
        gradient.setLinearGradientAngle(angle)

    presentation.save("linear_gradient_angles.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Das Ergebnis in PowerPoint:

![Lineare Verläufe bei 0°, 45° und 90° in der oberen Reihe und 135°, 180° und 270° in der unteren Reihe](linear-gradient-angles.png)

### **Linearen Verlauf mit der Form skalieren**

[GradientFormat.setLinearGradientScaled](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/#setLinearGradientScaled) akzeptiert einen [NullableBool](https://reference.aspose.com/slides/python-java/aspose.slides/nullablebool/). Setze ihn explizit auf `False_`, um den geometrischen Verlaufswinkel beizubehalten, wenn sich die Proportionen der Form ändern, oder auf `True_`, um den Verlauf mit Breite und Höhe der Form zu skalieren. Bei aktivierter Skalierung kann sich der sichtbare Winkel vom zugewiesenen Winkel bei einer nicht‑quadratischen Form unterscheiden.

Das folgende Beispiel verwendet einen `45`‑Grad‑Winkel und dieselben Farb‑Stops wie beim Winkel‑Vergleich. Die linke Spalte verwendet `False_`; die rechte Spalte verwendet `True_`. Jede Spalte enthält ein breites Rechteck über einem hohen Rechteck. Beide beginnen mit denselben breiten Abmessungen; das Ändern von Breite und Höhe des zweiten Rechtecks zeigt, wie die Füllung auf Größenänderungen reagiert, ohne die Verlaufseinstellungen zu ändern.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, GradientShape, NullableBool, Presentation, SaveFormat, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(720, 460, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    scaling_options = [NullableBool.False_, NullableBool.True_]

    for column, scaled in enumerate(scaling_options):
        for row in range(2):
            x = 30 + column * 360
            y = 30 if row == 0 else 150

            shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, y, 300, 90)
            shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
            shape.getFillFormat().setFillType(FillType.Gradient)

            gradient = shape.getFillFormat().getGradientFormat()
            gradient.setGradientShape(GradientShape.Linear)
            gradient.getGradientStops().clear()
            gradient.getGradientStops().add(0, Color.RED)
            gradient.getGradientStops().add(0.5, Color.GREEN)
            gradient.getGradientStops().add(1, Color.BLUE)
            gradient.setLinearGradientAngle(45)
            gradient.setLinearGradientScaled(scaled)

            if row == 1:
                shape.setWidth(90)
                shape.setHeight(280)

    presentation.save("linear_gradient_scaling.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Das Ergebnis in PowerPoint, links ohne Skalierung und rechts mit Skalierung:

![Breite und hohe Rechtecke mit einem 45‑Grad‑Verlauf, Vergleich LinearGradientScaled False links und True rechts](linear-gradient-scaling.png)

Bei deaktivierter Skalierung behalten die diagonalen Farbbänder in beiden Rechtecken die gleiche Ausrichtung. Bei aktivierter Skalierung strecken sich die Bänder gemäß den Proportionen der Form. Dies hilft, den Verlauf einer Vorlage wiederzugeben, wenn eine Form an eine andere Größe angepasst wird. Auf einem Quadrat ändert das Aktivieren der Skalierung das Aussehen dieses `45`‑Grad‑Verlaufs nicht.

Sowohl Winkel‑ als auch Skalierungseinstellungen gelten für lineare Verläufe. Sie steuern keine [GradientShape.Radial or GradientShape.Rectangle](https://reference.aspose.com/slides/python-java/aspose.slides/gradientshape/)‑Füllungen.

### **Winkel mit Verlauf‑Richtung kombinieren**

[GradientFormat.setGradientDirection](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/#setGradientDirection) wählt einen Verlauf‑Stil aus der Klasse [GradientDirection](https://reference.aspose.com/slides/python-java/aspose.slides/gradientdirection/) aus; er ersetzt keinen numerischen Winkel. Für einen linearen Verlauf können die Eck‑Stile den Bereich verändern, über den die Farben verteilt werden, ohne den über [setLinearGradientAngle](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/#setLinearGradientAngle) zugewiesenen Winkel zu ändern. Behalte die Richtung unverändert, wenn du Winkel oder Skalierung vergleichst.

Das folgende Beispiel wendet dieselben Einstellungen in unterschiedlicher Reihenfolge an. Die beiden Rechtecke sehen identisch aus: Das Zuweisen der Richtung vor oder nach dem Winkel ändert das Ergebnis nicht.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, GradientDirection, GradientShape, NullableBool, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    for i in range(2):
        shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30 + i * 140, 320, 100)
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
        shape.getFillFormat().setFillType(FillType.Gradient)

        gradient = shape.getFillFormat().getGradientFormat()
        gradient.setGradientShape(GradientShape.Linear)
        gradient.getGradientStops().clear()
        gradient.getGradientStops().add(0, Color.RED)
        gradient.getGradientStops().add(0.5, Color.GREEN)
        gradient.getGradientStops().add(1, Color.BLUE)
        gradient.setLinearGradientScaled(NullableBool.True_)

        if i == 0:
            gradient.setGradientDirection(GradientDirection.FromCorner1)
            gradient.setLinearGradientAngle(30)
        else:
            gradient.setLinearGradientAngle(30)
            gradient.setGradientDirection(GradientDirection.FromCorner1)

    presentation.save("linear_gradient_direction.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Musterfüllung**

Eine Musterfüllung wendet ein zweifarbiges Design wie Punkte, Streifen oder Karos an. Dieses Beispiel verwendet [PatternFormat.setPatternStyle](https://reference.aspose.com/slides/python-java/aspose.slides/patternformat/#setPatternStyle), um ein Gitter‑Muster auszuwählen. [PatternFormat.getBackColor](https://reference.aspose.com/slides/python-java/aspose.slides/patternformat/#getBackColor) liefert den hellgrauen Hintergrund, und [PatternFormat.getForeColor](https://reference.aspose.com/slides/python-java/aspose.slides/patternformat/#getForeColor) liefert die gelbe Musterfarbe.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, PatternStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)
    shape.getFillFormat().setFillType(FillType.Pattern)
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis)
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY)
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW)

    presentation.save("pattern_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Das Ergebnis:

![Das Rechteck mit Musterfüllung](pattern-fill.png)

## **Bildfüllung**

Eine Bildfüllung verwendet ein Bild innerhalb einer Form. Dieses Beispiel erfordert ein lokales Bild und nutzt [Images.fromFile](https://reference.aspose.com/slides/python-java/aspose.slides/images/#fromFile), um es in die Bild‑Sammlung der Präsentation zu laden. Das Setzen von [PictureFillFormat.setPictureFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setPictureFillMode) auf den gekachelten Modus wiederholt das Bild innerhalb des Rechtecks. Das hier verwendete Quellbild ist unten zu sehen:

![Das Lotus‑Bild](lotus.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Images, PictureFillMode, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130)
    shape.getFillFormat().setFillType(FillType.Picture)
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile)

    image = Images.fromFile("lotus.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture)

    presentation.save("picture_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Das Ergebnis:

![Die Form mit Bildfüllung](picture-fill.png)

### **Bild kacheln als Textur**

Wenn du ein gekacheltes Bild als Textur festlegen und das Kachel‑Verhalten anpassen möchtest, kannst du die folgenden Methoden der Klasse [PictureFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/) verwenden:

- [setPictureFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setPictureFillMode): Legt den Bildfüllmodus fest – entweder `Tile` oder `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileAlignment): Gibt die Ausrichtung der Kacheln innerhalb der Form an.
- [setTileFlip](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileFlip): Steuert, ob die Kachel horizontal, vertikal oder beides gespiegelt wird.
- [setTileOffsetX](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileOffsetX): Setzt den horizontalen Versatz der Kachel (in Punkten) vom Ursprung der Form.
- [setTileOffsetY](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileOffsetY): Setzt den vertikalen Versatz der Kachel (in Punkten) vom Ursprung der Form.
- [setTileScaleX](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileScaleX): Definiert die horizontale Skalierung der Kachel als Prozentsatz.
- [setTileScaleY](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileScaleY): Definiert die vertikale Skalierung der Kachel als Prozentsatz.

Dieses Beispiel erfordert ein lokales Bild und konfiguriert [PictureFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/) so, dass es bei 50 % seiner Originalgröße wiederholt wird. Offsets von −32 Punkten verschieben die Kacheln horizontal und vertikal; die Ausrichtung unten‑rechts und das Flippen in beide Richtungen bestimmen, wie die wiederholte Textur angeordnet wird.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Images, PictureFillMode, Presentation, RectangleAlignment, SaveFormat, ShapeType, TileFlip

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)

    shape = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95)
    shape.getFillFormat().setFillType(FillType.Picture)

    source_image = Images.fromFile("lotus.png")
    try:
        presentation_image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_fill_format = shape.getFillFormat().getPictureFillFormat()
    picture_fill_format.getPicture().setImage(presentation_image)
    picture_fill_format.setPictureFillMode(PictureFillMode.Tile)
    picture_fill_format.setTileOffsetX(-32)
    picture_fill_format.setTileOffsetY(-32)
    picture_fill_format.setTileScaleX(50)
    picture_fill_format.setTileScaleY(50)
    picture_fill_format.setTileAlignment(RectangleAlignment.BottomRight)
    picture_fill_format.setTileFlip(TileFlip.FlipBoth)

    presentation.save("tile.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Das Ergebnis:

![Die Kachel‑Optionen](tile-options.png)

## **Einfarbige Füllung**

Eine einfarbige Füllung verleiht einer Form eine einheitliche Farbe. Dieses Beispiel verwendet [FillFormat.setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType), um den einschichtigen Füllmodus zu setzen, und weist Gelb über [FillFormat.getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor) zu, dann speichert das Rechteck in einer Präsentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW)

    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Das Ergebnis:

![Die Form mit einfarbiger Füllung](solid-color-fill.png)

### **Farben kopieren und dabei Themen‑Referenzen beibehalten**

Verwende [ColorFormat.copyFrom](https://reference.aspose.com/slides/python-java/aspose.slides/colorformat/#copyFrom), um eine Farbangabe zu kopieren, einschließlich ihres Farbtyps, Themen‑Referenz und Transformationen. Das ist nützlich, wenn du eine Füllfarbe zwischen Formen überträgst, die weiterhin dem Präsentationsthema folgen sollen. Die Methode kopiert nur die Farbe: Sie kopiert weder den Fülltyp, die Kontur noch andere Form‑Formatierungen. Setze den Fülltyp des Ziels explizit mit [FillFormat.setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType).

Dieses Beispiel erstellt drei Rechtecke von links nach rechts: die Quelle, eine themen‑bewusste Kopie und eine feste RGB‑Kopie. Die Quelle verwendet [ColorFormat.setSchemeColor](https://reference.aspose.com/slides/python-java/aspose.slides/colorformat/#setSchemeColor), um die erste Akzentfarbe zu referenzieren und fügt über [ColorOperationCollection.add](https://reference.aspose.com/slides/python-java/aspose.slides/coloroperationcollection/#add) einen Farbton hinzu. Die RGB‑Kopie verwendet die effektive Füllfarbe der Quelle, sodass alle drei zunächst identisch aussehen. Das Aufrufen von [ColorFormat.setColor](https://reference.aspose.com/slides/python-java/aspose.slides/colorformat/#setColor) setzt einen festen RGB‑Wert und löscht vorhandene Farb‑Transformationen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorTransformOperation, FillType, ImageFormat, Presentation, SaveFormat, SchemeColor, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(660, 220, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    accent_color = Color(65, 105, 225)
    presentation.getMasterTheme().getColorScheme().getAccent1().setColor(accent_color)

    source = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 40, 180, 140)
    theme_copy = slide.getShapes().addAutoShape(ShapeType.Rectangle, 240, 40, 180, 140)
    rgb_copy = slide.getShapes().addAutoShape(ShapeType.Rectangle, 450, 40, 180, 140)

    for shape in (source, theme_copy, rgb_copy):
        shape.getFillFormat().setFillType(FillType.Solid)
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

    source_color = source.getFillFormat().getSolidFillColor()
    source_color.setSchemeColor(SchemeColor.Accent1)
    source_color.getColorTransform().add(ColorTransformOperation.Tint, 0.75)

    theme_copy.getFillFormat().getSolidFillColor().copyFrom(source_color)
    rgb_copy.getFillFormat().getSolidFillColor().setColor(source.getFillFormat().getEffective().getSolidFillColor())

    before = slide.getImage(1.0, 1.0)
    try:
        before.save("color-copy-before.png", ImageFormat.Png)
    finally:
        before.dispose()

    # Themenreferenzen folgen der neuen Akzentfarbe; der feste RGB-Wert nicht.
    accent_color = Color(255, 69, 0)
    presentation.getMasterTheme().getColorScheme().getAccent1().setColor(accent_color)

    after = slide.getImage(1.0, 1.0)
    try:
        after.save("color-copy-after.png", ImageFormat.Png)
    finally:
        after.dispose()
    presentation.save("copied_colors.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Vor der Themenänderung stimmen alle drei Füllungen überein:

![Quelle, copyFrom‑Ziel und feste RGB‑Ziel mit identischen blauen Füllungen](color-copy-before.png)

Nach der Themenänderung folgen die Quelle und die themen‑bewusste Kopie der neuen Akzentfarbe und behalten ihren Farbton bei. Die feste RGB‑Kopie bleibt blau:

![Quelle und copyFrom‑Ziel mit orangefarbenen Füllungen, während das feste RGB‑Ziel blau bleibt](color-copy-after.png)

Die kopierte Definition ist unabhäng­ig von der Quelle. Ein späteres Ändern der Themen‑Referenz der Quelle, das Zuweisen einer anderen Farbe oder das Hinzufügen bzw. Entfernen ihrer Transformationen ändert das Ziel nicht. Eine Themen‑Änderung wirkt sich weiterhin auf beide Formen aus, weil jede unabhängig auf dieselbe Themen‑Farbe verweist.

Das Speichern und erneute Öffnen der PPTX bewahrt den Typ der kopierten Farbe, der über [ColorFormat.getColorType](https://reference.aspose.com/slides/python-java/aspose.slides/colorformat/#getColorType) zurückgegeben wird, die Themen‑Referenz und die Transformations‑Sammlung, die über [ColorFormat.getColorTransform](https://reference.aspose.com/slides/python-java/aspose.slides/colorformat/#getColorTransform) zurückgegeben wird; sie wird nicht in RGB flachgelegt.

Beim Kopieren zwischen verschiedenen Themen‑Kontexten, wie Präsentationen mit unterschiedlichen Akzent‑Paletten, wird die kopierte Referenz gegen das Thema des Ziels aufgelöst. Die gleiche Referenz und Transformationen können daher eine andere sichtbare Farbe erzeugen. Siehe [Presentation Theme](/slides/de/python-java/presentation-theme/) für weitere Informationen zur Konfiguration von Themen‑Farben.

## **Folienhintergrund als Formfüllung verwenden**

Verwende [AutoShape.setUseBackgroundFill](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/#setUseBackgroundFill), wenn eine Form dem Folienhintergrund entsprechen soll, zum Beispiel in einer Präsentationsvorlage. Setze den Fülltyp mit [FillFormat.setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) zuerst auf [FillType.NotDefined](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/), um eine explizite Füllung zu entfernen. Mit dieser Kombination verwendet die Form den Folienhintergrund anstelle ihrer Stil‑Füllung. Das Setzen des Flags allein entfernt keine vorhandene explizite Füllung.

Dies unterscheidet sich von [FillType.NoFill](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/): Die Hintergrund‑Füllung deckt Objekte hinter der Form mit dem entsprechenden Bereich des Folienhintergrunds ab, während keine Füllung diese Objekte sichtbar lässt. Ein Verlauf bleibt an der Folie ausgerichtet, anstatt in jeder Form neu zu starten.

Das folgende Beispiel erzeugt einen Master‑Hintergrund, der von der Folie geerbt wird, und platziert ein magentafarbenes Band hinter drei Rechtecken. Das linke Rechteck verwendet den Hintergrund, das mittlere hat keine Füllung, und das rechte wechselt von Hintergrund‑Füllung zu einer expliziten orangen Füllung.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, GradientShape, Presentation, SaveFormat, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(720, 400, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    # Den Farbverlauf vom Master übernehmen.
    slide.getBackground().setType(BackgroundType.NotDefined)
    slide.getLayoutSlide().getBackground().setType(BackgroundType.NotDefined)
    background = slide.getLayoutSlide().getMasterSlide().getBackground()
    background.setType(BackgroundType.OwnBackground)
    background.getFillFormat().setFillType(FillType.Gradient)
    gradient = background.getFillFormat().getGradientFormat()
    gradient.setGradientShape(GradientShape.Linear)
    gradient.setLinearGradientAngle(0)
    gradient.getGradientStops().clear()
    color = Color(0, 0, 139)
    gradient.getGradientStops().add(0, color)
    color = Color(135, 206, 250)
    gradient.getGradientStops().add(1, color)

    # Dieses Objekt zuerst hinzufügen, damit es hinter den Rechtecken erscheint.
    band = slide.getShapes().addAutoShape(ShapeType.Rectangle, 25, 150, 670, 100)
    band.getFillFormat().setFillType(FillType.Solid)
    band.getFillFormat().getSolidFillColor().setColor(Color.MAGENTA)
    band.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

    background_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 100, 160, 200)
    background_shape.getFillFormat().setFillType(FillType.NotDefined)
    background_shape.setUseBackgroundFill(True)

    no_fill_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 280, 100, 160, 200)
    no_fill_shape.getFillFormat().setFillType(FillType.NoFill)

    explicit_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 510, 100, 160, 200)
    explicit_shape.getFillFormat().setFillType(FillType.NotDefined)
    explicit_shape.setUseBackgroundFill(True)

    # Hintergrundfüllung deaktivieren, bevor eine explizite Füllung angewendet wird.
    explicit_shape.setUseBackgroundFill(False)
    explicit_shape.getFillFormat().setFillType(FillType.Solid)
    color = Color(255, 165, 0)
    explicit_shape.getFillFormat().getSolidFillColor().setColor(color)

    presentation.save("background_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Das Ergebnis, von links nach rechts: **background fill**, **no fill**, und **explicit fill**. Das magentafarbene Band wird von den linken und rechten Rechtecken verdeckt, bleibt aber durch das mittlere Rechteck sichtbar.

![Hintergrundfüllung, keine Füllung und explizite orange Füllung über einem magentafarbenen Band](background-fill.png)

Das gleiche Verhalten gilt für einen direkt auf der Folie definierten oder aus einem Layout geerbten Hintergrund. Die Form verwendet den aufgelösten Folienhintergrund; das Beispiel lässt sowohl den Folien‑ als auch den Layout‑Hintergrund undefiniert, sodass der Master ihn bereitstellt.

## **Transparenz festlegen**

Für eine einfarbige Füllung steuert die Alpha‑Komponente der Farbe die Deckkraft: 0 ist vollständig transparent und 255 völlig undurchsichtig. Dieses Beispiel verwendet einen Alpha‑Wert von 128 für ein gelbes Rechteck, wodurch es etwa zu 50 % transparent wird, sodass das darunterliegende Rechteck sichtbar bleibt. Die Farbe wird über [FillFormat.getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor) zugewiesen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    solid_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    transparent_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75)
    transparent_shape.getFillFormat().setFillType(FillType.Solid)
    color = Color(255, 255, 0, 128)
    transparent_shape.getFillFormat().getSolidFillColor().setColor(color)

    presentation.save("shape_transparency.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Das Ergebnis:

![Die transparente Form](shape-transparency.png)

## **Formen drehen**

Verwende [Shape.setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setRotation), um eine Form in der Folien‑Ebene zu drehen. Der Winkel wird in Grad gemessen; dieses Beispiel dreht ein Rechteck um 5 Grad im Uhrzeigersinn und speichert die Präsentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)
    shape.setRotation(5)

    presentation.save("shape_rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Das Ergebnis:

![Die Formdrehung](shape-rotation.png)

## **3D‑Stufen‑Effekte hinzufügen**

Verwende [Shape.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getThreeDFormat), um einer Form Tiefe und abgeschrägte Kanten zu geben. Dieses Beispiel erstellt eine grüne Ellipse mit einer orangenen Kontur, setzt die Tiefe mit [ThreeDFormat.setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setDepth) auf 4 Punkte und wendet über [ThreeDFormat.getBevelTop](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getBevelTop) eine kreisförmige obere Abschrägung mit Breite und Höhe von 6 Punkten an. Eine frontale orthografische Kamera und Drei‑Punkt‑Beleuchtung machen die Abschrägung sichtbar.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BevelPresetType, CameraPresetType, FillType, LightRigPresetType, LightingDirection, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    color = Color(0, 128, 0)
    shape.getFillFormat().getSolidFillColor().setColor(color)
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    color = Color(255, 165, 0)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(color)
    shape.getLineFormat().setWidth(2.0)
    shape.getThreeDFormat().setDepth(4)
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle)
    shape.getThreeDFormat().getBevelTop().setHeight(6)
    shape.getThreeDFormat().getBevelTop().setWidth(6)
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)

    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Das Ergebnis:

![Der 3D‑Stufeneffekt](3D-bevel-effect.png)

## **3D‑Rotations‑Effekte hinzufügen**

Die 3D‑Ansicht einer Form wird durch ihre Kamera‑Einstellungen gesteuert. Dieses Beispiel verwendet [Camera.setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#setRotation) mit Breitengrad‑, Längengrad‑ und Rotations‑Winkeln von 40, 35 bzw. 20 Grad. Es wählt über [Camera.setCameraType](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#setCameraType) eine isometrische Kamera und über [LightRig.setLightType](https://reference.aspose.com/slides/python-java/aspose.slides/lightrig/#setLightType) eine ausgewogene Beleuchtung, dann speichert das formatierte Rechteck.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, LightRigPresetType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)
    auto_shape.getTextFrame().setText("Hello, Aspose!")
    auto_shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp)
    auto_shape.getThreeDFormat().getCamera().setRotation(40, 35, 20)
    auto_shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced)

    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Das Ergebnis:

![Der 3D‑Rotations‑Effekt](3D-rotation-effect.png)

## **Schwarz‑Weiß‑Darstellung für Formen steuern**

Die Methode [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setBlackWhiteMode) gibt an, wie eine einzelne Form gerendert wird, wenn eine Präsentation in Schwarz‑Weiß‑Modus angezeigt oder verarbeitet wird. Sie aktiviert die Schwarz‑Weiß‑Anzeige nicht selbst und ändert die Füll‑, Linien‑ oder andere Formatierung der Form im normalen Farb‑Modus nicht.

Verwende einen Wert aus der Klasse [BlackWhiteMode](https://reference.aspose.com/slides/python-java/aspose.slides/blackwhitemode/), um das gewünschte Verhalten auszuwählen. Zum Beispiel lässt `Automatic` die Rendering‑Anwendung die Konvertierung wählen, `Gray` und `LightGray` verwenden Graustufen, `BlackWhite` nutzt nur Schwarz und Weiß, `Black` und `White` erzwingen eine einfarbige Darstellung, `Color` erhält die normale Färbung und `Hidden` lässt die Form im Schwarz‑Weiß‑Modus wegfallen. `NotDefined` bedeutet, dass kein Form‑Ebene‑Modus zugewiesen ist.

Dieses Beispiel erstellt ein orangefarbenes Rechteck und verwendet [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setBlackWhiteMode), um den Modus auf grau zu setzen. Die gespeicherte Form behält ihre orangefüllung für die normale Farbanzeige bei und fordert graue Färbung von Anwendungen an, die Schwarz‑Weiß‑Anzeigeeinstellungen honorieren:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BlackWhiteMode, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    color = Color(255, 165, 0)
    shape.getFillFormat().getSolidFillColor().setColor(color)
    shape.setBlackWhiteMode(BlackWhiteMode.Gray)

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Im normalen Farb‑Modus behält das Rechteck seine orangefüllung. In einem Schwarz‑Weiß‑Workflow verwendet es graue Färbung, weil sein Modus auf `Gray` gesetzt ist. So kannst du eine Voll‑Farb‑Folien erhalten und gleichzeitig ein separates Aussehen für Druck, Vorschau oder andere Workflows definieren, die die Schwarz‑Weiß‑Anzeige‑Einstellungen der Präsentation beachten.

## **Formatierung zurücksetzen**

Verwende [Slide.reset](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#reset), um Position, Größe und Formatierung von Folien‑Platzhaltern aus den entsprechenden Layout‑Platzhaltern wiederherzustellen. Dieses Beispiel erfordert eine vorhandene Präsentation mit layout‑verknüpften Platzhaltern und setzt jede Folie vor dem Speichern zurück. Formen ohne entsprechenden Layout‑Platzhalter werden nicht zurückgesetzt.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    for slide in presentation.getSlides():
        slide.reset()

    presentation.save("reset_formatting.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Beeinflusst die Formformatierung die endgültige Dateigröße der Präsentation?**

Farben, Linienstile und Effekt‑Einstellungen fügen im Allgemeinen wenig Daten im Vergleich zu eingebetteten Bildern und Medien hinzu. Bild‑Füllungen können die Dateigröße erhöhen, weil ihre Bilder in der Präsentation gespeichert werden.

**Wie kann ich Formen auf einer Folie erkennen, die identische Formatierung besitzen, um sie zu gruppieren?**

Vergleiche die wichtigsten Formatierungs‑Eigenschaften jeder Form – Füllung, Linie und Effekt‑Einstellungen. Stimmen alle entsprechenden Werte überein, betrachte die Stile als identisch und gruppiere die Formen logisch, was die spätere Stil‑Verwaltung vereinfacht.

**Kann ich ein Set benutzerdefinierter Formstile in einer separaten Datei speichern, um sie in anderen Präsentationen wiederzuverwenden?**

Ja. Speichere Beispiel‑Formen mit den gewünschten Stilen in einem Vorlagen‑Slide‑Deck oder einer .POTX‑Vorlagendatei. Beim Erstellen einer neuen Präsentation öffne die Vorlage, klone die benötigten gestylten Formen und wende deren Formatierung dort an, wo sie gebraucht wird.