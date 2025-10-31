---
title: Add Picture Frames to Presentations with Python
linktitle: Picture Frame
type: docs
weight: 10
url: /de/python-net/picture-frame/
keywords:
- Bilderrahmen
- Bilderrahmen hinzufügen
- Bilderrahmen erstellen
- Bild hinzufügen
- Bild erstellen
- Bild extrahieren
- Rasterbild
- Vektorbilder
- Bild zuschneiden
- Zugeschnittener Bereich
- StretchOff-Eigenschaft
- Bilderrahmen-Formatierung
- Bilderrahmen-Eigenschaften
- relative Skalierung
- Bildeffekt
- Seitenverhältnis
- Bildtransparenz
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Fügen Sie PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Python via .NET Bilderrahmen hinzu. Optimieren Sie Ihren Arbeitsablauf und verbessern Sie das Design der Folien."
---

## **Übersicht**

Bilderrahmen in Aspose.Slides für Python ermöglichen das Platzieren und Verwalten von Raster‑ und Vektorbildern als native Folienformen. Sie können Bilder aus Dateien oder Streams einfügen, sie mit präzisen Koordinaten positionieren und skalieren, Rotation anwenden, Transparenz einstellen und die Z‑Reihenfolge zusammen mit anderen Formen steuern. Die API unterstützt zudem das Zuschneiden, das Beibehalten von Seitenverhältnissen, das Setzen von Rahmen und Effekten sowie das Ersetzen des zugrunde liegenden Bildes, ohne das Layout neu aufzubauen. Da Bilderrahmen sich wie reguläre Formen verhalten, können Sie Animationen, Hyperlinks und Alternativtexte hinzufügen, was den Aufbau visuell ansprechender und barrierefreier Präsentationen vereinfacht.

## **Bilderrahmen erstellen**

Dieser Abschnitt zeigt, wie Sie ein Bild in eine Folie einfügen, indem Sie mit Aspose.Slides für Python ein [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) erstellen. Sie lernen, wie das Bild geladen, genau positioniert und in Größe und Formatierung gesteuert wird.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse.
2. Rufen Sie eine Folie über ihren Index ab.
3. Erzeugen Sie ein [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/), indem Sie das Bild zur [ImageCollection](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/) der Präsentation hinzufügen. Dieses Bild wird zum Füllen der Form verwendet.
4. Legen Sie die Breite und Höhe des Rahmens fest.
5. Erstellen Sie mit der Methode [add_picture_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_picture_frame/) ein [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) dieser Größe.
6. Speichern Sie die Präsentation als PPTX‑Datei.

Der folgende Python‑Code zeigt, wie ein Bilderrahmen erstellt wird:

```py
import aspose.slides as slides

# Instanziieren der Presentation-Klasse zum Darstellen einer PPTX-Datei.
with slides.Presentation() as presentation:
    # Erste Folie abrufen.
    slide = presentation.slides[0]

    # Bild zur Präsentation hinzufügen.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # Einen Bildrahmen in Bildgröße hinzufügen.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        # Präsentation als PPTX speichern.
        presentation.save("picture_frame.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" %}}

Bilderrahmen ermöglichen es Ihnen, schnell Präsentationsfolien aus Bildern zu erstellen. Wenn Sie Bilderrahmen mit den Speichereinstellungen von Aspose.Slides kombinieren, können Sie I/O‑Vorgänge steuern, um Bilder von einem Format in ein anderes zu konvertieren. Sie möchten vielleicht diese Seiten sehen: konvertieren [Bild zu JPG](https://products.aspose.com/slides/python-net/conversion/image-to-jpg/); konvertieren [JPG zu Bild](https://products.aspose.com/slides/python-net/conversion/jpg-to-image/); konvertieren [JPG zu PNG](https://products.aspose.com/slides/python-net/conversion/jpg-to-png/); konvertieren [PNG zu JPG](https://products.aspose.com/slides/python-net/conversion/png-to-jpg/); konvertieren [PNG zu SVG](https://products.aspose.com/slides/python-net/conversion/png-to-svg/); konvertieren [SVG zu PNG](https://products.aspose.com/slides/python-net/conversion/svg-to-png/).

{{% /alert %}}

## **Bilderrahmen mit relativer Skalierung erstellen**

In diesem Abschnitt wird ein Bild mit fester Größe platziert und anschließend prozentual unabhängig von Breite und Höhe skaliert. Da die Prozentsätze unterschiedlich sein können, kann sich das Seitenverhältnis ändern. Die Skalierung erfolgt relativ zu den Originalabmessungen des Bildes.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse.
2. Rufen Sie eine Folie über ihren Index ab.
3. Erzeugen Sie ein [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/), indem Sie das Bild zur [ImageCollection](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/) der Präsentation hinzufügen.
4. Fügen Sie der Folie ein [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) hinzu.
5. Setzen Sie die relative Breite und Höhe des Bilderrahmens.
6. Speichern Sie die Präsentation als PPTX‑Datei.

Der folgende Python‑Code demonstriert das Erstellen eines Bilderrahmens mit relativer Skalierung:

```py
import aspose.slides as slides

