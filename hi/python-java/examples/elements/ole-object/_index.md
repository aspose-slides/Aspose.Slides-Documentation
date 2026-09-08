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
description: "PowerPoint और OpenDocument प्रस्तुतियों में OLE ऑब्जेक्ट्स को जोड़ने, पहुंचने, हटाने और अपडेट करने के लिए Aspose.Slides for Python via Java का उपयोग करें।"
---
यह लेख दिखाता है कि कैसे फ़ाइल को OLE ऑब्जेक्ट के रूप में एम्बेड किया जाए और उसके डेटा को **Aspose.Slides for Python via Java** का उपयोग करके अपडेट किया जाए।

पैकेज को स्थापित करने के लिए [Installation](/slides/hi/python-java/installation/) में वर्णित चरणों का पालन करें। प्रत्येक उदाहरण `asposeslides` को JVM शुरू करने से पहले इम्पोर्ट करता है, और फिर JVM चलने के बाद API को इम्पोर्ट करता है।

## **OLE ऑब्जेक्ट जोड़ें**

प्रेजेंटेशन में एक PDF फ़ाइल एम्बेड करें।

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

## **OLE ऑब्जेक्ट तक पहुंचें**

स्लाइड पर पहला OLE ऑब्जेक्ट फ़्रेम प्राप्त करें।

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

## **OLE ऑब्जेक्ट हटाएं**

स्लाइड से एम्बेड किया गया OLE ऑब्जेक्ट हटाएँ।

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

## **OLE ऑब्जेक्ट डेटा अपडेट करें**

मौजूदा OLE ऑब्जेक्ट में एम्बेड किए गए डेटा को बदलें।

```python
from pathlib import Path

import jpide
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