---
title: Python का उपयोग करके प्रस्तुतियों में वीडियो फ्रेम प्रबंधित करें
linktitle: वीडियो फ्रेम
type: docs
weight: 10
url: /hi/python-java/video-frame/
keywords:
- वीडियो जोड़ें
- वीडियो बनाएं
- वीडियो एम्बेड करें
- वीडियो निकालें
- वीडियो पुनः प्राप्त करें
- वीडियो फ्रेम
- वेब स्रोत
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java का उपयोग करके PowerPoint और OpenDocument स्लाइड्स में प्रोग्रामेटिक रूप से वीडियो फ्रेम जोड़ने और निकालने के बारे में जानें। तेज़ है‑तो‑करें गाइड।"
---
## **परिचय**

एक अच्छी तरह से रखी गई वीडियो प्रस्तुति में आपके संदेश को अधिक प्रभावशाली बना सकती है और दर्शकों के साथ जुड़ाव स्तर को बढ़ा सकती है।

PowerPoint दो तरीकों से प्रस्तुति की स्लाइड में वीडियो जोड़ने की अनुमति देता है:

* स्थानीय वीडियो (अपने कंप्यूटर पर संग्रहीत) जोड़ें या एम्बेड करें
* ऑनलाइन वीडियो (उदाहरण के लिए YouTube) जोड़ें

