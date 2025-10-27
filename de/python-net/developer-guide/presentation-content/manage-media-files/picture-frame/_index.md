---
title: Bildrahmen zu Präsentationen mit Python hinzufügen
linktitle: Bildrahmen
type: docs
weight: 10
url: /de/python-net/picture-frame/
keywords:
- Bildrahmen
- Bildrahmen hinzufügen
- Bildrahmen erstellen
- Bild hinzufügen
- Bild erstellen
- Bild extrahieren
- Rasterbild
- Vektorbild
- Bild zuschneiden
- Zugeschnittener Bereich
- StretchOff-Eigenschaft
- Bildrahmen-Formatierung
- Bildrahmen-Eigenschaften
- relative Skalierung
- Bildeffekt
- Seitenverhältnis
- Bildtransparenz
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Fügen Sie Bildrahmen zu PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Python via .NET hinzu. Optimieren Sie Ihren Workflow und verbessern Sie das Slide-Design."
---

## **Übersicht**

Bildrahmen in Aspose.Slides für Python ermöglichen das Platzieren und Verwalten von Raster‑ und Vektorbildern als native Folienformen. Sie können Bilder aus Dateien oder Streams einfügen, sie mit genauen Koordinaten positionieren und die Größe ändern, Drehungen anwenden, Transparenz einstellen und die Z‑Reihenfolge zusammen mit anderen Formen kontrollieren. Die API unterstützt zudem das Zuschneiden, das Beibehalten von Seitenverhältnissen, das Festlegen von Rändern und Effekten sowie das Ersetzen des zugrunde liegenden Bildes, ohne das Layout neu zu erstellen. Da Bildrahmen sich wie reguläre Formen verhalten, können Sie Animationen, Hyperlinks und Alternativtexte hinzufügen, was den Aufbau visuell ansprechender, barrierefreier Präsentationen erleichtert.

## **Bildrahmen erstellen**

Dieser Abschnitt zeigt, wie ein Bild in eine Folie eingefügt wird, indem ein [Bildrahmen](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) mit Aspose.Slides für Python erstellt wird. Sie lernen, wie das Bild geladen, exakt auf der Folie platziert und Größe sowie Formatierung gesteuert werden.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse.  
2. Holen Sie eine Folie über deren Index.  
3. Erzeugen Sie ein [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/), indem Sie das Bild zur [ImageCollection](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/) der Präsentation hinzufügen. Dieses Bild wird zum Füllen der Form verwendet.  
4. Geben Sie die Breite und Höhe des Rahmens an.  
5. Erstellen Sie einen [Bildrahmen](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) dieser Größe mit der Methode [add_picture_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_picture_frame/).  
6. Speichern Sie die Präsentation als PPTX‑Datei.

Der folgende Python‑Code zeigt, wie ein Bildrahmen erstellt wird:

```py
import aspose.slides as slides

# Instantiate the Presentation class to represent a PPTX file.
with slides.Presentation() as presentation:
    # Get the first slide.
    slide = presentation.slides[0]

    # Add the image to the presentation.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # Add a picture frame sized to the image.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        # Save the presentation as PPTX.
        presentation.save("picture_frame.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" %}}

Bildrahmen ermöglichen das schnelle Erstellen von Präsentationsfolien aus Bildern. Kombinieren Sie Bildrahmen mit den Speichereinstellungen von Aspose.Slides, können Sie I/O‑Operationen steuern, um Bilder von einem Format in ein anderes zu konvertieren. Weitere Seiten: Bild nach JPG konvertieren ([image to JPG](https://products.aspose.com/slides/python-net/conversion/image-to-jpg/)); JPG nach Bild konvertieren ([JPG to image](https://products.aspose.com/slides/python-net/conversion/jpg-to-image/)); JPG nach PNG konvertieren ([JPG to PNG](https://products.aspose.com/slides/python-net/conversion/jpg-to-png/)); PNG nach JPG konvertieren ([PNG to JPG](https://products.aspose.com/slides/python-net/conversion/png-to-jpg/)); PNG nach SVG konvertieren ([PNG to SVG](https://products.aspose.com/slides/python-net/conversion/png-to-svg/)); SVG nach PNG konvertieren ([SVG to PNG](https://products.aspose.com/slides/python-net/conversion/svg-to-png/)).

{{% /alert %}}

## **Bildrahmen mit relativer Skalierung erstellen**

Dieser Abschnitt demonstriert das Platzieren eines Bildes in fester Größe und anschließend das Anwenden einer prozentualen Skalierung, die unabhängig für Breite und Höhe erfolgt. Da die Prozentsätze unterschiedlich sein können, kann sich das Seitenverhältnis ändern. Die Skalierung erfolgt relativ zu den ursprünglichen Bildabmessungen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse.  
2. Holen Sie eine Folie über deren Index.  
3. Erzeugen Sie ein [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/), indem Sie das Bild zur [ImageCollection](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/) der Präsentation hinzufügen.  
4. Fügen Sie der Folie einen [Bildrahmen](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) hinzu.  
5. Setzen Sie die relative Breite und Höhe des Bildrahmens.  
6. Speichern Sie die Präsentation als PPTX‑Datei.

Der folgende Python‑Code zeigt, wie ein Bildrahmen mit relativer Skalierung erstellt wird:

```py
import aspose.slides as slides

