---
title: Bilderrahmen zu Präsentationen mit Python hinzufügen
linktitle: Bilderrahmen
type: docs
weight: 10
url: /de/python-net/picture-frame/
keywords:
- bilderrahmen
- bilderrahmen hinzufügen
- bilderrahmen erstellen
- bild hinzufügen
- bild erstellen
- bild extrahieren
- rasterbild
- vektorbild
- bild zuschneiden
- zugeschnittener Bereich
- StretchOff-Eigenschaft
- Bilderrahmenformatierung
- Bilderrahmeneigenschaften
- relative Skalierung
- Bildeffekt
- Seitenverhältnis
- Bildtransparenz
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Fügen Sie mit Aspose.Slides for Python via .NET Bilderrahmen zu PowerPoint- und OpenDocument-Präsentationen hinzu. Optimieren Sie Ihren Arbeitsablauf und veredeln Sie das Folienlayout."
---

Ein Bilderrahmen ist eine Form, die ein Bild enthält – es ist wie ein Bild in einem Rahmen.

Sie können ein Bild auf eine Folie über einen Bilderrahmen hinzufügen. Auf diese Weise können Sie das Bild durch die Formatierung des Bilderrahmens formatieren.

{{% alert  title="Tipp" color="primary" %}} 

Aspose bietet kostenlose Konverter – [JPEG zu PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) und [PNG zu PowerPoint](https://products.aspose.app/slides/import/png-to-ppt) – die es den Benutzern ermöglichen, schnell Präsentationen aus Bildern zu erstellen.

{{% /alert %}} 

## **Bilderrahmen erstellen**

1. Erstellen Sie eine Instanz der [Presentation ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
2. Holen Sie sich die Referenz einer Folie über ihren Index.
3. Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage/) Objekt, indem Sie ein Bild zur [IImageskollektion](https://reference.aspose.com/slides/python-net/aspose.slides/iimagecollection/) hinzufügen, die mit dem Präsentationsobjekt verbunden ist, das verwendet werden soll, um die Form auszufüllen.
4. Geben Sie die Breite und Höhe des Bildes an.
5. Erstellen Sie einen [Bilderrahmen](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) basierend auf der Breite und Höhe des Bildes über die `AddPictureFrame` Methode, die vom Formobjekt bereitgestellt wird, das mit der verwiesenen Folie verbunden ist.
6. Fügen Sie der Folie einen Bilderrahmen (der das Bild enthält) hinzu.
7. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser Python-Code zeigt Ihnen, wie Sie einen Bilderrahmen erstellen:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanziiert die Presentation-Klasse, die eine PPTX-Datei repräsentiert
with slides.Presentation() as pres:
    # Holt die erste Folie
    sld = pres.slides[0]

    # Instanziiert die ImageEx-Klasse
    with open("img.jpeg", "rb") as in_file:
        image = pres.images.add_image(in_file)

        # Fügt einen Rahmen mit der entsprechenden Höhe und Breite des Bildes hinzu
        pf = sld.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 150, image.width, image.height, image)

        # Wendet einige Formatierungen auf die PictureFrameEx an
        pf.line_format.fill_format.fill_type = slides.FillType.SOLID
        pf.line_format.fill_format.solid_fill_color.color = draw.Color.blue
        pf.line_format.width = 20
        pf.rotation = 45

        # Schreibt die PPTX-Datei auf die Festplatte
        pres.save("RectPicFrameFormat_out.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" %}} 

