---
title: VBA मैक्रो
type: docs
weight: 150
url: /hi/python-java/examples/elements/vba-macro/
keywords:
- कोड उदाहरण
- VBA
- मैक्रो
- PowerPoint
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java का उपयोग करके PowerPoint प्रस्तुतियों में VBA मैक्रो को जोड़ना, एक्सेस करना और हटाना, स्पष्ट और व्यावहारिक कोड उदाहरणों के साथ."
---
यह लेख **Aspose.Slides for Python via Java** का उपयोग करके VBA मैक्रो को जोड़ने, एक्सेस करने और निकालने की प्रक्रिया दर्शाता है।

पैकेज को [Installation](/slides/hi/python-java/installation/) में वर्णित अनुसार स्थापित करें। प्रत्येक उदाहरण JVM शुरू करने से पहले `asposeslides` को इम्पोर्ट करता है, और JVM चलने के बाद API को इम्पोर्ट करता है।

## **VBA मैक्रो जोड़ें**

VBA प्रोजेक्ट और एक साधारण मैक्रो मॉड्यूल के साथ एक प्रस्तुति बनाएँ।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VbaProject

presentation = Presentation()
try:
    presentation.setVbaProject(VbaProject())

    module = presentation.getVbaProject().getModules().addEmptyModule("Module")
    module.setSourceCode('Sub Test()\n MsgBox "Hi" \nEnd Sub')
finally:
    presentation.dispose()
```

## **VBA मैक्रो तक पहुँचें**

VBA प्रोजेक्ट से पहला मॉड्यूल प्राप्त करें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VbaProject

presentation = Presentation()
try:
    presentation.setVbaProject(VbaProject())

    module = presentation.getVbaProject().getModules().addEmptyModule("Module")
    module.setSourceCode('Sub Test()\n MsgBox "Hi" \nEnd Sub')

    first_module = presentation.getVbaProject().getModules().get_Item(0)
finally:
    presentation.dispose()
```

## **VBA मैक्रो हटाएँ**

VBA प्रोजेक्ट से एक मॉड्यूल हटाएँ।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VbaProject

presentation = Presentation()
try:
    presentation.setVbaProject(VbaProject())

    module = presentation.getVbaProject().getModules().addEmptyModule("Module")
    module.setSourceCode('Sub Test()\n MsgBox "Hi" \nEnd Sub')

    presentation.getVbaProject().getModules().remove(module)
finally:
    presentation.dispose()
```