---
title: OleObject
type: docs
weight: 210
url: /nl/python-net/examples/elements/ole-object/
keywords:
- OLE-object
- OLE-object toevoegen
- toegang tot OLE-object
- OLE-object verwijderen
- OLE-object bijwerken
- codevoorbeelden
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Werk met OLE-objecten in Python met Aspose.Slides: voeg ingesloten bestanden toe of werk ze bij, stel pictogrammen of koppelingen in, extraheer inhoud, beheer het gedrag voor PPT, PPTX en ODP."
---
Toont het insluiten van een bestand als OLE-object en het bijwerken van de gegevens met behulp van **Aspose.Slides for Python via .NET**.

## **Een OLE-object toevoegen**

Een PDF-bestand insluiten in de presentatie.

```py
def add_ole_object():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Laad PDF-gegevens om in te sluiten.
        with open("doc.pdf", "rb") as file_stream:
            data_info = slides.dom.ole.OleEmbeddedDataInfo(file_stream.read(), "pdf")

        # Voeg een OLE-objectframe toe aan de dia.
        ole_frame = slide.shapes.add_ole_object_frame(20, 20, 50, 50, data_info)

        presentation.save("ole_frame.pptx", slides.export.SaveFormat.PPTX)
```

## **Toegang tot een OLE-object**

Haal het eerste OLE-objectframe op een dia op.

```py
def access_ole_object():
    with slides.Presentation("ole_frame.pptx") as presentation:
        slide = presentation.slides[0]

        # Haal het eerste OLE-objectframe op de dia op.
        first_ole = next(shape for shape in slide.shapes if isinstance(shape, slides.OleObjectFrame))
```

## **Een OLE-object verwijderen**

Verwijder een ingebed OLE-object van de dia.

```py
def remove_ole_object():
    with slides.Presentation("ole_frame.pptx") as presentation:
        slide = presentation.slides[0]

        # Aannemende dat de eerste vorm een OleObjectFrame-object is.
        ole_frame = slide.shapes[0]

        slide.shapes.remove(ole_frame)

        presentation.save("ole_frame_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **OLE-objectgegevens bijwerken**

Vervang de gegevens die zijn ingebed in een bestaand OLE-object.

```py
def update_ole_object_data():
    with slides.Presentation("ole_frame.pptx") as presentation:
        slide = presentation.slides[0]

        # Aannemende dat de eerste vorm een OleObjectFrame-object is.
        ole_frame = slide.shapes[0]

        with open("Picture.png", "rb") as picture_stream:
            new_data = slides.dom.ole.OleEmbeddedDataInfo(picture_stream.read(), "png")

        # Werk het OLE-object bij met de nieuwe ingesloten gegevens.
        ole_frame.set_embedded_data(new_data)

        presentation.save("ole_frame_updated.pptx", slides.export.SaveFormat.PPTX)
```