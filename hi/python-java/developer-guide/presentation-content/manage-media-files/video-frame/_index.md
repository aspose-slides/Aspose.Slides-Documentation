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
- वीडियो प्राप्त करें
- वीडियो फ्रेम
- वेब स्रोत
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java का उपयोग करके PowerPoint और OpenDocument स्लाइड्स में प्रोग्रामेटिक रूप से वीडियो फ्रेम जोड़ने और निकालने को सीखें। तेज़ कैसे-करें गाइड।"
---
## **परिचय**

वीडियो विचारों को समझाने और दर्शकों को जोड़ने में मदद कर सकते हैं। Aspose.Slides for Python via Java आपको स्लाइड्स में वीडियो फ्रेम जोड़ने, प्लेबैक सेटिंग्स को समायोजित करने, कैप्शन प्रबंधित करने और एम्बेडेड वीडियो डेटा निकालने देता है।

PowerPoint स्थानीय वीडियो और ऑनलाइन वीडियो के लिंक, जैसे YouTube वीडियो, को समर्थन देता है।

वीडियो डेटा और वीडियो फ्रेम को प्रदर्शित करने के लिए, Aspose.Slides [Video](https://reference.aspose.com/slides/python-java/aspose.slides/video/) class, [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) class, और अन्य संबंधित प्रकार प्रदान करता है।

## **एक एम्बेडेड वीडियो फ्रेम बनाएं**

यदि वह वीडियो फ़ाइल जिसे आप अपनी स्लाइड में जोड़ना चाहते हैं स्थानीय रूप से संग्रहीत है, तो आप एक वीडियो फ्रेम बना सकते हैं जिससे वीडियो को अपनी प्रस्तुति में एम्बेड किया जा सके।

यह उदाहरण मौजूदा प्रस्तुति की पहली स्लाइड पर एक स्थानीय वीडियो एम्बेड करता है और परिणाम को सहेजता है। फ्रेम के निर्देशांक और आयाम पॉइंट्स में होते हैं। Python डिस्क से वीडियो बाइट्स पढ़ता है, और JPype उन्हें एक Java बाइट एरे में बदलता है इससे पहले कि वीडियो को प्रस्तुति में जोड़ा जाए।

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    video_data = Path("video.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)

    video = presentation.getVideos().addVideo(java_video_data)
    slide.getShapes().addVideoFrame(10, 10, 150, 250, video)

    presentation.save("embedded_video.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

आप सीधे स्थानीय वीडियो पाथ को [addVideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addVideoFrame) में पास भी कर सकते हैं। यह उदाहरण नई प्रस्तुति की पहली स्लाइड पर वीडियो एम्बेड करता है। वीडियो को प्रस्तुति सहेजे जाने तक उपलब्ध रहना चाहिए।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getShapes().addVideoFrame(50, 150, 300, 150, "video.avi")

    presentation.save("video_from_path.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **वेब स्रोत से वीडियो के साथ वीडियो फ़्रेम बनाएं**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) प्रस्तुति में ऑनलाइन वीडियो का समर्थन करता है। आप एक वीडियो फ्रेम बना सकते हैं जो ऑनलाइन वीडियो, जैसे YouTube वीडियो, से लिंक करता है।

यह उदाहरण पहली स्लाइड में एक YouTube वीडियो लिंक और थंबनेल जोड़ता है। किसी अन्य वीडियो के उपयोग के लिए वीडियो पहचानकर्ता को बदलें। [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) मेथड स्वचालित प्लेबैक का अनुरोध करता है। थंबनेल डाउनलोड करने और वीडियो चलाने के लिए इंटरनेट एक्सेस आवश्यक है। प्रस्तुति व्यूअर को भी ऑनलाइन वीडियो प्लेबैक का समर्थन होना चाहिए।

```python
from urllib.request import urlopen

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoPlayModePreset

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    video_id = "aqz-KE-bpKQ"
    video_url = "https://www.youtube.com/embed/" + video_id
    video_frame = slide.getShapes().addVideoFrame(10, 10, 427, 240, video_url)
    video_frame.setPlayMode(VideoPlayModePreset.Auto)

    thumbnail_url = "https://img.youtube.com/vi/" + video_id + "/hqdefault.jpg"
    with urlopen(thumbnail_url) as response:
        thumbnail_data = response.read()
    java_thumbnail_data = jpype.JArray(jpype.JByte)(thumbnail_data)
    thumbnail = presentation.getImages().addImage(java_thumbnail_data)
    video_frame.getPictureFormat().getPicture().setImage(thumbnail)

    presentation.save("online_video.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **पूरी स्क्रीन मोड में वीडियो चलाएँ**

प्रशिक्षण प्रस्तुति में आप सॉफ़्टवेयर डेमोंस्ट्रेशन को पूरी स्क्रीन मोड में चला सकते हैं ताकि दर्शकों को विवरण दिखे। प्लेबैक के दौरान इस व्यवहार को सक्षम करने के लिए `True` के साथ [setFullScreenMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setFullScreenMode) को कॉल करें।

यह उदाहरण एक प्रस्तुति खोलता है, पहली स्लाइड पर पहला [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) खोजता है, और पूरी स्क्रीन प्लेबैक को सक्षम करता है। इनपुट प्रस्तुति में कम से कम एक स्लाइड पर मौजूदा वीडियो फ्रेम होना आवश्यक है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoFrame

presentation = Presentation("training.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            shape.setFullScreenMode(True)
            break

    presentation.save("full_screen_video.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

पूरी स्क्रीन प्लेबैक नियंत्रित करता है कि वीडियो कैसे प्रदर्शित होता है। स्वतंत्र रूप से, [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) निर्धारित करता है कि यह स्वचालित रूप से या क्लिक पर शुरू हो, और [setPlayLoopMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode) नियंत्रित करता है कि यह दोहराए या नहीं। प्रारंभ व्यवहार चुनने के लिए, प्लेबैक मोड को [VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/python-java/aspose.slides/videoplaymodepreset/) पर सेट करें। उदाहरण मौजूदा प्रारंभ और लूप सेटिंग्स को बरकरार रखता है।

## **प्लेबैक के बाद वीडियो को रीवाइंड करें**

प्रशिक्षण प्रस्तुति में, डेमोंस्ट्रेशन वीडियो को उसकी शुरुआत पर लौटाना प्रस्तुतकर्ता को फिर से चलाने के लिए तैयार करता है। प्लेबैक समाप्त होने के बाद वीडियो को शुरुआत में लाने के लिए `True` के साथ [setRewindVideo](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setRewindVideo) को कॉल करें।

यह उदाहरण एक प्रस्तुति खोलता है, पहली स्लाइड पर पहला [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) खोजता है, और रीवाइंडिंग को सक्षम करता है। यह लूपिंग को निष्क्रिय करता है ताकि प्लेबैक समाप्त हो सके और क्लिक पर शुरू होने के लिए सेट करता है। इनपुट प्रस्तुति में कम से कम एक स्लाइड पर मौजूदा वीडियो फ्रेम होना आवश्यक है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoFrame, VideoPlayModePreset

presentation = Presentation("training.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            shape.setRewindVideo(True)
            shape.setPlayLoopMode(False)
            shape.setPlayMode(VideoPlayModePreset.OnClick)
            break

    presentation.save("rewind_video.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

रीवाइंड करने से वीडियो शुरुआत में लौट आता है बिना उसे दोबारा शुरू किए। इसके विपरीत, [setPlayLoopMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode) को `True` करने से प्लेबैक स्वचालित रूप से दोहराया जाता है। जब आप चाहते हैं कि वीडियो समाप्त हो और पुनः चलाने के लिए तैयार रहे, तो लूपिंग निष्क्रिय रखें। [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) स्वतंत्र रूप से स्वचालित या क्लिक पर शुरू होने को नियंत्रित करता है; यह उदाहरण [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/python-java/aspose.slides/videoplaymodepreset/) का उपयोग करता है ताकि प्रस्तुतकर्ता तय कर सके कि प्लेबैक कब शुरू हो। लूप सेटिंग के बाद प्लेबैक मोड सेट करें, जैसा कि उदाहरण में दिखाया गया है। रीवाइंडिंग [setFullScreenMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setFullScreenMode) से स्वतंत्र रूप से काम करता है।

## **वीडियो फ्रेम को ट्रिम करें**

[VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setTrimFromStart) और [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setTrimFromEnd) का उपयोग करके प्लेबैक के दौरान वीडियो की शुरुआत या अंत के भाग को छोड़ सकते हैं। दोनों मान मिलीसेकंड में होते हैं। ट्रिमिंग एम्बेडेड वीडियो डेटा को बदले बिना प्लेबैक सेटिंग्स को बदलता है।

**सेट ट्रिम सेटिंग्स**

यह उदाहरण एक स्थानीय वीडियो एम्बेड करता है और प्लेबैक के दौरान पहले 2.5 सेकंड तथा अंतिम एक सेकंड को छोड़ता है। प्लेबैक योग्य भाग रहने के लिए वीडियो की अवधि 3.5 सेकंड से अधिक रखें।

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    video_data = Path("video.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)

    video = presentation.getVideos().addVideo(java_video_data)
    video_frame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video)

    video_frame.setTrimFromStart(2500.0)
    video_frame.setTrimFromEnd(1000.0)

    presentation.save("video_with_trim.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**ट्रिम सेटिंग्स पढ़ें**

यह उदाहरण पहली स्लाइड पर पहले वीडियो फ्रेम के ट्रिम मानों को मिलीसेकंड में प्रिंट करता है। प्रस्तुति में कम से कम एक स्लाइड होना चाहिए। यदि उस स्लाइड में कोई वीडियो फ्रेम नहीं है तो कुछ भी प्रिंट नहीं होगा। पिछले उदाहरण ने 2500 और 1000 मान उत्पन्न किए।

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

Aspose.Slides आपको PowerPoint प्रस्तुतियों में वीडियो फ्रेम के लिए बंद कैप्शन प्रबंधित करने देता है। कैप्शन WebVTT फ़ॉर्मेट में संग्रहीत होते हैं और [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#getCaptionTracks) मेथड के माध्यम से उपलब्ध होते हैं।

### **वीडियो फ्रेम में कैप्शन जोड़ें**

यह उदाहरण एक स्थानीय वीडियो एम्बेड करता है और एक WebVTT कैप्शन ट्रैक लेबल English के साथ जोड़ता है। कैप्शन टाइमस्टैम्प वीडियो से मेल खाने चाहिए। सहेजी गई प्रस्तुति में वीडियो और उसके कैप्शन दोनों शामिल होते हैं।

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    video_data = Path("video.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)

    video = presentation.getVideos().addVideo(java_video_data)
    video_frame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video)

    # WebVTT फ़ाइल से एक नया कैप्शन ट्रैक जोड़ें।
    video_frame.getCaptionTracks().add("English", "track.vtt")

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[CaptionsCollection](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/) क्लास एक ओवरलोड भी प्रदान करती है जिससे आप स्ट्रीम से कैप्शन जोड़ सकते हैं।

### **वीडियो फ्रेम से कैप्शन निकालें**

यह उदाहरण पहली स्लाइड पर वीडियो फ्रेम से सभी कैप्शन ट्रैक को अलग-अलग WebVTT फ़ाइलों के रूप में सहेजता है। क्रमिक संख्याएँ आउटपुट फ़ाइलों को अलग रखती हैं। कंसोल में निकाले गए ट्रैकों की संख्या दिखाई देती है। प्रस्तुति में कम से कम एक स्लाइड होना आवश्यक है।

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

    track_count = 0
    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            for caption_track in shape.getCaptionTracks():
                track_count += 1
                output_path = Path(f"captions_{track_count}.vtt")
                caption_data = bytes(caption_track.getBinaryData())
                output_path.write_bytes(caption_data)

    print(f"Caption tracks extracted: {track_count}")
finally:
    presentation.dispose()
```

प्रत्येक [Captions](https://reference.aspose.com/slides/python-java/aspose.slides/captions/) ऑब्जेक्ट कैप्शन पहचानकर्ता, लेबल, बाइनरी डेटा, और UTF-8 स्ट्रिंग के रूप में कैप्शन टेक्स्ट को उजागर करता है।

### **वीडियो फ्रेम से कैप्शन हटाएँ**

यह उदाहरण पहली स्लाइड पर पहले शेप की स्थिति में वीडियो फ्रेम से सभी कैप्शन हटाता है और परिणाम सहेजता है। यह मानता है कि स्लाइड और शेप मौजूद हैं और शेप एक वीडियो फ्रेम है।

```python
import jpipeline
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

यदि आपको केवल एक ही कैप्शन ट्रैक हटाना है, तो [clear](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#clear) के बजाय [remove](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#remove) या [removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#removeAt) मेथड का उपयोग करें।

### **वीडियो कैप्शन खोजें**

[Captions.getDataAsString](https://reference.aspose.com/slides/python-java/aspose.slides/captions/#getDataAsString) पूरा WebVTT ट्रैक, जिसमें हेडर, टाइमिंग लाइन और कैप्शन टेक्स्ट शामिल है, लौटाता है। आप मेमोरी में कैप्शन को खोज सकते हैं ताकि कोई वाक्यांश और उसका टाइमस्टैम्प मिल सके। उदाहरण के लिए, स्लाइड 2 पर एक English ट्रैक में निम्नलिखित टेक्स्ट हो सकता है।

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

यह उदाहरण `captioned_media.pptx` को खोलता है और प्रत्येक स्लाइड पर प्रत्येक शीर्ष-स्तरीय वीडियो फ्रेम के ट्रैकों को पढ़ने के लिए [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#getCaptionTracks) का उपयोग करता है। साधारण टेक्स्ट क्यू में टाइमिंग लाइन में `-->` होता है, और एक खाली लाइन क्यू को समाप्त करती है। प्रत्येक कैप्शन जिसके भीतर “café” किसी भी केस में मौजूद है, उदाहरण स्लाइड नंबर, ट्रैक लेबल, मूल टाइमिंग लाइन, और पूर्ण कैप्शन प्रिंट करता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation("captioned_media.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if not isinstance(shape, VideoFrame):
                continue
            for track in shape.getCaptionTracks():
                track_text = str(track.getDataAsString())
                lines = iter(track_text.splitlines())
                for timing in lines:
                    if "-->" not in timing:
                        continue
                    caption_lines = []
                    for line in lines:
                        if not line:
                            break
                        caption_lines.append(line)
                    caption = "\n".join(caption_lines)
                    if "café" in caption.casefold():
                        print(f"Slide {slide.getSlideNumber()} | {track.getLabel()} | {timing}")
                        print(caption)
finally:
    presentation.dispose()
```

“café” के लिए खोजने पर नमूना ट्रैक के लिए एक मिलान मिलता है। खोज ट्रैक हेडर को बाहर रखती है और आउटपुट में टाइमिंग सेटिंग और लाइन ब्रेक को बरकरार रखती है।

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **स्लाइड से वीडियो निकालें**

स्लाइड में वीडियो जोड़ने के अलावा, Aspose.Slides आपको प्रस्तुतियों में एम्बेडेड वीडियो निकालने भी देता है।

यह उदाहरण प्रत्येक स्लाइड से एम्बेडेड वीडियो को अलग-अलग क्रमांकित बाइनरी फ़ाइलों में निकालता है। लिंक्ड वीडियो को छोड़ दिया जाता है क्योंकि उनके पास एम्बेडेड डेटा नहीं होता। कंसोल प्रत्येक वीडियो का MIME प्रकार और कुल गिनती प्रिंट करता है। आउटपुट सामान्य `.bin` एक्सटेंशन का उपयोग करता है; आवश्यकतानुसार रिपोर्टेड मीडिया टाइप से मेल खाने के लिए इसे बदलें।

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation("presentation_with_videos.pptx")
try:
    video_count = 0
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, VideoFrame):
                video = shape.getEmbeddedVideo()
                if video is None:
                    print("Skipped a linked video: no embedded data is available.")
                    continue

                video_count += 1
                output_path = Path(f"extracted_video_{video_count}.bin")
                video_data = bytes(video.getBinaryData())
                output_path.write_bytes(video_data)
                print(f"Video {video_count}: {video.getContentType()}")

    print(f"Embedded videos extracted: {video_count}")
finally:
    presentation.dispose()
```

## **अक्सर पूछे जाने वाले प्रश्न**

**वीडियो फ्रेम के लिए कौन से वीडियो प्लेबैक पैरामीटर बदले जा सकते हैं?**

आप [playback mode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) (ऑटो या ऑन क्लिक) और [looping](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode) को नियंत्रित कर सकते हैं। ये विकल्प [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) ऑब्जेक्ट की मेथड्स के माध्यम से उपलब्ध हैं।

**वीडियो जोड़ने से PPTX फ़ाइल आकार पर प्रभाव पड़ता है क्या?**

हाँ। जब आप स्थानीय वीडियो एम्बेड करते हैं, तो बाइनरी डेटा दस्तावेज़ में शामिल हो जाता है, इसलिए प्रस्तुति का आकार फ़ाइल आकार के अनुपात में बढ़ता है। जब आप ऑनलाइन वीडियो को लिंक करते हैं और थंबनेल जोड़ते हैं, तो प्रस्तुति लिंक और प्रीव्यू इमेज को संग्रहीत करती है, न कि वीडियो डेटा, इसलिए आकार वृद्धि आमतौर पर कम होती है।

**क्या मैं मौजूदा वीडियो फ्रेम में वीडियो को उसकी स्थिति और आकार बदले बिना बदल सकता हूँ?**

हाँ। आप फ्रेम के भीतर [video content](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setEmbeddedVideo) को बदल सकते हैं जबकि शेप की ज्यामिति बरकरार रहती है; यह मौजूदा लेआउट में मीडिया को अपडेट करने का सामान्य परिदृश्य है।

**क्या एम्बेडेड वीडियो की कंटेंट टाइप (MIME) निर्धारित की जा सकती है?**

हाँ। एम्बेडेड वीडियो का एक [content type](https://reference.aspose.com/slides/python-java/aspose.slides/video/#getContentType) होता है जिसे आप पढ़ और उपयोग कर सकते हैं, उदाहरण के लिए इसे डिस्क पर सहेजते समय।