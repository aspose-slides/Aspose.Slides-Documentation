---
title: PowerPoint-Formen in Python über Java formatieren
linktitle: Formformatierung
type: docs
weight: 20
url: /de/python-java/shape-formatting/
keywords:
- Form formatieren
- Linie formatieren
- Skizzen-Effekt
- Skizzen-Formlinie
- Verbindungsstil formatieren
- Verlaufsfüllung
- Musterfüllung
- Bildfüllung
- Texturfüllung
- Einfarbige Füllung
- Formtransparenz
- Schwarz-weiß-Darstellung von Formen
- Graustufen-Darstellung von Formen
- Form drehen
- 3D-Keil-Effekt
- 3D-Dreh-Effekt
- Formatierung zurücksetzen
- PowerPoint
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint-Formen in Python über Java mit Aspose.Slides formatieren – füllen, Linien- und Effektstile für PPT-, PPTX- und ODP-Dateien präzise und mit voller Kontrolle einstellen."
---
## **Einleitung**

In PowerPoint können Sie Formen zu Folien hinzufügen. Da Formen aus Linien bestehen, können Sie sie formatieren, indem Sie deren Konturen ändern oder Effekte darauf anwenden. Zusätzlich können Sie Formen formatieren, indem Sie Einstellungen festlegen, die steuern, wie ihre Innenbereiche gefüllt werden.

