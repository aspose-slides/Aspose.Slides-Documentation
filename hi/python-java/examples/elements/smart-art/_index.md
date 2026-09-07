---
title: SmartArt
type: docs
weight: 140
url: /hi/python-java/examples/elements/smart-art/
keywords:
- कोड उदाहरण
- SmartArt
- SmartArt जोड़ें
- SmartArt एक्सेस करें
- SmartArt हटाएँ
- SmartArt लेआउट
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java में SmartArt के साथ काम करें: PowerPoint और OpenDocument प्रस्तुतियों में आरेख लेआउट जोड़ें, एक्सेस करें, हटाएँ और बदलें।"
---
यह लेख दर्शाता है कि कैसे **Aspose.Slides for Python via Java** का उपयोग करके SmartArt ग्राफ़िक्स जोड़ें, उन्हें एक्सेस करें, हटाएँ, और लेआउट बदलें।

पैकेज को स्थापित करने के लिए [स्थापना](/slides/hi/python-java/installation/) में वर्णित चरणों का पालन करें। प्रत्येक उदाहरण JVM शुरू करने से पहले `asposeslides` आयात करता है, फिर JVM चलने के बाद API आयात करता है।

## **SmartArt जोड़ें**

निर्मित लेआउट्स में से किसी एक का उपयोग करके SmartArt ग्राफ़िक डालें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess)
finally:
    presentation.dispose()
```

## **SmartArt एक्सेस करें**

एक स्लाइड पर पहला SmartArt ऑब्जेक्ट प्राप्त करें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess)

    first_smart_art = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, SmartArt):
            first_smart_art = shape
            break
finally:
    presentation.dispose()
```

## **SmartArt हटाएँ**

स्लाइड से SmartArt आकार को हटाएँ।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess)

    slide.getShapes().remove(smart_art)
finally:
    presentation.dispose()
```

## **SmartArt लेआउट बदलें**

मौजूदा SmartArt ग्राफ़िक के लेआउट प्रकार को अपडेट करें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicBlockList)
    smart_art.setLayout(SmartArtLayoutType.VerticalPictureList)
finally:
    presentation.dispose()
```