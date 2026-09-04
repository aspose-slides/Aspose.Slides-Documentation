---
title: OLE objekt
type: docs
weight: 210
url: /cs/python-java/examples/elements/ole-object/
keywords:
- příklad kódu
- OLE objekt
- přidat OLE objekt
- přístup k OLE objektu
- odstranit OLE objekt
- aktualizovat OLE objekt
- PowerPoint
- OpenDocument
- prezentace
- Python
- Java
- Aspose.Slides
description: "Použijte Aspose.Slides for Python via Java k přidání, přístupu, odebrání a aktualizaci OLE objektů v prezentacích PowerPoint a OpenDocument."
---
Tento článek ukazuje, jak vložit soubor jako OLE objekt a aktualizovat jeho data pomocí **Aspose.Slides for Python via Java**.

Nainstalujte balíček podle popisu v [Installation](/slides/cs/python-java/installation/). Každý příklad importuje `asposeslides` před spuštěním JVM a poté importuje API po spuštění JVM.

## **Přidat OLE objekt**

Vložte soubor PDF do prezentace.

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

## **Přístup k OLE objektu**

Získejte první rámeček OLE objektu na snímku.

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

## **Odstranit OLE objekt**

Odstraňte vložený OLE objekt ze snímku.

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

## **Aktualizovat data OLE objektu**

Nahraďte data vložená v existujícím OLE objektu.

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