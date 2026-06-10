---
title: Kép
type: docs
weight: 50
url: /hu/python-net/examples/elements/picture/
keywords:
- kép
- képkeret
- kép hozzáadása
- kép elérése
- kódpéldák
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Képek kezelése Pythonban az Aspose.Slides használatával: beszúrás, csere, vágás, tömörítés, átlátszóság és effektusok beállítása, alakzatok kitöltése, valamint exportálás PPT, PPTX és ODP formátumokba."
---
Bemutatja, hogyan lehet képeket beszúrni és elérni memóriában tárolt képekből a **Aspose.Slides for Python via .NET** használatával. Az alábbi példák memóriában hoznak létre egy képet, elhelyezik egy dián, majd lekérdezik azt.

## **Kép hozzáadása**

Ez a kód egy képet tölt be egy fájlból, és képkeretként helyezi el az első dián.

```py
def add_picture():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Töltsön be egy képet egy fájlból.
        with open("image.png", "rb") as image_stream:
            # Adja hozzá a képet a prezentáció erőforrásaihoz.
            image = presentation.images.add_image(image_stream)

        # Szúrjon be egy képkeretet, amely megjeleníti a képet az első dián.
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        presentation.save("picture.pptx", slides.export.SaveFormat.PPTX)
```

## **Kép elérése**

Ez a példa biztosítja, hogy a dia tartalmazzon képkeretet, és ezután eléri az első megtalált képkeretet.

```py
def access_picture():
    with slides.Presentation("picture.pptx") as presentation:
        slide = presentation.slides[0]

        # Hozzáfér az első képkerethez a dián.
        picture_frame = next(shape for shape in slide.shapes if isinstance(shape, slides.PictureFrame))
```