# Instanziieren der Presentation-Klasse zum Darstellen einer PPTX-Datei.
with slides.Presentation() as presentation:
    # Erste Folie abrufen.
    slide = presentation.slides[0]

    # Bild zur Bildsammlung der Präsentation hinzufügen.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # Bildrahmen zur Folie hinzufügen.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)

        # Relative Skalierung von Breite und Höhe festlegen.
        picture_frame.relative_scale_height = 0.8
        picture_frame.relative_scale_width = 1.35

        # Präsentation speichern.
        presentation.save("relative_scaling.pptx", slides.export.SaveFormat.PPTX)
```

## **Rasterbilder aus Bilderrahmen extrahieren**

Sie können Rasterbilder aus [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/)-Objekten extrahieren und in PNG, JPG und anderen Formaten speichern. Das folgende Beispiel demonstriert das Extrahieren eines Bildes aus der Datei „sample.pptx“ und das Speichern im PNG‑Format.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    first_slide = presentation.slides[0]
    first_shape = first_slide.shapes[0]

    if isinstance(first_shape, slides.PictureFrame):
        image = first_shape.picture_format.picture.image.image
        image.save("slide_1_shape_1.png", slides.ImageFormat.PNG)
```

## **SVG‑Bilder aus Bilderrahmen extrahieren**

Enthält eine Präsentation SVG‑Grafiken, die in [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/)- Formen eingebettet sind, ermöglicht Aspose.Slides für Python via .NET das Abrufen der ursprünglichen Vektorbilder in voller Treue. Durch Durchlaufen der Formsammlung einer Folie können Sie jeden [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) identifizieren, prüfen, ob das zugrunde liegende [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) SVG‑Inhalt enthält, und das Bild dann im nativen SVG‑Format speichern.

Der folgende Code demonstriert das Extrahieren eines SVG‑Bildes aus einem Bilderrahmen:

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

Aspose.Slides ermöglicht das Abrufen des Transparenzeffekts, der einem Bild zugeordnet ist. Der folgende Python‑Code demonstriert die Vorgehensweise:

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
Alle auf Bilder angewendeten Effekte finden Sie unter [aspose.slides.effects](https://reference.aspose.com/slides/python-net/aspose.slides.effects/).
{{% /alert %}}

## **Bilderrahmen formatieren**

Aspose.Slides bietet zahlreiche Formatierungsoptionen für Bilderrahmen. Mit diesen Optionen können Sie einen Bilderrahmen an spezifische Anforderungen anpassen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse.
2. Rufen Sie eine Folie über ihren Index ab.
3. Erzeugen Sie ein [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/), indem Sie das Bild zur [ImageCollection](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/) der Präsentation hinzufügen. Dieses Bild wird zum Füllen der Form verwendet.
4. Legen Sie die Breite und Höhe des Rahmens fest.
5. Erstellen Sie ein [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) dieser Größe mittels der Methode [add_picture_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_picture_frame/).
6. Setzen Sie die Linienfarbe des Bilderrahmens.
7. Setzen Sie die Linienstärke des Bilderrahmens.
8. Rotieren Sie den Bilderrahmen, indem Sie einen positiven (im Uhrzeigersinn) oder negativen (gegen den Uhrzeigersinn) Wert angeben.
9. Speichern Sie die modifizierte Präsentation als PPTX‑Datei.

Der folgende Python‑Code demonstriert den Formatierungsprozess:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanziieren der Presentation-Klasse zum Darstellen einer PPTX-Datei.
with slides.Presentation() as presentation:
    # Erste Folie abrufen.
    slide = presentation.slides[0]

    # Bild zur Bildsammlung der Präsentation hinzufügen.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # Bildrahmen in Bildgröße hinzufügen.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        # Formatierung auf den Bildrahmen anwenden.
        picture_frame.line_format.fill_format.fill_type = slides.FillType.SOLID
        picture_frame.line_format.fill_format.solid_fill_color.color = draw.Color.blue
        picture_frame.line_format.width = 20
        picture_frame.rotation = 45

    # Präsentation als PPTX speichern.
    presentation.save("picture_formatting.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Tip" color="primary" %}}

