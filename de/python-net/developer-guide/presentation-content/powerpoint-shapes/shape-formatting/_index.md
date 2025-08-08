---
title: PowerPoint-Formen in Python formatieren
linktitle: Formformatierung
type: docs
weight: 20
url: /de/python-net/shape-formatting/
keywords:
- Form formatieren
- Linie formatieren
- Verbindungsart formatieren
- Verlaufsfüllung
- Musterfüllung
- Bildfüllung
- Strukturfüllung
- Einfarbige Füllung
- Formtransparenz
- Form drehen
- 3D-Abschrägungseffekt
- 3D-Drehungseffekt
- Formatierung zurücksetzen
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint-Formen in Python mit Aspose.Slides formatieren – legen Sie Füll-, Linien- und Effektstile für PPT-, PPTX- und ODP-Dateien mit Präzision und voller Kontrolle fest."
--- 

In PowerPoint kannst du Formen zu Folien hinzufügen. Da Formen aus Linien bestehen, kannst du Formen formatieren, indem du gewisse Effekte auf ihre Linien anwendest oder diese modifizierst. Zusätzlich kannst du Formen formatieren, indem du Einstellungen angibst, die festlegen, wie sie (der Bereich in ihnen) gefüllt werden.

![format-shape-powerpoint](format-shape-powerpoint.png)

**Aspose.Slides für Python über .NET** bietet Schnittstellen und Eigenschaften, die es dir ermöglichen, Formen basierend auf bekannten Optionen in PowerPoint zu formatieren.

## **Linien formatieren**

Mit Aspose.Slides kannst du deinen bevorzugten Linienstil für eine Form angeben. Diese Schritte umreißen ein solches Verfahren:

1. Erstelle eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
2. Hole einen Verweis auf die Folie über ihren Index.
3. Füge eine [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/) zur Folie hinzu.
4. Setze eine Farbe für die Linien der Form.
5. Setze die Breite für die Linien der Form.
6. Setze den [Linienstil](https://reference.aspose.com/slides/python-net/aspose.slides/linestyle/) für die Linien der Form.
7. Setze den [Strichstil](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/) für die Linien der Form.
8. Schreibe die modifizierte Präsentation als PPTX-Datei.

Dieser Python-Code demonstriert eine Operation, bei der wir ein Rechteck `AutoShape` formatiert haben:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Erstellt eine Instanz einer Präsentationsklasse, die eine PPTX-Datei darstellt
with slides.Presentation() as pres:
    # Holt die erste Folie
    sld = pres.slides[0]

    # Fügt eine rechteckige Autoform hinzu
    shp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 75)

    # Setzt die Füllfarbe für die rechteckige Form
    shp.fill_format.fill_type = slides.FillType.SOLID
    shp.fill_format.solid_fill_color.color = draw.Color.white

    # Wendet eine Formatierung auf die Linien des Rechtecks an
    shp.line_format.style = slides.LineStyle.THICK_THIN
    shp.line_format.width = 7
    shp.line_format.dash_style = slides.LineDashStyle.DASH

    # Setzt die Farbe für die Linie des Rechtecks
    shp.line_format.fill_format.fill_type = slides.FillType.SOLID
    shp.line_format.fill_format.solid_fill_color.color = draw.Color.blue

    # Schreibt die PPTX-Datei auf die Festplatte
    pres.save("RectShpLn_out-1.pptx", slides.export.SaveFormat.PPTX)
