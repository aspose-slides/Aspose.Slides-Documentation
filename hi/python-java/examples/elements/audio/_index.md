---
title: ऑडियो
type: docs
weight: 70
url: /hi/python-java/examples/elements/audio/
keywords:
- कोड उदाहरण
- ऑडियो
- ऑडियो फ्रेम
- ऑडियो जोड़ें
- ऑडियो तक पहुँचें
- ऑडियो हटाएँ
- ऑडियो प्लेबैक
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "PowerPoint और OpenDocument प्रस्तुतियों में ऑडियो फ्रेम को जोड़ने, एक्सेस करने, हटाने और कॉन्फ़िगर करने के लिए Java के माध्यम से Python के लिए Aspose.Slides का उपयोग करें।"
---
यह लेख दर्शाता है कि कैसे ऑडियो फ्रेम को एम्बेड किया जाए और **Aspose.Slides for Python via Java** का उपयोग करके प्लेबैक को नियंत्रित किया जाए। निम्नलिखित उदाहरण बुनियादी ऑडियो संचालन दिखाते हैं।

पैकेज को स्थापित करने के लिए [Installation](/slides/hi/python-java/installation/) में वर्णित चरणों का पालन करें। प्रत्येक उदाहरण `asposeslides` को JVM शुरू करने से पहले इम्पोर्ट करता है, फिर JVM चलने के बाद API को इम्पोर्ट करता है।

## **ऑडियो फ्रेम जोड़ें**

एक खाली ऑडियो फ्रेम डालें जिसे बाद में एम्बेडेड साउंड डेटा रख सके।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.io import ByteArrayInputStream
from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    audio_data = jpype.JArray(jpype.JByte)(0)
    audio_stream = ByteArrayInputStream(audio_data)

    # एक खाली ऑडियो फ्रेम बनाएं (ऑडियो बाद में एम्बेड किया जाएगा).
finally:
    presentation.dispose()
```

## **ऑडियो फ्रेम तक पहुंचें**

यह कोड स्लाइड पर पहला ऑडियो फ्रेम प्राप्त करता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.io import ByteArrayInputStream
from asposeslides.api import AudioFrame, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    audio_data = jpype.JArray(jpype.JByte)(0)
    audio_stream = ByteArrayInputStream(audio_data)
    slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio_stream)

    # स्लाइड पर पहला ऑडियो फ्रेम तक पहुँचें।
    first_audio = None
    for shape in slide.getShapes():
        if isinstance(shape, AudioFrame):
            first_audio = shape
            break

    if first_audio is None:
        print("The slide contains no audio frames.")
finally:
    presentation.dispose()
```

## **ऑडियो फ्रेम हटाएँ**

पहले जोड़ा गया ऑडियो फ्रेम हटाएँ।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.io import ByteArrayInputStream
from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    audio_data = jpype.JArray(jpype.JByte)(0)
    audio_stream = ByteArrayInputStream(audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio_stream)

    # ऑडियो फ्रेम हटाएँ.
    slide.getShapes().remove(audio_frame)
finally:
    presentation.dispose()
```

## **ऑडियो प्लेबैक सेट करें**

स्लाइड दिखने पर ऑडियो फ्रेम को स्वतः चलाने के लिए कॉन्फ़िगर करें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.io import ByteArrayInputStream
from asposeslides.api import AudioPlayModePreset, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    audio_data = jpype.JArray(jpype.JByte)(0)
    audio_stream = ByteArrayInputStream(audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio_stream)

    # स्लाइड के दिखाई देने पर स्वचालित रूप से चलाएँ।
    audio_frame.setPlayMode(AudioPlayModePreset.Auto)
finally:
    presentation.dispose()
```