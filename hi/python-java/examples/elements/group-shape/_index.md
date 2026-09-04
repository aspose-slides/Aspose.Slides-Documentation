---
title: समूह आकार
type: docs
weight: 170
url: /hi/python-java/examples/elements/group-shape/
keywords:
- कोड उदाहरण
- समूह आकार
- समूह आकार जोड़ें
- समूह आकार तक पहुँचें
- समूह आकार हटाएँ
- आकारों को अनग्रुप करें
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java के साथ प्रस्तुतियों में समूह आकारों को प्रबंधित करें: PowerPoint और OpenDocument फ़ाइलों में आकारों को जोड़ें, पहुँचें, हटाएँ, और अनग्रुप करें।"
---
यह लेख दर्शाता है कि कैसे **Aspose.Slides for Python via Java** का उपयोग करके आकारों के समूह बनाना, उन्हें एक्सेस करना, हटाना और उनकी सामग्री को अनग्रुप करना संभव है।

पैकेज को [Installation](/slides/hi/python-java/installation/) में वर्णित अनुसार इंस्टॉल करें। प्रत्येक उदाहरण `asposeslides` को JVM शुरू करने से पहले इम्पोर्ट करता है, फिर JVM चलने के बाद API को इम्पोर्ट करता है।

## **समूह आकार जोड़ें**

दो बुनियादी आकारों वाले एक समूह बनाएं।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    group = slide.getShapes().addGroupShape()
    group.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50)
    group.getShapes().addAutoShape(ShapeType.Ellipse, 60, 0, 50, 50)
finally:
    presentation.dispose()
```

## **समूह आकार तक पहुँचें**

स्लाइड से पहला समूह आकार प्राप्त करें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import GroupShape, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    group = slide.getShapes().addGroupShape()
    group.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50)

    first_group = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, GroupShape):
            first_group = shape
            break
finally:
    presentation.dispose()
```

## **समूह आकार हटाएँ**

स्लाइड से एक समूह आकार हटाएँ।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    group = slide.getShapes().addGroupShape()

    slide.getShapes().remove(group)
finally:
    presentation.dispose()
```

## **आकृतियों को अनग्रुप करें**

एक आकार को समूह कंटेनर से बाहर ले जाएँ।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    group = slide.getShapes().addGroupShape()
    rectangle = group.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50)

    # आकार को समूह से बाहर ले जाएँ।
    slide.getShapes().addClone(rectangle)
    group.getShapes().remove(rectangle)
finally:
    presentation.dispose()
```