```

## **Join-Stile formatieren**

Dies sind die 3 Join-Typ-Optionen:

* Rund
* Schräg
* Fase

Standardmäßig verwendet PowerPoint beim Verbinden zweier Linien in einem Winkel (oder an einer Ecke einer Form) die **Rund**-Einstellung. Wenn du jedoch eine Form mit sehr scharfen Winkeln zeichnen möchtest, solltest du **Schräg** wählen.

![join-style-powerpoint](join-style-powerpoint.png)

Dieser Python-Code demonstriert eine Operation, bei der 3 Rechtecke (das obige Bild) mit den Join-Typ-Einstellungen Schräg, Fase und Rund erstellt wurden:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Erstellt eine Instanz einer Präsentationsklasse, die eine PPTX-Datei darstellt
with slides.Presentation() as pres:
    # Holt die erste Folie
    sld = pres.slides[0]

    # Fügt 3 rechteckige Autoformen hinzu
    shp1 = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 100, 150, 75)
    shp2 = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 100, 150, 75)
    shp3 = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 250, 150, 75)

    # Setzt die Füllfarbe für die rechteckige Form
    shp1.fill_format.fill_type = slides.FillType.SOLID
    shp1.fill_format.solid_fill_color.color = draw.Color.black
    shp2.fill_format.fill_type = slides.FillType.SOLID
    shp2.fill_format.solid_fill_color.color = draw.Color.black
    shp3.fill_format.fill_type = slides.FillType.SOLID
    shp3.fill_format.solid_fill_color.color = draw.Color.black

    # Setzt die Linienstärke
    shp1.line_format.width = 15
    shp2.line_format.width = 15
    shp3.line_format.width = 15

    # Setzt die Farbe für die Linie der rechteckigen Form
    shp1.line_format.fill_format.fill_type = slides.FillType.SOLID
    shp1.line_format.fill_format.solid_fill_color.color = draw.Color.blue
    shp2.line_format.fill_format.fill_type = slides.FillType.SOLID
    shp2.line_format.fill_format.solid_fill_color.color = draw.Color.blue
    shp3.line_format.fill_format.fill_type = slides.FillType.SOLID
    shp3.line_format.fill_format.solid_fill_color.color = draw.Color.blue

    # Setzt den Join-Stil
    shp1.line_format.join_style = slides.LineJoinStyle.MITER
    shp2.line_format.join_style = slides.LineJoinStyle.BEVEL
    shp3.line_format.join_style = slides.LineJoinStyle.ROUND

    # Fügt jedem Rechteck Text hinzu
    shp1.text_frame.text = "Dies ist der Miter-Join-Stil"
    shp2.text_frame.text = "Dies ist der Bevel-Join-Stil"
    shp3.text_frame.text = "Dies ist der Rund-Join-Stil"

    # Schreibt die PPTX-Datei auf die Festplatte
    pres.save("RectShpLnJoin_out-2.pptx", slides.export.SaveFormat.PPTX)
```


## **Verlaufshintergrund**
In PowerPoint ist der Verlaufshintergrund eine Formatierungsoption, die es dir ermöglicht, eine kontinuierliche Farbmischung auf eine Form anzuwenden. Zum Beispiel kannst du zwei oder mehr Farben in einer Konfiguration anwenden, bei der eine Farbe allmählich in eine andere Farbe übergeht.

So verwendest du Aspose.Slides, um eine Verlaufshintergrundfüllung auf eine Form anzuwenden:

1. Erstelle eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
2. Hole einen Verweis auf die Folie über ihren Index.
3. Füge eine [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/) zur Folie hinzu.
4. Setze den [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) der Form auf `Gradient`.
5. Füge deine 2 bevorzugten Farben mit definierten Positionen über die `Add`-Methoden hinzu, die von der `GradientStops`-Sammlung bereitgestellt werden, die mit der `GradientFormat`-Klasse verknüpft ist.
6. Schreibe die modifizierte Präsentation als PPTX-Datei.

