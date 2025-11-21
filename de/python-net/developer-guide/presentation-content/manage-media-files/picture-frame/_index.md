---
title: Bilderrahmen zu Präsentationen mit Python hinzufügen
linktitle: Bilderrahmen
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
- Vektorbild
- Bild zuschneiden
- Zuge­schnittener Bereich
- StretchOff‑Eigenschaft
- Bilderrahmen‑Formatierung
- Bilderrahmen‑Eigenschaften
- relative Skalierung
- Bildeffekt
- Seitenverhältnis
- Bildtransparenz
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Fügen Sie PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Python über .NET Bilderrahmen hinzu. Optimieren Sie Ihren Arbeitsablauf und verbessern Sie das Design der Folien."
---

## **Übersicht**

Bilderrahmen in Aspose.Slides für Python ermöglichen das Platzieren und Verwalten von Raster‑ und Vektorbildern als native Folienformen. Sie können Bilder aus Dateien oder Streams einfügen, sie mit genauen Koordinaten positionieren und skalieren, eine Drehung anwenden, Transparenz festlegen und die Z‑Reihenfolge zusammen mit anderen Formen steuern. Die API unterstützt zudem das Zuschneiden, das Beibehalten von Seitenverhältnissen, das Festlegen von Rändern und Effekten sowie das Ersetzen des zugrunde liegenden Bildes, ohne das Layout neu zu erstellen. Da Bilderrahmen sich wie reguläre Formen verhalten, können Sie Animationen, Hyperlinks und Alternativtext hinzufügen, was das Erstellen visuell reichhaltiger, barrierefreier Präsentationen vereinfacht.

## **Bilderrahmen erstellen**

Dieser Abschnitt zeigt, wie Sie ein Bild in eine Folie einfügen, indem Sie mit Aspose.Slides für Python einen [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) erstellen. Sie lernen, wie das Bild geladen, präzise auf der Folie platziert und seine Größe sowie Formatierung gesteuert werden.

1. Erzeugen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Rufen Sie eine Folie anhand ihres Index ab.
3. Erstellen Sie ein [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) indem Sie das Bild zur [ImageCollection](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/) der Präsentation hinzufügen. Dieses Bild wird zum Füllen der Form verwendet.
4. Geben Sie die Breite und Höhe des Rahmens an.
5. Erzeugen Sie einen [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) dieser Größe mithilfe der Methode [add_picture_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_picture_frame/).
6. Speichern Sie die Präsentation als PPTX-Datei.

```py
import aspose.slides as slides

# Instanziieren Sie die Presentation‑Klasse, um eine PPTX‑Datei darzustellen.
with slides.Presentation() as presentation:
    # Holen Sie die erste Folie.
    slide = presentation.slides[0]

    # Fügen Sie das Bild zur Präsentation hinzu.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # Fügen Sie einen Bilderrahmen mit der Größe des Bildes hinzu.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        # Speichern Sie die Präsentation als PPTX.
        presentation.save("picture_frame.pptx", slides.export.SaveFormat.PPTX)
```


