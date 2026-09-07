---
title: सेक्शन
type: docs
weight: 90
url: /hi/python-java/examples/elements/section/
keywords:
- कोड उदाहरण
- सेक्शन
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java में प्रस्तुति सेक्शन को प्रबंधित करें: सेक्शन को जोड़ना, एक्सेस करना, हटाना और नाम बदलना, पाइथन कोड उदाहरणों के साथ।"
---
उदाहरण: प्रस्तुति सेक्शन को प्रोग्रामेटिक रूप से जोड़ना, एक्सेस करना, हटाना और नाम बदलना **Aspose.Slides for Python via Java** का उपयोग करके।

पैकेज को [Installation](/slides/hi/python-java/installation/) में वर्णित अनुसार स्थापित करें। प्रत्येक उदाहरण `asposeslides` को JVM शुरू करने से पहले इम्पोर्ट करता है, फिर JVM चलने के बाद API को इम्पोर्ट करता है।

## **सेक्शन जोड़ें**
एक सेक्शन बनाएं जो किसी विशिष्ट स्लाइड से शुरू होता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # सेक्शन की शुरुआत को चिह्नित करने वाली स्लाइड निर्दिष्ट करें।
    presentation.getSections().addSection("New Section", slide)
finally:
    presentation.dispose()
```

## **सेक्शन एक्सेस करें**
प्रस्तुति से सेक्शन की जानकारी पढ़ें।

```python
import jpide
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    presentation.getSections().addSection("My Section", slide)

    # इंडेक्स द्वारा सेक्शन तक पहुंचें।
    section = presentation.getSections().get_Item(0)
    section_name = section.getName()
    print(section_name)
finally:
    presentation.dispose()
```

## **सेक्शन हटाएँ**
पहले जोड़े गए सेक्शन को हटाएं।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    section = presentation.getSections().addSection("Temporary Section", slide)

    # पहले सेक्शन को हटाएँ।
    presentation.getSections().removeSection(section)
finally:
    presentation.dispose()
```

## **सेक्शन का नाम बदलें**
मौजूदा सेक्शन का नाम बदलें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    presentation.getSections().addSection("Old Name", slide)

    section = presentation.getSections().get_Item(0)
    section.setName("New Name")
finally:
    presentation.dispose()
```