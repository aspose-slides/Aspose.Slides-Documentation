---
title: Bild
type: docs
weight: 50
url: /de/python-net/examples/elements/picture/
keywords:
- Bild
- Bildrahmen
- Bild hinzufügen
- Bild abrufen
- Codebeispiele
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Arbeiten Sie mit Bildern in Python mit Aspose.Slides: Einfügen, Ersetzen, Zuschneiden, Komprimieren, Transparenz und Effekte anpassen, Formen füllen und für PPT, PPTX und ODP exportieren."
---
Zeigt, wie Bilder aus im Speicher befindlichen Bildern mit **Aspose.Slides for Python via .NET** eingefügt und abgerufen werden. Die nachfolgenden Beispiele erstellen ein Bild im Speicher, platzieren es auf einer Folie und rufen es anschließend ab.

## **Bild hinzufügen**

```py
def add_picture():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Bild aus einer Datei laden.
        with open("image.png", "rb") as image_stream:
            # Bild zu den Präsentationsressourcen hinzufügen.
            image = presentation.images.add_image(image_stream)

        # Bildrahmen einfügen, der das Bild auf der ersten Folie zeigt.
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        presentation.save("picture.pptx", slides.export.SaveFormat.PPTX)
```

## **Auf ein Bild zugreifen**

```py
def access_picture():
    with slides.Presentation("picture.pptx") as presentation:
        slide = presentation.slides[0]

        # Greife auf den ersten Bildrahmen auf der Folie zu.
        picture_frame = next(shape for shape in slide.shapes if isinstance(shape, slides.PictureFrame))
```