Aspose hat einen kostenlosen [Collage Maker](https://products.aspose.app/slides/collage) entwickelt. Wenn Sie JPG/JPEG‑ oder PNG‑Bilder zusammenführen oder Fotogitter erstellen möchten, können Sie diesen Service nutzen.

{{% /alert %}}

## **Bilder als Links hinzufügen**

Um Präsentationsdateien klein zu halten, können Sie Bilder oder Videos per Link einbinden, anstatt die Dateien direkt in die Präsentation zu integrieren. Der nachfolgende Python‑Code zeigt, wie ein Bild und ein Video in einen Platzhalter eingefügt werden:

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

In diesem Abschnitt lernen Sie, wie Sie den sichtbaren Bildbereich innerhalb eines Bilderrahmens zuschneiden, ohne die Quelldatei zu verändern. Außerdem wird die Grundmethode zum Anwenden von Zuschnittsrandwerten gezeigt, um eine klare, fokussierte Komposition direkt auf der Folie zu erzeugen.

Der folgende Python‑Code demonstriert das Zuschneiden eines Bildes auf einer Folie:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Bild zur Bildsammlung der Präsentation hinzufügen.
    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    # Bildrahmen zur Folie hinzufügen.
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 100, 100, 420, 250, image)

    # Bild zuschneiden (Prozentwerte).
    picture_frame.picture_format.crop_left = 23.6
    picture_frame.picture_format.crop_right = 21.5
    picture_frame.picture_format.crop_top = 3
    picture_frame.picture_format.crop_bottom = 31

    # Ergebnis speichern.
    presentation.save("cropped_image.pptx", slides.export.SaveFormat.PPTX)
```

## **Zugeschnittene Bildbereiche löschen**

Wenn Sie die zugeschnittenen Bereiche eines Bildes in einem Rahmen entfernen möchten, verwenden Sie die Methode [delete_picture_cropped_areas](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/). Diese Methode gibt das zugeschnittene Bild zurück oder das Originalbild, falls kein Zuschnitt nötig ist.

Der folgende Python‑Code demonstriert die Vorgehensweise:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Bildrahmen von der ersten Folie abrufen.
    picture_frame = slides.shape[0]

    # Bildrahmen von der ersten Folie abrufen.
    cropped_image = picture_frame.picture_format.delete_picture_cropped_areas()

    # Ergebnis speichern.
    presentation.save("deleted_cropped_areas.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}

Die Methode [delete_picture_cropped_areas](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) fügt das zugeschnittene Bild zur Bildsammlung der Präsentation hinzu. Wird das Bild nur im verarbeiteten [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) verwendet, kann dies die Dateigröße reduzieren; andernfalls kann die Bildanzahl in der resultierenden Präsentation steigen.

Während des Zuschnitts konvertiert diese Methode WMF/EMF‑Metadateien in ein Raster‑PNG‑Bild.

{{% /alert %}}

## **Seitenverhältnis sperren**

Wenn Sie möchten, dass ein Formobjekt mit Bild sein Seitenverhältnis nach einer Größenänderung beibehält, setzen Sie die Eigenschaft [aspect_ratio_locked](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/aspect_ratio_locked/) auf `True`.

Der folgende Python‑Code zeigt, wie das Seitenverhältnis einer Form gesperrt wird:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.CUSTOM)
    empty_slide = presentation.slides.add_empty_slide(layout)

    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = empty_slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

    # Seitenverhältnis beim Skalieren sperren.
    picture_frame.picture_frame_lock.aspect_ratio_locked = True

    presentation.save("aspect_ratio_locked.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}

Diese Einstellung *Seitenverhältnis sperren* bewahrt nur das Seitenverhältnis der Form, nicht das des darin enthaltenen Bildes.

{{% /alert %}}

## **Verwendung von Stretch‑Offset‑Eigenschaften**

Durch die Eigenschaften `stretch_offset_left`, `stretch_offset_top`, `stretch_offset_right` und `stretch_offset_bottom` der Klasse [PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/) können Sie ein Füllrechteck definieren.

Wird ein Bild gestreckt, wird das Quellrechteck so skaliert, dass es in das Füllrechteck passt. Jeder Rand des Füllrechtecks wird durch einen prozentualen Versatz vom entsprechenden Rand der begrenzenden Box der Form definiert. Ein positiver Prozentsatz bedeutet Einziehen, ein negativer Prozentsatz Ausdehnen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse.
2. Holen Sie sich eine Referenz zu einer Folie über deren Index.
3. Fügen Sie eine rechteckige [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) hinzu.
4. Setzen Sie den Fülltyp der Form.
5. Setzen Sie den Bildfüllmodus der Form.
6. Laden Sie ein Bild.
7. Weisen Sie das Bild der Form zu, um sie zu füllen.
8. Geben Sie Bildversätze von den jeweiligen Rändern der begrenzenden Box der Form an.
9. Speichern Sie die Präsentation als PPTX‑Datei.

Der folgende Python‑Code demonstriert die Verwendung der Stretch‑Offset‑Eigenschaften:

```py
import aspose.slides as slides

