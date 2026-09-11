---
title: Python के माध्यम से Java में प्रस्तुतियों में दीर्घवृत्त जोड़ें
linktitle: दीर्घवृत्त
type: docs
weight: 30
url: /hi/python-java/ellipse/
keywords:
- दीर्घवृत्त
- आकार
- दीर्घवृत्त जोड़ें
- दीर्घवृत्त बनाएं
- दीर्घवृत्त खींचें
- स्वरूपित दीर्घवृत्त
- PowerPoint
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java में PPT और PPTX प्रस्तुतियों के लिए दीर्घवृत्त आकृतियों को बनाना, स्वरूपित करना और हेरफेर करना सीखें—Python कोड उदाहरण शामिल हैं।"
---
## **अवलोकन**

यह लेख Aspose.Slides का उपयोग करके PowerPoint स्लाइड में दीर्घवृत्त आकृति जोड़ने का तरीका दर्शाता है। इसमें एक साधारण दीर्घवृत्त बनाना, स्वरूपित दीर्घवृत्त बनाना, और अद्यतन प्रस्तुति को PPTX फ़ाइल के रूप में सहेजना शामिल है। साथ ही यह दीर्घवृत्त की स्थिति और आकार, स्टैकिंग क्रम नियंत्रित करने, और एनीमेशन प्रभाव लागू करने से संबंधित प्रश्नों को भी छूता है।

## **दीर्घवृत्त बनाएं**

प्रस्तुति की एक चयनित स्लाइड में एक साधारण दीर्घवृत्त जोड़ने के लिए नीचे दिए गए चरणों का पालन करें:

- एक [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएँ।
- उसके इंडेक्स द्वारा स्लाइड का एक संदर्भ प्राप्त करें।
- [ShapeCollection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shapecollection/) ऑब्जेक्ट की [addAutoShape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shapecollection/#addAutoShape) विधि का उपयोग करके एक दीर्घवृत्त जोड़ें।
- संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

निम्न उदाहरण पहले स्लाइड में एक दीर्घवृत्त जोड़ता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpide.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएँ।
presentation = Presentation()
try:
    # पहली स्लाइड प्राप्त करें।
    slide = presentation.getSlides().get_Item(0)

    # एक दीर्घवृत्त आकार जोड़ें।
    slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50)

    # PPTX फ़ाइल को डिस्क पर लिखें।
    presentation.save("EllipseShp1.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **स्वरूपित दीर्घवृत्त बनाएं**

स्लाइड में एक स्वरूपित दीर्घवृत्त जोड़ने के लिए नीचे दिए गए चरणों का पालन करें:

- एक [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएँ।
- उसके इंडेक्स द्वारा स्लाइड का एक संदर्भ प्राप्त करें।
- [ShapeCollection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shapecollection/) ऑब्जेक्ट की [addAutoShape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shapecollection/#addAutoShape) विधि का उपयोग करके एक दीर्घवृत्त जोड़ें।
- दीर्घवृत्त के फाइल प्रकार को सॉलिड सेट करें।
- [Shape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/) ऑब्जेक्ट से जुड़े [FillFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fillformat/) ऑब्जेक्ट पर [getSolidFillColor](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fillformat/#getSolidFillColor) के द्वारा दीर्घवृत्त का फाइल रंग सेट करें।
- दीर्घवृत्त के रूपरेखा (आउटलाइन) का रंग सेट करें।
- दीर्घवृत्त के रूपरेखा (आउटलाइन) की चौड़ाई सेट करें।
- संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

निम्न उदाहरण प्रस्तुति की पहली स्लाइड में एक स्वरूपित दीर्घवृत्त जोड़ता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, PresetColor, SaveFormat, ShapeType
from java.awt import Color

# PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं।
presentation = Presentation()
try:
    # पहली स्लाइड प्राप्त करें।
    slide = presentation.getSlides().get_Item(0)

    # एक दीर्घवृत्त आकार जोड़ें।
    ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50)

    # दीर्घवृत्त के भराव को स्वरूपित करें।
    ellipse.getFillFormat().setFillType(FillType.Solid)
    ellipse.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.Chocolate)

    # दीर्घवृत्त की रूपरेखा स्वरूपित करें।
    ellipse.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    ellipse.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    ellipse.getLineFormat().setWidth(5)

    # PPTX फ़ाइल को डिस्क पर लिखें।
    presentation.save("EllipseShp1.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं स्लाइड की इकाइयों के संबंध में दीर्घवृत्त की सटीक स्थिति और आकार कैसे सेट करूँ?**

निर्देशांक और आकार आमतौर पर **पॉइंट्स** में निर्दिष्ट होते हैं। पूर्वानुमेय परिणामों के लिए, स्लाइड आकार के आधार पर गणनाएँ करें और मान असाइन करने से पहले आवश्यक मिलिमीटर या इंच को पॉइंट्स में बदलें।

**मैं दीर्घवृत्त को अन्य वस्तुओं के ऊपर या नीचे कैसे रखूँ (स्टैकिंग क्रम नियंत्रित करें)?**

ऑब्जेक्ट के ड्राइंग क्रम को आगे ले जाकर या पीछे भेजकर बदलें। इससे दीर्घवृत्त अन्य वस्तुओं के ऊपर ओवरलैप कर सकता है या उन वस्तुओं को प्रकट कर सकता है जो उसके नीचे थीं।

**मैं दीर्घवृत्त के प्रदर्शित या जोर देने के लिए एनीमेशन कैसे लागू करूँ?**

[प्रयोग करें](/slides/hi/python-java/shape-animation/) प्रवेश, जोर देने, या निकास प्रभाव को आकार पर लागू करें, और ट्रिगर व टाइमिंग को कॉन्फ़िगर करें ताकि एनीमेशन कब और कैसे चले।