आपको प्रस्तुति में वीडियो (video objects) जोड़ने के लिए, Aspose.Slides निम्नलिखित प्रदान करता है: [Video](https://reference.aspose.com/slides/hi/python-java/aspose.slides/video/) क्लास, [VideoFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/videoframe/) क्लास, और अन्य संबंधित प्रकार।

## **एम्बेडेड वीडियो फ्रेम बनाना**

यदि आप जिस वीडियो फ़ाइल को अपनी स्लाइड में जोड़ना चाहते हैं वह स्थानीय रूप से संग्रहीत है, तो आप प्रस्तुति में वीडियो को एम्बेड करने के लिए एक वीडियो फ्रेम बना सकते हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएँ।
1. उसकी अनुक्रमणिका के माध्यम से स्लाइड का संदर्भ प्राप्त करें।
1. एक [Video](https://reference.aspose.com/slides/hi/python-java/aspose.slides/video/) ऑब्जेक्ट जोड़ें और वीडियो फ़ाइल डेटा को पास करके वीडियो को प्रस्तुति में एम्बेड करें।
1. वीडियो के लिए एक फ्रेम बनाने हेतु एक [VideoFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/videoframe/) ऑब्जेक्ट जोड़ें।
1. संशोधित प्रस्तुति को सहेजें।

यह Python कोड दर्शाता है कि स्थानीय रूप से संग्रहीत वीडियो को प्रस्तुति में कैसे जोड़ें:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    video_data = Path("Wildlife.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)
    video = presentation.getVideos().addVideo(java_video_data)
    presentation.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video)
    presentation.save("pres-with-video.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

वैकल्पिक रूप से, आप वीडियो को सीधे उसकी फ़ाइल पथ पास कर के भी जोड़ सकते हैं, जैसे कि [addVideoFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shapecollection/#addVideoFrame) मेथड का उपयोग करके:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    video_frame = slide.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi")
finally:
    presentation.dispose()
```


## **वेब स्रोतों से वीडियो के साथ वीडियो फ्रेम बनाना**

Microsoft [PowerPoint 2013 और बाद के संस्करण](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) प्रस्तुति में YouTube वीडियो का समर्थन करते हैं। यदि आप जिस वीडियो का उपयोग करना चाहते हैं वह ऑनलाइन उपलब्ध है (जैसे YouTube पर), तो आप उसके वेब लिंक के माध्यम से इसे अपनी प्रस्तुति में जोड़ सकते हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएँ
1. उसकी अनुक्रमणिका के माध्यम से स्लाइड का संदर्भ प्राप्त करें।
1. एक [VideoFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/videoframe/) ऑब्जेक्ट जोड़ें और वीडियो का लिंक पास करें।
1. वीडियो फ्रेम के लिए एक थंबनेल सेट करें।
1. प्रस्तुति को सहेजें।

यह Python कोड दर्शाता है कि वेब से वीडियो को PowerPoint प्रस्तुति की स्लाइड में कैसे जोड़ें:

```python
from urllib.request import urlopen

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoPlayModePreset

video_id = "Tj75Arhq5ho"
presentation = Presentation()
try:
    video_frame = presentation.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 427, 240, "https://www.youtube.com/embed/" + video_id)
    video_frame.setPlayMode(VideoPlayModePreset.Auto)

    # थंबनेल लोड करें।
    thumbnail_uri = "https://img.youtube.com/vi/" + video_id + "/hqdefault.jpg"
    try:
        with urlopen(thumbnail_uri) as response:
            thumbnail_data = response.read()
        java_thumbnail_data = jpype.JArray(jpype.JByte)(thumbnail_data)
        thumbnail = presentation.getImages().addImage(java_thumbnail_data)
        video_frame.getPictureFormat().getPicture().setImage(thumbnail)
    except OSError as error:
        print("Could not load the thumbnail:", error)

    presentation.save("out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **वीडियो फ्रेम को ट्रिम करना**

Aspose.Slides आपको [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/hi/python-java/aspose.slides/videoframe/#setTrimFromStart) और [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/hi/python-java/aspose.slides/videoframe/#setTrimFromEnd) के माध्यम से trim‑from‑start और trim‑from‑end मान सेट करके यह नियंत्रित करने की अनुमति देता है कि वीडियो का कौन‑सा भाग चलाया जाएगा। दोनों मान मिलिसेकंड में निर्दिष्ट होते हैं और क्रमशः वीडियो की शुरुआत और अंत से छोड़े जाने वाले समय को परिभाषित करते हैं। ये सेटिंग्स प्रस्तुति में वीडियो प्लेबैक सेटिंग को बदलती हैं; वे एम्बेडेड वीडियो के बाइनरी डेटा को नहीं काटती या संशोधित करती हैं।

**Trim सेटिंग्स सेट करना**

एक वीडियो फ्रेम बनाकर उसकी trim सेटिंग्स सेट करने के लिए:

1. [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएँ।
1. प्रस्तुति में एक [Video](https://reference.aspose.com/slides/hi/python-java/aspose.slides/video/) ऑब्जेक्ट जोड़ें।
1. एक स्लाइड में एक [VideoFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/videoframe/) ऑब्जेक्ट जोड़ें।
1. [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/hi/python-java/aspose.slides/videoframe/#setTrimFromStart) और [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/hi/python-java/aspose.slides/videoframe/#setTrimFromEnd) के द्वारा trim‑from‑start और trim‑from‑end मान सेट करें।
1. संशोधित प्रस्तुति को सहेजें।

निम्नलिखित कोड उदाहरण प्लेबैक के दौरान एम्बेडेड वीडियो के पहले 2.5 सेकंड और अंतिम एक सेकंड को छोड़ देता है:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    video_data = Path("video.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)
    video = presentation.getVideos().addVideo(java_video_data)
    slide = presentation.getSlides().get_Item(0)
    video_frame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video)

    video_frame.setTrimFromStart(2500.0)
    video_frame.setTrimFromEnd(1000.0)
    presentation.save("video_with_trim.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**Trim सेटिंग्स पढ़ना**

मौजूदा trim सेटिंग्स का निरीक्षण करने के लिए, एक प्रस्तुति लोड करें, पहली स्लाइड पर शैप्स में से एक [VideoFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/videoframe/) ऑब्जेक्ट खोजें, और [VideoFrame.getTrimFromStart](https://reference.aspose.com/slides/hi/python-java/aspose.slides/videoframe/#getTrimFromStart) तथा [VideoFrame.getTrimFromEnd](https://reference.aspose.com/slides/hi/python-java/aspose.slides/videoframe/#getTrimFromEnd) के माध्यम से मान पढ़ें।

निम्नलिखित कोड उदाहरण पहली स्लाइड पर पहला वीडियो फ्रेम खोजता है और उसके trim सेटिंग्स को मिलिसेकंड में रिपोर्ट करता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation("video_with_trim.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            trim_from_start = shape.getTrimFromStart()
            trim_from_end = shape.getTrimFromEnd()
            print(f"Trim from start: {trim_from_start} ms")
            print(f"Trim from end: {trim_from_end} ms")
            break
finally:
    presentation.dispose()
```

## **वीडियो कैप्शन प्रबंधित करना**

Aspose.Slides आपको PowerPoint प्रस्तुतियों में वीडियो फ्रेम के लिए क्लोज्ड कैप्शन प्रबंधित करने की सुविधा देता है। कैप्शन WebVTT फ़ॉर्मेट में संग्रहीत होते हैं और [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/hi/python-java/aspose.slides/videoframe/#getCaptionTracks) मेथड के माध्यम से उपलब्ध होते हैं।

**वीडियो फ्रेम में कैप्शन जोड़ना**

वीडियो फ्रेम में कैप्शन जोड़ने के लिए:

1. [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएँ।
1. प्रस्तुति में एक वीडियो जोड़ें।
1. एक स्लाइड में एक [VideoFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/videoframe/) ऑब्जेक्ट जोड़ें।
1. [getCaptionTracks](https://reference.aspose.com/slides/hi/python-java/aspose.slides/videoframe/#getCaptionTracks) द्वारा लौटाए गए [CaptionsCollection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/captionscollection/) का उपयोग करके एक WebVTT कैप्शन ट्रैक जोड़ें।
1. संशोधित प्रस्तुति को सहेजें।

निम्नलिखित कोड दर्शाता है कि वीडियो फ्रेम में कैप्शन कैसे जोड़ें:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    video_data = Path("video.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)
    video = presentation.getVideos().addVideo(java_video_data)
    slide = presentation.getSlides().get_Item(0)
    video_frame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video)

    # WebVTT फ़ाइल से नया कैप्शन ट्रैक जोड़ें।
    video_frame.getCaptionTracks().add("English", "track.vtt")
    presentation.save("video_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[CaptionsCollection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/captionscollection/) क्लास एक ओवरलोड भी प्रदान करता है जिससे आप स्ट्रीम से कैप्शन जोड़ सकते हैं।

**वीडियो फ्रेम से कैप्शन निकालना**

वीडियो फ्रेम से कैप्शन निकालने के लिए:

1. उस प्रस्तुति को लोड करें जिसमें वीडियो हो।
1. लक्ष्य [VideoFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/videoframe/) ऑब्जेक्ट खोजें।
1. [CaptionsCollection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/captionscollection/) में प्रत्येक कैप्शन ट्रैक पर पुनरावृत्ति करें।
1. प्रत्येक कैप्शन ट्रैक को `.vtt` फ़ाइल में सहेजें।

निम्नलिखित कोड दर्शाता है कि वीडियो फ्रेम से कैप्शन कैसे निकालेँ:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation("video_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            for caption_track in shape.getCaptionTracks():
                # कैप्शन ट्रैक को WebVTT फ़ाइल में सहेजें।
                file_path = Path(str(caption_track.getCaptionId()) + ".vtt")
                caption_data = bytes(caption_track.getBinaryData())
                file_path.write_bytes(caption_data)
finally:
    presentation.dispose()
```

प्रत्येक [Captions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/captions/) ऑब्जेक्ट कैप्शन पहचानकर्ता, लेबल, बाइनरी डेटा, और UTF‑8 स्ट्रिंग के रूप में कैप्शन टेक्स्ट प्रदर्शित करता है।

**वीडियो फ्रेम से कैप्शन हटाना**

वीडियो फ्रेम से कैप्शन हटाने के लिए:

1. उस प्रस्तुति को लोड करें जिसमें वीडियो हो।
1. लक्ष्य [VideoFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/videoframe/) ऑब्जेक्ट प्राप्त करें।
1. [CaptionsCollection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/captionscollection/) से कैप्शन ट्रैक हटाएँ।
1. संशोधित प्रस्तुति को सहेजें।

निम्नलिखित कोड दर्शाता है कि वीडियो फ्रेम से सभी कैप्शन कैसे हटाएँ:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoFrame

presentation = Presentation("video_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    video_frame = slide.getShapes().get_Item(0)
    if isinstance(video_frame, VideoFrame):
        # वीडियो फ़्रेम से सभी कैप्शन हटाएँ।
        video_frame.getCaptionTracks().clear()
        presentation.save("video_without_captions.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not a video frame.")
finally:
    presentation.dispose()
```

यदि आपको केवल एक ही कैप्शन ट्रैक हटाना है, तो सभी को साफ़ करने के बजाय [remove](https://reference.aspose.com/slides/hi/python-java/aspose.slides/captionscollection/#remove) या [removeAt](https://reference.aspose.com/slides/hi/python-java/aspose.slides/captionscollection/#removeAt) मेथड का उपयोग करें।

## **स्लाइड्स से वीडियो निकालना**

स्लाइड्स में वीडियो जोड़ने के अलावा, Aspose.Slides आपको प्रस्तुति में एम्बेडेड वीडियो निकालने की भी अनुमति देता है।

1. वीडियो वाली प्रस्तुति लोड करने के लिए [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएँ।
2. सभी [Slide](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slide/) ऑब्जेक्ट्स पर इटररेट करें।
3. सभी [Shape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/) ऑब्जेक्ट्स पर इटररेट करें ताकि एक [VideoFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/videoframe/) मिल सके।
4. वीडियो को डिस्क पर सहेजें।

यह Python कोड दर्शाता है कि प्रस्तुति स्लाइड से वीडियो कैसे निकालें:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation("VideoSample.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, VideoFrame):
                video = shape.getEmbeddedVideo()
                if video is not None:
                    content_type = str(video.getContentType())
                    file_extension = content_type.split("/", 1)[-1]
                    video_data = bytes(video.getBinaryData())
                    Path("testing2." + file_extension).write_bytes(video_data)
                else:
                    print("The video frame has no embedded video.")
finally:
    presentation.dispose()
```

## **अक्सर पूछे जाने वाले प्रश्न**

**कौन‑से वीडियो प्लेबैक पैरामीटर VideoFrame के लिए बदले जा सकते हैं?**

आप [playback mode](https://reference.aspose.com/slides/hi/python-java/aspose.slides/videoframe/#setPlayMode) (ऑटो या क्लिक पर) और [looping](https://reference.aspose.com/slides/hi/python-java/aspose.slides/videoframe/#setPlayLoopMode) को नियंत्रित कर सकते हैं। ये विकल्प [VideoFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/videoframe/) ऑब्जेक्ट की प्रॉपर्टीज़ के माध्यम से उपलब्ध हैं।

**क्या वीडियो जोड़ने से PPTX फ़ाइल का आकार बढ़ता है?**

हां। जब आप स्थानीय वीडियो एम्बेड करते हैं, तो बाइनरी डेटा दस्तावेज़ में शामिल हो जाता है, इसलिए प्रस्तुति का आकार फ़ाइल के आकार के अनुपात में बढ़ता है। जब आप ऑनलाइन वीडियो जोड़ते हैं, तो केवल लिंक और थंबनेल एम्बेड होते हैं, इसलिए आकार वृद्धि कम होती है।

**क्या मैं मौजूदा VideoFrame में वीडियो को उसकी स्थिति और आकार बदले बिना बदल सकता हूँ?**

हां। आप फ्रेम के भीतर [video content](https://reference.aspose.com/slides/hi/python-java/aspose.slides/videoframe/#setEmbeddedVideo) को बदल सकते हैं जबकि शैप की ज्यामिति बरकरार रहती है; यह मौजूदा लेआउट में मीडिया अपडेट करने का सामान्य परिदृश्य है।

**क्या एम्बेडेड वीडियो की सामग्री प्रकार (MIME) निर्धारित की जा सकती है?**

हां। एम्बेडेड वीडियो का एक [content type](https://reference.aspose.com/slides/hi/python-java/aspose.slides/video/#getContentType) होता है जिसे आप पढ़ और उपयोग कर सकते हैं, उदाहरण के लिए इसे डिस्क पर सहेजते समय।