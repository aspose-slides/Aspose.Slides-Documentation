---
title: OleObjektum
type: docs
weight: 210
url: /hu/python-net/examples/elements/ole-object/
keywords:
- OLE objektum
- OLE objektum hozzáadása
- OLE objektum elérése
- OLE objektum eltávolítása
- OLE objektum frissítése
- kódrészletek
- PowerPoint
- OpenDocument
- bemutató
- Python
- Aspose.Slides
description: "OLE objektumok kezelése Pythonban az Aspose.Slides segítségével: beágyazott fájlok beszúrása vagy frissítése, ikonok vagy hivatkozások beállítása, tartalom kinyerése, viselkedés szabályozása PPT, PPTX és ODP esetén."
---
Bemutatja egy fájl beágyazását OLE-objektumként, valamint az adatainak frissítését a **Aspose.Slides for Python via .NET** használatával.

## **OLE-objektum hozzáadása**

Ágyazzon be egy PDF-fájlt a prezentációba.

```py
def add_ole_object():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # PDF-adatok betöltése a beágyazáshoz.
        with open("doc.pdf", "rb") as file_stream:
            data_info = slides.dom.ole.OleEmbeddedDataInfo(file_stream.read(), "pdf")

        # OLE-objektum keret hozzáadása a diára.
        ole_frame = slide.shapes.add_ole_object_frame(20, 20, 50, 50, data_info)

        presentation.save("ole_frame.pptx", slides.export.SaveFormat.PPTX)
```

## **OLE-objektum elérése**

Hozza vissza az első OLE-objektum keretet egy dián.

```py
def access_ole_object():
    with slides.Presentation("ole_frame.pptx") as presentation:
        slide = presentation.slides[0]

        # Az első OLE objektum keret lekérése a dián.
        first_ole = next(shape for shape in slide.shapes if isinstance(shape, slides.OleObjectFrame))
```

## **OLE-objektum eltávolítása**

Törölje a beágyazott OLE-objektumot a diáról.

```py
def remove_ole_object():
    with slides.Presentation("ole_frame.pptx") as presentation:
        slide = presentation.slides[0]

        # Feltételezve, hogy az első alakzat egy OleObjectFrame objektum.
        ole_frame = slide.shapes[0]

        slide.shapes.remove(ole_frame)

        presentation.save("ole_frame_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **OLE-objektum adatainak frissítése**

Cserélje ki a meglévő OLE-objektumba beágyazott adatokat.

```py
def update_ole_object_data():
    with slides.Presentation("ole_frame.pptx") as presentation:
        slide = presentation.slides[0]

        # Feltételezve, hogy az első alakzat egy OleObjectFrame objektum.
        ole_frame = slide.shapes[0]

        with open("Picture.png", "rb") as picture_stream:
            new_data = slides.dom.ole.OleEmbeddedDataInfo(picture_stream.read(), "png")

        # Az OLE objektum frissítése az új beágyazott adatokkal.
        ole_frame.set_embedded_data(new_data)

        presentation.save("ole_frame_updated.pptx", slides.export.SaveFormat.PPTX)
```