Dieser Python-Code demonstriert eine Operation, bei der der Verlaufshintergrundeffekt auf eine Ellipse angewendet wurde:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Erstellt eine Instanz einer Präsentationsklasse, die eine Präsentationsdatei darstellt
with slides.Presentation() as pres:
    # Holt die erste Folie
    sld = pres.slides[0]

    # Fügt eine elliptische Autoform hinzu
    shp = sld.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 150, 75, 150)

    # Wendet das Verlaufformat auf die Ellipse an
    shp.fill_format.fill_type = slides.FillType.GRADIENT
    shp.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR

    # Setzt die Richtung des Verlaufs
    shp.fill_format.gradient_format.gradient_direction = slides.GradientDirection.FROM_CORNER2

    # Fügt 2 Verlaufshaltestellen hinzu
    shp.fill_format.gradient_format.gradient_stops.add(1.0, slides.PresetColor.PURPLE)
    shp.fill_format.gradient_format.gradient_stops.add(0, slides.PresetColor.RED)

    # Schreibt die PPTX-Datei auf die Festplatte
    pres.save("EllipseShpGrad_out-3.pptx", slides.export.SaveFormat.PPTX)
```


## **Musterfüllung**
In PowerPoint ist die Musterfüllung eine Formatierungsoption, die es dir ermöglicht, ein zweifarbiges Design, das aus Punkten, Streifen, Kreuzhatches oder Kästchen besteht, auf eine Form anzuwenden. Darüber hinaus darfst du deine bevorzugten Farben für den Vordergrund und den Hintergrund deines Musters auswählen.

Aspose.Slides bietet über 45 vordefinierte Stile, die verwendet werden können, um Formen zu formatieren und Präsentationen zu bereichern. Selbst nachdem du ein vordefiniertes Muster ausgewählt hast, kannst du weiterhin die Farben spezifizieren, die das Muster enthalten muss.

So verwendest du Aspose.Slides, um eine Musterfüllung auf eine Form anzuwenden:

1. Erstelle eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
2. Hole einen Verweis auf die Folie über ihren Index.
3. Füge eine [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/) zur Folie hinzu.
4. Setze den [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) der Form auf `Pattern`.
5. Setze deinen bevorzugten Musterstil für die Form.
6. Setze die Hintergrundfarbe für das [PatternFormat](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/).
7. Setze die Vordergrundfarbe für das [PatternFormat](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/).
8. Schreibe die modifizierte Präsentation als PPTX-Datei.

Dieser Python-Code demonstriert eine Operation, bei der eine Musterfüllung verwendet wurde, um ein Rechteck zu verschönern:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Erstellt eine Instanz einer Präsentationsklasse, die eine Präsentationsdatei darstellt
with slides.Presentation() as pres:
    # Holt die erste Folie
    sld = pres.slides[0]

    # Fügt eine rechteckige Autoform hinzu
    shp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 75, 150)

    # Setzt den Fülltyp auf Muster
    shp.fill_format.fill_type = slides.FillType.PATTERN

    # Setzt den Musterstil
    shp.fill_format.pattern_format.pattern_style = slides.PatternStyle.TRELLIS

    # Setzt die Hintergrund- und Vordergrundfarben für das Muster
    shp.fill_format.pattern_format.back_color.color = draw.Color.light_gray
    shp.fill_format.pattern_format.fore_color.color = draw.Color.yellow

    # Schreibt die PPTX-Datei auf die Festplatte
    pres.save("RectShpPatt_out-4.pptx", slides.export.SaveFormat.PPTX)
```


## **Bildfüllung**
In PowerPoint ist die Bildfüllung eine Formatierungsoption, die es dir erlaubt, ein Bild innerhalb einer Form zu platzieren. Im Wesentlichen kannst du ein Bild als Hintergrund einer Form verwenden.

So verwendest du Aspose.Slides, um eine Form mit einem Bild zu füllen:

1. Erstelle eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
2. Hole einen Verweis auf die Folie über ihren Index.
3. Füge eine [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/) zur Folie hinzu.
4. Setze den [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) der Form auf `Picture`.
5. Setze den Bildfüllmodus auf Fliesen.
6. Erstelle ein `IPPImage`-Objekt unter Verwendung des Bildes, das zur Füllung der Form verwendet wird.
7. Setze die `Picture.Image`-Eigenschaft des `PictureFillFormat`-Objekts auf das kürzlich erstellte `IPPImage`.
8. Schreibe die modifizierte Präsentation als PPTX-Datei.

