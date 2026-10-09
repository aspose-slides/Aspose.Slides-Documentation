---
title: "Python का उपयोग करके प्रस्तुतियों में वीडियो फ़्रेम प्रबंधित करें"
linktitle: "वीडियो फ़्रेम"
type: docs
weight: 10
url: /hi/python-java/video-frame/
keywords:
- वीडियो जोड़ें
- वीडियो बनाएं
- वीडियो एंबेड करें
- वीडियो निकालें
- वीडियो प्राप्त करें
- वीडियो फ़्रेम
- वेब स्रोत
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java का उपयोग करके PowerPoint और OpenDocument स्लाइड्स में वीडियो फ़्रेम को प्रोग्रामेटिक रूप से जोड़ने और निकालने के बारे में सीखें। तेज़ चरण-दर-चरण मार्गदर्शिका।"
---
## **परिचय**

वीडियो विचारों को समझाने और दर्शकों को जोड़ने में मदद कर सकते हैं। Aspose.Slides for Python via Java आपको स्लाइड्स में वीडियो फ़्रेम जोड़ने, प्लेबैक सेटिंग्स समायोजित करने, कैप्शन प्रबंधित करने और एंबेडेड वीडियो डेटा निकालने की सुविधा देता है।

PowerPoint स्थानीय वीडियो और ऑनलाइन वीडियो, जैसे YouTube वीडियो, के लिंक को समर्थन देता है।