![Form-Format-PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for Python via Java stellt Klassen und Methoden bereit, mit denen Sie Formen mit denselben Optionen formatieren können, die in PowerPoint verfügbar sind.

## **Linien formatieren**

Mit Aspose.Slides können Sie für eine Form einen benutzerdefinierten Linienstil festlegen. Die folgenden Schritte beschreiben das Vorgehen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) Klasse.
1. Holen Sie eine Referenz zu einer Folie anhand ihres Index.
1. Fügen Sie der Folie ein [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) hinzu.
1. Setzen Sie den [Linienstil](https://reference.aspose.com/slides/python-java/aspose.slides/linestyle/) der Form.
1. Setzen Sie die Linienbreite.
1. Setzen Sie den [Strichstil](https://reference.aspose.com/slides/python-java/aspose.slides/linedashstyle/) der Linie.
1. Setzen Sie die Linienfarbe für die Form.
1. Speichern Sie die modifizierte Präsentation als PPTX‑Datei.

Der folgende Code demonstriert, wie man ein Rechteck‑[AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) formatiert:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineDashStyle, LineStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
presentation = Presentation()
try:
    # Holen Sie die erste Folie.
    slide = presentation.getSlides().get_Item(0)

    # Fügen Sie eine AutoShape vom Typ Rechteck hinzu.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75)

    # Legen Sie die Füllfarbe für die Rechteckform fest.
    shape.getFillFormat().setFillType(FillType.NoFill)

    # Wenden Sie die Formatierung auf die Linien des Rechtecks an.
    shape.getLineFormat().setStyle(LineStyle.ThickThin)
    shape.getLineFormat().setWidth(7)
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash)

    # Legen Sie die Farbe für die Linie des Rechtecks fest.
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    # Speichern Sie die PPTX-Datei auf der Festplatte.
    presentation.save("formatted_lines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Das Ergebnis:

![Die formatierten Linien in der Präsentation](formatted-lines.png)

## **Skizzeneffekte auf Formlinien anwenden**

Ein Skizze‑Effekt lässt eine Formlinie handgezeichnet wirken. Verwenden Sie [Shape.getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat) um auf die Linieneinstellungen zuzugreifen, [LineFormat.getSketchFormat](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getSketchFormat) um auf die Skizzeneinstellungen zuzugreifen, und [SketchFormat.setSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/sketchformat/#setSketchType) um einen Wert aus der Aufzählung [LineSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/) auszuwählen.

Der folgende Python‑Code zeigt, wie man einen [LineSketchType.Curved](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/#Curved)‑Effekt anwendet, den explizit zugewiesenen Wert ausliest und den Effekt mit [LineSketchType.None_](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/#None) entfernt:

```python
import jpype
import asposeslides

if not jpile.isJVMStarted():
    jpile.startJVM()

from asposeslides.api import LineSketchType, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100)

    # Greifen Sie auf das Linienformat der Form und dessen Skizzformat zu.
    sketch_format = shape.getLineFormat().getSketchFormat()

    # Wenden Sie einen Skizzeneffekt an.
    sketch_format.setSketchType(LineSketchType.Curved)

    # Lesen Sie den der Form direkt zugewiesenen Skizzeneffekt.
    explicit_sketch_type = sketch_format.getSketchType()
    print(f"Explicit sketch type: {explicit_sketch_type}")

    # Entfernen Sie den Skizzeneffekt.
    sketch_format.setSketchType(LineSketchType.None_)
finally:
    presentation.dispose()
```

Der von [SketchFormat.getSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/sketchformat/#getSketchType) zurückgegebene Wert stellt die direkt der Form zugewiesene Einstellung dar. Wenn die Linienformatierung von einem Design, einer Master‑Folie oder einer Layout‑Folie geerbt werden kann, verwenden Sie [LineFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getEffective), greifen Sie auf `LineFormatEffectiveData.getSketchFormat` zu und lesen Sie `SketchFormatEffectiveData.getSketchType`. Der effektive Wert spiegelt die Formatierung wider, die nach Auflösung der Vererbung tatsächlich angewendet wird:

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

    print(f"Explicit sketch type: {explicit_sketch_type}")
    print(f"Effective sketch type: {effective_sketch_type}")
finally:
    presentation.dispose()
```

## **Verbindungsstile formatieren**

Hier sind die drei Optionen für den Verbindungsstil:

* Round
* Miter
* Bevel

Standardmäßig verwendet PowerPoint beim Verbinden von zwei Linien in einem Winkel (wie an einer Formenecke) die **Round**‑Einstellung. Wenn Sie jedoch eine Form mit scharfen Winkeln zeichnen, bevorzugen Sie möglicherweise die **Miter**‑Option.

![Der Verbindungsstil in der Präsentation](join-style-powerpoint.png)

Der folgende Python‑Code demonstriert, wie drei Rechtecke (wie im Bild oben gezeigt) mit den Miter-, Bevel- und Round‑Verbindungsstil‑Einstellungen erstellt wurden:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineJoinStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
presentation = Presentation()
try:
    # Holen Sie die erste Folie.
    slide = presentation.getSlides().get_Item(0)

    # Fügen Sie drei AutoShapes vom Typ Rechteck hinzu.
    miter_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75)
    bevel_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75)
    round_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75)

    # Legen Sie die Füllfarbe für jede Rechteckform fest.
    miter_shape.getFillFormat().setFillType(FillType.Solid)
    miter_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    bevel_shape.getFillFormat().setFillType(FillType.Solid)
    bevel_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    round_shape.getFillFormat().setFillType(FillType.Solid)
    round_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    # Legen Sie die Linienstärke fest.
    miter_shape.getLineFormat().setWidth(15)
    bevel_shape.getLineFormat().setWidth(15)
    round_shape.getLineFormat().setWidth(15)

    # Legen Sie die Farbe für die Linie jedes Rechtecks fest.
    miter_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    miter_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    bevel_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    bevel_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    round_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    round_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    # Legen Sie den Verbindungsstil fest.
    miter_shape.getLineFormat().setJoinStyle(LineJoinStyle.Miter)
    bevel_shape.getLineFormat().setJoinStyle(LineJoinStyle.Bevel)
    round_shape.getLineFormat().setJoinStyle(LineJoinStyle.Round)

    # Fügen Sie jedem Rechteck Text hinzu.
    miter_shape.getTextFrame().setText("Miter Join Style")
    bevel_shape.getTextFrame().setText("Bevel Join Style")
    round_shape.getTextFrame().setText("Round Join Style")

    # Speichern Sie die PPTX-Datei auf der Festplatte.
    presentation.save("join_styles.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Verlaufsfüllung**

In PowerPoint ist die Verlaufsfüllung eine Formatierungsoption, mit der Sie einer Form einen kontinuierlichen Farbverlauf zuweisen können. Beispielsweise können Sie zwei oder mehr Farben so anwenden, dass die eine allmählich in die andere übergeht.

So wenden Sie eine Verlaufsfüllung auf eine Form mit Aspose.Slides an:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) Klasse.
1. Holen Sie eine Referenz zu einer Folie anhand ihres Index.
1. Fügen Sie der Folie ein [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) hinzu.
1. Setzen Sie den [FillType](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) der Form auf `Gradient`.
1. Fügen Sie Ihre beiden gewünschten Farben mit definierten Positionen mithilfe der Methode [addPresetColor](https://reference.aspose.com/slides/python-java/aspose.slides/gradientstopcollection/#addPresetColor) der Farb‑Stop‑Sammlung hinzu, die von der Klasse [GradientFormat](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/) bereitgestellt wird.
1. Speichern Sie die modifizierte Präsentation als PPTX‑Datei.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, GradientDirection, GradientShape, Presentation, PresetColor, SaveFormat, ShapeType
from java.awt import Color

# Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
presentation = Presentation()
try:
    # Holen Sie die erste Folie.
    slide = presentation.getSlides().get_Item(0)

    # Fügen Sie eine AutoShape vom Typ Ellipse hinzu.
    shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75)

    # Wenden Sie eine Gradientformatierung auf die Ellipse an.
    shape.getFillFormat().setFillType(FillType.Gradient)
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear)

    # Legen Sie die Richtung des Gradienten fest.
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2)

    # Fügen Sie zwei Farbverlaufspunkte hinzu.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0, PresetColor.Purple)
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0.0, PresetColor.Red)

    # Speichern Sie die PPTX-Datei auf der Festplatte.
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Die Ellipse mit Verlaufsfüllung](gradient-fill.png)

Wenn ein Verlauf in einem exportierten Bild anders aussieht als in PowerPoint, siehe [Choose a Gradient Rendering Style](/slides/de/python-java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Sie können einen Rendering‑Stil auswählen, ohne die in der Präsentation gespeicherte Verlaufsfüllung zu ändern.

## **Musterfüllung**

In PowerPoint ist die Musterfüllung eine Formatierungsoption, mit der Sie ein zweifarbiges Design – wie Punkte, Streifen, Kreuzschraffuren oder Karos – auf eine Form anwenden können. Sie können benutzerdefinierte Farben für den Vorder‑ und Hintergrund des Musters auswählen.

Aspose.Slides bietet über 45 vordefinierte Musterstile, die Sie auf Formen anwenden können, um die visuelle Attraktivität Ihrer Präsentationen zu steigern. Auch nach Auswahl eines vordefinierten Musters können Sie die genauen Farben festlegen, die verwendet werden sollen.

So wenden Sie eine Musterfüllung auf eine Form mit Aspose.Slides an:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) Klasse.
1. Holen Sie eine Referenz zu einer Folie anhand ihres Index.
1. Fügen Sie der Folie ein [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) hinzu.
1. Setzen Sie den [FillType](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) der Form auf `Pattern`.
1. Wählen Sie einen Musterstil aus den vordefinierten Optionen.
1. Setzen Sie die [Background Color](https://reference.aspose.com/slides/python-java/aspose.slides/patternformat/#getBackColor) des Musters.
1. Setzen Sie die [Foreground Color](https://reference.aspose.com/slides/python-java/aspose.slides/patternformat/#getForeColor) des Musters.
1. Speichern Sie die modifizierte Präsentation als PPTX‑Datei.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, PatternStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
presentation = Presentation()
try:
    # Holen Sie die erste Folie.
    slide = presentation.getSlides().get_Item(0)

    # Fügen Sie eine AutoShape vom Typ Rechteck hinzu.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # Setzen Sie den Fülltyp auf Pattern.
    shape.getFillFormat().setFillType(FillType.Pattern)

    # Setzen Sie den Musterstil.
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis)

    # Setzen Sie die Hintergrund- und Vordergrundfarben des Musters.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY)
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW)

    # Speichern Sie die PPTX-Datei auf der Festplatte.
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Das Rechteck mit Musterfüllung](pattern-fill.png)

## **Bildfüllung**

In PowerPoint ist die Bildfüllung eine Formatierungsoption, mit der Sie ein Bild in eine Form einfügen können – das Bild dient effektiv als Hintergrund der Form.

So verwenden Sie Aspose.Slides, um einer Form eine Bildfüllung zuzuweisen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) Klasse.
1. Holen Sie eine Referenz zu einer Folie anhand ihres Index.
1. Fügen Sie der Folie ein [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) hinzu.
1. Setzen Sie den [FillType](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) der Form auf `Picture`.
1. Setzen Sie den Bildfüllungsmodus auf `Tile` (oder einen anderen bevorzugten Modus).
1. Erstellen Sie ein [PPImage](https://reference.aspose.com/slides/python-java/aspose.slides/ppimage/)‑Objekt aus dem Bild, das Sie verwenden möchten.
1. Übergeben Sie das Bild an die Methode `SlidesPicture.setImage`.
1. Speichern Sie die modifizierte Präsentation als PPTX‑Datei.

![Das Lotus‑Bild](lotus.png)

Der folgende Python‑Code demonstriert, wie man eine Form mit dem Bild füllt:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Images, PictureFillMode, Presentation, SaveFormat, ShapeType

# Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
presentation = Presentation()
try:
    # Holen Sie die erste Folie.
    slide = presentation.getSlides().get_Item(0)

    # Fügen Sie eine AutoShape vom Typ Rechteck hinzu.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130)
    
    # Setzen Sie den Fülltyp auf Picture.
    shape.getFillFormat().setFillType(FillType.Picture)

    # Setzen Sie den Bildfüllungsmodus.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile)

    # Laden Sie ein Bild und fügen Sie es zu den Präsentationsressourcen hinzu.
    image = Images.fromFile("lotus.png")
    picture = presentation.getImages().addImage(image)
    image.dispose()

    # Setzen Sie das Bild.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture)

    # Speichern Sie die PPTX-Datei auf der Festplatte.
    presentation.save("picture_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Das Ergebnis:

![Die Form mit Bildfüllung](picture-fill.png)

### **Bild kacheln als Textur**

Wenn Sie ein gekacheltes Bild als Textur festlegen und das Kachelungsverhalten anpassen möchten, können Sie die folgenden Methoden der Klasse [PictureFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/) verwenden:

- [setPictureFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setPictureFillMode): Legt den Bildfüllungsmodus fest – entweder `Tile` oder `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileAlignment): Gibt die Ausrichtung der Kacheln innerhalb der Form an.
- [setTileFlip](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileFlip): Steuert, ob die Kachel horizontal, vertikal oder beides gespiegelt wird.
- [setTileOffsetX](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileOffsetX): Legt den horizontalen Versatz der Kachel (in Punkten) vom Ursprung der Form fest.
- [setTileOffsetY](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileOffsetY): Legt den vertikalen Versatz der Kachel (in Punkten) vom Ursprung der Form fest.
- [setTileScaleX](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileScaleX): Definiert die horizontale Skalierung der Kachel als Prozentsatz.
- [setTileScaleY](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileScaleY): Definiert die vertikale Skalierung der Kachel als Prozentsatz.

Das folgende Codebeispiel zeigt, wie man ein Rechteck mit gekachelter Bildfüllung hinzufügt und Kacheloptionen konfiguriert:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Images, PictureFillMode, Presentation, RectangleAlignment, SaveFormat, ShapeType, TileFlip

# Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
presentation = Presentation()
try:
    # Holen Sie die erste Folie.
    first_slide = presentation.getSlides().get_Item(0)

    # Fügen Sie eine Rechteck-AutoShape hinzu.
    shape = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95)

    # Setzen Sie den Fülltyp der Form auf Picture.
    shape.getFillFormat().setFillType(FillType.Picture)

    # Laden Sie das Bild und fügen Sie es zu den Präsentationsressourcen hinzu.
    source_image = Images.fromFile("lotus.png")
    presentation_image = presentation.getImages().addImage(source_image)
    source_image.dispose()

    # Weisen Sie das Bild der Form zu.
    picture_fill_format = shape.getFillFormat().getPictureFillFormat()
    picture_fill_format.getPicture().setImage(presentation_image)

    # Konfigurieren Sie den Bildfüllungsmodus und die Kacheleigenschaften.
    picture_fill_format.setPictureFillMode(PictureFillMode.Tile)
    picture_fill_format.setTileOffsetX(-32)
    picture_fill_format.setTileOffsetY(-32)
    picture_fill_format.setTileScaleX(50)
    picture_fill_format.setTileScaleY(50)
    picture_fill_format.setTileAlignment(RectangleAlignment.BottomRight)
    picture_fill_format.setTileFlip(TileFlip.FlipBoth)

    # Speichern Sie die PPTX-Datei auf der Festplatte.
    presentation.save("tile.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Die Kacheloptionen](tile-options.png)

## **Einfarbige Füllung**

In PowerPoint ist die einfarbige Füllung eine Formatierungsoption, die eine Form mit einer einzigen, einheitlichen Farbe füllt. Diese einfache Hintergrundfarbe wird ohne Verläufe, Texturen oder Muster angewendet.

Um mit Aspose.Slides eine einfarbige Füllung auf eine Form anzuwenden, führen Sie folgende Schritte aus:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) Klasse.
1. Holen Sie eine Referenz zu einer Folie anhand ihres Index.
1. Fügen Sie der Folie ein [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) hinzu.
1. Setzen Sie den [FillType](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) der Form auf `Solid`.
1. Weisen Sie der Form Ihre bevorzugte Füllfarbe zu.
1. Speichern Sie die modifizierte Präsentation als PPTX‑Datei.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
presentation = Presentation()
try:
    # Holen Sie die erste Folie.
    slide = presentation.getSlides().get_Item(0)

    # Fügen Sie eine AutoShape vom Typ Rechteck hinzu.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # Setzen Sie den Fülltyp auf Solid.
    shape.getFillFormat().setFillType(FillType.Solid)

    # Setzen Sie die Füllfarbe.
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW)

    # Speichern Sie die PPTX-Datei auf der Festplatte.
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Die Form mit einfarbiger Füllung](solid-color-fill.png)

## **Transparenz festlegen**

In PowerPoint können Sie, wenn Sie einer Form eine einfarbige, Verlauf-, Bild‑ oder Texturfüllung zuweisen, auch einen Transparenzwert festlegen, um die Undurchsichtigkeit der Füllung zu steuern. Ein höherer Transparenzwert macht die Form durchsichtiger, sodass der Hintergrund oder darunterliegende Objekte teilweise sichtbar werden.

Aspose.Slides ermöglicht das Festlegen des Transparenzwerts, indem Sie den Alpha‑Wert der für die Füllung verwendeten Farbe anpassen. So geht’s:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) Klasse.
1. Holen Sie eine Referenz zu einer Folie anhand ihres Index.
1. Fügen Sie der Folie ein [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) hinzu.
1. Setzen Sie den [FillType](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) der Form auf `Solid`.
1. Verwenden Sie [Color](https://docs.oracle.com/en/java/javase/17/docs/api/java.desktop/java/awt/Color.html), um eine Farbe mit Transparenz zu definieren (die `alpha`‑Komponente steuert die Transparenz).
1. Speichern Sie die Präsentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpile.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
presentation = Presentation()
try:
    # Holen Sie die erste Folie.
    slide = presentation.getSlides().get_Item(0)

    # Fügen Sie eine solide Rechteck-AutoShape hinzu.
    solid_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # Fügen Sie eine transparente Rechteck-AutoShape über der soliden Form hinzu.
    transparent_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75)
    transparent_shape.getFillFormat().setFillType(FillType.Solid)
    transparent_color = Color(255, 255, 0, 204)
    transparent_shape.getFillFormat().getSolidFillColor().setColor(transparent_color)

    # Speichern Sie die PPTX-Datei auf der Festplatte.
    presentation.save("shape_transparency.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Die transparente Form](shape-transparency.png)

## **Formen drehen**

Aspose.Slides ermöglicht das Drehen von Formen in PowerPoint‑Präsentationen. Das kann nützlich sein, um visuelle Elemente mit bestimmten Ausrichtungs‑ oder Designanforderungen zu platzieren.

Um eine Form auf einer Folie zu drehen, führen Sie folgende Schritte aus:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) Klasse.
1. Holen Sie eine Referenz zu einer Folie anhand ihres Index.
1. Fügen Sie der Folie ein [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) hinzu.
1. Setzen Sie die Rotations‑Eigenschaft der Form auf den gewünschten Winkel.
1. Speichern Sie die Präsentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
presentation = Presentation()
try:
    # Holen Sie die erste Folie.
    slide = presentation.getSlides().get_Item(0)

    # Fügen Sie eine AutoShape vom Typ Rechteck hinzu.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # Drehen Sie die Form um 5 Grad.
    shape.setRotation(5)

    # Speichern Sie die PPTX-Datei auf der Festplatte.
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Die Formdrehung](shape-rotation.png)

