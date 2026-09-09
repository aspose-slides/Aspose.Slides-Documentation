---
title: हेडर और फुटर
type: docs
weight: 220
url: /hi/python-java/examples/elements/header-footer/
keywords:
- कोड उदाहरण
- हेडर
- फ़ुटर
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java के साथ स्लाइड हेडर और फुटर नियंत्रित करें: PPT, PPTX, और ODP प्रस्तुतियों में तिथियों, स्लाइड नंबरों और कस्टम टेक्स्ट को जोड़ें।"
---
यह लेख **Aspose.Slides for Python via Java** का उपयोग करके फुटर जोड़ने और तिथि व समय प्लेसहोल्डर को अपडेट करने का प्रदर्शन करता है।

पैकेज को स्थापित करने के लिए [Installation](/slides/hi/python-java/installation/) में वर्णित चरणों का पालन करें। प्रत्येक उदाहरण JVM को शुरू करने से पहले `asposeslides` को इम्पोर्ट करता है, फिर JVM चलने के बाद API को इम्पोर्ट करता है।

## **फुटर जोड़ें**

स्लाइड के फुटर क्षेत्र में टेक्स्ट जोड़ें और इसे दृश्यमान बनाएं।

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

## **तिथि और समय अपडेट करें**

स्लाइड पर तिथि और समय प्लेसहोल्डर को संशोधित करें।

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