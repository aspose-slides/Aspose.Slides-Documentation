---
title: Python में प्रस्तुतियों के लिए वीडियो जोड़ें
linktitle: वीडियो फ्रेम
type: docs
weight: 10
url: /hi/python-net/video-frame/
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
description: "Aspose.Slides for Python via .NET का उपयोग करके PowerPoint और OpenDocument स्लाइड्स में प्रोग्रामेटिक रूप से वीडियो फ्रेम जोड़ने और निकालने के बारे में सीखें। तेज़ कैसे-करे गाइड।"
---
## **परिचय**

प्रस्तुति में सही जगह पर रखा गया वीडियो आपके संदेश को अधिक आकर्षक बना सकता है और दर्शकों के साथ जुड़ाव स्तर को बढ़ा सकता है।

PowerPoint आपको प्रस्तुति में किसी स्लाइड में वीडियो जोड़ने के दो तरीके प्रदान करता है:

* स्थानीय वीडियो जोड़ें या एम्बेड करें (आपके मशीन पर संग्रहीत)
* वेब स्रोत (जैसे YouTube) से ऑनलाइन वीडियो जोड़ें।

आपको प्रस्तुति में वीडियो (वीडियो ऑब्जेक्ट) जोड़ने की सुविधा देने के लिए, Aspose.Slides [Video](https://reference.aspose.com/slides/hi/python-net/aspose.slides/video/) क्लास, [VideoFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/videoframe/) क्लास, और अन्य संबंधित प्रकार प्रदान करता है।

## **एम्बेडेड वीडियो फ्रेम बनाएं**

यदि वह वीडियो फ़ाइल जिसे आप अपनी स्लाइड में जोड़ना चाहते हैं स्थानीय रूप से संग्रहीत है, तो आप प्रस्तुति में वीडियो एम्बेड करने के लिए एक वीडियो फ्रेम बना सकते हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2. स्लाइड के इंडेक्स के माध्यम से उसका रेफ़रेंसे प्राप्त करें।
3. एक [Video](https://reference.aspose.com/slides/hi/python-net/aspose.slides/video/) ऑब्जेक्ट जोड़ें और वीडियो फ़ाइल पथ पास करके वीडियो को प्रस्तुति में एम्बेड करें।
4. वीडियो के लिए एक फ्रेम बनाने हेतु एक [VideoFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/videoframe/) ऑब्जेक्ट जोड़ें।
5. संशोधित प्रस्तुति को सहेजें।

यह Python कोड दर्शाता है कि स्थानीय रूप से संग्रहीत वीडियो को प्रस्तुति में कैसे जोड़ें:

```python
import aspose.slides as slides

with slides.Presentation(path + "pres.pptx") as pres:
    with open("Wildlife.mp4", "br") as fileStream:
        video = pres.videos.add_video(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)

        # पहली स्लाइड प्राप्त करता है और एक वीडियोफ़्रेम जोड़ता है
        pres.slides[0].shapes.add_video_frame(10, 10, 150, 250, video)

        # प्रस्तुति को डिस्क पर सहेजता है
        pres.save(path + "pres-with-video.pptx", slides.export.SaveFormat.PPTX)
```

वैकल्पिक रूप से, आप वीडियो को उसके फ़ाइल पथ को सीधे `add_video_frame(x, y, width, height, fname)` मेथड में पास करके जोड़ सकते हैं:

``` python
import aspose.slides as slides

with slides.Presentation() as pres:
    sld = pres.slides[0]
    vf = sld.shapes.add_video_frame(50, 150, 300, 150, "video1.avi")
```

## **वेब स्रोत से वीडियो के साथ वीडियो फ्रेम बनाएं**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/office/insert-a-video-from-youtube-or-another-site-8340ec69-4cee-4fe1-ab96-4849154bc6db) के नए संस्करण प्रस्तुति में ऑनलाइन वीडियो का समर्थन करते हैं। यदि आप जिस वीडियो का उपयोग करना चाहते हैं वह ऑनलाइन उपलब्ध है (उदा. YouTube पर), तो आप इसे वेब लिंक के माध्यम से अपनी प्रस्तुति में जोड़ सकते हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं
2. स्लाइड के इंडेक्स के माध्यम से उसका रेफ़रेंसे प्राप्त करें।
3. एक [Video](https://reference.aspose.com/slides/hi/python-net/aspose.slides/video/) ऑब्जेक्ट जोड़ें और वीडियो का लिंक पास करें।
4. वीडियो फ्रेम के लिए थंबनेल सेट करें।
5. प्रस्तुति को सहेजें।

यह Python कोड दर्शाता है कि वेब से वीडियो को PowerPoint प्रस्तुति की स्लाइड में कैसे जोड़ें:

```python
import aspose.slides as slides
from urllib.request import urlopen

def add_video_from_youyube(pres, videoId):
    # एक वीडियोफ़्रेम जोड़ता है
    videoFrame = pres.slides[0].shapes.add_video_frame(10, 10, 427, 240, "https://www.youtube.com/embed/" + videoId)
    videoFrame.play_mode = slides.VideoPlayModePreset.AUTO

    # थंबनेल लोड करता है
    thumbnail_uri = "http://img.youtube.com/vi/" + videoId + "/hqdefault.jpg"
    f = urlopen(thumbnail_uri)
    videoFrame.picture_format.picture.image = pres.images.add_image(f.read())


with slides.Presentation() as pres:
    add_video_from_youyube(pres, "s5JbfQZ5Cc0")
    pres.save("AddVideoFrameFromWebSource_out.pptx", slides.export.SaveFormat.PPTX)
```

## **वीडियो फ्रेम ट्रिम करें**

Aspose.Slides आपको वीडियो के कौन से भाग को चलाया जाए, इसे [VideoFrame.trim_from_start](https://reference.aspose.com/slides/hi/python-net/aspose.slides/videoframe/trim_from_start/) और [VideoFrame.trim_from_end](https://reference.aspose.com/slides/hi/python-net/aspose.slides/videoframe/trim_from_end/) के माध्यम से शुरू और अंत से ट्रिम मान सेट करके नियंत्रित करने की अनुमति देता है। दोनों मान मिलिसेकंड में निर्दिष्ट होते हैं और क्रमशः वीडियो की शुरुआत और अंत से कितना समय छोड़ा जाए, यह निर्धारित करते हैं। ये सेटिंग्स प्रस्तुति में वीडियो प्लेबैक सेटिंग्स को बदलती हैं; वे एम्बेडेड वीडियो बाइनरी डेटा को काटती या संशोधित नहीं करतीं।

**ट्रिम सेटिंग्स सेट करें**

वीडियो फ्रेम बनाने और उसकी ट्रिम सेटिंग्स सेट करने के लिए:

1. [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2. प्रस्तुति में एक [Video](https://reference.aspose.com/slides/hi/python-net/aspose.slides/video/) ऑब्जेक्ट जोड़ें।
3. स्लाइड में एक [VideoFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/videoframe/) ऑब्जेक्ट जोड़ें।
4. [VideoFrame.trim_from_start](https://reference.aspose.com/slides/hi/python-net/aspose.slides/videoframe/trim_from_start/) और [VideoFrame.trim_from_end](https://reference.aspose.com/slides/hi/python-net/aspose.slides/videoframe/trim_from_end/) के माध्यम से trim-from-start और trim-from-end मान सेट करें।
5. संशोधित प्रस्तुति को सहेजें।

निम्नलिखित कोड उदाहरण एम्बेडेड वीडियो के प्लेबैक के दौरान पहले 2.5 सेकंड और अंतिम एक सेकंड को छोड़ता है:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("video.mp4", "rb") as video_stream:
        video_data = video_stream.read()

    video = presentation.videos.add_video(video_data)

    slide = presentation.slides[0]
    video_frame = slide.shapes.add_video_frame(50, 50, 640, 360, video)

    video_frame.trim_from_start = 2500.0
    video_frame.trim_from_end = 1000.0

    presentation.save("video_with_trim.pptx", slides.export.SaveFormat.PPTX)
```

**ट्रिम सेटिंग्स पढ़ें**

मौज़ूदा ट्रिम सेटिंग्स को निरीक्षण करने के लिए, प्रस्तुति लोड करें, पहले स्लाइड पर आकृतियों में से एक [VideoFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/videoframe/) ऑब्जेक्ट खोजें, और [VideoFrame.trim_from_start](https://reference.aspose.com/slides/hi/python-net/aspose.slides/videoframe/trim_from_start/) तथा [VideoFrame.trim_from_end](https://reference.aspose.com/slides/hi/python-net/aspose.slides/videoframe/trim_from_end/) के माध्यम से मान पढ़ें।

निम्नलिखित कोड उदाहरण पहले स्लाइड पर पहला वीडियो फ्रेम ढूँढता है और उसके ट्रिम सेटिंग्स को मिलिसेकंड में रिपोर्ट करता है:

```python
import aspose.slides as slides

with slides.Presentation("video_with_trim.pptx") as presentation:
    slide = presentation.slides[0]
    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            video_frame = shape
            trim_from_start = video_frame.trim_from_start
            trim_from_end = video_frame.trim_from_end

            print(f"Trim from start: {trim_from_start} ms")
            print(f"Trim from end: {trim_from_end} ms")
            break
```

## **वीडियो कैप्शन प्रबंधित करें**

Aspose.Slides आपको PowerPoint प्रस्तुतियों में वीडियो फ्रेम के लिए क्लोज्ड कैप्शन प्रबंधित करने की अनुमति देता है। कैप्शन WebVTT फ़ॉर्मेट में संग्रहीत होते हैं और [VideoFrame.caption_tracks](https://reference.aspose.com/slides/hi/python-net/aspose.slides/videoframe/caption_tracks/) प्रॉपर्टी के माध्यम से उपलब्ध होते हैं।

**वीडियो फ्रेम में कैप्शन जोड़ें**

1. [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2. प्रस्तुति में एक वीडियो जोड़ें।
3. स्लाइड में एक [VideoFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/videoframe/) ऑब्जेक्ट जोड़ें।
4. [caption_tracks](https://reference.aspose.com/slides/hi/python-net/aspose.slides/videoframe/caption_tracks/) द्वारा लौटाए गए [CaptionsCollection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/captionscollection/) का उपयोग करके WebVTT कैप्शन ट्रैक जोड़ें।
5. संशोधित प्रस्तुति को सहेजें।

निम्नलिखित कोड दर्शाता है कि वीडियो फ्रेम में कैप्शन कैसे जोड़ें:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("video.mp4", "rb") as video_stream:
        video_data = video_stream.read()

    video = presentation.videos.add_video(video_data)

    slide = presentation.slides[0]
    video_frame = slide.shapes.add_video_frame(0, 0, 100, 100, video)

    # WebVTT फ़ाइल से नया कैप्शन ट्रैक जोड़ता है।
    video_frame.caption_tracks.add("English", "track.vtt")

    presentation.save("video_with_captions.pptx", slides.export.SaveFormat.PPTX)
```

[CaptionsCollection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/captionscollection/) क्लास एक ओवरलोड भी प्रदान करता है जो आपको स्ट्रीम से कैप्शन जोड़ने की अनुमति देता है।

**एक वीडियो फ्रेम से कैप्शन निकालें**

1. वह प्रस्तुति लोड करें जिसमें वीडियो शामिल है।
2. लक्षित [VideoFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/videoframe/) ऑब्जेक्ट खोजें।
3. [caption_tracks](https://reference.aspose.com/slides/hi/python-net/aspose.slides/videoframe/caption_tracks/) संग्रह के माध्यम से इटरेट करें।
4. प्रत्येक कैप्शन ट्रैक को `.vtt` फ़ाइल में सहेजें।

निम्नलिखित कोड दर्शाता है कि वीडियो फ्रेम से कैप्शन कैसे निकालें:

```py
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            for caption_track in shape.caption_tracks:
                # कैप्शन ट्रैक को WebVTT फ़ाइल में सहेजता है।
                file_path = f"{caption_track.caption_id}.vtt"
                with open(file_path, "wb") as track_stream:
                    track_stream.write(bytes(caption_track.binary_data))
```

प्रत्येक [Captions](https://reference.aspose.com/slides/hi/python-net/aspose.slides/captions/) ऑब्जेक्ट कैप्शन पहचानकर्ता, लेबल, बाइनरी डेटा, और कैप्शन टेक्स्ट को UTF-8 स्ट्रिंग के रूप में प्रस्तुत करता है।

**वीडियो फ्रेम से कैप्शन हटाएँ**

1. वह प्रस्तुति लोड करें जिसमें वीडियो शामिल है।
2. लक्षित [VideoFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/videoframe/) ऑब्जेक्ट प्राप्त करें।
3. [CaptionsCollection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/captionscollection/) से कैप्शन ट्रैक हटाएँ।
4. संशोधित प्रस्तुति को सहेजें।

निम्नलिखित कोड दर्शाता है कि एक वीडियो फ्रेम से सभी कैप्शन कैसे हटाएँ:

```py
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    video_frame = slide.shapes[0]  # type: slides.VideoFrame

    # वीडियो फ़्रेम से सभी कैप्शन हटाता है।
    video_frame.caption_tracks.clear()

    presentation.save("video_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

यदि आपको केवल एक कैप्शन ट्रैक हटाना हो, तो [clear](https://reference.aspose.com/slides/hi/python-net/aspose.slides/captionscollection/clear/) के बजाय [remove](https://reference.aspose.com/slides/hi/python-net/aspose.slides/captionscollection/remove/) या [remove_at](https://reference.aspose.com/slides/hi/python-net/aspose.slides/captionscollection/remove_at/) मेथड का उपयोग करें।

## **स्लाइड से वीडियो निकालें**

स्लाइड में वीडियो जोड़ने के अलावा, Aspose.Slides आपको प्रस्तुतियों में एम्बेडेड वीडियो निकालने की सुविधा भी देता है।

1. वीडियो वाली प्रस्तुति लोड करने के लिए [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं। 
2. सभी [Slide](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slide/) ऑब्जेक्ट्स के माध्यम से इटरेट करें।
3. सभी [Shape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shape/) ऑब्जेक्ट्स के माध्यम से इटरेट करें और एक [VideoFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/videoframe/) खोजें। 
4. वीडियो को डिस्क पर सहेजें।

यह Python कोड दर्शाता है कि प्रस्तुति स्लाइड से वीडियो कैसे निकालें:

```python
import aspose.slides as slides

# प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाला Presentation ऑब्जेक्ट बनाता है
with slides.Presentation(path + "Video.pptx") as presentation:
    for shape in presentation.slides[0].shapes:
        if type(shape) is slides.VideoFrame:
            type = shape.embedded_video.content_type
            buffer = shape.embedded_video.binary_data
            with open("NewVideo_out." + type[type.rfind('/') + 1:len(type)], "wb") as stream:
                stream.write(buffer)
```

## **FAQ**

**VideoFrame के लिए कौन से वीडियो प्लेबैक पैरामीटर बदल सकते हैं?**

आप [playback mode](https://reference.aspose.com/slides/hi/python-net/aspose.slides/videoframe/play_mode/) (ऑटो या क्लिक पर) और [looping](https://reference.aspose.com/slides/hi/python-net/aspose.slides/videoframe/play_loop_mode/) को नियंत्रित कर सकते हैं। ये विकल्प [VideoFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/videoframe/) ऑब्जेक्ट की प्रॉपर्टीज़ के माध्यम से उपलब्ध हैं।

**क्या वीडियो जोड़ने से PPTX फ़ाइल का आकार प्रभावित होता है?**

हां। जब आप स्थानीय वीडियो एम्बेड करते हैं, तो बाइनरी डेटा दस्तावेज़ में शामिल हो जाता है, इसलिए प्रस्तुति का आकार फ़ाइल के आकार के अनुपात में बढ़ जाता है। जब आप ऑनलाइन वीडियो जोड़ते हैं, तो केवल एक लिंक और थंबनेल एम्बेड होते हैं, इसलिए आकार वृद्धि कम रहती है।

**क्या मैं मौजूदा VideoFrame में वीडियो को उसकी स्थिति और आकार बदले बिना बदल सकता हूँ?**

हां। आप फ्रेम के भीतर [video content](https://reference.aspose.com/slides/hi/python-net/aspose.slides/videoframe/embedded_video/) को बदल सकते हैं जबकि आकृति की ज्योमेट्री अपरिवर्तित रहती है; यह मौजूदा लेआउट में मीडिया अपडेट करने का सामान्य परिदृश्य है।

**क्या एम्बेडेड वीडियो का कंटेंट टाइप (MIME) निर्धारित किया जा सकता है?**

हां। एम्बेडेड वीडियो का एक [content type](https://reference.aspose.com/slides/hi/python-net/aspose.slides/video/content_type/) होता है जिसे आप पढ़ और उपयोग कर सकते हैं, उदाहरण के लिए इसे डिस्क पर सहेजते समय।