# Instantiate the Presentation class to represent a PPTX file.
with slides.Presentation() as presentation:
    # Get the first slide.
    slide = presentation.slides[0]

    # Add the image to the presentation's image collection.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # Add a picture frame to the slide.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)

        # Set the relative scale width and height.
        picture_frame.relative_scale_height = 0.8
        picture_frame.relative_scale_width = 1.35

        # Save the presentation.
        presentation.save("relative_scaling.pptx", slides.export.SaveFormat.PPTX)
```

## **Rasterbilder aus Bildrahmen extrahieren**

Sie können Rasterbilder aus [Bildrahmen](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/)-Objekten extrahieren und in PNG, JPG und anderen Formaten speichern. Das folgende Beispiel zeigt, wie ein Bild aus dem Dokument „sample.pptx“ extrahiert und im PNG‑Format gespeichert wird.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    first_slide = presentation.slides[0]
    first_shape = first_slide.shapes[0]

    if isinstance(first_shape, slides.PictureFrame):
        image = first_shape.picture_format.picture.image.image
        image.save("slide_1_shape_1.png", slides.ImageFormat.PNG)
```

## **SVG‑Bilder aus Bildrahmen extrahieren**

Wenn eine Präsentation SVG‑Grafiken enthält, die in [Bildrahmen](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/)-Formen platziert sind, ermöglicht Aspose.Slides für Python via .NET das Abrufen der ursprünglichen Vektorbilder mit voller Treue. Durch Durchlaufen der Formsammlung einer Folie können Sie jeden Bildrahmen identifizieren, prüfen, ob das zugehörige [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) SVG‑Inhalte enthält, und das Bild dann im nativen SVG‑Format speichern.

Der folgende Code demonstriert das Extrahieren eines SVG‑Bildes aus einem Bildrahmen:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.PictureFrame):
        svg_image = shape.picture_format.picture.image.svg_image

        if svg_image is not None:
            with open("output.svg", "w", encoding="utf-8") as svg_stream:
                svg_stream.write(svg_image.svg_content)
```

## **Bildtransparenz abrufen**

Aspose.Slides ermöglicht das Abrufen des Transparenzeffekts, der auf ein Bild angewendet wurde. Der folgende Python‑Code demonstriert den Vorgang:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    picture_frame = presentation.slides[0].shapes[0]
    image_transform = picture_frame.picture_format.picture.image_transform
    for effect in image_transform:
        if isinstance(effect, slides.effects.AlphaModulateFixed):
            transparency_value = 100 - effect.amount
            print("Picture transparency: " + str(transparency_value))
```

{{% alert color="primary" %}}
Alle auf Bilder angewendeten Effekte finden Sie in [aspose.slides.effects](https://reference.aspose.com/slides/python-net/aspose.slides.effects/).
{{% /alert %}}

## **Bildrahmen-Formatierung**

Aspose.Slides bietet zahlreiche Formatierungsoptionen, die Sie auf einen Bildrahmen anwenden können. Mit diesen Optionen können Sie einen Bildrahmen an spezifische Anforderungen anpassen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse.  
2. Holen Sie eine Folie über deren Index.  
3. Erzeugen Sie ein [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/), indem Sie das Bild zur [ImageCollection](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/) der Präsentation hinzufügen. Dieses Bild wird zum Füllen der Form verwendet.  
4. Geben Sie die Breite und Höhe des Rahmens an.  
5. Erstellen Sie einen [Bildrahmen](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) dieser Größe mittels der Methode [add_picture_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_picture_frame/) der Folie.  
6. Setzen Sie die Linienfarbe des Bildrahmens.  
7. Setzen Sie die Linienstärke des Bildrahmens.  
8. Rotieren Sie den Bildrahmen, indem Sie einen positiven (im Uhrzeigersinn) oder negativen (gegen den Uhrzeigersinn) Wert angeben.  
9. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Der folgende Python‑Code demonstriert den Formatierungsprozess:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Instantiate the Presentation class to represent a PPTX file.
with slides.Presentation() as presentation:
    # Get the first slide.
    slide = presentation.slides[0]

    # Add the image to the presentation's image collection.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # Add a picture frame sized to the image.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        # Apply formatting to the picture frame.
        picture_frame.line_format.fill_format.fill_type = slides.FillType.SOLID
        picture_frame.line_format.fill_format.solid_fill_color.color = draw.Color.blue
        picture_frame.line_format.width = 20
        picture_frame.rotation = 45

    # Save the presentation as PPTX.
    presentation.save("picture_formatting.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Tip" color="primary" %}}

