---
title: Obiekt OLE
type: docs
weight: 210
url: /pl/python-java/examples/elements/ole-object/
keywords:
- przykład kodu
- obiekt OLE
- dodaj obiekt OLE
- uzyskaj dostęp do obiektu OLE
- usuń obiekt OLE
- zaktualizuj obiekt OLE
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Użyj Aspose.Slides for Python via Java, aby dodać, uzyskać dostęp, usunąć i zaktualizować obiekty OLE w prezentacjach PowerPoint i OpenDocument."
---
Ten artykuł demonstruje, jak osadzić plik jako obiekt OLE i zaktualizować jego dane przy użyciu **Aspose.Slides for Python via Java**.

Zainstaluj pakiet zgodnie z opisem w [Installation](/slides/pl/python-java/installation/). Każdy przykład importuje `asposeslides` przed uruchomieniem JVM, a następnie importuje API po uruchomieniu JVM.

## **Dodaj obiekt OLE**
Osadź plik PDF w prezentacji.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    pdf_data = Path("doc.pdf").read_bytes()
    java_pdf_data = jpype.JArray(jpype.JByte)(pdf_data)
    data_info = OleEmbeddedDataInfo(java_pdf_data, "pdf")
    ole_frame = slide.getShapes().addOleObjectFrame(20, 20, 50, 50, data_info)
finally:
    presentation.dispose()
```

## **Uzyskaj dostęp do obiektu OLE**
Pobierz pierwszą ramkę obiektu OLE na slajdzie.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, OleObjectFrame, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    pdf_data = Path("doc.pdf").read_bytes()
    java_pdf_data = jpype.JArray(jpype.JByte)(pdf_data)
    data_info = OleEmbeddedDataInfo(java_pdf_data, "pdf")
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

## **Usuń obiekt OLE**
Usuń osadzony obiekt OLE ze slajdu.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    pdf_data = Path("doc.pdf").read_bytes()
    java_pdf_data = jpype.JArray(jpype.JByte)(pdf_data)
    data_info = OleEmbeddedDataInfo(java_pdf_data, "pdf")
    ole_frame = slide.getShapes().addOleObjectFrame(20, 20, 50, 50, data_info)

    slide.getShapes().remove(ole_frame)
finally:
    presentation.dispose()
```

## **Zaktualizuj dane obiektu OLE**
Zastąp dane osadzone w istniejącym obiekcie OLE.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    pdf_data = Path("doc.pdf").read_bytes()
    java_pdf_data = jpype.JArray(jpype.JByte)(pdf_data)
    data_info = OleEmbeddedDataInfo(java_pdf_data, "pdf")
    ole_frame = slide.getShapes().addOleObjectFrame(20, 20, 50, 50, data_info)

    new_data = Path("Picture.png").read_bytes()
    java_new_data = jpype.JArray(jpype.JByte)(new_data)
    new_data_info = OleEmbeddedDataInfo(java_new_data, "png")
    ole_frame.setEmbeddedData(new_data_info)
finally:
    presentation.dispose()
```