## **3D‑Keil‑Effekte hinzufügen**

Aspose.Slides ermöglicht das Anwenden von 3D‑Keil‑Effekten auf Formen, indem Sie deren [ThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/)‑Eigenschaften konfigurieren.

Um einer Form 3D‑Keil‑Effekte hinzuzufügen, führen Sie folgende Schritte aus:

1. Instanziieren Sie die [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) Klasse.
1. Holen Sie eine Referenz zu einer Folie anhand ihres Index.
1. Fügen Sie der Folie ein [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) hinzu.
1. Konfigurieren Sie das [ThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/) der Form, um Keil‑Einstellungen festzulegen.
1. Speichern Sie die Präsentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BevelPresetType, CameraPresetType, FillType, LightRigPresetType, LightingDirection, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Erstellen Sie eine Instanz der Presentation-Klasse.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Fügen Sie der Folie eine Form hinzu.
    shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color.GREEN)
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.ORANGE)
    shape.getLineFormat().setWidth(2.0)

    # Setzen Sie die ThreeDFormat-Eigenschaften der Form.
    shape.getThreeDFormat().setDepth(4)
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle)
    shape.getThreeDFormat().getBevelTop().setHeight(6)
    shape.getThreeDFormat().getBevelTop().setWidth(6)
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)

    # Speichern Sie die Präsentation als PPTX-Datei.
    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Der 3D‑Keil‑Effekt](3D-bevel-effect.png)

