---
title: PowerPoint-Formen in Python formatieren
linktitle: Formformatierung
type: docs
weight: 20
url: /de/python-net/shape-formatting/
keywords:
- Form formatieren
- Linie formatieren
- Skizzen-Effekt
- Formlinien skizzieren
- Verbindungsstil formatieren
- Verlaufsfüllung
- Musterfüllung
- Bildfüllung
- Texturfüllung
- Einfarbige Füllung
- Formtransparenz
- Form drehen
- 3D-Fasen-Effekt
- 3D-Drehungseffekt
- Formatierung zurücksetzen
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint-Formen in Python mit Aspose.Slides formatieren - Füllungen, Linien und Effekt-Styles für PPT-, PPTX- und ODP-Dateien präzise und vollständig steuern."
---
## **Einleitung**

In PowerPoint können Sie Formen zu Folien hinzufügen. Da Formen aus Linien bestehen, können Sie sie formatieren, indem Sie die Konturen ändern oder Effekte darauf anwenden. Zusätzlich können Sie Formen formatieren, indem Sie Einstellungen festlegen, die steuern, wie ihre Innenflächen gefüllt werden.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides für Python bietet Klassen und Eigenschaften, die es Ihnen ermöglichen, Formen mit denselben Optionen zu formatieren, die in PowerPoint verfügbar sind.

## **Linien formatieren**