Dieser Python-Code zeigt dir, wie du eine Form mit einem Bild füllst:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Erstellt eine Instanz einer Präsentationsklasse, die eine PPTX-Datei darstellt
with slides.Presentation() as pres:
    # Holt die erste Folie
    sld = pres.slides[0]

    # Fügt eine rechteckige Autoform hinzu
    shp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 75, 150)

    # Setzt den Fülltyp auf Bild
    shp.fill_format.fill_type = slides.FillType.PICTURE

    # Setzt den Bildfüllmodus
    shp.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE

    # Setzt das Bild
    img = draw.Bitmap(path + "Tulips.jpg")
    imgx = pres.images.add_image(img)
    shp.fill_format.picture_fill_format.picture.image = imgx

    # Schreibt die PPTX-Datei auf die Festplatte
    pres.save("RectShpPic_out-5.pptx", slides.export.SaveFormat.PPTX)
```


## **Einfarbige Füllung**
In PowerPoint ist die einfarbige Füllung eine Formatierungsoption, die es dir ermöglicht, eine Form mit einer einzelnen Farbe zu füllen. Die gewählte Farbe ist typischerweise eine einfarbige Farbe. Die Farbe wird auf den Hintergrund der Form angewendet, ohne spezielle Effekte oder Modifikationen.

So verwendest du Aspose.Slides, um eine einfarbige Füllung auf eine Form anzuwenden:

1. Erstelle eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
2. Hole einen Verweis auf die Folie über ihren Index.
3. Füge eine [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/) zur Folie hinzu.
4. Setze den [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) der Form auf `Solid`.
5. Setze deine bevorzugte Farbe für die Form.
6. Schreibe die modifizierte Präsentation als PPTX-Datei.

Dieser Python-Code zeigt dir, wie du die einfarbige Füllung auf eine Box in PowerPoint anwendest:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:

    # Holt die erste Folie
    slide = presentation.slides[0]

    # Fügt eine rechteckige Autoform hinzu
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 75, 150)

    # Setzt den Fülltyp auf Einfarbig
    shape.fill_format.fill_type = slides.FillType.SOLID

    # Setzt die Farbe für das Rechteck
    shape.fill_format.solid_fill_color.color = draw.Color.yellow

    # Schreibt die PPTX-Datei auf die Festplatte
    presentation.save("RectShpSolid_out-6.pptx", slides.export.SaveFormat.PPTX)
```

## **Transparenz einstellen**

In PowerPoint kannst du, wenn du Formen mit einfarbigen Farben, Verläufen, Bildern oder Texturen füllst, das Transparenzniveau angeben, das die Opazität einer Füllung bestimmt. Auf diese Weise zeigt, z. B. wenn du ein niedriges Transparenzniveau festlegst, das Objekt oder der Hintergrund hinter (der Form) hindurch.

Aspose.Slides ermöglicht es dir, das Transparenzniveau für eine Form auf diese Weise festzulegen:

1. Erstelle eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
2. Hole einen Verweis auf die Folie über ihren Index.
3. Füge eine [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/) zur Folie hinzu.
4. Verwende `Color.FromArgb` mit dem festgelegten Alphakanal.
5. Speichere das Objekt als PowerPoint-Datei.

Dieser Python-Code demonstriert den Prozess:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    
    # Fügt eine einfarbige Form hinzu
    solidShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 75, 175, 75, 150)

    # Fügt eine transparente Form über der einfarbigen hinzu
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 75, 150)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.from_argb(128, 204, 102, 0)
    
    presentation.save("ShapeTransparentOverSolid_out.pptx", slides.export.SaveFormat.PPTX)

