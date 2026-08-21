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
- Skizzenformlinie
- Verbindungsstil formatieren
- Verlaufsfüllung
- Musterfüllung
- Bildfüllung
- Texturfüllung
- Einfarbige Füllung
- Formtransparenz
- Schwarz-Weiß-Darstellung von Formen
- Graustufen-Darstellung von Formen
- Form drehen
- 3D-Fasen-Effekt
- 3D-Dreh-Effekt
- Formatierung zurücksetzen
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint-Formen in Python mit Aspose.Slides formatieren – füllen, Linien und Effekte für PPT-, PPTX- und ODP-Dateien präzise und vollständig steuern."
---
## **Einleitung**

In PowerPoint können Sie Formen zu Folien hinzufügen. Da Formen aus Linien bestehen, können Sie sie formatieren, indem Sie die Umrandungen ändern oder Effekte darauf anwenden. Zusätzlich können Sie Formen formatieren, indem Sie Einstellungen festlegen, die steuern, wie deren Innenflächen gefüllt werden.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides für Python stellt Klassen und Eigenschaften bereit, mit denen Sie Formen mit denselben Optionen wie in PowerPoint formatieren können.

## **Linien formatieren**

Mit Aspose.Slides können Sie für eine Form einen benutzerdefinierten Linienstil festlegen. Die folgenden Schritte beschreiben das Verfahren:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/) Klasse.
1. Holen Sie sich einen Verweis auf eine Folie über ihren Index.
1. Fügen Sie der Folie eine [AutoShape](https://reference.aspose.com/slides/de/python-net/aspose.slides/autoshape/) hinzu.
1. Setzen Sie den [line style](https://reference.aspose.com/slides/de/python-net/aspose.slides/linestyle/) der Form.
1. Setzen Sie die Linienbreite.
1. Setzen Sie den [dash style](https://reference.aspose.com/slides/de/python-net/aspose.slides/linedashstyle/) der Form.
1. Legen Sie die Linienfarbe für die Form fest.
1. Speichern Sie die modifizierte Präsentation als PPTX‑Datei.

Der folgende Python‑Code demonstriert, wie ein Rechteck‑`AutoShape` formatiert wird:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
with slides.Presentation() as presentation:

    # Holen Sie die erste Folie.
    slide = presentation.slides[0]

    # Fügen Sie eine AutoForm vom Typ Rechteck hinzu.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 75)

    # Entfernen Sie die Füllung von der Rechteckform, sodass nur ihre Linien sichtbar sind.
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    # Wenden Sie die Formatierung auf die Linien des Rechtecks an.
    shape.line_format.style = slides.LineStyle.THICK_THIN
    shape.line_format.width = 7
    shape.line_format.dash_style = slides.LineDashStyle.DASH

    # Legen Sie die Farbe für die Linie des Rechtecks fest.
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue

    # Speichern Sie die PPTX-Datei auf dem Datenträger.
    presentation.save("formatted_lines.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![The formatted lines in the presentation](formatted-lines.png)

## **Skizzeneffekte auf Formlinien anwenden**

Ein Skizzeneffekt lässt eine Formlinie handgezeichnet wirken. Verwenden Sie [Shape.line_format](https://reference.aspose.com/slides/de/python-net/aspose.slides/shape/line_format/), um auf die Linieneinstellungen zuzugreifen, [LineFormat.sketch_format](https://reference.aspose.com/slides/de/python-net/aspose.slides/lineformat/sketch_format/), um auf die Skizzeeinstellungen zuzugreifen, und [SketchFormat.sketch_type](https://reference.aspose.com/slides/de/python-net/aspose.slides/sketchformat/sketch_type/), um einen Wert aus der Aufzählung [LineSketchType](https://reference.aspose.com/slides/de/python-net/aspose.slides/linesketchtype/) auszuwählen.

Der folgende Python‑Code zeigt, wie der Effekt [LineSketchType.CURVED](https://reference.aspose.com/slides/de/python-net/aspose.slides/linesketchtype/) angewendet, der explizit zugewiesene Wert ausgelesen und der Effekt mit [LineSketchType.NONE](https://reference.aspose.com/slides/de/python-net/aspose.slides/linesketchtype/) entfernt wird:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)

    # Greifen Sie auf das Linienformat der Form und dessen Skizzenformat zu.
    sketch_format = shape.line_format.sketch_format

    # Wenden Sie einen Skizzeneffekt an.
    sketch_format.sketch_type = slides.LineSketchType.CURVED

    # Lesen Sie den der Form direkt zugewiesenen Skizzeneffekt.
    explicit_sketch_type = sketch_format.sketch_type
    print(f"Explicit sketch type: {explicit_sketch_type}")

    # Entfernen Sie den Skizzeneffekt.
    sketch_format.sketch_type = slides.LineSketchType.NONE
```

Der von `SketchFormat.sketch_type` zurückgegebene Wert stellt die direkt der Form zugewiesene Einstellung dar. Wenn die Linienformatierung von einem Design, einer Master‑Folien‑ oder Layout‑Folien‑Vorlage ererbt werden kann, verwenden Sie [LineFormat.get_effective](https://reference.aspose.com/slides/de/python-net/aspose.slides/lineformat/get_effective/), greifen Sie auf die `sketch_format`‑Eigenschaft des zurückgegebenen Objekts zu und lesen Sie dessen `sketch_type`‑Eigenschaft. Der effektive Wert spiegelt die tatsächlich angewendete Formatierung wider, nachdem die Vererbung aufgelöst wurde:

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

## **Verbindungsarten formatieren**

Hier sind die drei verfügbaren Verbindungsarten:

* Rund
* Gehrung
* Abschrägung

Standardmäßig verwendet PowerPoint beim Zusammenführen zweier Linien in einem Winkel (z. B. an der Ecke einer Form) die Einstellung **Rund**. Wenn Sie jedoch eine Form mit scharfen Winkeln zeichnen, bevorzugen Sie möglicherweise die Option **Gehrung**.

![The join style in the presentation](join-style-powerpoint.png)

Der folgende Python‑Code demonstriert, wie drei Rechtecke (wie im Bild oben gezeigt) mit den Verbindungsarten Gehrung, Abschrägung und Rund erstellt wurden:

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

	# Setzen Sie die Füllfarbe für jede Rechteckform.
	shape1.fill_format.fill_type = slides.FillType.SOLID
	shape1.fill_format.solid_fill_color.color = draw.Color.black
	shape2.fill_format.fill_type = slides.FillType.SOLID
	shape2.fill_format.solid_fill_color.color = draw.Color.black
	shape3.fill_format.fill_type = slides.FillType.SOLID
	shape3.fill_format.solid_fill_color.color = draw.Color.black

	# Setzen Sie die Linienbreite.
	shape1.line_format.width = 15
	shape2.line_format.width = 15
	shape3.line_format.width = 15

	# Setzen Sie die Farbe für die Linie jedes Rechtecks.
	shape1.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape1.line_format.fill_format.solid_fill_color.color = draw.Color.blue
	shape2.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape2.line_format.fill_format.solid_fill_color.color = draw.Color.blue
	shape3.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape3.line_format.fill_format.solid_fill_color.color = draw.Color.blue

	# Setzen Sie den Verbindungsstil.
	shape1.line_format.join_style = slides.LineJoinStyle.MITER
	shape2.line_format.join_style = slides.LineJoinStyle.BEVEL
	shape3.line_format.join_style = slides.LineJoinStyle.ROUND

	# Fügen Sie jedem Rechteck Text hinzu.
	shape1.text_frame.text = "Miter Join style"
	shape2.text_frame.text = "Bevel Join style"
	shape3.text_frame.text = "Round Join style"

	# Speichern Sie die PPTX-Datei auf dem Datenträger.
	presentation.save("join_styles.pptx", slides.export.SaveFormat.PPTX)
```

## **Verlaufsfüllung**

In PowerPoint ist die Verlaufsfüllung eine Formatierungsoption, die es ermöglicht, einer Form einen kontinuierlichen Farbübergang zuzuweisen. Sie können beispielsweise zwei oder mehr Farben so anwenden, dass die eine allmählich in die andere übergeht.

So wenden Sie eine Verlaufsfüllung auf eine Form mit Aspose.Slides an:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/) Klasse.
1. Holen Sie sich einen Verweis auf eine Folie über ihren Index.
1. Fügen Sie der Folie eine [AutoShape](https://reference.aspose.com/slides/de/python-net/aspose.slides/autoshape/) hinzu.
1. Setzen Sie das [FillType](https://reference.aspose.com/slides/de/python-net/aspose.slides/filltype/) der Form auf `GRADIENT`.
1. Fügen Sie Ihre beiden gewünschten Farben mit definierten Positionen über die `add`‑Methoden der `gradient_stops`‑Sammlung der [GradientFormat](https://reference.aspose.com/slides/de/python-net/aspose.slides/gradientformat/)‑Klasse hinzu.
1. Speichern Sie die modifizierte Präsentation als PPTX‑Datei.

Der folgende Python‑Code demonstriert, wie ein Verlaufseffekt auf eine Ellipse angewendet wird:

```python
import aspose.slides as slides

# Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
with slides.Presentation() as presentation:

    # Holen Sie die erste Folie.
    slide = presentation.slides[0]

    # Fügen Sie eine Autoform vom Typ Ellipse hinzu.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 150, 75)

    # Wenden Sie die Verlaufformatierung auf die Ellipse an.
    shape.fill_format.fill_type = slides.FillType.GRADIENT
    shape.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR

    # Setzen Sie die Richtung des Verlaufs.
    shape.fill_format.gradient_format.gradient_direction = slides.GradientDirection.FROM_CORNER2

    # Fügen Sie zwei Farbverlaufspunkte hinzu.
    shape.fill_format.gradient_format.gradient_stops.add(1.0, slides.PresetColor.PURPLE)
    shape.fill_format.gradient_format.gradient_stops.add(0, slides.PresetColor.RED)

    # Speichern Sie die PPTX-Datei auf dem Datenträger.
    presentation.save("gradient_fill.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![The ellipse with gradient fill](gradient-fill.png)

## **Musterfüllung**

In PowerPoint ist die Musterfüllung eine Formatierungsoption, mit der Sie ein zweifarbiges Design – etwa Punkte, Streifen, Kreuzschraffuren oder Karos – auf eine Form anwenden können. Sie können eigene Vorder‑ und Hintergrundfarben für das Muster auswählen.

Aspose.Slides stellt über 45 vordefinierte Musterstile bereit, die Sie Formen zuweisen können, um die visuelle Wirkung Ihrer Präsentationen zu erhöhen. Auch nach der Auswahl eines vordefinierten Musters können Sie die genauen Farben festlegen, die verwendet werden sollen.

So wenden Sie eine Musterfüllung auf eine Form mit Aspose.Slides an:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/) Klasse.
1. Holen Sie sich einen Verweis auf eine Folie über ihren Index.
1. Fügen Sie der Folie eine [AutoShape](https://reference.aspose.com/slides/de/python-net/aspose.slides/autoshape/) hinzu.
1. Setzen Sie das [FillType](https://reference.aspose.com/slides/de/python-net/aspose.slides/filltype/) der Form auf `PATTERN`.
1. Wählen Sie einen Musterstil aus den vordefinierten Optionen.
1. Setzen Sie die [back_color](https://reference.aspose.com/slides/de/python-net/aspose.slides/patternformat/back_color/) des Musters.
1. Setzen Sie die [fore_color](https://reference.aspose.com/slides/de/python-net/aspose.slides/patternformat/fore_color/) des Musters.
1. Speichern Sie die modifizierte Präsentation als PPTX‑Datei.

Der folgende Python‑Code demonstriert, wie eine Musterfüllung auf ein Rechteck angewendet wird:

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

    # Speichern Sie die PPTX-Datei auf dem Datenträger.
    presentation.save("pattern_fill.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![The rectangle with pattern fill](pattern-fill.png)

## **Bildfüllung**

In PowerPoint ist die Bildfüllung eine Formatierungsoption, die es ermöglicht, ein Bild in eine Form einzufügen – das Bild dient dabei als Hintergrund der Form.

So verwenden Sie Aspose.Slides, um einer Form eine Bildfüllung zuzuweisen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/) Klasse.
1. Holen Sie sich einen Verweis auf eine Folie über ihren Index.
1. Fügen Sie der Folie eine [AutoShape](https://reference.aspose.com/slides/de/python-net/aspose.slides/autoshape/) hinzu.
1. Setzen Sie das [FillType](https://reference.aspose.com/slides/de/python-net/aspose.slides/filltype/) der Form auf `PICTURE`.
1. Setzen Sie den Bildfüllungsmodus auf `TILE` (oder einen anderen gewünschten Modus).
1. Erzeugen Sie ein [PPImage](https://reference.aspose.com/slides/de/python-net/aspose.slides/ppimage/)‑Objekt aus dem gewünschten Bild.
1. Weisen Sie dieses Bild der Eigenschaft `picture.image` des `picture_fill_format` der Form zu.
1. Speichern Sie die modifizierte Präsentation als PPTX‑Datei.

Angenommen, wir haben die Datei **lotus.png** mit folgendem Bild:

![The lotus picture](lotus.png)

Der folgende Python‑Code demonstriert, wie eine Form mit dem Bild gefüllt wird:

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

    # Speichern Sie die PPTX-Datei auf dem Datenträger.
    presentation.save("picture_fill.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![The shape with picture fill](picture-fill.png)

### **Bild kacheln als Textur**

Wenn Sie ein gekacheltes Bild als Textur festlegen und das Kachelverhalten anpassen möchten, können Sie die folgenden Eigenschaften der Klasse [PictureFillFormat](https://reference.aspose.com/slides/de/python-net/aspose.slides/picturefillformat/) verwenden:

- [picture_fill_mode](https://reference.aspose.com/slides/de/python-net/aspose.slides/picturefillformat/picture_fill_mode/): Legt den Bildfüllungsmodus fest – entweder `TILE` oder `STRETCH`.
- [tile_alignment](https://reference.aspose.com/slides/de/python-net/aspose.slides/picturefillformat/tile_alignment/): Gibt die Ausrichtung der Kacheln innerhalb der Form an.
- [tile_flip](https://reference.aspose.com/slides/de/python-net/aspose.slides/picturefillformat/tile_flip/): Steuert, ob die Kachel horizontal, vertikal oder beides gespiegelt wird.
- [tile_offset_x](https://reference.aspose.com/slides/de/python-net/aspose.slides/picturefillformat/tile_offset_x/): Setzt den horizontalen Versatz der Kachel (in Punkten) vom Ursprung der Form.
- [tile_offset_y](https://reference.aspose.com/slides/de/python-net/aspose.slides/picturefillformat/tile_offset_y/): Setzt den vertikalen Versatz der Kachel (in Punkten) vom Ursprung der Form.
- [tile_scale_x](https://reference.aspose.com/slides/de/python-net/aspose.slides/picturefillformat/tile_scale_x/): Definiert die horizontale Skalierung der Kachel als Prozentsatz.
- [tile_scale_y](https://reference.aspose.com/slides/de/python-net/aspose.slides/picturefillformat/tile_scale_y/): Definiert die vertikale Skalierung der Kachel als Prozentsatz.

Der folgende Code‑Auszug zeigt, wie ein Rechteck mit gekachelter Bildfüllung erstellt und die Kacheloptionen konfiguriert werden:

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

    # Konfigurieren Sie den Bildfüllungsmodus und die Kachel‑Eigenschaften.
    picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE
    picture_fill_format.tile_offset_x = -32
    picture_fill_format.tile_offset_y = -32
    picture_fill_format.tile_scale_x = 50
    picture_fill_format.tile_scale_y = 50
    picture_fill_format.tile_alignment = slides.RectangleAlignment.BOTTOM_RIGHT
    picture_fill_format.tile_flip = slides.TileFlip.FLIP_BOTH

    # Speichern Sie die PPTX-Datei auf dem Datenträger.
    presentation.save("tile.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![The tile options](tile-options.png)

## **Einfarbige Füllung**

In PowerPoint ist die einfarbige Füllung eine Formatierungsoption, die eine Form mit einer einzigen, gleichmäßigen Farbe füllt. Dieser einheitliche Hintergrund wird ohne Verläufe, Texturen oder Muster angewendet.

So wenden Sie eine einfarbige Füllung auf eine Form mit Aspose.Slides an:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/) Klasse.
1. Holen Sie sich einen Verweis auf eine Folie über ihren Index.
1. Fügen Sie der Folie eine [AutoShape](https://reference.aspose.com/slides/de/python-net/aspose.slides/autoshape/) hinzu.
1. Setzen Sie das [FillType](https://reference.aspose.com/slides/de/python-net/aspose.slides/filltype/) der Form auf `SOLID`.
1. Weisen Sie der Form Ihre bevorzugte Füllfarbe zu.
1. Speichern Sie die modifizierte Präsentation als PPTX‑Datei.

Der folgende Python‑Code demonstriert, wie eine einfarbige Füllung auf ein Rechteck in einer PowerPoint‑Folien angewendet wird:

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

    # Speichern Sie die PPTX-Datei auf dem Datenträger.
    presentation.save("solid_color_fill.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![The shape with solid color fill](solid-color-fill.png)

## **Transparenz festlegen**

In PowerPoint können Sie bei einer einfarbigen, Verlauf‑, Bild‑ oder Texturfüllung die Transparenz einstellen, um die Deckkraft der Füllung zu steuern. Ein höherer Transparenzwert lässt die Form durchsichtiger werden, sodass der Hintergrund oder darunterliegende Objekte teilweise sichtbar sind.

Aspose.Slides ermöglicht das Festlegen des Transparenzwerts, indem Sie den Alpha‑Wert der für die Füllung verwendeten Farbe anpassen. So geht’s:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/) Klasse.
1. Holen Sie sich einen Verweis auf eine Folie über ihren Index.
1. Fügen Sie der Folie eine [AutoShape](https://reference.aspose.com/slides/de/python-net/aspose.slides/autoshape/) hinzu.
1. Setzen Sie den Füllungstyp auf `SOLID`.
1. Verwenden Sie `Color.from_argb`, um eine Farbe mit Transparenz zu definieren (die `alpha`‑Komponente steuert die Transparenz).
1. Speichern Sie die Präsentation.

Der folgende Python‑Code demonstriert, wie eine transparente Füllfarbe auf ein Rechteck angewendet wird:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
with slides.Presentation() as presentation:

    # Holen Sie die erste Folie.
    slide = presentation.slides[0]
    
    # Fügen Sie eine solide Rechteck-Autoform hinzu.
    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Fügen Sie eine transparente Rechteck-Autoform über der soliden Form hinzu.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 80, 150, 75)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.from_argb(128, 204, 102, 0)
    
    presentation.save("shape_transparency.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![The transparent shape](shape-transparency.png)

## **Formen drehen**

Aspose.Slides ermöglicht das Drehen von Formen in PowerPoint‑Präsentationen. Dies kann nützlich sein, um visuelle Elemente mit bestimmten Ausrichtungs‑ oder Designanforderungen zu positionieren.

So drehen Sie eine Form auf einer Folie:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/) Klasse.
1. Holen Sie sich einen Verweis auf eine Folie über ihren Index.
1. Fügen Sie der Folie eine [AutoShape](https://reference.aspose.com/slides/de/python-net/aspose.slides/autoshape/) hinzu.
1. Setzen Sie die Eigenschaft `rotation` der Form auf den gewünschten Winkel.
1. Speichern Sie die Präsentation.

Der folgende Python‑Code demonstriert, wie eine Form um 5 Grad gedreht wird:

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

    # Speichern Sie die PPTX-Datei auf dem Datenträger.
    presentation.save("shape_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![The shape rotation](shape-rotation.png)

## **3D‑Fasen‑Effekte hinzufügen**

Aspose.Slides ermöglicht das Hinzufügen von 3D‑Fasen‑Effekten zu Formen, indem die Eigenschaften des [ThreeDFormat](https://reference.aspose.com/slides/de/python-net/aspose.slides/threedformat/) konfiguriert werden.

So fügen Sie einer Form 3D‑Fasen‑Effekte hinzu:

1. Instanziieren Sie die [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/) Klasse.
1. Holen Sie sich einen Verweis auf eine Folie über ihren Index.
1. Fügen Sie der Folie eine [AutoShape](https://reference.aspose.com/slides/de/python-net/aspose.slides/autoshape/) hinzu.
1. Konfigurieren Sie das [ThreeDFormat](https://reference.aspose.com/slides/de/python-net/aspose.slides/threedformat/) der Form, um die Fasen­einstellungen zu definieren.
1. Speichern Sie die Präsentation.

Der folgende Python‑Code zeigt, wie 3D‑Fasen‑Effekte auf eine Form angewendet werden:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Erstelle eine Instanz der Presentation-Klasse.
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    # Füge der Folie eine Form hinzu.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.green
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.orange
    shape.line_format.width = 2.0

    # Setze die ThreeDFormat-Eigenschaften der Form.
    shape.three_d_format.depth = 4
    shape.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    shape.three_d_format.bevel_top.height = 6
    shape.three_d_format.bevel_top.width = 6
    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.THREE_PT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP

    # Speichere die Präsentation als PPTX-Datei.
    presentation.save("3D_bevel_effect.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![The 3D bevel effect](3D-bevel-effect.png)

## **3D‑Dreh‑Effekte hinzufügen**

Aspose.Slides ermöglicht das Hinzufügen von 3D‑Dreh‑Effekten zu Formen, indem die Eigenschaften des [ThreeDFormat](https://reference.aspose.com/slides/de/python-net/aspose.slides/threedformat/) konfiguriert werden.

So wenden Sie 3D‑Dreh‑Effekte auf eine Form an:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/) Klasse.
1. Holen Sie sich einen Verweis auf eine Folie über ihren Index.
1. Fügen Sie der Folie eine [AutoShape](https://reference.aspose.com/slides/de/python-net/aspose.slides/autoshape/) hinzu.
1. Setzen Sie den [camera_type](https://reference.aspose.com/slides/de/python-net/aspose.slides/camera/camera_type/) und den [light_type](https://reference.aspose.com/slides/de/python-net/aspose.slides/lightrig/light_type/) der Form, um die 3D‑Drehung zu definieren.
1. Speichern Sie die Präsentation.

Der folgende Python‑Code demonstriert, wie 3D‑Dreh‑Effekte auf eine Form angewendet werden:

```python
import aspose.slides as slides

# Erstelle eine Instanz der Presentation-Klasse.
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    auto_shape.text_frame.text = "Hello, Aspose!"

    auto_shape.three_d_format.depth = 6
    auto_shape.three_d_format.camera.set_rotation(40, 35, 20)
    auto_shape.three_d_format.camera.camera_type = slides.CameraPresetType.ISOMETRIC_LEFT_UP
    auto_shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED

    # Speichere die Präsentation als PPTX-Datei.      
    presentation.save("3D_rotation_effect.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![The 3D rotation effect](3D-rotation-effect.png)

## **Schwarz‑Weiß‑Darstellung von Formen steuern**

Die Eigenschaft [Shape.black_white_mode](https://reference.aspose.com/slides/de/python-net/aspose.slides/shape/black_white_mode/) legt fest, wie eine einzelne Form gerendert wird, wenn eine Präsentation im Schwarz‑Weiß‑Modus angezeigt oder verarbeitet wird. Sie aktiviert die Schwarz‑Weiß‑Darstellung nicht selbst und ändert die Füll‑, Linien‑ oder sonstige Formatierung der Form im normalen Farbmodus nicht.

Verwenden Sie einen Wert aus der Aufzählung [BlackWhiteMode](https://reference.aspose.com/slides/de/python-net/aspose.slides/blackwhitemode/), um das gewünschte Verhalten auszuwählen. Beispiel: `AUTOMATIC` lässt die Rendering‑Anwendung die Umwandlung wählen, `GRAY` und `LIGHT_GRAY` verwenden Graustufen, `BLACK_WHITE` nutzt ausschließlich Schwarz und Weiß, `BLACK` und `WHITE` erzwingen eine einfarbige Darstellung, `COLOR` erhält die normale Farbdarstellung und `HIDDEN` blendet die Form im Schwarz‑Weiß‑Modus aus. `NOT_DEFINED` bedeutet, dass kein Form‑Ebene‑Modus zugewiesen ist.

Der folgende Python‑Code erstellt eine farbige Form und lässt sie im Schwarz‑Weiß‑Modus grau erscheinen:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.orange

    # Behalte die orange Füllung im Farbmodus, aber rendere die Form mit grauer Färbung im Schwarz-Weiß-Modus.
    shape.black_white_mode = slides.BlackWhiteMode.GRAY

    presentation.save("shape_black_white_mode.pptx", slides.export.SaveFormat.PPTX)
```

Im normalen Farbmodus behält das Rechteck seine orange Füllung. Im Schwarz‑Weiß‑Workflow wird es grau angezeigt, weil sein Modus auf `GRAY` gesetzt ist. So können Sie eine Voll‑Farb‑Folienpräsentation beibehalten und gleichzeitig ein abweichendes Erscheinungsbild für Druck, Vorschau oder andere Workflows definieren, die die Schwarz‑Weiß‑Anzeige berücksichtigen.

## **Formatierung zurücksetzen**

Der folgende Python‑Code zeigt, wie die Formatierung einer Folie zurückgesetzt und die Position, Größe und Formatierung aller Formen mit Platzhaltern auf dem [LayoutSlide](https://reference.aspose.com/slides/de/python-net/aspose.slides/layoutslide/) auf die Standard‑Einstellungen zurückgesetzt werden:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:

    for slide in presentation.slides:
        # Setze jede Form auf der Folie zurück, die einen Platzhalter im Layout besitzt.
        slide.reset()

    presentation.save("reset_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Wirkt sich die Formformatierung auf die endgültige Dateigröße der Präsentation aus?**

Nur sehr geringfügig. Eingebettete Bilder und Medien belegen den Großteil des Dateiraums, während Form‑Parameter wie Farben, Effekte und Verläufe als Metadaten gespeichert werden und praktisch keinen zusätzlichen Platz beanspruchen.

**Wie kann ich Formen auf einer Folie erkennen, die identische Formatierung besitzen, um sie zu gruppieren?**

Vergleichen Sie die wichtigsten Formatierungseigenschaften jeder Form – Füllung, Linie und Effekte. Stimmen alle entsprechenden Werte überein, behandeln Sie die Stile als identisch und gruppieren Sie die Formen logisch, was die spätere Stilverwaltung vereinfacht.

**Kann ich ein Set benutzerdefinierter Formstile in einer separaten Datei speichern, um es in anderen Präsentationen wiederzuverwenden?**

Ja. Speichern Sie Beispiel‑Formen mit den gewünschten Stilen in einer Vorlagen‑Präsentation oder einer .POTX‑Datei. Beim Erstellen einer neuen Präsentation öffnen Sie die Vorlage, duplizieren die benötigten stilisierten Formen und wenden deren Formatierung dort an, wo sie benötigt wird.