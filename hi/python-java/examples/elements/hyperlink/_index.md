---
title: हाइपरलिंक
type: docs
weight: 130
url: /hi/python-java/examples/elements/hyperlink/
keywords:
- कोड उदाहरण
- हाइपरलिंक
- हाइपरलिंक जोड़ें
- हाइपरलिंक तक पहुँचें
- हाइपरलिंक हटाएँ
- हाइपरलिंक अपडेट करें
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java में हाइपरलिंक जोड़ें और प्रबंधित करें: PPT, PPTX और ODP प्रस्तुतियों में लिंक बनाएं, पहुँचें, हटाएँ और अपडेट करें।"
---
यह लेख **Aspose.Slides for Python via Java** का उपयोग करके आकारों पर हाइपरलिंक जोड़ने, पहुँचने, हटाने और अपडेट करने का प्रदर्शन करता है।

पैकेज को [Installation](/slides/hi/python-java/installation/) में वर्णित अनुसार स्थापित करें। प्रत्येक उदाहरण JVM को शुरू करने से पहले `asposeslides` को इम्पोर्ट करता है, फिर JVM चलने के बाद API को इम्पोर्ट करता है।

## **हाइपरलिंक जोड़ें**

एक आयताकार आकार बनाएं जिसमें बाहरी वेबसाइट की ओर इशारा करता हाइपरलिंक हो।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50)
    shape.getTextFrame().setText("Aspose")

    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    text_portion = paragraph.getPortions().get_Item(0)
    text_portion.getPortionFormat().setHyperlinkClick(Hyperlink("https://www.aspose.com"))
finally:
    presentation.dispose()
```

## **हाइपरलिंक तक पहुँचें**

आकार के टेक्स्ट भाग से हाइपरलिंक की जानकारी पढ़ें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50)
    shape.getTextFrame().setText("Aspose")

    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    text_portion = paragraph.getPortions().get_Item(0)
    text_portion.getPortionFormat().setHyperlinkClick(Hyperlink("https://www.aspose.com"))

    hyperlink = text_portion.getPortionFormat().getHyperlinkClick()
finally:
    presentation.dispose()
```

## **हाइपरलिंक हटाएँ**

आकार के टेक्स्ट से हाइपरलिंक को साफ़ करें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50)
    shape.getTextFrame().setText("Aspose")

    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    text_portion = paragraph.getPortions().get_Item(0)
    text_portion.getPortionFormat().setHyperlinkClick(Hyperlink("https://www.aspose.com"))

    text_portion.getPortionFormat().setHyperlinkClick(None)
finally:
    presentation.dispose()
```

## **हाइपरलिंक अपडेट करें**

मौजूदा हाइपरलिंक का लक्ष्य बदलें। टेक्स्ट जिसमें पहले से हाइपरलिंक है, उसे संशोधित करने के लिए [HyperlinkManager](https://reference.aspose.com/slides/hi/python-java/aspose.slides/hyperlinkmanager/) का उपयोग करें, जो PowerPoint के सुरक्षित हाइपरलिंक अपडेट करने के तरीके की नकल करता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50)
    shape.getTextFrame().setText("Aspose")

    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    text_portion = paragraph.getPortions().get_Item(0)
    text_portion.getPortionFormat().setHyperlinkClick(Hyperlink("https://old.example.com"))

    # मौजूदा टेक्स्ट में हाइपरलिंक बदलना चाहिए
    # HyperlinkManager के माध्यम से, सीधे प्रॉपर्टी सेट करने के बजाय।
    # यह PowerPoint के सुरक्षित रूप से हाइपरलिंक अपडेट करने के तरीके की नकल करता है।
    text_portion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://new.example.com")
finally:
    presentation.dispose()
```