{{% alert color="warning" %}}
Bilderrahmen ermöglichen es Ihnen, schnell Präsentationsfolien aus Bildern zu erstellen. Wenn Sie Bilderrahmen mit den Speicheroptionen von Aspose.Slides kombinieren, können Sie I/O‑Operationen steuern, um Bilder von einem Format in ein anderes zu konvertieren. Möglicherweise interessieren Sie folgende Seiten: konvertieren [Bild zu JPG](https://products.aspose.com/slides/python-net/conversion/image-to-jpg/); konvertieren [JPG zu Bild](https://products.aspose.com/slides/python-net/conversion/jpg-to-image/); konvertieren [JPG zu PNG](https://products.aspose.com/slides/python-net/conversion/jpg-to-png/); konvertieren [PNG zu JPG](https://products.aspose.com/slides/python-net/conversion/png-to-jpg/); konvertieren [PNG zu SVG](https://products.aspose.com/slides/python-net/conversion/png-to-svg/); konvertieren [SVG zu PNG](https://products.aspose.com/slides/python-net/conversion/svg-to-png/).
{{% /alert %}}

## **Bilderrahmen mit relativer Skalierung erstellen**

Dieser Abschnitt demonstriert das Platzieren eines Bildes in fester Größe und anschließend das Anwenden einer prozentbasierten Skalierung unabhängig für Breite und Höhe. Da die Prozentsätze unterschiedlich sein können, kann sich das Seitenverhältnis ändern. Die Skalierung erfolgt relativ zu den ursprünglichen Abmessungen des Bildes.

1. Erzeugen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Rufen Sie eine Folie anhand ihres Index ab.
3. Erstellen Sie ein [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) indem Sie das Bild zur [ImageCollection](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/) der Präsentation hinzufügen.
4. Fügen Sie der Folie einen [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) hinzu.
5. Setzen Sie die relative Breite und Höhe des Bilderrahmens.
6. Speichern Sie die Präsentation als PPTX-Datei.

```py
import aspose.slides as slides

# Instanziieren Sie die Presentation-Klasse, um eine PPTX-Datei darzustellen.
with slides.Presentation() as presentation:
    # Holen Sie die erste Folie.
    slide = presentation.slides[0]

    # Fügen Sie das Bild zur Bildsammlung der Präsentation hinzu.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # Fügen Sie einen Bilderrahmen zur Folie hinzu.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)

        # Setzen Sie die relative Skalierungsbreite und -höhe.
        picture_frame.relative_scale_height = 0.8
        picture_frame.relative_scale_width = 1.35

        # Speichern Sie die Präsentation.
        presentation.save("relative_scaling.pptx", slides.export.SaveFormat.PPTX)
```


## **Rasterbilder aus Bilderrahmen extrahieren**

Sie können Rasterbilder aus [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/)-Objekten extrahieren und sie in PNG, JPG und anderen Formaten speichern. Das untenstehende Codebeispiel zeigt, wie ein Bild aus dem Dokument "sample.pptx" extrahiert und im PNG-Format gespeichert wird.
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

Enthält eine Präsentation SVG‑Grafiken, die in [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/)-Formen eingefügt wurden, ermöglicht Aspose.Slides für Python via .NET das Abrufen der ursprünglichen Vektorbilder mit voller Genauigkeit. Durch das Durchlaufen der Formensammlung einer Folie können Sie jedes [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) identifizieren, prüfen, ob das zugrunde liegende [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) SVG‑Inhalt enthält, und das Bild dann auf dem Datenträger oder in einem Stream im nativen SVG‑Format speichern.
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
Alle auf Bilder angewendeten Effekte finden Sie in [aspose.slides.effects](https://reference.aspose.com/slides/python-net/aspose.slides.effects/).
{{% /alert %}}

## **Bilderrahmen‑Formatierung**

Aspose.Slides bietet zahlreiche Formatierungsoptionen, die Sie auf einen Bilderrahmen anwenden können. Mit diesen Optionen können Sie einen Bilderrahmen an spezifische Anforderungen anpassen.

1. Erzeugen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Rufen Sie eine Folie anhand ihres Index ab.
3. Erstellen Sie ein [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) indem Sie das Bild zur [ImageCollection](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/) der Präsentation hinzufügen. Dieses Bild wird zum Füllen der Form verwendet.
4. Geben Sie die Breite und Höhe des Rahmens an.
5. Erzeugen Sie einen [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) dieser Größe mithilfe der Methode [add_picture_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_picture_frame/) der Folie.
6. Setzen Sie die Linienfarbe des Bilderrahmens.
7. Setzen Sie die Linienstärke des Bilderrahmens.
8. Drehen Sie den Bilderrahmen, indem Sie einen positiven (im Uhrzeigersinn) oder negativen (gegen den Uhrzeigersinn) Wert angeben.
9. Speichern Sie die geänderte Präsentation als PPTX-Datei.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanziieren Sie die Presentation-Klasse, um eine PPTX-Datei zu repräsentieren.
with slides.Presentation() as presentation:
    # Holen Sie die erste Folie.
    slide = presentation.slides[0]

    # Fügen Sie das Bild zur Bildsammlung der Präsentation hinzu.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # Fügen Sie einen Bilderrahmen in Bildgröße hinzu.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        # Wenden Sie die Formatierung auf den Bilderrahmen an.
        picture_frame.line_format.fill_format.fill_type = slides.FillType.SOLID
        picture_frame.line_format.fill_format.solid_fill_color.color = draw.Color.blue
        picture_frame.line_format.width = 20
        picture_frame.rotation = 45

    # Speichern Sie die Präsentation als PPTX.
    presentation.save("picture_formatting.pptx", slides.export.SaveFormat.PPTX)
```


{{% alert title="Hinweis" color="primary" %}}
Aspose hat einen kostenlosen [Collage Maker](https://products.aspose.app/slides/collage) entwickelt. Wenn Sie [JPG/JPEG](https://products.aspose.app/slides/collage/jpg) oder PNG‑Bilder zusammenführen oder [Foto‑Raster](https://products.aspose.app/slides/collage/photo-grid) benötigen, können Sie diesen Dienst nutzen.
{{% /alert %}}

## **Bilder als Links hinzufügen**

Um Präsentationsdateien klein zu halten, können Sie Bilder oder Videos über Links hinzufügen, anstatt die Dateien direkt in die Präsentationen einzubetten. Der folgende Python‑Code zeigt, wie ein Bild und ein Video in einen Platzhalter eingefügt werden:
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

In diesem Abschnitt lernen Sie, wie Sie den sichtbaren Bereich eines Bildes innerhalb eines Bilderrahmens zuschneiden, ohne die Quelldatei zu verändern. Außerdem erfahren Sie, wie Sie Grundränder zum Zuschneiden anwenden, um eine klare, fokussierte Komposition direkt auf der Folie zu erstellen.
```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Bild zur Bildsammlung der Präsentation hinzufügen.
    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    # Einen Bilderrahmen zur Folie hinzufügen.
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

Wenn Sie zugeschnittene Bereiche eines Bildes in einem Rahmen löschen möchten, verwenden Sie die Methode [delete_picture_cropped_areas](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/). Diese Methode gibt das zugeschnittene Bild zurück, bzw. das Originalbild, wenn kein Zuschnitt erforderlich ist.
```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Holen Sie den PictureFrame von der ersten Folie.
    picture_frame = slides.shape[0]

    # Holen Sie den PictureFrame von der ersten Folie.
    cropped_image = picture_frame.picture_format.delete_picture_cropped_areas()

    # Ergebnis speichern.
    presentation.save("deleted_cropped_areas.pptx", slides.export.SaveFormat.PPTX)
```


{{% alert title="HINWEIS" color="warning" %}}
Die Methode [delete_picture_cropped_areas](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) fügt das zugeschnittene Bild zur Bildsammlung der Präsentation hinzu. Wird das Bild nur im verarbeiteten [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) verwendet, kann dies die Präsentationsgröße reduzieren; andernfalls kann die Anzahl der Bilder in der resultierenden Präsentation steigen.

Während des Zuschneidens konvertiert diese Methode WMF/EMF‑Metadateien in ein Raster‑PNG‑Bild.
{{% /alert %}}

## **Seitenverhältnis sperren**

Wenn Sie möchten, dass eine Form, die ein Bild enthält, ihr Seitenverhältnis nach einer Größenänderung des Bildes beibehält, setzen Sie die Eigenschaft [aspect_ratio_locked](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/aspect_ratio_locked/) auf `True`.
```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.CUSTOM)
    empty_slide = presentation.slides.add_empty_slide(layout)

    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = empty_slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

    # Das Seitenverhältnis beim Skalieren sperren.
    picture_frame.picture_frame_lock.aspect_ratio_locked = True

    presentation.save("aspect_ratio_locked.pptx", slides.export.SaveFormat.PPTX)
```


{{% alert title="HINWEIS" color="warning" %}}
Diese *Lock Aspect Ratio*-Einstellung bewahrt nur das Seitenverhältnis der Form, nicht das Seitenverhältnis des Bildes darin.
{{% /alert %}}

## **Stretch‑Offset‑Eigenschaften verwenden**

Mit den Eigenschaften `stretch_offset_left`, `stretch_offset_top`, `stretch_offset_right` und `stretch_offset_bottom` der Klasse [PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/) können Sie ein Füllrechteck definieren.

Wenn für ein Bild ein Stretch angegeben ist, wird das Quellrechteck so skaliert, dass es in das Füllrechteck passt. Jede Kante des Füllrechtecks wird durch einen prozentualen Versatz von der entsprechenden Kante des Begrenzungsrahmens der Form festgelegt. Ein positiver Prozentsatz gibt einen Einzug an, ein negativer Prozentsatz einen Auszug.

1. Erzeugen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Rufen Sie eine Referenz zu einer Folie anhand ihres Index ab.
3. Fügen Sie ein rechteckiges [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) hinzu.
4. Setzen Sie den Fülltyp der Form.
5. Setzen Sie den Bildfüllmodus der Form.
6. Laden Sie ein Bild.
7. Weisen Sie das Bild als Füllung der Form zu.
8. Geben Sie Bildversätze von den entsprechenden Kanten des Begrenzungsrahmens der Form an.
9. Speichern Sie die Präsentation als PPTX-Datei.

```py
import aspose.slides as slides

# Instanzieren Sie die Presentation-Klasse, die eine PPTX-Datei repräsentiert.
with slides.Presentation() as presentation:
    # Holen Sie die erste Folie.
    slide = presentation.slides[0]

    # Fügen Sie ein Rechteck-AutoShape hinzu.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 300, 300)

    # Setzen Sie den Fülltyp der Form.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Setzen Sie den Bildfüllmodus der Form.
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    # Laden Sie das Bild und fügen Sie es der Präsentation hinzu.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

    # Weisen Sie das Bild der Füllung der Form zu.
    shape.fill_format.picture_fill_format.picture.image = image

    # Geben Sie Bildversätze von den entsprechenden Kanten des Begrenzungsrahmens der Form an.
    shape.fill_format.picture_fill_format.stretch_offset_left = 25
    shape.fill_format.picture_fill_format.stretch_offset_right = 25
    shape.fill_format.picture_fill_format.stretch_offset_top = -20
    shape.fill_format.picture_fill_format.stretch_offset_bottom = -10

    # Speichern Sie die PPTX-Datei auf der Festplatte.
    presentation.save("stretch_offset.pptx", slides.export.SaveFormat.PPTX)
```


{{% alert title="Hinweis" color="primary" %}}
Aspose bietet kostenlose Konverter — [JPEG zu PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) und [PNG zu PowerPoint](https://products.aspose.app/slides/import/png-to-ppt) — die Ihnen ermöglichen, schnell Präsentationen aus Bildern zu erstellen.
{{% /alert %}}

## **FAQ**

**Wie kann ich herausfinden, welche Bildformate für PictureFrame unterstützt werden?**

Aspose.Slides unterstützt sowohl Rasterbilder (PNG, JPEG, BMP, GIF usw.) als auch Vektorbilder (zum Beispiel SVG) über das Bildobjekt, das einem [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) zugewiesen wird. Die Liste der unterstützten Formate überschneidet sich im Allgemeinen mit den Möglichkeiten der Folien‑ und Bildkonvertierungs‑Engine.

**Wie wirkt sich das Hinzufügen von Dutzenden großer Bilder auf die PPTX‑Größe und Performance aus?**

Das Einbetten großer Bilder erhöht die Dateigröße und den Speicherverbrauch; das Verlinken von Bildern hilft, die Präsentationsgröße klein zu halten, erfordert jedoch, dass die externen Dateien weiterhin zugänglich bleiben. Aspose.Slides bietet die Möglichkeit, Bilder per Link hinzuzufügen, um die Dateigröße zu reduzieren.

**Wie kann ich ein Bildobjekt vor versehentlichem Verschieben/Größenändern schützen?**

Verwenden Sie [shape locks](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/picture_frame_lock/) für ein [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) (z. B. das Verschieben oder die Größenänderung deaktivieren). Der Sperrmechanismus wird für Formen in einem separaten [Schutz‑Artikel](/slides/de/python-net/applying-protection-to-presentation/) beschrieben und wird für verschiedene Formtypen unterstützt, einschließlich [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/).

**Bleibt die Vektor‑Genauigkeit von SVG beim Exportieren einer Präsentation zu PDF/Bildern erhalten?**

Aspose.Slides erlaubt das Extrahieren eines SVG aus einem [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) als ursprünglichen Vektor. Beim [Exportieren zu PDF](/slides/de/python-net/convert-powerpoint-to-pdf/) oder zu [Rasterformaten](/slides/de/python-net/convert-powerpoint-to-png/) kann das Ergebnis je nach Exporteinstellungen gerastert werden; die Tatsache, dass das ursprüngliche SVG als Vektor gespeichert ist, wird durch das Extraktionsverhalten bestätigt.