---
title: नोट
type: docs
weight: 240
url: /hi/python-java/examples/elements/note/
keywords:
- कोड उदाहरण
- नोट
- स्पीकर नोट
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java में स्लाइड नोट्स के साथ काम करें: PowerPoint और OpenDocument प्रस्तुतियों में स्पीकर नोट्स जोड़ें, पढ़ें, हटाएँ, और अपडेट करें।"
---
यह लेख **Aspose.Slides for Python via Java** का उपयोग करके नोट्स स्लाइड्स जोड़ने, पढ़ने, हटाने और अपडेट करने का प्रदर्शन करता है।

पैकेज को [Installation](/slides/hi/python-java/installation/) में वर्णित अनुसार स्थापित करें। प्रत्येक उदाहरण JVM को शुरू करने से पहले `asposeslides` आयात करता है, उसके बाद JVM चलने पर API आयात करता है।

## **नोट्स स्लाइड जोड़ें**

एक नोट्स स्लाइड बनाएं और उसमें पाठ असाइन करें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    notes_slide = slide.getNotesSlideManager().addNotesSlide()
    notes_slide.getNotesTextFrame().setText("My note")
finally:
    presentation.dispose()
```

## **नोट्स स्लाइड तक पहुँचें**

एक मौजूदा नोट्स स्लाइड से पाठ पढ़ें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    notes_slide = slide.getNotesSlideManager().addNotesSlide()
    notes_slide.getNotesTextFrame().setText("My note")

    notes = notes_slide.getNotesTextFrame().getText()
    print(notes)
finally:
    presentation.dispose()
```

## **नोट्स स्लाइड हटाएँ**

एक स्लाइड के साथ जुड़े नोट्स स्लाइड को हटाएं।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getNotesSlideManager().addNotesSlide()
    slide.getNotesSlideManager().removeNotesSlide()
finally:
    presentation.dispose()
```

## **नोट्स पाठ अपडेट करें**

नोट्स स्लाइड का पाठ बदलें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    notes_slide = slide.getNotesSlideManager().addNotesSlide()
    notes_slide.getNotesTextFrame().setText("Old")
    notes_slide.getNotesTextFrame().setText("Updated")
finally:
    presentation.dispose()
```