वीडियो डेटा और वीडियो फ़्रेम को दर्शाने के लिए, Aspose.Slides [वीडियो](https://reference.aspose.com/slides/python-java/aspose.slides/video/) क्लास, [वीडियोफ़्रेम](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) क्लास, और अन्य संबंधित प्रकार प्रदान करता है।

## **एक एंबेडेड वीडियो फ़्रेम बनाएं**

यदि वह वीडियो फ़ाइल जिसे आप अपनी स्लाइड में जोड़ना चाहते हैं स्थानीय रूप से संग्रहीत है, तो आप वीडियो फ़्रेम बना सकते हैं ताकि वीडियो को अपनी प्रस्तुति में एंबेड किया जा सके।

यह उदाहरण मौजूदा प्रस्तुति की पहली स्लाइड पर एक स्थानीय वीडियो को एंबेड करता है और परिणाम को सहेजता है। फ़्रेम के निर्देशांक और आयाम पॉइंट्स में होते हैं। Python डिस्क से वीडियो बाइट्स पढ़ता है, और JPype उन्हें जावा बाइट एरे में परिवर्तित करता है इससे पहले कि वीडियो को प्रस्तुति में जोड़ा जाए।

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

आप सीधे एक स्थानीय वीडियो पथ को [addVideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addVideoFrame) को पास कर सकते हैं। यह उदाहरण नई प्रस्तुति की पहली स्लाइड पर वीडियो को एंबेड करता है। वीडियो को तब तक उपलब्ध रहना चाहिए जब तक प्रस्तुति सहेजी न जाए।

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

## **वेब स्रोत से वीडियो के साथ एक वीडियो फ़्रेम बनाएं**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) प्रस्तुतियों में ऑनलाइन वीडियो को समर्थन देता है। आप एक वीडियो फ़्रेम बना सकते हैं जो ऑनलाइन वीडियो, जैसे YouTube वीडियो, से लिंक करता है।

यह उदाहरण YouTube वीडियो लिंक और थंबनेल को पहली स्लाइड पर जोड़ता है। किसी अन्य वीडियो का उपयोग करने के लिए वीडियो पहचानकर्ता को बदलें। [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) मेथड स्वचालित प्लेबैक अनुरोध करता है। थंबनेल डाउनलोड करने और वीडियो चलाने के लिए इंटरनेट एक्सेस आवश्यक है। प्रस्तुति व्यूअर को भी ऑनलाइन वीडियो प्लेबैक का समर्थन करना चाहिए।

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

## **पूर्ण-स्क्रीन मोड में वीडियो चलाएं**

एक प्रशिक्षण प्रस्तुति में, आप सॉफ़्टवेयर डेमोंस्ट्रेशन को पूर्ण-स्क्रीन मोड में चला सकते हैं ताकि दर्शक विवरण देख सकें। प्लेबैक के दौरान इस व्यवहार को सक्षम करने के लिए `True` के साथ [setFullScreenMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setFullScreenMode) को कॉल करें।

यह उदाहरण एक प्रस्तुति खोलता है, पहली स्लाइड पर पहला [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) खोजता है, और पूर्ण-स्क्रीन प्लेबैक सक्षम करता है। इनपुट प्रस्तुति में कम से कम एक स्लाइड में पहली स्लाइड पर मौजूदा वीडियो फ़्रेम होना चाहिए।

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

पूर्ण-स्क्रीन प्लेबैक तय करता है कि वीडियो कैसे प्रदर्शित होता है। स्वतंत्र रूप से, [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) नियंत्रित करता है कि यह स्वचालित रूप से या क्लिक पर शुरू हो, और [setPlayLoopMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode) नियंत्रित करता है कि यह दोहराए। प्रारंभ व्यवहार चुनने के लिए, प्लेबैक मोड को [VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/python-java/aspose.slides/videoplaymodepreset/) पर सेट करें। उदाहरण मौजूदा प्रारंभ और लूप सेटिंग्स को संरक्षित रखता है।

## **प्लेबैक के बाद वीडियो को रीवाइंड करें**

एक प्रशिक्षण प्रस्तुति में, डेमोंस्ट्रेशन वीडियो को उसकी शुरुआत में लौटाना इसे प्रस्तुतकर्ता के फिर से चलाने के लिए तैयार करता है। प्लेबैक समाप्त होने के बाद वीडियो को शुरुआत पर लौटाने के लिए `True` के साथ [setRewindVideo](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setRewindVideo) को कॉल करें।

यह उदाहरण एक प्रस्तुति खोलता है, पहली स्लाइड पर पहला [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) खोजता है, और रीवाइंडिंग सक्षम करता है। यह लूपिंग को अक्षम करता है ताकि प्लेबैक समाप्त हो सके और प्लेबैक को क्लिक पर शुरू करने के लिए सेट करता है। इनपुट प्रस्तुति में कम से कम एक स्लाइड में पहली स्लाइड पर मौजूदा वीडियो फ़्रेम होना चाहिए।

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

रीवाइंडिंग वीडियो को उसकी शुरुआत में वापस ले आती है बिना उसे फिर से शुरू किए। इसके विपरीत, `True` के साथ [setPlayLoopMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode) को कॉल करने पर प्लेबैक स्वचालित रूप से दोहराता है। जब आप चाहते हैं कि वीडियो समाप्त हो और पुनः चलाने के लिए तैयार रहे, तो लूपिंग को अक्षम रखें। [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) स्वतंत्र रूप से स्वचालित या क्लिक-पर स्टार्टअप को नियंत्रित करता है; यह उदाहरण [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/python-java/aspose.slides/videoplaymodepreset/) का उपयोग करता है ताकि प्रस्तुतकर्ता तय करे कि प्लेबैक कब शुरू हो। जैसा कि उदाहरण में दिखाया गया है, लूप सेटिंग के बाद प्लेबैक मोड सेट करें। रीवाइंडिंग [setFullScreenMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setFullScreenMode) से स्वतंत्र रूप से कार्य करता है।

## **वीडियो फ़्रेम को ट्रिम करें**

[VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setTrimFromStart) और [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setTrimFromEnd) का उपयोग करके प्लेबैक के दौरान वीडियो की शुरुआत या अंत के हिस्से को छोड़ सकते हैं। दोनों मान मिलीसेकंड में हैं। ट्रिमिंग एंबेडेड वीडियो डेटा को बदले बिना प्लेबैक सेटिंग्स बदलता है।

**ट्रिम सेटिंग्स सेट करें**

यह उदाहरण एक स्थानीय वीडियो को एंबेड करता है और प्लेबैक के दौरान पहले 2.5 सेकंड और अंतिम एक सेकंड को छोड़ देता है। 3.5 सेकंड से अधिक लंबा वीडियो उपयोग करें ताकि प्लेयोग्य भाग बना रहे।

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

यह उदाहरण पहली स्लाइड पर पहले वीडियो फ़्रेम के ट्रिम मानों को मिलीसेकंड में प्रिंट करता है। प्रस्तुति में कम से कम एक स्लाइड होनी चाहिए। यदि उस स्लाइड में कोई वीडियो फ़्रेम नहीं है, तो कुछ नहीं प्रिंट होगा। पिछले उदाहरण ने मान 2500 और 1000 उत्पन्न किए।

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

Aspose.Slides आपको PowerPoint प्रस्तुतियों में वीडियो फ़्रेम के लिए क्लोज़्ड कैप्शन प्रबंधित करने देता है। कैप्शन WebVTT फ़ॉर्मेट में संग्रहीत होते हैं और [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#getCaptionTracks) मेथड के माध्यम से उपलब्ध होते हैं।

**एक वीडियो फ़्रेम में कैप्शन जोड़ें**

यह उदाहरण एक स्थानीय वीडियो को एंबेड करता है और "English" लेबल वाला WebVTT कैप्शन ट्रैक जोड़ता है। कैप्शन टाइमस्टैम्प वीडियो के साथ मेल खाने चाहिए। सहेजी गई प्रस्तुति में वीडियो और उसके कैप्शन दोनों शामिल होते हैं।

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

[CaptionsCollection](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/) क्लास भी एक ओवरलोड प्रदान करती है जो आपको स्ट्रीम से कैप्शन जोड़ने देती है।

**एक वीडियो फ़्रेम से कैप्शन निकालें**

यह उदाहरण पहली स्लाइड पर वीडियो फ़्रेम से सभी कैप्शन ट्रैक को अलग-अलग WebVTT फ़ाइलों के रूप में सहेजता है। क्रमागत संख्याएँ आउटपुट फ़ाइलों को अलग रखती हैं। कंसोल निकाले गए ट्रैक्स की संख्या रिपोर्ट करता है। प्रस्तुति में कम से कम एक स्लाइड होनी चाहिए।

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

प्रत्येक [Captions](https://reference.aspose.com/slides/python-java/aspose.slides/captions/) ऑब्जेक्ट कैप्शन पहचानकर्ता, लेबल, बाइनरी डेटा, और कैप्शन टेक्स्ट को UTF-8 स्ट्रिंग के रूप में प्रदर्शित करता है।

**एक वीडियो फ़्रेम से कैप्शन हटाएं**

यह उदाहरण पहली स्लाइड पर पहले शेप पोजीशन पर वीडियो फ़्रेम से सभी कैप्शन हटाता है और परिणाम सहेजता है। यह मानता है कि स्लाइड और शेप मौजूद हैं और शेप एक वीडियो फ़्रेम है।

```python
import jpide
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

यदि आपको केवल एक ही कैप्शन ट्रैक हटाना है, तो [remove](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#remove) या [removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#removeAt) मेथड का उपयोग करें, बजाय [clear](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#clear) के।

## **स्लाइड से वीडियो निकालें**

स्लाइड में वीडियो जोड़ने के अलावा, Aspose.Slides आपको प्रस्तुतियों में एंबेडेड वीडियो निकालने की अनुमति देता है।

यह उदाहरण प्रत्येक स्लाइड से एंबेडेड वीडियो को अलग-अलग, क्रमांकित बाइनरी फ़ाइलों में निकालता है। लिंक्ड वीडियो को छोड़ दिया जाता है क्योंकि उनमें कोई एंबेडेड डेटा नहीं होता। कंसोल प्रत्येक वीडियो का MIME टाइप और कुल संख्या प्रिंट करता है। आउटपुट सामान्य `.bin` एक्सटेंशन का उपयोग करता है; आवश्यकता होने पर इसे रिपोर्ट किए गए मीडिया टाइप से मिलाने के लिए बदलें।

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

**किस वीडियो फ़्रेम के लिए कौन से प्लेबैक पैरामीटर बदले जा सकते हैं?**

आप [playback mode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) (स्वतः या क्लिक पर) और [looping](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode) को नियंत्रित कर सकते हैं। ये विकल्प [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) ऑब्जेक्ट के मेथड्स के माध्यम से उपलब्ध हैं।

**क्या वीडियो जोड़ने से PPTX फ़ाइल का आकार बढ़ता है?**

हाँ। जब आप एक स्थानीय वीडियो एंबेड करते हैं, तो बाइनरी डेटा दस्तावेज़ में शामिल हो जाता है, इसलिए प्रस्तुति का आकार फ़ाइल आकार के अनुपात में बढ़ता है। जब आप ऑनलाइन वीडियो के लिंक करते हैं और थंबनेल जोड़ते हैं, तो प्रस्तुति लिंक और प्रीव्यू इमेज को रखती है न कि वीडियो डेटा, इसलिए आकार वृद्धि आमतौर पर कम होती है।

**क्या मैं मौजूदा वीडियो फ़्रेम में वीडियो को उसकी स्थिति और आकार बदले बिना बदल सकता हूँ?**

हाँ। आप फ़्रेम के भीतर [video content](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setEmbeddedVideo) को बदल सकते हैं जबकि शेप की ज्यामिति को संरक्षित रखते हैं; यह मौजूदा लेआउट में मीडिया अपडेट करने का आम परिदृश्य है।

**क्या एंबेडेड वीडियो का कंटेंट टाइप (MIME) निर्धारित किया जा सकता है?**

हाँ। एक एंबेडेड वीडियो का एक [content type](https://reference.aspose.com/slides/python-java/aspose.slides/video/#getContentType) होता है जिसे आप पढ़ सकते हैं और उपयोग कर सकते हैं, उदाहरण के लिए जब इसे डिस्क पर सहेजा जाता है।