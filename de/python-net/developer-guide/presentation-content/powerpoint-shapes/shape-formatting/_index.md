---
title: PowerPoint-Formen in Python formatieren
linktitle: Formformatierung
type: docs
weight: 20
url: /de/python-net/shape-formatting/
keywords:
- Form formatieren
- Linie formatieren
- Verbindungsstil formatieren
- Verlaufsfüllung
- Musterfüllung
- Bildfüllung
- Texturfüllung
- Einfarbige Füllung
- Formen-Transparenz
- Form drehen
- 3D-Kanteneffekt
- 3D-Drehungseffekt
- Formatierung zurücksetzen
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint-Formen in Python mit Aspose.Slides formatieren—setzen Sie Füll-, Linien- und Effektstile für PPT-, PPTX- und ODP-Dateien mit Präzision und voller Kontrolle."
---

## **Übersicht**

In PowerPoint können Sie Formen zu Folien hinzufügen. Da Formen aus Linien bestehen, können Sie deren Konturen formatieren, indem Sie die Linien ändern oder Effekte darauf anwenden. Zusätzlich können Sie Formen formatieren, indem Sie Einstellungen festlegen, die steuern, wie deren Innenflächen gefüllt werden.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides für Python bietet Klassen und Eigenschaften, mit denen Sie Formen mithilfe derselben Optionen formatieren können, die in PowerPoint verfügbar sind.

## **Linien formatieren**

