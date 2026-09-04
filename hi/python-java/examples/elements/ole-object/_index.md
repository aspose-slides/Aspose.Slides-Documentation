---
title: OLE ऑब्जेक्ट
type: docs
weight: 210
url: /hi/python-java/examples/elements/ole-object/
keywords:
- कोड उदाहरण
- OLE ऑब्जेक्ट
- OLE ऑब्जेक्ट जोड़ें
- OLE ऑब्जेक्ट तक पहुंचें
- OLE ऑब्जेक्ट हटाएँ
- OLE ऑब्जेक्ट अपडेट करें
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में OLE ऑब्जेक्ट जोड़ना, पहुँचना, हटाना और अपडेट करना।"
---
यह लेख दिखाता है कि **Aspose.Slides for Python via Java** का उपयोग करके फ़ाइल को OLE ऑब्जेक्ट के रूप में एम्बेड कैसे करें और उसके डेटा को अपडेट कैसे करें।

पैकेज को स्थापित करने के लिए [स्थापना](/slides/hi/python-java/installation/) देखें। प्रत्येक उदाहरण `asposeslides` को JVM शुरू करने से पहले इम्पोर्ट करता है, फिर JVM चलाने के बाद API को इम्पोर्ट करता है।

## **OLE ऑब्जेक्ट जोड़ें**

एक PDF फ़ाइल को प्रस्तुति में एम्बेड करें।

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

## **OLE ऑब्जेक्ट तक पहुँचें**

स्लाइड पर पहले OLE ऑब्जेक्ट फ्रेम को प्राप्त करें।

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

## **OLE ऑब्जेक्ट हटाएँ**

स्लाइड से एम्बेडेड OLE ऑब्जेक्ट को हटाएँ।

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

## **OLE ऑब्जेक्ट डेटा अपडेट करें**

मौजूद OLE ऑब्जेक्ट में एम्बेडेड डेटा को प्रतिस्थापित करें।

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