```

## **Formen drehen**
Aspose.Slides ermöglicht es dir, eine auf eine Folie hinzugefügte Form auf folgende Weise zu drehen:

1. Erstelle eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
2. Hole einen Verweis auf die Folie über ihren Index.
3. Füge eine [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/) zur Folie hinzu.
4. Drehe die Form um die benötigten Grad.
5. Schreibe die modifizierte Präsentation als PPTX-Datei.

Dieser Python-Code zeigt dir, wie du eine Form um 90 Grad drehst:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    # Holt die erste Folie
    sld = pres.slides[0]

    # Fügt eine rechteckige Autoform hinzu
    shp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 75, 150)

    # Dreht die Form um 90 Grad
    shp.rotation = 90

    # Schreibt die PPTX-Datei auf die Festplatte
    pres.save("RectShpRot_out-7.pptx", slides.export.SaveFormat.PPTX)
```


## **3D-Faseneffekte hinzufügen**
Aspose.Slides für Python über .NET ermöglicht es dir, 3D-Faseneffekte zu einer Form hinzuzufügen, indem du die [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) Eigenschaften dieser so anpasst:

1. Erstelle eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
2. Hole einen Verweis auf die Folie über ihren Index.
3. Füge eine [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/) zur Folie hinzu.
4. Setze deine bevorzugten Parameter für die [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) Eigenschaften der Form.
5. Schreibe die Präsentation auf die Festplatte.

Dieser Python-Code zeigt dir, wie du 3D-Faseneffekte zu einer Form hinzufügen kannst:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Erstellt eine Instanz der Präsentationsklasse
with slides.Presentation() as pres:
    slide = pres.slides[0]

    # Fügt eine Form zur Folie hinzu
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 30, 30, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.green
    format = shape.line_format.fill_format
    format.fill_type = slides.FillType.SOLID
    format.solid_fill_color.color = draw.Color.orange
    shape.line_format.width = 2.0

    # Setzt die 3D-Format-Eigenschaften der Form
    shape.three_d_format.depth = 4
    shape.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    shape.three_d_format.bevel_top.height = 6
    shape.three_d_format.bevel_top.width = 6
    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.THREE_PT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP

    # Schreibt die Präsentation als PPTX-Datei
    pres.save("Bavel_out-8.pptx", slides.export.SaveFormat.PPTX)
```


## **3D-Rotationseffekt hinzufügen**
Aspose.Slides ermöglicht es dir, 3D-Rotationseffekte zu einer Form hinzuzufügen, indem du die [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) Eigenschaften dieser so anpasst:

1. Erstelle eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
2. Hole einen Verweis auf die Folie über ihren Index.
3. Füge eine [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/) zur Folie hinzu.
4. Gib deine bevorzugten Figuren für CameraType und LightType an.
5. Schreibe die Präsentation auf die Festplatte.

Dieser Python-Code zeigt dir, wie du 3D-Rotationseffekte auf eine Form anwenden kannst:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Erstellt eine Instanz der Präsentationsklasse
with slides.Presentation() as pres:
    autoShape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 200, 200)

    autoShape.three_d_format.depth = 6
    autoShape.three_d_format.camera.set_rotation(40, 35, 20)
    autoShape.three_d_format.camera.camera_type = slides.CameraPresetType.ISOMETRIC_LEFT_UP
    autoShape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED

    autoShape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.LINE, 30, 300, 200, 200)
    autoShape.three_d_format.depth = 6
    autoShape.three_d_format.camera.set_rotation(0, 35, 20)
    autoShape.three_d_format.camera.camera_type = slides.CameraPresetType.ISOMETRIC_LEFT_UP
    autoShape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED

            
    pres.save("Rotation_out-9.pptx", slides.export.SaveFormat.PPTX)
```

## **Formatierung zurücksetzen**

Dieser Python-Code zeigt dir, wie du die Formatierung in einer Folie zurücksetzt und die Position, Größe und Formatierung jeder Form, die einen Platzhalter auf einem [LayoutSlide](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/) hat, auf ihre Standards zurücksetzt:

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    for slide in pres.slides:
        # Jede Form auf der Folie, die einen Platzhalter im Layout hat, wird zurückgesetzt
        slide.reset()
```