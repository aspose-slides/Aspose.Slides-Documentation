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
description: "Fügen Sie PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Python via .NET Bildrahmen hinzu. Optimieren Sie Ihren Arbeitsablauf und verbessern Sie das Design der Folien."
---

## **Übersicht**

Bildrahmen in Aspose.Slides für Python ermöglichen das Platzieren und Verwalten von Raster- und Vektorbildern als native Folienformen. Sie können Bilder aus Dateien oder Streams einfügen, sie mit genauen Koordinaten positionieren und skalieren, Drehungen anwenden, Transparenz einstellen und die Z‑Reihenfolge zusammen mit anderen Formen steuern. Die API unterstützt außerdem das Zuschneiden, das Beibehalten von Seitenverhältnissen, das Festlegen von Rahmen und Effekten sowie das Ersetzen des zugrunde liegenden Bildes, ohne das Layout neu zu erstellen. Da Bildrahmen sich wie reguläre Formen verhalten, können Sie Animationen, Hyperlinks und Alternativtext hinzufügen, was das Erstellen visuell ansprechender, barrierefreier Präsentationen vereinfacht.

## **Bildrahmen erstellen**

Dieser Abschnitt zeigt, wie Sie ein Bild in eine Folie einfügen, indem Sie ein [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) mit Aspose.Slides für Python erstellen. Sie lernen, wie Sie das Bild laden, präzise auf der Folie platzieren und Größe sowie Formatierung steuern.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.  
2. Holen Sie eine Folie anhand ihres Index.  
3. Erstellen Sie ein [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/), indem Sie das Bild zur [ImageCollection](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/) der Präsentation hinzufügen. Dieses Bild wird zum Füllen der Form verwendet.  
4. Geben Sie die Breite und Höhe des Rahmens an.  
5. Erstellen Sie einen [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) dieser Größe mittels der Methode [add_picture_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_picture_frame/).  
6. Speichern Sie die Präsentation als PPTX‑Datei.

Der folgende Python‑Code zeigt, wie Sie einen Bildrahmen erstellen:

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
Bildrahmen ermöglichen es Ihnen, schnell Präsentationsfolien aus Bildern zu erstellen. Wenn Sie Bildrahmen mit den Speicheroptionen von Aspose.Slides kombinieren, können Sie I/O‑Operationen steuern, um Bilder von einem Format in ein anderes zu konvertieren. Möglicherweise möchten Sie diese Seiten ansehen: konvertieren [Bild zu JPG]https://products.aspose.com/slides/python-net/conversion/image-to-jpg/; konvertieren [JPG zu Bild]https://products.aspose.com/slides/python-net/conversion/jpg-to-image/; konvertieren [JPG zu PNG]https://products.aspose.com/slides/python-net/conversion/jpg-to-png/; konvertieren [PNG zu JPG]https://products.aspose.com/slides/python-net/conversion/png-to-jpg/; konvertieren [PNG zu SVG]https://products.aspose.com/slides/python-net/conversion/png-to-svg/; konvertieren [SVG zu PNG]https://products.aspose.com/slides/python-net/conversion/svg-to-png/.
{{% /alert %}}

## **Bildrahmen mit relativer Skalierung erstellen**

Dieser Abschnitt demonstriert das Platzieren eines Bildes mit fester Größe und anschließendem prozentualen Skalieren der Breite und Höhe unabhängig voneinander. Da die Prozentsätze unterschiedlich sein können, kann sich das Seitenverhältnis ändern. Die Skalierung erfolgt relativ zu den Originalabmessungen des Bildes.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.  
2. Holen Sie eine Folie anhand ihres Index.  
3. Erstellen Sie ein [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/), indem Sie das Bild zur [ImageCollection](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/) der Präsentation hinzufügen.  
4. Fügen Sie einen [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) zur Folie hinzu.  
5. Setzen Sie die relative Breite und Höhe des Bildrahmens.  
6. Speichern Sie die Präsentation als PPTX‑Datei.

Der folgende Python‑Code zeigt, wie Sie einen Bildrahmen mit relativer Skalierung erstellen:

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

Sie können Rasterbilder aus [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/)-Objekten extrahieren und sie in PNG, JPG und anderen Formaten speichern. Der folgende Beispielcode zeigt, wie Sie ein Bild aus dem Dokument „sample.pptx“ extrahieren und im PNG‑Format speichern.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    first_slide = presentation.slides[0]
    first_shape = first_slide.shapes[0]

    if isinstance(first_shape, slides.PictureFrame):
        image = first_shape.picture_format.picture.image.image
        image.save("slide_1_shape_1.png", slides.ImageFormat.PNG)
