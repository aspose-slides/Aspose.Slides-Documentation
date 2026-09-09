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
description: "Aspose.Slides for Python via Java में टेक्स्ट बॉक्स के साथ काम करें: PowerPoint और OpenDocument प्रस्तुतियों में टेक्स्ट जोड़ें, फ़ॉर्मेट करें, खोजें और हटाएँ।"
---
In **Aspose.Slides for Python via Java**, एक टेक्स्ट बॉक्स एक ऑटो शैप है जो टेक्स्ट रखता है। लगभग सभी शैप्स टेक्स्ट रख सकते हैं, लेकिन एक सामान्य टेक्स्ट बॉक्स में कोई फ़िल या बॉर्डर नहीं होता और यह केवल टेक्स्ट दिखाता है।

यह गाइड बताता है कि प्रोग्रामेटिक रूप से टेक्स्ट बॉक्स को कैसे जोड़ें, पहुँचें और हटाएँ।

पैकेज को [Installation](/slides/hi/python-java/installation/) में वर्णित अनुसार इंस्टॉल करें। प्रत्येक उदाहरण JVM शुरू करने से पहले `asposeslides` को इम्पोर्ट करता है, फिर JVM चलने के बाद API को इम्पोर्ट करता है।

## **टेक्स्ट बॉक्स जोड़ें**

एक रेक्टेंगल बनाएं, उसका फ़िल और बॉर्डर हटाएँ, और फ़ॉर्मेटेड टेक्स्ट असाइन करें।

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

    # एक आयताकार आकार बनाएं।
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 75, 150, 100)

    # केवल टेक्स्ट दिखाने के लिए फ़िल और बॉर्डर हटाएँ।
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

## **सामग्री द्वारा टेक्स्ट बॉक्स पहुँचें**

एक उदाहरण टेक्स्ट बॉक्स जोड़ें, फिर उन शैप्स को खोजें जिनके टेक्स्ट में कीवर्ड "Slide" मौजूद है।

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

पहले स्लाइड पर ऐसे टेक्स्ट बॉक्स खोजें और हटाएँ जिनमें कोई विशिष्ट कीवर्ड हो।

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
इटरेशन के दौरान शैप कलेक्शन को बदलने से बचने के लिए उन्हें हटाने से पहले मिलते-जुलते शैप्स को एक अलग सूची में इकट्ठा करें।
{{% /alert %}}