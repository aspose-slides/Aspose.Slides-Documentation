---
title: PowerPoint-Formen in Python via Java formatieren
linktitle: Formformatierung
type: docs
weight: 20
url: /de/python-java/shape-formatting/
keywords:
- Form formatieren
- Linie formatieren
- Skizzeneffekt
- Skizzenformenlinie
- Verbindungsstil formatieren
- Verlaufsfüllung
- Musterfüllung
- Bildfüllung
- Texturfüllung
- Einfarbige Füllung
- Formtransparenz
- Schwarz‑Weiß‑Darstellung von Formen
- Graustufen‑Darstellung von Formen
- Form drehen
- 3D‑Kehl‑Effekt
- 3D‑Dreh‑Effekt
- Formatierung zurücksetzen
- PowerPoint
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint-Formen in Python via Java mit Aspose.Slides formatieren — Füll‑, Linien‑ und Effekt‑Stile für PPT‑ und PPTX‑Dateien präzise und vollständig steuern."
---
## **Einführung**

Formatiere Formen in PowerPoint, indem du deren Konturen, Füllungen und Effekte anpasst. Aspose.Slides für Python via Java ermöglicht die programmgesteuerte Kontrolle dieser Einstellungen, einschließlich Transparenz, Drehung und 3D-Formatierung.

![Formatiervorgänge für Formen in PowerPoint](format-shape-powerpoint.png)

Aspose.Slides für Python via Java stellt Klassen und Methoden bereit, mit denen du Formen mit denselben Optionen formatieren kannst, die in PowerPoint verfügbar sind.

## **Linien formatieren**

Verwende [Shape.getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat), um die Kontur einer Form zu steuern. Dieses Beispiel erstellt ein nicht ausgefülltes Rechteck mit einer blauen, gestrichelten Kontur. [LineFormat.setStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setStyle) wählt eine dick‑dünn zusammengesetzte Linie, während [LineFormat.setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setWidth) die Breite auf 7 Punkte setzt und [LineFormat.setDashStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setDashStyle) das Strichmuster auswählt.

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

### **Benutzerdefinierte Linienstrichmuster festlegen**

