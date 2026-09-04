---
title: इंक
type: docs
weight: 180
url: /hi/python-java/examples/elements/ink/
keywords:
- कोड उदाहरण
- इंक
- इंक तक पहुँच
- इंक हटाएँ
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java प्रस्तुतियों में इंक आकारों तक पहुँचें और उन्हें हटाएँ, जिसमें PPT, PPTX, और ODP फ़ाइलें शामिल हैं।"
---
यह लेख मौजूदा इंक आकारों तक पहुँचने और उन्हें हटाने के उदाहरण प्रदान करता है **Aspose.Slides for Python via Java** का उपयोग करके।

पैकेज को यहाँ वर्णित अनुसार स्थापित करें [Installation](/slides/hi/python-java/installation/). प्रत्येक उदाहरण `asposeslides` को JVM शुरू करने से पहले इम्पोर्ट करता है, उसके बाद JVM चलने पर API को इम्पोर्ट करता है।

{{% alert color="info" title="Note" %}}
इंक आकार उपयोगकर्ता इनपुट का प्रतिनिधित्व करते हैं जो विशेष उपकरणों से प्राप्त होते हैं। Aspose.Slides नया इंक स्ट्रोक प्रोग्रामेटिक रूप से नहीं बना सकता, लेकिन आप मौजूदा इंक को पढ़ और संशोधित कर सकते हैं।
{{% /alert %}}

## **इंक तक पहुँच**

स्लाइड पर पहले इंक आकार के टैग पढ़ें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpime.startJVM()

from asposeslides.api import Ink, Presentation

presentation = Presentation("ink.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().get_Item(0)
    if isinstance(shape, Ink):
        tags = shape.getCustomData().getTags()
        if tags.size() > 0:
            tag_name = tags.getNameByIndex(0)
            # आवश्यकतानुसार tag_name का उपयोग करें।
finally:
    presentation.dispose()
```

## **इंक हटाएँ**

यदि कोई इंक आकार मौजूद हो तो उसे स्लाइड से हटाएँ।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Ink, Presentation

presentation = Presentation("ink.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    ink = None
    for shape in slide.getShapes():
        if isinstance(shape, Ink):
            ink = shape
            break

    if ink is not None:
        slide.getShapes().remove(ink)
finally:
    presentation.dispose()
```