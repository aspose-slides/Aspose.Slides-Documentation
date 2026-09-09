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
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java का उपयोग करके PowerPoint और OpenDocument स्लाइड्स में वीडियो फ्रेम को प्रोग्रामेटिकली जोड़ने और निकालने के तरीके सीखें। तेज़ गाइड।"
---
## **परिचय**

एक अच्छी तरह से स्थित वीडियो प्रस्तुति में आपके संदेश को अधिक प्रभावशाली बना सकता है और आपके श्रोताओं के साथ सहभागिता स्तर को बढ़ा सकता है।

PowerPoint आपको प्रस्तुति में एक स्लाइड में वीडियो जोड़ने के दो तरीके प्रदान करता है:

* स्थानीय वीडियो जोड़ें या एम्बेड करें (जो आपके कंप्यूटर पर संग्रहित है)
* ऑनलाइन वीडियो जोड़ें (जैसे YouTube जैसे वेब स्रोत से)।

आपको प्रस्तुति में वीडियो (वीडियो ऑब्जेक्ट) जोड़ने के लिए, Aspose.Slides [Video](https://reference.aspose.com/slides/hi/python-java/aspose.slides/video/) क्लास, [VideoFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/videoframe/) क्लास और अन्य संबंधित प्रकार प्रदान करता है।

## **एम्बेडेड वीडियो फ्रेम बनाएं**

यदि वह वीडियो फ़ाइल जिसे आप अपनी स्लाइड में जोड़ना चाहते हैं स्थानीय रूप से संग्रहीत है, तो आप प्रस्तुति में वीडियो एम्बेड करने के लिए एक वीडियो फ्रेम बना सकते हैं।

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएं।
1. इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
1. एक [Video](https://reference.aspose.com/slides/hi/python-java/aspose.slides/video/) ऑब्जेक्ट जोड़ें और वीडियो फ़ाइल डेटा पास करें ताकि प्रस्तुति में वीडियो एम्बेड हो सके।
1. एक [VideoFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/videoframe/) ऑब्जेक्ट जोड़ें ताकि वीडियो के लिए एक फ्रेम बनाया जा सके।
1. संशोधित प्रस्तुति को सहेजें।

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

वैकल्पिक रूप से, आप वीडियो को सीधे उसके फ़ाइल पथ को [addVideoFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shapecollection/#addVideoFrame) मेथड में पास करके जोड़ सकते हैं:

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

## **वेब स्रोतों से वीडियो के साथ वीडियो फ्रेम बनाएं**

Microsoft [PowerPoint 2013 और नई संस्करणों](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) प्रस्तुति में YouTube वीडियो को समर्थन देते हैं। यदि वह वीडियो जिसे आप उपयोग करना चाहते हैं ऑनलाइन उपलब्ध है (उदाहरण के लिए YouTube पर), तो आप उसे अपने प्रस्तुति में उसके वेब लिंक के माध्यम से जोड़ सकते हैं।

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएं।
1. इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
1. एक [VideoFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/videoframe/) ऑब्जेक्ट जोड़ें और वीडियो का लिंक पास करें।
1. वीडियो फ्रेम के लिए थंबनेल सेट करें।
1. प्रस्तुति को सहेजें।

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

## **वीडियो फ्रेम को ट्रिम करें**

Aspose.Slides आपको वीडियो के किस भाग को चलाया जाए, इसे [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/hi/python-java/aspose.slides/videoframe/#setTrimFromStart) और [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/hi/python-java/aspose.slides/videoframe/#setTrimFromEnd) के द्वारा trim-from-start और trim-from-end मान सेट करके नियंत्रित करने देता है। दोनों मान मिलीसेकंड में निर्दिष्ट होते हैं और क्रमशः वीडियो की शुरुआत और अंत से कितना समय छोड़ना है, यह निर्धारित करते हैं। ये सेटिंग्स प्रस्तुति में वीडियो प्लेबैक सेटिंग्स को बदलती हैं; वे एम्बेडेड वीडियो बाइनरी डेटा को काटती या बदलती नहीं हैं।

**ट्रिम सेटिंग्स सेट करें**

एक वीडियो फ्रेम बनाने और उसकी ट्रिम सेटिंग्स सेट करने के लिए:

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएं।
1. एक [Video](https://reference.aspose.com/slides/hi/python-java/aspose.slides/video/) ऑब्जेक्ट को प्रस्तुति में जोड़ें।
1. एक [VideoFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/videoframe/) ऑब्जेक्ट को स्लाइड में जोड़ें।
1. trim-from-start और trim-from-end मान को [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/hi/python-java/aspose.slides/videoframe/#setTrimFromStart) और [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/hi/python-java/aspose.slides/videoframe/#setTrimFromEnd) के द्वारा सेट करें।
1. संशोधित प्रस्तुति को सहेजें।

निम्नलिखित कोड उदाहरण एम्बेडेड वीडियो के प्लेबैक के दौरान पहले 2.5 सेकंड और अंतिम एक सेकंड को छोड़ देता है:

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

**ट्रिम सेटिंग्स पढ़ें**

मौजूदा ट्रिम सेटिंग्स को जांचने के लिए, प्रस्तुति लोड करें, पहले स्लाइड पर आकारों में से [VideoFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/videoframe/) ऑब्जेक्ट खोजें, और मान को [VideoFrame.getTrimFromStart](https://reference.aspose.com/slides/hi/python-java/aspose.slides/videoframe/#getTrimFromStart) और [VideoFrame.getTrimFromEnd](https://reference.aspose.com/slides/hi/python-java/aspose.slides/videoframe/#getTrimFromEnd) के द्वारा पढ़ें।

निम्नलिखित कोड उदाहरण पहले स्लाइड पर पहला वीडियो फ्रेम खोजता है और उसके ट्रिम सेटिंग्स को मिलीसेकंड में रिपोर्ट करता है:

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

## **वीडियो कैप्शन प्रबंधित करें**

Aspose.Slides आपको PowerPoint प्रस्तुतियों में वीडियो फ्रेम के लिए क्लोज्ड कैप्शन प्रबंधित करने देता है। कैप्शन WebVTT फ़ॉर्मेट में संग्रहीत होते हैं और [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/hi/python-java/aspose.slides/videoframe/#getCaptionTracks) मेथड के द्वारा उपलब्ध कराए जाते हैं।

**वीडियो फ्रेम में कैप्शन जोड़ें**

वीडियो फ्रेम में कैप्शन जोड़ने के लिए:

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएं।
1. प्रस्तुति में एक वीडियो जोड़ें।
1. एक [VideoFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/videoframe/) ऑब्जेक्ट को स्लाइड में जोड़ें।
1. [getCaptionTracks](https://reference.aspose.com/slides/hi/python-java/aspose.slides/videoframe/#getCaptionTracks) द्वारा लौटाए गए [CaptionsCollection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/captionscollection/) का उपयोग करके एक WebVTT कैप्शन ट्रैक जोड़ें।
1. संशोधित प्रस्तुति को सहेजें।

निम्नलिखित कोड दिखाता है कि कैसे वीडियो फ्रेम में कैप्शन जोड़ें:

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

    # WebVTT फ़ाइल से एक नया कैप्शन ट्रैक जोड़ें।
    video_frame.getCaptionTracks().add("English", "track.vtt")
    presentation.save("video_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[CaptionsCollection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/captionscollection/) क्लास एक ओवरलोड भी प्रदान करती है जो आपको स्ट्रीम से कैप्शन जोड़ने देती है।

**वीडियो फ्रेम से कैप्शन निकालें**

वीडियो फ्रेम से कैप्शन निकालने के लिए:

1. वीडियो वाली प्रस्तुति को लोड करें।
1. लक्ष्य [VideoFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/videoframe/) ऑब्जेक्ट खोजें।
1. [CaptionsCollection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/captionscollection/) में कैप्शन ट्रैकों के माध्यम से इटररेट करें।
1. प्रत्येक कैप्शन ट्रैक को `.vtt` फ़ाइल में सहेजें।

निम्नलिखित कोड दिखाता है कि कैसे वीडियो फ्रेम से कैप्शन निकालें:

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

प्रत्येक [Captions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/captions/) ऑब्जेक्ट कैप्शन पहचानकर्ता, लेबल, बाइनरी डेटा, और कैप्शन टेक्स्ट को UTF-8 स्ट्रिंग के रूप में उजागर करता है।

**वीडियो फ्रेम से कैप्शन हटाएँ**

वीडियो फ्रेम से कैप्शन हटाने के लिए:

1. वीडियो वाली प्रस्तुति को लोड करें।
1. लक्ष्य [VideoFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/videoframe/) ऑब्जेक्ट प्राप्त करें।
1. [CaptionsCollection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/captionscollection/) से कैप्शन ट्रैक हटाएँ।
1. संशोधित प्रस्तुति को सहेजें।

निम्नलिखित कोड दिखाता है कि कैसे वीडियो फ्रेम से सभी कैप्शन हटाएँ:

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
        # वीडियो फ्रेम से सभी कैप्शन हटाएँ।
        video_frame.getCaptionTracks().clear()
        presentation.save("video_without_captions.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not a video frame.")
finally:
    presentation.dispose()
```

यदि आपको केवल एक कैप्शन ट्रैक हटाना है, तो [clear](https://reference.aspose.com/slides/hi/python-java/aspose.slides/captionscollection/#clear) के बजाय [remove](https://reference.aspose.com/slides/hi/python-java/aspose.slides/captionscollection/#remove) या [removeAt](https://reference.aspose.com/slides/hi/python-java/aspose.slides/captionscollection/#removeAt) मेथड का उपयोग करें।

## **स्लाइड्स से वीडियो निकालें**

स्लाइड्स में वीडियो जोड़ने के अलावा, Aspose.Slides आपको प्रस्तुतियों में एम्बेडेड वीडियो निकालने की अनुमति देता है।

1. [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएं ताकि वीडियो वाली प्रस्तुति लोड हो सके।
2. सभी [Slide](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slide/) ऑब्जेक्ट्स के माध्यम से इटररेट करें।
3. सभी [Shape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/) ऑब्जेक्ट्स के माध्यम से इटररेट करें ताकि एक [VideoFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/videoframe/) मिल सके।
4. वीडियो को डिस्क पर सहेजें।

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

## **FAQ**

**वीडियो फ्रेम के लिए कौन से वीडियो प्लेबैक पैरामीटर बदले जा सकते हैं?**

आप [playback mode](https://reference.aspose.com/slides/hi/python-java/aspose.slides/videoframe/#setPlayMode) (स्वचालित या क्लिक पर) और [looping](https://reference.aspose.com/slides/hi/python-java/aspose.slides/videoframe/#setPlayLoopMode) को नियंत्रित कर सकते हैं। ये विकल्प [VideoFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/videoframe/) ऑब्जेक्ट की प्रॉपर्टीज़ के माध्यम से उपलब्ध हैं।

**वीडियो जोड़ने से PPTX फ़ाइल का आकार प्रभावित होता है क्या?**

हां। जब आप एक स्थानीय वीडियो एम्बेड करते हैं, तो बाइनरी डेटा दस्तावेज़ में शामिल हो जाता है, इसलिए प्रस्तुति का आकार फ़ाइल आकार के अनुपात में बढ़ता है। जब आप एक ऑनलाइन वीडियो जोड़ते हैं, तो एक लिंक और थंबनेल एम्बेड किए जाते हैं, इसलिए आकार वृद्धि कम होती है।

**क्या मैं मौजूदा VideoFrame में वीडियो को उसकी स्थिति और आकार बदले बिना बदल सकता हूं?**

हां। आप फ्रेम के भीतर [video content](https://reference.aspose.com/slides/hi/python-java/aspose.slides/videoframe/#setEmbeddedVideo) को बदल सकते हैं जबकि आकार की ज्योमेट्री को बरकरार रखते हैं; यह मौजूदा लेआउट में मीडिया अपडेट करने का एक सामान्य परिदृश्य है।

**क्या एम्बेडेड वीडियो के कंटेंट टाइप (MIME) का निर्धारण किया जा सकता है?**

हां। एम्बेडेड वीडियो का एक [content type](https://reference.aspose.com/slides/hi/python-java/aspose.slides/video/#getContentType) होता है जिसे आप पढ़ और उपयोग कर सकते हैं, उदाहरण के लिए जब आप इसे डिस्क पर सहेजते हैं।