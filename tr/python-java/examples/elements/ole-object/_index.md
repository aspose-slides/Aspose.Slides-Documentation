---
title: OLE Nesnesi
type: docs
weight: 210
url: /tr/python-java/examples/elements/ole-object/
keywords:
- kod örneği
- OLE nesnesi
- OLE nesnesi ekle
- OLE nesnesine eriş
- OLE nesnesini kaldır
- OLE nesnesini güncelle
- PowerPoint
- OpenDocument
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java kullanarak PowerPoint ve OpenDocument sunumlarında OLE nesnelerini ekleyin, erişin, kaldırın ve güncelleyin."
---
Bu makale, bir dosyayı OLE nesnesi olarak eklemeyi ve **Aspose.Slides for Python via Java** kullanarak verilerini güncellemeyi göstermektedir.

Paketi, [Installation](/slides/tr/python-java/installation/) bölümünde açıklandığı gibi kurun. Her örnek, JVM'i başlatmadan önce `asposeslides` paketini içe aktarır, ardından JVM çalıştıktan sonra API'yi içe aktarır.

## **OLE Nesnesi Ekle**

PDF dosyasını sunuma yerleştirin.

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

## **OLE Nesnesine Erişim**

Bir slayttaki ilk OLE nesnesi çerçevesini alın.

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

## **OLE Nesnesini Kaldır**

Yerleştirilmiş bir OLE nesnesini slayttan silin.

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

## **OLE Nesne Verilerini Güncelle**

Mevcut bir OLE nesnesine gömülü verileri değiştirin.

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