Mit Aspose.Slides können Sie für eine Form einen benutzerdefinierten Linienstil angeben. Die folgenden Schritte beschreiben das Vorgehen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.
1. Holen Sie sich einen Verweis auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie eine [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) hinzu.
1. Setzen Sie den [line style](https://reference.aspose.com/slides/python-net/aspose.slides/linestyle/) der Form.
1. Setzen Sie die Linienstärke.
1. Setzen Sie den [dash style](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/) der Form.
1. Setzen Sie die Linienfarbe für die Form.
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Der folgende Python‑Code demonstriert, wie ein Rechteck‑`AutoShape` formatiert wird:
```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
with slides.Presentation() as presentation:

    # Holen Sie die erste Folie.
    slide = presentation.slides[0]

    # Fügen Sie eine AutoShape vom Typ Rechteck hinzu.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 75)

    # Setzen Sie die Füllfarbe für die Rechteckform.
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    # Wenden Sie die Formatierung auf die Linien des Rechtecks an.
    shape.line_format.style = slides.LineStyle.THICK_THIN
    shape.line_format.width = 7
    shape.line_format.dash_style = slides.LineDashStyle.DASH

    # Setzen Sie die Farbe für die Linie des Rechtecks.
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue

    # Speichern Sie die PPTX-Datei auf dem Datenträger.
    presentation.save("formatted_lines.pptx", slides.export.SaveFormat.PPTX)
```


Das Ergebnis:

![The formatted lines in the presentation](formatted-lines.png)

## **Verbindungsstile formatieren**

Hier sind die drei Optionen für den Verbindungstyp:

* Round
* Miter
* Bevel

Standardmäßig verwendet PowerPoint beim Verbinden zweier Linien in einem Winkel (z. B. an einer Formkante) die Einstellung **Round**. Wenn Sie jedoch eine Form mit scharfen Winkeln zeichnen, bevorzugen Sie möglicherweise die Option **Miter**.

![The join style in the presentation](join-style-powerpoint.png)

Der folgende Python‑Code zeigt, wie drei Rechtecke (wie im Bild oben) mit den Verbindungstyp‑Einstellungen Miter, Bevel und Round erstellt wurden:
```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanziieren Sie die Presentation‑Klasse, die eine Präsentationsdatei darstellt.
with slides.Presentation() as presentation:

	# Holen Sie die erste Folie.
	slide = presentation.slides[0]

	# Fügen Sie drei AutoShapes vom Typ Rechteck hinzu.
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

	# Speichern Sie die PPTX‑Datei auf dem Datenträger.
	presentation.save("join_styles.pptx", slides.export.SaveFormat.PPTX)
```


## **Verlaufsfüllung**

In PowerPoint ist die Verlaufsfüllung eine Formatierungsoption, mit der Sie einer Form einen kontinuierlichen Farbübergang zuweisen können. Sie können z. B. zwei oder mehr Farben so anwenden, dass die eine allmählich in die andere übergeht.

So wenden Sie eine Verlaufsfüllung auf eine Form mit Aspose.Slides an:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.
1. Holen Sie sich einen Verweis auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie eine [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) hinzu.
1. Setzen Sie die [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) der Form auf `GRADIENT`.
1. Fügen Sie mit den `add`‑Methoden der `gradient_stops`‑Auflistung der [GradientFormat](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/)‑Klasse Ihre beiden gewünschten Farben mit definierten Positionen hinzu.
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Der folgende Python‑Code demonstriert, wie ein Verlaufsfüllungseffekt auf eine Ellipse angewendet wird:
```python
import aspose.slides as slides

# Instanziieren Sie die Presentation‑Klasse, die eine Präsentationsdatei darstellt.
with slides.Presentation() as presentation:

    # Holen Sie die erste Folie.
    slide = presentation.slides[0]

    # Fügen Sie eine AutoShape vom Typ Ellipse hinzu.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 150, 75)

    # Wenden Sie eine Verlaufsformatierung auf die Ellipse an.
    shape.fill_format.fill_type = slides.FillType.GRADIENT
    shape.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR

    # Legen Sie die Richtung des Verlaufs fest.
    shape.fill_format.gradient_format.gradient_direction = slides.GradientDirection.FROM_CORNER2

    # Fügen Sie zwei Verlaufsstopps hinzu.
    shape.fill_format.gradient_format.gradient_stops.add(1.0, slides.PresetColor.PURPLE)
    shape.fill_format.gradient_format.gradient_stops.add(0, slides.PresetColor.RED)

    # Speichern Sie die PPTX‑Datei auf dem Datenträger.
    presentation.save("gradient_fill.pptx", slides.export.SaveFormat.PPTX)
```


Das Ergebnis:

![The ellipse with gradient fill](gradient-fill.png)

## **Musterfüllung**

In PowerPoint ist die Musterfüllung eine Formatierungsoption, mit der Sie einer Form ein zweifarbiges Design – z. B. Punkte, Streifen, Kreuzschraffuren oder Karos – zuweisen können. Sie können benutzerdefinierte Farben für den Vorder‑ und Hintergrund des Musters wählen.

Aspose.Slides stellt über 45 vordefinierte Mustervorlagen bereit, die Sie auf Formen anwenden können, um das visuelle Erscheinungsbild Ihrer Präsentationen zu verbessern. Auch nach Auswahl eines vordefinierten Musters können Sie die genauen Farben festlegen, die verwendet werden sollen.

So wenden Sie eine Musterfüllung auf eine Form mit Aspose.Slides an:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.
1. Holen Sie sich einen Verweis auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie eine [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) hinzu.
1. Setzen Sie die [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) der Form auf `PATTERN`.
1. Wählen Sie einen Mustertyp aus den vordefinierten Optionen.
1. Setzen Sie die [back_color](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/back_color/) des Musters.
1. Setzen Sie die [fore_color](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/fore_color/) des Musters.
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Der folgende Python‑Code demonstriert, wie eine Musterfüllung auf ein Rechteck angewendet wird:
```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanziieren Sie die Presentation‑Klasse, die eine Präsentationsdatei darstellt.
with slides.Presentation() as presentation:

    # Holen Sie die erste Folie.
    slide = presentation.slides[0]

    # Fügen Sie eine AutoShape vom Typ Rechteck hinzu.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Setzen Sie den Fülltyp auf Muster.
    shape.fill_format.fill_type = slides.FillType.PATTERN

    # Setzen Sie den Mustertyp.
    shape.fill_format.pattern_format.pattern_style = slides.PatternStyle.TRELLIS

    # Setzen Sie die Hintergrund‑ und Vordergrundfarben des Musters.
    shape.fill_format.pattern_format.back_color.color = draw.Color.light_gray
    shape.fill_format.pattern_format.fore_color.color = draw.Color.yellow

    # Speichern Sie die PPTX‑Datei auf dem Datenträger.
    presentation.save("pattern_fill.pptx", slides.export.SaveFormat.PPTX)
```


Das Ergebnis:

![The rectangle with pattern fill](pattern-fill.png)

## **Bildfüllung**

In PowerPoint ist die Bildfüllung eine Formatierungsoption, mit der Sie ein Bild in eine Form einfügen können – das Bild wird dabei zum Hintergrund der Form.

So verwenden Sie Aspose.Slides, um eine Bildfüllung auf eine Form anzuwenden:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.
1. Holen Sie sich einen Verweis auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie eine [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) hinzu.
1. Setzen Sie die [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) der Form auf `PICTURE`.
1. Setzen Sie den Bildfüllungsmodus auf `TILE` (oder einen anderen gewünschten Modus).
1. Erzeugen Sie ein [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/)‑Objekt aus dem Bild, das Sie verwenden möchten.
1. Weisen Sie dieses Bild der `picture.image`‑Eigenschaft des `picture_fill_format` der Form zu.
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Angenommen, wir haben die Datei **lotus.png** mit folgendem Bild:

![The lotus picture](lotus.png)

Der folgende Python‑Code demonstriert, wie Sie eine Form mit dem Bild füllen:
```python
import aspose.slides as slides

# Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
with slides.Presentation() as presentation:

    # Holen Sie die erste Folie.
    slide = presentation.slides[0]

    # Fügen Sie eine AutoShape vom Typ Rechteck hinzu.
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

### **Bild als Textur kacheln**

Wenn Sie ein gekacheltes Bild als Textur festlegen und das Kachelverhalten anpassen möchten, können Sie die folgenden Eigenschaften der [PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/)‑Klasse verwenden:

- [picture_fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture_fill_mode/): Legt den Bildfüllungsmodus fest – entweder `TILE` oder `STRETCH`.
- [tile_alignment](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_alignment/): Gibt die Ausrichtung der Kacheln innerhalb der Form an.
- [tile_flip](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_flip/): Steuert, ob die Kachel horizontal, vertikal oder beides gespiegelt wird.
- [tile_offset_x](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_offset_x/): Legt den horizontalen Versatz der Kachel (in Punkten) vom Ursprung der Form fest.
- [tile_offset_y](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_offset_y/): Legt den vertikalen Versatz der Kachel (in Punkten) vom Ursprung der Form fest.
- [tile_scale_x](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_scale_x/): Definiert die horizontale Skalierung der Kachel als Prozentsatz.
- [tile_scale_y](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_scale_y/): Definiert die vertikale Skalierung der Kachel als Prozentsatz.

Der folgende Code‑Beispiel zeigt, wie Sie ein Rechteck mit einer gekachelten Bildfüllung hinzufügen und die Kacheloptionen konfigurieren:
```py
import aspose.slides as slides

    # Instanziieren Sie die Presentation‑Klasse, die eine Präsentationsdatei darstellt.
    with slides.Presentation() as presentation:

        # Holen Sie die erste Folie.
        first_slide = presentation.slides[0]

        # Fügen Sie eine Rechteck‑AutoShape hinzu.
        shape = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 190, 95)

        # Setzen Sie den Fülltyp der Form auf Bild.
        shape.fill_format.fill_type = slides.FillType.PICTURE

        # Laden Sie das Bild und fügen Sie es zu den Präsentationsressourcen hinzu.
        with slides.Images.from_file("lotus.png") as source_image:
            presentation_image = presentation.images.add_image(source_image)

        # Weisen Sie das Bild der Form zu.
        picture_fill_format = shape.fill_format.picture_fill_format
        picture_fill_format.picture.image = presentation_image

        # Konfigurieren Sie den Bildfüllungsmodus und die Kacheleigenschaften.
        picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE
        picture_fill_format.tile_offset_x = -32
        picture_fill_format.tile_offset_y = -32
        picture_fill_format.tile_scale_x = 50
        picture_fill_format.tile_scale_y = 50
        picture_fill_format.tile_alignment = slides.RectangleAlignment.BOTTOM_RIGHT
        picture_fill_format.tile_flip = slides.TileFlip.FLIP_BOTH

        # Speichern Sie die PPTX‑Datei auf dem Datenträger.
        presentation.save("tile.pptx", slides.export.SaveFormat.PPTX)
