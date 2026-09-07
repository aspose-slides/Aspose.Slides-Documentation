---
title: वीडियो
type: docs
weight: 80
url: /hi/python-java/examples/elements/video/
keywords:
- कोड उदाहरण
- वीडियो
- वीडियो फ्रेम
- वीडियो जोड़ें
- वीडियो एक्सेस करें
- वीडियो हटाएँ
- वीडियो प्लेबैक
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "PowerPoint और OpenDocument प्रस्तुतियों में वीडियो फ्रेम जोड़ने, एक्सेस करने, हटाने और कॉन्फ़िगर करने के लिए Python के माध्यम से Java के लिए Aspose.Slides का उपयोग करें।"
---
यह लेख **Aspose.Slides for Python via Java** का उपयोग करके वीडियो फ्रेम जोड़ने और प्लेबैक विकल्प सेट करने का प्रदर्शन करता है।

पैकेज को जैसा कि [Installation](/slides/hi/python-java/installation/) में वर्णित है, स्थापित करें। प्रत्येक उदाहरण JVM शुरू करने से पहले `asposeslides` आयात करता है, और JVM चलने के बाद API आयात करता है।

## **वीडियो फ्रेम जोड़ें**

बाहरी वीडियो फ़ाइल को संदर्भित करने वाला एक वीडियो फ्रेम सम्मिलित करें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpime.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # वीडियो फ़ाइल से जुड़े एक वीडियो फ़्रेम को जोड़ें।
    video_frame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4")
finally:
    presentation.dispose()
```

## **एक वीडियो फ्रेम प्राप्त करें**

स्लाइड में जोड़ा गया पहला वीडियो फ्रेम प्राप्त करें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4")

    # स्लाइड पर पहला वीडियो फ़्रेम एक्सेस करें।
    first_video = None
    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            first_video = shape
            break

    if first_video is None:
        print("The slide contains no video frames.")
finally:
    presentation.dispose()
```

## **एक वीडियो फ्रेम हटाएँ**

स्लाइड से एक वीडियो फ्रेम हटाएँ।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    video_frame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4")

    # वीडियो फ़्रेम हटाएँ।
    slide.getShapes().remove(video_frame)
finally:
    presentation.dispose()
```

## **वीडियो प्लेबैक सेट करें**

स्लाइड प्रदर्शित होने पर वीडियो को स्वचालित रूप से चलाने के लिए कॉन्फ़िगर करें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoPlayModePreset

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    video_frame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4")

    # वीडियो को स्वचालित रूप से चलाने के लिए कॉन्फ़िगर करें।
    video_frame.setPlayMode(VideoPlayModePreset.Auto)
finally:
    presentation.dispose()
```