## **3D‑Dreh‑Effekte hinzufügen**

Aspose.Slides ermöglicht das Anwenden von 3D‑Dreh‑Effekten auf Formen, indem Sie deren [ThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/)‑Properties konfigurieren.

Um eine 3D‑Drehung auf eine Form anzuwenden:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) Klasse.
1. Holen Sie eine Referenz zu einer Folie anhand ihres Index.
1. Fügen Sie der Folie ein [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) hinzu.
1. Verwenden Sie die Methoden [setCameraType](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#setCameraType) und [setLightType](https://reference.aspose.com/slides/python-java/aspose.slides/lightrig/#setLightType), um die 3D‑Drehung zu definieren.
1. Speichern Sie die Präsentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, LightRigPresetType, Presentation, SaveFormat, ShapeType

# Erstellen Sie eine Instanz der Presentation-Klasse.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)
    auto_shape.getTextFrame().setText("Hello, Aspose!")

    auto_shape.getThreeDFormat().setDepth(6)
    auto_shape.getThreeDFormat().getCamera().setRotation(40, 35, 20)
    auto_shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp)
    auto_shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced)

    # Speichern Sie die Präsentation als PPTX-Datei.
    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Der 3D‑Dreh‑Effekt](3D-rotation-effect.png)

## **Schwarz‑weiß‑Rendering für Formen steuern**

