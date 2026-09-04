---
title: कनेक्टर
type: docs
weight: 190
url: /hi/python-java/examples/elements/connector/
keywords:
- कोड उदाहरण
- कनेक्टर
- कनेक्टर जोड़ें
- कनेक्टर एक्सेस करें
- कनेक्टर हटाएँ
- आकृतियों को पुनः कनेक्ट करें
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java का उपयोग करके PPT, PPTX और ODP प्रस्तुतियों में कनेक्टर्स के साथ आकृतियों को जोड़ना, एक्सेस करना, हटाना और पुनः कनेक्ट करना सीखें।"
---
यह लेख **Aspose.Slides for Python via Java** का उपयोग करके आकृतियों को कनेक्टर्स के साथ जोड़ने और उनके टार्गेट बदलने का प्रदर्शन करता है।

पैकेज को [Installation](/slides/hi/python-java/installation/) में वर्णित अनुसार इंस्टॉल करें। प्रत्येक उदाहरण JVM शुरू करने से पहले `asposeslides` को इम्पोर्ट करता है, और फिर JVM चलने के बाद API को इम्पोर्ट करता है।

## **कनेक्टर जोड़ें**

स्लाइड पर दो बिंदुओं के बीच एक कनेक्टर आकृति डालें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    connector = slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100)
finally:
    presentation.dispose()
```

## **कनेक्टर एक्सेस करें**

स्लाइड में जोड़े गए पहले कनेक्टर आकृति को प्राप्त करें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Connector, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100)

    # स्लाइड पर पहले कनेक्टर तक पहुंचें।
    connector = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, Connector):
            connector = shape
            break
finally:
    presentation.dispose()
```

## **कनेक्टर हटाएँ**

स्लाइड से एक कनेक्टर को हटाएँ।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    connector = slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100)

    slide.getShapes().remove(connector)
finally:
    presentation.dispose()
```

## **आकृतियों को पुनः कनेक्ट करें**

शुरू और अंत टार्गेट असाइन करके दो आकृतियों को एक कनेक्टर से जोड़ें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50)
    shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 50, 50)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100)

    connector.setStartShapeConnectedTo(shape1)
    connector.setEndShapeConnectedTo(shape2)
finally:
    presentation.dispose()
```