Mit Aspose.Slides können Sie für eine Form einen benutzerdefinierten Linienstil festlegen. Die folgenden Schritte beschreiben das Vorgehen:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/).
1. Holen Sie eine Referenz zu einer Folie anhand ihres Index.
1. Fügen Sie der Folie ein [AutoShape](https://reference.aspose.com/slides/de/python-net/aspose.slides/autoshape/) hinzu.
1. Setzen Sie den [line style](https://reference.aspose.com/slides/de/python-net/aspose.slides/linestyle/) der Form.
1. Legen Sie die Linienbreite fest.
1. Setzen Sie den [dash style](https://reference.aspose.com/slides/de/python-net/aspose.slides/linedashstyle/) der Form.
1. Legen Sie die Linienfarbe für die Form fest.
1. Speichern Sie die modifizierte Präsentation als PPTX-Datei.

Der folgende Python-Code zeigt, wie ein Rechteck-`AutoShape` formatiert wird:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei repräsentiert.
with slides.Presentation() as presentation:

    # Holen Sie die erste Folie.
    slide = presentation.slides[0]

    # Fügen Sie eine AutoForm vom Typ Rechteck hinzu.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 75)

    # Legen Sie die Füllfarbe für die Rechteckform fest.
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    # Wenden Sie die Formatierung auf die Linien des Rechtecks an.
    shape.line_format.style = slides.LineStyle.THICK_THIN
    shape.line_format.width = 7
    shape.line_format.dash_style = slides.LineDashStyle.DASH

    # Legen Sie die Farbe für die Linie des Rechtecks fest.
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue

    # Speichern Sie die PPTX-Datei auf der Festplatte.
    presentation.save("formatted_lines.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![The formatted lines in the presentation](formatted-lines.png)

## **Skizzeneffekte auf Formlinien anwenden**

Ein Skizzeneffekt lässt eine Formlinie handgezeichnet aussehen. Verwenden Sie [Shape.line_format](https://reference.aspose.com/slides/de/python-net/aspose.slides/shape/line_format/), um auf die Linieneinstellungen zuzugreifen, [LineFormat.sketch_format](https://reference.aspose.com/slides/de/python-net/aspose.slides/lineformat/sketch_format/), um auf die Skizzeinstellungen zuzugreifen, und [SketchFormat.sketch_type](https://reference.aspose.com/slides/de/python-net/aspose.slides/sketchformat/sketch_type/), um einen Wert aus der Aufzählung [LineSketchType](https://reference.aspose.com/slides/de/python-net/aspose.slides/linesketchtype/) auszuwählen.

Der folgende Python-Code zeigt, wie ein [LineSketchType.CURVED](https://reference.aspose.com/slides/de/python-net/aspose.slides/linesketchtype/)-Effekt angewendet, der explizit zugewiesene Wert ausgelesen und der Effekt mit [LineSketchType.NONE](https://reference.aspose.com/slides/de/python-net/aspose.slides/linesketchtype/) entfernt wird:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)

    # Greifen Sie auf das Linienformat der Form und dessen Skizzenformat zu.
    sketch_format = shape.line_format.sketch_format

    # Wenden Sie einen Skizzeneffekt an.
    sketch_format.sketch_type = slides.LineSketchType.CURVED

    # Lesen Sie den direkt der Form zugewiesenen Skizzeneffekt.
    explicit_sketch_type = sketch_format.sketch_type
    print(f"Explicit sketch type: {explicit_sketch_type}")

    # Entfernen Sie den Skizzeneffekt.
    sketch_format.sketch_type = slides.LineSketchType.NONE
```

Der von `SketchFormat.sketch_type` zurückgegebene Wert stellt die Einstellung dar, die direkt der Form zugewiesen wurde. Wenn die Linienformatierung von einem Design, einer Masterfolie oder einer Layoutfolie geerbt werden kann, verwenden Sie [LineFormat.get_effective](https://reference.aspose.com/slides/de/python-net/aspose.slides/lineformat/get_effective/), greifen Sie auf die `sketch_format`‑Eigenschaft des zurückgegebenen Objekts zu und lesen Sie dessen `sketch_type`‑Eigenschaft aus. Der effektive Wert spiegelt die tatsächlich angewendete Formatierung wider, nachdem die Vererbung aufgelöst wurde:

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

## **Verbindungsstil formatieren**

Hier sind die drei Optionen für den Verbindungsstil:

* Round
* Miter
* Bevel

Standardmäßig verwendet PowerPoint beim Verbinden zweier Linien unter einem Winkel (zum Beispiel an einer Formkante) die Einstellung **Round**. Wenn Sie jedoch eine Form mit scharfen Winkeln zeichnen, bevorzugen Sie möglicherweise die Option **Miter**.

![The join style in the presentation](join-style-powerpoint.png)

Der folgende Python-Code zeigt, wie drei Rechtecke (wie im Bild oben) mit den Einstellungen Miter, Bevel und Round für den Verbindungsstil erstellt wurden:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
with slides.Presentation() as presentation:

	# Holen Sie die erste Folie.
	slide = presentation.slides[0]

	# Fügen Sie drei Autoformen vom Typ Rechteck hinzu.
	shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 75)
	shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 210, 20, 150, 75)
	shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 135, 150, 75)

	# Legen Sie die Füllfarbe für jede Rechteckform fest.
	shape1.fill_format.fill_type = slides.FillType.SOLID
	shape1.fill_format.solid_fill_color.color = draw.Color.black
	shape2.fill_format.fill_type = slides.FillType.SOLID
	shape2.fill_format.solid_fill_color.color = draw.Color.black
	shape3.fill_format.fill_type = slides.FillType.SOLID
	shape3.fill_format.solid_fill_color.color = draw.Color.black

	# Legen Sie die Linienbreite fest.
	shape1.line_format.width = 15
	shape2.line_format.width = 15
	shape3.line_format.width = 15

	# Legen Sie die Farbe für die Linie jedes Rechtecks fest.
	shape1.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape1.line_format.fill_format.solid_fill_color.color = draw.Color.blue
	shape2.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape2.line_format.fill_format.solid_fill_color.color = draw.Color.blue
	shape3.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape3.line_format.fill_format.solid_fill_color.color = draw.Color.blue

	# Legen Sie den Verbindungsstil fest.
	shape1.line_format.join_style = slides.LineJoinStyle.MITER
	shape2.line_format.join_style = slides.LineJoinStyle.BEVEL
	shape3.line_format.join_style = slides.LineJoinStyle.ROUND

	# Fügen Sie jedem Rechteck Text hinzu.
	shape1.text_frame.text = "Miter Join style"
	shape2.text_frame.text = "Bevel Join style"
	shape3.text_frame.text = "Round Join style"

	# Speichern Sie die PPTX-Datei auf der Festplatte.
	presentation.save("join_styles.pptx", slides.export.SaveFormat.PPTX)
```

## **Verlaufsfüllung**

In PowerPoint ist die Verlaufsfüllung eine Formatierungsoption, die es ermöglicht, einer Form einen kontinuierlichen Farbverlauf zuzuweisen. Beispielsweise können Sie zwei oder mehr Farben so anwenden, dass die eine allmählich in die andere übergeht.

So wenden Sie eine Verlaufsfüllung auf eine Form mit Aspose.Slides an:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/).
1. Holen Sie eine Referenz zu einer Folie anhand ihres Index.
1. Fügen Sie der Folie ein [AutoShape](https://reference.aspose.com/slides/de/python-net/aspose.slides/autoshape/) hinzu.
1. Setzen Sie den [FillType](https://reference.aspose.com/slides/de/python-net/aspose.slides/filltype/) der Form auf `GRADIENT`.
1. Fügen Sie Ihre beiden bevorzugten Farben mit definierten Positionen über die `add`‑Methoden der `gradient_stops`‑Sammlung hinzu, die von der Klasse [GradientFormat](https://reference.aspose.com/slides/de/python-net/aspose.slides/gradientformat/) bereitgestellt wird.
1. Speichern Sie die modifizierte Präsentation als PPTX-Datei.

Der folgende Python-Code demonstriert, wie ein Verlaufseffekt auf eine Ellipse angewendet wird:

```python
import aspose.slides as slides

# Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
with slides.Presentation() as presentation:

    # Holen Sie die erste Folie.
    slide = presentation.slides[0]

    # Fügen Sie eine Autoform vom Typ Ellipse hinzu.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 150, 75)

    # Wenden Sie eine Verlaufformatierung auf die Ellipse an.
    shape.fill_format.fill_type = slides.FillType.GRADIENT
    shape.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR

    # Legen Sie die Richtung des Verlaufs fest.
    shape.fill_format.gradient_format.gradient_direction = slides.GradientDirection.FROM_CORNER2

    # Fügen Sie zwei Verlaufspunkte hinzu.
    shape.fill_format.gradient_format.gradient_stops.add(1.0, slides.PresetColor.PURPLE)
    shape.fill_format.gradient_format.gradient_stops.add(0, slides.PresetColor.RED)

    # Speichern Sie die PPTX-Datei auf der Festplatte.
    presentation.save("gradient_fill.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![The ellipse with gradient fill](gradient-fill.png)

## **Musterfüllung**

In PowerPoint ist die Musterfüllung eine Formatierungsoption, mit der Sie ein zweifarbiges Design – beispielsweise Punkte, Streifen, Schraffuren oder Karos – auf eine Form anwenden können. Sie können benutzerdefinierte Farben für den Vorder‑ und Hintergrund des Musters wählen.

Aspose.Slides stellt über 45 vordefinierte Mustervorlagen bereit, die Sie auf Formen anwenden können, um das visuelle Erscheinungsbild Ihrer Präsentationen zu verbessern. Selbst nach Auswahl eines vordefinierten Musters können Sie die genauen Farben festlegen, die verwendet werden sollen.

So wenden Sie eine Musterfüllung auf eine Form mit Aspose.Slides an:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/).
1. Holen Sie eine Referenz zu einer Folie anhand ihres Index.
1. Fügen Sie der Folie ein [AutoShape](https://reference.aspose.com/slides/de/python-net/aspose.slides/autoshape/) hinzu.
1. Setzen Sie den [FillType](https://reference.aspose.com/slides/de/python-net/aspose.slides/filltype/) der Form auf `PATTERN`.
1. Wählen Sie einen Mustertyp aus den vordefinierten Optionen.
1. Setzen Sie die [back_color](https://reference.aspose.com/slides/de/python-net/aspose.slides/patternformat/back_color/) des Musters.
1. Setzen Sie die [fore_color](https://reference.aspose.com/slides/de/python-net/aspose.slides/patternformat/fore_color/) des Musters.
1. Speichern Sie die modifizierte Präsentation als PPTX-Datei.

Der folgende Python-Code demonstriert, wie eine Musterfüllung auf ein Rechteck angewendet wird:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
with slides.Presentation() as presentation:

    # Holen Sie die erste Folie.
    slide = presentation.slides[0]

    # Fügen Sie eine Autoform vom Typ Rechteck hinzu.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Setzen Sie den Fülltyp auf Muster.
    shape.fill_format.fill_type = slides.FillType.PATTERN

    # Setzen Sie den Musterstil.
    shape.fill_format.pattern_format.pattern_style = slides.PatternStyle.TRELLIS

    # Setzen Sie die Hintergrund- und Vordergrundfarben des Musters.
    shape.fill_format.pattern_format.back_color.color = draw.Color.light_gray
    shape.fill_format.pattern_format.fore_color.color = draw.Color.yellow

    # Speichern Sie die PPTX-Datei auf der Festplatte.
    presentation.save("pattern_fill.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![The rectangle with pattern fill](pattern-fill.png)

## **Bildfüllung**

In PowerPoint ist die Bildfüllung eine Formatierungsoption, die es ermöglicht, ein Bild in eine Form einzufügen – das Bild dient dabei als Hintergrund der Form.

So verwenden Sie Aspose.Slides, um eine Bildfüllung auf eine Form anzuwenden:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/).
1. Holen Sie eine Referenz zu einer Folie anhand ihres Index.
1. Fügen Sie der Folie ein [AutoShape](https://reference.aspose.com/slides/de/python-net/aspose.slides/autoshape/) hinzu.
1. Setzen Sie den [FillType](https://reference.aspose.com/slides/de/python-net/aspose.slides/filltype/) der Form auf `PICTURE`.
1. Setzen Sie den Bildfüllungsmodus auf `TILE` (oder einen anderen bevorzugten Modus).
1. Erstellen Sie ein [PPImage](https://reference.aspose.com/slides/de/python-net/aspose.slides/ppimage/)-Objekt aus dem Bild, das Sie verwenden möchten.
1. Weisen Sie dieses Bild der `picture.image`‑Eigenschaft des `picture_fill_format` der Form zu.
1. Speichern Sie die modifizierte Präsentation als PPTX-Datei.

Nehmen wir an, wir haben die Datei **lotus.png** mit folgendem Bild:

![The lotus picture](lotus.png)

Der folgende Python-Code demonstriert, wie eine Form mit dem Bild gefüllt wird:

```python
import aspose.slides as slides

# Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
with slides.Presentation() as presentation:

    # Holen Sie die erste Folie.
    slide = presentation.slides[0]

    # Fügen Sie eine Autoform vom Typ Rechteck hinzu.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 192, 95)

    # Setzen Sie den Fülltyp auf Bild.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Setzen Sie den Bildfüllungsmodus.
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE

    # Laden Sie ein Bild und fügen Sie es zu den Präsentationsressourcen hinzu.
    with slides.Images.from_file("lotus.png") as image:
        presentation_image = presentation.images.add_image(image)

    # Setzen Sie das Bild.
    shape.fill_format.picture_fill_format.picture.image = presentation_image

    # Speichern Sie die PPTX-Datei auf der Festplatte.
    presentation.save("picture_fill.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![The shape with picture fill](picture-fill.png)

### **Bild kacheln als Textur**

Wenn Sie ein gekacheltes Bild als Textur festlegen und das Kachelverhalten anpassen möchten, können Sie die folgenden Eigenschaften der Klasse [PictureFillFormat](https://reference.aspose.com/slides/de/python-net/aspose.slides/picturefillformat/) verwenden:

- [picture_fill_mode](https://reference.aspose.com/slides/de/python-net/aspose.slides/picturefillformat/picture_fill_mode/): Legt den Bildfüllungsmodus fest – entweder `TILE` oder `STRETCH`.
- [tile_alignment](https://reference.aspose.com/slides/de/python-net/aspose.slides/picturefillformat/tile_alignment/): Gibt die Ausrichtung der Kacheln innerhalb der Form an.
- [tile_flip](https://reference.aspose.com/slides/de/python-net/aspose.slides/picturefillformat/tile_flip/): Steuert, ob die Kachel horizontal, vertikal oder beides gespiegelt wird.
- [tile_offset_x](https://reference.aspose.com/slides/de/python-net/aspose.slides/picturefillformat/tile_offset_x/): Definiert den horizontalen Versatz der Kachel (in Punkten) vom Ursprung der Form.
- [tile_offset_y](https://reference.aspose.com/slides/de/python-net/aspose.slides/picturefillformat/tile_offset_y/): Definiert den vertikalen Versatz der Kachel (in Punkten) vom Ursprung der Form.
- [tile_scale_x](https://reference.aspose.com/slides/de/python-net/aspose.slides/picturefillformat/tile_scale_x/): Gibt die horizontale Skalierung der Kachel als Prozentsatz an.
- [tile_scale_y](https://reference.aspose.com/slides/de/python-net/aspose.slides/picturefillformat/tile_scale_y/): Gibt die vertikale Skalierung der Kachel als Prozentsatz an.

Der folgende Code zeigt, wie ein Rechteck mit einer gekachelten Bildfüllung erstellt und die Kacheloptionen konfiguriert werden:

```py
import aspose.slides as slides

# Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
with slides.Presentation() as presentation:

    # Holen Sie die erste Folie.
    first_slide = presentation.slides[0]

    # Fügen Sie eine Rechteck-Autoform hinzu.
    shape = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 190, 95)

    # Setzen Sie den Fülltyp der Form auf Bild.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Laden Sie das Bild und fügen Sie es zu den Präsentationsressourcen hinzu.
    with slides.Images.from_file("lotus.png") as source_image:
        presentation_image = presentation.images.add_image(source_image)

    # Weisen Sie das Bild der Form zu.
    picture_fill_format = shape.fill_format.picture_fill_format
    picture_fill_format.picture.image = presentation_image

    # Konfigurieren Sie den Bildfüllungsmodus und die Kacheliteigenschaften.
    picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE
    picture_fill_format.tile_offset_x = -32
    picture_fill_format.tile_offset_y = -32
    picture_fill_format.tile_scale_x = 50
    picture_fill_format.tile_scale_y = 50
    picture_fill_format.tile_alignment = slides.RectangleAlignment.BOTTOM_RIGHT
    picture_fill_format.tile_flip = slides.TileFlip.FLIP_BOTH

    # Speichern Sie die PPTX-Datei auf der Festplatte.
    presentation.save("tile.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![The tile options](tile-options.png)

## **Einfarbige Füllung**

In PowerPoint ist die einfarbige Füllung eine Formatierungsoption, die eine Form mit einer einzigen, gleichmäßigen Farbe füllt. Diese einheitliche Hintergrundfarbe wird ohne Verläufe, Texturen oder Muster angewendet.

So wenden Sie eine einfarbige Füllung auf eine Form mit Aspose.Slides an:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/).
1. Holen Sie eine Referenz zu einer Folie anhand ihres Index.
1. Fügen Sie der Folie ein [AutoShape](https://reference.aspose.com/slides/de/python-net/aspose.slides/autoshape/) hinzu.
1. Setzen Sie den [FillType](https://reference.aspose.com/slides/de/python-net/aspose.slides/filltype/) der Form auf `SOLID`.
1. Weisen Sie der Form Ihre gewünschte Füllfarbe zu.
1. Speichern Sie die modifizierte Präsentation als PPTX-Datei.

Der folgende Python-Code demonstriert, wie eine einfarbige Füllung auf ein Rechteck in einer PowerPoint‑Folie angewendet wird:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
with slides.Presentation() as presentation:

    # Holen Sie die erste Folie.
    slide = presentation.slides[0]

    # Fügen Sie eine Autoform vom Typ Rechteck hinzu.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Setzen Sie den Fülltyp auf Solid.
    shape.fill_format.fill_type = slides.FillType.SOLID

    # Setzen Sie die Füllfarbe.
    shape.fill_format.solid_fill_color.color = draw.Color.yellow

    # Speichern Sie die PPTX-Datei auf der Festplatte.
    presentation.save("solid_color_fill.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![The shape with solid color fill](solid-color-fill.png)

## **Transparenz festlegen**

In PowerPoint können Sie bei einer einfarbigen, verlaufenden, Bild‑ oder Texturfüllung die Transparenzstufe festlegen, um die Deckkraft der Füllung zu steuern. Ein höherer Transparenzwert macht die Form durchsichtiger, sodass der Hintergrund oder darunterliegende Objekte teilweise sichtbar werden.

Aspose.Slides ermöglicht das Festlegen der Transparenz, indem Sie den Alpha‑Wert in der für die Füllung verwendeten Farbe anpassen. So gehen Sie vor:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/).
1. Holen Sie eine Referenz zu einer Folie anhand ihres Index.
1. Fügen Sie der Folie ein [AutoShape](https://reference.aspose.com/slides/de/python-net/aspose.slides/autoshape/) hinzu.
1. Setzen Sie den Fülltyp auf `SOLID`.
1. Verwenden Sie `Color.from_argb`, um eine Farbe mit Transparenz zu definieren (die `alpha`‑Komponente steuert die Transparenz).
1. Speichern Sie die Präsentation.

Der folgende Python-Code demonstriert, wie eine transparente Füllfarbe auf ein Rechteck angewendet wird:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
with slides.Presentation() as presentation:

    # Holen Sie die erste Folie.
    slide = presentation.slides[0]
    
    # Fügen Sie eine solide Rechteck-Autoform hinzu.
    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Fügen Sie über der soliden Form eine transparente Rechteck-Autoform hinzu.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 80, 150, 75)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.from_argb(128, 204, 102, 0)
    
    presentation.save("shape_transparency.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![The transparent shape](shape-transparency.png)

## **Formen drehen**

Aspose.Slides ermöglicht das Drehen von Formen in PowerPoint‑Präsentationen. Dies kann nützlich sein, wenn Sie visuelle Elemente mit bestimmten Ausrichtungs‑ oder Designanforderungen positionieren möchten.

So drehen Sie eine Form auf einer Folie:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/).
1. Holen Sie eine Referenz zu einer Folie anhand ihres Index.
1. Fügen Sie der Folie ein [AutoShape](https://reference.aspose.com/slides/de/python-net/aspose.slides/autoshape/) hinzu.
1. Setzen Sie die `rotation`‑Eigenschaft der Form auf den gewünschten Winkel.
1. Speichern Sie die Präsentation.

Der folgende Python-Code demonstriert, wie eine Form um 5 Grad gedreht wird:

```python
import aspose.slides as slides

# Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
with slides.Presentation() as presentation:

    # Holen Sie die erste Folie.
    slide = presentation.slides[0]

    # Fügen Sie eine Autoform vom Typ Rechteck hinzu.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Drehen Sie die Form um 5 Grad.
    shape.rotation = 5

    # Speichern Sie die PPTX-Datei auf der Festplatte.
    presentation.save("shape_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![The shape rotation](shape-rotation.png)

## **3D‑Fasen‑Effekte hinzufügen**

Aspose.Slides ermöglicht das Anwenden von 3D‑Fasen‑Effekten auf Formen, indem Sie deren [ThreeDFormat](https://reference.aspose.com/slides/de/python-net/aspose.slides/threedformat/)‑Eigenschaften konfigurieren.

So fügen Sie einer Form 3D‑Fasen‑Effekte hinzu:

1. Instanziieren Sie die Klasse [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/).
1. Holen Sie eine Referenz zu einer Folie anhand ihres Index.
1. Fügen Sie der Folie ein [AutoShape](https://reference.aspose.com/slides/de/python-net/aspose.slides/autoshape/) hinzu.
1. Konfigurieren Sie das [ThreeDFormat](https://reference.aspose.com/slides/de/python-net/aspose.slides/threedformat/) der Form, um die Fasen‑Einstellungen festzulegen.
1. Speichern Sie die Präsentation.

Der folgende Python-Code zeigt, wie 3D‑Fasen‑Effekte auf eine Form angewendet werden:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Eine Instanz der Presentation-Klasse erstellen.
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    # Eine Form zur Folie hinzufügen.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.green
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.orange
    shape.line_format.width = 2.0

    # Die ThreeDFormat-Eigenschaften der Form festlegen.
    shape.three_d_format.depth = 4
    shape.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    shape.three_d_format.bevel_top.height = 6
    shape.three_d_format.bevel_top.width = 6
    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.THREE_PT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP

    # Die Präsentation als PPTX-Datei speichern.
    presentation.save("3D_bevel_effect.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![The 3D bevel effect](3D-bevel-effect.png)

## **3D‑Drehungseffekte hinzufügen**

Aspose.Slides ermöglicht das Anwenden von 3D‑Drehungseffekten auf Formen, indem Sie deren [ThreeDFormat](https://reference.aspose.com/slides/de/python-net/aspose.slides/threedformat/)‑Eigenschaften konfigurieren.

So wenden Sie eine 3D‑Drehung auf eine Form an:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/).
1. Holen Sie eine Referenz zu einer Folie anhand ihres Index.
1. Fügen Sie der Folie ein [AutoShape](https://reference.aspose.com/slides/de/python-net/aspose.slides/autoshape/) hinzu.
1. Setzen Sie den [camera_type](https://reference.aspose.com/slides/de/python-net/aspose.slides/camera/camera_type/) und den [light_type](https://reference.aspose.com/slides/de/python-net/aspose.slides/lightrig/light_type/) der Form, um die 3D‑Drehung zu definieren.
1. Speichern Sie die Präsentation.

Der folgende Python-Code demonstriert, wie 3D‑Drehungseffekte auf eine Form angewendet werden:

```python
import aspose.slides as slides

# Eine Instanz der Presentation-Klasse erstellen.
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    auto_shape.text_frame.text = "Hello, Aspose!"

    auto_shape.three_d_format.depth = 6
    auto_shape.three_d_format.camera.set_rotation(40, 35, 20)
    auto_shape.three_d_format.camera.camera_type = slides.CameraPresetType.ISOMETRIC_LEFT_UP
    auto_shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED

    # Speichern Sie die Präsentation als PPTX-Datei.      
    presentation.save("3D_rotation_effect.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![The 3D rotation effect](3D-rotation-effect.png)

## **Formatierung zurücksetzen**

Der folgende Python-Code zeigt, wie die Formatierung einer Folie zurückgesetzt und die Position, Größe und Formatierung aller Formen mit Platzhaltern auf der [LayoutSlide](https://reference.aspose.com/slides/de/python-net/aspose.slides/layoutslide/) auf ihre Standardwerte zurückgesetzt werden:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:

    for slide in presentation.slides:
        # Setze jede Form auf der Folie zurück, die einen Platzhalter im Layout hat.
        slide.reset()

    presentation.save("reset_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Beeinflusst die Formatierung von Formen die endgültige Dateigröße der Präsentation?**

Nur minimal. Eingebettete Bilder und Medien belegen den größten Teil des Dateiraums, während Formparameter wie Farben, Effekte und Verläufe als Metadaten gespeichert werden und praktisch keinen zusätzlichen Speicherplatz benötigen.

**Wie kann ich Formen auf einer Folie erkennen, die identische Formatierungen besitzen, um sie zu gruppieren?**

Vergleichen Sie die wichtigsten Formatierungseigenschaften jeder Form – Füll‑, Linien‑ und Effekt‑Einstellungen. Stimmen alle entsprechenden Werte überein, behandeln Sie deren Stile als identisch und gruppieren Sie die Formen logisch, was die spätere Stilverwaltung vereinfacht.

**Kann ich ein Set benutzerdefinierter Formstile in einer separaten Datei speichern, um sie in anderen Präsentationen wiederzuverwenden?**

Ja. Speichern Sie Beispiel‑Formen mit den gewünschten Stilen in einem Vorlagen‑Slide‑Deck oder einer .POTX‑Vorlagendatei. Beim Erstellen einer neuen Präsentation öffnen Sie die Vorlage, kopieren die stilisierten Formen, die Sie benötigen, und wenden deren Formatierung dort an, wo sie gebraucht wird.