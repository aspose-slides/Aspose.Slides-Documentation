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
description: "PowerPoint ve OpenDocument sunumlarında OLE nesnelerini eklemek, erişmek, kaldırmak ve güncellemek için Aspose.Slides for Python via Java'yi kullanın."
---
Bu makale, bir dosyayı OLE nesnesi olarak nasıl gömeceğinizi ve **Aspose.Slides for Python via Java** kullanarak verilerini nasıl güncelleyeceğinizi gösterir.

Paketi, [Installation](/slides/tr/python-java/installation/) bölümünde açıklandığı gibi kurun. Her örnek, JVM'i başlatmadan önce `asposeslides` paketini, JVM çalıştıktan sonra API'yi içe aktarır.

## **OLE Nesnesi Ekle**

Bir PDF dosyasını sunuma gömün.

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

## **OLE Nesnesine Erişme**

Bir slayttaki ilk OLE nesne çerçevesini alın.

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

## **OLE Nesnesini Kaldırma**

Slayttan gömülü bir OLE nesnesini silin.

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

## **OLE Nesnesi Verilerini Güncelleme**

Mevcut bir OLE nesnesine gömülü verileri değiştirin.

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