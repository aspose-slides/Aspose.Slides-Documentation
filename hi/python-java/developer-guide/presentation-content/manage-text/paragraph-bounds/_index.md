---
title: Python के माध्यम से Java में प्रस्तुतियों से पैराग्राफ सीमाएँ प्राप्त करें
linktitle: पैराग्राफ सीमाएँ
type: docs
weight: 43
url: /hi/python-java/paragraph-bounds/
keywords:
- पैराग्राफ सीमाएँ
- पैराग्राफ निर्देशांक
- पैराग्राफ आकार
- टेक्स्ट फ्रेम
- PowerPoint
- प्रस्तुतीकरण
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides के लिए Python के माध्यम से Java में पैराग्राफ सीमाओं को प्राप्त करने का तरीका सीखें ताकि PowerPoint प्रस्तुतियों में टेक्स्ट की स्थिति को अनुकूलित किया जा सके।"
---
## **अवलोकन**

यह लेख Aspose.Slides में अनुच्छेदों की सीमाएँ, आकार और निर्देशांक प्राप्त करने के तरीकों को समझाता है। यह दिखाता है कि कैसे एक [TextFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframe/) से [Paragraph.getRect](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraph/#getRect) का उपयोग करके अनुच्छेद आयत प्राप्त की जाए, तालिका सेल टेक्स्ट फ्रेम के अंदर अनुच्छेद के निर्देशांक कैसे प्राप्त किए जाएँ, और मापन इकाइयाँ, टेक्स्ट रैपिंग का सीमाओं पर प्रभाव, पिक्सेल रूपांतरण, और प्रभावी अनुच्छेद फ़ॉर्मेटिंग मानों जैसे महत्वपूर्ण विवरणों को उजागर किया जाए।

## **अनुच्छेद के आयताकार निर्देशांक प्राप्त करें**

एक अनुच्छेद का बाउंडिंग आयत प्राप्त करने के लिए [Paragraph.getRect](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraph/#getRect) का उपयोग करें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Shapes.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)
    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    rectangle = paragraph.getRect()
finally:
    presentation.dispose()
```

## **तालिका सेल टेक्स्ट फ्रेम के भीतर एक अनुच्छेद का आकार प्राप्त करें**

एक तालिका सेल टेक्स्ट फ्रेम में एक [Paragraph](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraph/) का आकार और निर्देशांक प्राप्त करने के लिए [Paragraph.getRect](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraph/#getRect) का प्रयोग करें। प्राप्त आयत तालिका सेल टेक्स्ट फ्रेम के सापेक्ष है, इसलिए स्लाइड‑स्तर के निर्देशांक चाहिए हों तो तालिका की स्थिति और सेल ऑफ़सेट जोड़ें।

निम्न उदाहरण तालिका सेल के भीतर अनुच्छेद सीमाएँ प्राप्त करता है और उन सीमाओं को दृश्य रूप में प्रस्तुत करने के लिए स्लाइड पर आयतें खींचता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation("source.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)
    cell = table.getRows().get_Item(1).get_Item(1)

    cell_x = table.getX() + cell.getOffsetX()
    cell_y = table.getY() + cell.getOffsetY()

    for paragraph in cell.getTextFrame().getParagraphs():
        if not paragraph.getText():
            continue

        paragraph_rectangle = paragraph.getRect()
        paragraph_rectangle_x = paragraph_rectangle.x + cell_x
        paragraph_rectangle_y = paragraph_rectangle.y + cell_y

        paragraph_bounds_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, paragraph_rectangle_x, paragraph_rectangle_y, paragraph_rectangle.width, paragraph_rectangle.height)

        paragraph_bounds_shape.getFillFormat().setFillType(FillType.NoFill)
        paragraph_bounds_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW)
        paragraph_bounds_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **अक्सर पूछे जाने वाले प्रश्न**

**अनुच्छेद निर्देशांक किन इकाइयों में मापे जाते हैं?**

वे पॉइंट्स में मापे जाते हैं, जहाँ 1 इंच = 72 पॉइंट्स। यह स्लाइड पर सभी निर्देशांक और आयामों पर लागू होता है।

**क्या शब्द रैपिंग का अनुच्छेद की सीमाओं पर प्रभाव पड़ता है?**

हां। यदि [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframeformat/#setWrapText) [TextFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframe/) के लिए सक्रिय है, तो टेक्स्ट क्षेत्र की चौड़ाई के अनुसार टूटता है, जिससे अनुच्छेद की वास्तविक सीमाएँ बदलती हैं।

**क्या निर्यातित छवि में अनुच्छेद निर्देशांकों को पिक्सेल में भरोसेमंद रूप से मैप किया जा सकता है?**

हां। इस सूत्र के द्वारा पॉइंट्स को पिक्सेल में बदलें: pixels = points x (DPI / 72). परिणाम रेंडरिंग या निर्यात के लिए चुने गए DPI पर निर्भर करता है।

**स्टाइल विरासत को ध्यान में रखते हुए "प्रभावी" अनुच्छेद फ़ॉर्मेटिंग पैरामीटर कैसे प्राप्त करें?**

[effective paragraph formatting data structure](/slides/hi/python-java/shape-effective-properties/) का उपयोग करें; यह इंडेंट, स्पेसिंग, रैपिंग, RTL आदि के अंतिम संयुक्त मान लौटाता है।