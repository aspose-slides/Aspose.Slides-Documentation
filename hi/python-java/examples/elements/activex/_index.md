---
title: ActiveX
type: docs
weight: 200
url: /hi/python-java/examples/elements/activex/
keywords:
- कोड उदाहरण
- ActiveX
- ActiveX नियंत्रण
- ActiveX गुण
- PowerPoint
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java का उपयोग करके PowerPoint प्रस्तुतियों में ActiveX नियंत्रण जोड़ने, एक्सेस करने, हटाने और कॉन्फ़िगर करने के लिए व्यावहारिक कोड उदाहरण प्रदान करें।"
---
यह लेख दर्शाता है कि कैसे एक प्रस्तुति में **Aspose.Slides for Python via Java** का उपयोग करके ActiveX नियंत्रण को जोड़ें, एक्सेस करें, हटाएँ और कॉन्फ़िगर करें।

पैकेज को [Installation](/slides/hi/python-java/installation/) में वर्णित अनुसार स्थापित करें। प्रत्येक उदाहरण JVM शुरू करने से पहले `asposeslides` इम्पोर्ट करता है, उसके बाद JVM चलने पर API इम्पोर्ट करता है। एक्सेस और हटाने के उदाहरण पहले उदाहरण द्वारा बनाई गई `add_activex.pptm` फ़ाइल का उपयोग करते हैं।

## **ActiveX नियंत्रण जोड़ें**

पहली स्लाइड पर एक Windows Media Player नियंत्रण सम्मिलित करें और प्रस्तुति को PPTM फ़ाइल के रूप में सहेजें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ControlType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Windows Media Player नियंत्रण जोड़ें।
    control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 100, 50)
    control.getProperties().set_Item("autoStart", "false")

    presentation.save("add_activex.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```

## **ActiveX नियंत्रण तक पहुँचें**

स्लाइड पर पहले ActiveX नियंत्रण का नाम और स्वतः प्लेबैक सेटिंग पढ़ें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("add_activex.pptm")
try:
    if presentation.getSlides().size() > 0:
        slide = presentation.getSlides().get_Item(0)
        if slide.getControls().size() > 0:
            # पहले ActiveX नियंत्रण तक पहुँचें।
            control = slide.getControls().get_Item(0)
            print("Control Name:", control.getName())
            print("autoStart:", control.getProperties().get_Item("autoStart"))
        else:
            print("The first slide contains no ActiveX controls.")
    else:
        print("The presentation contains no slides.")
finally:
    presentation.dispose()
```

## **ActiveX नियंत्रण हटाएँ**

स्लाइड से पहला ActiveX नियंत्रण हटाएँ और संशोधित प्रस्तुति को सहेजें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("add_activex.pptm")
try:
    if presentation.getSlides().size() > 0:
        slide = presentation.getSlides().get_Item(0)
        if slide.getControls().size() > 0:
            # पहले ActiveX नियंत्रण को हटाएँ।
            slide.getControls().removeAt(0)
        else:
            print("The first slide contains no ActiveX controls.")
    else:
        print("The presentation contains no slides.")

    presentation.save("removed_activex.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```

## **ActiveX गुण सेट करें**

एक Windows Media Player नियंत्रण जोड़ें, स्वतः प्लेबैक को निष्क्रिय करें, और उसके प्लेबैक नियंत्रणों को छिपाएँ। प्रॉपर्टी मानों को स्ट्रिंग के रूप में असाइन करने के लिए [ControlPropertiesCollection.set_Item](https://reference.aspose.com/slides/hi/python-java/aspose.slides/controlpropertiescollection/#set_Item) का उपयोग करें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ControlType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Windows Media Player नियंत्रण जोड़ें और उसकी गुण कॉन्फ़िगर करें।
    control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 150, 50)
    properties = control.getProperties()
    properties.set_Item("autoStart", "false")
    properties.set_Item("uiMode", "none")

    presentation.save("set_activex_props.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```