Die Methode [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setBlackWhiteMode) legt fest, wie eine einzelne Form gerendert wird, wenn eine Präsentation im Schwarz‑weiß‑Modus angezeigt oder verarbeitet wird. Sie aktiviert die Schwarz‑weiß‑Anzeige nicht selbst und ändert die Füllung, Linie oder andere Formatierungen der Form im normalen Farbmodus nicht.

Verwenden Sie einen Wert aus der Klasse [BlackWhiteMode](https://reference.aspose.com/slides/python-java/aspose.slides/blackwhitemode/), um das gewünschte Verhalten auszuwählen. Beispielsweise lässt `Automatic` die Rendering‑Anwendung die Konvertierung wählen, `Gray` und `LightGray` verwenden graue Farbtöne, `BlackWhite` nutzt ausschließlich Schwarz und Weiß, `Black` und `White` erzwingen eine einzelne Farbe, `Color` bewahrt die normale Farbgebung, und `Hidden` blendet die Form im Schwarz‑weiß‑Modus aus. `NotDefined` bedeutet, dass kein Form‑Ebene‑Modus zugewiesen ist.

Der folgende Python‑Code erstellt eine farbige Form und lässt sie im Schwarz‑weiß‑Anzeige‑Modus grau erscheinen:

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
    shape.getFillFormat().getSolidFillColor().setColor(Color.ORANGE)

    # Behalten Sie die orange Füllung im Farbmodus, aber rendern Sie die Form mit grauer Färbung im Schwarz-weiß-Modus.
    shape.setBlackWhiteMode(BlackWhiteMode.Gray)

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Im normalen Farbmodus behält das Rechteck seine orangefarbene Füllung. In einem Schwarz‑weiß‑Anzeige‑Workflow verwendet es eine graue Färbung, weil sein Modus auf `Gray` gesetzt ist. Damit können Sie eine Vollfarb‑Folien erhalten und gleichzeitig ein separates Aussehen für den Druck, die Vorschau oder andere Workflows definieren, die die Schwarz‑weiß‑Anzeigeeinstellungen der Präsentation berücksichtigen.

## **Formatierung zurücksetzen**

Der folgende Python‑Code zeigt, wie Sie die Formatierung einer Folie zurücksetzen und die Position, Größe und Formatierung aller Formen mit Platzhaltern auf dem [LayoutSlide](https://reference.aspose.com/slides/python-java/aspose.slides/layoutslide/) auf ihre Standardwerte zurücksetzen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    for slide in presentation.getSlides():
        # Setzen Sie jede Form auf der Folie zurück, die einen Platzhalter im Layout hat.
        slide.reset()

    presentation.save("reset_formatting.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Beeinflusst die Formformatierung die endgültige Dateigröße der Präsentation?**

Nur minimal. Eingebettete Bilder und Medien beanspruchen den größten Teil des Speicherplatzes, während Formparameter wie Farben, Effekte und Verläufe als Metadaten gespeichert werden und praktisch keinen zusätzlichen Platz benötigen.

**Wie kann ich Formen auf einer Folie erkennen, die identische Formatierungen teilen, sodass ich sie gruppieren kann?**

Vergleichen Sie die wichtigsten Formatierungseigenschaften jeder Form – Füllung, Linie und Effekteinstellungen. Stimmen alle entsprechenden Werte überein, betrachten Sie deren Stile als identisch und gruppieren die Formen logisch, was die spätere Stilverwaltung vereinfacht.

**Kann ich ein Set benutzerdefinierter Formstile in einer separaten Datei speichern, um es in anderen Präsentationen wiederzuverwenden?**

Ja. Speichern Sie Beispiel‑Formen mit den gewünschten Stilen in einem Vorlagen‑Foliendeck oder einer .POTX‑Vorlagendatei. Beim Erstellen einer neuen Präsentation öffnen Sie die Vorlage, klonen die benötigten stilisierten Formen und wenden deren Formatierung an den gewünschten Stellen erneut an.