```


Das Ergebnis:

![The tile options](tile-options.png)

## **Einfarbige Füllung**

In PowerPoint ist die einfarbige Füllung eine Formatierungsoption, die eine Form mit einer einzigen, einheitlichen Farbe füllt. Diese schlichte Hintergrundfarbe wird ohne Verläufe, Texturen oder Muster angewendet.

So wenden Sie mit Aspose.Slides eine einfarbige Füllung auf eine Form an:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.
1. Holen Sie sich einen Verweis auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie eine [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) hinzu.
1. Setzen Sie die [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) der Form auf `SOLID`.
1. Weisen Sie der Form Ihre gewünschte Füllfarbe zu.
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Der folgende Python‑Code demonstriert, wie Sie eine einfarbige Füllung auf ein Rechteck in einer PowerPoint‑Folien anwenden:
```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
with slides.Presentation() as presentation:

    # Holen Sie die erste Folie.
    slide = presentation.slides[0]

    # Fügen Sie eine AutoShape vom Typ Rechteck hinzu.
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

In PowerPoint können Sie bei einer einfarbigen, verlaufenden, Bild‑ oder Texturfüllung für Formen auch einen Transparenzwert festlegen, um die Undurchsichtigkeit der Füllung zu steuern. Ein höherer Transparenzwert macht die Form durchsichtiger, sodass Hintergrund oder darunter liegende Objekte teilweise sichtbar werden.