```

## **SVG-Bilder aus Bildrahmen extrahieren**

Wenn eine Präsentation SVG-Grafiken enthält, die in [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/)-Formen platziert sind, ermöglicht Aspose.Slides für Python via .NET das Abrufen der originalen Vektorbilder mit voller Treue. Durch Durchlaufen der Formsammlung der Folie können Sie jedes [PictureFrame] identifizieren, prüfen, ob das zugrunde liegende [PPImage] SVG‑Inhalt enthält, und das Bild dann im nativen SVG‑Format speichern.

Das folgende Codebeispiel demonstriert, wie Sie ein SVG‑Bild aus einem Bildrahmen extrahieren:

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

Aspose.Slides ermöglicht das Abrufen des auf ein Bild angewendeten Transparenzeffekts. Dieser Python‑Code demonstriert die Vorgehensweise:

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
Alle Effekte, die auf Bilder angewendet werden, finden Sie in [aspose.slides.effects](https://reference.aspose.com/slides/python-net/aspose.slides.effects/).
{{% /alert %}}

## **Bildrahmen-Formatierung**

Aspose.Slides bietet viele Formatierungsoptionen, die Sie auf einen Bildrahmen anwenden können. Mit diesen Optionen können Sie einen Bildrahmen an spezifische Anforderungen anpassen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.  
2. Holen Sie eine Folie anhand ihres Index.  
3. Erstellen Sie ein [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/), indem Sie das Bild zur [ImageCollection] der Präsentation hinzufügen. Dieses Bild wird zum Füllen der Form verwendet.  
4. Geben Sie die Breite und Höhe des Rahmens an.  
5. Erstellen Sie einen [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) dieser Größe mittels der Methode [add_picture_frame] der Folie.  
6. Setzen Sie die Linienfarbe des Bildrahmens.  
7. Setzen Sie die Linienbreite des Bildrahmens.  
8. Drehen Sie den Bildrahmen, indem Sie einen positiven (im Uhrzeigersinn) oder negativen (gegen den Uhrzeigersinn) Wert angeben.  
9. Speichern Sie die modifizierte Präsentation als PPTX‑Datei.

Der folgende Python‑Code demonstriert den Bildrahmen-Formatierungsprozess:

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

{{% alert title="Hinweis" color="primary" %}}

Aspose hat einen kostenlosen [Collage Maker](https://products.aspose.app/slides/collage) entwickelt. Wenn Sie JPG/JPEG‑ oder PNG‑Bilder zusammenführen oder Fotogitter erstellen möchten, können Sie diesen Service nutzen.

{{% /alert %}}

## **Bilder als Links hinzufügen**

Um Präsentationsdateien klein zu halten, können Sie Bilder oder Videos über Links hinzufügen, anstatt die Dateien direkt in die Präsentationen einzubetten. Der folgende Python‑Code zeigt, wie Sie ein Bild und ein Video in einen Platzhalter einfügen:

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

In diesem Abschnitt lernen Sie, wie Sie den sichtbaren Bereich eines Bildes innerhalb eines Bildrahmens zuschneiden, ohne die Quelldatei zu ändern. Außerdem erfahren Sie, wie Sie Zuschneidemargen anwenden, um eine klare, fokussierte Komposition direkt auf der Folie zu erstellen.

Der folgende Python‑Code zeigt, wie Sie ein Bild auf einer Folie zuschneiden:

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

Wenn Sie die zugeschnittenen Bereiche eines Bildes in einem Rahmen löschen möchten, verwenden Sie die Methode [delete_picture_cropped_areas](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/). Diese Methode liefert das zugeschnittene Bild zurück oder das Originalbild, falls kein Zuschneiden nötig ist.

Der folgende Python‑Code demonstriert die Vorgehensweise:

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

{{% alert title="HINWEIS" color="warning" %}}
Die Methode `delete_picture_cropped_areas` fügt das zugeschnittene Bild zur Bildsammlung der Präsentation hinzu. Wenn das Bild nur im verarbeiteten PictureFrame verwendet wird, kann dies die Präsentationsgröße reduzieren; andernfalls kann die Anzahl der Bilder in der resultierenden Präsentation zunehmen.

Während des Zuschneidens konvertiert diese Methode WMF/EMF‑Metadateien in ein Raster‑PNG‑Bild.
{{% /alert %}}

## **Seitenverhältnis sperren**

Wenn Sie möchten, dass eine Form, die ein Bild enthält, ihr Seitenverhältnis beibehält, nachdem Sie die Bildabmessungen geändert haben, setzen Sie die Eigenschaft `aspect_ratio_locked` auf `True`.

Der folgende Python‑Code zeigt, wie Sie das Seitenverhältnis einer Form sperren:

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

{{% alert title="HINWEIS" color="warning" %}}
Diese *Lock Aspect Ratio*-Einstellung bewahrt nur das Seitenverhältnis der Form, nicht das Seitenverhältnis des darin enthaltenen Bildes.
{{% /alert %}}

## **Stretch‑Offset‑Eigenschaften verwenden**

Mit den Eigenschaften `stretch_offset_left`, `stretch_offset_top`, `stretch_offset_right` und `stretch_offset_bottom` der Klasse [PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/) können Sie ein Füllrechteck definieren.

Wenn für ein Bild ein Strecken angegeben ist, wird das Quellrechteck auf das Füllrechteck skaliert. Jede Kante des Füllrechtecks wird durch einen prozentualen Versatz von der entsprechenden Kante des Begrenzungsrahmens der Form definiert. Ein positiver Prozentsatz gibt eine Einbuchtung an, ein negativer Prozentsatz eine Ausbuchtung.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.  
2. Holen Sie eine Referenz zu einer Folie anhand ihres Index.  
3. Fügen Sie eine rechteckige AutoShape hinzu.  
4. Setzen Sie den Fülltyp der Form.  
5. Setzen Sie den Bildfüllmodus der Form.  
6. Laden Sie ein Bild.  
7. Weisen Sie das Bild zu, um die Form zu füllen.  
8. Geben Sie Bildversätze von den entsprechenden Kanten des Begrenzungsrahmens der Form an.  
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

{{% alert title="Hinweis" color="primary" %}}
Aspose stellt kostenlose Konverter bereit – JPEG zu PowerPoint und PNG zu PowerPoint – die es Ihnen ermöglichen, schnell Präsentationen aus Bildern zu erstellen.
{{% /alert %}}

## **FAQ**

**Wie kann ich herausfinden, welche Bildformate für PictureFrame unterstützt werden?**

Aspose.Slides unterstützt sowohl Rasterbilder (PNG, JPEG, BMP, GIF usw.) als auch Vektorbilder (z. B. SVG) über das Bildobjekt, das einem PictureFrame zugewiesen wird. Die Liste der unterstützten Formate überschneidet sich im Allgemeinen mit den Fähigkeiten der Folien‑ und Bildkonvertierungs‑Engine.

**Wie wirkt sich das Hinzufügen von Dutzenden großer Bilder auf die PPTX‑Größe und -Leistung aus?**

Das Einbetten großer Bilder erhöht die Dateigröße und den Speicherverbrauch; das Verlinken von Bildern hilft, die Präsentationsgröße klein zu halten, erfordert jedoch, dass die externen Dateien zugänglich bleiben. Aspose.Slides bietet die Möglichkeit, Bilder per Link hinzuzufügen, um die Dateigröße zu reduzieren.

**Wie kann ich ein Bildobjekt vor versehentlichem Verschieben/Größenändern schützen?**

Verwenden Sie Form‑Sperren für einen PictureFrame (z. B. das Verschieben oder die Größenänderung deaktivieren). Der Sperrmechanismus wird für Formen in einem separaten [Schutz‑Artikel](/slides/de/python-net/applying-protection-to-presentation/) beschrieben und wird für verschiedene Formtypen unterstützt, einschließlich PictureFrame.

**Bleibt die Vektor‑Treue von SVG beim Exportieren einer Präsentation zu PDF/Bildern erhalten?**

Aspose.Slides ermöglicht das Extrahieren eines SVG aus einem PictureFrame als Originalvektor. Beim Exportieren zu PDF oder Rasterformaten kann das Ergebnis je nach Exporteinstellungen gerastert werden; die Tatsache, dass das ursprüngliche SVG als Vektor gespeichert wird, wird durch das Extraktionsverhalten bestätigt.