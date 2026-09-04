---
title: लेआउट स्लाइड
type: docs
weight: 20
url: /hi/python-java/examples/elements/layout-slide/
keywords:
- कोड उदाहरण
- लेआउट स्लाइड
- लेआउट स्लाइड जोड़ें
- लेआउट स्लाइड तक पहुँचें
- लेआउट स्लाइड हटाएँ
- अप्रयुक्त लेआउट स्लाइड
- लेआउट स्लाइड क्लोन करें
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java के साथ लेआउट स्लाइड्स को प्रबंधित करें: PowerPoint और OpenDocument प्रस्तुतियों में लेआउट्स को जोड़ना, पहुँचना, हटाना, साफ-सफ़ाई करना और क्लोन करना।"
---
इस लेख में Aspose.Slides for Python via Java का उपयोग करके **layout slides** के साथ काम करने का प्रदर्शन किया गया है। एक layout slide वह डिज़ाइन और फ़ॉर्मेटिंग निर्धारित करता है जो सामान्य स्लाइड्स द्वारा विरासत में ली जाती है। आप layout slides को जोड़, एक्सेस, क्लोन और हटाकर, साथ ही उपयोग न किए गए स्लाइड्स को साफ करके प्रस्तुति का आकार घटा सकते हैं।

पैकेज को [Installation](/slides/hi/python-java/installation/) में वर्णित अनुसार इंस्टॉल करें। प्रत्येक उदाहरण `asposeslides` को JVM शुरू करने से पहले इम्पोर्ट करता है, फिर JVM चलने के बाद API को इम्पोर्ट करता है।

## **लेआउट स्लाइड जोड़ें**

एक कस्टम लेआउट स्लाइड बनाकर पुन: उपयोग योग्य फ़ॉर्मेटिंग निर्धारित करें। निम्नलिखित उदाहरण एक नई लेआउट में टेक्स्ट बॉक्स जोड़ता है और फिर दो स्लाइड्स बनाता है जो इसका उपयोग करती हैं।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SlideLayoutType

presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)

    # एक ब्लैंक लेआउट प्रकार और कस्टम नाम के साथ एक लेआउट स्लाइड बनाएं।
    layout_slide = presentation.getLayoutSlides().add(master_slide, SlideLayoutType.Blank, "Main layout")

    # लेआउट स्लाइड में एक टेक्स्ट बॉक्स जोड़ें।
    layout_text_box = layout_slide.getShapes().addAutoShape(ShapeType.Rectangle, 75, 75, 150, 150)
    layout_text_box.getTextFrame().setText("Layout Slide Text")

    # लेआउट से टेक्स्ट विरासत में लेने वाली दो स्लाइड्स जोड़ें।
    presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)
finally:
    presentation.dispose()
```

> 💡 **नोट 1:** Layout slides व्यक्तिगत स्लाइड्स के लिए टेम्पलेट की तरह कार्य करती हैं। आप सामान्य तत्वों को एक बार परिभाषित करके कई स्लाइड्स में पुनः उपयोग कर सकते हैं।

> 💡 **नोट 2:** जब आप लेआउट स्लाइड में शैलियों या टेक्स्ट को जोड़ते हैं, तो उस लेआउट पर आधारित सभी स्लाइड्स स्वचालित रूप से साझा सामग्री प्रदर्शित करती हैं।  
> नीचे दिया गया स्क्रीनशॉट दिखाता है कि दो स्लाइड्स समान लेआउट स्लाइड से टेक्स्ट बॉक्स को विरासत में लेती हैं।

![लेआउट सामग्री विरासत में लेने वाली स्लाइड्स](layout-slide-result.png)

## **लेआउट स्लाइड तक पहुँचें**

लेआउट स्लाइड्स को इंडेक्स या लेआउट प्रकार जैसे ब्लैंक, टाइटल, या सेक्शन हेडर द्वारा एक्सेस करें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    # सूचकांक द्वारा लेआउट स्लाइड तक पहुँचें।
    first_layout_slide = presentation.getLayoutSlides().get_Item(0)

    # प्रकार द्वारा लेआउट स्लाइड तक पहुँचें।
    blank_layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)
finally:
    presentation.dispose()
```

## **लेआउट स्लाइड हटाएँ**

जब इसे अब आवश्यक न हो, तो एक विशिष्ट लेआउट स्लाइड हटाएँ।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)
    layout_slide = presentation.getLayoutSlides().add(master_slide, SlideLayoutType.Blank, "Temporary layout")

    presentation.getLayoutSlides().remove(layout_slide)
finally:
    presentation.dispose()
```

## **अप्रयुक्त लेआउट स्लाइड्स हटाएँ**

प्रस्तुति का आकार घटाने के लिए उन लेआउट स्लाइड्स को हटाएँ जो किसी सामान्य स्लाइड द्वारा उपयोग नहीं की गई हैं।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    presentation.getLayoutSlides().removeUnused()
finally:
    presentation.dispose()
```

## **लेआउट स्लाइड क्लोन करें**

एक लेआउट स्लाइड को डुप्लिकेट करें और कॉपी को लेआउट स्लाइड संग्रह के अंत में जोड़ें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)
    source_layout_slide = presentation.getLayoutSlides().add(master_slide, SlideLayoutType.Blank, "Source layout")

    cloned_layout_slide = presentation.getLayoutSlides().addClone(source_layout_slide)
finally:
    presentation.dispose()
```

> ✅ **सारांश:** लेआउट स्लाइड्स प्रस्तुति में सुसंगत फ़ॉर्मेटिंग बनाए रखने में मदद करती हैं। Aspose.Slides आपको आवश्यकता अनुसार लेआउट्स को बनाना, प्रबंधित करना, पुनः उपयोग करना और साफ़ करना संभव बनाता है।