Aspose.Slides ermöglicht das Festlegen der Transparenz, indem Sie den Alphawert in der für die Füllung verwendeten Farbe anpassen. So gehen Sie vor:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.
1. Holen Sie sich einen Verweis auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie eine [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) hinzu.
1. Setzen Sie den Füllungstyp auf `SOLID`.
1. Verwenden Sie `Color.from_argb`, um eine Farbe mit Transparenz zu definieren (die `alpha`‑Komponente steuert die Transparenz).
1. Speichern Sie die Präsentation.

Der folgende Python‑Code demonstriert, wie Sie einer Rechtecksform eine transparente Füllfarbe zuweisen:
```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Instanziieren Sie die Presentation‑Klasse, die eine Präsentationsdatei darstellt.
with slides.Presentation() as presentation:

    # Holen Sie die erste Folie.
    slide = presentation.slides[0]
    
    # Fügen Sie ein festes Rechteck‑AutoShape hinzu.
    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Fügen Sie über dem festen Rechteck ein transparentes Rechteck‑AutoShape hinzu.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 80, 150, 75)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.from_argb(128, 204, 102, 0)
    
    presentation.save("shape_transparency.pptx", slides.export.SaveFormat.PPTX)
```


Das Ergebnis:

![The transparent shape](shape-transparency.png)

## **Formen drehen**

Aspose.Slides ermöglicht das Drehen von Formen in PowerPoint‑Präsentationen. Das kann nützlich sein, wenn visuelle Elemente mit bestimmten Ausrichtungen oder Designanforderungen positioniert werden sollen.

