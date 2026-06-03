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
- zugeschnittener Bereich
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
description: "Fügen Sie Bildrahmen zu PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Python via .NET hinzu. Optimieren Sie Ihren Arbeitsablauf und verbessern Sie das Design der Folien."
---
## **Einführung**

Bildrahmen in Aspose.Slides für Python ermöglichen das Platzieren und Verwalten von Raster‑ und Vektorbildern als native Folienformen. Sie können Bilder aus Dateien oder Streams einfügen, sie mit genauen Koordinaten positionieren und skalieren, Drehungen anwenden, Transparenz festlegen und die Z‑Reihenfolge zusammen mit anderen Formen steuern. Die API unterstützt außerdem das Zuschneiden, das Beibehalten von Seitenverhältnissen, das Setzen von Rahmen und Effekten sowie das Ersetzen des zugrunde liegenden Bildes, ohne das Layout neu zu erstellen. Da Bildrahmen wie reguläre Formen funktionieren, können Sie Animationen, Hyperlinks und Alternativtexte hinzufügen, sodass sich visuell reiche, barrierefreie Präsentationen einfach erstellen lassen.

## **Bildrahmen erstellen**

Dieser Abschnitt zeigt, wie Sie ein Bild in eine Folie einfügen, indem Sie einen [PictureFrame](https://reference.aspose.com/slides/de/python-net/aspose.slides/pictureframe/) mit Aspose.Slides für Python erstellen. Sie lernen, wie Sie das Bild laden, exakt auf der Folie platzieren und Größe sowie Formatierung steuern.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/)-Klasse.
2. Holen Sie eine Folie über ihren Index.
3. Erstellen Sie ein [PPImage](https://reference.aspose.com/slides/de/python-net/aspose.slides/ppimage/), indem Sie das Bild zur [ImageCollection](https://reference.aspose.com/slides/de/python-net/aspose.slides/imagecollection/) der Präsentation hinzufügen. Dieses Bild wird zum Füllen der Form verwendet.
4. Geben Sie die Breite und Höhe des Rahmens an.
5. Erzeugen Sie mit der Methode [add_picture_frame](https://reference.aspose.com/slides/de/python-net/aspose.slides/shapecollection/add_picture_frame/) einen [PictureFrame](https://reference.aspose.com/slides/de/python-net/aspose.slides/pictureframe/) dieser Größe.
6. Speichern Sie die Präsentation als PPTX‑Datei.

Der folgende Python‑Code zeigt, wie ein Bildrahmen erstellt wird:

```py
import aspose.slides as slides

# Instanziieren Sie die Presentation‑Klasse, um eine PPTX‑Datei darzustellen.
with slides.Presentation() as presentation:
    # Holen Sie die erste Folie.
    slide = presentation.slides[0]

    # Bild zur Präsentation hinzufügen.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # Bildrahmen mit der Größe des Bildes hinzufügen.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        # Präsentation als PPTX speichern.
        presentation.save("picture_frame.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" %}}
Bildrahmen ermöglichen das schnelle Erstellen von Präsentationsfolien aus Bildern. Kombinieren Sie Bildrahmen mit den Speicheroptionen von Aspose.Slides, können Sie I/O‑Vorgänge steuern, um Bilder von einem Format in ein anderes zu konvertieren. Sie könnten folgende Seiten interessieren: Bild nach JPG konvertieren [image to JPG](https://products.aspose.com/slides/de/python-net/conversion/image-to-jpg/); JPG nach Bild konvertieren [JPG to image](https://products.aspose.com/slides/de/python-net/conversion/jpg-to-image/); JPG nach PNG konvertieren [JPG to PNG](https://products.aspose.com/slides/de/python-net/conversion/jpg-to-png/); PNG nach JPG konvertieren [PNG to JPG](https://products.aspose.com/slides/de/python-net/conversion/png-to-jpg/); PNG nach SVG konvertieren [PNG to SVG](https://products.aspose.com/slides/de/python-net/conversion/png-to-svg/); SVG nach PNG konvertieren [SVG to PNG](https://products.aspose.com/slides/de/python-net/conversion/svg-to-png/).
{{% /alert %}}

## **Bildrahmen mit relativer Skalierung erstellen**

Dieser Abschnitt demonstriert das Platzieren eines Bildes mit fester Größe und anschließend das prozentuale Skalieren von Breite und Höhe unabhängig voneinander. Da die Prozentsätze unterschiedlich sein können, kann das Seitenverhältnis ändern. Die Skalierung erfolgt relativ zu den Originalabmessungen des Bildes.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/)-Klasse.
2. Holen Sie eine Folie über ihren Index.
3. Erstellen Sie ein [PPImage](https://reference.aspose.com/slides/de/python-net/aspose.slides/ppimage/), indem Sie das Bild zur [ImageCollection](https://reference.aspose.com/slides/de/python-net/aspose.slides/imagecollection/) der Präsentation hinzufügen.
4. Fügen Sie der Folie einen [PictureFrame](https://reference.aspose.com/slides/de/python-net/aspose.slides/pictureframe/) hinzu.
5. Setzen Sie die relative Breite und Höhe des Bildrahmens.
6. Speichern Sie die Präsentation als PPTX‑Datei.

Der folgende Python‑Code zeigt, wie ein Bildrahmen mit relativer Skalierung erstellt wird:

```py
import aspose.slides as slides

# Instanziieren Sie die Presentation‑Klasse, um eine PPTX‑Datei darzustellen.
with slides.Presentation() as presentation:
    # Holen Sie die erste Folie.
    slide = presentation.slides[0]

    # Bild zur Bildsammlung der Präsentation hinzufügen.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # Bildrahmen zur Folie hinzufügen.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)

        # Relative Skalierungsbreite und -höhe festlegen.
        picture_frame.relative_scale_height = 0.8
        picture_frame.relative_scale_width = 1.35

        # Präsentation speichern.
        presentation.save("relative_scaling.pptx", slides.export.SaveFormat.PPTX)
```

## **Rasterbilder aus Bildrahmen extrahieren**

Sie können Rasterbilder aus [PictureFrame](https://reference.aspose.com/slides/de/python-net/aspose.slides/pictureframe/)-Objekten extrahieren und sie im PNG‑, JPG‑ und anderen Formaten speichern. Das nachfolgende Beispiel demonstriert, wie ein Bild aus der Datei „sample.pptx“ extrahiert und im PNG‑Format gespeichert wird.

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

Enthält eine Präsentation SVG‑Grafiken, die in [PictureFrame](https://reference.aspose.com/slides/de/python-net/aspose.slides/pictureframe/)-Formen platziert sind, ermöglicht Aspose.Slides für Python via .NET das Abrufen der ursprünglichen Vektorbilder mit voller Treue. Durch Durchlaufen der Formsammlung der Folie können Sie jede [PictureFrame](https://reference.aspose.com/slides/de/python-net/aspose.slides/pictureframe/) identifizieren, prüfen, ob das zugrunde liegende [PPImage](https://reference.aspose.com/slides/de/python-net/aspose.slides/ppimage/) SVG‑Inhalt enthält, und dann dieses Bild im nativen SVG‑Format auf Datenträger oder Stream speichern.

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

## **Bildtransparenz ermitteln**

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
Alle Effekte, die auf Bilder angewendet werden, finden Sie in [aspose.slides.effects](https://reference.aspose.com/slides/de/python-net/aspose.slides.effects/).
{{% /alert %}}

## **Bildrahmen‑Formatierung**

Aspose.Slides bietet zahlreiche Formatierungsoptionen, die Sie auf einen Bildrahmen anwenden können. Mit diesen Optionen können Sie einen Bildrahmen an spezifische Anforderungen anpassen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/)-Klasse.
2. Holen Sie eine Folie über ihren Index.
3. Erstellen Sie ein [PPImage](https://reference.aspose.com/slides/de/python-net/aspose.slides/ppimage/), indem Sie das Bild zur [ImageCollection](https://reference.aspose.com/slides/de/python-net/aspose.slides/imagecollection/) der Präsentation hinzufügen. Dieses Bild wird zum Füllen der Form verwendet.
4. Geben Sie die Breite und Höhe des Rahmens an.
5. Erzeugen Sie mit der Methode [add_picture_frame](https://reference.aspose.com/slides/de/python-net/aspose.slides/shapecollection/add_picture_frame/) einen [PictureFrame](https://reference.aspose.com/slides/de/python-net/aspose.slides/pictureframe/) dieser Größe.
6. Setzen Sie die Linienfarbe des Bildrahmens.
7. Setzen Sie die Linienbreite des Bildrahmens.
8. Drehen Sie