Bilderrahmen ermöglichen es Ihnen, schnell Präsentationsfolien basierend auf Bildern zu erstellen. Wenn Sie den Bilderrahmen mit den Speichermöglichkeiten von Aspose.Slides kombinieren, können Sie Eingabe-/Ausgabeoperationen manipulieren, um Bilder von einem Format in ein anderes zu konvertieren. Möglicherweise möchten Sie sich diese Seiten ansehen: konvertieren [Bild zu JPG](https://products.aspose.com/slides/python-net/conversion/image-to-jpg/); konvertieren [JPG zu Bild](https://products.aspose.com/slides/python-net/conversion/jpg-to-image/); konvertieren [JPG zu PNG](https://products.aspose.com/slides/python-net/conversion/jpg-to-png/), konvertieren [PNG zu JPG](https://products.aspose.com/slides/python-net/conversion/png-to-jpg/); konvertieren [PNG zu SVG](https://products.aspose.com/slides/python-net/conversion/png-to-svg/), konvertieren [SVG zu PNG](https://products.aspose.com/slides/python-net/conversion/svg-to-png/).

{{% /alert %}}

## **Bilderrahmen mit relativem Maßstab erstellen**

Durch Ändern des relativen Maßstabs eines Bildes können Sie einen komplizierteren Bilderrahmen erstellen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
2. Holen Sie sich die Referenz einer Folie über ihren Index.
3. Fügen Sie ein Bild zur Präsentationsbildkollektion hinzu.
4. Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage/) Objekt, indem Sie ein Bild zur [IImageskollektion](https://reference.aspose.com/slides/python-net/aspose.slides/iimagecollection/) hinzufügen, die mit dem Präsentationsobjekt verbunden ist, das verwendet werden soll, um die Form auszufüllen.
5. Geben Sie die relative Breite und Höhe des Bildes im Bilderrahmen an.
6. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser Python-Code zeigt Ihnen, wie Sie einen Bilderrahmen mit relativem Maßstab erstellen:

```py
import aspose.slides as slides

# Instanziiert die Presentation-Klasse, die eine PPTX-Datei repräsentiert
with slides.Presentation() as presentation:
    # Lädt das Bild, das zur Präsentationsbildkollektion hinzugefügt werden soll
    with open("img.jpeg", "rb") as in_file:
        image = presentation.images.add_image(in_file)

        # Fügt einen Bilderrahmen zur Folie hinzu
        pf = presentation.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)

        # Setzt die relative Maßstabshöhe und -breite
        pf.relative_scale_height = 0.8
        pf.relative_scale_width = 1.35

        # Speichert die Präsentation
        presentation.save("Adding Picture Frame with Relative Scale_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Bild aus dem Bilderrahmen extrahieren**

Sie können Bilder aus [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) Objekten extrahieren und sie in PNG, JPG und anderen Formaten speichern. Das folgende Codebeispiel demonstriert, wie Sie ein Bild aus dem Dokument "sample.pptx" extrahieren und im PNG-Format speichern.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    first_slide = presentation.slides[0]
    first_shape = first_slide.shapes[0]

    if isinstance(first_shape, slides.PictureFrame):
        image = first_shape.picture_format.picture.image.image
        image.save("slide_1_shape_1.png", slides.ImageFormat.PNG)
```

## **Transparenz eines Bildes abrufen**

Aspose.Slides ermöglicht es Ihnen, die Transparenz eines Bildes abzurufen. Dieser Python-Code demonstriert die Operation:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    pictureFrame = presentation.slides[0].shapes[0]
    imageTransform = pictureFrame.picture_format.picture.image_transform
    for effect in imageTransform:
        if type(effect) is slides.AlphaModulateFixed:
            transparencyValue = 100 - effect.amount
            print("Bildtransparenz: " + str(transparencyValue))
```

## **Formatierung des Bilderrahmens**

Aspose.Slides bietet viele Formatierungsoptionen, die auf einen Bilderrahmen angewendet werden können. Mit diesen Optionen können Sie einen Bilderrahmen ändern, damit er bestimmten Anforderungen entspricht.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/) Klasse.
2. Holen Sie sich die Referenz einer Folie über ihren Index. 
3. Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage) Objekt, indem Sie ein Bild zur [IImageskollektion](https://reference.aspose.com/slides/python-net/aspose.slides/iimagecollection/) hinzufügen, die mit dem Präsentationsobjekt verbunden ist, das verwendet werden soll, um die Form auszufüllen.
4. Geben Sie die Breite und Höhe des Bildes an.
5. Erstellen Sie einen `PictureFrame` basierend auf der Breite und Höhe des Bildes über die [AddPictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/) Methode, die vom [IShapes](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection) Objekt bereitgestellt wird, das mit der verwiesenen Folie verbunden ist.
6. Fügen Sie den Bilderrahmen (der das Bild enthält) zur Folie hinzu.
7. Setzen Sie die Linienfarbe des Bilderrahmens.
8. Setzen Sie die Linienbreite des Bilderrahmens.
9. Drehen Sie den Bilderrahmen, indem Sie ihm entweder einen positiven oder negativen Wert geben.
   * Ein positiver Wert dreht das Bild im Uhrzeigersinn. 
   * Ein negativer Wert dreht das Bild gegen den Uhrzeigersinn.
10. Fügen Sie den Bilderrahmen (der das Bild enthält) zur Folie hinzu.
11. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser Python-Code demonstriert den Prozess der Bilderrahmenformatierung:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanziiert die Presentation-Klasse, die eine PPTX-Datei repräsentiert
with slides.Presentation() as pres:
    # Holt die erste Folie
    sld = pres.slides[0]

    with open("img.jpeg", "rb") as in_file:
        imgx = pres.images.add_image(in_file)

         # Fügt einen Bilderrahmen mit der entsprechenden Höhe und Breite des Bildes hinzu
        pf = sld.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 150, imgx.width, imgx.height, imgx)

        # Wendet einige Formatierungen auf PictureFrameEx an
        pf.line_format.fill_format.fill_type = slides.FillType.SOLID
        pf.line_format.fill_format.solid_fill_color.color = draw.Color.blue
        pf.line_format.width = 20
        pf.rotation = 45

    # Schreibt die PPTX-Datei auf die Festplatte
    pres.save("RectPicFrameFormat_out.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Tipp" color="primary" %}}

Aspose hat kürzlich einen [kostenlosen Collage Maker](https://products.aspose.app/slides/collage) entwickelt. Wenn Sie jemals [JPG/JPEG](https://products.aspose.app/slides/collage/jpg) oder PNG-Bilder zusammenführen oder [Raster aus Fotos erstellen](https://products.aspose.app/slides/collage/photo-grid) müssen, können Sie diesen Service nutzen. 

{{% /alert %}}

## **Bild als Link hinzufügen**

Um große Präsentationsgrößen zu vermeiden, können Sie Bilder (oder Videos) über Links hinzufügen, anstatt die Dateien direkt in die Präsentationen einzubetten. Dieser Python-Code zeigt Ihnen, wie Sie ein Bild und ein Video in einen Platzhalter einfügen:

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    shapesToRemove = []

    for autoShape in presentation.slides[0].shapes:
        if autoShape.placeholder is None:
            continue
        
        if autoShape.placeholder.type == slides.PlaceholderType.PICTURE:
            pictureFrame = presentation.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE,
                    autoShape.x, autoShape.y, autoShape.width, autoShape.height, None)

            pictureFrame.picture_format.picture.link_path_long = \
                "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg"

            shapesToRemove.append(autoShape)

        elif autoShape.placeholder.type == slides.PlaceholderType.MEDIA:
            videoFrame = presentation.slides[0].shapes.add_video_frame(
                autoShape.X, autoShape.Y, autoShape.width, autoShape.height, "")

            videoFrame.picture_format.picture.link_path_long = \
                "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg"

            videoFrame.link_path_long = "https://youtu.be/t_1LYZ102RA"
            shapesToRemove.append(autoShape)
        
    

    for shape in shapesToRemove:
        presentation.slides[0].shapes.remove(shape)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Bild zuschneiden**

Dieser Python-Code zeigt Ihnen, wie Sie ein vorhandenes Bild auf einer Folie zuschneiden:

``` py
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Erstellt ein neues Bildobjekt
    newImage = presentation.images.add_image(slides.Images.from_file(imagePath))

    # Fügt einen Bilderrahmen zu einer Folie hinzu
    picFrame = presentation.slides[0].shapes.add_picture_frame(
        slides.ShapeType.RECTANGLE, 100, 100, 420, 250, newImage)

    # Schneidet das Bild zu (Prozentsatzwerte)
    picFrame.picture_format.crop_left = 23.6
    picFrame.picture_format.crop_right = 21.5
    picFrame.picture_format.crop_top = 3
    picFrame.picture_format.crop_bottom = 31

    # Speichert das Ergebnis
    presentation.save(outPptxFile, slides.export.SaveFormat.PPTX)

```

## Zuschnitte der Bilder im Rahmen löschen

Wenn Sie die zugeschnittenen Bereiche eines Bildes, das sich in einem Rahmen befindet, löschen möchten, können Sie die Methode [delete_picture_cropped_areas](https://reference.aspose.com/slides/python-net/aspose.slides/ipicturefillformat/) verwenden. Diese Methode gibt das zugeschnittene Bild oder das ursprüngliche Bild zurück, wenn das Zuschneiden nicht erforderlich ist.

Dieser Python-Code demonstriert die Operation:

```python
import aspose.slides as slides

with slides.Presentation(path + "PictureFrameCrop.pptx") as pres:
    slide = pres.slides[0]

    # Holt den Bilderrahmen von der ersten Folie
    picture_frame = slides.shape[0]

    # Löscht die zugeschnittenen Bereiche des Bildes im Bilderrahmen und gibt das zugeschnittene Bild zurück
    cropped_image = picture_frame.picture_format.delete_picture_cropped_areas()

    # Speichert das Ergebnis
    pres.save(path + "PictureFrameDeleteCroppedAreas.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="HINWEIS" color="warning" %}} 

Die Methode delete_picture_cropped_areas fügt das zugeschnittene Bild zur Präsentationsbildkollektion hinzu. Wenn das Bild nur im verarbeiteten [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) verwendet wird, kann diese Einrichtung die Präsentationsgröße reduzieren. Andernfalls wird die Anzahl der Bilder in der resultierenden Präsentation erhöht.

Diese Methode konvertiert WMF/EMF-Metadateien in ein Raster-PNG-Bild im Zuschneidevorgang. 

{{% /alert %}}

## **Seitenverhältnis sperren**

Wenn Sie möchten, dass eine Form, die ein Bild enthält, ihr Seitenverhältnis auch nach Änderung der Bildabmessungen beibehält, können Sie die Eigenschaft *aspect_ratio_locked* verwenden, um die Einstellung *Seitenverhältnis sperren* festzulegen. 

Dieser Python-Code zeigt Ihnen, wie Sie das Seitenverhältnis einer Form sperren: 

```python
from aspose.slides import SlideLayoutType, Presentation, ShapeType
from aspose.pydrawing import Image

with Presentation("pres.pptx") as pres:
    layout = pres.layout_slides.get_by_type(SlideLayoutType.CUSTOM)
    emptySlide = pres.slides.add_empty_slide(layout)
    image = Image.from_file("image.png")
    presImage = pres.images.add_image(image)

    pictureFrame = emptySlide.shapes.add_picture_frame(ShapeType.RECTANGLE, 50, 150, presImage.width, presImage.height, presImage)

    # Setzt die Form, um das Seitenverhältnis beim Ändern der Größe beizubehalten
    pictureFrame.picture_frame_lock.aspect_ratio_locked = True
```

{{% alert title="HINWEIS" color="warning" %}} 

Diese Einstellung *Seitenverhältnis sperren* bewahrt nur das Seitenverhältnis der Form und nicht das Bild, das sie enthält.

{{% /alert %}}

## **Stretchen der Offsets verwenden**

Mithilfe der Eigenschaften `StretchOffsetLeft`, `StretchOffsetTop`, `StretchOffsetRight` und `StretchOffsetBottom` aus dem [IPictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/ipicturefillformat/) Interface und der [PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/) Klasse können Sie ein Füllrechteck spezifizieren. 

Wenn das Stretchen für ein Bild angegeben wird, wird ein Quellrechteck skaliert, um in das angegebene Füllrechteck zu passen. Jede Kante des Füllrechtecks wird durch einen prozentualen Versatz von der entsprechenden Kante des Begrenzungsrahmens der Form definiert. Ein positiver Prozentsatz spezifiziert ein Einrücken, während ein negativer Prozentsatz ein Herausziehen angibt.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/) Klasse.
2. Holen Sie sich die Referenz einer Folie über ihren Index.
3. Fügen Sie eine Rechteck-`AutoShape` hinzu. 
4. Erstellen Sie ein Bild.
5. Setzen Sie den Fülltyp der Form.
6. Setzen Sie den Bildfüllmodus der Form.
7. Fügen Sie ein Bild hinzu, um die Form zu füllen.
8. Geben Sie die Bildversätze von der entsprechenden Kante des Begrenzungsrahmens der Form an.
9. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser Python-Code demonstriert einen Prozess, in dem die StretchOff-Eigenschaft verwendet wird:

```py
import aspose.slides as slides

# Instanziiert die Presentation-Klasse, die eine PPTX-Datei repräsentiert
with slides.Presentation() as pres:

    # Holt die erste Folie
    slide = pres.slides[0]

    # Instanziiert die ImageEx-Klasse
    with open("img.jpeg", "rb") as in_file:
        imgx = pres.images.add_image(in_file)

        # Fügt einen Bilderrahmen mit der entsprechenden Höhe und Breite des Bildes hinzu
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 300, 300)

        # Setzt den Fülltyp der Form
        shape.fill_format.fill_type = slides.FillType.PICTURE

        # Setzt den Bildfüllmodus der Form
        shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

        # Setzt das Bild zur Füllung der Form
        shape.fill_format.picture_fill_format.picture.image = imgx

        # Gibt die Bildversätze von der entsprechenden Kante des Begrenzungsrahmens der Form an
        shape.fill_format.picture_fill_format.stretch_offset_left = 25
        shape.fill_format.picture_fill_format.stretch_offset_right = 25
        shape.fill_format.picture_fill_format.stretch_offset_top = -20
        shape.fill_format.picture_fill_format.stretch_offset_bottom = -10
    
    # Schreibt die PPTX-Datei auf die Festplatte
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", slides.export.SaveFormat.PPTX)
```