# Instanziieren der Presentation-Klasse, die eine PPTX-Datei repräsentiert.
with slides.Presentation() as presentation:
    # Erste Folie abrufen.
    slide = presentation.slides[0]

    # Rechteckige AutoShape hinzufügen.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 300, 300)

    # Fülltyp der Form festlegen.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Bildfüllmodus der Form festlegen.
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    # Bild laden und zur Präsentation hinzufügen.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

    # Bild der Form zuweisen, um sie zu füllen.
    shape.fill_format.picture_fill_format.picture.image = image

    # Bildversätze von den jeweiligen Rändern der Formbox angeben.
    shape.fill_format.picture_fill_format.stretch_offset_left = 25
    shape.fill_format.picture_fill_format.stretch_offset_right = 25
    shape.fill_format.picture_fill_format.stretch_offset_top = -20
    shape.fill_format.picture_fill_format.stretch_offset_bottom = -10

    # PPTX-Datei auf Festplatte speichern.
    presentation.save("stretch_offset.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Tip" color="primary" %}}

Aspose stellt kostenlose Konverter bereit – [JPEG zu PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) und [PNG zu PowerPoint](https://products.aspose.app/slides/import/png-to-ppt) – mit denen Sie schnell Präsentationen aus Bildern erstellen können.

{{% /alert %}}

## **FAQ**

**Wie finde ich heraus, welche Bildformate für PictureFrame unterstützt werden?**

Aspose.Slides unterstützt sowohl Rasterbilder (PNG, JPEG, BMP, GIF usw.) als auch Vektorbilder (z. B. SVG) über das Bildobjekt, das einem [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) zugewiesen wird. Die unterstützten Formate überschneiden sich im Allgemeinen mit den Fähigkeiten der Folien‑ und Bildkonvertierungs‑Engine.

**Wie wirkt sich das Hinzufügen von Dutzenden großer Bilder auf die PPTX‑Größe und Performance aus?**

Das Einbetten großer Bilder erhöht Dateigröße und Speicherverbrauch; das Verlinken von Bildern hält die Präsentationsgröße klein, erfordert jedoch, dass die externen Dateien weiterhin zugänglich sind. Aspose.Slides bietet die Möglichkeit, Bilder per Link hinzuzufügen, um die Dateigröße zu reduzieren.

**Wie kann ich ein Bildobjekt vor versehentlichem Verschieben/Größenändern schützen?**

Verwenden Sie [Form‑Sperren](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/picture_frame_lock/) für einen [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) (z. B. Sperren von Verschieben oder Skalieren). Der Sperrmechanismus wird für Formen in einem separaten [Schutz‑Artikel](/slides/de/python-net/applying-protection-to-presentation/) beschrieben und wird für verschiedene Formtypen, einschließlich [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/), unterstützt.

**Wird die Vektortreue von SVG beim Export einer Präsentation zu PDF/Bildern beibehalten?**

Aspose.Slides ermöglicht das Extrahieren eines SVG aus einem [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) als ursprünglichen Vektor. Beim [Export zu PDF](/slides/de/python-net/convert-powerpoint-to-pdf/) oder zu Rasterformaten [/slides/python-net/convert-powerpoint-to-png/] kann das Ergebnis je nach Exporteinstellungen gerastert werden; die Tatsache, dass das ursprüngliche SVG als Vektor gespeichert ist, wird durch das Extraktionsverhalten bestätigt.