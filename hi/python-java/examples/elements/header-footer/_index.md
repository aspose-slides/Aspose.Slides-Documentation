---
title: हेडर फुटर
type: docs
weight: 220
url: /hi/python-java/examples/elements/header-footer/
keywords:
- कोड उदाहरण
- हेडर
- फुटर
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java के साथ स्लाइड हेडर और फुटर नियंत्रित करें: PPT, PPTX और ODP प्रस्तुतियों में तिथियां, स्लाइड नंबर, और कस्टम टेक्स्ट जोड़ें।"
---
यह लेख दर्शाता है कि **Aspose.Slides for Python via Java** का उपयोग करके फुटर कैसे जोड़ें और दिनांक व समय प्लेसहोल्डर को कैसे अपडेट करें।

पैकेज को [Installation](/slides/hi/python-java/installation/) में वर्णित अनुसार स्थापित करें। प्रत्येक उदाहरण JVM शुरू करने से पहले `asposeslides` इम्पोर्ट करता है, फिर JVM चलने के बाद API इम्पोर्ट करता है।

## **फ़ुटर जोड़ें**
स्लाइड के फ़ुटर क्षेत्र में टेक्स्ट जोड़ें और इसे दृश्यमान बनाएं।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getHeaderFooterManager().setFooterText("My footer")
    slide.getHeaderFooterManager().setFooterVisibility(True)
finally:
    presentation.dispose()
```

## **तारीख और समय अपडेट करें**
स्लाइड पर दिनांक और समय प्लेसहोल्डर को संशोधित करें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getHeaderFooterManager().setDateTimeText("01/01/2024")
    slide.getHeaderFooterManager().setDateTimeVisibility(True)
finally:
    presentation.dispose()
```