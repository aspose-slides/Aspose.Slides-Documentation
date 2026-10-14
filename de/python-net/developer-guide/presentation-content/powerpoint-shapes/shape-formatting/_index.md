---
title: PowerPoint-Formen in Python formatieren
linktitle: Formenformatierung
type: docs
weight: 20
url: /de/python-net/shape-formatting/
keywords:
- Form formatieren
- Linie formatieren
- Skizzen-Effekt
- Skizzenlinienform
- Verbindungsstil formatieren
- Verlaufsfüllung
- Musterfüllung
- Bildfüllung
- Texturfüllung
- Einfarbige Füllung
- Form-Transparenz
- Schwarz-Weiß-Formendarstellung
- Graustufen-Formendarstellung
- Form drehen
- 3D-Kehlungs-Effekt
- 3D-Rotations-Effekt
- Formatierung zurücksetzen
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint-Formen in Python mit Aspose.Slides formatieren — füllen, Linien- und Effektstile für PPT-, PPTX- und ODP-Dateien präzise und vollständig steuern."
---
## **Einleitung**

In PowerPoint können Sie Formen zu Folien hinzufügen. Da Formen aus Linien bestehen, können Sie sie formatieren, indem Sie die Konturen ändern oder Effekte darauf anwenden. Zusätzlich können Sie Formen formatieren, indem Sie Einstellungen festlegen, die steuern, wie deren Innenbereiche gefüllt werden.