Verwende [LineFormat.setCustomDashPattern](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setCustomDashPattern), wenn vordefinierte Linienstile die benötigten Strich‑ und Lückenlängen nicht bieten, zum Beispiel für markenspezifische Konturen oder technische Diagramme. Das Zuweisen eines Musters ändert den Linienstrichstil automatisch zu [LineDashStyle.Custom](https://reference.aspose.com/slides/python-java/aspose.slides/linedashstyle/).

Array‑Einträge wechseln zwischen Strich‑ und Lückenlängen und beginnen mit einem Strich. Jeder Wert ist ein Vielfaches der Linienbreite: `[4, 2]` bei einer Breite von 3 Punkten erzeugt einen 12‑Punkte‑Strich gefolgt von einer 6‑Punkte‑Lücke. Verwende Paare aus endlichen, nichtnegativen Werten, um vollständige Strich‑und‑Lücken‑Segmente zu definieren. Das Beispiel verwendet positive Werte, damit jeder Strich und jede Lücke sichtbar bleibt.

Dieses Beispiel erstellt fünf blaue Linien mit gleicher Länge und flachen Enden. Die ersten drei vergleichen Muster bei einer Breite von 3 Punkten. Die vierte wiederholt das erste Muster bei doppelter Breite, wodurch sowohl Strich‑ als auch Lückenlänge verdoppelt werden. Die fünfte wechselt von einem benutzerdefinierten Muster zu einer durchgezogenen Linie.

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

    # Setze die letzte Linie auf einen durchgezogenen Stil zurück.
    slide.getShapes().get_Item(4).getLineFormat().setDashStyle(LineDashStyle.Solid)

    presentation.save("custom_dash_patterns.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Um stattdessen zu einem vordefinierten gestrichelten Stil zurückzukehren, übergebe [LineDashStyle.Dash](https://reference.aspose.com/slides/python-java/aspose.slides/linedashstyle/) an [LineFormat.setDashStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setDashStyle). Der ausgewählte Stil steuert das Aussehen der Linie.

Das Ergebnis in PowerPoint, von oben nach unten: **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; und **Solid, 3 pt**.

![Drei benutzerdefinierte Strichmuster, eine breitere Linie mit dem ersten Muster und eine durchgezogene Linie in PowerPoint](custom-dash-patterns.png)

### **Linienenden festlegen**

Verwende [LineFormat.setCapStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setCapStyle), um die Enden einer offenen Linie zu setzen. Die Klasse [LineCapStyle](https://reference.aspose.com/slides/python-java/aspose.slides/linecapstyle/) bietet drei explizite Endstil‑Optionen:

- `Flat`: Der Strich endet am Endpunkt.
- `Round`: Ein halbkreisförmiges Ende ragt halb so weit über den Endpunkt hinaus wie die Linienbreite.
- `Square`: Ein quadratisches Ende ragt halb so weit über den Endpunkt hinaus wie die Linienbreite.

Die Klasse enthält außerdem `NotDefined`, was bedeutet, dass kein Endstil explizit zugewiesen ist.

Enden unterscheiden sich von Pfeilspitzen, die Symbole an Linienenden hinzufügen, und von Verbindungen, die Ecken zwischen Linienstücken steuern. Dieses Beispiel deaktiviert Pfeilspitzen über [LineFormat.setBeginArrowheadStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setBeginArrowheadStyle) und [LineFormat.setEndArrowheadStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setEndArrowheadStyle), sodass nur die Endformen verglichen werden.

Das folgende Beispiel erstellt drei sonst identische horizontale Linien, 20 Punkte breit. Von oben nach unten verwenden sie flache, runde bzw. quadratische Enden. Ihre Endpunkte haben dieselben horizontalen Koordinaten; die runden und quadratischen Enden ragen jeweils 10 Punkte über jeden Endpunkt hinaus.

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

Das Ergebnis in PowerPoint, von oben nach unten: **Flat**, **Round** und **Square**.

![Flache, runde und quadratische Enden an identischen dicken Linien in PowerPoint](line-caps.png)

## **Skizzeeffekte auf Formlinien anwenden**

Ein Skizzeeffekt lässt eine Formlinie handgezeichnet wirken. Verwende [Shape.getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat), um die Linieneinstellungen zu erhalten, [LineFormat.getSketchFormat](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getSketchFormat), um die Skizzeneinstellungen zu erhalten, und [SketchFormat.setSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/sketchformat/#setSketchType), um einen Wert aus der Klasse [LineSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/) auszuwählen.

Der folgende Python‑Code zeigt, wie ein [LineSketchType.Curved](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/)-Effekt angewendet, der explizit zugewiesene Wert gelesen und der Effekt mit [LineSketchType.None_](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/) entfernt wird:

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

Der von [SketchFormat.getSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/sketchformat/#getSketchType) zurückgegebene Wert repräsentiert die direkt der Form zugewiesene Einstellung. Wenn die Linienformatierung von einem Theme, einer Master‑Folien‑ oder Layout‑Folien‑Vorlage geerbt werden kann, verwende [LineFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getEffective) und lese den Skizzen‑Typ aus der zurückgegebenen effektiven Linienformatierung, wie unten gezeigt. Der effektive Wert spiegelt die tatsächlich angewendete Formatierung wider, nachdem die Vererbung aufgelöst wurde. Dieses Beispiel benötigt eine vorhandene Präsentation mit mindestens einer Form auf der ersten Folie und gibt beide Werte aus:

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

## **Verbindungs‑Stile formatieren**

Hier sind die drei Optionen für den Verbindungs‑Typ:

* Round
* Miter
* Bevel

Der Verbindungs‑Stil steuert, wie zwei Kontursegmente an einer Ecke zusammentreffen. Verwende **Round** für abgerundete Ecken, **Miter** für spitze Ecken oder **Bevel** für abgeflachte Ecken.

![Der Verbindungs‑Stil in der Präsentation](join-style-powerpoint.png)

Dieses Beispiel erstellt drei schwarze Rechtecke mit blauen Konturen von 15 Punkten Breite. Es verwendet [LineFormat.setJoinStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setJoinStyle), um die Werte `Miter`, `Bevel` und `Round` der Klasse [LineJoinStyle](https://reference.aspose.com/slides/python-java/aspose.slides/linejoinstyle/) zu setzen und zu vergleichen, wie die Ecken gezeichnet werden.

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

### **Miter‑Verbindungen bei scharfen Ecken begrenzen**

Verwende [LineFormat.setMiterLimit](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setMiterLimit) zusammen mit [LineFormat.setJoinStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setJoinStyle) auf [LineJoinStyle.Miter](https://reference.aspose.com/slides/python-java/aspose.slides/linejoinstyle/), um zu begrenzen, wie weit eine scharfe Ecke ausstoßen darf.

Der Grenzwert ist das Verhältnis des Abstands zwischen innerer und äußerer Ecke der Verbindung zur Linienbreite. Ein Wert von `8` erlaubt beispielsweise eine Miter‑Länge von bis zu achtmal der Linienbreite; er ist keine Messung in Punkten. Überschreitet die Ecke den Grenzwert, verwendet PowerPoint an dieser Stelle eine abgeschrägte Verbindung. Ein größerer Grenzwert ermöglicht spitzere Punkte. Die Einstellung wirkt sich nur auf Miter‑Verbindungen aus und hat keinen sichtbaren Effekt, solange die Ecke innerhalb beider Grenzwerte bleibt.

Dieses Beispiel erstellt zwei identische, nicht ausgefüllte Dreiecke mit Konturen von 20 Punkten Breite. Das linke Dreieck verwendet einen Grenzwert von `2`, das rechte von `8`. Jedes Dreieck ist 80 Punkte breit und 160 Punkte hoch, sodass das Verhältnis von Miter‑Länge zu Linienbreite am oberen Winkel etwa `4,12` beträgt. Folglich fährt PowerPoint die linke Spitze ab und behält die rechte Spitze bei.

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

![Eine abgeschrägte Spitze mit Miter‑Grenzwert 2 und eine spitze Spitze mit Miter‑Grenzwert 8 in PowerPoint](miter-limits.png)

## **Verlaufsfüllung**

Eine Verlauffüllung mischt Farben über eine Form hinweg. Dieses Beispiel füllt eine Ellipse mit einem linearen Verlauf in einem 45‑Grad‑Winkel von Rot nach Violett über [FillFormat.getGradientFormat](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getGradientFormat). Die Methode [GradientStopCollection.addPresetColor](https://reference.aspose.com/slides/python-java/aspose.slides/gradientstopcollection/#addPresetColor) legt die Farb‑Stops bei 0 und 1, dem Anfang bzw. Ende des Verlaufs, fest. Das Löschen der vorhandenen Stops stellt sicher, dass nur diese beiden Farben verwendet werden.

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

![Die Ellipse mit Verlauffüllung](gradient-fill.png)

Falls ein Verlauf in einem exportierten Bild anders aussieht als in PowerPoint, siehe [Choose a Gradient Rendering Style](/slides/de/python-java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Du kannst einen Render‑Stil auswählen, ohne die in der Präsentation gespeicherte Verlauffüllung zu ändern.

### **Winkel des linearen Verlaufs festlegen**

Verwende [GradientFormat.setLinearGradientAngle](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/#setLinearGradientAngle), um die Ausrichtung einer [GradientShape.Linear](https://reference.aspose.com/slides/python-java/aspose.slides/gradientshape/)-Füllung zu steuern. Der Winkel wird in Grad gemessen und nimmt im Uhrzeigersinn zu: `0` verläuft von links nach rechts, `90` von oben nach unten, `180` von rechts nach links und `270` von unten nach oben. Bruchteile von Grad werden unterstützt. Endliche Winkel außerhalb des Intervalls `[0, 360)` werden zu einer Umdrehung normalisiert; zum Beispiel wird `-45` zu `315` und `360` zu `0`.

Dieses Beispiel erstellt sechs Rechtecke mit identischen roten, grünen und blauen Stops an den Positionen `0`, `0.5` und `1`. Das Skalieren ist deaktiviert, sodass der Winkel unabhängig von den Proportionen der Rechtecke verglichen werden kann. Die Winkel von links nach rechts sind `0`, `45` und `90` in der ersten Reihe sowie `135`, `180` und `270` in der zweiten Reihe.

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

![Lineare Verläufe bei 0°, 45° und 90° in der oberen Reihe sowie 135°, 180° und 270° in der unteren Reihe](linear-gradient-angles.png)

### **Linearen Verlauf mit der Form skalieren**

[GradientFormat.setLinearGradientScaled](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/#setLinearGradientScaled) akzeptiert einen [NullableBool](https://reference.aspose.com/slides/python-java/aspose.slides/nullablebool/)-Wert. Setze ihn explizit auf `False_`, um den geometrischen Verlaufswinkel beizubehalten, wenn sich die Proportionen der Form ändern, oder auf `True_`, um den Verlauf mit Breite und Höhe der Form zu skalieren. Bei aktivierter Skalierung kann der sichtbare Winkel von dem zugewiesenen Winkel einer nicht quadratischen Form abweichen.

Das folgende Beispiel verwendet einen Winkel von `45` Grad und dieselben Farb‑Stops wie im Winkel‑Vergleich. Die linke Spalte verwendet `False_`; die rechte Spalte verwendet `True_`. Jede Spalte enthält ein breites Rechteck über einem hohen Rechteck. Beide beginnen mit denselben Breiten‑Abmessungen; das Ändern von Breite und Höhe des zweiten Rechtecks zeigt, wie die Füllung auf Größenskalierung reagiert, ohne die Verlaufseinstellungen zu ändern.

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

Bei deaktivierter Skalierung behalten die diagonalen Farbstreifen in beiden Rechtecken dieselbe Orientierung. Bei aktivierter Skalierung dehnen sich die Streifen mit den Proportionen der Form. Das hilft, den Verlauf einer Vorlage beizubehalten, wenn eine Form an eine andere Größe angepasst wird. Auf einem Quadrat ändert das Aktivieren der Skalierung das Erscheinungsbild dieses `45`‑Grad‑Verlaufs nicht.

Sowohl Winkel‑ als auch Skalierungseinstellungen gelten für lineare Verläufe. Sie steuern nicht die Füllungen [GradientShape.Radial] oder [GradientShape.Rectangle](https://reference.aspose.com/slides/python-java/aspose.slides/gradientshape/).

### **Winkel mit Verlaufsrichtung kombinieren**

[GradientFormat.setGradientDirection](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/#setGradientDirection) wählt einen Verlaufsstil aus der Klasse [GradientDirection](https://reference.aspose.com/slides/python-java/aspose.slides/gradientdirection/) aus; er ersetzt keinen numerischen Winkel. Für einen linearen Verlauf können die Eck‑Stile den Bereich, über den die Farben verteilt werden, ändern, ohne den über [setLinearGradientAngle](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/#setLinearGradientAngle) zugewiesenen Winkel zu ändern. Lass die Richtung unverändert, wenn du Winkel oder Skalierung vergleichst.

Das folgende Beispiel wendet dieselben Einstellungen in umgekehrter Reihenfolge an. Die beiden Rechtecke sehen identisch aus: Das Zuweisen der Richtung vor oder nach dem Winkel ändert das Ergebnis nicht.

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

Eine Musterfüllung wendet ein zweifarbiges Design wie Punkte, Streifen oder Karos an. Dieses Beispiel verwendet [PatternFormat.setPatternStyle](https://reference.aspose.com/slides/python-java/aspose.slides/patternformat/#setPatternStyle), um ein Gittermuster auszuwählen. [PatternFormat.getBackColor](https://reference.aspose.com/slides/python-java/aspose.slides/patternformat/#getBackColor) liefert den hellgrauen Hintergrund, und [PatternFormat.getForeColor](https://reference.aspose.com/slides/python-java/aspose.slides/patternformat/#getForeColor) liefert die gelbe Musterfarbe.

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

Eine Bildfüllung verwendet ein Bild innerhalb einer Form. Dieses Beispiel benötigt ein lokales Bild und verwendet [Images.fromFile](https://reference.aspose.com/slides/python-java/aspose.slides/images/#fromFile), um es in die Bildsammlung der Präsentation zu laden. Das Setzen von [PictureFillFormat.setPictureFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setPictureFillMode) auf den Kachel‑Modus wiederholt das Bild innerhalb des Rechtecks. Das hier verwendete Quellbild ist unten zu sehen:

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

### **Bild als Textur kacheln**

Wenn du ein gekacheltes Bild als Textur festlegen und das Kacheln‑Verhalten anpassen möchtest, kannst du die folgenden Methoden der Klasse [PictureFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/) verwenden:

- [setPictureFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setPictureFillMode): Setzt den Bildfüll‑Modus – entweder `Tile` oder `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileAlignment): Gibt die Ausrichtung der Kacheln innerhalb der Form an.
- [setTileFlip](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileFlip): Steuert, ob die Kachel horizontal, vertikal oder in beide Richtungen gespiegelt wird.
- [setTileOffsetX](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileOffsetX): Setzt den horizontalen Versatz der Kachel (in Punkten) vom Ursprung der Form.
- [setTileOffsetY](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileOffsetY): Setzt den vertikalen Versatz der Kachel (in Punkten) vom Ursprung der Form.
- [setTileScaleX](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileScaleX): Definiert die horizontale Skalierung der Kachel als Prozentsatz.
- [setTileScaleY](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileScaleY): Definiert die vertikale Skalierung der Kachel als Prozentsatz.

Dieses Beispiel benötigt ein lokales Bild und konfiguriert [PictureFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/), um es mit 50 % seiner Originalgröße zu wiederholen. Offsets von −32 Punkten verschieben die Kacheln horizontal und vertikal; die Ausrichtung unten‑rechts und das Spiegeln in beiden Richtungen bestimmen, wie die wiederholte Textur angeordnet wird.

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

Eine einfarbige Füllung verleiht einer Form eine einzelne, gleichmäßige Farbe. Dieses Beispiel verwendet [FillFormat.setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType), um den einfarbigen Füllmodus zu setzen, und weist Gelb über [FillFormat.getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor) zu, bevor das Rechteck in einer Präsentation gespeichert wird.

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

## **Folienhintergrund als Formfüllung verwenden**

Verwende [AutoShape.setUseBackgroundFill](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/#setUseBackgroundFill), wenn eine Form dem Folienhintergrund entsprechen soll, zum Beispiel in einer Präsentationsvorlage. Setze zuerst [FillFormat.setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) auf [FillType.NotDefined](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/), um eine explizite Füllung zu entfernen. Mit dieser Kombination verwendet die Form den Folienhintergrund anstelle ihrer Stil‑Füllung. Das Aktivieren des Schalters allein entfernt keine bereits vorhandene explizite Füllung.

Dies unterscheidet sich von [FillType.NoFill](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/): Hintergrundfüllung deckt Objekte hinter der Form mit dem entsprechenden Bereich des Folienhintergrunds ab, während NoFill diese Objekte sichtbar lässt. Ein Verlauf bleibt an die Folie ausgerichtet, anstatt innerhalb jeder Form neu zu starten.

Das folgende Beispiel erstellt einen Master‑Hintergrund, der von der Folie geerbt wird, und platziert ein magentafarbenes Band hinter drei Rechtecken. Das linke Rechteck verwendet den Hintergrund, das mittlere Rechteck hat keine Füllung, und das rechte Rechteck wechselt von Hintergrundfüllung zu einer expliziten orangefarbenen Füllung.

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

    # Vererbe den Verlauf vom Master.
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

    # Füge dieses Objekt zuerst hinzu, damit es hinter den Rechtecken erscheint.
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

    # Deaktiviere Hintergrundfüllung, bevor eine explizite Füllung angewendet wird.
    explicit_shape.setUseBackgroundFill(False)
    explicit_shape.getFillFormat().setFillType(FillType.Solid)
    color = Color(255, 165, 0)
    explicit_shape.getFillFormat().getSolidFillColor().setColor(color)

    presentation.save("background_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Das Ergebnis von links nach rechts: **background fill**, **no fill** und **explicit fill**. Das magentafarbene Band wird von den linken und rechten Rechtecken verdeckt, bleibt aber durch das mittlere Rechteck sichtbar.

![Hintergrundfüllung, keine Füllung und explizite orange Füllung über einem magentafarbenen Band](background-fill.png)

Das gleiche Verhalten gilt für einen direkt auf der Folie definierten Hintergrund oder einen von einem Layout geerbten Hintergrund. Die Form verwendet den aufgelösten Folienhintergrund; das Beispiel lässt sowohl den Folien‑ als auch den Layout‑Hintergrund undefiniert, sodass der Master ihn bereitstellt.

## **Transparenz setzen**

Bei einer einfarbigen Füllung steuert die Alpha‑Komponente der Farbe die Deckkraft: 0 ist vollständig transparent und 255 vollständig undurchsichtig. Dieses Beispiel verwendet einen Alpha‑Wert von 128 für ein gelbes Rechteck, wodurch es etwa zu 50 % transparent ist, sodass das darunterliegende Rechteck sichtbar bleibt. Die Farbe wird über [FillFormat.getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor) zugewiesen.

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

Verwende [Shape.setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setRotation), um eine Form in der Folienebene zu drehen. Der Winkel wird in Grad gemessen; dieses Beispiel dreht ein Rechteck um 5 Grad im Uhrzeigersinn und speichert die Präsentation.

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

![Die Drehung der Form](shape-rotation.png)

## **3D‑Kehl‑Effekte hinzufügen**

Verwende [Shape.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getThreeDFormat), um einer Form Tiefe und abgeflachte Kanten zu verleihen. Dieses Beispiel erstellt eine grüne Ellipse mit einer orangefarbenen Kontur, verwendet [ThreeDFormat.setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setDepth), um die Tiefe auf 4 Punkte zu setzen, und wendet über [ThreeDFormat.getBevelTop](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getBevelTop) einen kreisförmigen oberen Kehl mit einer Breite und Höhe von 6 Punkten an. Eine frontale orthografische Kamera und dreipunktige Beleuchtung lassen den Kehl sichtbar werden.

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

![Der 3D‑Kehl‑Effekt](3D-bevel-effect.png)

## **3D‑Dreh‑Effekte hinzufügen**

Die 3D‑Ansicht einer Form wird durch die Kameraeinstellungen gesteuert. Dieses Beispiel verwendet [Camera.setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#setRotation) mit Längen‑, Breitengrad‑ und Revolutions‑Winkeln von jeweils 40, 35 und 20 Grad. Es wählt über [Camera.setCameraType](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#setCameraType) eine isometrische Kamera und über [LightRig.setLightType](https://reference.aspose.com/slides/python-java/aspose.slides/lightrig/#setLightType) eine ausgewogene Beleuchtung, bevor das formatierte Rechteck gespeichert wird.

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

![Der 3D‑Dreh‑Effekt](3D-rotation-effect.png)

## **Schwarz‑Weiß‑Darstellung für Formen steuern**

Die Methode [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setBlackWhiteMode) legt fest, wie eine einzelne Form gerendert wird, wenn eine Präsentation im Schwarz‑Weiß‑Modus angezeigt oder verarbeitet wird. Sie aktiviert die Schwarz‑Weiß‑Anzeige nicht selbst und ändert die Füll‑, Linien‑ oder andere Formatierungen der Form im normalen Farbmodus nicht.

Verwende einen Wert aus der Klasse [BlackWhiteMode](https://reference.aspose.com/slides/python-java/aspose.slides/blackwhitemode/), um das gewünschte Verhalten auszuwählen. Beispielsweise lässt `Automatic` die rendender Anwendung die Konvertierung wählen, `Gray` und `LightGray` verwenden Graufärbung, `BlackWhite` nur Schwarz und Weiß, `Black` und `White` erzwingen eine einzige Farbe, `Color` bewahrt die normale Farbgebung, und `Hidden` lässt die Form im Schwarz‑Weiß‑Modus wegfallen. `NotDefined` bedeutet, dass kein modellspezifischer Modus zugewiesen ist.

Dieses Beispiel erstellt ein oranges Rechteck und verwendet [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setBlackWhiteMode), um den Modus auf Grau zu setzen. Die gespeicherte Form behält ihre orange Füllung für die normale Farbanzeige bei und fordert Graufärbung von Anwendungen an, die die Schwarz‑Weiß‑Anzeigeeinstellungen honorieren:

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

Im normalen Farbmodus behält das Rechteck seine orange Füllung bei. In einem Schwarz‑Weiß‑Anzeige‑Workflow verwendet es Graufärbung, weil sein Modus auf `Gray` gesetzt ist. Das ermöglicht, eine vollfarbige Folie zu erhalten und gleichzeitig ein unterschiedliches Aussehen für Druck, Vorschau oder andere Workflows zu definieren, die die Schwarz‑Weiß‑Anzeigeeinstellungen der Präsentation berücksichtigen.

## **Formatierung zurücksetzen**

Verwende [Slide.reset](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#reset), um die Position, Größe und Formatierung von Platzhaltern einer Folie aus den entsprechenden Layout‑Platzhaltern wiederherzustellen. Dieses Beispiel erfordert eine vorhandene Präsentation mit layout‑verknüpften Platzhaltern und setzt jede Folie zurück, bevor sie gespeichert wird. Formen ohne entsprechende Layout‑Platzhalter werden nicht zurückgesetzt.

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

**Beeinflusst die Formatierung von Formen die endgültige Dateigröße der Präsentation?**

Farben, Linienstile und Effekt‑Einstellungen fügen im Vergleich zu eingebetteten Bildern und Medien nur wenig Daten hinzu. Bildfüllungen können die Dateigröße erhöhen, weil ihre Bilder in der Präsentation gespeichert werden.

**Wie kann ich Formen auf einer Folie erkennen, die identische Formatierung besitzen, um sie zu gruppieren?**

Vergleiche die wichtigsten Formatierungseigenschaften jeder Form – Füllung, Linie und Effekt‑Einstellungen. Stimmen alle entsprechenden Werte überein, betrachte ihre Stile als identisch und gruppiere diese Formen logisch, was die spätere Stilverwaltung vereinfacht.

**Kann ich ein Set benutzerdefinierter Form‑Stile in einer separaten Datei speichern, um es in anderen Präsentationen wiederzuverwenden?**

Ja. Speichere Beispiel­formen mit den gewünschten Stilen in einer Vorlagen‑Präsentation oder einer .POTX‑Vorlagendatei. Beim Erstellen einer neuen Präsentation öffne die Vorlage, klone die benötigten gestylten Formen und wende deren Formatierung dort an, wo sie benötigt wird.