Aspose hat einen kostenlosen [Collage Maker](https://products.aspose.app/slides/collage) entwickelt. Wenn Sie JPG/JPEG‑ oder PNG‑Bilder zusammenführen oder [Fotogitter erstellen](https://products.aspose.app/slides/collage/photo-grid) möchten, können Sie diesen Service nutzen.

{{% /alert %}}

## **Bilder als Links hinzufügen**

Um Präsentationsdateien klein zu halten, können Sie Bilder oder Videos über Links einbinden, anstatt die Dateien direkt in die Präsentation zu integrieren. Der folgende Python‑Code zeigt, wie ein Bild und ein Video in einen Platzhalter eingefügt werden:

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    shapes_to_remove = []

    for shape in slide.shapes:
        if shape.placeholder is None:
            continue

        if shape.placeholder.type == slides.PlaceholderType.PICTURE:
            picture_frame = slide.shapes.add_picture_frame(
                slides.ShapeType.RECTANGLE, shape.x, shape.y, shape.width, shape.height, None)

            picture_frame.picture_format.picture.link_path_long = \
                "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg"

            shapes_to_remove.append(shape)

        elif shape.placeholder.type == slides.PlaceholderType.MEDIA:
            video_frame = slide.shapes.add_video_frame(shape.X, shape.Y, shape.width, shape.height, "")

            video_frame.picture_format.picture.link_path_long = \
                "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg"

            video_frame.link_path_long = "https://youtu.be/t_1LYZ102RA"
            shapes_to_remove.append(shape)

    for shape in shapes_to_remove:
        slide.shapes.remove(shape)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Bilder zuschneiden**

In diesem Abschnitt lernen Sie, wie Sie den sichtbaren Bereich eines Bildes innerhalb eines Bildrahmens zuschneiden, ohne die Quelldatei zu verändern. Außerdem erfahren Sie, wie Sie grundlegende Zuschneide‑Abstände anwenden, um eine klare, fokussierte Komposition direkt auf der Folie zu erzeugen.

Der folgende Python‑Code zeigt, wie ein Bild auf einer Folie zugeschnitten wird:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Add the image to the presentation's image collection.
    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    # Add a picture frame to the slide.
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 100, 100, 420, 250, image)

    # Crop the image (percentage values).
    picture_frame.picture_format.crop_left = 23.6
    picture_frame.picture_format.crop_right = 21.5
    picture_frame.picture_format.crop_top = 3
    picture_frame.picture_format.crop_bottom = 31

    # Save the result.
    presentation.save("cropped_image.pptx", slides.export.SaveFormat.PPTX)
```

## **Zugeschnittene Bildbereiche löschen**

Wenn Sie zugeschnittene Bildbereiche in einem Rahmen entfernen möchten, verwenden Sie die Methode [delete_picture_cropped_areas](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/). Diese Methode gibt das zugeschnittene Bild zurück oder das Originalbild, wenn kein Zuschneiden nötig ist.

Der folgende Python‑Code demonstriert diesen Vorgang:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Get the PictureFrame from the first slide.
    picture_frame = slides.shape[0]

    # Get the PictureFrame from the first slide.
    cropped_image = picture_frame.picture_format.delete_picture_cropped_areas()

    # Save the result.
    presentation.save("deleted_cropped_areas.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}

Die Methode [delete_picture_cropped_areas](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) fügt das zugeschnittene Bild der Bildsammlung der Präsentation hinzu. Wird das Bild ausschließlich im verarbeiteten [Bildrahmen](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) verwendet, kann dies die Dateigröße reduzieren; andernfalls kann die Anzahl der Bilder in der resultierenden Präsentation steigen.

Während des Zuschneidens konvertiert diese Methode WMF/EMF‑Metadateien in ein Raster‑PNG‑Bild.

{{% /alert %}}

## **Seitenverhältnis sperren**

Wenn Sie möchten, dass ein Bild, das in einer Form enthalten ist, sein Seitenverhältnis beibehält, nachdem Sie die Bildabmessungen geändert haben, setzen Sie die Eigenschaft [aspect_ratio_locked](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/aspect_ratio_locked/) auf `True`.

Der folgende Python‑Code zeigt, wie das Seitenverhältnis einer Form gesperrt wird:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.CUSTOM)
    empty_slide = presentation.slides.add_empty_slide(layout)

    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = empty_slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

    # Lock the aspect ratio when resizing.
    picture_frame.picture_frame_lock.aspect_ratio_locked = True

    presentation.save("aspect_ratio_locked.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}

Diese Einstellung *Seitenverhältnis sperren* bewahrt nur das Seitenverhältnis der Form, nicht das des darin enthaltenen Bildes.

{{% /alert %}}

## **Stretch‑Offset‑Eigenschaften verwenden**

Durch die Eigenschaften `stretch_offset_left`, `stretch_offset_top`, `stretch_offset_right` und `stretch_offset_bottom` der Klasse [PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/) können Sie ein Füllrechteck definieren.

Wenn ein Bild gestreckt wird, wird das Quellrechteck auf das Füllrechteck skaliert. Jede Kante des Füllrechtecks wird durch einen prozentualen Offset von der entsprechenden Kante der Begrenzungsbox der Form definiert. Ein positiver Prozentsatz bedeutet Einrückung, ein negativer Prozentsatz Außenlage.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.  
2. Holen Sie eine Referenz zu einer Folie über deren Index.  
3. Fügen Sie eine rechteckige [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) hinzu.  
4. Setzen Sie den Fülltyp der Form.  
5. Setzen Sie den Bildfüllmodus der Form.  
6. Laden Sie ein Bild.  
7. Weisen Sie das Bild als Füllung der Form zu.  
8. Geben Sie Bild‑Offsets von den entsprechenden Kanten der Begrenzungsbox der Form an.  
9. Speichern Sie die Präsentation als PPTX‑Datei.

Der folgende Python‑Code demonstriert die Verwendung der Stretch‑Offset‑Eigenschaften:

```py
import aspose.slides as slides

