---
title: टेक्स्ट बॉक्स
type: docs
weight: 40
url: /hi/python-java/examples/elements/text-box/
keywords:
- कोड उदाहरण
- टेक्स्ट बॉक्स
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java में टेक्स्ट बॉक्स के साथ काम करें: PowerPoint और OpenDocument प्रस्तुतियों में टेक्स्ट जोड़ें, स्वरूपित करें, खोजें और हटाएँ।"
---
**Aspose.Slides for Python via Java** में, एक टेक्स्ट बॉक्स एक स्वचालित आकार है जो टेक्स्ट रखता है। लगभग हर आकार टेक्स्ट रख सकता है, लेकिन एक सामान्य टेक्स्ट बॉक्स में कोई फ़िल या बॉर्डर नहीं होता और यह केवल टेक्स्ट दिखाता है।

यह गाइड प्रोग्रामेटिकली टेक्स्ट बॉक्स को जोड़ने, एक्सेस करने और हटाने का तरीका समझाता है।

पैकेज को [Installation](/slides/hi/python-java/installation/) में वर्णित अनुसार इंस्टॉल करें। प्रत्येक उदाहरण JVM शुरू करने से पहले `asposeslides` इम्पोर्ट करता है, और JVM चलने के बाद API इम्पोर्ट करता है।

## **टेक्स्ट बॉक्स जोड़ें**

एक आयत बनाएं, उसका फ़िल और बॉर्डर हटाएँ, और फ़ॉर्मेट किया हुआ टेक्स्ट असाइन करें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # आयत आकार बनाएं।
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 75, 150, 100)

    # फ़िल और बॉर्डर हटाएँ ताकि केवल टेक्स्ट दिखे।
    text_box.getFillFormat().setFillType(FillType.NoFill)
    text_box.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

    # डिफ़ॉल्ट टेक्स्ट फ़ॉर्मेटिंग सेट करें।
    paragraph = text_box.getTextFrame().getParagraphs().get_Item(0)
    text_format = paragraph.getParagraphFormat().getDefaultPortionFormat()
    text_format.getFillFormat().setFillType(FillType.Solid)
    text_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    text_box.getTextFrame().setText("Some text...")
finally:
    presentation.dispose()
```

## **सामग्री के आधार पर टेक्स्ट बॉक्स तक पहुँचें**

एक सैंपल टेक्स्ट बॉक्स जोड़ें, फिर उन आकारों को खोजें जिनके टेक्स्ट में शब्द "Slide" मौजूद है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType, AutoShape

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 75, 150, 100)
    text_box.getFillFormat().setFillType(FillType.NoFill)
    text_box.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    text_box.getTextFrame().setText("Slide notes")

    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, AutoShape):
            text_frame = shape.getTextFrame()
            if text_frame is not None and "Slide" in str(text_frame.getText()):
                # मिलते-जुलते टेक्स्ट बॉक्स का उपयोग करें।
                print(text_frame.getText())
finally:
    presentation.dispose()
```

## **सामग्री के आधार पर टेक्स्ट बॉक्स हटाएँ**

पहले स्लाइड पर उस विशेष कीवर्ड को शामिल करने वाले टेक्स्ट बॉक्स को खोजें और हटाएँ।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType, AutoShape

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 75, 150, 100)
    text_box.getFillFormat().setFillType(FillType.NoFill)
    text_box.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    text_box.getTextFrame().setText("Slide notes")

    shapes_to_remove = []
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, AutoShape):
            text_frame = shape.getTextFrame()
            if text_frame is not None and "Slide" in str(text_frame.getText()):
                shapes_to_remove.append(shape)

    for shape in shapes_to_remove:
        slide.getShapes().remove(shape)
finally:
    presentation.dispose()
```

{{% alert color="success" title="Tip" %}}
मिलते-जुलते आकारों को हटाने से पहले एक अलग सूची में एकत्र करें ताकि इटरशन के दौरान आकार संग्रह को संशोधित करने से बचा जा सके।
{{% /alert %}}