So drehen Sie eine Form auf einer Folie:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.
1. Holen Sie sich einen Verweis auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie eine [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) hinzu.
1. Setzen Sie die `rotation`‑Eigenschaft der Form auf den gewünschten Winkel.
1. Speichern Sie die Präsentation.

Der folgende Python‑Code demonstriert, wie Sie eine Form um 5 Grad drehen:
```python
import aspose.slides as slides

# Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
with slides.Presentation() as presentation:

    # Holen Sie die erste Folie.
    slide = presentation.slides[0]

    # Fügen Sie eine AutoShape vom Typ Rechteck hinzu.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Drehen Sie die Form um 5 Grad.
    shape.rotation = 5

    # Speichern Sie die PPTX-Datei auf dem Datenträger.
    presentation.save("shape_rotation.pptx", slides.export.SaveFormat.PPTX)
```


Das Ergebnis:

![The shape rotation](shape-rotation.png)

## **3D‑Kanteneffekte hinzufügen**

Aspose.Slides ermöglicht das Anwenden von 3D‑Kanteneffekten auf Formen, indem Sie die Eigenschaften des [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) konfigurieren.

So fügen Sie einer Form 3D‑Kanteneffekte hinzu:

1. Instanziieren Sie die [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.
1. Holen Sie sich einen Verweis auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie eine [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) hinzu.
1. Konfigurieren Sie das [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) der Form, um die Kanteneinstellungen zu definieren.
1. Speichern Sie die Präsentation.

Der folgende Python‑Code zeigt, wie Sie 3D‑Kanteneffekte auf eine Form anwenden:
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

![The 3D bevel effect](3D-bevel-effect.png)

## **3D‑Drehungseffekte hinzufügen**

Aspose.Slides ermöglicht das Anwenden von 3D‑Drehungseffekten auf Formen, indem Sie die Eigenschaften des [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) konfigurieren.

So wenden Sie eine 3D‑Drehung auf eine Form an:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.
1. Holen Sie sich einen Verweis auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie eine [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) hinzu.
1. Setzen Sie den [camera_type](https://reference.aspose.com/slides/python-net/aspose.slides/camera/camera_type/) und den [light_type](https://reference.aspose.com/slides/python-net/aspose.slides/lightrig/light_type/) der Form, um die 3D‑Drehung zu definieren.
1. Speichern Sie die Präsentation.

Der folgende Python‑Code demonstriert, wie Sie 3D‑Drehungseffekte auf eine Form anwenden:
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

![The 3D rotation effect](3D-rotation-effect.png)

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

**Wirkt die Formformatierung auf die endgültige Dateigröße der Präsentation?**

Nur minimal. Eingebettete Bilder und Medien belegen den Großteil des Speicherplatzes, während Formparameter wie Farben, Effekte und Verläufe als Metadaten gespeichert werden und praktisch keinen zusätzlichen Platz beanspruchen.

**Wie kann ich Formen auf einer Folie erkennen, die identische Formatierungen aufweisen, um sie zu gruppieren?**

Vergleichen Sie die wichtigsten Formatierungseigenschaften jeder Form – Füllung, Linie und Effekte. Stimmen alle entsprechenden Werte überein, behandeln Sie deren Stile als identisch und gruppieren Sie die Formen logisch, was die spätere Stilverwaltung vereinfacht.

**Kann ich ein Set benutzerdefinierter Formstile in einer separaten Datei speichern, um es in anderen Präsentationen wiederzuverwenden?**

Ja. Speichern Sie Beispiel­formen mit den gewünschten Stilen in einem Vorlagen‑Slide‑Deck oder einer .POTX‑Vorlagendatei. Beim Erstellen einer neuen Präsentation öffnen Sie die Vorlage, klonen die benötigten stilisierten Formen und wenden deren Formatierungen bei Bedarf erneut an.