![Form formatieren PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for Python stellt Klassen und Eigenschaften bereit, mit denen Sie Formen mit denselben Optionen formatieren können, die in PowerPoint verfügbar sind.

## **Linien formatieren**

Mit Aspose.Slides können Sie für eine Form einen benutzerdefinierten Linienstil festlegen. Die folgenden Schritte beschreiben das Vorgehen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
1. Holen Sie eine Referenz zu einer Folie anhand ihres Index.
1. Fügen Sie der Folie eine [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) hinzu.
1. Setzen Sie den [Linienstil](https://reference.aspose.com/slides/python-net/aspose.slides/linestyle/) der Form.
1. Legen Sie die Linienbreite fest.
1. Setzen Sie den [Strichstil](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/) der Form.
1. Legen Sie die Linienfarbe für die Form fest.
1. Speichern Sie die bearbeitete Präsentation als PPTX-Datei.

Der folgende Python‑Code demonstriert, wie man ein Rechteck‑`AutoShape` formatieren kann:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
with slides.Presentation() as presentation:

    # Holen Sie die erste Folie.
    slide = presentation.slides[0]

    # Fügen Sie eine AutoShape des Typs Rechteck hinzu.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 75)

    # Entfernen Sie die Füllung der Rechteckform, sodass nur ihre Linien sichtbar sind.
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

![Die formatierten Linien in der Präsentation](formatted-lines.png)

## **Skizze‑Effekte auf Formenlinien anwenden**

Ein Skizze‑Effekt lässt eine Formenlinie handgezeichnet erscheinen. Verwenden Sie [Shape.line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/), um auf die Linieneinstellungen zuzugreifen, [LineFormat.sketch_format](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/sketch_format/), um auf die Skizze‑Einstellungen zuzugreifen, und [SketchFormat.sketch_type](https://reference.aspose.com/slides/python-net/aspose.slides/sketchformat/sketch_type/), um einen Wert aus der [LineSketchType](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/) Aufzählung auszuwählen.

Der folgende Python‑Code zeigt, wie man einen [LineSketchType.CURVED](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/)‑Effekt anwendet, den explizit zugewiesenen Wert ausliest und den Effekt mit [LineSketchType.NONE](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/) entfernt:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)

    # Greifen Sie auf das Linienformat der Form und deren Skizzenformat zu.
    sketch_format = shape.line_format.sketch_format

    # Wenden Sie einen Skizze-Effekt an.
    sketch_format.sketch_type = slides.LineSketchType.CURVED

    # Lesen Sie den direkt der Form zugewiesenen Skizze-Effekt.
    explicit_sketch_type = sketch_format.sketch_type
    print(f"Explicit sketch type: {explicit_sketch_type}")

    # Entfernen Sie den Skizze-Effekt.
    sketch_format.sketch_type = slides.LineSketchType.NONE
```

Der von `SketchFormat.sketch_type` zurückgegebene Wert stellt die direkt der Form zugewiesene Einstellung dar. Wenn die Linienformatierung von einem Design, einer Master‑Folien‑ oder Layout‑Folie geerbt werden kann, verwenden Sie [LineFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/get_effective/), greifen Sie auf die `sketch_format`‑Eigenschaft des zurückgegebenen Objekts zu und lesen Sie dessen `sketch_type`‑Eigenschaft. Der effektive Wert spiegelt die tatsächlich angewendete Formatierung wider, nachdem die Vererbung aufgelöst wurde:

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

Hier sind die drei Optionen für den Verbindungsstil:

* Rund
* Gehrung
* Fase

Standardmäßig verwendet PowerPoint beim Verbinden zweier Linien unter einem Winkel (z. B. an einer Form‑Ecke) die **Rund**‑Einstellung. Wenn Sie jedoch eine Form mit scharfen Winkeln zeichnen, bevorzugen Sie möglicherweise die **Gehrung**‑Option.

![Der Verbindungsstil in der Präsentation](join-style-powerpoint.png)

Der folgende Python‑Code demonstriert, wie drei Rechtecke (wie im Bild oben gezeigt) mit den Verbindungsstil‑Einstellungen Gehrung, Fase und Rund erstellt wurden:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
with slides.Presentation() as presentation:

	# Holen Sie die erste Folie.
	slide = presentation.slides[0]

	# Fügen Sie drei AutoShapes des Typs Rechteck hinzu.
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

	# Speichern Sie die PPTX-Datei auf dem Datenträger.
	presentation.save("join_styles.pptx", slides.export.SaveFormat.PPTX)
```

## **Verlaufsfüllung**

In PowerPoint ist die Verlaufsfüllung eine Formatierungsoption, die es ermöglicht, einem Objekt einen kontinuierlichen Farbübergang zuzuweisen. Sie können beispielsweise zwei oder mehr Farben so anwenden, dass die eine allmählich in die andere übergeht.

So wenden Sie eine Verlaufsfüllung auf eine Form mit Aspose.Slides an:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
1. Holen Sie eine Referenz zu einer Folie anhand ihres Index.
1. Fügen Sie der Folie eine [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) hinzu.
1. Setzen Sie den [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) der Form auf `GRADIENT`.
1. Fügen Sie Ihre beiden bevorzugten Farben mit definierten Positionen über die `add`‑Methoden der `gradient_stops`‑Sammlung hinzu, die von der [GradientFormat](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/) Klasse bereitgestellt wird.
1. Speichern Sie die bearbeitete Präsentation als PPTX-Datei.

Der folgende Python‑Code demonstriert, wie man einer Ellipse einen Verlaufsfüll‑Effekt hinzufügt:

```python
import aspose.slides as slides

# Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
with slides.Presentation() as presentation:

    # Holen Sie die erste Folie.
    slide = presentation.slides[0]

    # Fügen Sie eine AutoShape des Typs Ellipse hinzu.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 150, 75)

    # Wenden Sie eine Verlaufsformatierung auf die Ellipse an.
    shape.fill_format.fill_type = slides.FillType.GRADIENT
    shape.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR

    # Legen Sie die Richtung des Verlaufs fest.
    shape.fill_format.gradient_format.gradient_direction = slides.GradientDirection.FROM_CORNER2

    # Fügen Sie zwei Verlaufsstopps hinzu.
    shape.fill_format.gradient_format.gradient_stops.add(1.0, slides.PresetColor.PURPLE)
    shape.fill_format.gradient_format.gradient_stops.add(0, slides.PresetColor.RED)

    # Speichern Sie die PPTX-Datei auf dem Datenträger.
    presentation.save("gradient_fill.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![Die Ellipse mit Verlaufsfüllung](gradient-fill.png)

Wenn ein Verlauf in einem exportierten Bild anders aussieht als in PowerPoint, siehe [Choose a Gradient Rendering Style](/slides/de/python-net/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Sie können einen Rendering‑Stil auswählen, ohne die im Dokument gespeicherte Verlaufsfüllung zu ändern.

## **Musterfüllung**

In PowerPoint ist die Musterfüllung eine Formatierungsoption, mit der Sie einem Objekt ein zweifarbiges Design – z. B. Punkte, Streifen, Kreuzschraffuren oder Schachbrett – zuweisen können. Sie können eigene Farben für den Vorder‑ und Hintergrund des Musters wählen.

Aspose.Slides bietet über 45 vordefinierte Musterstile, die Sie auf Formen anwenden können, um die visuelle Attraktivität Ihrer Präsentationen zu erhöhen. Auch nach Auswahl eines vordefinierten Musters können Sie die genauen Farben festlegen, die verwendet werden sollen.

So wenden Sie eine Musterfüllung auf eine Form mit Aspose.Slides an:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
1. Holen Sie eine Referenz zu einer Folie anhand ihres Index.
1. Fügen Sie der Folie eine [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) hinzu.
1. Setzen Sie den [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) der Form auf `PATTERN`.
1. Wählen Sie einen Musterstil aus den vordefinierten Optionen.
1. Setzen Sie die [back_color](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/back_color/) des Musters.
1. Setzen Sie die [fore_color](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/fore_color/) des Musters.
1. Speichern Sie die bearbeitete Präsentation als PPTX-Datei.

Der folgende Python‑Code zeigt, wie Sie ein Rechteck mit Musterfüllung versehen:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
with slides.Presentation() as presentation:

    # Holen Sie die erste Folie.
    slide = presentation.slides[0]

    # Fügen Sie eine AutoShape des Typs Rechteck hinzu.
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

![Das Rechteck mit Musterfüllung](pattern-fill.png)

## **Bildfüllung**

In PowerPoint ist die Bildfüllung eine Formatierungsoption, die es ermöglicht, ein Bild innerhalb einer Form zu platzieren – das Bild dient effektiv als Hintergrund der Form.

So verwenden Sie Aspose.Slides, um eine Bildfüllung auf eine Form anzuwenden:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
1. Holen Sie eine Referenz zu einer Folie anhand ihres Index.
1. Fügen Sie der Folie eine [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) hinzu.
1. Setzen Sie den [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) der Form auf `PICTURE`.
1. Setzen Sie den Bildfüll‑Modus auf `TILE` (oder einen anderen gewünschten Modus).
1. Erstellen Sie ein [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) Objekt aus dem Bild, das Sie verwenden möchten.
1. Weisen Sie dieses Bild der `picture.image`‑Eigenschaft des `picture_fill_format` der Form zu.
1. Speichern Sie die bearbeitete Präsentation als PPTX-Datei.

Hier ein "lotus.png"-Beispielbild:

![Das Lotusbild](lotus.png)

Der folgende Python‑Code demonstriert, wie Sie eine Form mit dem Bild füllen:

```python
import aspose.slides as slides

# Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
with slides.Presentation() as presentation:

    # Holen Sie die erste Folie.
    slide = presentation.slides[0]

    # Fügen Sie eine AutoShape des Typs Rechteck hinzu.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 192, 95)

    # Setzen Sie den Fülltyp auf Bild.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Setzen Sie den Bildfüllmodus.
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE

    # Laden Sie ein Bild und fügen Sie es den Präsentationsressourcen hinzu.
    with slides.Images.from_file("lotus.png") as image:
        presentation_image = presentation.images.add_image(image)

    # Setzen Sie das Bild.
    shape.fill_format.picture_fill_format.picture.image = presentation_image

    # Speichern Sie die PPTX-Datei auf dem Datenträger.
    presentation.save("picture_fill.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![Die Form mit Bildfüllung](picture-fill.png)

### **Bild kacheln als Textur**

Wenn Sie ein gekacheltes Bild als Textur festlegen und das Kachel‑Verhalten anpassen möchten, können Sie die folgenden Eigenschaften der [PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/) Klasse verwenden:

- [picture_fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture_fill_mode/): Legt den Bildfüllmodus fest – entweder `TILE` oder `STRETCH`.
- [tile_alignment](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_alignment/): Gibt die Ausrichtung der Kacheln innerhalb der Form an.
- [tile_flip](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_flip/): Steuert, ob die Kachel horizontal, vertikal oder beide Richtungen gespiegelt wird.
- [tile_offset_x](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_offset_x/): Setzt den horizontalen Versatz der Kachel (in Punkten) vom Ursprung der Form.
- [tile_offset_y](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_offset_y/): Setzt den vertikalen Versatz der Kachel (in Punkten) vom Ursprung der Form.
- [tile_scale_x](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_scale_x/): Definiert den horizontalen Maßstab der Kachel als Prozentsatz.
- [tile_scale_y](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_scale_y/): Definiert den vertikalen Maßstab der Kachel als Prozentsatz.

Der folgende Beispielcode zeigt, wie Sie ein Rechteck mit gekachelter Bildfüllung hinzufügen und die Kachel‑Optionen konfigurieren:

```py
import aspose.slides as slides

# Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
with slides.Presentation() as presentation:

    # Holen Sie die erste Folie.
    first_slide = presentation.slides[0]

    # Fügen Sie eine Rechteck-AutoShape hinzu.
    shape = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 190, 95)

    # Setzen Sie den Fülltyp der Form auf Bild.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Laden Sie das Bild und fügen Sie es den Präsentationsressourcen hinzu.
    with slides.Images.from_file("lotus.png") as source_image:
        presentation_image = presentation.images.add_image(source_image)

    # Weisen Sie das Bild der Form zu.
    picture_fill_format = shape.fill_format.picture_fill_format
    picture_fill_format.picture.image = presentation_image

    # Konfigurieren Sie den Bildfüllmodus und die Kachel-Eigenschaften.
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

![Die Kacheloptionen](tile-options.png)

## **Einfarbige Füllung**

In PowerPoint ist die einfarbige Füllung eine Formatierungsoption, die ein Objekt mit einer einzigen, gleichmäßigen Farbe füllt. Diese einheitliche Hintergrundfarbe wird ohne Verläufe, Texturen oder Muster angewendet.

So wenden Sie eine einfarbige Füllung auf eine Form mit Aspose.Slides an:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
1. Holen Sie eine Referenz zu einer Folie anhand ihres Index.
1. Fügen Sie der Folie eine [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) hinzu.
1. Setzen Sie den [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) der Form auf `SOLID`.
1. Ordnen Sie der Form Ihre bevorzugte Füllfarbe zu.
1. Speichern Sie die bearbeitete Präsentation als PPTX-Datei.

Der folgende Python‑Code demonstriert, wie Sie ein Rechteck in einer PowerPoint‑Folie mit einfarbiger Füllung versehen:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
with slides.Presentation() as presentation:

    # Holen Sie die erste Folie.
    slide = presentation.slides[0]

    # Fügen Sie eine AutoShape des Typs Rechteck hinzu.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Setzen Sie den Fülltyp auf Einfarbig.
    shape.fill_format.fill_type = slides.FillType.SOLID

    # Setzen Sie die Füllfarbe.
    shape.fill_format.solid_fill_color.color = draw.Color.yellow

    # Speichern Sie die PPTX-Datei auf dem Datenträger.
    presentation.save("solid_color_fill.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![Die Form mit einfarbiger Füllung](solid-color-fill.png)

## **Transparenz festlegen**

In PowerPoint können Sie bei einer einfarbigen, Verlaufs‑, Bild‑ oder Textur‑Füllung von Formen zusätzlich einen Transparenz‑Wert festlegen, der die Undurchsichtigkeit der Füllung steuert. Ein höherer Transparenz‑Wert macht die Form durchsichtiger, sodass der Hintergrund oder darunter liegende Objekte teilweise sichtbar werden.

Aspose.Slides ermöglicht das Festlegen des Transparenz‑Werts, indem Sie den Alpha‑Wert in der für die Füllung verwendeten Farbe anpassen. So geht’s:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
1. Holen Sie eine Referenz zu einer Folie anhand ihres Index.
1. Fügen Sie der Folie eine [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) hinzu.
1. Setzen Sie den Fülltyp auf `SOLID`.
1. Verwenden Sie `Color.from_argb`, um eine Farbe mit Transparenz zu definieren (die `alpha`‑Komponente steuert die Transparenz).
1. Speichern Sie die Präsentation.

Der folgende Python‑Code zeigt, wie Sie einer Rechteck‑Form eine transparente Füllfarbe zuweisen:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
with slides.Presentation() as presentation:

    # Holen Sie die erste Folie.
    slide = presentation.slides[0]
    
    # Fügen Sie eine einfarbige Rechteck-AutoShape hinzu.
    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Fügen Sie eine transparente Rechteck-AutoShape über der einfarbigen Form hinzu.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 80, 150, 75)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.from_argb(128, 204, 102, 0)
    
    presentation.save("shape_transparency.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![Die transparente Form](shape-transparency.png)

## **Formen drehen**

Aspose.Slides ermöglicht das Drehen von Formen in PowerPoint‑Präsentationen. Dies kann nützlich sein, wenn visuelle Elemente mit spezifischer Ausrichtung oder Design‑Anforderungen positioniert werden sollen.

So drehen Sie eine Form auf einer Folie:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
1. Holen Sie eine Referenz zu einer Folie anhand ihres Index.
1. Fügen Sie der Folie eine [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) hinzu.
1. Setzen Sie die `rotation`‑Eigenschaft der Form auf den gewünschten Winkel.
1. Speichern Sie die Präsentation.

Der folgende Python‑Code demonstriert das Drehen einer Form um 5 Grad:

```python
import aspose.slides as slides

# Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
with slides.Presentation() as presentation:

    # Holen Sie die erste Folie.
    slide = presentation.slides[0]

    # Fügen Sie eine AutoShape des Typs Rechteck hinzu.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Drehen Sie die Form um 5 Grad.
    shape.rotation = 5

    # Speichern Sie die PPTX-Datei auf dem Datenträger.
    presentation.save("shape_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![Die Formdrehung](shape-rotation.png)

## **3D‑Kehlungs‑Effekte hinzufügen**

Aspose.Slides ermöglicht das Hinzufügen von 3D‑Kehlungs‑Effekten zu Formen, indem die Eigenschaften des [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) konfiguriert werden.

So fügen Sie einer Form 3D‑Kehlungs‑Effekte hinzu:

1. Instanziieren Sie die [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
1. Holen Sie eine Referenz zu einer Folie anhand ihres Index.
1. Fügen Sie der Folie eine [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) hinzu.
1. Konfigurieren Sie das [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) der Form, um die Kehlungs‑Einstellungen festzulegen.
1. Speichern Sie die Präsentation.

Der folgende Python‑Code zeigt, wie Sie 3D‑Kehlungs‑Effekte auf eine Form anwenden:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Erstellen Sie eine Instanz der Presentation-Klasse.
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    # Fügen Sie der Folie eine Form hinzu.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.green
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.orange
    shape.line_format.width = 2.0

    # Setzen Sie die ThreeDFormat-Eigenschaften der Form.
    shape.three_d_format.depth = 4
    shape.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    shape.three_d_format.bevel_top.height = 6
    shape.three_d_format.bevel_top.width = 6
    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.THREE_PT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP

    # Speichern Sie die Präsentation als PPTX-Datei.
    presentation.save("3D_bevel_effect.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![Der 3D‑Kehlungs‑Effekt](3D-bevel-effect.png)

## **3D‑Rotations‑Effekte hinzufügen**

Aspose.Slides ermöglicht das Anwenden von 3D‑Rotations‑Effekten auf Formen, indem die Eigenschaften des [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) konfiguriert werden.

So wenden Sie 3D‑Rotation auf eine Form an:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
1. Holen Sie eine Referenz zu einer Folie anhand ihres Index.
1. Fügen Sie der Folie eine [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) hinzu.
1. Setzen Sie den [camera_type](https://reference.aspose.com/slides/python-net/aspose.slides/camera/camera_type/) und den [light_type](https://reference.aspose.com/slides/python-net/aspose.slides/lightrig/light_type/) der Form, um die 3D‑Rotation zu definieren.
1. Speichern Sie die Präsentation.

Der folgende Python‑Code demonstriert das Anwenden von 3D‑Rotations‑Effekten auf eine Form:

```python
import aspose.slides as slides

# Erstellen Sie eine Instanz der Presentation-Klasse.
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

![Der 3D‑Rotations‑Effekt](3D-rotation-effect.png)

## **Schwarz‑Weiß‑Darstellung für Formen steuern**

Die Eigenschaft [Shape.black_white_mode](https://reference.aspose.com/slides/python-net/aspose.slides/shape/black_white_mode/) legt fest, wie eine einzelne Form gerendert wird, wenn eine Präsentation im Schwarz‑Weiß‑Modus angezeigt oder verarbeitet wird. Sie aktiviert die Schwarz‑Weiß‑Anzeige nicht automatisch und ändert die Füll‑, Linien‑ oder andere Formatierung nicht im normalen Farbmodus.

Verwenden Sie einen Wert aus der Aufzählung [BlackWhiteMode](https://reference.aspose.com/slides/python-net/aspose.slides/blackwhitemode/), um das gewünschte Verhalten auszuwählen. Beispielsweise lässt `AUTOMATIC` die Rendering‑Anwendung die Konvertierung wählen, `GRAY` und `LIGHT_GRAY` verwenden Grautöne, `BLACK_WHITE` nutzt ausschließlich Schwarz und Weiß, `BLACK` und `WHITE` erzwingen eine einfarbige Darstellung, `COLOR` bewahrt die normale Farbgebung, und `HIDDEN` blendet die Form im Schwarz‑Weiß‑Modus aus. `NOT_DEFINED` bedeutet, dass kein Form‑Level‑Modus zugewiesen ist.

Der folgende Python‑Code erstellt eine farbige Form und lässt sie im Schwarz‑Weiß‑Anzeige‑Modus grau erscheinen:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.orange

    # Behalten Sie die orange Füllung im Farbmodus bei, aber rendern Sie die Form im Schwarz-Weiß-Modus grau.
    shape.black_white_mode = slides.BlackWhiteMode.GRAY

    presentation.save("shape_black_white_mode.pptx", slides.export.SaveFormat.PPTX)
```

Im normalen Farbmodus behält das Rechteck seine orange Füllung. Im Schwarz‑Weiß‑Workflow wird es grau angezeigt, weil sein Modus auf `GRAY` gesetzt ist. So können Sie eine Farbfolie beibehalten und gleichzeitig ein unterschiedliches Erscheinungsbild für den Druck, die Vorschau oder andere Workflows definieren, die die Schwarz‑Weiß‑Anzeige‑Einstellungen der Präsentation beachten.

## **Formatierung zurücksetzen**

Der folgende Python‑Code zeigt, wie Sie die Formatierung einer Folie zurücksetzen und die Position, Größe und Formatierung aller Formen mit Platzhaltern auf dem [LayoutSlide](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/) auf deren Standardwerte zurücksetzen:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:

    for slide in presentation.slides:
        # Setzen Sie jede Form auf der Folie zurück, die einen Platzhalter im Layout hat.
        slide.reset()

    presentation.save("reset_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Beeinflusst die Formatierung von Formen die endgültige Dateigröße der Präsentation?**

Nur minimal. Eingebettete Bilder und Medien machen den größten Teil des Dateiruums aus, während Form‑Parameter wie Farben, Effekte und Verläufe als Metadaten gespeichert werden und praktisch keinen zusätzlichen Platz beanspruchen.

**Wie kann ich Formen auf einer Folie erkennen, die dieselbe Formatierung besitzen, damit ich sie gruppieren kann?**

Vergleichen Sie die wichtigsten Formatierungs‑Eigenschaften jeder Form – Füll‑, Linien‑ und Effekt‑Einstellungen. Stimmen alle entsprechenden Werte überein, behandeln Sie die Stile als identisch und gruppieren Sie diese Formen logisch, was die spätere Stil‑Verwaltung erleichtert.

**Kann ich ein Set benutzerdefinierter Formstile in einer separaten Datei speichern, um sie in anderen Präsentationen wiederzuverwenden?**

Ja. Speichern Sie Beispiel‑Formen mit den gewünschten Stilen in einem Vorlagen‑Slide‑Deck oder einer *.POTX*‑Vorlagendatei. Beim Erstellen einer neuen Präsentation öffnen Sie die Vorlage, klonen die benötigten Formen und wenden deren Formatierung dort an, wo sie benötigt wird.