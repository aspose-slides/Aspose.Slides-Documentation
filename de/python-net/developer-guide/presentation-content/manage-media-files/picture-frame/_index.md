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
description: "Fügen Sie Bildrahmen zu PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Python via .NET hinzu. Optimieren Sie Ihren Arbeitsablauf und verbessern Sie das Foliendesign."
---
## **Einleitung**

Bildrahmen in Aspose.Slides für Python ermöglichen das Platzieren und Verwalten von Raster‑ und Vektorbildern als native Folienformen. Sie können Bilder aus Dateien oder Streams einfügen, sie mit genauen Koordinaten positionieren und skalieren, Drehungen anwenden, Transparenz einstellen und die Z‑Ordnung neben anderen Formen steuern. Die API unterstützt außerdem das Zuschneiden, das Beibehalten von Seitenverhältnissen, das Festlegen von Rahmen und Effekten sowie das Ersetzen des zugrunde liegenden Bildes, ohne das Layout neu zu erstellen. Da Bildrahmen sich wie reguläre Formen verhalten, können Sie Animationen, Hyperlinks und Alternativtext hinzufügen, wodurch es einfach ist, visuell reiche, barrierefreie Präsentationen zu erstellen.

## **Bildrahmen erstellen**

Dieser Abschnitt zeigt, wie man ein Bild in eine Folie einfügt, indem man mit Aspose.Slides für Python ein [PictureFrame](https://reference.aspose.com/slides/de/python-net/aspose.slides/pictureframe/) erstellt. Sie lernen, wie Sie das Bild laden, es genau auf der Folie platzieren und seine Größe sowie Formatierung steuern.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/).
2. Rufen Sie eine Folie anhand ihres Index ab.
3. Erstellen Sie ein [PPImage](https://reference.aspose.com/slides/de/python-net/aspose.slides/ppimage/), indem Sie das Bild zur [ImageCollection](https://reference.aspose.com/slides/de/python-net/aspose.slides/imagecollection/) der Präsentation hinzufügen. Dieses Bild wird verwendet, um die Form zu füllen.
4. Geben Sie die Breite und Höhe des Rahmens an.
5. Erstellen Sie ein [PictureFrame](https://reference.aspose.com/slides/de/python-net/aspose.slides/pictureframe/) dieser Größe mit der Methode [add_picture_frame](https://reference.aspose.com/slides/de/python-net/aspose.slides/shapecollection/add_picture_frame/).
6. Speichern Sie die Präsentation als PPTX-Datei.

Der folgende Python-Code zeigt, wie man einen Bildrahmen erstellt:

```py
import aspose.slides as slides

# Instanziieren Sie die Presentation-Klasse, um eine PPTX-Datei darzustellen.
with slides.Presentation() as presentation:
    # Rufen Sie die erste Folie ab.
    slide = presentation.slides[0]

    # Fügen Sie das Bild zur Präsentation hinzu.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # Fügen Sie einen Bildrahmen in Bildgröße hinzu.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        # Speichern Sie die Präsentation als PPTX.
        presentation.save("picture_frame.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" %}}
Bildrahmen ermöglichen es Ihnen, schnell Präsentationsfolien aus Bildern zu erstellen. Wenn Sie Bildrahmen mit den Speicheroptionen von Aspose.Slides kombinieren, können Sie I/O‑Vorgänge steuern, um Bilder von einem Format in ein anderes zu konvertieren. Vielleicht möchten Sie diese Seiten ansehen: konvertieren [Bild nach JPG](https://products.aspose.com/slides/de/python-net/conversion/image-to-jpg/); konvertieren [JPG nach Bild](https://products.aspose.com/slides/de/python-net/conversion/jpg-to-image/); konvertieren [JPG nach PNG](https://products.aspose.com/slides/de/python-net/conversion/jpg-to-png/); konvertieren [PNG nach JPG](https://products.aspose.com/slides/de/python-net/conversion/png-to-jpg/); konvertieren [PNG nach SVG](https://products.aspose.com/slides/de/python-net/conversion/png-to-svg/); konvertieren [SVG nach PNG](https://products.aspose.com/slides/de/python-net/conversion/svg-to-png/).
{{% /alert %}}

## **Bildrahmen mit relativer Skalierung erstellen**

Dieser Abschnitt demonstriert das Platzieren eines Bildes mit fester Größe, gefolgt von einer prozentbasierten Skalierung von Breite und Höhe unabhängig voneinander. Da die Prozentsätze unterschiedlich sein können, kann das Seitenverhältnis geändert werden. Die Skalierung erfolgt relativ zu den Originalabmessungen des Bildes.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/).
2. Rufen Sie eine Folie anhand ihres Index ab.
3. Erstellen Sie ein [PPImage](https://reference.aspose.com/slides/de/python-net/aspose.slides/ppimage/), indem Sie das Bild zur [ImageCollection](https://reference.aspose.com/slides/de/python-net/aspose.slides/imagecollection/) der Präsentation hinzufügen.
4. Fügen Sie der Folie ein [PictureFrame](https://reference.aspose.com/slides/de/python-net/aspose.slides/pictureframe/) hinzu.
5. Legen Sie die relative Breite und Höhe des Bildrahmens fest.
6. Speichern Sie die Präsentation als PPTX-Datei.

Der folgende Python-Code zeigt, wie man einen Bildrahmen mit relativer Skalierung erstellt:

```py
import aspose.slides as slides

# Instanziieren Sie die Presentation-Klasse, um eine PPTX-Datei darzustellen.
with slides.Presentation() as presentation:
    # Holen Sie die erste Folie ab.
    slide = presentation.slides[0]

    # Fügen Sie das Bild zur Bildsammlung der Präsentation hinzu.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # Fügen Sie einen Bildrahmen zur Folie hinzu.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)

        # Legen Sie die relative Skalierungsbreite und -höhe fest.
        picture_frame.relative_scale_height = 0.8
        picture_frame.relative_scale_width = 1.35

        # Speichern Sie die Präsentation.
        presentation.save("relative_scaling.pptx", slides.export.SaveFormat.PPTX)
```

## **Rasterbilder aus Bildrahmen extrahieren**

Sie können Rasterbilder aus [PictureFrame]-Objekten extrahieren und sie im PNG-, JPG- und anderen Formaten speichern. Das folgende Codebeispiel zeigt, wie man ein Bild aus dem Dokument "sample.pptx" extrahiert und im PNG-Format speichert.

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

Wenn eine Präsentation SVG‑Grafiken enthält, die sich innerhalb von [PictureFrame]-Formen befinden, ermöglicht Aspose.Slides für Python über .NET das Abrufen der ursprünglichen Vektorbilder in voller Treue. Durch das Durchlaufen der Formsammlung der Folie können Sie jedes [PictureFrame] identifizieren, prüfen, ob das zugrunde liegende [PPImage] SVG‑Inhalt enthält, und das Bild dann auf dem Datenträger oder in einem Stream im nativen SVG‑Format speichern.

Das folgende Codebeispiel demonstriert, wie man ein SVG‑Bild aus einem Bildrahmen extrahiert:

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

Aspose.Slides ermöglicht das Abrufen des auf ein Bild angewendeten Transparenzeffekts. Dieser Python-Code demonstriert die Vorgehensweise:

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
Alle auf Bilder angewendeten Effekte finden Sie in [aspose.slides.effects](https://reference.aspose.com/slides/de/python-net/aspose.slides.effects/).
{{% /alert %}}

## **Helligkeit und Kontrast eines Bildes abrufen**

Aspose.Slides ermöglicht das Abrufen des Helligkeits- und Kontrasteffekts, der auf ein Bild angewendet wird. Die Klasse [Luminance](https://reference.aspose.com/slides/de/python-net/aspose.slides.effects/luminance/) stellt diesen Bildtransformations‑Effekt dar.

Dieser Python-Code zeigt, wie man die Helligkeits‑ und Kontrasteinstellungen eines Bildrahmens abruft:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    picture_frame = shape

    image_transform = picture_frame.picture_format.picture.image_transform
    for effect in image_transform:
        if isinstance(effect, slides.effects.Luminance):
            luminance = effect.get_effective()
            brightness = luminance.brightness
            contrast = luminance.contrast

            print("Brightness: " + str(brightness))
            print("Contrast: " + str(contrast))
```

## **Bildrahmen-Formatierung**

Aspose.Slides bietet viele Formatierungsoptionen, die Sie auf einen Bildrahmen anwenden können. Mit diesen Optionen können Sie einen Bildrahmen an spezifische Anforderungen anpassen.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/).
2. Rufen Sie eine Folie anhand ihres Index ab.
3. Erstellen Sie ein [PPImage](https://reference.aspose.com/slides/de/python-net/aspose.slides/ppimage/), indem Sie das Bild zur [ImageCollection](https://reference.aspose.com/slides/de/python-net/aspose.slides/imagecollection/) der Präsentation hinzufügen. Dieses Bild wird verwendet, um die Form zu füllen.
4. Geben Sie die Breite und Höhe des Rahmens an.
5. Erstellen Sie ein [PictureFrame](https://reference.aspose.com/slides/de/python-net/aspose.slides/pictureframe/) dieser Größe mit der Methode [add_picture_frame](https://reference.aspose.com/slides/de/python-net/aspose.slides/shapecollection/add_picture_frame/) der Folie.
6. Legen Sie die Linienfarbe des Bildrahmens fest.
7. Legen Sie die Linienbreite des Bildrahmens fest.
8. Drehen Sie den Bildrahmen, indem Sie einen positiven (im Uhrzeigersinn) oder negativen (gegen den Uhrzeigersinn) Wert angeben.
9. Speichern Sie die geänderte Präsentation als PPTX-Datei.

Der folgende Python-Code demonstriert den Bildrahmen-Formatierungsprozess:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanziieren Sie die Presentation-Klasse, um eine PPTX-Datei darzustellen.
with slides.Presentation() as presentation:
    # Holen Sie die erste Folie.
    slide = presentation.slides[0]

    # Fügen Sie das Bild zur Bildsammlung der Präsentation hinzu.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # Fügen Sie einen Bildrahmen in Bildgröße hinzu.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        # Wenden Sie die Formatierung auf den Bildrahmen an.
        picture_frame.line_format.fill_format.fill_type = slides.FillType.SOLID
        picture_frame.line_format.fill_format.solid_fill_color.color = draw.Color.blue
        picture_frame.line_format.width = 20
        picture_frame.rotation = 45

    # Speichern Sie die Präsentation als PPTX.
    presentation.save("picture_formatting.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Tip" color="primary" %}}
Aspose hat einen kostenlosen [Collage Maker](https://products.aspose.app/slides/de/collage) entwickelt. Wenn Sie [JPG/JPEG] oder PNG‑Bilder zusammenführen oder [Foto‑Raster] erstellen müssen, können Sie diesen Dienst nutzen.
{{% /alert %}}

## **Bilder als Links hinzufügen**

Um Präsentationsdateien klein zu halten, können Sie Bilder oder Videos über Links hinzufügen, anstatt die Dateien direkt in die Präsentation einzubetten. Der folgende Python-Code zeigt, wie man ein Bild und ein Video in einen Platzhalter einfügt:

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

In diesem Abschnitt lernen Sie, wie Sie den sichtbaren Bereich eines Bildes innerhalb eines Bildrahmens zuschneiden, ohne die Quelldatei zu ändern. Sie lernen außerdem die Grundmethode zum Anwenden von Beschnitträndern, um eine klare, fokussierte Komposition direkt auf der Folie zu erstellen.

Der folgende Python-Code zeigt, wie man ein Bild auf einer Folie zuschneidet:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Fügen Sie das Bild zur Bildsammlung der Präsentation hinzu.
    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    # Fügen Sie einen Bildrahmen zur Folie hinzu.
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 100, 100, 420, 250, image)

    # Zuschneiden des Bildes (Prozentwerte).
    picture_frame.picture_format.crop_left = 23.6
    picture_frame.picture_format.crop_right = 21.5
    picture_frame.picture_format.crop_top = 3
    picture_frame.picture_format.crop_bottom = 31

    # Speichern Sie das Ergebnis.
    presentation.save("cropped_image.pptx", slides.export.SaveFormat.PPTX)
```

## **Zugeschnittene Bildbereiche löschen**

Wenn Sie die zugeschnittenen Bereiche eines Bildes in einem Rahmen löschen möchten, verwenden Sie die Methode [delete_picture_cropped_areas](https://reference.aspose.com/slides/de/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/). Diese Methode gibt das zugeschnittene Bild zurück, oder das Originalbild, wenn kein Zuschnitt erforderlich ist.

Der folgende Python-Code demonstriert die Vorgehensweise:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Rufen Sie den PictureFrame von der ersten Folie ab.
    picture_frame = slides.shape[0]

    # Rufen Sie den PictureFrame von der ersten Folie ab.
    cropped_image = picture_frame.picture_format.delete_picture_cropped_areas()

    # Speichern Sie das Ergebnis.
    presentation.save("deleted_cropped_areas.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}
Die Methode [delete_picture_cropped_areas] fügt das zugeschnittene Bild zur Bildsammlung der Präsentation hinzu. Wenn das Bild nur im verarbeiteten [PictureFrame] verwendet wird, kann dies die Präsentationsgröße verringern; andernfalls kann die Anzahl der Bilder in der resultierenden Präsentation steigen.

Während des Zuschnitts konvertiert diese Methode WMF/EMF‑Metadateien in ein rasterbasiertes PNG‑Bild.
{{% /alert %}}

## **Bilder komprimieren**

Sie können ein Bild in einer Präsentation mit der Methode [PictureFillFormat.compress_image](https://reference.aspose.com/slides/de/python-net/aspose.slides/picturefillformat/compress_image/) komprimieren. Diese Methode komprimiert ein Bild, indem sie seine Größe basierend auf der Formgröße und der angegebenen Auflösung reduziert, mit der Option, zugeschnittene Bereiche zu löschen.

Sie passt die Bildgröße und Auflösung ähnlich der PowerPoint‑Funktion **Picture Format -> Compress Pictures -> Resolution** an.

Die folgenden Python‑Beispiele zeigen, wie man ein Bild in einer Präsentation komprimiert, indem man eine Zielauflösung angibt und optional zugeschnittene Bereiche entfernt:

```python
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = slide.shapes[0]

    # Bild mit einer Zielauflösung von 150 DPI (Web-Auflösung) komprimieren und zugeschnittene Bereiche entfernen.
    result = picture_frame.picture_format.compress_image(True, slides.export.PicturesCompression.DPI150)

    # Ergebnis der Komprimierung prüfen.
    if result:
        print("Image successfully compressed.")
    else:
        print("Image compression failed or no changes were necessary.")

    presentation.save("compressed_image.pptx", slides.export.SaveFormat.PPTX)
```

Oder direkt einen benutzerdefinierten DPI‑Wert verwenden:

```python
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = slide.shapes[0]

    # Bild auf 150 DPI (Web-Auflösung) komprimieren und zugeschnittene Bereiche entfernen.
    picture_frame.picture_format.compress_image(True, 150)

    presentation.save("compressed_image.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}
Die Methode konvertiert das Bild in eine niedrigere Auflösung basierend auf der Formgröße und dem angegebenen DPI. Zuschnittsbereiche können ebenfalls gelöscht werden, um die Dateigröße zu optimieren.
Ist das Bild eine Metadatei (WMF/EMF) oder SVG, wird keine Kompression angewendet. Außerdem bleibt die JPEG‑Qualität erhalten oder wird je nach Auflösung leicht reduziert, ähnlich wie PowerPoint bei hochauflösenden JPEGs.
{{% /alert %}}

## **Seitenverhältnis sperren**

Wenn Sie möchten, dass eine Form, die ein Bild enthält, ihr Seitenverhältnis beibehält, nachdem Sie die Bildabmessungen geändert haben, setzen Sie die Eigenschaft [aspect_ratio_locked](https://reference.aspose.com/slides/de/python-net/aspose.slides/pictureframelock/aspect_ratio_locked/) auf `True`.

Der folgende Python-Code zeigt, wie man das Seitenverhältnis einer Form sperrt:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.CUSTOM)
    empty_slide = presentation.slides.add_empty_slide(layout)

    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = empty_slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

    # Seitenverhältnis beim Ändern der Größe sperren.
    picture_frame.picture_frame_lock.aspect_ratio_locked = True

    presentation.save("aspect_ratio_locked.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}
Diese *Lock Aspect Ratio*-Einstellung bewahrt nur das Seitenverhältnis der Form, nicht das Seitenverhältnis des Bildes darin.
{{% /alert %}}

## **Stretch‑Offset‑Eigenschaften verwenden**

Durch die Verwendung der Eigenschaften `stretch_offset_left`, `stretch_offset_top`, `stretch_offset_right` und `stretch_offset_bottom` der Klasse [PictureFillFormat](https://reference.aspose.com/slides/de/python-net/aspose.slides/picturefillformat/) können Sie ein Füllrechteck definieren.

Wenn für ein Bild ein Stretching angegeben wird, wird das Quellrechteck skaliert, um in das Füllrechteck zu passen. Jede Kante des Füllrechtecks wird durch einen prozentualen Versatz von der entsprechenden Kante des Begrenzungsrahmens der Form definiert. Ein positiver Prozentsatz gibt einen Einschub an, während ein negativer Prozentsatz einen Ausbiss bezeichnet.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/).
2. Holen Sie sich eine Referenz auf eine Folie anhand ihres Index.
3. Fügen Sie eine rechteckige [AutoShape](https://reference.aspose.com/slides/de/python-net/aspose.slides/autoshape/) hinzu.
4. Legen Sie den Fülltyp der Form fest.
5. Legen Sie den Bildfüllmodus der Form fest.
6. Laden Sie ein Bild.
7. Weisen Sie das Bild zu, um die Form zu füllen.
8. Geben Sie Bildversätze von den entsprechenden Kanten des Begrenzungsrahmens der Form an.
9. Speichern Sie die Präsentation als PPTX-Datei.

Der folgende Python-Code demonstriert die Verwendung der Stretch‑Offset‑Eigenschaften:

```py
import aspose.slides as slides

# Instanziieren Sie die Presentation-Klasse, die eine PPTX-Datei darstellt.
with slides.Presentation() as presentation:
    # Rufen Sie die erste Folie ab.
    slide = presentation.slides[0]

    # Fügen Sie eine rechteckige AutoShape hinzu.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 300, 300)

    # Setzen Sie den Fülltyp der Form.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Setzen Sie den Bildfüllmodus der Form.
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    # Laden Sie das Bild und fügen Sie es der Präsentation hinzu.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

    # Weisen Sie das Bild zu, um die Form zu füllen.
    shape.fill_format.picture_fill_format.picture.image = image

    # Geben Sie Bildversätze von den entsprechenden Kanten des Begrenzungsrahmens der Form an.
    shape.fill_format.picture_fill_format.stretch_offset_left = 25
    shape.fill_format.picture_fill_format.stretch_offset_right = 25
    shape.fill_format.picture_fill_format.stretch_offset_top = -20
    shape.fill_format.picture_fill_format.stretch_offset_bottom = -10

    # Speichern Sie die PPTX-Datei auf dem Datenträger.
    presentation.save("stretch_offset.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert  title="Tip" color="primary" %}}
Aspose bietet kostenlose Konverter—[JPEG nach PowerPoint](https://products.aspose.app/slides/de/import/jpg-to-ppt) und [PNG nach PowerPoint](https://products.aspose.app/slides/de/import/png-to-ppt)—die Ihnen ermöglichen, schnell Präsentationen aus Bildern zu erstellen.
{{% /alert %}}

## **FAQ**

**Wie kann ich herausfinden, welche Bildformate für PictureFrame unterstützt werden?**

Aspose.Slides unterstützt sowohl Rasterbilder (PNG, JPEG, BMP, GIF usw.) als auch Vektorbilder (z. B. SVG) über das Bildobjekt, das einem [PictureFrame] zugewiesen wird. Die Liste der unterstützten Formate überschneidet sich im Allgemeinen mit den Fähigkeiten der Folien‑ und Bildkonvertierungsengine.

**Wie wirkt sich das Hinzufügen von Dutzenden großer Bilder auf die PPTX‑Größe und Performance aus?**

Das Einbetten großer Bilder erhöht die Dateigröße und den Speicherverbrauch; das Verlinken von Bildern hilft, die Präsentationsgröße klein zu halten, erfordert jedoch, dass die externen Dateien weiterhin zugänglich sind. Aspose.Slides bietet die Möglichkeit, Bilder per Link hinzuzufügen, um die Dateigröße zu reduzieren.

**Wie kann ich ein Bildobjekt vor versehentlichem Verschieben/Größenändern schützen?**

Verwenden Sie [shape locks](https://reference.aspose.com/slides/de/python-net/aspose.slides/pictureframe/picture_frame_lock/) für einen [PictureFrame] (z. B. das Verschieben oder die Größenänderung deaktivieren). Der Sperrmechanismus wird für Formen in einem separaten [protect article](/slides/de/python-net/applying-protection-to-presentation/) beschrieben und wird für verschiedene Formtypen, einschließlich [PictureFrame], unterstützt.

**Wird die Vektor‑Treue von SVG beim Export einer Präsentation zu PDF/Bildern beibehalten?**

Aspose.Slides ermöglicht das Extrahieren einer SVG aus einem [PictureFrame] als ursprünglichen Vektor. Beim [exporting to PDF](/slides/de/python-net/convert-powerpoint-to-pdf/) oder [raster formats](/slides/de/python-net/convert-powerpoint-to-png/) kann das Ergebnis je nach Export‑Einstellungen gerastert werden; die Tatsache, dass das ursprüngliche SVG als Vektor gespeichert ist, wird durch das Extraktionsverhalten bestätigt.