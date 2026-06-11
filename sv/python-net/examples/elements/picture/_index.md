---
title: Bild
type: docs
weight: 50
url: /sv/python-net/examples/elements/picture/
keywords:
- bild
- bildram
- lägg till bild
- åtkomst bild
- kodexempel
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Arbeta med bilder i Python med Aspose.Slides: infoga, ersätta, beskära, komprimera, justera transparens och effekter, fylla former och exportera till PPT, PPTX och ODP."
---
Visar hur man infogar och får åtkomst till bilder från minneslagrade bilder med **Aspose.Slides for Python via .NET**. Exemplen nedan skapar en bild i minnet, placerar den på en bild och hämtar den sedan.

## **Lägg till en bild**

Den här koden läser in en bild från en fil och infogar den som en bildram på den första bilden.

```py
def add_picture():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Läs in en bild från en fil.
        with open("image.png", "rb") as image_stream:
            # Lägg till bilden i presentationens resurser.
            image = presentation.images.add_image(image_stream)

        # Infoga en bildram som visar bilden på den första bilden.
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        presentation.save("picture.pptx", slides.export.SaveFormat.PPTX)
```

## **Åtkomst till en bild**

Det här exemplet säkerställer att en bild innehåller en bildram och hämtar sedan den första som den hittar.

```py
def access_picture():
    with slides.Presentation("picture.pptx") as presentation:
        slide = presentation.slides[0]

        # Åtkomst till den första bildramen på bilden.
        picture_frame = next(shape for shape in slide.shapes if isinstance(shape, slides.PictureFrame))
```