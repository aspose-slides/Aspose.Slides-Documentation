---
title: टेबल
type: docs
weight: 120
url: /hi/python-java/examples/elements/table/
keywords:
- कोड उदाहरण
- टेबल
- टेबल जोड़ें
- टेबल तक पहुँचें
- टेबल हटाएँ
- सेल्स को मर्ज करें
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java में टेबल के साथ काम करें: PowerPoint और OpenDocument प्रस्तुतियों में टेबल जोड़ें, पहुँचें, हटाएँ, और सेल्स को मर्ज करें।"
---
**Aspose.Slides for Python via Java** का उपयोग करके टेबल जोड़ने, एक्सेस करने, हटाने और सेल्स को मर्ज करने के उदाहरण।

पैकेज को [Installation](/slides/hi/python-java/installation/) में वर्णित अनुसार इंस्टॉल करें। प्रत्येक उदाहरण `asposeslides` को JVM शुरू करने से पहले इम्पोर्ट करता है, फिर JVM चलने के बाद API को इम्पोर्ट करता है।

## **टेबल जोड़ें**

दो पंक्तियों और दो कॉलमों के साथ एक सरल टेबल बनाएं।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    widths = jpype.JArray(jpype.JDouble)([80, 80])
    heights = jpype.JArray(jpype.JDouble)([30, 30])
    table = slide.getShapes().addTable(50, 50, widths, heights)
finally:
    presentation.dispose()
```

## **टेबल तक पहुँचें**

स्लाइड पर पहला टेबल शैप प्राप्त करें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Table

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    widths = jpype.JArray(jpype.JDouble)([80, 80])
    heights = jpype.JArray(jpype.JDouble)([30, 30])
    table = slide.getShapes().addTable(50, 50, widths, heights)

    # स्लाइड पर पहली टेबल तक पहुँचें।
    first_table = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, Table):
            first_table = shape
            break
finally:
    presentation.dispose()
```

## **टेबल हटाएँ**

स्लाइड से एक टेबल हटाएँ।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    widths = jpype.JArray(jpype.JDouble)([80, 80])
    heights = jpype.JArray(jpype.JDouble)([30, 30])
    table = slide.getShapes().addTable(50, 50, widths, heights)

    slide.getShapes().remove(table)
finally:
    presentation.dispose()
```

## **टेबल सेल्स को मर्ज करें**

टेबल के सटे हुए सेल्स को एकल सेल में मर्ज करें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    widths = jpype.JArray(jpype.JDouble)([80, 80])
    heights = jpype.JArray(jpype.JDouble)([30, 30])
    table = slide.getShapes().addTable(50, 50, widths, heights)

    # सेल्स को मर्ज करें।
    table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 1), False)
finally:
    presentation.dispose()
```