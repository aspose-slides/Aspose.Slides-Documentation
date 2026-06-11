---
title: OleObjekt
type: docs
weight: 210
url: /sv/python-net/examples/elements/ole-object/
keywords:
- OLE-objekt
- lägga till OLE-objekt
- åtkomst till OLE-objekt
- ta bort OLE-objekt
- uppdatera OLE-objekt
- kodexempel
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Arbeta med OLE-objekt i Python med Aspose.Slides: infoga eller uppdatera inbäddade filer, ange ikoner eller länkar, extrahera innehåll, kontrollera beteende för PPT, PPTX och ODP."
---
Visar hur man bäddar in en fil som ett OLE-objekt och uppdaterar dess data med hjälp av **Aspose.Slides for Python via .NET**.

## **Lägg till ett OLE-objekt**

Bädda in en PDF-fil i presentationen.

```py
def add_ole_object():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Läs in PDF-data för inbäddning.
        with open("doc.pdf", "rb") as file_stream:
            data_info = slides.dom.ole.OleEmbeddedDataInfo(file_stream.read(), "pdf")

        # Lägg till en OLE-objektram på bilden.
        ole_frame = slide.shapes.add_ole_object_frame(20, 20, 50, 50, data_info)

        presentation.save("ole_frame.pptx", slides.export.SaveFormat.PPTX)
```

## **Åtkomst till ett OLE-objekt**

Hämta den första OLE-objekt‑ramen på en bild.

```py
def access_ole_object():
    with slides.Presentation("ole_frame.pptx") as presentation:
        slide = presentation.slides[0]

        # Hämta den första OLE-objektramen på bilden.
        first_ole = next(shape for shape in slide.shapes if isinstance(shape, slides.OleObjectFrame))
```

## **Ta bort ett OLE-objekt**

Ta bort ett inbäddat OLE-objekt från bilden.

```py
def remove_ole_object():
    with slides.Presentation("ole_frame.pptx") as presentation:
        slide = presentation.slides[0]

        # Antar att den första formen är ett OleObjectFrame-objekt.
        ole_frame = slide.shapes[0]

        slide.shapes.remove(ole_frame)

        presentation.save("ole_frame_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Uppdatera OLE-objektdata**

Ersätt data som är inbäddad i ett befintligt OLE-objekt.

```py
def update_ole_object_data():
    with slides.Presentation("ole_frame.pptx") as presentation:
        slide = presentation.slides[0]

        # Antar att den första formen är ett OleObjectFrame-objekt.
        ole_frame = slide.shapes[0]

        with open("Picture.png", "rb") as picture_stream:
            new_data = slides.dom.ole.OleEmbeddedDataInfo(picture_stream.read(), "png")

        # Uppdatera OLE-objektet med den nya inbäddade datan.
        ole_frame.set_embedded_data(new_data)

        presentation.save("ole_frame_updated.pptx", slides.export.SaveFormat.PPTX)
```