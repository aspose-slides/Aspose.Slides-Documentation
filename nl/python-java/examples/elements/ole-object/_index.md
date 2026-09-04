---
title: OLE-object
type: docs
weight: 210
url: /nl/python-java/examples/elements/ole-object/
keywords:
- codevoorbeeld
- OLE-object
- OLE-object toevoegen
- OLE-object benaderen
- OLE-object verwijderen
- OLE-object bijwerken
- PowerPoint
- OpenDocument
- presentatie
- Python
- Java
- Aspose.Slides
description: "Gebruik Aspose.Slides voor Python via Java om OLE-objecten toe te voegen, te benaderen, te verwijderen en bij te werken in PowerPoint- en OpenDocument-presentaties."
---
Dit artikel toont hoe u een bestand kunt insluiten als OLE-object en de gegevens ervan kunt bijwerken met **Aspose.Slides for Python via Java**.

Installeer het pakket zoals beschreven in [Installatie](/slides/nl/python-java/installation/). Elk voorbeeld importeert `asposeslides` voordat de JVM wordt gestart, en importeert daarna de API zodra de JVM draait.

## **OLE-object toevoegen**

Sluit een PDF-bestand in in de presentatie.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.nio.file import Files, Paths
from asposeslides.api import OleEmbeddedDataInfo, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    pdf_data = Files.readAllBytes(Paths.get("doc.pdf"))
    data_info = OleEmbeddedDataInfo(pdf_data, "pdf")
    ole_frame = slide.getShapes().addOleObjectFrame(20, 20, 50, 50, data_info)
finally:
    presentation.dispose()
```

## **OLE-object benaderen**

Haal het eerste OLE-objectframe op een dia op.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.nio.file import Files, Paths
from asposeslides.api import OleEmbeddedDataInfo, OleObjectFrame, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    pdf_data = Files.readAllBytes(Paths.get("doc.pdf"))
    data_info = OleEmbeddedDataInfo(pdf_data, "pdf")
    slide.getShapes().addOleObjectFrame(20, 20, 50, 50, data_info)

    first_ole_frame = None
    for shape in slide.getShapes():
        if isinstance(shape, OleObjectFrame):
            first_ole_frame = shape
            break

    if first_ole_frame is None:
        print("The slide contains no OLE object frames.")
finally:
    presentation.dispose()
```

## **OLE-object verwijderen**

Verwijder een ingesloten OLE-object van de dia.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.nio.file import Files, Paths
from asposeslides.api import OleEmbeddedDataInfo, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    pdf_data = Files.readAllBytes(Paths.get("doc.pdf"))
    data_info = OleEmbeddedDataInfo(pdf_data, "pdf")
    ole_frame = slide.getShapes().addOleObjectFrame(20, 20, 50, 50, data_info)

    slide.getShapes().remove(ole_frame)
finally:
    presentation.dispose()
```

## **OLE-objectgegevens bijwerken**

Vervang de gegevens die ingebed zijn in een bestaand OLE-object.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.nio.file import Files, Paths
from asposeslides.api import OleEmbeddedDataInfo, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    pdf_data = Files.readAllBytes(Paths.get("doc.pdf"))
    data_info = OleEmbeddedDataInfo(pdf_data, "pdf")
    ole_frame = slide.getShapes().addOleObjectFrame(20, 20, 50, 50, data_info)

    new_data = Files.readAllBytes(Paths.get("Picture.png"))
    new_data_info = OleEmbeddedDataInfo(new_data, "png")
    ole_frame.setEmbeddedData(new_data_info)
finally:
    presentation.dispose()
```