# Instantiate the Presentation class that represents a PPTX file.
with slides.Presentation() as presentation:
    # Get the first slide.
    slide = presentation.slides[0]

    # Add a rectangle AutoShape.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 300, 300)

    # Set the shape's fill type.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Set the shape's picture fill mode.
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    # Load the image and add it to the presentation.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

    # Assign the image to fill the shape.
    shape.fill_format.picture_fill_format.picture.image = image

    # Specify image offsets from the corresponding edges of the shape's bounding box.
    shape.fill_format.picture_fill_format.stretch_offset_left = 25
    shape.fill_format.picture_fill_format.stretch_offset_right = 25
    shape.fill_format.picture_fill_format.stretch_offset_top = -20
    shape.fill_format.picture_fill_format.stretch_offset_bottom = -10

    # Save the PPTX file to disk.
    presentation.save("stretch_offset.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert  title="Tip" color="primary" %}}

Aspose bietet kostenlose Konverter – [JPEG nach PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) und [PNG nach PowerPoint](https://products.aspose.app/slides/import/png-to-ppt) – mit denen Sie schnell Präsentationen aus Bildern erstellen können.

{{% /alert %}}

## **FAQ**

**Wie finde ich heraus, welche Bildformate für Bildrahmen unterstützt werden?**

Aspose.Slides unterstützt sowohl Rasterbilder (PNG, JPEG, BMP, GIF usw.) als auch Vektorbilder (z. B. SVG) über das Bildobjekt, das einem [Bildrahmen](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) zugewiesen wird. Die Liste der unterstützten Formate überschneidet sich im Allgemeinen mit den Fähigkeiten der Folien‑ und Bildkonvertierungs‑Engine.

**Wie wirkt sich das Hinzufügen von Dutzenden großer Bilder auf die PPTX‑Größe und Performance aus?**

Das Einbetten großer Bilder erhöht Dateigröße und Speicherverbrauch; das Verlinken von Bildern hält die Präsentationsgröße klein, erfordert jedoch, dass die externen Dateien weiterhin erreichbar sind. Aspose.Slides bietet die Möglichkeit, Bilder per Link hinzuzufügen, um die Dateigröße zu reduzieren.

**Wie kann ich ein Bildobjekt vor versehentlichem Verschieben/Größenändern schützen?**

Verwenden Sie [Form‑Sperren](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/picture_frame_lock/) für einen [Bildrahmen](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) (z. B. Verschieben oder Größenänderung deaktivieren). Der Sperrmechanismus wird in einem separaten [Schutz‑Artikel](/slides/de/python-net/applying-protection-to-presentation/) beschrieben und wird für verschiedene Formtypen unterstützt, einschließlich [Bildrahmen](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/).

**Wird die Vektor‑Treue von SVG beim Export einer Präsentation zu PDF/Bildern erhalten?**

Aspose.Slides ermöglicht das Extrahieren eines SVG aus einem [Bildrahmen](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) als ursprünglichen Vektor. Beim [Export zu PDF](/slides/de/python-net/convert-powerpoint-to-pdf/) oder zu [Rasterformaten](/slides/de/python-net/convert-powerpoint-to-png/) kann das Ergebnis je nach Exporteinstellungen rasterisiert werden; die Tatsache, dass das ursprüngliche SVG als Vektor gespeichert wird, bestätigt sich durch das Extraktionsverhalten.