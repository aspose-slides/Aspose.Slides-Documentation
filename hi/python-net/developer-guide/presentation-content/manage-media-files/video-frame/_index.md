---
title: Python में प्रस्तुतियों में वीडियो जोड़ें
linktitle: वीडियो फ्रेम
type: docs
weight: 10
url: /hi/python-net/video-frame/
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
description: "Aspose.Slides for Python via .NET का उपयोग करके PowerPoint और OpenDocument स्लाइड में प्रोग्रामेटिकली वीडियो फ्रेम जोड़ने और निकालने के बारे में सीखें। तेज़ गाइड।"
---
## **परिचय**

एक प्रस्तुति में उचित स्थान पर रखा गया वीडियो आपके संदेश को अधिक प्रभावशाली बना सकता है और दर्शकों की भागीदारी स्तर को बढ़ा सकता है।

PowerPoint दो तरीकों से स्लाइड में वीडियो जोड़ने की अनुमति देता है:

* स्थानीय वीडियो जोड़ें या एम्बेड करें (जो आपके कंप्यूटर में संग्रहीत है)
* ऑनलाइन वीडियो जोड़ें (जैसे YouTube से)

आपको प्रस्तुति में वीडियो (वीडियो ऑब्जेक्ट) जोड़ने के लिए, Aspose.Slides निम्नलिखित क्लास प्रदान करता है: [Video](https://reference.aspose.com/slides/hi/python-net/aspose.slides/video/), [VideoFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/videoframe/) और अन्य संबंधित प्रकार।

## **एम्बेडेड वीडियो फ्रेम बनाएं**

यदि आप जिस वीडियो फ़ाइल को अपनी स्लाइड में जोड़ना चाहते हैं वह स्थानीय रूप से संग्रहीत है, तो आप प्रस्तुति में वीडियो एम्बेड करने के लिए एक वीडियो फ्रेम बना सकते हैं।

1. एक नया [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएं।
1. उसका इंडेक्स इस्तेमाल करके स्लाइड का रेफ़रेंस प्राप्त करें।
1. एक [Video](https://reference.aspose.com/slides/hi/python-net/aspose.slides/video/) ऑब्जेक्ट जोड़ें और वीडियो फ़ाइल पथ पास करके वीडियो को प्रस्तुति में एम्बेड करें।
1. एक [VideoFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/videoframe/) ऑब्जेक्ट जोड़ें ताकि वीडियो के लिए फ्रेम बनाया जा सके।  
1. संशोधित प्रस्तुति को सहेजें।

यह Python कोड दिखाता है कि स्थानीय रूप से संग्रहीत वीडियो को प्रस्तुति में कैसे जोड़ा जाए:

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

वैकल्पिक रूप से, आप `add_video_frame(x, y, width, height, fname)` मेथड में फ़ाइल पथ सीधे पास करके भी वीडियो जोड़ सकते हैं:

``` python
import aspose.slides as slides

with slides.Presentation() as pres:
    sld = pres.slides[0]
    vf = sld.shapes.add_video_frame(50, 150, 300, 150, "video1.avi")
```

## **वेब स्रोत से वीडियो के साथ वीडियो फ्रेम बनाएं**

Microsoft [PowerPoint 2013 and newer](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) ऑनलाइन वीडियो को सपोर्ट करता है। यदि आप जिस वीडियो को उपयोग करना चाहते हैं वह ऑनलाइन उपलब्ध है (जैसे YouTube पर), तो आप उसका वेब लिंक इस्तेमाल करके उसे अपनी प्रस्तुति में जोड़ सकते हैं।

1. एक नया [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएं।
1. उसका इंडेक्स इस्तेमाल करके स्लाइड का रेफ़रेंस प्राप्त करें। 
1. एक [Video](https://reference.aspose.com/slides/hi/python-net/aspose.slides/video/) ऑब्जेक्ट जोड़ें और वीडियो का लिंक पास करें।
1. वीडियो फ्रेम के लिए थंबनेल सेट करें। 
1. प्रस्तुति को सहेजें।

यह Python कोड दिखाता है कि वेब से प्राप्त वीडियो को PowerPoint स्लाइड में कैसे जोड़ें:

```python
import aspose.slides as slides
from urllib.request import urlopen

def add_video_from_youyube(pres, videoId):
    # एक videoFrame जोड़ता है
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

## **वीडियो कैप्शन प्रबंधित करें**

Aspose.Slides PowerPoint प्रस्तुतियों में वीडियो फ्रेम के लिए क्लोज़्ड कैप्शन प्रबंधित करने की अनुमति देता है। कैप्शन WebVTT फ़ॉर्मेट में संग्रहीत होते हैं और उन्हें [VideoFrame.caption_tracks](https://reference.aspose.com/slides/hi/python-net/aspose.slides/videoframe/caption_tracks/) प्रॉपर्टी के माध्यम से एक्सेस किया जा सकता है।

**वीडियो फ्रेम में कैप्शन जोड़ें**

कैप्शन जोड़ने के लिए:

1. एक नया [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएं।
1. प्रस्तुति में एक वीडियो जोड़ें।
1. स्लाइड में एक [VideoFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/videoframe/) ऑब्जेक्ट जोड़ें।
1. [caption_tracks](https://reference.aspose.com/slides/hi/python-net/aspose.slides/videoframe/caption_tracks/) द्वारा लौटाए गए [CaptionsCollection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/captionscollection/) का उपयोग करके WebVTT कैप्शन ट्रैक जोड़ें।
1. संशोधित प्रस्तुति को सहेजें।

निम्न कोड दिखाता है कि वीडियो फ्रेम में कैप्शन कैसे जोड़ें:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("video.mp4", "rb") as video_stream:
        video_data = video_stream.read()

    video = presentation.videos.add_video(video_data)

    slide = presentation.slides[0]
    video_frame = slide.shapes.add_video_frame(0, 0, 100, 100, video)

    # WebVTT फ़ाइल से एक नया कैप्शन ट्रैक जोड़ता है.
    video_frame.caption_tracks.add("English", "track.vtt")

    presentation.save("video_with_captions.pptx", slides.export.SaveFormat.PPTX)
```

[CaptionsCollection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/captionscollection/) क्लास एक ओवरलोड भी प्रदान करता है जिससे आप स्ट्रीम से कैप्शन जोड़ सकते हैं।

**वीडियो फ्रेम से कैप्शन निकालें**

कैप्शन निकालने के लिए:

1. वीडियो वाली प्रस्तुति लोड करें।
1. लक्षित [VideoFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/videoframe/) ऑब्जेक्ट खोजें।
1. [caption_tracks](https://reference.aspose.com/slides/hi/python-net/aspose.slides/videoframe/caption_tracks/) संग्रह को इटरেট करें।
1. प्रत्येक कैप्शन ट्रैक को `.vtt` फ़ाइल में सहेजें।

निम्न कोड दिखाता है कि वीडियो फ्रेम से कैप्शन कैसे निकाले जाएँ:

```py
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            for caption_track in shape.caption_tracks:
                # कैप्शन ट्रैक को WebVTT फ़ाइल में सहेजता है.
                file_path = f"{caption_track.caption_id}.vtt"
                with open(file_path, "wb") as track_stream:
                    track_stream.write(bytes(caption_track.binary_data))
```

प्रत्येक [Captions](https://reference.aspose.com/slides/hi/python-net/aspose.slides/captions/) ऑब्जेक्ट कैप्शन पहचानकर्ता, लेबल, बाइनरी डेटा और UTF-8 स्ट्रिंग के रूप में कैप्शन टेक्स्ट प्रदान करता है।

**वीडियो फ्रेम से कैप्शन हटाएँ**

कैप्शन हटाने के लिए:

1. वीडियो वाली प्रस्तुति लोड करें।
1. लक्ष्य [VideoFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/videoframe/) ऑब्जेक्ट प्राप्त करें।
1. [CaptionsCollection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/captionscollection/) से कैप्शन ट्रैक हटाएँ।
1. संशोधित प्रस्तुति को सहेजें।

निम्न कोड दिखाता है कि वीडियो फ्रेम से सभी कैप्शन कैसे हटाएँ:

```py
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    video_frame = slide.shapes[0]  # प्रकार: slides.VideoFrame

    # वीडियो फ्रेम से सभी कैप्शन हटाता है.
    video_frame.caption_tracks.clear()

    presentation.save("video_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

यदि आप केवल एक ही कैप्शन ट्रैक हटाना चाहते हैं, तो [clear](https://reference.aspose.com/slides/hi/python-net/aspose.slides/captionscollection/clear/) के बजाय [remove](https://reference.aspose.com/slides/hi/python-net/aspose.slides/captionscollection/remove/) या [remove_at](https://reference.aspose.com/slides/hi/python-net/aspose.slides/captionscollection/remove_at/) मेथड का उपयोग करें।

## **स्लाइड से वीडियो निकालें**

वीडियो को स्लाइड में जोड़ने के अलावा, Aspose.Slides प्रस्तुतियों में एम्बेडेड वीडियो को निकालने की सुविधा भी देता है।

1. वीडियो वाली प्रस्तुति लोड करने के लिए एक नया [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास बनाएं। 
2. सभी [Slide](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slide/) ऑब्जेक्ट्स को इटरेट करें।
3. सभी [Shape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shape/) ऑब्जेक्ट्स को इटरेट करें ताकि [VideoFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/videoframe/) मिल सके। 
4. वीडियो को डिस्क पर सहेजें।

यह Python कोड दिखाता है कि प्रस्तुति स्लाइड से वीडियो कैसे निकाला जाए:

```python
import aspose.slides as slides

# एक Presentation ऑब्जेक्ट बनाता है जो प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है
with slides.Presentation(path + "Video.pptx") as presentation:
    for shape in presentation.slides[0].shapes:
        if type(shape) is slides.VideoFrame:
            type = shape.embedded_video.content_type
            buffer = shape.embedded_video.binary_data
            with open("NewVideo_out." + type[type.rfind('/') + 1:len(type)], "wb") as stream:
                stream.write(buffer)
```

## **FAQ**

**VideoFrame के लिए कौन‑से वीडियो प्लेबैक पैरामीटर बदले जा सकते हैं?**

आप [playback mode](https://reference.aspose.com/slides/hi/python-net/aspose.slides/videoframe/play_mode/) (ऑटो या क्लिक पर) और [looping](https://reference.aspose.com/slides/hi/python-net/aspose.slides/videoframe/play_loop_mode/) को नियंत्रित कर सकते हैं। ये विकल्प [VideoFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/videoframe/) ऑब्जेक्ट की प्रॉपर्टीज़ के माध्यम से उपलब्ध हैं।

**क्या वीडियो जोड़ने से PPTX फ़ाइल का आकार बढ़ता है?**

हां। जब आप स्थानीय वीडियो एम्बेड करते हैं, तो बाइनरी डेटा दस्तावेज़ में सम्मिलित हो जाता है, इसलिए प्रस्तुति का आकार फ़ाइल के आकार के अनुपात में बढ़ता है। जब आप ऑनलाइन वीडियो जोड़ते हैं, तो केवल लिंक और एक थंबनेल एम्बेड होते हैं, इसलिए आकार वृद्धि कम होती है।

**क्या मैं मौजूदा VideoFrame में वीडियो को उसकी स्थिति और आकार बदले बिना बदल सकता हूँ?**

हां। आप फ्रेम के भीतर [video content](https://reference.aspose.com/slides/hi/python-net/aspose.slides/videoframe/embedded_video/) को बदल सकते हैं जबकि आकार और स्थिति अपरिवर्तित रहती है; यह मौजूदा लेआउट में मीडिया अपडेट करने का सामान्य परिदृश्य है।

**क्या एम्बेडेड वीडियो का कंटेंट टाइप (MIME) निर्धारित किया जा सकता है?**

हां। एम्बेडेड वीडियो का एक [content type](https://reference.aspose.com/slides/hi/python-net/aspose.slides/video/content_type/) होता है जिसे आप पढ़ सकते हैं और उपयोग कर सकते हैं, उदाहरण के लिए जब आप उसे डिस्क पर सहेजते हैं।